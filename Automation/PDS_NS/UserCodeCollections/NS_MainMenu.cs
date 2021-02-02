/*
 * Created by Ranorex
 * User: 503099171
 * Date: 24/04/2020
 * Time: 18:16hrs
 *
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WinForms = System.Windows.Forms;
using PDS_CORE.Code_Utils;
using System.Globalization;
using PDS_NS.Recording_Modules.PTC.PTC_Configuration;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Path;
using Ranorex.Core.Testing;
using Oracle.Code_Utils;
using Env.Code_Utils;
using PDS_NS.UserCodeCollections.NS_Oracle;
using Ranorex.Plugin;

namespace PDS_NS.UserCodeCollections
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
	public class NS_MainMenu
	{
        public static global::PDS_NS.MainMenu_Repo MainMenurepo = global::PDS_NS.MainMenu_Repo.Instance;
		[UserCodeMethod]
        public static void NS_ValidateMainMenuOptionsEnable_MainMenu(string menuOption,bool isEnable)
        {
        	if(MainMenurepo.PDS_Main_Menu.SelfInfo.Exists(0))
        	{
        		MainMenurepo.PDS_Main_Menu.Self.Activate();
        		switch (menuOption.ToLower())
        		{
        			case "createtrain":
        				GeneralUtilities.NS_CheckMenuEnabled_MainMenu(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrainsButtonInfo,
        				                                              MainMenurepo.PDS_Main_Menu.TrainsMenu.SelfInfo,
        				                                              MainMenurepo.PDS_Main_Menu.TrainsMenu.CreateTrainInfo,
        				                                              isEnable);
        				break;
        			case "trainschedule":
        				GeneralUtilities.NS_CheckMenuEnabled_MainMenu(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrainsButtonInfo,
        				                                              MainMenurepo.PDS_Main_Menu.TrainsMenu.SelfInfo,
        				                                              MainMenurepo.PDS_Main_Menu.TrainsMenu.TrainScheduleInfo,
        				                                              isEnable);
        				break;
        			case "trainstatussummary":
        				GeneralUtilities.NS_CheckMenuEnabled_MainMenu(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrainsButtonInfo,
        				                                              MainMenurepo.PDS_Main_Menu.TrainsMenu.SelfInfo,
        				                                              MainMenurepo.PDS_Main_Menu.TrainsMenu.TrainStatusSummaryInfo,
        				                                              isEnable);
        				GeneralUtilities.NS_CheckMenuEnabled_MainMenu(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrainsButtonInfo,
        				                                              MainMenurepo.PDS_Main_Menu.TrainsMenu.SelfInfo,
        				                                              MainMenurepo.PDS_Main_Menu.TrainsMenu.TrainStatusSummaryChoiceInfo,
        				                                              isEnable);
        				break;
        			case "viewmovementplanner":
        				GeneralUtilities.NS_CheckMenuEnabled_MainMenu(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
        				                                              MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo,
        				                                              MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.MovementPlanningStatusInfo,
        				                                              isEnable);
        				break;
        			case "expresstrains":
        				GeneralUtilities.NS_CheckMenuEnabled_MainMenu(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrainsButtonInfo,
        				                                              MainMenurepo.PDS_Main_Menu.TrainsMenu.SelfInfo,
        				                                              MainMenurepo.PDS_Main_Menu.TrainsMenu.ExpressCreateTrainInfo,
        				                                              isEnable);
        				break;
        			case "unusaloccurrances":
        				GeneralUtilities.NS_CheckMenuEnabled_MainMenu(MainMenurepo.PDS_Main_Menu.MainMenuBar.MiscellaneousButtonInfo,
        				                                              MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.SelfInfo,
        				                                              MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.UnusualOccurencesInfo,
        				                                              isEnable);
        				break;
        			case "helperoperations":
        				GeneralUtilities.NS_CheckMenuEnabled_MainMenu(MainMenurepo.PDS_Main_Menu.MainMenuBar.MiscellaneousButtonInfo,
        				                                              MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.SelfInfo,
        				                                              MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.HelperOperationsInfo,
        				                                              isEnable);
        				break;
        			case "trackauthorities":
        				GeneralUtilities.NS_CheckMenuEnabled_MainMenu(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrackAuthoritesButtonInfo,
        				                                              MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.SelfInfo,
        				                                              MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.SummaryListInfo,
        				                                              isEnable);
        				GeneralUtilities.NS_CheckMenuEnabled_MainMenu(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrackAuthoritesButtonInfo,
        				                                              MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.SelfInfo,
        				                                              MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.DetailedTrackAuthorityDisplayInfo,
        				                                              isEnable);
        				break;
        			case "positivetraincontrol":
        				GeneralUtilities.NS_CheckMenuEnabled_MainMenu(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
        				                                              MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo,
        				                                              MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.PositiveTrainControlInfo,
        				                                              isEnable);
        				GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
        				                                                 MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
        				break;
        			default:
        				Ranorex.Report.Failure("Invalid option");
        				break;
        		}
        	}
        	else
        	{
        		Ranorex.Report.Failure("PDS Main Menu does not exist");
        	}
        }
	}
}
