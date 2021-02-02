/*
 * Created by Ranorex
 * User: 212719544
 * Date: 11/13/2019
 * Time: 1:50 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Threading.Tasks;
//using System.Net;
//using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using PDS_CORE.Code_Utils;
using SimpleTcp;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace STE.Code_Utils
{
    /// <summary>
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class Server
    {
        public static TcpServer server;
        public static bool serverStarted = false;
        public static bool steConnected = false;
        public static bool onBoardConnected = false;
        public static bool messageReceived = false;
        
        public static readonly object _messageLock = new object();
        public static readonly object _lock = new object();
        public static readonly Dictionary<string, string> serverClientDictionary = new Dictionary<string, string>();
        public static readonly Dictionary<string, string> reverseServerClientDictionary = new Dictionary<string, string>();
        
        [UserCodeMethod]
        public static void StartServer(string serverIpAddress, int serverPort)
        {
            server = new TcpServer(serverIpAddress, serverPort, false, null, null);
            server.ClientConnected += ClientConnected;
            server.ClientDisconnected += ClientDisconnected;
            server.DataReceived += DataReceived;
            
            server.Start();
            serverStarted = true;
            Ranorex.Delay.Seconds(5);
            return;
        }
        
        public static Task ClientConnected(string client)
        {
            Ranorex.Report.Info(client + " connected.");
            return Task.CompletedTask;
        }
        
        public static Task ClientDisconnected(string client, DisconnectReason reason)
        {
            lock (_lock) if (reverseServerClientDictionary.ContainsKey(client))
            {
                if (reverseServerClientDictionary[client] == "ONB")
                {
                    onBoardConnected = false;
                } else if (reverseServerClientDictionary[client] == "STE")
                {
                    steConnected = false;
                }
                serverClientDictionary.Remove(reverseServerClientDictionary[client]);
                reverseServerClientDictionary.Remove(client);
            }
            return Task.CompletedTask;
        }
        
        public static Task DataReceived(string client, byte[] data)
        {
        	try
        	{
        		string readData = Encoding.UTF8.GetString(data);
        		
        		//If it's a size of 3, we'll assume it's the identifier
        		if (readData.Length == 3)
        		{
        			lock (_lock) serverClientDictionary.Add(readData, client);
        			lock (_lock) reverseServerClientDictionary.Add(client, readData);
        			if (readData == "ONB")
        			{
        				onBoardConnected = true;
        			} else if (readData == "STE")
        			{
        				steConnected = true;
        			} else {
        				Ranorex.Report.Error("Unknown Data Received implying new Client of {" + client + "} with moniker of {" + readData + "}");
        			}
        			return Task.CompletedTask;
        		}
        		
        		string[] splitReadData = readData.Split('|');
        		foreach (string result in splitReadData)
        		{
        			if (result.StartsWith("Failure: "))
        			{
        				Ranorex.Report.Failure(result.Remove(0, 9));
        			} else if (result.StartsWith("Success: "))
        			{
        				Ranorex.Report.Success(result.Remove(0, 9));
        			}else if (result.StartsWith("Warn: "))
        			{
        				Ranorex.Report.Warn(result.Remove(0, 6));
        			} else if (result.StartsWith("Error: "))
        			{
        				Ranorex.Report.Error(result.Remove(0, 7));
        			} else if (result.StartsWith("Info: "))
        			{
        				Ranorex.Report.Info(result.Remove(0, 6));
        			} else {
        				Ranorex.Report.Error("Received unknown return of {" + result + "}.");
        			}
        		}
        		lock (_messageLock) messageReceived = true;
        		
        	}
        	catch (Exception e)
        	{
        		Ranorex.Report.Failure("Data Received Exception: "+e.StackTrace.ToString());
        		lock (_messageLock) messageReceived = false;
			}
        	return Task.CompletedTask;
            
        }
        
        
        [UserCodeMethod]
        public static void SendCommandToOnboard(string functionalArea, string command, string pipeSeparatedParameters)
        {
        	Report.Info("PipeSeparatedParameters: "+pipeSeparatedParameters);
            SendCommandToClient(functionalArea, command, pipeSeparatedParameters, "ONB");
        }
        
        [UserCodeMethod]
        public static void SendCommandToSTE(string message)
        {
            SendCommandToClient("", message, "", "STE");
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        public static void SendCommandToClient(string functionalArea, string command, string pipeSeparatedParameters, string clientName)
        {
        	try
        	{
        		lock (_messageLock) messageReceived = false;
        		if (!serverStarted)
        		{
        			Ranorex.Report.Failure("You must first start the server to communicate to external instances of Ranorex/STE");
        			return;
        		}
        		
        		//First check to make sure the onBoard has been connected to
        		bool hasTheKey = false;
        		lock (_lock) hasTheKey = serverClientDictionary.ContainsKey(clientName);
        		if (!hasTheKey)
        		{
        			//Show popup that the server and onboard are not currently connected, then rerun the command until a connection can be made
        			//Not rerunning the command would result in loss in test sequence
        			WinForms.MessageBox.Show("Not currently connected to Onboard. Ensure Ranorex is running on the Onboard machine.", "Error",
        			                         WinForms.MessageBoxButtons.OK);
        			SendCommandToClient(functionalArea, command, pipeSeparatedParameters, clientName);
        			return;
        		}
        		
        		string client;
        		lock (_lock) client = serverClientDictionary[clientName];
        		
        		//Attempt to send a "Heartbeat" to check that we can in-fact communicate with the Onboard
        		//First we need to tell the receiver what size it is
        		server.Send(client, Encoding.UTF8.GetBytes("1"));
        		
        		if (!server.IsConnected(client))
        		{
        			//If we fail to have a connection, then we should remove the client from the dictionary and attempt to reconnect.
        			lock (_lock) serverClientDictionary.Remove(clientName);
        			SendCommandToClient(functionalArea, command, pipeSeparatedParameters, clientName);
        			return;
        		}
        		
        		string onBoardMessage = "";
        		
        		if (clientName == "STE")
        		{
        			onBoardMessage = command;
        		} else {
        			onBoardMessage = string.Join("&", new List<string>{functionalArea, command, pipeSeparatedParameters});
        		}
        		
        		server.Send(client, Encoding.UTF8.GetBytes(onBoardMessage));
        		
        		//Now we need to wait for the message return
        		bool hasMessageBeenReceived = false;
        		lock (_messageLock) hasMessageBeenReceived = messageReceived;
        		
        		System.DateTime expirationTime = System.DateTime.Now.AddMinutes(15);
        		while (!hasMessageBeenReceived && (System.DateTime.Now < expirationTime ))
        		{
        			Ranorex.Delay.Milliseconds(500);
        			lock (_messageLock) hasMessageBeenReceived = messageReceived;
        		}
        		return;
        	}
        	catch(Exception e)
        	{
        		Ranorex.Report.Failure("Send Command Exception: "+e.StackTrace.ToString());
        	}
            
        }
    }
}
