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

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace PDS_NS.Recording_Modules.Track_Authorities
{
    public partial class ValidateCommunicationExchangeFormDoesntExist
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

        public void ValidateCommunicationExchangeFormDoesntExistFunction()
        {
        	int retries = 0;
        	while (Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0) && retries < 3)
        	{
        		Ranorex.Delay.Milliseconds(500);
        		retries++;
        	}
        	
        	if (Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
        	{
        		Ranorex.Report.Failure("Communications Exchange form is still open");
        		return;
        	}
        	
        	Ranorex.Report.Success("Communications Exchange form is closed");
        }

    }
}
