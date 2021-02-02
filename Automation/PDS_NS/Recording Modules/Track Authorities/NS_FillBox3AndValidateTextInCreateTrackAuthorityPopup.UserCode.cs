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
using PDS_NS.UserCodeCollections;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace PDS_NS.Recording_Modules.Track_Authorities
{
    public partial class NS_FillBox3AndValidateTextInCreateTrackAuthorityPopup
    {
    	
    	public static global::PDS_NS.TrackAuthorities_Repo Authoritiesrepo = global::PDS_NS.TrackAuthorities_Repo.Instance;
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            // Your recording specific initialization code goes here.
        }

       /// <summary>
    	/// Fill Box3 in FBA Without Notification Popup Handaling.
    	/// </summary>
    	/// <param name="box3WorkBetweenFrom">Rw authority 'From' opsta</param>
    	/// <param name="box3FromCP">Rw authority 'From' control point check box</param>
    	/// <param name="box3To">Rw authority 'To' opsta</param>
    	/// <param name="box3ToCP">Rw authority 'From' control point check box</param>
    	/// <param name="box3Track1">Rw authority Track 1</param>
    	/// <returns></returns>
    
    	public static bool NS_FillBox3PopupTestingFunction(string box3WorkBetweenFrom, bool box3FromCP, string box3To, bool box3ToCP, string box3Track1)
    	{
    		int retries=0;
    		if (box3WorkBetweenFrom == "" && box3To == "")
    		{
    			return true;
    		}

    		if(Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenBetween.GetAttributeValue<string>("Text").Equals(box3WorkBetweenFrom, StringComparison.OrdinalIgnoreCase))
    		{
    			Ranorex.Report.Success("Box3 WorkBetweenForm is already pre-selected");
    		}
    		else
    		{
    			Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenBetween.Element.SetAttributeValue("Text", box3WorkBetweenFrom);
    			Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenBetween.PressKeys("{TAB}");

    		}
    		
    		string acceptableFeedback = "";
    		if (!NS_Authorities.CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
			{
				return false;
			}

    		if (box3FromCP)
    		{
    			if(!Authoritiesrepo.Create_Track_Authority.Box3.ControlPoint1Checkbox.Enabled && retries<5)
              	{
              		Delay.Milliseconds(500);
              		retries ++;
              	}
              	if(Authoritiesrepo.Create_Track_Authority.Box3.ControlPoint1Checkbox.Enabled)
              		
              	{
              		PDS_CORE.Code_Utils.GeneralUtilities.CheckCheckboxAndVerifyChecked(Authoritiesrepo.Create_Track_Authority.Box3.ControlPoint1Checkbox);
              		Ranorex.Report.Success("controlpoint1 check box enabled");
              	}
              	else
              	{
              		Ranorex.Report.Failure("controlpoint1 check box Disabled");
              	}
    		}
    		Authoritiesrepo.Create_Track_Authority.Box3.ControlPoint1Checkbox.PressKeys("{TAB}");

    		if(Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenAnd.GetAttributeValue<string>("Text").Equals(box3To, StringComparison.OrdinalIgnoreCase))
    		{
    			Ranorex.Report.Success("Box3 WorkBetweenAnd is already pre-selected");
    		}
    		else
    		{
    			Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenAnd.Element.SetAttributeValue("Text", box3To);
    			Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenAnd.PressKeys("{TAB}");
    		}
    		

    		if (!NS_Authorities.CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
			{
				return false;
			}

    		if (Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack1.Enabled)
    		{
    			Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack1.Element.SetAttributeValue("Text", box3Track1);
    			Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack1.PressKeys("{TAB}");

    			if (!NS_Authorities.CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
				{
					return false;
				}
    		} 
    		else 
    		{
    			string box3Track1Text = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack1.SelectedItemText;
    			if (box3Track1Text != box3Track1 && box3Track1 != "")
    			{
    				Ranorex.Report.Failure("Track could not be changed from {"+box3Track1Text+"} expected to be {"+box3Track1+"}.");
    				return false;
    			}
    		}	
			return true;
    	}

    }
}
