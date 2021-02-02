/*
 * Created by Ranorex
 * User: r07000021
 * Date: 2/2/2018
 * Time: 7:09 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.IO;
using System.Text;
using System.Messaging;
using Env.Code_Utils;

namespace STE.Code_Utils.MessageQueues
{
    /// <summary>
    /// Description of SteMessageQueueUtility.
    /// </summary>
    public class SteMessageQueue
    {
        private static SteMessageQueue instance;
        
        public MessageQueue sendQueue = null;
        public MessageQueue receiveQueue = null;
        private DateTime now;

        public static SteMessageQueue Instance()
        {
            if (instance == null)
            {
                instance = new SteMessageQueue();
            }
            return instance;
        }
        
        private SteMessageQueue()
        {
            CreateMessageQueues();
            //InitiateStartSession();
        }
        
        private void CreateMessageQueues()
        {
            string ste = VMEnvironment.Instance().ste;
            
            MessagePropertyFilter filter = new MessagePropertyFilter();
            filter.ClearAll();
            filter.Body = true;
            filter.Label = true;
            filter.Id = true;
            filter.ArrivedTime = true;
        
            
            sendQueue = new MessageQueue(".\\Private$\\AUTOMATION.SEND."+ste);
            sendQueue.MessageReadPropertyFilter = filter;
            sendQueue.Formatter = new XmlMessageFormatter(new Type[] {typeof(string) });
            
            receiveQueue = new MessageQueue(".\\Private$\\AUTOMATION.RECEIVE."+ste); 
            receiveQueue.MessageReadPropertyFilter = filter;        
            receiveQueue.Formatter = new XmlMessageFormatter(new Type[] {typeof(string) });            
        }
        
        
        private void InitiateStartSession()
        {
            now = DateTime.Now;
            Message sessionStartResponse = null;
            
            sendQueue.Purge();
            receiveQueue.Purge();
            sendQueue.Send("SESSION_START "+  now.ToString("MMddyyyyHHmm"));             

            try 
            {
                sessionStartResponse = receiveQueue.Receive(new TimeSpan(0,0,60));
            }
            catch (MessageQueueException mqException)
            {
                if (mqException.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
                {
                    try 
                    {
                        sessionStartResponse = receiveQueue.Receive(new TimeSpan(0,0,60));
                    }
                    catch (MessageQueueException imqException)
                    {
                        if (imqException.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
                        {
                            Ranorex.Report.Failure("Failed to connect with STE via MSMQ.  Check that Message Queues are up and STE is running.");
                        }
        
                    }

                }

            }
                        
        }
        
        
        public void Purge(MessageQueue msQueue)
        {
            msQueue.Purge();
        }
        
        public void Send(string message, string label)
        {
            sendQueue.Send(message, label);
        }
        
        /*******This is Test Code*******/
        public void GetSendQueueAllMessages()
        {
            String message = null;
            Message[] messages = sendQueue.GetAllMessages();
            foreach (Message msg in messages)
            {
                msg.Formatter = new XmlMessageFormatter(new Type[] {typeof(string) });
                message = (String) msg.Body;
                message = "I see your "+ message + " in the send Queue and return with a message that is intentionally left blank";
                Send(message, "response");
            }
        }
        
        /*******This is Test Code*******/
        public void GetReceiveQueueAllMessages()
        {
            String message = null;
            Message[] messages = receiveQueue.GetAllMessages();
            foreach (Message msg in messages)
            {
                StreamReader  sr = new StreamReader(msg.BodyStream);
                message = "";
                while (sr.Peek() >= 0)
                {
                    message += sr.ReadLine();
                }

                message = "I see your "+ message + " in the receive Queue return with a message that is intentionally left blank";
                Send(message, "response");
            }
        }
        
        public string Receive(string messageType, string version, string[] filters, int timeInSeconds=5 )
        {
            string message = null;
            bool filterCheck = true;
            DateTime fromDate = DateTime.Now.AddSeconds(-System.Math.Abs(timeInSeconds));
            
            StringBuilder msgIdBuilder = new StringBuilder();
            msgIdBuilder.Append("<MESSAGE_ID>");
            msgIdBuilder.Append(messageType);
            msgIdBuilder.Append("</MESSAGE_ID>");
            string messageId = msgIdBuilder.ToString();
            
            StringBuilder msgVersionBuilder = new StringBuilder();
            msgVersionBuilder.Append("<MESSAGE_VERSION>");
            msgVersionBuilder.Append(version);
            msgVersionBuilder.Append("</MESSAGE_VERSION>");
            string messageVersion = msgVersionBuilder.ToString();
            
            try 
            {
                Message[] messages = receiveQueue.GetAllMessages();
                foreach (Message msg in messages)
                {
                    if (msg.ArrivedTime >= fromDate)
                    {
                        StreamReader  sr = new StreamReader(msg.BodyStream);
                        message = "";
                        while (sr.Peek() >= 0)
                        {
                            message += sr.ReadLine();
                        }
                        
                        if (message.Contains(messageId) && message.Contains(messageVersion))
                        {
                            filterCheck = true;
                            if (filters != null && filters.Length > 0)
                            {
                                foreach (string filter in filters)
                                {
                                    if (!message.Contains(filter))
                                    {
                                        filterCheck = false;
                                        break;
                                    }
                                }   
                            }
                            
                            if (filterCheck)
                            {
                                message = (String) sendQueue.ReceiveById(msg.Id).Body;
                                return message;
                            }
                        }
                    }
                }
            
            }
            catch (MessageQueueException mqException)
            {
                if (mqException.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
                {
                    Console.WriteLine("Receive Timeout");
                }
                // do something with exception
            }
            
            //receiveQueue.Receive();
            
            return message;
        }
    }


}
