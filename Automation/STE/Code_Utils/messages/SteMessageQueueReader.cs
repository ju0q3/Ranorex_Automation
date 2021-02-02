/*
 * Created by Ranorex
 * User: r07000021
 * Date: 2/20/2018
 * Time: 1:58 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.IO;
using System.Text;
using System.Threading;
using STE.Code_Utils.messages.MIS.NS;
using STE.Code_Utils.messages.MIS.CN;
using STE.Code_Utils.messages.PTC;
using STE.Code_Utils.MessageQueues;
using System.Xml.Serialization;

namespace STE.Code_Utils.messages
{
    /// <summary>
    /// Description of SteMessageQueueReader.
    /// </summary>
    public class SteMessageQueueReader
    {
        public SteMessageQueueReader()
        {
        }


        
        // updateMessageHeader needs to be called to make the message match the class
        // Because we cannot have - in classnames, we had to convert messages to use _
        // We also have to have all the tags between <HEADER> and </HEADER> prepended with HEADER_
        // so the objects can be filled upon deserialization.
        private static string updateMessageHeader(string message, string messageId, string className)
        {
            if (message.Contains(messageId))
            {
                message = message.Replace(messageId+">", className+">");
            }
            
            string startTag = "<HEADER>";
            string endTag = "</HEADER>";
            
            int startIndex = message.IndexOf(startTag) + startTag.Length;
            int endIndex = message.IndexOf(endTag, startIndex);
            string headerSubstring = message.Substring(startIndex, endIndex - startIndex);
            
            //prepend HEADER_ to header attribute tags.
            string replaceString = headerSubstring.Replace("</", "</HEADER_");
            replaceString = replaceString.Replace("<", "<HEADER_");
            replaceString = replaceString.Replace("<HEADER_/", "</");
            
            message = message.Replace(headerSubstring, replaceString);
            
            return message;
        }
         
        
        public static MIS.CN.MIS_PrintFax getMessagePrintFaxCNMsmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            MIS.CN.PrintFax printfax = null;
            MIS.CN.MIS_PrintFax mis_printfax = null;
            string message = null;
			XmlSerializer serializer = new XmlSerializer(typeof(MIS.CN.PrintFax));
			
			message = SteMessageQueue.Instance().Receive("PrintFax", "1", filters, timeInSeconds);
			
			if (message == null && retry)
			{
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("PrintFax", "1", filters, timeInSeconds + 5);
			}
			
		    if (message != null)
		    {
		        StringReader reader = new StringReader(message);
		        printfax = (MIS.CN.PrintFax) serializer.Deserialize(reader);
    			mis_printfax = MIS.CN.MIS_PrintFax.fromSerializableObject(printfax);
		    }
			
			return mis_printfax;
        }
        
        public static MIS.NS.MIS_PrintFax getMessagePrintFaxNSMsmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            MIS.NS.PrintFax printfax = null;
            MIS.NS.MIS_PrintFax mis_printfax = null;
            string message = null;
			XmlSerializer serializer = new XmlSerializer(typeof(MIS.NS.PrintFax));
			
			message = SteMessageQueue.Instance().Receive("PrintFax", "1", filters, timeInSeconds);
			
			if (message == null && retry)
			{
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("PrintFax", "1", filters, timeInSeconds + 5);
			}
			
		    if (message != null)
		    {
		        StringReader reader = new StringReader(message);
		        printfax = (MIS.NS.PrintFax) serializer.Deserialize(reader);
    			mis_printfax = MIS.NS.MIS_PrintFax.fromSerializableObject(printfax);
		    }
			
			return mis_printfax;
        }

        
        public static MIS.CN.MIS_ErrorMessageConfig getMessageErrorCNMsmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            MIS.CN.ErrorMessageConfig errormessage = null;
            MIS.CN.MIS_ErrorMessageConfig mis_errormessage = null;
            string message = null;
			XmlSerializer serializer = new XmlSerializer(typeof(MIS.CN.ErrorMessageConfig));
			
			message = SteMessageQueue.Instance().Receive("ErrorMessage", "1", filters, timeInSeconds);
			
			if (message == null && retry)
			{
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("ErrorMessage", "1", filters, timeInSeconds + 5);
			}
			
		    if (message != null)
		    {
    			StringReader reader = new StringReader(message);
    			errormessage = (MIS.CN.ErrorMessageConfig) serializer.Deserialize(reader);
    			mis_errormessage = MIS.CN.MIS_ErrorMessageConfig.fromSerializableObject(errormessage);
		    }
			
			return mis_errormessage;
        }
                
                
        public static MIS.CN.MIS_ErrorMessagesConfig getMessageErrorsCNMsmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            MIS.CN.ErrorMessagesConfig errormessages = null;
            MIS.CN.MIS_ErrorMessagesConfig mis_errormessages = null;
            string message = null;
			XmlSerializer serializer = new XmlSerializer(typeof(MIS.CN.ErrorMessagesConfig));
			
			message = SteMessageQueue.Instance().Receive("ErrorMessages", "1", filters, timeInSeconds);
			
			if (message == null && retry)
			{
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("ErrorMessages", "1", filters, timeInSeconds + 5);
			}
			
		    if (message != null)
		    {
    			StringReader reader = new StringReader(message);
    			errormessages = (MIS.CN.ErrorMessagesConfig) serializer.Deserialize(reader);
    			mis_errormessages = MIS.CN.MIS_ErrorMessagesConfig.fromSerializableObject(errormessages);
		    }
			
			return mis_errormessages;
        }
        
        public static MIS.NS.MIS_ErrorMessageConfig getMessageErrorNSMsmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            MIS.NS.ErrorMessageConfig errormessage = null;
            MIS.NS.MIS_ErrorMessageConfig mis_errormessage = null;
            string message = null;
			XmlSerializer serializer = new XmlSerializer(typeof(MIS.NS.ErrorMessageConfig));
			
			message = SteMessageQueue.Instance().Receive("ErrorMessage", "1", filters, timeInSeconds);
			
			if (message == null && retry)
			{
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("ErrorMessage", "1", filters, timeInSeconds + 5);
			}
			
		    if (message != null)
		    {
    			StringReader reader = new StringReader(message);
    			errormessage = (MIS.NS.ErrorMessageConfig) serializer.Deserialize(reader);
    			mis_errormessage = MIS.NS.MIS_ErrorMessageConfig.fromSerializableObject(errormessage);
		    }
			
			return mis_errormessage;
        }
                
                
        public static MIS.NS.MIS_ErrorMessagesConfig getMessageErrorsNSMsmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            MIS.NS.ErrorMessagesConfig errormessages = null;
            MIS.NS.MIS_ErrorMessagesConfig mis_errormessages = null;
            string message = null;
			XmlSerializer serializer = new XmlSerializer(typeof(MIS.NS.ErrorMessagesConfig));
			
			message = SteMessageQueue.Instance().Receive("ErrorMessages", "1", filters, timeInSeconds);
			
			if (message == null && retry)
			{
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("ErrorMessages", "1", filters, timeInSeconds + 5);
			}
			
		    if (message != null)
		    {
    			StringReader reader = new StringReader(message);
    			errormessages = (MIS.NS.ErrorMessagesConfig) serializer.Deserialize(reader);
    			mis_errormessages = MIS.NS.MIS_ErrorMessagesConfig.fromSerializableObject(errormessages);
		    }
			
			return mis_errormessages;
        }
        
        
        /// <summary>
        /// getMessageDC_ERROR_1 retrieves a DC-ERROR message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_ERROR_1</returns>
        public static PTC_DC_ERROR_1 getMessageDC_ERROR_1Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_ERROR_1 dc_error = null;
            PTC_DC_ERROR_1 ptc_dc_error = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_ERROR_1));
            
            message = SteMessageQueue.Instance().Receive("DC-ERROR", "1", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-ERROR", "1", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-ERROR", "DC_ERROR_1");
                StringReader reader = new StringReader(message);
                dc_error = (DC_ERROR_1) serializer.Deserialize(reader);
                ptc_dc_error = PTC_DC_ERROR_1.fromSerializableObject(dc_error);
            }
            
            return ptc_dc_error;
        }

        /// <summary>
        /// getMessageDG_ERROR_1 retrieves a DG-ERROR message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_ERROR_1</returns>
        public static PTC_DG_ERROR_1 getMessageDG_ERROR_1Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_ERROR_1 dg_error = null;
            PTC_DG_ERROR_1 ptc_dg_error = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_ERROR_1));
            
            message = SteMessageQueue.Instance().Receive("DG-ERROR", "1", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-ERROR", "1", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-ERROR", "DG_ERROR_1");
                StringReader reader = new StringReader(message);
                dg_error = (DG_ERROR_1) serializer.Deserialize(reader);
                ptc_dg_error = PTC_DG_ERROR_1.fromSerializableObject(dg_error);
            }
            
            return ptc_dg_error;
        }

        /// <summary>
        /// getMessageDC_AK01_2 retrieves a DC-AK01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_AK01_2</returns>
        public static PTC_DC_AK01_2 getMessageDC_AK01_2Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_AK01_2 dc_ak01 = null;
            PTC_DC_AK01_2 ptc_dc_ak01 = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_AK01_2));
            
            message = SteMessageQueue.Instance().Receive("DC-AK01", "2", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-AK01", "2", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-AK01", "DC_AK01_2");
                StringReader reader = new StringReader(message);
                dc_ak01 = (DC_AK01_2) serializer.Deserialize(reader);
                ptc_dc_ak01 = PTC_DC_AK01_2.fromSerializableObject(dc_ak01);
            }
            
            return ptc_dc_ak01;
        }

        /// <summary>
        /// getMessageDC_AK01_7 retrieves a DC-AK01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_AK01_7</returns>
        public static PTC_DC_AK01_7 getMessageDC_AK01_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_AK01_7 dc_ak01 = null;
            PTC_DC_AK01_7 ptc_dc_ak01 = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_AK01_7));
            
            message = SteMessageQueue.Instance().Receive("DC-AK01", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-AK01", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-AK01", "DC_AK01_7");
                StringReader reader = new StringReader(message);
                dc_ak01 = (DC_AK01_7) serializer.Deserialize(reader);
                ptc_dc_ak01 = PTC_DC_AK01_7.fromSerializableObject(dc_ak01);
            }
            
            return ptc_dc_ak01;
        }

        /// <summary>
        /// getMessageDC_ASBI_2 retrieves a DC-ASBI message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_ASBI_2</returns>
        public static PTC_DC_ASBI_2 getMessageDC_ASBI_2Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_ASBI_2 dc_asbi = null;
            PTC_DC_ASBI_2 ptc_dc_asbi = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_ASBI_2));
            
            message = SteMessageQueue.Instance().Receive("DC-ASBI", "2", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-ASBI", "2", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-ASBI", "DC_ASBI_2");
                StringReader reader = new StringReader(message);
                dc_asbi = (DC_ASBI_2) serializer.Deserialize(reader);
                ptc_dc_asbi = PTC_DC_ASBI_2.fromSerializableObject(dc_asbi);
            }
            
            return ptc_dc_asbi;
        }

        /// <summary>
        /// getMessageDC_ASBI_7 retrieves a DC-ASBI message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_ASBI_7</returns>
        public static PTC_DC_ASBI_7 getMessageDC_ASBI_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_ASBI_7 dc_asbi = null;
            PTC_DC_ASBI_7 ptc_dc_asbi = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_ASBI_7));
            
            message = SteMessageQueue.Instance().Receive("DC-ASBI", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-ASBI", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-ASBI", "DC_ASBI_7");
                StringReader reader = new StringReader(message);
                dc_asbi = (DC_ASBI_7) serializer.Deserialize(reader);
                ptc_dc_asbi = PTC_DC_ASBI_7.fromSerializableObject(dc_asbi);
            }
            
            return ptc_dc_asbi;
        }

        /// <summary>
        /// getMessageDC_DIBS_2 retrieves a DC-DIBS message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_DIBS_2</returns>
        public static PTC_DC_DIBS_2 getMessageDC_DIBS_2Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_DIBS_2 dc_dibs = null;
            PTC_DC_DIBS_2 ptc_dc_dibs = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_DIBS_2));
            
            message = SteMessageQueue.Instance().Receive("DC-DIBS", "2", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-DIBS", "2", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-DIBS", "DC_DIBS_2");
                StringReader reader = new StringReader(message);
                dc_dibs = (DC_DIBS_2) serializer.Deserialize(reader);
                ptc_dc_dibs = PTC_DC_DIBS_2.fromSerializableObject(dc_dibs);
            }
            
            return ptc_dc_dibs;
        }

        /// <summary>
        /// getMessageDC_DIBS_7 retrieves a DC-DIBS message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_DIBS_7</returns>
        public static PTC_DC_DIBS_7 getMessageDC_DIBS_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_DIBS_7 dc_dibs = null;
            PTC_DC_DIBS_7 ptc_dc_dibs = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_DIBS_7));
            
            message = SteMessageQueue.Instance().Receive("DC-DIBS", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-DIBS", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-DIBS", "DC_DIBS_7");
                StringReader reader = new StringReader(message);
                dc_dibs = (DC_DIBS_7) serializer.Deserialize(reader);
                ptc_dc_dibs = PTC_DC_DIBS_7.fromSerializableObject(dc_dibs);
            }
            
            return ptc_dc_dibs;
        }

        /// <summary>
        /// getMessageDC_ENED_2 retrieves a DC-ENED message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_ENED_2</returns>
        public static PTC_DC_ENED_2 getMessageDC_ENED_2Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_ENED_2 dc_ened = null;
            PTC_DC_ENED_2 ptc_dc_ened = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_ENED_2));
            
            message = SteMessageQueue.Instance().Receive("DC-ENED", "2", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-ENED", "2", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-ENED", "DC_ENED_2");
                StringReader reader = new StringReader(message);
                dc_ened = (DC_ENED_2) serializer.Deserialize(reader);
                ptc_dc_ened = PTC_DC_ENED_2.fromSerializableObject(dc_ened);
            }
            
            return ptc_dc_ened;
        }

        /// <summary>
        /// getMessageDC_ENED_7 retrieves a DC-ENED message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_ENED_7</returns>
        public static PTC_DC_ENED_7 getMessageDC_ENED_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_ENED_7 dc_ened = null;
            PTC_DC_ENED_7 ptc_dc_ened = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_ENED_7));
            
            message = SteMessageQueue.Instance().Receive("DC-ENED", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-ENED", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-ENED", "DC_ENED_7");
                StringReader reader = new StringReader(message);
                dc_ened = (DC_ENED_7) serializer.Deserialize(reader);
                ptc_dc_ened = PTC_DC_ENED_7.fromSerializableObject(dc_ened);
            }
            
            return ptc_dc_ened;
        }

        /// <summary>
        /// getMessageDC_KA01_2 retrieves a DC-KA01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_KA01_2</returns>
        public static PTC_DC_KA01_2 getMessageDC_KA01_2Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_KA01_2 dc_ka01 = null;
            PTC_DC_KA01_2 ptc_dc_ka01 = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_KA01_2));
            
            message = SteMessageQueue.Instance().Receive("DC-KA01", "2", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-KA01", "2", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-KA01", "DC_KA01_2");
                StringReader reader = new StringReader(message);
                dc_ka01 = (DC_KA01_2) serializer.Deserialize(reader);
                ptc_dc_ka01 = PTC_DC_KA01_2.fromSerializableObject(dc_ka01);
            }
            
            return ptc_dc_ka01;
        }

        /// <summary>
        /// getMessageDC_KA01_7 retrieves a DC-KA01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_KA01_7</returns>
        public static PTC_DC_KA01_7 getMessageDC_KA01_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_KA01_7 dc_ka01 = null;
            PTC_DC_KA01_7 ptc_dc_ka01 = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_KA01_7));
            
            message = SteMessageQueue.Instance().Receive("DC-KA01", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-KA01", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-KA01", "DC_KA01_7");
                StringReader reader = new StringReader(message);
                dc_ka01 = (DC_KA01_7) serializer.Deserialize(reader);
                ptc_dc_ka01 = PTC_DC_KA01_7.fromSerializableObject(dc_ka01);
            }
            
            return ptc_dc_ka01;
        }

        /// <summary>
        /// getMessageDC_MESS_2 retrieves a DC-MESS message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_MESS_2</returns>
        public static PTC_DC_MESS_2 getMessageDC_MESS_2Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_MESS_2 dc_mess = null;
            PTC_DC_MESS_2 ptc_dc_mess = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_MESS_2));
            
            message = SteMessageQueue.Instance().Receive("DC-MESS", "2", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-MESS", "2", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-MESS", "DC_MESS_2");
                StringReader reader = new StringReader(message);
                dc_mess = (DC_MESS_2) serializer.Deserialize(reader);
                ptc_dc_mess = PTC_DC_MESS_2.fromSerializableObject(dc_mess);
            }
            
            return ptc_dc_mess;
        }

        /// <summary>
        /// getMessageDC_MESS_7 retrieves a DC-MESS message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_MESS_7</returns>
        public static PTC_DC_MESS_7 getMessageDC_MESS_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_MESS_7 dc_mess = null;
            PTC_DC_MESS_7 ptc_dc_mess = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_MESS_7));
            
            message = SteMessageQueue.Instance().Receive("DC-MESS", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-MESS", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-MESS", "DC_MESS_7");
                StringReader reader = new StringReader(message);
                dc_mess = (DC_MESS_7) serializer.Deserialize(reader);
                ptc_dc_mess = PTC_DC_MESS_7.fromSerializableObject(dc_mess);
            }
            
            return ptc_dc_mess;
        }

        /// <summary>
        /// getMessageDC_TCON_6 retrieves a DC-TCON message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_TCON_6</returns>
        public static PTC_DC_TCON_6 getMessageDC_TCON_6Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_TCON_6 dc_tcon = null;
            PTC_DC_TCON_6 ptc_dc_tcon = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_TCON_6));
            
            message = SteMessageQueue.Instance().Receive("DC-TCON", "6", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-TCON", "6", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-TCON", "DC_TCON_6");
                StringReader reader = new StringReader(message);
                dc_tcon = (DC_TCON_6) serializer.Deserialize(reader);
                ptc_dc_tcon = PTC_DC_TCON_6.fromSerializableObject(dc_tcon);
            }
            
            return ptc_dc_tcon;
        }

        /// <summary>
        /// getMessageDC_TCON_7 retrieves a DC-TCON message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_TCON_7</returns>
        public static PTC_DC_TCON_7 getMessageDC_TCON_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_TCON_7 dc_tcon = null;
            PTC_DC_TCON_7 ptc_dc_tcon = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_TCON_7));
            
            message = SteMessageQueue.Instance().Receive("DC-TCON", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-TCON", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-TCON", "DC_TCON_7");
                StringReader reader = new StringReader(message);
                dc_tcon = (DC_TCON_7) serializer.Deserialize(reader);
                ptc_dc_tcon = PTC_DC_TCON_7.fromSerializableObject(dc_tcon);
            }
            
            return ptc_dc_tcon;
        }

        /// <summary>
        /// getMessageDC_TLST_5 retrieves a DC-TLST message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_TLST_5</returns>
        public static PTC_DC_TLST_5 getMessageDC_TLST_5Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_TLST_5 dc_tlst = null;
            PTC_DC_TLST_5 ptc_dc_tlst = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_TLST_5));
            
            message = SteMessageQueue.Instance().Receive("DC-TLST", "5", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-TLST", "5", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-TLST", "DC_TLST_5");
                StringReader reader = new StringReader(message);
                dc_tlst = (DC_TLST_5) serializer.Deserialize(reader);
                ptc_dc_tlst = PTC_DC_TLST_5.fromSerializableObject(dc_tlst);
            }
            
            return ptc_dc_tlst;
        }

        /// <summary>
        /// getMessageDC_TLST_7 retrieves a DC-TLST message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_TLST_7</returns>
        public static PTC_DC_TLST_7 getMessageDC_TLST_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_TLST_7 dc_tlst = null;
            PTC_DC_TLST_7 ptc_dc_tlst = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_TLST_7));
            
            message = SteMessageQueue.Instance().Receive("DC-TLST", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-TLST", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-TLST", "DC_TLST_7");
                StringReader reader = new StringReader(message);
                dc_tlst = (DC_TLST_7) serializer.Deserialize(reader);
                ptc_dc_tlst = PTC_DC_TLST_7.fromSerializableObject(dc_tlst);
            }
            
            return ptc_dc_tlst;
        }

        /// <summary>
        /// getMessageDC_TRDL_2 retrieves a DC-TRDL message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_TRDL_2</returns>
        public static PTC_DC_TRDL_2 getMessageDC_TRDL_2Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_TRDL_2 dc_trdl = null;
            PTC_DC_TRDL_2 ptc_dc_trdl = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_TRDL_2));
            
            message = SteMessageQueue.Instance().Receive("DC-TRDL", "2", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-TRDL", "2", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-TRDL", "DC_TRDL_2");
                StringReader reader = new StringReader(message);
                dc_trdl = (DC_TRDL_2) serializer.Deserialize(reader);
                ptc_dc_trdl = PTC_DC_TRDL_2.fromSerializableObject(dc_trdl);
            }
            
            return ptc_dc_trdl;
        }

        /// <summary>
        /// getMessageDC_TRDL_7 retrieves a DC-TRDL message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_TRDL_7</returns>
        public static PTC_DC_TRDL_7 getMessageDC_TRDL_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_TRDL_7 dc_trdl = null;
            PTC_DC_TRDL_7 ptc_dc_trdl = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_TRDL_7));
            
            message = SteMessageQueue.Instance().Receive("DC-TRDL", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-TRDL", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-TRDL", "DC_TRDL_7");
                StringReader reader = new StringReader(message);
                dc_trdl = (DC_TRDL_7) serializer.Deserialize(reader);
                ptc_dc_trdl = PTC_DC_TRDL_7.fromSerializableObject(dc_trdl);
            }
            
            return ptc_dc_trdl;
        }

        /// <summary>
        /// getMessageDC_VDME_2 retrieves a DC-VDME message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_VDME_2</returns>
        public static PTC_DC_VDME_2 getMessageDC_VDME_2Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_VDME_2 dc_vdme = null;
            PTC_DC_VDME_2 ptc_dc_vdme = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_VDME_2));
            
            message = SteMessageQueue.Instance().Receive("DC-VDME", "2", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-VDME", "2", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-VDME", "DC_VDME_2");
                StringReader reader = new StringReader(message);
                dc_vdme = (DC_VDME_2) serializer.Deserialize(reader);
                ptc_dc_vdme = PTC_DC_VDME_2.fromSerializableObject(dc_vdme);
            }
            
            return ptc_dc_vdme;
        }

        /// <summary>
        /// getMessageDC_VDME_7 retrieves a DC-VDME message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_VDME_7</returns>
        public static PTC_DC_VDME_7 getMessageDC_VDME_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_VDME_7 dc_vdme = null;
            PTC_DC_VDME_7 ptc_dc_vdme = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_VDME_7));
            
            message = SteMessageQueue.Instance().Receive("DC-VDME", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-VDME", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-VDME", "DC_VDME_7");
                StringReader reader = new StringReader(message);
                dc_vdme = (DC_VDME_7) serializer.Deserialize(reader);
                ptc_dc_vdme = PTC_DC_VDME_7.fromSerializableObject(dc_vdme);
            }
            
            return ptc_dc_vdme;
        }

        /// <summary>
        /// getMessageDC_DSSR_7 retrieves a DC-DSSR message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_DSSR_7</returns>
        public static PTC_DC_DSSR_7 getMessageDC_DSSR_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_DSSR_7 dc_dssr = null;
            PTC_DC_DSSR_7 ptc_dc_dssr = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_DSSR_7));
            
            message = SteMessageQueue.Instance().Receive("DC-DSSR", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DC-DSSR", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DC-DSSR", "DC_DSSR_7");
                StringReader reader = new StringReader(message);
                dc_dssr = (DC_DSSR_7) serializer.Deserialize(reader);
                ptc_dc_dssr = PTC_DC_DSSR_7.fromSerializableObject(dc_dssr);
            }
            
            return ptc_dc_dssr;
        }

        /// <summary>
        /// getMessageDG_AK01_2 retrieves a DG-AK01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_AK01_2</returns>
        public static PTC_DG_AK01_2 getMessageDG_AK01_2Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_AK01_2 dg_ak01 = null;
            PTC_DG_AK01_2 ptc_dg_ak01 = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_AK01_2));
            
            message = SteMessageQueue.Instance().Receive("DG-AK01", "2", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-AK01", "2", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-AK01", "DG_AK01_2");
                StringReader reader = new StringReader(message);
                dg_ak01 = (DG_AK01_2) serializer.Deserialize(reader);
                ptc_dg_ak01 = PTC_DG_AK01_2.fromSerializableObject(dg_ak01);
            }
            
            return ptc_dg_ak01;
        }

        /// <summary>
        /// getMessageDG_AK01_7 retrieves a DG-AK01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_AK01_7</returns>
        public static PTC_DG_AK01_7 getMessageDG_AK01_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_AK01_7 dg_ak01 = null;
            PTC_DG_AK01_7 ptc_dg_ak01 = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_AK01_7));
            
            message = SteMessageQueue.Instance().Receive("DG-AK01", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-AK01", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-AK01", "DG_AK01_7");
                StringReader reader = new StringReader(message);
                dg_ak01 = (DG_AK01_7) serializer.Deserialize(reader);
                ptc_dg_ak01 = PTC_DG_AK01_7.fromSerializableObject(dg_ak01);
            }
            
            return ptc_dg_ak01;
        }

        /// <summary>
        /// getMessageDG_BULI_3 retrieves a DG-BULI message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_BULI_3</returns>
        public static PTC_DG_BULI_3 getMessageDG_BULI_3Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_BULI_3 dg_buli = null;
            PTC_DG_BULI_3 ptc_dg_buli = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_BULI_3));
            
            message = SteMessageQueue.Instance().Receive("DG-BULI", "3", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-BULI", "3", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-BULI", "DG_BULI_3");
                StringReader reader = new StringReader(message);
                dg_buli = (DG_BULI_3) serializer.Deserialize(reader);
                ptc_dg_buli = PTC_DG_BULI_3.fromSerializableObject(dg_buli);
            }
            
            return ptc_dg_buli;
        }

        /// <summary>
        /// getMessageDG_BULI_7 retrieves a DG-BULI message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_BULI_7</returns>
        public static PTC_DG_BULI_7 getMessageDG_BULI_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_BULI_7 dg_buli = null;
            PTC_DG_BULI_7 ptc_dg_buli = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_BULI_7));
            
            message = SteMessageQueue.Instance().Receive("DG-BULI", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-BULI", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-BULI", "DG_BULI_7");
                StringReader reader = new StringReader(message);
                dg_buli = (DG_BULI_7) serializer.Deserialize(reader);
                ptc_dg_buli = PTC_DG_BULI_7.fromSerializableObject(dg_buli);
            }
            
            return ptc_dg_buli;
        }

        /// <summary>
        /// getMessageDG_KA01_2 retrieves a DG-KA01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_KA01_2</returns>
        public static PTC_DG_KA01_2 getMessageDG_KA01_2Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_KA01_2 dg_ka01 = null;
            PTC_DG_KA01_2 ptc_dg_ka01 = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_KA01_2));
            
            message = SteMessageQueue.Instance().Receive("DG-KA01", "2", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-KA01", "2", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-KA01", "DG_KA01_2");
                StringReader reader = new StringReader(message);
                dg_ka01 = (DG_KA01_2) serializer.Deserialize(reader);
                ptc_dg_ka01 = PTC_DG_KA01_2.fromSerializableObject(dg_ka01);
            }
            
            return ptc_dg_ka01;
        }

        /// <summary>
        /// getMessageDG_KA01_7 retrieves a DG-KA01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_KA01_7</returns>
        public static PTC_DG_KA01_7 getMessageDG_KA01_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_KA01_7 dg_ka01 = null;
            PTC_DG_KA01_7 ptc_dg_ka01 = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_KA01_7));
            
            message = SteMessageQueue.Instance().Receive("DG-KA01", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-KA01", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-KA01", "DG_KA01_7");
                StringReader reader = new StringReader(message);
                dg_ka01 = (DG_KA01_7) serializer.Deserialize(reader);
                ptc_dg_ka01 = PTC_DG_KA01_7.fromSerializableObject(dg_ka01);
            }
            
            return ptc_dg_ka01;
        }

        /// <summary>
        /// getMessageDG_SGCN_2 retrieves a DG-SGCN message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SGCN_2</returns>
        public static PTC_DG_SGCN_2 getMessageDG_SGCN_2Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SGCN_2 dg_sgcn = null;
            PTC_DG_SGCN_2 ptc_dg_sgcn = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SGCN_2));
            
            message = SteMessageQueue.Instance().Receive("DG-SGCN", "2", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-SGCN", "2", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-SGCN", "DG_SGCN_2");
                StringReader reader = new StringReader(message);
                dg_sgcn = (DG_SGCN_2) serializer.Deserialize(reader);
                ptc_dg_sgcn = PTC_DG_SGCN_2.fromSerializableObject(dg_sgcn);
            }
            
            return ptc_dg_sgcn;
        }

        /// <summary>
        /// getMessageDG_SGCN_7 retrieves a DG-SGCN message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SGCN_7</returns>
        public static PTC_DG_SGCN_7 getMessageDG_SGCN_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SGCN_7 dg_sgcn = null;
            PTC_DG_SGCN_7 ptc_dg_sgcn = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SGCN_7));
            
            message = SteMessageQueue.Instance().Receive("DG-SGCN", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-SGCN", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-SGCN", "DG_SGCN_7");
                StringReader reader = new StringReader(message);
                dg_sgcn = (DG_SGCN_7) serializer.Deserialize(reader);
                ptc_dg_sgcn = PTC_DG_SGCN_7.fromSerializableObject(dg_sgcn);
            }
            
            return ptc_dg_sgcn;
        }

        /// <summary>
        /// getMessageDG_SGIN_2 retrieves a DG-SGIN message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SGIN_2</returns>
        public static PTC_DG_SGIN_2 getMessageDG_SGIN_2Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SGIN_2 dg_sgin = null;
            PTC_DG_SGIN_2 ptc_dg_sgin = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SGIN_2));
            
            message = SteMessageQueue.Instance().Receive("DG-SGIN", "2", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-SGIN", "2", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-SGIN", "DG_SGIN_2");
                StringReader reader = new StringReader(message);
                dg_sgin = (DG_SGIN_2) serializer.Deserialize(reader);
                ptc_dg_sgin = PTC_DG_SGIN_2.fromSerializableObject(dg_sgin);
            }
            
            return ptc_dg_sgin;
        }

        /// <summary>
        /// getMessageDG_SGIN_7 retrieves a DG-SGIN message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SGIN_7</returns>
        public static PTC_DG_SGIN_7 getMessageDG_SGIN_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SGIN_7 dg_sgin = null;
            PTC_DG_SGIN_7 ptc_dg_sgin = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SGIN_7));
            
            message = SteMessageQueue.Instance().Receive("DG-SGIN", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-SGIN", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-SGIN", "DG_SGIN_7");
                StringReader reader = new StringReader(message);
                dg_sgin = (DG_SGIN_7) serializer.Deserialize(reader);
                ptc_dg_sgin = PTC_DG_SGIN_7.fromSerializableObject(dg_sgin);
            }
            
            return ptc_dg_sgin;
        }

        /// <summary>
        /// getMessageDG_SWCN_2 retrieves a DG-SWCN message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SWCN_2</returns>
        public static PTC_DG_SWCN_2 getMessageDG_SWCN_2Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SWCN_2 dg_swcn = null;
            PTC_DG_SWCN_2 ptc_dg_swcn = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SWCN_2));
            
            message = SteMessageQueue.Instance().Receive("DG-SWCN", "2", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-SWCN", "2", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-SWCN", "DG_SWCN_2");
                StringReader reader = new StringReader(message);
                dg_swcn = (DG_SWCN_2) serializer.Deserialize(reader);
                ptc_dg_swcn = PTC_DG_SWCN_2.fromSerializableObject(dg_swcn);
            }
            
            return ptc_dg_swcn;
        }

        /// <summary>
        /// getMessageDG_SWCN_7 retrieves a DG-SWCN message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SWCN_7</returns>
        public static PTC_DG_SWCN_7 getMessageDG_SWCN_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SWCN_7 dg_swcn = null;
            PTC_DG_SWCN_7 ptc_dg_swcn = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SWCN_7));
            
            message = SteMessageQueue.Instance().Receive("DG-SWCN", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-SWCN", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-SWCN", "DG_SWCN_7");
                StringReader reader = new StringReader(message);
                dg_swcn = (DG_SWCN_7) serializer.Deserialize(reader);
                ptc_dg_swcn = PTC_DG_SWCN_7.fromSerializableObject(dg_swcn);
            }
            
            return ptc_dg_swcn;
        }

        /// <summary>
        /// getMessageDG_SWIN_2 retrieves a DG-SWIN message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SWIN_2</returns>
        public static PTC_DG_SWIN_2 getMessageDG_SWIN_2Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SWIN_2 dg_swin = null;
            PTC_DG_SWIN_2 ptc_dg_swin = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SWIN_2));
            
            message = SteMessageQueue.Instance().Receive("DG-SWIN", "2", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-SWIN", "2", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-SWIN", "DG_SWIN_2");
                StringReader reader = new StringReader(message);
                dg_swin = (DG_SWIN_2) serializer.Deserialize(reader);
                ptc_dg_swin = PTC_DG_SWIN_2.fromSerializableObject(dg_swin);
            }
            
            return ptc_dg_swin;
        }

        /// <summary>
        /// getMessageDG_SWIN_7 retrieves a DG-SWIN message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SWIN_7</returns>
        public static PTC_DG_SWIN_7 getMessageDG_SWIN_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SWIN_7 dg_swin = null;
            PTC_DG_SWIN_7 ptc_dg_swin = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SWIN_7));
            
            message = SteMessageQueue.Instance().Receive("DG-SWIN", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-SWIN", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-SWIN", "DG_SWIN_7");
                StringReader reader = new StringReader(message);
                dg_swin = (DG_SWIN_7) serializer.Deserialize(reader);
                ptc_dg_swin = PTC_DG_SWIN_7.fromSerializableObject(dg_swin);
            }
            
            return ptc_dg_swin;
        }

        /// <summary>
        /// getMessageDG_SY01_2 retrieves a DG-SY01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SY01_2</returns>
        public static PTC_DG_SY01_2 getMessageDG_SY01_2Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SY01_2 dg_sy01 = null;
            PTC_DG_SY01_2 ptc_dg_sy01 = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SY01_2));
            
            message = SteMessageQueue.Instance().Receive("DG-SY01", "2", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-SY01", "2", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-SY01", "DG_SY01_2");
                StringReader reader = new StringReader(message);
                dg_sy01 = (DG_SY01_2) serializer.Deserialize(reader);
                ptc_dg_sy01 = PTC_DG_SY01_2.fromSerializableObject(dg_sy01);
            }
            
            return ptc_dg_sy01;
        }

        /// <summary>
        /// getMessageDG_SY01_7 retrieves a DG-SY01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SY01_7</returns>
        public static PTC_DG_SY01_7 getMessageDG_SY01_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SY01_7 dg_sy01 = null;
            PTC_DG_SY01_7 ptc_dg_sy01 = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SY01_7));
            
            message = SteMessageQueue.Instance().Receive("DG-SY01", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-SY01", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-SY01", "DG_SY01_7");
                StringReader reader = new StringReader(message);
                dg_sy01 = (DG_SY01_7) serializer.Deserialize(reader);
                ptc_dg_sy01 = PTC_DG_SY01_7.fromSerializableObject(dg_sy01);
            }
            
            return ptc_dg_sy01;
        }

        /// <summary>
        /// getMessageDG_TAUT_3 retrieves a DG-TAUT message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_TAUT_3</returns>
        public static PTC_DG_TAUT_3 getMessageDG_TAUT_3Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_TAUT_3 dg_taut = null;
            PTC_DG_TAUT_3 ptc_dg_taut = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_TAUT_3));
            
            message = SteMessageQueue.Instance().Receive("DG-TAUT", "3", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-TAUT", "3", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-TAUT", "DG_TAUT_3");
                StringReader reader = new StringReader(message);
                dg_taut = (DG_TAUT_3) serializer.Deserialize(reader);
                ptc_dg_taut = PTC_DG_TAUT_3.fromSerializableObject(dg_taut);
            }
            
            return ptc_dg_taut;
        }

        /// <summary>
        /// getMessageDG_TAUT_7 retrieves a DG-TAUT message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_TAUT_7</returns>
        public static PTC_DG_TAUT_7 getMessageDG_TAUT_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_TAUT_7 dg_taut = null;
            PTC_DG_TAUT_7 ptc_dg_taut = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_TAUT_7));
            
            message = SteMessageQueue.Instance().Receive("DG-TAUT", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-TAUT", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-TAUT", "DG_TAUT_7");
                StringReader reader = new StringReader(message);
                dg_taut = (DG_TAUT_7) serializer.Deserialize(reader);
                ptc_dg_taut = PTC_DG_TAUT_7.fromSerializableObject(dg_taut);
            }
            
            return ptc_dg_taut;
        }

        /// <summary>
        /// getMessageDG_TRDL_2 retrieves a DG-TRDL message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_TRDL_2</returns>
        public static PTC_DG_TRDL_2 getMessageDG_TRDL_2Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_TRDL_2 dg_trdl = null;
            PTC_DG_TRDL_2 ptc_dg_trdl = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_TRDL_2));
            
            message = SteMessageQueue.Instance().Receive("DG-TRDL", "2", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-TRDL", "2", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-TRDL", "DG_TRDL_2");
                StringReader reader = new StringReader(message);
                dg_trdl = (DG_TRDL_2) serializer.Deserialize(reader);
                ptc_dg_trdl = PTC_DG_TRDL_2.fromSerializableObject(dg_trdl);
            }
            
            return ptc_dg_trdl;
        }

        /// <summary>
        /// getMessageDG_TRDL_7 retrieves a DG-TRDL message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_TRDL_7</returns>
        public static PTC_DG_TRDL_7 getMessageDG_TRDL_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_TRDL_7 dg_trdl = null;
            PTC_DG_TRDL_7 ptc_dg_trdl = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_TRDL_7));
            
            message = SteMessageQueue.Instance().Receive("DG-TRDL", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-TRDL", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-TRDL", "DG_TRDL_7");
                StringReader reader = new StringReader(message);
                dg_trdl = (DG_TRDL_7) serializer.Deserialize(reader);
                ptc_dg_trdl = PTC_DG_TRDL_7.fromSerializableObject(dg_trdl);
            }
            
            return ptc_dg_trdl;
        }

        /// <summary>
        /// getMessageDG_UDIE_5 retrieves a DG-UDIE message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_UDIE_5</returns>
        public static PTC_DG_UDIE_5 getMessageDG_UDIE_5Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_UDIE_5 dg_udie = null;
            PTC_DG_UDIE_5 ptc_dg_udie = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_UDIE_5));
            
            message = SteMessageQueue.Instance().Receive("DG-UDIE", "5", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-UDIE", "5", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-UDIE", "DG_UDIE_5");
                StringReader reader = new StringReader(message);
                dg_udie = (DG_UDIE_5) serializer.Deserialize(reader);
                ptc_dg_udie = PTC_DG_UDIE_5.fromSerializableObject(dg_udie);
            }
            
            return ptc_dg_udie;
        }

        /// <summary>
        /// getMessageDG_UDIE_7 retrieves a DG-UDIE message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_UDIE_7</returns>
        public static PTC_DG_UDIE_7 getMessageDG_UDIE_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_UDIE_7 dg_udie = null;
            PTC_DG_UDIE_7 ptc_dg_udie = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_UDIE_7));
            
            message = SteMessageQueue.Instance().Receive("DG-UDIE", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-UDIE", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-UDIE", "DG_UDIE_7");
                StringReader reader = new StringReader(message);
                dg_udie = (DG_UDIE_7) serializer.Deserialize(reader);
                ptc_dg_udie = PTC_DG_UDIE_7.fromSerializableObject(dg_udie);
            }
            
            return ptc_dg_udie;
        }

        /// <summary>
        /// getMessageDG_VDBI_4 retrieves a DG-VDBI message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_VDBI_4</returns>
        public static PTC_DG_VDBI_4 getMessageDG_VDBI_4Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_VDBI_4 dg_vdbi = null;
            PTC_DG_VDBI_4 ptc_dg_vdbi = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_VDBI_4));
            
            message = SteMessageQueue.Instance().Receive("DG-VDBI", "4", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-VDBI", "4", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-VDBI", "DG_VDBI_4");
                StringReader reader = new StringReader(message);
                dg_vdbi = (DG_VDBI_4) serializer.Deserialize(reader);
                ptc_dg_vdbi = PTC_DG_VDBI_4.fromSerializableObject(dg_vdbi);
            }
            
            return ptc_dg_vdbi;
        }

        /// <summary>
        /// getMessageDG_VDBI_7 retrieves a DG-VDBI message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_VDBI_7</returns>
        public static PTC_DG_VDBI_7 getMessageDG_VDBI_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_VDBI_7 dg_vdbi = null;
            PTC_DG_VDBI_7 ptc_dg_vdbi = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_VDBI_7));
            
            message = SteMessageQueue.Instance().Receive("DG-VDBI", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-VDBI", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-VDBI", "DG_VDBI_7");
                StringReader reader = new StringReader(message);
                dg_vdbi = (DG_VDBI_7) serializer.Deserialize(reader);
                ptc_dg_vdbi = PTC_DG_VDBI_7.fromSerializableObject(dg_vdbi);
            }
            
            return ptc_dg_vdbi;
        }

        /// <summary>
        /// getMessageDG_DSSR_7 retrieves a DG-DSSR message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_DSSR_7</returns>
        public static PTC_DG_DSSR_7 getMessageDG_DSSR_7Msmq(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_DSSR_7 dg_dssr = null;
            PTC_DG_DSSR_7 ptc_dg_dssr = null;
            string message = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_DSSR_7));
            
            message = SteMessageQueue.Instance().Receive("DG-DSSR", "7", filters, timeInSeconds);
            
            if (message == null && retry)
            {
                Thread.Sleep(5000);
                message = SteMessageQueue.Instance().Receive("DG-DSSR", "7", filters, timeInSeconds + 5);
            }

            if (message != null)
            {
                message = updateMessageHeader(message, "DG-DSSR", "DG_DSSR_7");
                StringReader reader = new StringReader(message);
                dg_dssr = (DG_DSSR_7) serializer.Deserialize(reader);
                ptc_dg_dssr = PTC_DG_DSSR_7.fromSerializableObject(dg_dssr);
            }
            
            return ptc_dg_dssr;
        }        
    }
}
