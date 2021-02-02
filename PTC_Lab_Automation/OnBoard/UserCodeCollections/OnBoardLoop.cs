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
using System.Linq;
//using System.Net;
//using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Reflection;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using SimpleTcp;

using PDS_NS.UserCodeCollections;

namespace OnBoard.UserCodeCollections
{
    /// <summary>
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class OnBoardLoop
    {
        public static string serverIPAddress = "3.11.52.108";
        public static int serverPort = 2005;
        public static TcpClient client;
        public static bool clientConnected = false;
        
        private static void ConnectToServer()
        {
            try {
                serverIPAddress = TestSuite.Current.Parameters["ServerIPAddress"];
                serverPort = int.Parse(TestSuite.Current.Parameters["ServerPort"]);
            } catch {
                Ranorex.Report.Info("Could not set the Parameters for connecting to the server from the TestSuite");
            }
            
            client = new TcpClient(serverIPAddress, serverPort, false, null, null);
            client.Connected += Connected;
            client.Disconnected += Disconnected;
            client.DataReceived += DataReceived;
            
            while (!clientConnected)
            {
                try {
                    client.Connect();
                    clientConnected = true;
//                    if(LogAgentLoop.logAgentTask.ThreadState.Equals("Unstarted"))
//                    {
//                    	LogAgentLoop.logAgentTask.Join();
//                    	LogAgentLoop.StartLogAgent();
//                    }
//                    Report.Info("Thread State: "+LogAgentLoop.logAgentTask.ThreadState.ToString());
                    //LogFunctions.TurnOnboardLoggingOn_LogManager();
                } catch (Exception ex)
                {
            		Thread.Sleep(2000);
                    clientConnected = false;
                }
            }
            return;
        }
        
        public static Task DataReceived(byte[] data)
        {
            string command = Encoding.UTF8.GetString(data);
            if (command != "1")
            {
                string returnData = RunOnboardFunction(command);
                client.Send(Encoding.UTF8.GetBytes(returnData));
            }
                    
            return Task.CompletedTask;
        }
        
        public static Task Connected()
        {
            Ranorex.Report.Info("Connected");
            client.Send(Encoding.UTF8.GetBytes("ONB"));
            return Task.CompletedTask;
        }
        
        public static Task Disconnected()
        {
            Ranorex.Report.Info("Disconnected");
            clientConnected = false;
            ConnectToServer();
            return Task.CompletedTask;
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static void MainOnBoardLoopFunction()
        {
        	try
        	{
        		ConnectToServer();
        		while (true)
        		{
        			try
        			{
        				
        			}
        			catch(Exception e)
        			{
        				Report.Failure("Found Exception: "+e.ToString());
        			}
        		}
        	}
        	catch(Exception e)
        	{
        		Report.Failure("Found Exception: "+e.StackTrace);
        	}
            
        }
        
        public static string RunOnboardFunction(string onBoardFunctionString)
        {
        	//Report.Info("Onboard function: "+onBoardFunctionString);
            string[] splitOnBoardFunctionString = onBoardFunctionString.Split('&');
            if (splitOnBoardFunctionString.Length < 3)
            {
                return "Error: Length of command sent to onBoard is too short. Format is {functionalArea,command,pipeSeparatedParameters}, must have at least functionalArea and command";
            }
            
            IList<string> parameters = new List<string>();
            
            if (splitOnBoardFunctionString[2] != "")
            {
                parameters = splitOnBoardFunctionString[2].Split('|');
            }
            
            
            //Switch based on functional area
            switch (splitOnBoardFunctionString[0])
            {
//                case "TestFunc":
//                    MethodInfo testFuncMethod = typeof(NS_LogonLogoff).GetMethod(splitOnBoardFunctionString[1]);
//                    if (testFuncMethod == null)
//                    {
//                        return "Error: Could not find Method Name {NS_LogonLogoff." + splitOnBoardFunctionString[1] + "}.";
//                    } else {
//                        ParameterInfo[] parametersInfo = testFuncMethod.GetParameters();
//                        if (parametersInfo.Length > parameters.Count)
//                        {
//                            int currentParameterCount = parameters.Count;
//                            for (int i = currentParameterCount; i < parametersInfo.Length; i++)
//                            {
//                                parameters.Add(parametersInfo[i].DefaultValue.ToString());
//                            }
//                        } else if (parametersInfo.Length < parameters.Count)
//                        {
//                            return "Error: Too many parameters for method NS_LogonLogoff." + splitOnBoardFunctionString[1] + ". Expected {" + parametersInfo.Length.ToString() + "} and got {" + parameters.Count.ToString() + "}.";
//                        }
//                        return (string)testFuncMethod.Invoke(typeof(OnBoardLoop), parameters.Cast<string>().ToArray());
//                    }
                case "OnBoard":
				case "1OnBoard":
                    MethodInfo onBoardMethod = typeof(OnBoardFunctions).GetMethod(splitOnBoardFunctionString[1]);
                    if (onBoardMethod == null)
                    {
                        return "Error: Could not find Method Name {OnBoardFunctions." + splitOnBoardFunctionString[1] + "}.";
                    } else {
                        ParameterInfo[] parametersInfo = onBoardMethod.GetParameters();
                        if (parametersInfo.Length > parameters.Count)
                        {
                            int currentParameterCount = parameters.Count;
                            for (int i = currentParameterCount; i < parametersInfo.Length; i++)
                            {
                                parameters.Add(parametersInfo[i].DefaultValue.ToString());
                            }
                        } else if (parametersInfo.Length < parameters.Count)
                        {
                            return "Error: Too many parameters for method OnBoardFunctions." + splitOnBoardFunctionString[1] + ". Expected {" + parametersInfo.Length.ToString() + "} and got {" + parameters.Count.ToString() + "}.";
                        }
                        return (string)onBoardMethod.Invoke(typeof(OnBoardLoop), parameters.Cast<string>().ToArray());
                    }
                case "LogManager":
                case "1LogManager":
                    MethodInfo logFunctionMethod = typeof(LogFunctions).GetMethod(splitOnBoardFunctionString[1]);
                    if (logFunctionMethod == null)
                    {
                        return "Error: Could not find Method Name {LogFunctions." + splitOnBoardFunctionString[1] + "}.";
                    } else {
                        ParameterInfo[] parametersInfo = logFunctionMethod.GetParameters();
                        if (parametersInfo.Length > parameters.Count)
                        {
                            int currentParameterCount = parameters.Count;
                            for (int i = currentParameterCount; i < parametersInfo.Length; i++)
                            {
                                parameters.Add(parametersInfo[i].DefaultValue.ToString());
                            }
                        } else if (parametersInfo.Length < parameters.Count)
                        {
                            return "Error: Too many parameters for method LogFunctions." + splitOnBoardFunctionString[1] + ". Expected {" + parametersInfo.Length.ToString() + "} and got {" + parameters.Count.ToString() + "}.";
                        }
                        return (string)logFunctionMethod.Invoke(typeof(OnBoardLoop), parameters.Cast<string>().ToArray());
                    }
                case "MotionControl":
                case "1MotionControl":
                    MethodInfo motionControlMethod = typeof(MotionControl).GetMethod(splitOnBoardFunctionString[1]);
                    if (motionControlMethod == null)
                    {
                        return "Error: Could not find Method Name {MotionControl." + splitOnBoardFunctionString[1] + "}.";
                    } else {
                        ParameterInfo[] parametersInfo = motionControlMethod.GetParameters();
                        if (parametersInfo.Length > parameters.Count)
                        {
                            int currentParameterCount = parameters.Count;
                            for (int i = currentParameterCount; i < parametersInfo.Length; i++)
                            {
                                parameters.Add(parametersInfo[i].DefaultValue.ToString());
                            }
                        } else if (parametersInfo.Length < parameters.Count)
                        {
                            return "Error: Too many parameters for method MotionControl." + splitOnBoardFunctionString[1] + ". Expected {" + parametersInfo.Length.ToString() + "} and got {" + parameters.Count.ToString() + "}.";
                        }
                        return (string)motionControlMethod.Invoke(typeof(OnBoardLoop), parameters.Cast<string>().ToArray());
                    }
                    
                case "FieldSimulator":
                case "1FieldSimulator":
                    MethodInfo fieldSimulatorMethod = typeof(FieldSimulator).GetMethod(splitOnBoardFunctionString[1]);
                    if (fieldSimulatorMethod == null)
                    {
                        return "Error: Could not find Method Name {FieldSimulator." + splitOnBoardFunctionString[1] + "}.";
                    } else {
                        ParameterInfo[] parametersInfo = fieldSimulatorMethod.GetParameters();
                        if (parametersInfo.Length > parameters.Count)
                        {
                            int currentParameterCount = parameters.Count;
                            for (int i = currentParameterCount; i < parametersInfo.Length; i++)
                            {
                                parameters.Add(parametersInfo[i].DefaultValue.ToString());
                            }
                        } else if (parametersInfo.Length < parameters.Count)
                        {
                            return "Error: Too many parameters for method FieldSimulator." + splitOnBoardFunctionString[1] + ". Expected {" + parametersInfo.Length.ToString() + "} and got {" + parameters.Count.ToString() + "}.";
                        }
                        return (string)fieldSimulatorMethod.Invoke(typeof(OnBoardLoop), parameters.Cast<string>().ToArray());
                    }
            }
            
            return "Error: functional area of " + splitOnBoardFunctionString[0] + " is invalid";
        }
    }
}
