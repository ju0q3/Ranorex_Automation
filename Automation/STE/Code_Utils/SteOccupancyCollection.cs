/*
 * Created by Ranorex
 * User: r07000021
 * Date: 1/22/2018
 * Time: 6:47 AM
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

using System.Net.Sockets;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace STE.Code_Utils
{
    /// <summary>
    /// Description of RemoteCommandUtility.
    /// </summary>
    [UserCodeCollection]
    public class SteOccupancyCollection
    {
        public SteOccupancyCollection()
        {
        }
        
        
        /// <summary>
        /// initalizeVehicle will place an occupancy of a train on the tracks
        /// </summary>
        /// <param name="trainId">ex: 1001 22</param>
        /// <param name="trackId">ex: 12345</param>
        /// <param name="trainType">ex: Freight, Passenger, or Unrestricted</param>
        /// <param name="length">ex: 4000</param>
        /// <param name="speed">ex: 55</param>
        /// <param name="offset">ex: 0</param>
        /// <param name="direction">ex: DownBound, UpBound</param>
        /// <param name="etd">ex: CURRENT or mm-dd-yy HH:MM</param>
        [UserCodeMethod]
        public static void initializeVehicle(string trainId, string trackId, string trainType, string length, string speed, string offset, string direction, string etd)
        {
            string request = "InitVehicle,";
            request = request+trainId+","+length+","+speed+",T"+trackId+","+offset+","+direction+","+etd+","+trainType;
            System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
        }

        
        /// <summary>
        /// removeVehicle will place an occupancy of a train on the tracks
        /// </summary>
        /// <param name="trainId">ex: 1001 22</param>
        [UserCodeMethod]
        public static void removeVehicle(string trainId)
        {
            string request = "RemoveVehicle,"+trainId;
            System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
        }
        
        /// <summary>
        /// removeVehicle will place an occupancy of a train on the tracks
        /// </summary>
        /// <param name="trackId">ex: 12345</param>
        /// <param name="action">ex: Occupied</param>
        [UserCodeMethod]
        public static void manualOccupancy(string trackId, string action)
        {
        	//"Occupied" "NotOccupied" "OtcNormal" "OtcNonNormal" "StopSignal" "ClearSignal" "On" "Off" "Ooc" "Normal" "Reverse" "Blocked" "NotBlocked" "Locked"
            //"NotLocked" "Transmit" "Receive" "CallOnSignalClear" "CallOn"
            string request = "SetDevice,"+trackId+","+action;
            System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
        }

        [UserCodeMethod]
        public static void SetDevice(string deviceId, string deviceAction)
        {
            string request = "SetDevice,"+deviceId+","+deviceAction;
            System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <param name="action"></param>
        /// <param name="hostname"></param>
        /// <returns></returns>
        [UserCodeMethod]
        public static bool sendRemoteCommandToSTE(string device, string action, string hostname) {
        	//TCP Message to <STEAddress>:[2500]
        	//ExecCmd:SetDevice,901989,On
        	
        	int receiver_port = 2500;
        	/*
        	var actions = new List<string>() {
        		//circuits
        		"Occupied",  "NotOccupied", "Blocked",  "NotBlocked",
				//switch monitors     		
        		"OtcNormal",  "OtcNonNormal",
        		//signals
        		"StopSignal",  "ClearSignal", "CallOnSignalClear", "CallOn",
				//misc devices        		
        		"On",  "Off",  
        		//switches
        		"Ooc", "Normal",  "Reverse", "Locked", "NotLocked",    
				//field traffic
        		"Transmit",  "Receive",
        		//Control Point
        		"LocalControlModeOn", "LocalControlModeOff", "ControlPointFailure"
        	};
        	
        	if(!actions.Contains(action)) return false;
        	*/
        	
        	
        	string request = String.Format("ExecCmd:SetDevice,{0},{1}", device, action);
        	
        	using(TcpClient tcp = new TcpClient(hostname, receiver_port)) {
        		NetworkStream nw = tcp.GetStream();
        		nw.ReadTimeout = 5000; //5 second timeout for read response
        		Report.Info(String.Format("Encoding Message {0} for STE {1}:2500",request, hostname));
        		byte[] bytesToSend = UTF8Encoding.UTF8.GetBytes(request);

        		//log to record we are sending exec
				nw.Write(bytesToSend, 0, bytesToSend.Length);

				/*
	            byte[] bytesToRead = new byte[tcp.ReceiveBufferSize];
	            int bytesRead = nw.Read(bytesToRead, 0, tcp.ReceiveBufferSize);
	            string response = UTF8Encoding.UTF8.GetString(bytesToRead, 0, bytesRead);
	            Report.Info(String.Format("Received Message {0} for STE {1}:2500",response, hostname));
	            */
	           //screw the receive, doesn't matter
        	}
                
        	return true;
        }

    }
}
