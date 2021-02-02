/*
 * Created by Ranorex
 * User: r07000021
 * Date: 10/25/2017
 * Time: 2:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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

namespace PDS_CORE.Code_Utils
{

    /// <summary>
    /// Ranorex User Code collection. A collection is used to publish User Code methods to the User Code library.
    /// </summary>
    [UserCodeCollection]
    public class Signaling
    {
		/// <summary>
		/// context object for rapid route signal clear
		/// </summary>
		public class RapidRouteSignalContext {
			public string DispatchView { get; set; }
			public string LampID { get; set; }
			public string TargetDispatchView { get; set; }
			public string TargetRouteEndPoint { get; set; }
		}
	
        // You can use the "Insert New User Code Method" functionality from the context menu,
        // to add a new method with the attribute [UserCodeMethod].
       internal static int InTimeDelay = 20000;
       internal static int ATCSCommunicationDelay = 5000;
       internal static int SwitchMove = 10000;
        
        /// <summary>
        /// This method takes a window (Bessimer -5) and a symbol ID 
        /// of a signal, and clears the signal 
        /// </summary>
        /// <param name="window">Form Window or Dispatch View of intended signal to clear ex 'Desk 10: Bessemer 1'</param>
        /// <param name="signalID">TDMS Lamp ID that of intended signal to clear ex. 904305</param>
        [UserCodeMethod]
        public static void ClearSignal(String window, String signalID)
        {
            //get signal and set to clear
            var signalToStop = FindTrackLineAssetByContext(window, signalID);
            
            //need to figure out report
            //Report.Log(ReportLevel.Info, "Mouse", String.Format("Clicking on lamp {0} at center", signalID), test, new RecordItemIndex(1));
            signalToStop.Click(System.Windows.Forms.MouseButtons.Left);
            Delay.Milliseconds(200);
            
            Transmit(window);
        }
        
        /// <summary>
        /// verifier image for a signal being cleared
        /// </summary>
        /// <returns></returns>
        public static Bitmap ClearSignalValidatingImage() 
        {
            Bitmap bmp = new Bitmap(3, 3);
            Graphics g = Graphics.FromImage(bmp);
            
            g.FillRectangle(new SolidBrush(PDSColors.green), new Rectangle(0,0,3,3));
            
            return bmp;
        }
        
        /// <summary>
        /// verifier image for a signal being set to stop 
        /// </summary>
        /// <returns></returns>
        public static Bitmap StopSignalValidatingImage() 
        {
            Bitmap bmp = new Bitmap(3, 3);
            Graphics g = Graphics.FromImage(bmp);
            
            g.FillRectangle(new SolidBrush(PDSColors.red), new Rectangle(0,0,3,3));
            
            return bmp;
        }
        
        /// <summary>
        /// This method takes a window (Bessimer -5) and a symbol ID 
        /// of a signal, and verifies that the signal is in the cleared state
        /// </summary>
        [UserCodeMethod]
        public static void ClearSignalValidate(String window, String symbolID, String sectionID)
        {
        	Delay.Milliseconds(ATCSCommunicationDelay);
        	
        	/*
        	 * Fail the validation if there is a feedback at bottom of trackline
        	 */
        	var feedback = PDS_CORE.Code_Utils.TracklineActions.GetFeedbackString(window);
        	if(feedback != " ") {
        		//fail the validate
        		Report.Failure("Failed signal clear" + feedback);
        		
        		//ask Mark if we can make this boolean to check
        		//if(PDS_CORE.Code_Utils.TracklineActions.VerifyControlRequestListEmpty()
				var repo = TrackLine.Instance;
            	var tableControlRequestTable = repo.ControlRequestList.CRLPanel.TableControlRequestTable;
				int rowCount = tableControlRequestTable.Self.Rows.Count;
				if(rowCount > 0) {
					Report.Error("Command stuck in CRL");
					//using swanky instead, because the other way may be broke					
					repo.TrackLineWindow.SwankyToolbar.ClearControlRequestListButton.Click();
					//repo.ControlRequestList.CRLPanel.ClearList.Click();
				}
				
        	}
        	 
            /*
             * Fail the validation if the lamp has not turned green (indicator our clear signal has failed)
             */
            var element = FindTrackLineAssetByContext(window, symbolID);
            
            Validate.ContainsImage(element, ClearSignalValidatingImage(), new Imaging.FindOptions());
            Delay.Milliseconds(100);
            
            
            /*
             * Fail if the section the lamp route was attached to does not trace green as well. This is an
             * indicator of a bad signal route or that the route is still running time (not full clear)
             */
            if(sectionID != "0") {
            	var trackSection = FindTrackLineAssetByContext(window, sectionID);
				Validate.ContainsImage(element, ClearSignalValidatingImage(), new Imaging.FindOptions());
            	Delay.Milliseconds(100);
            }
        }
        
                
        /// <summary>
        /// This method takes a window (Bessimer -5) and a symbol ID 
        /// of a signal, and stops the signal
        /// </summary>
        [UserCodeMethod]
        public static void StopSignal(String window, String symbolID)
        {
            var repo = TrackLine.Instance;
            
            //get signal and set to stop
            var signalToStop = FindTrackLineAssetByContext(window, symbolID);
            signalToStop.Focus();
            Delay.Milliseconds(1000);
            signalToStop.Click(System.Windows.Forms.MouseButtons.Left, Location.Center);
            Delay.Milliseconds(1000);
                        
            repo.TrackLineWindow.Viewport.Acknowledge.Focus();
            Delay.Milliseconds(500);
            repo.TrackLineWindow.Viewport.Acknowledge.Click();          
            Delay.Milliseconds(200);
            
            //send and wait for time to run
            Transmit(window);            
            Delay.Milliseconds(InTimeDelay);
        }
                
        /// <summary>
        /// This method takes a window (Bessimer -5) and a symbol ID 
        /// of a signal, and verifies that the signal is in the stopped state
        /// </summary>
        [UserCodeMethod]
        public static void StopSignalValidate(String window, String symbolID)
        {        	
            Delay.Milliseconds(ATCSCommunicationDelay);
            var element = FindTrackLineAssetByContext(window, symbolID);
            
            Validate.ContainsImage(element, StopSignalValidatingImage(), new Imaging.FindOptions());
            Delay.Milliseconds(100);
        }
              
        /// <summary>
        /// This method transmits whatever command(s) is currently pending 
        /// </summary>
        /// <param name="window">Form Window or Dispatch View of intended signal to clear ex 'Desk 10: Bessemer 1'</param>
        /// 
        [UserCodeMethod]
        public static void Transmit(String window) 
        {
            JavaElement panel;            
            var repo = TrackLine.Instance;

            repo.window = window;            
            var XPath = repo.TrackLineWindow.Viewport.SelfInfo.AbsolutePath;           

            try
            {
                panel = Host.Local.FindSingle(XPath).As<JavaElement>();
            }
            catch(ElementNotFoundException ex)
            {
                Report.Error(String.Format(@"Error finding viewport window for Transmit. Exception information: {0}",ex.Message));
                return;                 
            }
            
            //modified to use swanky
            repo.TrackLineWindow.SwankyToolbar.TransmitControlRequestButton.Click();
            
            /*
            //have to click inside a PDS trackline pane to get transmit "black screen"
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'Desk10Bessemer1.JtlrJLayeredPane' at 2;2.", repo.Desk10Bessemer1.JtlrJLayeredPaneInfo, new RecordItemIndex(0));
            panel.Click("850;5");
            //Delay.Milliseconds(200);
                        
            //control + T to xmt, as opposed to button click or right click -> transmit
            Report.Log(ReportLevel.Info, "Keyboard", "Key 'Ctrl+T' Press.", new RecordItemIndex(1));
            Keyboard.Press(System.Windows.Forms.Keys.T | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
            Delay.Milliseconds(100);
            */
        }
        
        /// <summary>
        /// Get the trackline object associated with the tdmsID in the window provided
        /// </summary>
        /// <param name="window">Form Window or Dispatch View of intended signal to clear ex 'Desk 10: Bessemer 1'</param>
        /// <param name="signalID">TDMS Lamp ID that of intended signal to clear ex. 904305</param>
        /// <returns>JavaElement of the object selected</returns>
        public static JavaElement FindTrackLineAssetByContext(string window, string tdmsID) 
        {
            JavaElement source;
            var repo = TrackLine.Instance;            
            repo.window = window;
            repo.tdmsID = tdmsID;

            repo.TrackLineWindow.TrackSection.Focus();
            var trackSectionInfo = repo.TrackLineWindow.TrackSectionInfo;
            
            //search wtihout defined Repository
            try
            {
                source = Host.Local.FindSingle(trackSectionInfo.AbsolutePath).As<JavaElement>();
            }
            catch(ElementNotFoundException ex)
            {
                // Catch and rethrow the error to prevent errors when the asset cannot be found
                Report.Error(String.Format(@"Error finding trackline asset by context. Exception information: {0}",ex.Message));
                // throw without specifying the original exception to preserve the stack trace
                throw;
            }
            
            return source;
        }
                
        /// <summary>
        /// Rapid Route clear 
        /// </summary>
        /// <param name="ctx">Rapid Route Signal Context for RR clear</param>
        [UserCodeMethod]
        public static void RapidRouteSignalClear(String sourceWindow, String sourceTdmsId, String targetWindow, String targetTdmsId) 
        {
            JavaElement source;
            JavaElement target;
            
            source = FindTrackLineAssetByContext(sourceWindow, sourceTdmsId);           
            
            //need to figure out report
            //Report.Log(ReportLevel.Info, "Mouse", String.Format("Clicking on lamp {0} at center", signalID), test, new RecordItemIndex(1));
            //source.Focus();
            Mouse.MoveTo(source);
            Delay.Seconds(1);
            source.DoubleClick(Location.Center);
            Delay.Seconds(1);

            string[] targetTdmsIds = targetTdmsId.Split('|');
            
            foreach(string targetTrackId in targetTdmsIds)
            {
            	target = FindTrackLineAssetByContext(targetWindow, targetTrackId);
            	
            	//target.Focus();
            	Mouse.MoveTo(target);
            	Delay.Seconds(1);
            	target.Click(System.Windows.Forms.MouseButtons.Left);
            	Delay.Seconds(1);
            }
            
            Transmit(sourceWindow);
            
            //potential extra delay of having to bend switch
            Delay.Milliseconds(SwitchMove + ATCSCommunicationDelay);
        }
        
        
        /// <summary>
        /// Fleeting (continuous clear traffic) signal using signal context menu
        /// </summary>
        /// <param name="window">Form Window or Dispatch View of intended signal to clear ex 'Desk 10: Bessemer 1'</param>
        /// <param name="signalID">TDMS Lamp ID that of intended signal to clear ex. 904305</param>
        [UserCodeMethod]
        public static void FleetingSignalClear(string window, string tdmsID) 
        {
            JavaElement fleetingOption;
            var repo = TrackLine.Instance;
            
            var element = FindTrackLineAssetByContext(window, tdmsID);
            Delay.Milliseconds(1000);
            element.Click(WinForms.MouseButtons.Right);
            
            repo.ContextMenuItem = "Fleeting";
            var xPath = repo.TrackLineWindow.MenuItemInfo.AbsolutePath;            

            try
            {
                fleetingOption = Host.Local.FindSingle(xPath).As<JavaElement>();
            }
            catch(ElementNotFoundException ex)
            {
                Report.Error(String.Format(@"Error finding target lamp for rapid route. Exception information: {0}",ex.Message));
                return;                
            }
            
            fleetingOption.Click(WinForms.MouseButtons.Left);
            Delay.Seconds(1);
            
            Transmit(window);
        }
            
    }
}
