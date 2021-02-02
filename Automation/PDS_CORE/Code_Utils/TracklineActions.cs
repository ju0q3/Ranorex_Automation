/*
 * Created by Ranorex
 * User: 502732101
 * Date: 12/19/2017
 * Time: 1:49 PM
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

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace PDS_CORE.Code_Utils
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class TracklineActions
    {
       
    	public static PDS_CORE.TrackLine repo = PDS_CORE.TrackLine.Instance;
       
        [UserCodeMethod]
        public static void SwitchDialogConfirm(String windowName, String reporterName) 
        {
            var repo = TrackLine.Instance;
            repo.window = windowName;            
        	repo.TrackLineWindow.ConfirmationDialog.ReporterName.PressKeys(reporterName);        		
        	repo.TrackLineWindow.ConfirmationDialog.Continue.Click();
        }
        
        [UserCodeMethod]
        public static JavaElement GetTracklineObject(String window, String componentId) 
        {
        	JavaElement component;
            try
            {
                component = Signaling.FindTrackLineAssetByContext(window, componentId);
            }
            catch(ElementNotFoundException ex)
            {
                Report.Error(String.Format(@"Error in FindTrackLineAssetByContext (LeftClickComponent). Exception information: {0}",ex.Message));               
            	throw;
            }
            
            return component;
        }
        
        [UserCodeMethod]
        public static String GetAttributeValue(JavaElement component, String attributeName) 
        {
        	
        	String attributeValue = "";
        	
        	switch (attributeName) 
        	{
        		case "CurrentState":
        			try 
        			{
            			attributeValue = component.Element.GetAttributeValueText("CurrentState");
            			return attributeValue;
            		} 
        			catch (ArgumentNullException e)
        			{
            			Report.Error(String.Format(@"Attribute specified is null. Exception information: {0}",e.Message));   
            		}
        			break;
        		default:
        			break;
        			
        	}
        	//Debugging code string
        	return "Attribute Value Empty or Incorrect Atrribute Name";        	
        }
        
        
        [UserCodeMethod]
		/// <summary>
		/// 
		/// </summary>
		/// <param name="window"></param>
		/// <param name="componentId"></param>
		/// <param name="authorityType"></param>
		/// <param name="validateType"></param>
		public static void NormalizeSwitchPosition(String window, String componentId) 
		{
			
			Ranorex.JavaElement component;
			
			if (componentId.Contains("|")) 
			{
				String[] components = componentId.Split('|');
				
				for (int i = 0; i < components.Length; i++) 
				{
					
					component = GetTracklineObject(window, components[i]);           
					Validate.IsTrue(GetAttributeValue(component, "CurrentState").Contains("P, REV"));
					component.Focus();
					Delay.Milliseconds(250);
					component.Click(Location.LowerCenter);
		            Delay.Milliseconds(500);
					SwitchDialogConfirm(window, "Worker Joe");
		            Delay.Milliseconds(500);
		            Keyboard.Press(System.Windows.Forms.Keys.T | System.Windows.Forms.Keys.Alt, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
		            Delay.Milliseconds(500);
		            Validate.IsFalse(GetAttributeValue(component, "CurrentState").Contains("P, REV"));
					
				}
			} 
			else 
			{
            
				component = GetTracklineObject(window, componentId);                     
				Validate.IsTrue(GetAttributeValue(component, "CurrentState").Contains("P, REV"));
				component.Focus();
				Delay.Milliseconds(250);
				component.Click(Location.LowerCenter);
				Delay.Milliseconds(500);
	            SwitchDialogConfirm(window, "Worker Joe");
	            Delay.Milliseconds(500);
	            Keyboard.Press(System.Windows.Forms.Keys.T | System.Windows.Forms.Keys.Alt, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);           
	            Delay.Milliseconds(500);
	            Validate.IsFalse(GetAttributeValue(component, "CurrentState").Contains("P, REV"));
			
			}
			
			return;
            
		}
	
        [UserCodeMethod]
		/// <summary>
		/// 
		/// </summary>
		/// <param name="window"></param>
		/// <param name="componentId"></param>
		/// <param name="authorityType"></param>
		/// <param name="validateType"></param>
		public static void TrackSegmentAttributeValidation(String window, String componentId, String attributeName, String expectedValue) 
		{
          
			//This catches cases where you may want to use a smartfolder to iterate over several devices for validation
			//and helps alleviate extra smart folders or columns
			if (componentId.Equals("")) 
			{
				return;
			}
            Ranorex.JavaElement component;
            try
            {
                component = Signaling.FindTrackLineAssetByContext(window, componentId);
            }
            catch(ElementNotFoundException ex)
            {
                Report.Error(String.Format(@"Error in FindTrackLineAssetByContext (LeftClickComponent). Exception information: {0}",ex.Message));
                return;                
            }
            
            Validate.AttributeContains(component.Element,attributeName,expectedValue);
            return;
            
        }
		
		[UserCodeMethod]
		/// <summary>
		/// 
		/// </summary>
		/// <param name="window"></param>
		/// <param name="componentId"></param>
		/// <param name="authorityType"></param>
		/// <param name="validateType"></param>
		public static void TrackSegmentAttributeValueNotPresent(String window, String componentId, String attributeName, String expectedValue) 
		{
          
			//This catches cases where you may want to use a smartfolder to iterate over several devices for validation
			//and helps alleviate extra smart folders or columns
			if (componentId.Equals("")) 
			{
				return;
			}
			
            Ranorex.JavaElement component;
            try
            {
                component = Signaling.FindTrackLineAssetByContext(window, componentId);
            }
            catch(ElementNotFoundException ex)
            {
                Report.Error(String.Format(@"Error in FindTrackLineAssetByContext (LeftClickComponent). Exception information: {0}",ex.Message));
                return;                
            }
            
            String attributeValue = "";
            
            try
            {
            	attributeValue = component.Element.GetAttributeValueText(attributeName);
            } 
            catch (ArgumentNullException e)
            {
            	Report.Error(String.Format(@"Attribute specified is null. Exception information: {0}",e.Message));
                return;    
            }
            if (!attributeValue.Contains(expectedValue)) {
            	Report.Success("Success", "attribue " + attributeName + "'s value (" + attributeValue + ") is not present.");
            } else {
            	Report.Failure("Failure", "attribue " + attributeName + "'s value (" + attributeValue + ") is present.");
            }
            return;
            
        }
        
        /// <summary>
        /// This function will pull up the context menu on the specified component and verify if the 
        /// menu item desired exists.
        /// </summary>
        /// <param name="window">Form Window or Dispatch View ex 'Desk 10: Bessemer 1'</param>
        /// <param name="componentId">TDMS ID that of intended component ex. 904305</param>
        /// <param name="contextMenuItem">String value of the menu item to search for in the context menu</param>         
        [UserCodeMethod]
        public static void VerifyContextMenuItem(String window, String componentId, String contextMenuItemText)
        {
            Report.Info(String.Format("Looking for context menu item {0}", contextMenuItemText));
            var repo = TrackLine.Instance;
            repo.window = window;
            
            JavaElement component;

            // Get the component from Signaling's function to access trackline objects
            try
            {
                component = Signaling.FindTrackLineAssetByContext(window, componentId);
            }
            catch(ElementNotFoundException ex)
            {
                Report.Error(String.Format(@"Error in FindTrackLineAssetByContext (VerifyContextMenuItem). Exception information: {0}",ex.Message));
                return;                
            }
            component.Click(WinForms.MouseButtons.Right);
            
            repo.ContextMenuItem = contextMenuItemText;
            if (repo.TrackLineWindow.MenuItemInfo.Exists(1000))
            {
                Report.Info(String.Format("Found context menu item {0}", contextMenuItemText));
            }
            else
            {
                Report.Error(String.Format("Did not find context menu item {0}", contextMenuItemText));
            }
            repo.TrackLineWindow.Viewport.Self.Click(new Location(10,10));
        }
        
        /// <summary>
        /// This function will read the feedback bar at the bottom of the desired window and return the string value contained.
        /// </summary>
        /// <param name="window">Form Window or Dispatch View ex 'Desk 10: Bessemer 1'</param>
        [UserCodeMethod]
        public static String GetFeedbackString(String window)
        {
            var repo = TrackLine.Instance;  
            String feedback = "";
            
            feedback = repo.TrackLineWindow.FeedbackText.TextValue;
            Report.Info(String.Format(@"Found Feedback text '{0}'", feedback));
            return feedback;
        }
        
        /// <summary>
        /// This function will click on the component with the left button
        /// </summary>
        /// <param name="window">Form Window or Dispatch View ex 'Desk 10: Bessemer 1'</param>
        /// <param name="componentId">TDMS ID that of intended component ex. 904305</param>
        [UserCodeMethod]
        public static void LeftClickComponent(String window, String componentId)
        {
            JavaElement component;
            try
            {
                component = Signaling.FindTrackLineAssetByContext(window, componentId);
            }
            catch(ElementNotFoundException ex)
            {
                Report.Error(String.Format(@"Error in FindTrackLineAssetByContext (LeftClickComponent). Exception information: {0}",ex.Message));
                return;                
            }
            component.Click();
        }
        
        /// <summary>
        /// This function will double click on the component with the left button
        /// </summary>
        /// <param name="window">Form Window or Dispatch View ex 'Desk 10: Bessemer 1'</param>
        /// <param name="componentId">TDMS ID that of intended component ex. 904305</param>
        [UserCodeMethod]
        public static void DoubleClickComponent(String window, String componentId)
        {
            JavaElement component;
            try
            {
                component = Signaling.FindTrackLineAssetByContext(window, componentId);
            }
            catch(ElementNotFoundException ex)
            {
                Report.Error(String.Format(@"Error in FindTrackLineAssetByContext (DoubleClickComponent). Exception information: {0}",ex.Message));
                return;                
            }
            component.DoubleClick();
        }
        
        /// <summary>
        /// This function will click on the component with the middle button
        /// </summary>
        /// <param name="window">Form Window or Dispatch View ex 'Desk 10: Bessemer 1'</param>
        /// <param name="componentId">TDMS ID that of intended component ex. 904305</param>
        [UserCodeMethod]
        public static void MiddleClickComponent(String window, String componentId)
        {
            JavaElement component;
            try
            {
                component = Signaling.FindTrackLineAssetByContext(window, componentId);
            }
            catch(ElementNotFoundException ex)
            {
                Report.Error(String.Format(@"Error in FindTrackLineAssetByContext (MiddleClickComponent). Exception information: {0}",ex.Message));
                return;                
            }
            component.Click(WinForms.MouseButtons.Middle);
        }
        
        /// <summary>
        /// This function will click on the component with the right button
        /// </summary>
        /// <param name="window">Form Window or Dispatch View ex 'Desk 10: Bessemer 1'</param>
        /// <param name="componentId">TDMS ID that of intended component ex. 904305</param>
        [UserCodeMethod]
        public static void RightClickComponent(String window, String componentId)
        {
            JavaElement component;
            try
            {
                component = Signaling.FindTrackLineAssetByContext(window, componentId);
            }
            catch(ElementNotFoundException ex)
            {
                Report.Error(String.Format(@"Error in FindTrackLineAssetByContext (RightClickComponent). Exception information: {0}",ex.Message));
                return;                
            }
            component.Click(WinForms.MouseButtons.Right);            
        }
        
        /// <summary>
        /// This function will click on the component with the right button and returns the Element
        /// </summary>
        /// <param name="window">Form Window or Dispatch View ex 'Desk 10: Bessemer 1'</param>
        /// <param name="componentId">TDMS ID that of intended component ex. 904305</param>
        public static JavaElement RightClickComponentReturnElement(String window, String componentId)
        {
            JavaElement component;
            try
            {
                component = Signaling.FindTrackLineAssetByContext(window, componentId);
            }
            catch(ElementNotFoundException ex)
            {
                Report.Error(String.Format(@"Error in FindTrackLineAssetByContext (RightClickComponent). Exception information: {0}",ex.Message));
                return null;                
            }
            component.Click(WinForms.MouseButtons.Right);       
			return component;            
        }
        
        /// <summary>
        /// Set the variables to select a trackline object
        /// </summary>
        /// <param name="window">The name of the window that contains the object</param>
        /// <param name="tdmsID">The TDMS Id for the object</param>
        [UserCodeMethod]
        public static void SetTracklineObjectVariables(String window, String tdmsId)
        {
            var repo = TrackLine.Instance;            
            repo.window = window;
            repo.tdmsID = tdmsId;
        }   

        
        /// <summary>
        /// This function will use the trackline to determine the current position of the switch
        /// </summary>
        /// <param name="window">The name of the window to find the switch in</param>
        /// <param name="tdmsId">The TDMS ID for the switch (not the Device ID)</param>
        [UserCodeMethod]
        public static void LogCurrentSwitchState(String window, String tdmsId)
        {
            var repo = TrackLine.Instance;
            repo.window = window;
            repo.tdmsID = tdmsId;

            String modelText = repo.TrackLineWindow.TrackSection.Element.GetAttributeValueText("Model");
            String stationName = repo.TrackLineWindow.TrackSection.Element.GetAttributeValueText("StationName");
            
            String[] splitString = modelText.Split(',');
            String switchPosition = splitString[1];
            
            Report.Info(String.Format("Current switch position for switch at {0}:{1}: {2}", stationName, tdmsId, switchPosition));
            // Can enable screenshots if more details are desired
            //Report.Screenshot(repo.TrackLineWindow.TrackSection);
        }

        /// <summary>
        /// This function will use the trackline to determine the current position of the switch
        /// </summary>
        /// <param name="window">The name of the window to find the switch in</param>
        /// <param name="tdmsId">The TDMS ID for the switch (not the Device ID)</param>
        [UserCodeMethod]
        public static void ValidateCurrentSwitchPos(String window, String tdmsId, String expectedPos)
        {
            Report.Info(String.Format("Validating Current Switch Position for {0}:{1}: expected position {2}", window, tdmsId, expectedPos));
            var repo = TrackLine.Instance;
            repo.window = window;
            repo.tdmsID = tdmsId;

            String modelText = repo.TrackLineWindow.TrackSection.Element.GetAttributeValueText("Model");
            String stationName = repo.TrackLineWindow.TrackSection.Element.GetAttributeValueText("StationName");
            
            String[] splitString = modelText.Split(',');
            String switchPosition = splitString[1];
            
            expectedPos = expectedPos.ToUpper();
            
            if (expectedPos.Equals("NORMAL") || expectedPos.Equals("NORM") ) expectedPos = "NORM";
            if (expectedPos.Equals("REVERSE") || expectedPos.Equals("REV") ) expectedPos = "REV";
            
            if (switchPosition.Equals(expectedPos))
            {
                Report.Info(String.Format("Current switch position for switch at {0}:{1}: {2}", stationName, tdmsId, switchPosition));
            }
            else
            {
                Report.Error(String.Format("Current switch position for switch at {0}:{1}: {2} expected position {3}", stationName, tdmsId, switchPosition, expectedPos));
            }                
        }        
        
        /// <summary>
        /// Set the switch to a desired position from the context menu
        /// </summary>
        /// <param name="window">Name of the window the switch is located in</param>
        /// <param name="tdmsId">TDMS ID of the switch</param>
        /// <param name="positionText">Position to select on the context menu</param>
        [UserCodeMethod]
        public static void SetSwitchPosition(String window, String tdmsId, String positionText)
        {
            Report.Info(String.Format("Setting switch position for {0}:{1} to {2}", window, tdmsId, positionText));
            int retries = 0;
            var repo = TrackLine.Instance;
            repo.SwitchId = tdmsId;
            repo.TrackLineWindow.SwitchObject.EnsureVisible();
            repo.TrackLineWindow.SwitchObject.MoveTo(Location.Center);
            Mouse.Click(WinForms.MouseButtons.Right);
//            repo.window = window;
//            repo.tdmsID = tdmsId;            
//            repo.TrackLineWindow.Self.Activate();
//            Mouse.Click(repo.TrackLineWindow.TrackSection, WinForms.MouseButtons.Right, new Point(30,30));
            

            while(!repo.TrackLineWindow.SwitchObjectMenu.SelfInfo.Exists(0) && retries < 5)
            {
                Ranorex.Delay.Seconds(1);
                retries++;
            }
            
            if(repo.TrackLineWindow.SwitchObjectMenu.SelfInfo.Exists(0))
            {
                if(positionText == "Normal")
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(repo.TrackLineWindow.SwitchObjectMenu.NormalInfo,
                                                                     repo.TrackLineWindow.SwitchObjectMenu.SelfInfo);
                }
                else if(positionText == "Reverse")
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(repo.TrackLineWindow.SwitchObjectMenu.ReverseInfo,
                                                                     repo.TrackLineWindow.SwitchObjectMenu.SelfInfo);
                }
                else if(positionText == "Move Authority Blocked Switch Normal")
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(repo.TrackLineWindow.SwitchObjectMenu.MoveAuthorityBlockedSwitchNormalInfo,
                                                                     repo.TrackLineWindow.SwitchObjectMenu.SelfInfo);
                }
                else if(positionText == "Move Authority Blocked Switch Reverse")
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(repo.TrackLineWindow.SwitchObjectMenu.MoveAuthorityBlockedSwitchReverseInfo,
                                                                     repo.TrackLineWindow.SwitchObjectMenu.SelfInfo);
                }
                else if(positionText == "Manual Switch Normal")
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(repo.TrackLineWindow.SwitchObjectMenu.ManualSwitchNormalInfo,
                                                                     repo.TrackLineWindow.SwitchObjectMenu.SelfInfo);
                }
                else if(positionText == "Manual Switch Reverse")
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(repo.TrackLineWindow.SwitchObjectMenu.ManualSwitchReverseInfo,
                                                                     repo.TrackLineWindow.SwitchObjectMenu.SelfInfo);
                }
                else
                {
                    Ranorex.Report.Failure("Invalid Switch Position:"+positionText);
                }
            }
           
        }

        /// <summary>
        /// Set the switch to a desired position from the context menu
        /// </summary>
        /// <param name="window">Name of the window the switch is located in</param>
        /// <param name="tdmsId">TDMS ID of the switch</param>
        /// <param name="positionText">Position to select on the context menu</param>
        [UserCodeMethod]
        [System.Obsolete("Use TracklineActions.ClickTrackLineContextMenuItem")]
        public static void ClickSignalMenuItem(String window, String tdmsId, String positionText)
        {
            Report.Info(String.Format("Clicking signal menu for {0}:{1} to {2}", window, tdmsId, positionText));
            var repo = TrackLine.Instance;
            repo.window = window;
            repo.tdmsID = tdmsId;            
            repo.TrackLineWindow.Self.Activate();
            Mouse.Click(repo.TrackLineWindow.TrackSection, WinForms.MouseButtons.Right);
            
            repo.ContextMenuItem = positionText;            
            repo.TrackLineWindow.MenuItem.Click();
            
        }    
        
        /// <summary>
        /// Click Menu Item from trackline object (Signal, CP, Switch, MD, etc...)
        /// </summary>
        /// <param name="window">Dispatch View Name where device is</param>
        /// <param name="tdmsId">TDMS Device ID</param>
        /// <param name="positionText"></param>
		[UserCodeMethod]
        public static void ClickTrackLineContextMenuItem(String window, String tdmsId, String contextMenuItem)
        {
            Report.Info(String.Format("Clicking menu item {2} for {0}:{1}", window, tdmsId, contextMenuItem));
            var repo = TrackLine.Instance;
            repo.window = window;
            repo.tdmsID = tdmsId;            
            repo.TrackLineWindow.Self.Activate();
            //adjusted to lower center
            Mouse.Click(repo.TrackLineWindow.TrackSection, WinForms.MouseButtons.Right, Location.LowerCenter);
            
            repo.ContextMenuItem = contextMenuItem;            
			repo.TrackLineWindow.MenuItem.Click();	
        } 
        
        
        /// <summary>
        /// Using the control request list, verify the desired operation is listed
        /// </summary>
        /// <param name="controlPoint">Name of the control point</param>
        /// <param name="deviceId">Name of the device (from the DB Summary)</param>
        /// <param name="requestedFunction">Text of the function</param>
        [UserCodeMethod]
        public static void VerifyControlRequestList(String controlPoint, String deviceId, String requestedFunction)
        {
            var repo = TrackLine.Instance;
            var tableControlRequestTable = repo.ControlRequestList.CRLPanel.TableControlRequestTable;
            
            int rowCount = tableControlRequestTable.Self.Rows.Count;
            bool found = false;
            
            if (rowCount > 0)
            {
                for(int i=0; i< rowCount; i++)
                {
                	repo.rowidx = i.ToString();
                	if (repo.ControlRequestList.CRLPanel.TableControlRequestTable.ControlPointCell.GetAttributeValue<string>("Text").Equals(controlPoint,StringComparison.OrdinalIgnoreCase) &&
                        repo.ControlRequestList.CRLPanel.TableControlRequestTable.DevideIDCell.GetAttributeValue<string>("Text").Equals(deviceId,StringComparison.OrdinalIgnoreCase) &&
                        repo.ControlRequestList.CRLPanel.TableControlRequestTable.RequestFunctionCell.GetAttributeValue<string>("Text").ToLower().Contains(requestedFunction.ToLower()))
                    {
                        Report.Info(String.Format("Verified the entry in the Control Request List table for ControlPoint: {0}, DeviceId: {1}, RequestedFunction: {2}",controlPoint,deviceId,requestedFunction));
                        found = true;
                        break;
                    }
                }
            }
            else
            {
                Report.Info("No Rows in the Control Request List table");
            }
            
            if (!found)
            {
                Report.Failure(String.Format("Did not find an entry in the Control Request List table for ControlPoint: {0}, DeviceId: {1}, RequestedFunction: {2}",controlPoint,deviceId,requestedFunction));
            }
        }

        /// <summary>
        /// Verify that there are no requested controls pending
        /// </summary>
        [UserCodeMethod]
        public static void VerifyControlRequestListEmpty()
        {
            var repo = TrackLine.Instance;
            var tableControlRequestTable = repo.ControlRequestList.CRLPanel.TableControlRequestTable;
            
            int rowCount = tableControlRequestTable.Self.Rows.Count;
            
            if (rowCount > 0)
            {
                foreach(Row row in tableControlRequestTable.Self.Rows)
                {
                	if (!(row.Cells[0].Text == "") &&
                	    !(row.Cells[1].Text == "") &&
                	    !(row.Cells[2].Text == ""))
                    {
                        Report.Error("Found unexpected data in the CRL");
                        return;
                    }
                }
            }
            else
            {
                Report.Info("No Rows in the Control Request List table");
            }            
        }
                
        /// <summary>
        /// Validate the controls and indications for stopping a signal
        /// This has 2 indications returned so changed data for each indication row is expected
        /// </summary>
        /// <param name="controlNames">Pipe delimited list of control names to check</param>
        /// <param name="expectedControlValues">Pipe delimited list of data expected in the controls</param>
        /// <param name="indication1Names">Pipe delimited list of indications in the first return</param>
        /// <param name="expectedIndication1Values">Pipe delimited list of data for the first return indicatinos</param>
        /// <param name="indication2Names">Pipe delimited list of indications in the second return</param>
        /// <param name="expectedIndication2Values">Pipe delimited list of data for the second return indications</param>
        [UserCodeMethod]
        public static void ValidateMCPForStopSignal(String controlNames, String expectedControlValues, 
                                                    String indication1Names, String expectedIndication1Values, 
                                                    String indication2Names, String expectedIndication2Values)
        {
            // For sanity: indications 1 is used for the first set of indications returned
            //           : indications 2 is used for the second set of indications returned
            Report.Info("Validating the C/I data in the MCP for a stopped signal");
            var repo = TrackLine.Instance;
            
            String[] controls = controlNames.Split('|');
            String[] controlsData = expectedControlValues.Split('|');
            String[] indications1 = indication1Names.Split('|');
            String[] indications1Data = expectedIndication1Values.Split('|');
            String[] indications2 = indication2Names.Split('|');
            String[] indications2Data = expectedIndication2Values.Split('|');
            
            Table CandITable = repo.MonitorControlPointCommunications.ControlPointMessagesTable;            
            
            int i2RowName = 0;
            int i2RowData = 1;
            int i1RowName = 2;
            int i1RowData = 3;
            int cRowName = 4;
            int cRowData = 5;
            
            int currentCellIndex = 0;
            
            bool unexpectedControlData = false;
            bool unexpectedIndication1Data = false;
            bool unexpectedIndication2Data = false;
            
            StringBuilder sbControlMessage = new StringBuilder();
            StringBuilder sbIndication1Message = new StringBuilder();
            StringBuilder sbIndication2Message = new StringBuilder();
            
            sbControlMessage.Append("Controls:");
            sbIndication1Message.Append("Indications(1):");
            sbIndication2Message.Append("Indications(2):");
            

            for(int x = 1; x < controls.Length; x++)
            {
                String control = controls[x];
                foreach(Cell c in CandITable.Rows[cRowName].Cells)
                {
                    if (c.Text.Equals(control, StringComparison.OrdinalIgnoreCase))
                    {
                        currentCellIndex = c.ColumnIndex;
                        String data = CandITable.Rows[cRowData].Cells[currentCellIndex].Text;
                        if (data.Equals(controlsData[x], StringComparison.OrdinalIgnoreCase))
                        {
                            sbControlMessage.Append(String.Format(@" {0}:{1}",control, data));                            
                        }
                        else
                        {
                            sbControlMessage.Append(String.Format(@" {0}:{1}-{2}expected", control, data, controlsData[x]));
                            unexpectedControlData = true;
                        }                        
                        break;
                    }
                }
            }
            
            for(int x = 1; x < indications1.Length; x++)
            {
                String indication = indications1[x];
                foreach(Cell i in CandITable.Rows[i1RowName].Cells)
                {
                    if (i.Text.Equals(indication, StringComparison.OrdinalIgnoreCase))
                    {
                        currentCellIndex = i.ColumnIndex;
                        String data = CandITable.Rows[i1RowData].Cells[currentCellIndex].Text;
                        if (data.Equals(indications1Data[x], StringComparison.OrdinalIgnoreCase))
                        {
                            sbIndication1Message.Append(String.Format(@" {0}:{1}",indication, data));                            
                        }
                        else
                        {
                            sbIndication1Message.Append(String.Format(@" {0}:{1}-{2}expected", indication, data, indications1Data[x]));
                            unexpectedIndication1Data = true;
                        }                        
                        break;
                    }
                }
            }
            
            for(int x = 0; x < indications2.Length; x++)
            {
                String indication = indications2[x];
                foreach(Cell i in CandITable.Rows[i2RowName].Cells)
                {
                    if (i.Text.Equals(indication, StringComparison.OrdinalIgnoreCase))
                    {
                        currentCellIndex = i.ColumnIndex;
                        String data = CandITable.Rows[i2RowData].Cells[currentCellIndex].Text;
                        if (data.Equals(indications2Data[x], StringComparison.OrdinalIgnoreCase))
                        {
                            sbIndication2Message.Append(String.Format(@" {0}:{1}",indication, data));                            
                        }
                        else
                        {
                            sbIndication2Message.Append(String.Format(@" {0}:{1}-{2}expected", indication, data, indications2Data[x]));
                            unexpectedIndication2Data = true;
                        }                        
                        break;
                    }
                }
            }            
            
            if (unexpectedControlData)
            {
                Report.Error(sbControlMessage.ToString());
            }
            else
            {
                Report.Info(sbControlMessage.ToString());
            }
            
            if (unexpectedIndication1Data)
            {
                Report.Error(sbIndication1Message.ToString());
            }
            else
            {
                Report.Info(sbIndication1Message.ToString());
            }
            
            if (unexpectedIndication2Data)
            {
                Report.Error(sbIndication2Message.ToString());
            }
            else
            {
                Report.Info(sbIndication2Message.ToString());
            }            
            
        }
                
        /// <summary>
        /// Validate the controls and indications for clearing a signal
        /// </summary>
        /// <param name="">Pipe delimited list of control names</param>
        /// <param name="">Pipe delimited list of indication names</param>
        [UserCodeMethod]
        public static void ValidateMCPForClearSignal(String controlNames, String expectedControlValues, String indicationNames, String expectedIndicationValues)
        {
            Report.Info("Validating the C/I data in the MCP for a cleared signal");
            var repo = TrackLine.Instance;
            
            String[] controls = controlNames.Split('|');
            String[] controlsData = expectedControlValues.Split('|');
            String[] indications = indicationNames.Split('|');
            String[] indicationsData = expectedIndicationValues.Split('|');
            
            Table CandITable = repo.MonitorControlPointCommunications.ControlPointMessagesTable;            
            
            int iRowName = 0;
            int iRowData = 1;
            int cRowName = 2;
            int cRowData = 3;
            
            int currentCellIndex = 0;
            
            bool unexpectedControlData = false;
            bool unexpectedIndicationData = false;
            
            StringBuilder sbControlMessage = new StringBuilder();
            StringBuilder sbIndicationMessage = new StringBuilder();
            
            sbControlMessage.Append("Controls:");
            sbIndicationMessage.Append("Indications:");

            for(int x = 0; x < controls.Length; x++)
            {
                String control = controls[x];
                foreach(Cell c in CandITable.Rows[cRowName].Cells)
                {
                    if (c.Text.Equals(control, StringComparison.OrdinalIgnoreCase))
                    {
                        currentCellIndex = c.ColumnIndex;
                        String data = CandITable.Rows[cRowData].Cells[currentCellIndex].Text;
                        if (data.Equals(controlsData[x], StringComparison.OrdinalIgnoreCase))
                        {
                            sbControlMessage.Append(String.Format(@" {0}:{1}",control, data));                            
                        }
                        else
                        {
                            sbControlMessage.Append(String.Format(@" {0}:{1}-{2}expected", control, data, controlsData[x]));
                            unexpectedControlData = true;
                        }                        
                        break;
                    }
                }
            }
            
            for(int x = 0; x < indications.Length; x++)
            {
                String indication = indications[x];
                foreach(Cell i in CandITable.Rows[iRowName].Cells)
                {
                    if (i.Text.Equals(indication, StringComparison.OrdinalIgnoreCase))
                    {
                        currentCellIndex = i.ColumnIndex;
                        String data = CandITable.Rows[iRowData].Cells[currentCellIndex].Text;
                        if (data.Equals(indicationsData[x], StringComparison.OrdinalIgnoreCase))
                        {
                            sbIndicationMessage.Append(String.Format(@" {0}:{1}",indication, data));                            
                        }
                        else
                        {
                            sbIndicationMessage.Append(String.Format(@" {0}:{1}-{2}expected", indication, data, indicationsData[x]));
                            unexpectedIndicationData = true;
                        }                        
                        break;
                    }
                }
            }
            
            if (unexpectedControlData)
            {
                Report.Error(sbControlMessage.ToString());
            }
            else
            {
                Report.Info(sbControlMessage.ToString());
            }
            
            if (unexpectedIndicationData)
            {
                Report.Error(sbIndicationMessage.ToString());
            }
            else
            {
                Report.Info(sbIndicationMessage.ToString());
            }
            
        }
        
        /// <summary>
        /// Check the trackline component to see if a the hblinking field contains the desired state 
        /// </summary>
        /// <param name="window">Name of the window to find the component in</param>
        /// <param name="sectionIDs">Pipe delimited ID(s) of the trackline object to check</param>
        /// <param name="isBlinking">boolean for the state desired</param>
        [UserCodeMethod]
        public static void ValidateBlinkingState(String window, String tdmsIds, bool isBlinking)
        {
            
            String[] sections = tdmsIds.Split('|');
            
            foreach (String id in sections)
            {
                Report.Info(String.Format("Validating the blinking state of {0}:{1} to be {2}", window, id, isBlinking));
                var element = Signaling.FindTrackLineAssetByContext(window, id);
                			
                String blinkingState = element.Element.GetAttributeValue("blinking").ToString();
                
                if (blinkingState.ToLower().Equals("true") && isBlinking == true)
                {
                    Report.Success(String.Format("Found 'blinking:{0}' in trackline object '{1}'", blinkingState, id));
                }
                else if (blinkingState.ToLower().Equals("false") && isBlinking == false)
                {
                    Report.Success(String.Format("Found 'blinking:{0}' in trackline object '{1}'", blinkingState, id));
                }
                else
                {
                    Report.Failure(String.Format("Blinking States did not match 'blinking:{0}' does not match 'isBlinking:{1}' for trackline object '{2}'", blinkingState, isBlinking.ToString(), id));
                }
                
                Delay.Milliseconds(100);
            }
        }
        
        /// <summary>
        /// Opens an EMT tag located above the Trackline
        /// </summary>
        /// <param name="trainSeed">Train Seed used for getting Train Symbol</param>
        /// <param name="trainSeed2">Secondary Train Seed used for getting second Train Symbol (in the event of EMTs/Trains stacked on piece of trackline)</param>
        [UserCodeMethod]
        public static void OpenEMTFromTrackline(String trainSeed, String trainSeed2)
        {
        	var repo = TrackLine.Instance;
        	            
            String trainID = PDS_CORE.Code_Utils.CN_TrainID.getTrainID(trainSeed);
            repo.trainID = trainID;
            Delay.Milliseconds(0);
            
            if(repo.TrackLineWindow.EMTAboveTrackline.Visible) {
            	Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'TrackLineWindow.EmtTagAboveTrackline' at Center.", repo.TrackLineWindow.EMTAboveTracklineInfo, new RecordItemIndex(1));
            	repo.TrackLineWindow.EMTAboveTrackline.Click();
            	Delay.Milliseconds(200);
            	
            	Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'TrackLineWindow.EmtTagAboveTrackline' at Center.", repo.TrackLineWindow.EMTAboveTracklineInfo, new RecordItemIndex(1));
            	repo.TrackLineWindow.EMTAboveTrackline.Click();
            	Delay.Milliseconds(200);
            } else {
            	// if items are stacked on trackline, open the stacked item table and open the EMT
            	if(repo.TrackLineWindow.TrainID.Visible) {
            		Report.Log(ReportLevel.Info, "Mouse", "Mouse Middle Click item 'TrackLineWindow.TrainId' at Center.", repo.TrackLineWindow.TrainIDInfo, new RecordItemIndex(1));
            		repo.TrackLineWindow.TrainID.Click(WinForms.MouseButtons.Middle);
            		Delay.Milliseconds(200);
            	} else {
            		String trainID2 = PDS_CORE.Code_Utils.CN_TrainID.getTrainID(trainSeed2);
            		repo.trainID = trainID2;
            		Report.Log(ReportLevel.Info, "Mouse", "Mouse Middle Click item 'TrackLineWindow.TrainId' at Center.", repo.TrackLineWindow.TrainIDInfo, new RecordItemIndex(1));
            		repo.TrackLineWindow.TrainID.Click(WinForms.MouseButtons.Middle);
            		Delay.Milliseconds(200);
            	}
            	repo.trainID = trainID;
            	Report.Log(ReportLevel.Info, "Mouse", "Mouse Right Click item 'TrackLineWindow.EmtTagAboveTrackline' at Center.", repo.TrackLineWindow.EMTAboveTracklineInfo, new RecordItemIndex(1));
            	GeneralUtilities.RightClickAndWaitForWithRetry(repo.TrackLineWindow.EMTAboveTracklineInfo,
            	                                               repo.TrackLineWindow.RemoveEMTInfo);
            	Delay.Milliseconds(200);
            	
            	Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'TrackLineWindow.RemoveEmt' at Center.", repo.TrackLineWindow.RemoveEMTInfo, new RecordItemIndex(1));
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(repo.TrackLineWindow.RemoveEMTInfo,
            	                                                  repo.TrackLineWindow.RemoveEMTInfo);
            	Delay.Milliseconds(200);
            }
            
        }

		
		/// <summary>
		/// Use CurrentState of Jtlr Device to determine if activated
		/// </summary>
		/// <param name="window"></param>
		/// <param name="deviceId"></param>
		/// <param name="state"></param>
		[UserCodeMethod]
		public static void DeviceStateValidation(string window, string deviceId, string state) {
			//LCI, ON -> CP Local Control
			//"MD, ION" -> Misc Device On
			//maybe enum the values so we dont' lose the info?
			
			Report.Log(ReportLevel.Info, String.Format("Verifying {0}:{1} in state {2}", window, deviceId, state));
			
			Ranorex.JavaElement element = Signaling.FindTrackLineAssetByContext(window, deviceId);
			if(element != null)
				Validate.AttributeContains(element.Element,"CurrentState",state);
			else 
				Validate.Fail(String.Format("Unable to find track line asset {0} on window {1}", deviceId, window));
		}


		
    }
}
