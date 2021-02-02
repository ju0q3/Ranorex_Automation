/*
 * Created by Ranorex
 * User: r07000021
 * Date: 1/16/2018
 * Time: 1:47 PM
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
    /// A collection of filter methods to use with TrackSegmentAttributeValidation method. Used to simplify ranorex user interaction with PDS java element lingo.
    /// Only required Params should be the window name of the desk validation is to occur on, and the tdms ID of the track object.
    /// </summary>
    [UserCodeCollection]
    public class TrackDevice_Validations
    {
    	
    	[UserCodeMethod]
    	/// <summary>
    	/// 
    	/// </summary>
    	/// <param name="window"></param>
    	/// <param name="tdmsID"></param>
   		public static void NoAuthority_ValidateTrackNONCTC (string window, string tdmsID) {
    		//Check for ABS & TWC
    		if (tdmsID.Contains("|")) {
    		    String[] tdmsIDList = tdmsID.Split('|');
    		    foreach (String iD in tdmsIDList) {
    		    	TracklineActions.TrackSegmentAttributeValueNotPresent(window, iD, "CurrentState", "WARRANT_TYPE");
    		    }

    		} else {
    		    TracklineActions.TrackSegmentAttributeValueNotPresent(window, tdmsID, "CurrentState", "WARRANT_TYPE");
    		}
    	}
    	
    	[UserCodeMethod]
    	/// <summary>
    	/// 
    	/// </summary>
    	/// <param name="window"></param>
    	/// <param name="tdmsID"></param>
    	public static void NoAuthority_ValidateTrackCTC (string window, string tdmsID) {
    		if (tdmsID.Contains("|")) {
    		    String[] tdmsIDList = tdmsID.Split('|');
    		    foreach (String iD in tdmsIDList) {
    		    	TracklineActions.TrackSegmentAttributeValidation(window, iD, "CurrentState", "MA, NMA");
    		    }

    		} else {
    		    TracklineActions.TrackSegmentAttributeValidation(window, tdmsID, "CurrentState", "MA, NMA");
    		}
	    }
    	
    	[UserCodeMethod]
    	/// <summary>
    	/// 
    	/// </summary>
    	/// <param name="window"></param>
    	/// <param name="tdmsID"></param>
   		public static void ProceedToPointAuthority_ValidateTrack (string window, string tdmsID) {
    		
    		if (tdmsID.Contains("|")) {
    		    String[] tdmsIDList = tdmsID.Split('|');
    		    foreach (String iD in tdmsIDList) {
    		    	TracklineActions.TrackSegmentAttributeValidation(window,iD, "CurrentState", "WARRANT_TYPE = PROCEED_TO_POINT");
    		    }

    		    } else {
    		    	TracklineActions.TrackSegmentAttributeValidation(window,tdmsID, "CurrentState", "WARRANT_TYPE = PROCEED_TO_POINT");
    		    }   	
    		    
	    }
    	
    	[UserCodeMethod]
    	/// <summary>
    	/// 
    	/// </summary>
    	/// <param name="window"></param>
    	/// <param name="tdmsID"></param>
   		public static void ProceedNeitherAuthority_ValidateTrack (string window, string tdmsID) {
    		
    		if (tdmsID.Contains("|")) {
    		    String[] tdmsIDList = tdmsID.Split('|');
    		    foreach (String iD in tdmsIDList) {
    		    	TracklineActions.TrackSegmentAttributeValidation(window,iD, "CurrentState", "WARRANT_TYPE = PROCEED_NEITHER");
    		    }
		    } else {
		    	TracklineActions.TrackSegmentAttributeValidation(window,tdmsID, "CurrentState", "WARRANT_TYPE = PROCEED_NEITHER");
		    } 
		
	    }
    
    	[UserCodeMethod]
    	/// <summary>
    	/// 
    	/// </summary>
    	/// <param name="window"></param>
    	/// <param name="tdmsID"></param>
   		public static void WorkAuthority_ValidateTrackNONCTC (string window, string tdmsID) {
    		
    		if (tdmsID.Contains("|")) {
    		    String[] tdmsIDList = tdmsID.Split('|');
    		    foreach (String iD in tdmsIDList) {  	
    		    		TracklineActions.TrackSegmentAttributeValidation(window,iD, "CurrentState", "WARRANT_TYPE = WORK");
    		    }
		    } else {
		    	TracklineActions.TrackSegmentAttributeValidation(window,tdmsID, "CurrentState", "WARRANT_TYPE = WORK");
		    }
    		    
	    }
    	
    	[UserCodeMethod]
    	/// <summary>
    	/// 
    	/// </summary>
    	/// <param name="window"></param>
    	/// <param name="tdmsID"></param>
   		public static void WorkAuthority_ValidateTrackCTC (string window, string tdmsID) {
    		
    		if (tdmsID.Contains("|")) {
    		    String[] tdmsIDList = tdmsID.Split('|');
    		    foreach (String iD in tdmsIDList) {  	
		    		TracklineActions.TrackSegmentAttributeValidation(window,iD, "CurrentState", "MA, IMA");
    		    }
		    } else {
    	    	TracklineActions.TrackSegmentAttributeValidation(window,tdmsID, "CurrentState", "MA, IMA");
		    }
    		    
	    }
	    
    	[UserCodeMethod]
    	/// <summary>
    	/// 
    	/// </summary>
    	/// <param name="window"></param>
    	/// <param name="tdmsID"></param>
   		public static void ProceedClearMainAuthority_ValidateTrack (string window, string tdmsID) {
    		
    		if (tdmsID.Contains("|")) {
    			   		    String[] tdmsIDList = tdmsID.Split('|');
    		    foreach (String iD in tdmsIDList) {    		    	
    		    	TracklineActions.TrackSegmentAttributeValidation(window,iD, "CurrentState", "WARRANT_TYPE = PROCEED_CLEAR_MAIN");
    		    }
		    } else {
		    	TracklineActions.TrackSegmentAttributeValidation(window,tdmsID, "CurrentState", "WARRANT_TYPE = PROCEED_CLEAR_MAIN");

		    }
    		    
	    }
    }
}
