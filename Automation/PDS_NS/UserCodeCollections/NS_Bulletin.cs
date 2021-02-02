/*
 * Created by Ranorex
 * User: r07000021
 * Date: 11/7/2018
 * Time: 9:17 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Linq;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using PDS_CORE.Code_Utils;
using Oracle.Code_Utils;
namespace PDS_NS.UserCodeCollections
{
    /// <summary>
    /// Stores basic information about a bulletin for use in Special Validations
    /// </summary>
    public class NS_BulletinObject
    {
        public string bulletinNumber { get; set; }
        public string bulletinType { get; set; }
        public string milepost1 { get; set; }
        public string milepost2 { get; set; }
        public string district { get; set; }
        public string trackLine { get; set; }
        public string maximumSpeed { get; set; }
        public string bulletinId { get; set; }

    }
    
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_Bulletin
    {
        public static global::PDS_NS.Miscellaneous_Repo Miscellaneousrepo = global::PDS_NS.Miscellaneous_Repo.Instance;
        public static global::PDS_NS.MainMenu_Repo MainMenurepo = global::PDS_NS.MainMenu_Repo.Instance;
        public static global::PDS_NS.Bulletins_Repo Bulletinsrepo = global::PDS_NS.Bulletins_Repo.Instance;
        public static global::PDS_NS.Trackline_Repo Tracklinerepo = global::PDS_NS.Trackline_Repo.Instance;
        public static global::PDS_NS.TrackAuthorities_Repo TrackAuthoritiesrepo = global::PDS_NS.TrackAuthorities_Repo.Instance;
        //Bulletin List for persisting Bulletin Data for Validation purposes
        private static Dictionary<string, NS_BulletinObject> bulletinDictionary = new Dictionary<string, NS_BulletinObject>();
        
        private static void setBulletinObject(string bulletinSeed, NS_BulletinObject bulletinObject)
        {
            bulletinDictionary[bulletinSeed] = bulletinObject;
        }

        private static void addBulletinObject(string bulletinSeed, NS_BulletinObject bulletinObject)
        {
            if (!bulletinDictionary.ContainsKey(bulletinSeed))
            {
                bulletinDictionary.Add(bulletinSeed, bulletinObject);
            }
        }

        public static NS_BulletinObject getBulletinObject(string bulletinSeed)
        {
            NS_BulletinObject bulletinObject = null;
            if (BulletinExists(bulletinSeed))
            {
                bulletinObject = bulletinDictionary[bulletinSeed];
            }
            return bulletinObject;
        }
        
        public static void AddBulletinId(string bulletinSeed)
        {
            string bulletinNumber = GetBulletinNumber(bulletinSeed);
            NS_BulletinObject bulletinObject = bulletinDictionary[bulletinSeed];
            bulletinObject.bulletinId = ADMSEnvironment.GetBulletinId_ADMS(bulletinNumber);
        }

        /// <summary>
        /// Return a string-formatted bulletin number corresponding to the bulletinSeed.
        /// </summary>
        /// <param name="bulletinSeed">Input:bulletinSeed</param>
        [UserCodeMethod]
        public static string GetBulletinNumber(string bulletinSeed)
        {
            string bulletinNumber = null;
            NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
            if (bulletinObject != null)
            {
                bulletinNumber = bulletinObject.bulletinNumber;
            }
            return bulletinNumber;
        }
        
        /// <summary>
		/// Return a string-formatted bulletin id corresponding to the bulletinSeed.
		/// </summary>
		/// <param name="bulletinSeed">Input:bulletinSeed</param>
		[UserCodeMethod]
        public static string GetBulletinId(string bulletinSeed)
        {
        	string bulletinId = null;
        	NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
        	if (bulletinObject != null)
        	{
        		bulletinId = bulletinObject.bulletinId;
        	}
        	return bulletinId;
        }

        /// <summary>
        /// Return a string-formatted bulletin type corresponding to the bulletinSeed.
        /// </summary>
        /// <param name="bulletinSeed">Input:bulletinSeed</param>
        [UserCodeMethod]
        public static string GetBulletinType(string bulletinSeed)
        {
            string bulletinType = null;
            NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
            if (bulletinObject != null)
            {
                bulletinType = bulletinObject.bulletinType;
            }
            return bulletinType;
        }

        /// <summary>
        /// Return a string-formatted 'milepost1' attribute corresponding to the bulletinSeed.
        /// </summary>
        /// <param name="bulletinSeed">Input:bulletinSeed</param>
        [UserCodeMethod]
        public static string GetBulletinMilepost1(string bulletinSeed)
        {
            string milepost1 = null;
            NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
            if (bulletinObject != null)
            {
                milepost1 = bulletinObject.milepost1;
            }
            return milepost1;
        }

        /// <summary>
        /// Return a string-formatted 'milepost2' attribute corresponding to the bulletinSeed.
        /// </summary>
        /// <param name="bulletinSeed">Input:bulletinSeed</param>
        [UserCodeMethod]
        public static string GetBulletinMilepost2(string bulletinSeed)
        {
            string milepost2 = null;
            NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
            if (bulletinObject != null)
            {
                milepost2 = bulletinObject.milepost2;
            }
            return milepost2;
        }

        /// <summary>
        /// Return a string-formatted 'district' attribute corresponding to the bulletinSeed.
        /// </summary>
        /// <param name="bulletinSeed">Input:bulletinSeed</param>
        [UserCodeMethod]
        public static string GetBulletinDistrict(string bulletinSeed)
        {
            string district = null;
            NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
            if (bulletinObject != null)
            {
                district = bulletinObject.district;
            }
            return district;
        }
        
        /// <summary>
        /// Return a string-formatted 'trackLine' attribute corresponding to the bulletinSeed.
        /// </summary>
        /// <param name="bulletinSeed">Input:bulletinSeed</param>
        [UserCodeMethod]
        public static string GetBulletinTrackLine(string bulletinSeed)
        {
            string trackLine = null;
            NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
            if (bulletinObject != null)
            {
                trackLine = bulletinObject.trackLine;
            }
            return trackLine;
        }
        
        /// <summary>
        /// Return a string-formatted 'maximumSpeed' attribute corresponding to the bulletinSeed.
        /// </summary>
        /// <param name="bulletinSeed">Input:bulletinSeed</param>
        [UserCodeMethod]
        public static string GetBulletinMaximumSpeed(string bulletinSeed)
        {
            string maximumSpeed = null;
            NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
            if (bulletinObject != null)
            {
                
                maximumSpeed = bulletinObject.maximumSpeed;
            }
            return maximumSpeed;
        }

        public static bool BulletinExists(string bulletinSeed)
        {
            return bulletinDictionary.ContainsKey(bulletinSeed);
        }

        /// <summary>
        /// Adds Bulletin Objects to the Bulletin object dictionary
        /// </summary>
        /// <param name="bulletinSeed">Input:bulletinSeed</param>
        /// <param name="BulletinNumber">Input:BulletinNumber</param>
        /// <param name="bulletinType">Input:bulletinType</param>
        /// <param name="milepost1">Input:milepost1</param>
        /// <param name="milepost2">Input:milepost2</param>
        /// <param name="district">Input:district</param>
        public static void CreateBulletinRecord(string bulletinSeed, string bulletinNumber, string bulletinType, string milepost1, string milepost2, string district, string trackLine, string maximumSpeed, string bulletinId = "")
        {
            NS_BulletinObject newBulletinObject = new NS_BulletinObject();
            
            newBulletinObject.bulletinNumber = bulletinNumber;
            newBulletinObject.bulletinType = bulletinType;
            newBulletinObject.milepost1 = milepost1;
            newBulletinObject.milepost2 = milepost2;
            newBulletinObject.district = district;
            newBulletinObject.trackLine = trackLine;
            newBulletinObject.maximumSpeed = maximumSpeed;
            newBulletinObject.bulletinId = bulletinId;
            if (BulletinExists(bulletinSeed))
            {
                setBulletinObject(bulletinSeed, newBulletinObject);
            } else {
                addBulletinObject(bulletinSeed, newBulletinObject);
            }
        }

        /// <summary>
        /// Return a list of existing keys that are currently used in the bulletinDictionary.
        /// </summary>
        public static List<string> GetBulletinSeeds()
        {
            List<string> keyList = new List<string>(bulletinDictionary.Keys);
            return keyList;
        }

        /// <summary>
        /// Opens the Bulletin Input Form if not already open
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenBulletinInputForm_MainMenu()
        {
            int retries = 0;

            //Open Bulletin Input Form if it's not already open
            if (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
            {
                //Click Bulletin menu
                MainMenurepo.PDS_Main_Menu.Self.EnsureVisible();
                PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.BulletinButtonInfo, MainMenurepo.PDS_Main_Menu.BulletinMenu.SelfInfo);
                //Click Input in bulletins menu
                MainMenurepo.PDS_Main_Menu.BulletinMenu.Input.Click();
                
                //Wait for Bulletin Input Form to exist in case of lag
                if (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
                {
                    Ranorex.Delay.Milliseconds(500);
                    while (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0) && retries < 2)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }
                    
                    if (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("Bulletin Input form did not open");
                        return;
                    }
                }
            }
            //If Input Tab is selected, then we don't need to do anything
            if (!Bulletinsrepo.Bulletins_Input_Relay.BulletinTabs.InputTab.GetAttributeValue<bool>("Selected"))
            {
                Bulletinsrepo.Bulletins_Input_Relay.BulletinTabs.InputTab.Click();
            }
            
            return;
        }
        
        /// <summary>
        /// Opens the Bulletin Relay Form if not already open
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenBulletinRelayForm_MainMenu()
        {
            int retries = 0;

            //Open Bulletin Relay Form if it's not already open
            if (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
            {
                //Click Bulletin menu
                PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.BulletinButtonInfo, MainMenurepo.PDS_Main_Menu.BulletinMenu.SelfInfo);
                //Click Relay in bulletins menu
                MainMenurepo.PDS_Main_Menu.BulletinMenu.Relay.Click();
                
                //Wait for Bulletin Relay Form to exist in case of lag
                if (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
                {
                    Ranorex.Delay.Milliseconds(500);
                    while (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0) && retries < 2)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }
                    
                    if (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("Bulletin Relay form did not open");
                        return;
                    }
                }
            }
            Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
            //If Relay Tab is selected, then we don't need to do anything
            if (!Bulletinsrepo.Bulletins_Input_Relay.BulletinTabs.RelayTab.GetAttributeValue<bool>("Selected"))
            {
                Bulletinsrepo.Bulletins_Input_Relay.BulletinTabs.RelayTab.Click();
            }
            
            return;
        }
        
        /// <summary>
        /// Opens the Bulletin Input Form if not already open
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenBulletinSummaryList_MainMenu()
        {
            int retries = 0;

            //Open Bulletin Input Form if it's not already open
            if (!Bulletinsrepo.Bulletin_Summary_List.SelfInfo.Exists(0))
            {
                //Click Bulletin menu
                PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.BulletinButtonInfo, MainMenurepo.PDS_Main_Menu.BulletinMenu.SelfInfo);
//                MainMenurepo.PDS_Main_Menu.MainMenuBar.BulletinButton.Click();
                //Click Summary List in bulletins menu
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.PDS_Main_Menu.BulletinMenu.SummaryListInfo, MainMenurepo.PDS_Main_Menu.BulletinMenu.SummaryListInfo);
//                MainMenurepo.PDS_Main_Menu.BulletinMenu.SummaryList.Click();
                
                //Wait for Bulletin Summary List Form to exist in case of lag
                if (!Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.SelfInfo.Exists(0))
                {
                    Ranorex.Delay.Milliseconds(500);
                    while (!Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.SelfInfo.Exists(0) && retries < 6)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }
                    
                    if (!Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("Bulletin Summary List form did not open");
                        return;
                    }
                }
            }
            
            return;
        }
        
        public static void NS_CloseViewShortTracksForm_BulletinInputRelayForm()
        {
            // In the event that the form exists on first pass, then close immediately.
            if (Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.ShowAllTracksButtonInfo,
                    Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo
                   );
                return;
            }
            
            // Hardening is minimally necessary in the event that the form does not appear immediately.
            // This includes scenarios where the form takes 15 short milliseconds to appear.
            int retries = 0;
            while (!Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0) && retries < 4)
            {
                Ranorex.Delay.Milliseconds(25);
                //If View Short Tracks Form appears select Show All Tracks
                if (Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                        Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.ShowAllTracksButtonInfo,
                        Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo
                       );
                    return;;
                }
                retries++;
            }
            return;
        }
        
        
        
        /// <summary>
        /// Compares feedback with regex of expectedFeedback
        /// </summary>
        /// <param name="feedback">Input:feedback</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        public static bool CheckFeedback(Adapter feeback, string expectedFeedback)
        {
        	Regex expectedFeedbackRegex = new Regex(expectedFeedback);
        	string feedbackText = feeback.GetAttributeValue<string>("Text");
        	if (feedbackText == "" || feedbackText == " ")
        	{
        		//No feedback received, return
        		return true;
        	}
        	if (expectedFeedback == "")
        	{
        		Ranorex.Report.Failure("Expected no feedback, got feedback of {"+feedbackText+"}.");
        		return false;
        	}
        	if (expectedFeedbackRegex.IsMatch(feedbackText))
        	{
        		Ranorex.Report.Success("Expected Regex feedback of {"+@expectedFeedbackRegex+"} found feedback {"+feedbackText+"}.");
        		return false;
        	}
        	return true;
        }
        
        /// <summary>
        /// On the Bulletin Summary List, this function will void all Bulletins in the table.
        /// </summary>
        /// <param name="closeForms">Input:Closes Bulletin Summary List</param>
        [UserCodeMethod]
        public static void NS_VoidAllBulletins_BulletinSummaryList(bool closeForms)
        {
            //Open Bulletin Summary List form if it's not already open
            NS_OpenBulletinSummaryList_MainMenu();
            
            if (Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.SelfInfo.Exists(0)) 
            {
                int retries = 0;
                while (Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.Self.Rows.Count == 0 && retries < 6)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }
                int rowCount = Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.Self.Rows.Count;
                int unremovableCount = 0;
                Report.Info(String.Format("Found {0} bulletins in the list to remove", rowCount.ToString()));
                
                if(rowCount > 0)
                {
                    // Set the row selection to look at the first row to start
                    for(int i=rowCount-1; i>=0; i--)
                    {
                    	if (unremovableCount > rowCount)
                    	{
                    		Report.Error("The number of unremovable bulletins exceeds the number of bulletins");
                    		break;
                    	}
                    	Bulletinsrepo.RowIndex = i.ToString();
                        if (Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByRowIndex.SelfInfo.Exists(0))
                        {
                            string currentBulletinNumber = Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByRowIndex.CellByColumnName.BulletinNumber.GetAttributeValue<string>("Text");
                            
                            //Right Click the menu cell of the first bulletin and select Open
                            GeneralUtilities.RightClickAndWaitForWithRetry(Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByRowIndex.MenuCellInfo,
                                                                           Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.MenuCellMenu.OpenBulletinInfo);
                            GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.MenuCellMenu.OpenBulletinInfo,
                                                                      Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
                            
                            if (Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
                            {
                                NS_VoidBulletin_BulletinInputRelayForm(currentBulletinNumber, true);
                                
                                //If the number of Bulletins in the Summary List hasn't changed, then none were removed due to an error
                                int newRowCount = Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.Self.Rows.Count;
                                if (newRowCount == rowCount)
                                {
                                    unremovableCount++;
                                    Bulletinsrepo.RowIndex = unremovableCount.ToString();
                                    Ranorex.Report.Error("Bulletin could not be removed");
                                }
                                
                            }
                            else
                            {
                                //if we could not open the bulletin, then that bulletin cannot be removed
                                unremovableCount++;
                                Bulletinsrepo.RowIndex = unremovableCount.ToString();
                                Ranorex.Report.Error("Bulletin Input form could not be opened");
                            }
                            rowCount = Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.Self.Rows.Count;
                        }
                        else
                        {
                            Ranorex.Report.Failure("Row with row number: "+i.ToString()+" does not exist");
                        }
                        
                        if (Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo.Exists(0))
                        {
                            Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButton.Click();
                        }
                    }
                }
                
                if (closeForms)
                {
                    Ranorex.Report.Info("Closing Summary List Form");
                    Bulletinsrepo.Bulletin_Summary_List.WindowControls.Close.Click();
                    if (Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists())
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo,
                                                                          Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
                    }
                }
                
            }
        }
        
        /// <summary>
        /// Voids Bulletin From Bulletin Input Form using the Bulletins Bulletin Number
        /// </summary>
        /// <param name="bulletinSeed">Input:Bulletin Seed of Bulletin to be removed</param>
        /// <param name="closeBulletinInputForm">Input:Closes the Bulletin Input Form if true</param>
        [UserCodeMethod]
        public static void NS_VoidBulletin_BulletinInputRelayForm(string bulletinSeed, bool closeBulletinInputForm = true)
        {
        	NS_OpenBulletinInputForm_MainMenu();
            if (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Bulletin Input Form could not be found");
                return;
            }
            
            //If Bulletin seed doesn't exist assume the seed is the bulletin number
            string targetBulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
            if (targetBulletinNumber == null)
            {
                targetBulletinNumber = bulletinSeed;
            }
            
            Bulletinsrepo.BulletinNumber = targetBulletinNumber;
            
            string district = NS_Bulletin.GetBulletinDistrict(bulletinSeed);
            string bulletinType = NS_Bulletin.GetBulletinType(bulletinSeed);
            Bulletinsrepo.DistrictName = district;
            Bulletinsrepo.BulletinTypeName = bulletinType;
            
            if(Bulletinsrepo.Bulletins_Input_Relay.Input.District.DistrictMenuItem.GetAttributeValue<string>("Text") != district)
            {
                if(Bulletinsrepo.Bulletins_Input_Relay.Input.District.DistrictMenuItem.GetAttributeValue<bool>("Enabled"))
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.District.DistrictMenuItemInfo,
                                                              Bulletinsrepo.Bulletins_Input_Relay.Input.District.DistrictMenuList.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.District.DistrictMenuList.DistrictListItemByDistrictNameInfo,
                                                                      Bulletinsrepo.Bulletins_Input_Relay.Input.District.DistrictMenuList.SelfInfo);
                }
            }
            
            if(Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuItem.GetAttributeValue<string>("Text") != bulletinType)
            {
                if(Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuItem.GetAttributeValue<bool>("Enabled"))
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuItemInfo,
                                                              Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuList.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuList.TypeListItemByBulletinTypeNameInfo,
                                                                      Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuList.SelfInfo);
                }
            }
            int retries = 0;
            while(!Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByBulletinNumber.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (!Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByBulletinNumber.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Bulletin with Bulletin Number {"+targetBulletinNumber+"} was not found in Bulletin Input Form");
                if (closeBulletinInputForm)
                {
                    CloseBulletinItemsForm_NS();
                }
            }
            
            string rowNumber = Convert.ToString(Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByBulletinNumber.ReferenceNumber.GetAttributeValue<int>("RowIndex"));
            Bulletinsrepo.BulletinRowIndex = rowNumber;
            
            Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();

            NS_Bulletin_Input_Form.ScrollUntilVisible(
                row: Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.Self,
                container: Bulletinsrepo.Bulletins_Input_Relay.Input.VisibleItemsTable.Self
            );

            GeneralUtilities.RightClickAndWaitForWithRetry(
                Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.MenuCellInfo,
                Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.VoidBulletinInfo
            );

            GeneralUtilities.ClickAndWaitForWithRetry(
                Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.VoidBulletinInfo,
                Bulletinsrepo.Bulletins_Input_Relay.Input.Warning_Form.SelfInfo
            );

            GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                Bulletinsrepo.Bulletins_Input_Relay.Input.Warning_Form.YesButtonInfo,
                Bulletinsrepo.Bulletins_Input_Relay.Input.Warning_Form.SelfInfo
            );
            
            retries = 0;
            while (!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 4)
            {
            	GeneralUtilities.CheckWaitState(10);
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if (Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
                    Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo
                );
            }

            if (Bulletinsrepo.Bulletins_Input_Relay.Feedback.GetAttributeValue<string>("Text").Trim() != "")
            {
                Report.Screenshot(Bulletinsrepo.Bulletins_Input_Relay.Self);
                Report.Failure(string.Format(
                    "The following error is displayed: '{0}'",
                    Bulletinsrepo.Bulletins_Input_Relay.Feedback.GetAttributeValue<string>("Text")
                ));
            } else {
                // TODO: Validate that there is no better way to ensure that the bulletin has been voided -DK
                Report.Success("Removed Bulletin with Bulletin Number {"+targetBulletinNumber+"} from Bulletin Input Form");
            }
            
            if (closeBulletinInputForm)
            {
                CloseBulletinItemsForm_NS();
            }
            
            return;

        }

        [UserCodeMethod]
        public static void NS_OpenTrainDetails_BulletinItemsNeededByTrains_BulletinInputRelayForm(string trainSeed, string bulletinSeed)
        {
            NS_OpenBulletinRelayForm_MainMenu();

            Bulletinsrepo.DistrictName = "All Controlled Districts";
            if (Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuItem.SelectedItemText != Bulletinsrepo.DistrictName)
            {
                GeneralUtilities.ClickAndWaitForWithRetry(
                    Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuItemInfo,
                    Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuList.SelfInfo
                   );
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuList.DistrictListItemByDistrictNameInfo,
                    Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuList.SelfInfo
                   );
            }
            

            string bulletinNumber = GetBulletinNumber(bulletinSeed);
            if (bulletinNumber != null)
            {
                Bulletinsrepo.BulletinNumber = bulletinNumber;
            } else {
                Report.Error(string.Format("No bulletin exists for bulletin seed '{0}'", bulletinSeed));
                return;
            }

            string trainId = NS_TrainID.GetTrainId(trainSeed);
            if (trainId != null)
            {
                Bulletinsrepo.TrainID = trainId;
            } else {
                Report.Error(string.Format("No train exists for train seed '{0}'", trainSeed));
                return;
            }
            
            int attempts = 0;
            while (!Bulletinsrepo.Bulletins_Input_Relay.Relay.ArrangeBy.BulletinItemsNeededByTrainRadioButton.Checked && attempts < 3)
            {
                Bulletinsrepo.Bulletins_Input_Relay.Relay.ArrangeBy.BulletinItemsNeededByTrainRadioButton.Click();
                Delay.Milliseconds(250);
                attempts++;
            }

            if (!Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinNumber.SelfInfo.Exists(0))
            {
                Report.Error(string.Format("No bulletin found in relay form corresponding to bulletin number '{0}'", bulletinNumber));
                return;
            }

            if (Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinNumber.Self.GetAttributeValue<int>("ChildCount") == 0)
            {
                Report.Error(string.Format("The bulletin number '{0}' is not needed by any active train.", bulletinNumber));
                return;
            }
            
            // Expand the tree list
            int retry = 0;
            while (!Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinNumber.Self.GetAttributeValue<bool>("Expanded") && retry < 3)
            {
                Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinNumber.Self.DoubleClick();
                Delay.Milliseconds(500);
                retry++;
            }
            
            if (!Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinNumber.Self.GetAttributeValue<bool>("Expanded"))
            {
                Report.Error(string.Format("Unable to expand the tree item list for bulletin number: '{0}'", bulletinNumber));
                return;
            }

            if (Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinNumber.TrainIDTreeItemByTrainIDInfo.Exists(0))
            {
                Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinNumber.TrainIDTreeItemByTrainID.Click();
                Report.Success(string.Format("Train '{0}' found among active trains for bulletin number '{1}'", trainId, bulletinNumber));
            } else {
                Report.Error(string.Format("Train '{0}' not found among active trains for bulletin number '{1}'", trainId, bulletinNumber));
                return;
            }

        }

        [UserCodeMethod]
        public static void NS_ValidateRetransmitOptionExists_BulletinInputRelayForm(string trainSeed, string bulletinSeed, bool validateDoesExist = false, bool closeForm = true)
        {
            
            NS_OpenTrainDetails_BulletinItemsNeededByTrains_BulletinInputRelayForm(trainSeed: trainSeed, bulletinSeed: bulletinSeed);

            // Not necessary to ensure bulletin number or train id exist. It is already performed in above method.
            Bulletinsrepo.BulletinNumber = GetBulletinNumber(bulletinSeed);
            Bulletinsrepo.TrainID = NS_TrainID.GetTrainId(trainSeed);
            
            if (validateDoesExist)
            	GeneralUtilities.RightClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinNumber.TrainIDTreeItemByTrainIDInfo, Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.MenuCellMenu.SelfInfo);
            else
            {
            	int retries = 0;
            	while (!Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.MenuCellMenu.RetransmitInfo.Exists(0) && retries < 3)
            	{
            		Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinNumber.TrainIDTreeItemByTrainID.Click(System.Windows.Forms.MouseButtons.Right);
            		retries++;
            	}
            }
            
            bool exists = Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.MenuCellMenu.RetransmitInfo.Exists(0);
            string resultMessage = string.Format("Retransmit option exists (expected): '{0}' & exists (actual): '{1}'", validateDoesExist, exists);
            if (exists == validateDoesExist)
            {
                Report.Success("Validation", resultMessage);
            } else {
                Report.Failure("Validation", resultMessage);
            }

            if (closeForm)
            {
                NS_CloseBulletinForm();
            }
        }

        [UserCodeMethod]
        public static void NS_RetransmitBulletin_BulletinInputRelayForm(string trainSeed, string bulletinSeed, bool closeForm = true)
        {
            NS_OpenTrainDetails_BulletinItemsNeededByTrains_BulletinInputRelayForm(trainSeed: trainSeed, bulletinSeed: bulletinSeed);

            // Not necessary to ensure bulletin number or train id exist. It is already performed in above method. Will throw an error if missing there.
            Bulletinsrepo.BulletinNumber = GetBulletinNumber(bulletinSeed);
            Bulletinsrepo.TrainID = NS_TrainID.GetTrainId(trainSeed);

            GeneralUtilities.RightClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinNumber.TrainIDTreeItemByTrainIDInfo, Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.MenuCellMenu.SelfInfo);
            if (Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.MenuCellMenu.RetransmitInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.MenuCellMenu.RetransmitInfo,
                    Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.MenuCellMenu.SelfInfo
                   );
                Report.Success("Retransmit option successfully executed.");
            } else {
                Report.Failure("Unable to click on retransmit option. Check settings to ensure that electronic delivery is enabled.");
            }

            if (closeForm)
            {
                NS_CloseBulletinForm();
            }
        }
        
        /// <summary>
        /// Voids Bulletin From Bulletin Summary List using the Bulletins Bulletin Number
        /// </summary>
        /// <param name="bulletinSeed">Input:Bulletin Seed of Bulletin to be removed</param>
        /// <param name="closeBulletinInputForm">Input:Closes the Bulletin Summary List if true</param>
        [UserCodeMethod]
        public static void NS_VoidBulletin_BulletinSummaryList(string bulletinSeed, bool closeBulletinSummaryList = true)
        {
            NS_OpenBulletinSummaryList_MainMenu();

            // We want to ensure that the form is closed, so that PDS will not throw an error that it cannot open another instance of the form
            // Please note that this is a proof-of-concept to see if this type of preventative action can lead to fewer failures.
            if (Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
            {
            	NS_Bulletin.CloseBulletinItemsForm_NS();
            }
            
            //If Bulletin seed doesn't exist assume the seed is the bulletin number
            string targetBulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
            if (targetBulletinNumber == null)
            {
                targetBulletinNumber = bulletinSeed;
            }
            
            Bulletinsrepo.BulletinNumber = targetBulletinNumber;
            int retries = 0;
            
            while(!Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByBulletinNumber.SelfInfo.Exists(0) && retries < 6)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (!Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByBulletinNumber.SelfInfo.Exists(0))
            {
                Ranorex.Report.Screenshot(Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.Self);
                Ranorex.Report.Error("Bulletin with Bulletin Number {"+targetBulletinNumber+"} was not found in Bulletin Summary List");
                if (closeBulletinSummaryList)
                {
                    CloseBulletinSummaryListForm_NS();
                }
                return;
            }
            
            int numberOfRows = Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.Self.Rows.Count;
            for (int i=0; i<numberOfRows; i++)
            {
                Bulletinsrepo.RowIndex = i.ToString();
                if (Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByRowIndex.CellByColumnName.BulletinNumber.Text == targetBulletinNumber)
                {
                	Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByRowIndex.Self.EnsureVisible();
                	break;
                }
            }
            
            GeneralUtilities.RightClickAndWaitForWithRetry(
                Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByRowIndex.MenuCellInfo,
                Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.MenuCellMenu.OpenBulletinInfo
            );
            
            GeneralUtilities.ClickAndWaitForWithRetry(
                Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.MenuCellMenu.OpenBulletinInfo,
                Bulletinsrepo.Bulletins_Input_Relay.SelfInfo

            );
            
            if (closeBulletinSummaryList)
            {
                CloseBulletinSummaryListForm_NS();
            }
            
            NS_VoidBulletin_BulletinInputRelayForm(targetBulletinNumber, true);
            return;
        }
        
        /// <summary>
        /// On the Bulletin Input Form, this function will void all visible Bulletins in the table.
        /// Has optional variables for selecting District and type
        /// </summary>
        /// <param name="optionalDistrict">Input:optionalDistrict</param>
        /// <param name="optionalType">Input:optionalType</param>
        /// <param name="closeForms">Input:Closes Bulletin Input Form</param>
        [UserCodeMethod]
        public static void NS_VoidVisibleBulletinsOnBulletinInputForm_BulletinInputRelayForm(string optionalDistrict, string optionalType, bool closeForms)
        {
            int retries = 0;
            //Open Bulletin Input form if it's not already open
            NS_OpenBulletinInputForm_MainMenu();
            //Check if input tab is selected and try selecting it if it's not
            if (!Bulletinsrepo.Bulletins_Input_Relay.BulletinTabs.InputTab.GetAttributeValue<bool>("Selected"))
            {
                Bulletinsrepo.Bulletins_Input_Relay.BulletinTabs.InputTab.Click();
                while(!Bulletinsrepo.Bulletins_Input_Relay.BulletinTabs.InputTab.GetAttributeValue<bool>("Selected") && retries < 2)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }
                if (!Bulletinsrepo.Bulletins_Input_Relay.BulletinTabs.InputTab.GetAttributeValue<bool>("Selected")) {
                    Ranorex.Report.Failure("Unable to get to Input Tab of Bulletin Input Form");
                    return;
                }
            }
            
            //Only need to select a type if you want to fill in the header as a blank district will default to "All Controlled Districts"
            if (optionalType != "")
            {
                NS_InputBulletins.InputBulletinHeader(optionalDistrict, optionalType);
            }
            
            if (Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0)) {
                
                int rowCount = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
                Report.Info(String.Format("Found {0} bulletins in the list to remove", rowCount.ToString()));
                
                if (rowCount > 0)
                {
                    // Set the row selection to look at the first row to start
                    Bulletinsrepo.BulletinRowIndex = "0";
                    
                    for (int x = rowCount-1; x <= 0; x--)
                    {
                        Bulletinsrepo.BulletinRowIndex = x.ToString();
                        string currentBulletinReferenceNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
                        
                        //Right Click the menu cell of the first bulletin and select Void
                        Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.MenuCell.Click(WinForms.MouseButtons.Right);
                        GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.VoidBulletinInfo,
                                                                  Bulletinsrepo.Bulletins_Input_Relay.Input.Warning_Form.YesButtonInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Warning_Form.YesButtonInfo,
                                                                          Bulletinsrepo.Bulletins_Input_Relay.Input.Warning_Form.SelfInfo);
                        
                        // If there is an error in voiding the authority, record it but move on to void the next authority in the list
                        if (Bulletinsrepo.Bulletins_Input_Relay.Feedback.GetAttributeValue<string>("Text") != "" && Bulletinsrepo.Bulletins_Input_Relay.Feedback.GetAttributeValue<string>("Text") != " ")
                        {
                            Ranorex.Report.Info("Failed to remove Bulletin with Reference Number {"+currentBulletinReferenceNumber+"}.");
                            int rowIndex = Convert.ToInt32(Bulletinsrepo.BulletinRowIndex);
                            rowIndex--;
                            Bulletinsrepo.BulletinRowIndex = rowIndex.ToString();
                        }
                        else {
                            retries = 0;
                            while (!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 2)
                            {
                                Ranorex.Delay.Milliseconds(750);
                            }
                            if (Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
                            {
                                Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButton.Click();
                            }
                            
                            Ranorex.Report.Info("Removed Bulletin with Reference Number {"+currentBulletinReferenceNumber+"}.");
                        }
                    }
                }
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo,
                                                                      Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
                }
                
            } else {
                Ranorex.Report.Error("Bulletin Input form could not be opened");
            }
            
            return;
        }
        
        /// <summary>
        /// Empties List Containing Bulletins
        /// </summary>
        private static void ClearBulletinDictionary()
        {
            bulletinDictionary.Clear();
        }

        /// <summary>
        /// Validates whether a given bulletin displays as active in the bulletin relay form
        /// </summary>
        /// <param name="bulletinSeed">Input: bulletinSeed. Key used to look up bulletin information to be validated.</param>
        /// <param name="validateIsActive">Input: validateIsActive. Bool. Determine whether validation success equates to bulletin being found, or not found.</param>
        /// <param name="closeForms">Input: closeForms. Bool. Determine whether or not to close bulletin relay form.</param>
        [UserCodeMethod]
        public static void NS_ValidateBulletinIsActive_BulletinInputRelayForm(string bulletinSeed, bool validateIsActive, bool closeForms)
        {
            string bulletinNumber = GetBulletinNumber(bulletinSeed);
            string bulletinType = GetBulletinType(bulletinSeed);

            string bulletinText = string.Format("<{0}>{1}", bulletinNumber, bulletinType);

            if (bulletinNumber == null)
            {
                Report.Error(string.Format("No bulletin is associated with the bulletin seed: '{0}'", bulletinSeed));
                return;
            }
            
            NS_OpenBulletinRelayForm_MainMenu();
            
            Bulletinsrepo.DistrictName = "All Controlled Districts";
            if (Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuItem.SelectedItemText != Bulletinsrepo.DistrictName)
            {
                Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuItem.Click();
                Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuList.DistrictListItemByDistrictName.Click();
            }

            // Arrange by All Active Bulletin Items
            // The click seldom takes on first attempt
            int clicks = 0;
            while (!Bulletinsrepo.Bulletins_Input_Relay.Relay.ArrangeBy.AllActiveBulletinItems.Checked && clicks < 3)
            {
                Bulletinsrepo.Bulletins_Input_Relay.Relay.ArrangeBy.AllActiveBulletinItems.Click();
                Delay.Milliseconds(100);
                clicks++;
            }

            // The program will need to iterate through all of these elements
            int numberOfBulletins = Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.Self.GetAttributeValue<int>("ChildCount");

            // It's extremely likely that there will be some small delay in population over the UI, so this is inserted to prevent a false failure.
            int retries = 0;
            while (numberOfBulletins == 0 && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                numberOfBulletins = Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.Self.GetAttributeValue<int>("ChildCount");
                retries++;
            }

            string bulletinRepoText;
            bool bulletinFound = false;
            for (int i = 0; i < numberOfBulletins; i++)
            {
                Bulletinsrepo.BulletinIndex = (i+1).ToString();
                if (Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.AllActiveBulletinItems.TreeItemByBulletinInfo.Exists(0))
                {
                    bulletinRepoText = Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.AllActiveBulletinItems.TreeItemByBulletin.GetAttributeValue<string>("Text");
                    if (bulletinRepoText.Equals(bulletinText, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Report.Info(string.Format("Bulletin information for bulletin number '{0}' found as follows: '{1}'", bulletinNumber, bulletinRepoText));
                        bulletinFound = true;
                        break;
                    }
                }
            }

            string feedbackMessage = string.Format(
                "Bulletin corresponding to bulletin seed '{0}' has expected active state: '{1}' and actual active state: '{2}'",
                bulletinSeed, validateIsActive.ToString(), bulletinFound.ToString()
               );

            if (validateIsActive == bulletinFound)
            {
                Report.Success("Validation", feedbackMessage);
            } else {
                Report.Failure("Validation", feedbackMessage);
            }

            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    Bulletinsrepo.Bulletins_Input_Relay.WindowControls.CloseInfo,
                    Bulletinsrepo.Bulletins_Input_Relay.SelfInfo
                   );
            }
        }
        
        /// <summary>
        /// Relays Bulletins to specific TrainId or if no trainSeed is given, relays all bulletins to all trains, opening bulletin relay form if necessary
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed if blank will relay all bulletins to all trains</param>
        /// <param name="closeBulletinRelayForm">Input:closeBulletinRelayForm if true, closes the form once bulletins are relayed</param>
        [UserCodeMethod]
        public static void NS_RelayBulletinsToTrain_BulletinInputRelayForm(string trainSeed, bool closeBulletinRelayForm = true)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            if (trainSeed != "" && trainId == null)
            {
                Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                return;
            }
            
            NS_OpenBulletinRelayForm_MainMenu();
            int innerRetry = 0;
            string currentMouseState = Mouse.Cursor.ToString();
            while (currentMouseState == "[Cursor: WaitCursor]" && innerRetry < 5)
            {
                Thread.Sleep(500);
                currentMouseState = Mouse.Cursor.ToString();
                innerRetry++;
            }
            
            //Select All Controlled Districts
            Bulletinsrepo.DistrictName = "All Controlled Districts";
            if (Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuItem.SelectedItemText != Bulletinsrepo.DistrictName) {
                Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuItem.Click();
                Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuList.DistrictListItemByDistrictName.Click();
            }
            
            //Arrange by Bulletin Items Need by Trains
            if (!Bulletinsrepo.Bulletins_Input_Relay.Relay.ArrangeBy.BulletinItemsNeededByTrainRadioButton.Checked)
            {
                Bulletinsrepo.Bulletins_Input_Relay.Relay.ArrangeBy.BulletinItemsNeededByTrainRadioButton.Click();
            }
            
            //If trainSeed is blank, Relay All dem Bulls to all dem Trains
            int numberOfBulletins = Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.Self.GetAttributeValue<int>("ChildCount");
            
            //Possibly pulled the information too fast
            int retries = 0;
            while (numberOfBulletins == 0 && retries < 10)
            {
                Ranorex.Delay.Milliseconds(500);
                numberOfBulletins = Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.Self.GetAttributeValue<int>("ChildCount");
                retries++;
            }
            
            //If there are no Bulletins, then they've all been relayed
            if (numberOfBulletins == 0)
            {
                Ranorex.Report.Info("No bulletins found in bulletin relay form");
            }
            
            if (trainSeed == "")
            {
                Ranorex.Report.Info("TestStep","Relaying all Bulletins needed by trains");
                //Iterates through each listed bulletin clicking the Ok Button for each train
                Bulletinsrepo.BulletinIndex = "1";
                for (int i = 0; i<numberOfBulletins; i++)
                {
                    Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinIndex.Self.Click();
                    int numberOfTrains = Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.Self.Rows.Count;
                    for (int j = 0; j < numberOfTrains; j++)
                    {
                        Bulletinsrepo.AddressLinesRowIndex = j.ToString();
                        while (!Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.AddressLinesRowByIndex.Self.Visible)
                        {
                            Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.VerticalScroll.Click(Location.LowerCenter);
                        }
                        Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.AddressLinesRowByIndex.OkTimeButton.Click();
                    }
                }
                
                retries = 0;
                while (Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinIndex.SelfInfo.Exists(0) && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }
                
                if (Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinIndex.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Failure("Unable to Relay all Bulletins");
                    return;
                } else {
                    Ranorex.Report.Success("All Bulletins relayed to all trains in all controlled districts");
                }
            } else {
                Bulletinsrepo.TrainID = trainId;
                for (int i = numberOfBulletins; i>0; i--)
                {
                    Bulletinsrepo.BulletinIndex = i.ToString();
                    if(!Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinIndex.TrainIDTreeItemByTrainIDInfo.Exists(0))
                    {
                        continue;
                    }
                    Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinIndex.Self.Click();
                    int scrollbarHeight = Convert.ToInt32(Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.VerticalScroll.GetAttributeValue<string>("Height"));
                    while (!Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.AddressLinesRowByTrainID.Self.Visible)
                    {
                        Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.VerticalScroll.Click(Location.LowerCenter);
                    }
                    Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.AddressLinesRowByTrainID.OkTimeButton.Click();
                }
                
                retries = 0;
                while (Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByContainingTrainId.SelfInfo.Exists(0) && retries < 3)
                {
                    Ranorex.Delay.Seconds(1);
                    retries++;
                }
                if (Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByContainingTrainId.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Failure("Unable to Relay all Bulletins for train {"+trainId+"}");
                } else {
                    Ranorex.Report.Success("All Bulletins relayed to train {"+trainId+"} in all controlled districts");
                }
            }
            
            if (closeBulletinRelayForm)
            {
                retries = 0;
                Ranorex.Report.Info("Closing Bulletin Relay Form");
                Bulletinsrepo.Bulletins_Input_Relay.OkButton.Click();
                while (Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0) && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }
                if (Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
                {
                    Bulletinsrepo.Bulletins_Input_Relay.OkButton.Click();
                }
                while (Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0) && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }
                if (Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Error("Unable to close Bulletin Relay Form");
                }
            }
            return;
        }
        
        /// <summary>
        /// Complete Granting or Denying a Bulletin recived via RUM
        /// </summary>
        /// <param name="grantBulletin">Input:True to grant the bulletin, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        [UserCodeMethod]
        public static void NS_GrantOrDenyRUMBulletin_BulletinInputRelayForm(bool grantBulletin, string bulletinSeed, bool clickRefresh, bool closeForms, string inputComments, string expectedFeedback)
        {
            int retries = 0;
            Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
            if (grantBulletin)
            {
                Ranorex.Report.Info("Granting Bulletin");
                if(!string.IsNullOrEmpty(inputComments))
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.CommentsButtonInfo,
                                                              Bulletinsrepo.Bulletins_Input_Relay.Input.Enter_Comments.SelfInfo);
                    
                    Bulletinsrepo.Bulletins_Input_Relay.Input.Enter_Comments.CommentText.Element.SetAttributeValue("Text", inputComments);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Enter_Comments.OkButtonInfo,
                                                                      Bulletinsrepo.Bulletins_Input_Relay.Input.Enter_Comments.SelfInfo);
                    
                }
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.OkButtonInfo, Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
                string bulletinIdFeatureStatus = CDMSEnvironment.GetCommonConfigValue_CDMS("RST_BULLETIN_ID_FEATURE_ENABLE");
                string remedyBulletinUniqueIdStatus = CDMSEnvironment.GetCommonConfigValue_CDMS("RST_REMEDY_UNIQUE_ID_CONFIG");
                if(bulletinIdFeatureStatus == "1" || bulletinIdFeatureStatus == "2" || remedyBulletinUniqueIdStatus == "1" || remedyBulletinUniqueIdStatus == "2")
                {
                    AddBulletinId(bulletinSeed);
                }
                
                if (Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
                {
                    if (!CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
                    {
                        Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.DoubleClick();
                        return;
                    }
                }
                else
                {
                    Ranorex.Report.Info("Request has been Granted");
                }
            }
            else
            {
                if (inputComments != "")
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.CommentsButtonInfo,
                                                              Bulletinsrepo.Bulletins_Input_Relay.Input.Enter_Comments.SelfInfo);
                    Bulletinsrepo.Bulletins_Input_Relay.Input.Enter_Comments.CommentText.Element.SetAttributeValue("Text", inputComments);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Enter_Comments.OkButtonInfo,
                                                                      Bulletinsrepo.Bulletins_Input_Relay.Input.Enter_Comments.SelfInfo);
                    
                }
                
                Ranorex.Report.Info("Denying Bulletin");
                Bulletinsrepo.Bulletins_Input_Relay.CancelButton.Click();
                if(Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
                {
                    while(Bulletinsrepo.Bulletins_Input_Relay.Feedback.GetAttributeValue<string>("Text").Equals("") && retries < 5)
                    {
                        Delay.Milliseconds(500);
                        retries++;
                    }

                    if (!CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
                    {
                        if (clickRefresh)
                        {
                            Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
                        }
                        if (closeForms && Miscellaneousrepo.Task_List.SelfInfo.Exists(0))
                        {
                            Ranorex.Report.Info("Closing Task List Form");
                            Miscellaneousrepo.Task_List.CloseButton.Click();
                        }
                        return;
                    }
                    
                    if (expectedFeedback != "")
                    {
                        Ranorex.Report.Failure("Expected feedback of {" + expectedFeedback + "} but received no feedback");
                    }
                }
                
            }
            if (closeForms && Miscellaneousrepo.Task_List.SelfInfo.Exists(0))
            {
                Ranorex.Report.Info("Closing Task List Form");
                Miscellaneousrepo.Task_List.CloseButton.Click();
            }
            return;
        }
        
        
        /// <summary>
        /// Closing a BulletinForm
        /// </summary>
        [UserCodeMethod]
        public static void NS_CloseBulletinForm()
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry (
                Bulletinsrepo.Bulletins_Input_Relay.SelfInfo,
                Bulletinsrepo.Bulletins_Input_Relay.OkButtonInfo
               );
            Bulletinsrepo.Bulletins_Input_Relay.OkButton.Click();
            //Check if form is closed or not
            if (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
            {
                Ranorex.Report.Info("Form is Closed");
            }
            else
            {
                Ranorex.Report.Error("Failed to Close Bulletin Form");
            }
        }
        
        /// <summary>
        /// Corrupts a Bulletin
        /// </summary>
        /// <param name="labelName">Input:Current label for the machine running the test</param>
        /// <param name="bulletinSeed">Input:Either the seed of the bulletin or the value intended to be the bulletin number</param>
        [UserCodeMethod]
        public static void CorruptBulletin_NS(string labelName, string bulletinSeed)
        {
            string bulletinNumber = "";
            NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
            if (bulletinObject != null)
            {
                bulletinNumber = bulletinObject.bulletinNumber;
            } else {
                bulletinNumber = bulletinSeed;
            }
            Env.Code_Utils.VMEnvironment vm = Env.Code_Utils.VMEnvironment.Instance();
            string cacheBulletinCorruptor = Env.Code_Utils.LinuxUtils.corruptBulletin(vm, labelName, bulletinNumber).Replace("\n", " ");

            
            
            Ranorex.Report.Info("Bulletin Corruptor returned with output {"+cacheBulletinCorruptor+"}.");
            return;
        }
        
        /// <summary>
        /// Waits for Bulletin to disappear from the trackline
        /// </summary>
        /// <param name="bulletinSeed">Input:Either the seed of the bulletin or the value intended to be the bulletin number</param>
        /// <param name="maxWaitMinutes">Input:Maximum wait time in minutes</param>
        [UserCodeMethod]
        public static void WaitForBulletinToBeRemoved_NS(string bulletinSeed, int maxWaitMinutes)
        {
            NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
            if (bulletinObject != null)
            {
                Tracklinerepo.BulletinNumber = bulletinObject.bulletinNumber;
            } else {
                Tracklinerepo.BulletinNumber = bulletinSeed;
            }
            Report.Info("Bulletin "+ Tracklinerepo.BulletinNumber+ " Exists:"+Tracklinerepo.Trackline_Form.BulletinObjectInfo.Exists(0));
            Ranorex.Report.Info("Waiting for Bulletin {"+Tracklinerepo.BulletinNumber+"} to disappear within "+maxWaitMinutes.ToString()+" minutes.");
            
            System.DateTime timeoutTime = System.DateTime.Now.AddMinutes(maxWaitMinutes);
            while (Tracklinerepo.Trackline_Form.BulletinObjectInfo.Exists(0) && timeoutTime > System.DateTime.Now)
            {
                Ranorex.Delay.Seconds(1);
            }
            
            if (Tracklinerepo.Trackline_Form.BulletinObjectInfo.Exists(0))
            {
                Ranorex.Report.Error("Bulletin with Bulletin Number {"+Tracklinerepo.BulletinNumber+"} failed to be removed within "+maxWaitMinutes.ToString()+" minutes.");
            	return;
            }
            Report.Success("Bulletin Successfully removed.");
        }
        
        /// <summary>
        /// Waits for Bulletin to appear on the trackline
        /// </summary>
        /// <param name="bulletinSeed">Input:Either the seed of the bulletin or the value intended to be the bulletin number</param>
        /// <param name="maxWaitMinutes">Input:Maximum wait time in minutes</param>
        [UserCodeMethod]
        public static void WaitForBulletinToAppear_NS(string bulletinSeed, int maxWaitMinutes)
        {
            NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
            if (bulletinObject != null)
            {
                Tracklinerepo.BulletinNumber = bulletinObject.bulletinNumber;
            } else {
                Tracklinerepo.BulletinNumber = bulletinSeed;
            }
            
            Ranorex.Report.Info("Waiting for Bulletin {"+Tracklinerepo.BulletinNumber+"} to appear within "+maxWaitMinutes.ToString()+" minutes.");
            
            System.DateTime timeoutTime = System.DateTime.Now.AddMinutes(maxWaitMinutes);
            while (!Tracklinerepo.Trackline_Form.BulletinObjectInfo.Exists(0) && timeoutTime > System.DateTime.Now)
            {
                Ranorex.Delay.Seconds(1);
            }
            
            if (!Tracklinerepo.Trackline_Form.BulletinObjectInfo.Exists(0))
            {
                Ranorex.Report.Error("Bulletin with Bulletin Number {"+Tracklinerepo.BulletinNumber+"} failed to appear within "+maxWaitMinutes.ToString()+" minutes.");
            }
            
            return;
        }
        
        /// <summary>
        /// Validates Bulletin is not on the trackline
        /// </summary>
        /// <param name="bulletinSeed">Input:Either the seed of the bulletin or the value intended to be the bulletin number</param>
        [UserCodeMethod]
        public static void NS_ValidateBulletinNotPresent_Trackline(string bulletinSeed)
        {
            NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
            if (bulletinObject != null)
            {
                Tracklinerepo.BulletinNumber = bulletinObject.bulletinNumber;
            } else {
                Tracklinerepo.BulletinNumber = bulletinSeed;
            }
            
            if (Tracklinerepo.Trackline_Form.BulletinObjectInfo.Exists(0))
            {
                Ranorex.Report.Failure("Bulletin with Bulletin Number {"+Tracklinerepo.BulletinNumber+"} exists on trackline.");
            } else {
                Ranorex.Report.Success("Bulletin with Bulletin Number {"+Tracklinerepo.BulletinNumber+"} does not exist on trackline.");
            }
            
            return;
        }
        
        
        /// <summary>
        /// Validates color of the bulletin text
        /// </summary>
        /// <param name="bulletinSeed">Input - bulletin seed </param>
        /// <param name="expBulletinIsPresent">Input - True / False</param>
        [UserCodeMethod]
        public static void NS_ValidateBulletinPresent_Trackline(string bulletinSeed, bool expBulletinIsPresent)
        {
            NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
            if (bulletinObject != null)
            {
                Tracklinerepo.BulletinNumber = bulletinObject.bulletinNumber;
            } else {
                Tracklinerepo.BulletinNumber = bulletinSeed;
            }
            
            bool actBulletinIsPresent = Tracklinerepo.Trackline_Form.BulletinObjectInfo.Exists(0);
            if(actBulletinIsPresent == expBulletinIsPresent)
            {
                Ranorex.Report.Success("Presence of Bulletin on Trackline expected to be{"+expBulletinIsPresent+"} and found{"+actBulletinIsPresent+"}.");
            }
            else
            {
                Ranorex.Report.Failure("Presence of Bulletin on Trackline expected to be{"+expBulletinIsPresent+"} but found{"+actBulletinIsPresent+"}.");
            }
        }
        
        /// <summary>
        /// Closes the Bulletin Input/Relay Form
        /// </summary>
        public static void CloseBulletinItemsForm_NS()
        {
            if (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
            {
                Ranorex.Report.Warn("Bulletin Form is not open, so it cannot be closed");
                return;
            }
            //Bulletin Form had to have Ensure Visible turned off in the repo in order to work so we need to activate it specifically
            Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
            
            //If it's the Input form, then we should refresh to clear any variables first to avoid a popup.
            if (Bulletinsrepo.Bulletins_Input_Relay.BulletinTabs.InputTab.Selected)
            {
                Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
            }
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo, Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
            return;
        }
        
        /// <summary>
        /// Closes the Bulletin Summary List
        /// </summary>
        public static void CloseBulletinSummaryListForm_NS()
        {
            if (!Bulletinsrepo.Bulletin_Summary_List.SelfInfo.Exists(0))
            {
                Ranorex.Report.Warn("Bulletin Summary List is not open, so it cannot be closed");
                return;
            }
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_List.WindowControls.CloseInfo, Bulletinsrepo.Bulletin_Summary_List.SelfInfo);
            return;
        }
        
        
        /// <summary>
        /// Click Continue Button in Relay Bulletin Popup
        /// </summary>
        [UserCodeMethod]
        public static void ClickContinueBulletinRelayPopup()
        {
            int retries = 0;
            
            while (!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Relay_Bulletin_Popup.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            
            Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Relay_Bulletin_Popup.ContinueButton.Click();
            retries = 0;
            
            while (Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Relay_Bulletin_Popup.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            
            
            if(!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Relay_Bulletin_Popup.SelfInfo.Exists(0))
            {
                Ranorex.Report.Info("Successfully Click Continue Button");
            } else{
                Ranorex.Report.Error("Unable to Click Continue Button in Relay Bulletin Popup");
            }
            
            
        }
        
        /// <summary>
        /// Validates if the bulletin type is displayed or not in the Input Form
        /// </summary>
        /// <param name="bulletinName">Bulletin Name to be validated</param>
        /// <param name="isDisplayed">TRUE if Bulletin Name is present and False if not present</param>
        [UserCodeMethod]
        public static void NS_ValidateBulletinTypeExistsInInputForm(string bulletinName, bool isDisplayed)
        {
            Bulletinsrepo.BulletinTypeName = bulletinName;
            NS_OpenBulletinInputForm_MainMenu();
            
            if(Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
            {
                Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuItem.Click();
                if(Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuList.TypeListItemByBulletinTypeNameInfo.Exists(0) && isDisplayed)
                {
                    Ranorex.Report.Success("Bulletin Type is Present in the Dropdown list");
                    Bulletinsrepo.Bulletins_Input_Relay.WindowControls.Close.Click();
                } else if(!Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuList.TypeListItemByBulletinTypeNameInfo.Exists(0) && !isDisplayed)
                {
                    Ranorex.Report.Success("Bulletin Type is not Present in the Dropdown list");
                    Bulletinsrepo.Bulletins_Input_Relay.WindowControls.Close.Click();
                } else if(Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuList.TypeListItemByBulletinTypeNameInfo.Exists(0) && !isDisplayed)
                {
                    Ranorex.Report.Failure("Bulletin Type is Present in the Dropdown list even when it should not be");
                    Bulletinsrepo.Bulletins_Input_Relay.WindowControls.Close.Click();
                } else
                {
                    Ranorex.Report.Failure("Bulletin Type is not present in the Dropdown list even when it should be");
                    Bulletinsrepo.Bulletins_Input_Relay.WindowControls.Close.Click();
                }
            } else {
                Ranorex.Report.Failure("Bulletin Input form is not open");
            }
        }

        public static string NS_FormatDateTime_Bulletin(System.DateTime inputDateTime, string inputTimeZone, string inputStringOffset)
        {
            return NS_Time.FormatDateTime(
                inputDateTime: inputDateTime,
                inputTimeZone: inputTimeZone,
                inputStringOffset: inputStringOffset,
                allowEmptyString: true,
                outputTimeFormat: NS_Time.GetPDSTimeFormat()
               );
        }
        
        /// <summary>
        /// Validates that certain filters are not found when querying the cache refresh
        /// Gets the contents of the cache refresh from the server, removes new lines, and compares against filters
        /// </summary>
        /// <param name="labelName">Name of Server label being run</param>
        /// <param name="district">District for the cache refresh information</param>
        /// <param name="division">division for the district. i.e. Georgia = div1</param>
        /// <param name="messageType">DG, DC, etc..</param>
        /// <param name="bulletinSeed">Seed of Bulletin you want ot Verify</param>
        /// <param name="extraFilters">Filters beyond bulletin number and bulletin type</param>
        [UserCodeMethod]
        public static void NS_ValidateBulletinExistInCacheRefresh(string labelName, string district, string division, string messageType, string bulletinSeed, string extraFilters)
        {
            string filters = "<BULLETIN_ITEM_NUMBER>"+GetBulletinNumber(bulletinSeed)+@"</BULLETIN_ITEM_NUMBER>";
            filters = filters + "<BULLETIN_ITEM_TYPE>"+GetBulletinType(bulletinSeed)+@"</BULLETIN_ITEM_TYPE>";
            filters = filters +"|"+extraFilters;
            STE.Code_Utils.messages.CacheRefresh.ValidateMessageInCacheRefreshFunction_NS(labelName, district, division, messageType, filters);
            return;
        }
        /// <summary>
        /// Closes the Bulletin Input Relay Form
        /// </summary>
        [UserCodeMethod]
        public static void NS_CloseBulletinItemRelayFormAndValidate_BulletinItemRelay()
        {
            if (Bulletinsrepo.Bulletin_Item_Relay.SelfInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Item_Relay.CloseButtonInfo, Bulletinsrepo.Bulletin_Item_Relay.SelfInfo);
                Ranorex.Report.Success("Bulletin Item Relay Form is closed successfully");
            }
            else
            {
                Ranorex.Report.Failure("Bulletin Item Relay Form is not opened ");
            }
            return;
            
        }

        /// <summary>
        /// Relay the Bulletin for an Authority
        /// </summary>
        /// <param name="bulletinSeed">bulletin seed which needs to pass</param>
        /// <param name="closeForm">True to close the Bulletin Relay form, else False</param>
        [UserCodeMethod]
        public static void NS_RelayBulletinToAuthority_BulletinItemRelay(string bulletinSeed, bool closeForm=true)
        {
            int retries = 0;
            string bulletinNumber = GetBulletinNumber(bulletinSeed);
            if(!String.IsNullOrEmpty(bulletinNumber))
            {
                Bulletinsrepo.BulletinNumber = bulletinNumber.ToString();
            }
            
            while(!Bulletinsrepo.Bulletin_Item_Relay.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            retries = 0;
            if(Bulletinsrepo.Bulletin_Item_Relay.SelfInfo.Exists(0))
            {
                if(Bulletinsrepo.Bulletin_Item_Relay.BulletinTable.BulletinItemByBulletinNumber.SelfInfo.Exists(0))
                {
                    Bulletinsrepo.Bulletin_Item_Relay.BulletinTable.BulletinItemByBulletinNumber.MenuCell.Click();
                    
                    while(!Bulletinsrepo.Bulletin_Item_Relay.Details.SystemReferenceNumber.GetAttributeValue<string>("Text").Equals(bulletinNumber) && retries < 3)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }
                    
                    if(Bulletinsrepo.Bulletin_Item_Relay.Details.SystemReferenceNumber.GetAttributeValue<string>("Text").Equals(bulletinNumber))
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Item_Relay.AddressTable.AddressLinesRowByIndex.TCNumberInfo,
                                                                          Bulletinsrepo.Bulletin_Item_Relay.AddressTable.AddressLinesRowByIndex.TCNumberInfo);
                    }
                    else
                    {
                        Ranorex.Report.Screenshot(Bulletinsrepo.Bulletin_Item_Relay.Self);
                        Ranorex.Report.Failure("System took more time to load bulleitn information or the information does not exist");
                    }
                }
                else
                {
                    Ranorex.Report.Screenshot(Bulletinsrepo.Bulletin_Item_Relay.Self);
                    Ranorex.Report.Failure("Unable to find Bulletin with Bulletin Number: "+bulletinNumber+" in Relay form");
                }
            }
            else
            {
                Ranorex.Report.Failure("Unable to find bulletin relay form to relay Authority");
                return;
            }
            
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Item_Relay.CloseButtonInfo,
                                                                  Bulletinsrepo.Bulletin_Item_Relay.SelfInfo);
            }
            return;
        }
        

       /// <summary>
		/// Close the Relay Bulletin form if it exist, else throw failure
		/// </summary>
		[UserCodeMethod]
		public static void NS_CloseBulletinInputRelayForm()
		{
			if (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
			{
				Ranorex.Report.Warn("Bulletin Form is not open, so it cannot be closed");
				return;
			}
			
			else
			{
				GeneralUtilities.ClickAndWaitForDisabledWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButtonInfo,
				                                                  Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButtonInfo);
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo,
				                                                  Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
				Ranorex.Report.Info("Bulletin Form is closed");
				
			}
		}

        
        /// <summary>
        /// Relay a specific bulletin to a train
        /// </summary>
        /// <param name="trainSeed">Trainseed of train to which bulletin to be relayed</param>
        /// <param name="bulletinSeed">Bulletinseed of bulletin which needs to be relayed</param>
        /// <param name="closeBulletinRelayForm">TRUE to close the bulletin relay form, else FALSE to keep it open</param>
        [UserCodeMethod]
        public static void NS_RelayBulletinToTrain_BulletinInputRelayForm(string trainSeed, string bulletinSeed, bool closeBulletinRelayForm = true)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            string bulletinNumber = GetBulletinNumber(bulletinSeed);
            if (trainSeed != "" && trainId == null)
            {
                Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                return;
            }
            
            if(bulletinSeed != "" && bulletinNumber == null)
            {
                Ranorex.Report.Failure("No Bulletin found for bulletinSeed {"+bulletinSeed+"}, ensure correct bulletinSeed and that bulletin was issued");
                return;
            }
            
            Bulletinsrepo.BulletinNumber = bulletinNumber;
            Bulletinsrepo.TrainID = trainId;
            
            NS_OpenBulletinRelayForm_MainMenu();
            int innerRetry = 0;
            string currentMouseState = Mouse.Cursor.ToString();
            while (currentMouseState == "[Cursor: WaitCursor]" && innerRetry < 5)
            {
                Thread.Sleep(500);
                currentMouseState = Mouse.Cursor.ToString();
                innerRetry++;
            }
            
            //Select All Controlled Districts
            Bulletinsrepo.DistrictName = "All Controlled Districts";
            if (Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuItem.SelectedItemText != Bulletinsrepo.DistrictName) {
                GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuItemInfo,
                                                          Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuList.DistrictListItemByDistrictNameInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuList.DistrictListItemByDistrictNameInfo,
                                                                  Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuList.SelfInfo);
            }
            
            //Arrange by Bulletin Items Need by Trains
            if (!Bulletinsrepo.Bulletins_Input_Relay.Relay.ArrangeBy.BulletinItemsNeededByTrainRadioButton.Checked)
            {
                Bulletinsrepo.Bulletins_Input_Relay.Relay.ArrangeBy.BulletinItemsNeededByTrainRadioButton.Click();
            }
            
            //If trainSeed is blank, Relay All dem Bulls to all dem Trains
            int numberOfBulletins = Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.Self.GetAttributeValue<int>("ChildCount");
            
            //Possibly pulled the information too fast
            int retries = 0;
            while (numberOfBulletins == 0 && retries < 10)
            {
                Ranorex.Delay.Milliseconds(500);
                numberOfBulletins = Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.Self.GetAttributeValue<int>("ChildCount");
                retries++;
            }
            
            //If there are no Bulletins, then they've all been relayed
            if (numberOfBulletins == 0)
            {
                Ranorex.Report.Failure("Bulletin: "+bulletinNumber+ " not available to Relay for Train: "+trainId);
            }
            
            if(Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinNumber.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinNumber.SelfInfo,
                                                          Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.SelfInfo);
                
                if(Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.AddressLinesRowByTrainID.SelfInfo.Exists(0))
                {
                    Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.AddressLinesRowByTrainID.Self.Click();
                    Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.AddressLinesRowByTrainID.OkTimeButton.Click();
                }
                else
                {
                    Ranorex.Report.Failure("Train with TrainId: "+trainId+ " not found under the Bulletin");
                }
            }
            else
            {
                Ranorex.Report.Failure("Bulletin with Bulletin Number: "+bulletinNumber+ " not found");
            }
            
            if (closeBulletinRelayForm)
            {
                Ranorex.Report.Info("Closing Bulletin Relay Form");
                
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo,
                                                                  Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
                if (Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Error("Unable to close Bulletin Relay Form");
                }
            }
            return;
        }
        
        /// <summary>
        /// Open Bulletin From Bulletin Summary List using the Bulletins Bulletin Number
        /// </summary>
        /// <param name="bulletinSeed">Input:Bulletin Seed of Bulletin to  open</param>
        /// <param name="closeBulletinInputForm">Input:Closes the Bulletin Summary List if true</param>
        [UserCodeMethod]
        public static void NS_OpenBulletin_BulletinSummaryList(string bulletinSeed, bool closeBulletinSummaryList = true)
        {
        	NS_OpenBulletinSummaryList_MainMenu();
        	
        	//If Bulletin seed doesn't exist assume the seed is the bulletin number
        	string targetBulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
        	if (targetBulletinNumber == null)
        	{
        		targetBulletinNumber = bulletinSeed;
        	}
        	int retries=0;
        	Bulletinsrepo.BulletinNumber = targetBulletinNumber;
        	
        	while (!Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByBulletinNumber.SelfInfo.Exists(0) && retries<5)
        	{
        		Delay.Milliseconds(500);
        		retries++;
        	}
        	if(!Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByBulletinNumber.SelfInfo.Exists(0))
        	{
        		Report.Screenshot(Bulletinsrepo.Bulletin_Summary_List.Self.Element);
        		Ranorex.Report.Error("Bulletin with Bulletin Number {"+targetBulletinNumber+"} was not found in Bulletin Summary List");
        		if (closeBulletinSummaryList)
        		{
        			CloseBulletinSummaryListForm_NS();
        		}
        		return;
        	}
        	
        	Bulletinsrepo.RowIndex = Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByBulletinNumber.CellByColumnName.BulletinNumber.GetAttributeValue<int>("Index").ToString();
        	Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByRowIndex.MenuCell.Click(WinForms.MouseButtons.Right);
        	GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.MenuCellMenu.OpenBulletinInfo, Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
        	if (closeBulletinSummaryList)
        	{
        		CloseBulletinSummaryListForm_NS();
        	}
        	
        }
        
        /// <summary>
        /// Validate if the color is present on the bulletin in Bulletin relay form
        /// </summary>
        /// <param name="bulletinSeed">bulletinSeed of bulletin in which need to validate color present</param>
        /// <param name="color">Color string to validate if present, e.g. Red, Yellow etc</param>
        /// <param name="closeBulletinRelayForm">True to close the form, else False</param>
        [UserCodeMethod]
        public static void NS_ValidateBulletinColor_BulletinInputRelayForm(string bulletinSeed, string color, bool closeBulletinRelayForm = true)
        {
            string bulletinNumber = GetBulletinNumber(bulletinSeed);
            
            if(NS_ValidateBulletinExist_BulletinRelayForm(bulletinSeed))
            {
                GeneralUtilities.ValidateColorForAnyAdapterByPixel_EnsureVisible(Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinNumber.Self, color, true, false);
            }
            else
            {
                Ranorex.Report.Screenshot(Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.Self);
                Ranorex.Report.Failure("Bulletin with Bulletin Number: "+bulletinNumber+ " not found");
            }
            
            if (closeBulletinRelayForm)
            {
                Ranorex.Report.Info("Closing Bulletin Relay Form");
                
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo,
                                                                  Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
                if (Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Error("Unable to close Bulletin Relay Form");
                }
            }
            return;
        }
        
        /// <summary>
        /// Validate if the color is present on the train in Bulletin relay form
        /// </summary>
        /// <param name="trainSeed">Trainseed of train in which need to validate color present</param>
        /// <param name="color">Color string to validate if present, e.g. Red, Yellow etc</param>
        /// <param name="closeBulletinRelayForm">True to close the form, else False</param>
        [UserCodeMethod]
        public static void NS_Validate_Train_Color_RelayForm(string trainSeed, string color, bool closeBulletinRelayForm = true)
        {
            string trainId = NS_TrainID.GetTrainId(trainSeed);
            
            if(trainSeed != "" && trainId == null)
            {
                Ranorex.Report.Failure("No train found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was issued");
                return;
            }
            
            Bulletinsrepo.TrainID = trainId;
            
            if(NS_ValidateTrainExist_BulletinRelayForm(trainSeed))
            {
                GeneralUtilities.ValidateColorForAnyAdapterByPixel_EnsureVisible(Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.TrainsThatNeedBulletinItems.TreeItemByTrainID.Self, color, true, false);
            }
            else
            {
                Ranorex.Report.Failure("Train with Train Number: "+trainId+ " not found");
            }
            
            if (closeBulletinRelayForm)
            {
                Ranorex.Report.Info("Closing Bulletin Relay Form");
                
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo,
                                                                  Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
                if (Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Error("Unable to close Bulletin Relay Form");
                }
            }
            return;
        }
        
        /// <summary>
        /// This user code validates if a bulletin exists in bulletin relay form
        /// </summary>
        /// <param name="bulletinSeed">bulletinSeed of bulletin to validate</param>
        /// <param name="bulletinExist">True if bulletin needs to be present, else false</param>
        /// <param name="closeBulletinRelayForm">True to close the form, else false</param>
        [UserCodeMethod]
        public static void NS_ValidateBulletinExists_BulletinInputRelayForm(string bulletinSeed,bool bulletinExist, bool closeBulletinRelayForm = true)
        {
            string bulletinNumber = GetBulletinNumber(bulletinSeed);
            
            bool resultFound = NS_ValidateBulletinExist_BulletinRelayForm(bulletinSeed);
            int numberOfBulletins = Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.Self.GetAttributeValue<int>("ChildCount");
            if (numberOfBulletins == 0 && resultFound)
            {
                Ranorex.Report.Screenshot(Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.Self);
                Ranorex.Report.Failure("Bulletin: "+bulletinNumber+ " not available");
            }
            else if(numberOfBulletins == 0 && !resultFound)
            {
                Ranorex.Report.Success("Bulletin: "+bulletinNumber+ " not available");
            }
            
            if(Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinNumber.SelfInfo.Exists(0) == bulletinExist)
            {
                Ranorex.Report.Success("Bulletin: "+bulletinNumber+" in Relay form exist, expected value:"+bulletinExist+" actual result:" +resultFound);
            }
            else
            {
                Ranorex.Report.Screenshot(Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.Self);
                Ranorex.Report.Failure("Bulletin with Bulletin Number: "+bulletinNumber+ " does not match bulletin exist criteria");
            }
            
            if (closeBulletinRelayForm)
            {
                Ranorex.Report.Info("Closing Bulletin Relay Form");
                
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo,
                                                                  Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
                if (Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Error("Unable to close Bulletin Relay Form");
                }
            }
            return;
        }
        
        /// <summary>
        /// Validate if the color is not present on the bulletin in Bulletin relay form
        /// </summary>
        /// <param name="bulletinSeed">Bulletinseed of bulletin in which need to validate color present</param>
        /// <param name="color">Color string to validate if present, e.g. Red, Yellow etc</param>
        /// <param name="closeBulletinRelayForm">True to close the form, else False</param>
        [UserCodeMethod]
        public static void NS_Validate_ColorNotExistOnBulletin_RelayForm(string bulletinSeed,string color, bool closeBulletinRelayForm = true)
        {
            string bulletinNumber = GetBulletinNumber(bulletinSeed);
            
            if(NS_ValidateBulletinExist_BulletinRelayForm(bulletinSeed))
            {
                GeneralUtilities.ValidateColorNotOnObject(Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinNumber.Self, color);
            }
            else
            {
                Ranorex.Report.Failure("Bulletin with Bulletin Number: "+bulletinNumber+ " does not exist in Relay Form");
            }
            
            if (closeBulletinRelayForm)
            {
                Ranorex.Report.Info("Closing Bulletin Relay Form");
                
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo,
                                                                  Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
                if (Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Error("Unable to close Bulletin Relay Form");
                }
            }
            return;
        }
        
        /// <summary>
        /// Validate if the color is present on the train in Bulletin relay form
        /// </summary>
        /// <param name="trainSeed">Trainseed of train in which need to validate color present</param>
        /// <param name="color">Color string to validate if present, e.g. Red, Yellow etc</param>
        /// <param name="closeBulletinRelayForm">True to close the form, else False</param>
        [UserCodeMethod]
        public static void NS_Validate_ColorNotOnTrain_RelayForm(string trainSeed, string color, bool closeBulletinRelayForm = true)
        {
            string trainId = NS_TrainID.GetTrainId(trainSeed);
            
            if(trainSeed != "" && trainId == null)
            {
                Ranorex.Report.Failure("No train found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was issued");
                return;
            }
            
            Bulletinsrepo.TrainID = trainId;
            
            if(NS_ValidateTrainExist_BulletinRelayForm(trainSeed))
            {
                GeneralUtilities.ValidateColorNotOnObject(Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.TrainsThatNeedBulletinItems.TreeItemByTrainID.Self, color);
            }
            else
            {
                Ranorex.Report.Failure("Train with Train Number: "+trainId+ " not found");
            }
            
            if (closeBulletinRelayForm)
            {
                Ranorex.Report.Info("Closing Bulletin Relay Form");
                
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo,
                                                                  Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
                if (Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Error("Unable to close Bulletin Relay Form");
                }
            }
            return;
        }
        
        /// <summary>
        /// This method validates if a train exists in Relay Form, sends true if exists else false.
        /// </summary>
        /// <param name="trainSeed">Trainseed of train which needs to be validated</param>
        /// <returns></returns>
        [UserCodeMethod]
        public static bool NS_ValidateTrainExist_BulletinRelayForm(string trainSeed)
        {
            string trainId = NS_TrainID.GetTrainId(trainSeed);
            
            if(trainSeed != "" && trainId == null)
            {
                Ranorex.Report.Failure("No train found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was issued");
                return false;
            }
            
            Bulletinsrepo.TrainID = trainId;
            
            NS_OpenBulletinRelayForm_MainMenu();
            int innerRetry = 0;
            string currentMouseState = Mouse.Cursor.ToString();
            while (currentMouseState == "[Cursor: WaitCursor]" && innerRetry < 5)
            {
                Thread.Sleep(500);
                currentMouseState = Mouse.Cursor.ToString();
                innerRetry++;
            }
            
            //Select All Controlled Districts
            Bulletinsrepo.DistrictName = "All Controlled Districts";
            if (Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuItem.SelectedItemText != Bulletinsrepo.DistrictName) {
                GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuItemInfo,
                                                          Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuList.DistrictListItemByDistrictNameInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuList.DistrictListItemByDistrictNameInfo,
                                                                  Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuList.SelfInfo);
            }
            
            //Arrange by Bulletin Items Need by Trains
            if (!Bulletinsrepo.Bulletins_Input_Relay.Relay.ArrangeBy.TrainsThatNeedBulletinItemsRadioButton.Checked)
            {
                Bulletinsrepo.Bulletins_Input_Relay.Relay.ArrangeBy.TrainsThatNeedBulletinItemsRadioButton.Click();
                
            }
            
            //If trainSeed is blank, Relay All dem Bulls to all dem Trains
            int numberOfTrains = Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.Self.GetAttributeValue<int>("ChildCount");
            
            //Possibly pulled the information too fast
            int retries = 0;
            while (numberOfTrains == 0 && retries < 10)
            {
                Ranorex.Delay.Milliseconds(500);
                numberOfTrains = Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.Self.GetAttributeValue<int>("ChildCount");
                retries++;
            }
            
            //If there are no Bulletins, then they've all been relayed
            if (numberOfTrains == 0)
            {
                Ranorex.Report.Screenshot(Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.Self);
                Ranorex.Report.Info("Train: "+trainId+ " not available");
            }
            
            
            if(Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.TrainsThatNeedBulletinItems.TreeItemByTrainID.SelfInfo.Exists(0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// This method validates if a bulletin exists in Bulletin Relay form, returns true if exist, else false
        /// </summary>
        /// <param name="bulletinSeed">BulletinSeed of the bulletin to validate</param>
        /// <returns></returns>
        [UserCodeMethod]
        public static bool NS_ValidateBulletinExist_BulletinRelayForm(string bulletinSeed)
        {
            string bulletinNumber = GetBulletinNumber(bulletinSeed);
            
            if(bulletinSeed != "" && bulletinNumber == null)
            {
                Ranorex.Report.Failure("No Bulletin found for bulletinSeed {"+bulletinSeed+"}, ensure correct bulletinSeed and that bulletin was issued");
                return false;
            }
            
            Bulletinsrepo.BulletinNumber = bulletinNumber;
            
            NS_OpenBulletinRelayForm_MainMenu();
            int innerRetry = 0;
            string currentMouseState = Mouse.Cursor.ToString();
            while (currentMouseState == "[Cursor: WaitCursor]" && innerRetry < 5)
            {
                Thread.Sleep(500);
                currentMouseState = Mouse.Cursor.ToString();
                innerRetry++;
            }
            
            //Select All Controlled Districts
            Bulletinsrepo.DistrictName = "All Controlled Districts";
            if (Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuItem.SelectedItemText != Bulletinsrepo.DistrictName) {
                GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuItemInfo,
                                                          Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuList.DistrictListItemByDistrictNameInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuList.DistrictListItemByDistrictNameInfo,
                                                                  Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuList.SelfInfo);
            }
            
            //Arrange by Bulletin Items Need by Trains
            if (!Bulletinsrepo.Bulletins_Input_Relay.Relay.ArrangeBy.BulletinItemsNeededByTrainRadioButton.Checked)
            {
                Bulletinsrepo.Bulletins_Input_Relay.Relay.ArrangeBy.BulletinItemsNeededByTrainRadioButton.Click();
            }
            
            //If trainSeed is blank, Relay All dem Bulls to all dem Trains
            int numberOfBulletins = Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.Self.GetAttributeValue<int>("ChildCount");
            
            //Possibly pulled the information too fast
            int retries = 0;
            while (numberOfBulletins == 0 && retries < 10)
            {
                Ranorex.Delay.Milliseconds(500);
                numberOfBulletins = Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.Self.GetAttributeValue<int>("ChildCount");
                retries++;
            }
            
            //If there are no Bulletins, then they've all been relayed
            if (numberOfBulletins == 0)
            {
                Ranorex.Report.Screenshot(Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.Self);
                Ranorex.Report.Info("Bulletin: "+bulletinNumber+ " not available");
            }
            
            if(Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.BulletinItemsNeededByTrains.TreeItemByBulletinNumber.SelfInfo.Exists(0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// It verifies the given tracks exist in the tack list or not
        /// </summary>
        /// <param name="tracks">Track names separated by | to validate</param>
        /// <param name="validateCount">Whether or not to validate the number of tracks</param>
        /// <param name="tracksCount">Number of expected tracks if validating the count</param>
        /// <param name="expectTrack">Expecting the tracks to exist or not exist</param>
        [UserCodeMethod]
        public static void NS_ValidateTracksExists_BulletinInputRelayForm(string tracks, bool validateCount, int tracksCount, bool expectTrack = true)
        {
        	if (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
        	{
        		Ranorex.Report.Error("Bulletin Input Relay form is not open");
        		return;
        	}
        	
        	
        	string [] trackItem = tracks.Split('|');
        	
        	if (!validateCount && trackItem.Length == 0)
        	{
        		Ranorex.Report.Error("Enter tracks to be validated or validate the count");
        		return;
        	}
        	
        	GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Tracks.TracksButtonInfo,
        	                                          Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Tracks.TracksMenu.SelfInfo);
        	if (validateCount)
        	{
        		int listCount = 0;
        		listCount = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Tracks.TracksMenu.Self.Items.Count;
        		if (listCount == tracksCount)
        		{
        			Ranorex.Report.Success("The count value is "+tracksCount+" as expexted");
        		}
        		else
        		{
        			Ranorex.Report.Failure("Tracks count is not what we expect");
        		}
        	}
        	
        	foreach(string track in trackItem)
        	{
        		Bulletinsrepo.TracksName = track;
        		bool actualTrack = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Tracks.TracksMenu.TracksMenuitemByNameInfo.Exists(0);
        		if(actualTrack == expectTrack)
        		{
        		    Ranorex.Report.Success("Expected and found track {"+track+"} to " + (actualTrack ? "":"not ") + "Exist");
        		}
        		else
        		{
        			Ranorex.Report.Screenshot(Bulletinsrepo.Bulletins_Input_Relay.Self);
        			Ranorex.Report.Failure("Expected track {"+track+"} to " + (expectTrack ? "":"not ") + "Exist and found that it does " + (actualTrack ? "":"not ") + "Exist");
        		}
        	}
        	return;
        }
        
        
        /// <summary>
        /// Opens the Bulletin Input Form and Bulletin View Form from trackline
        /// </summary>
        /// <param name="bulletinSeed">Input - bulletin seed</param>
        /// <param name="bulletinObjectMenu">Input - View Bulletin or Open Bulletin</param>
        [UserCodeMethod]
        public static void NS_OpenOrViewBulletinFrom_TrackLine(string bulletinSeed, string bulletinObjectMenu)
        {
            int retries=0;
            bulletinObjectMenu = bulletinObjectMenu.ToLower();
            string bulletinNumber = GetBulletinNumber(bulletinSeed);
            Tracklinerepo.BulletinNumber = bulletinNumber;
            if(bulletinNumber == null)
            {
                Ranorex.Report.Failure("No Bulletin found for bulletinSeed {"+bulletinSeed+"}, ensure correct bulletinSeed and that bulletin was issued");
                Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form.BulletinObject);
                return;
            }
            if(!Tracklinerepo.Trackline_Form.BulletinObjectInfo.Exists(0) && retries < 5)
            {
                Delay.Milliseconds(500);
                retries++;
            }
            if(Tracklinerepo.Trackline_Form.BulletinObjectInfo.Exists(0))
            {
                Tracklinerepo.Trackline_Form.BulletinObject.Click(WinForms.MouseButtons.Middle);
                GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.BulletinIDLabelInfo,
                                                               Tracklinerepo.Trackline_Form.BulletinObjectMenu.SelfInfo);
                switch(bulletinObjectMenu)
                {
                    case "openbulletin":
                        GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.BulletinObjectMenu.OpenBulletinInfo, Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
                        break;
                    case "viewbulletin":
                        GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.BulletinObjectMenu.ViewBulletinInfo, Bulletinsrepo.Bulletin_View.SelfInfo);
                        break;
                    default:
                        Ranorex.Report.Failure("Failed to find "+bulletinObjectMenu+" from trackline");
                        break;
                }
                Tracklinerepo.Trackline_Form.BulletinObject.Click(WinForms.MouseButtons.Middle);
            }
            else
            {
                Ranorex.Report.Error("No Bulletin found on trackline for bulletin with seed {"+bulletinSeed+"}");
                return;
            }
            
            return;
        }
        
        
        /// <summary>
        /// Validates the contents of Bulletin View Form
        /// </summary>
        /// <param name="bulletinSeed">Input - bulletin seed </param>
        /// <param name="bulletinObjectMenu">Input - View Bulletin or Open Bulletin</param>
        /// <param name="validateFrom">Input - Validate From trackline section/bulletin input form/bulletin summarylist form</param>
        /// <param name="closeBulletinInputForm">Input - True/False</param>
        /// <param name="closeBulletinSummaryList">Input - True/False</param>
        [UserCodeMethod]
        public static void NS_validateContentsOnBulletinView(string bulletinSeed, string bulletinObjectMenu,string validateFrom, bool closeForm =  true)
        {
        	switch(validateFrom.ToLower())
        	{
        		case "tracklinesection" :
        			NS_validateBulletinViewForm_TrackLineSection(bulletinSeed, bulletinObjectMenu);
        			break;
        			
        		case "bulletininputform" :
        			NS_ValidateBulletinViewForm_BulletinInputForm(bulletinSeed, closeForm);
        			break;
        			
        		case "bulletinsummarylist" :
        			NS_ValidateBulletinViewForm_BulletinSummary(bulletinSeed, closeForm);
        			break;
        			
        			default :
        				Ranorex.Report.Failure("Invalid choice to validate bulletins view form");
        			break;
        	}
        }
        
        /// <summary>
        /// Validates color of the bulletin text
        /// </summary>
        /// <param name="bulletinSeed">Input - bulletin seed </param>
        /// <param name="color">Input - Pink / Yellow / Orange</param>
        /// <param name="trackSectionId">Input - ID of particular track Section</param>
        [UserCodeMethod]
        public static void NS_ValidateBulletinTextColor_TrackLine(string bulletinSeed, string color)
        {
            NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
            if (bulletinObject != null)
            {
                Tracklinerepo.BulletinNumber = bulletinObject.bulletinNumber;
            } else {
                Tracklinerepo.BulletinNumber = bulletinSeed;
            }
            
            if(Tracklinerepo.Trackline_Form.BulletinObjectInfo.Exists(0))
            {
                //click on the bulletin
                GeneralUtilities.MiddleClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.BulletinObjectInfo,
                                                                Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.SelfInfo,
                                                                WinForms.MouseButtons.Middle);
                //Validate the color of the bulletin text
                if(GeneralUtilities.ValidateColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.BulletinIDLabel,
                                                                      color, true))
                {
                    Report.Success("Bulletin: "+Tracklinerepo.BulletinNumber+" is found with color "+color+" as expected on Trackline.");
                }
                else
                {
                    Report.Failure("Bulletin: "+Tracklinerepo.BulletinNumber+" is not found with color "+color+" as expected on Trackline.");
                    Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form.Self);
                    return;
                }
                // simply cilck on object to close the Bulletin Label
                GeneralUtilities.MiddleClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.BulletinObjectInfo,
                                                                        Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.BulletinIDLabelInfo);
                
            }
            else
            {
                Ranorex.Report.Error("No Bulletin found for bulletinSeed {"+bulletinSeed+"}");
                return;
            }
        }
        
        /// <summary>
        /// Validate Remote Bulletin Issue Request PopUp and click OpenBulletinButton or AcknowledgeButton
        /// <param name="OpenBulletin"></param>
        /// </summary>
        [UserCodeMethod]
        public static void AcknowledgeOrOpenRemoteBulletinIssueRequestPopUp(bool OpenBulletin)
        {
            int retries = 0;

            while(!Bulletinsrepo.Remote_Bulletin_Request.SelfInfo.Exists(0) && retries < 12)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if(Bulletinsrepo.Remote_Bulletin_Request.SelfInfo.Exists(0))
            {
                IList<Form> forms = Host.Local.Find<Form>(Bulletinsrepo.Remote_Bulletin_Request.AbsoluteBasePath.ToString());
                if (forms.Count == 1)
                {
                    if(OpenBulletin)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Remote_Bulletin_Request.OpenBulletinButtonInfo, Bulletinsrepo.Remote_Bulletin_Request.SelfInfo);
                        Ranorex.Report.Info("Succesfully verified the Open Bulletin button and performed click on it.");
                    }
                    else
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Remote_Bulletin_Request.AcknowledgeButtonInfo, Bulletinsrepo.Remote_Bulletin_Request.SelfInfo);
                        Ranorex.Report.Info("Succesfully verified the Acknowledge Button and performed click on it.");
                    }
                } else {
                    int currentCount, newCount;
                    currentCount = newCount = forms.Count;
                    while (currentCount == newCount)
                    {
                        if(OpenBulletin)
                        {
                            Bulletinsrepo.Remote_Bulletin_Request.OpenBulletinButton.Click();
                        }
                        else
                        {
                            Bulletinsrepo.Remote_Bulletin_Request.AcknowledgeButton.Click();
                        }
                        
                        Ranorex.Delay.Seconds(1);
                        forms = Host.Local.Find<Form>(Bulletinsrepo.Remote_Bulletin_Request.AbsoluteBasePath.ToString());
                        newCount = forms.Count;
                    }
                    
                    if (OpenBulletin)
                    {
                        Ranorex.Report.Info("Succesfully verified the Open Bulletin button and performed click on it.");
                    } else {
                        Ranorex.Report.Info("Succesfully verified the Acknowledge Button and performed click on it.");
                    }
                }
            }

            else
            {
                Ranorex.Report.Error("Error", Bulletinsrepo.Remote_Bulletin_Request + " Error Remote Bulletin popup , the popup does not exist.");
            }
        }
        /// <summary>
        /// validate Bulletin Remote Popup Count
        /// </summary>
         [UserCodeMethod]
         public static void ValidateNumberOfRemoteBulletinPopups(int expPopupCount)
         {
         	int retries = 0;

            while(!Bulletinsrepo.Remote_Bulletin_Request.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            
            IList<Form> forms = Host.Local.Find<Form>(Bulletinsrepo.Remote_Bulletin_Request.AbsoluteBasePath.ToString());
            if(forms.Count == expPopupCount)
            {
            	Ranorex.Report.Success("Succesfully verified the Bulletin Remote popup count Actual : {"+forms.Count+"} and Expected : {"+expPopupCount+"}.");
            }
            else
            {
            	Ranorex.Report.Failure("Bulletin Remote popup count Actual : {"+forms.Count+"} and Expected : {"+expPopupCount+"}.");
            }
         	
         }
        /// <summary>
        /// Wait for Remote Bulletin Request Pop up
        /// <param name="maxWaitSeconds">Input:Maximum wait time in seconds</param>
        /// </summary>
        [UserCodeMethod]
        public static void NS_WaitForRumBulletinRequestPopup(int maxWaitSeconds)
        {
            int retries = 0;
            while(!Bulletinsrepo.Remote_Bulletin_Request.SelfInfo.Exists(0) && retries < maxWaitSeconds)
            {
                Ranorex.Delay.Seconds(1);
                retries++;
            }            
            if(Bulletinsrepo.Remote_Bulletin_Request.AcknowledgeButtonInfo.Exists(0) && Bulletinsrepo.Remote_Bulletin_Request.OpenBulletinButtonInfo.Exists(0))
            {
                Ranorex.Report.Info("RUM Bulletin Popup appeared found AcknowledgeButton and OpenBulletinButton");
            }
            else if(Bulletinsrepo.Remote_Bulletin_Request.AcknowledgeButtonInfo.Exists(0) && !Bulletinsrepo.Remote_Bulletin_Request.OpenBulletinButtonInfo.Exists(0))
            {
            	
            	 Ranorex.Report.Info("RUM Bulletin Popup appeared found AcknowledgeButton and No OpenBulletinButton");
            }
            else
            {
            	Ranorex.Report.Error("RUM bulletin request pop up did not appear within "+maxWaitSeconds.ToString()+" seconds.");
            }
            return;
        }
        
        [UserCodeMethod]
        public static void NS_CloseBulletinGrantDenyForm(string expectedFeedback)
        {
            int retries = 0;
            while (!Bulletinsrepo.Bulletins_Input_Relay.WindowControls.CloseInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if(!Bulletinsrepo.Bulletins_Input_Relay.WindowControls.CloseInfo.Exists(0))
            {
                Ranorex.Report.Error("Could not find Cancel button for Grant Deny Form");
                return;
            }
            retries = 0;
            while (Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0) && retries < 2)
            {
                if(Bulletinsrepo.Bulletins_Input_Relay.Feedback.TextValue != "" && Bulletinsrepo.Bulletins_Input_Relay.Feedback.TextValue != " ")
                {
                    break;
                }
                
                Bulletinsrepo.Bulletins_Input_Relay.WindowControls.Close.Click();
                Delay.Milliseconds(500);
                retries++;
            }
            if(Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
            {
                if (!CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
                {
                    return;
                }
            }
            if (expectedFeedback != "")
            {
                Ranorex.Report.Failure("Did not get expected feedback of {" + expectedFeedback + "}");
            }
            return;
        }

        
        
        /// <summary>
        /// For Issue Replace Bulletin use this recoding then call relevant recording in next step for the bulletin you want to replace with.
        /// </summary>
        /// <param name="bulletinSeedVoid">Input:bulletinSeedVoid to issue replace bulletin</param>
        [UserCodeMethod]
        public static void NS_IssueReplaceBulletin_BulletinInputRelayForm(string bulletinSeedVoid,string optionalReplaceBulletinSeed, bool pressComplete)
        {
            //If Bulletin seed doesn't exist assume the seed is the bulletin number
            string targetBulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeedVoid);
            string type = NS_Bulletin.GetBulletinType(bulletinSeedVoid);
            string district = NS_Bulletin.GetBulletinDistrict(bulletinSeedVoid);
            if (targetBulletinNumber == null)
            {
                targetBulletinNumber = bulletinSeedVoid;
            }
            
            Bulletinsrepo.BulletinNumber = targetBulletinNumber;
            NS_OpenBulletinInputForm_MainMenu();
            Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
            
            NS_InputBulletins.InputBulletinHeader(district, type);
            
            Bulletinsrepo.BulletinRowIndex = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByBulletinNumber.ReferenceNumber.GetAttributeValue<int>("RowIndex").ToString();
            
            Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
            GeneralUtilities.RightClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.MenuCellInfo,
                                                           Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.SelfInfo);
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.IssueReplaceBulletinInfo,
                                                              Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.IssueReplaceBulletinInfo);
            
            if(pressComplete)
            {
            	GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButtonInfo,Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButtonInfo);
            	Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
            }
            if(!optionalReplaceBulletinSeed.Equals(""))
            {
            	int retries=0;
            	while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count==0 && retries<3) 
            	{
            		Delay.Milliseconds(500);
            		retries++;
            	}
            	Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
            	string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
            	NS_Bulletin.CreateBulletinRecord(optionalReplaceBulletinSeed, bulletinNumber, type, "", "", district, "", "");
            }
        }
        
        /// Validates color of  the top bulletin text
        /// <summary>
        /// <param name="expBulletinSeedTop">Input - bulletin seed </param>
        /// <param name="objBulletinSeed">Input - bulletin seed</param>
        /// <param name="color">Input - color</param>
        /// </summary>
        [UserCodeMethod]
        public static void NS_ValidateTopBulletinColor_TrackLine(string expBulletinSeedTop, string objBulletinSeed, string color)
        {
            string expBulletinTop = NS_Bulletin.GetBulletinNumber(expBulletinSeedTop);
            
            //Fetching bulletin number just to click on 2nd bulletin object in the trackline
            NS_BulletinObject bulletinObject = getBulletinObject(objBulletinSeed);
            if (bulletinObject != null)
            {
                Tracklinerepo.BulletinNumber = bulletinObject.bulletinNumber;
            } else {
                Tracklinerepo.BulletinNumber = objBulletinSeed;
            }
            
            if(Tracklinerepo.Trackline_Form.BulletinObjectInfo.Exists(0))
            {
                //click on the bulletin object
                GeneralUtilities.MiddleClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.BulletinObjectInfo,
                                                                Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.SelfInfo,
                                                                WinForms.MouseButtons.Middle);
                //Changing the bulletin number to previous expected to be top bulletin
                Tracklinerepo.BulletinNumber = expBulletinTop;
                
                //Getting the row of Topbulletin expected
                int TopBulletinRow = Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.BulletinIDLabel.RowIndex;
                
                //if the row is 1 means then the bulletin is present at the top
                if(TopBulletinRow == 1)
                {
                    //Validate the color of the bulletin
                    if(GeneralUtilities.ValidateColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.BulletinIDLabel,
                                                                          color, true))
                    {
                        Report.Success("Bulletin: "+Tracklinerepo.BulletinNumber+" is at TOP with color "+color+" as expected on Trackline.");
                    }
                    else
                    {
                        Report.Failure("Bulletin: "+Tracklinerepo.BulletinNumber+" is at TOP but not found with color "+color+" as expected on Trackline.");
                        Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form.Self);
                        return;
                    }
                }
                else
                {
                    Ranorex.Report.Failure("Bulletin: {"+Tracklinerepo.BulletinNumber+"} is not at the TOP ");
                }
                
                // simply cilck on object to close the Bulletin Label
                GeneralUtilities.MiddleClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.BulletinObjectInfo,
                                                                        Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.BulletinIDLabelInfo);
            }
            else
            {
                Ranorex.Report.Error("No Bulletin found for bulletinSeed {"+objBulletinSeed+"}");
                return;
            }
        }
        
        /// <summary>
        /// Validates Name and Color bulletin displayed on the trackline
        /// </summary>
        /// <param name="bulletinSeed">Input - bulletin seed </param>
        /// <param name="color">Input - Pink / Yellow / Orange</param>
        /// <param name="expectedBulletinName">Input - Expected name /param>
        [UserCodeMethod]
        public static void NS_ValidateBulletinNameAndColor_TrackLine(string bulletinSeed, string expectedBulletinName, string color)
        {
            NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
            if (bulletinObject != null)
            {
                Tracklinerepo.BulletinNumber = bulletinObject.bulletinNumber;
            } else {
                Tracklinerepo.BulletinNumber = bulletinSeed;
            }
            
            if(Tracklinerepo.Trackline_Form.BulletinObjectInfo.Exists(0))
            {
                string actualBulletinName = Tracklinerepo.Trackline_Form.BulletinObject.GetAttributeValue<string>("TrainId");
                //Validating the  Name of bulletin
                if(actualBulletinName.Contains(expectedBulletinName))
                {
                    Report.Success("Name of Bulletin: {"+Tracklinerepo.BulletinNumber+"} is expected to be {"+expectedBulletinName+"} and found {"+actualBulletinName+"}.");
                }
                else
                {
                    Report.Failure("Name of Bulletin: {"+Tracklinerepo.BulletinNumber+"} is expected to be {"+expectedBulletinName+"} and found {"+actualBulletinName+"}.");
                }
                
                //click on the bulletin
                GeneralUtilities.MiddleClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.BulletinObjectInfo,
                                                                Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.SelfInfo,
                                                                WinForms.MouseButtons.Middle);
                //Validate the color of the bulletin text
                if(GeneralUtilities.ValidateColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.BulletinIDLabel,
                                                                      color, true))
                {
                    Report.Success("Bulletin: "+Tracklinerepo.BulletinNumber+" is found with color "+color+" as expected on Trackline.");
                }
                else
                {
                    Report.Failure("Bulletin: "+Tracklinerepo.BulletinNumber+" is not found with color "+color+" as expected on Trackline.");
                    Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form.Self);
                }
                
                // simply cilck on object to close the Bulletin Label
                GeneralUtilities.MiddleClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.BulletinObjectInfo,
                                                                        Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.BulletinIDLabelInfo);
            }
            else
            {
                Ranorex.Report.Error("No Bulletin found for bulletinSeed {"+bulletinSeed+"}");
                return;
            }
        }
        
        
        public static void NS_ValidateBulletinViewForm(string bulletinSeed)
        {
        	string milepost1 = NS_Bulletin.GetBulletinMilepost1(bulletinSeed);
        	string milepost2 = NS_Bulletin.GetBulletinMilepost2(bulletinSeed);
        	string trackLine = NS_Bulletin.GetBulletinTrackLine(bulletinSeed);
        	string maximumSpeed = NS_Bulletin.GetBulletinMaximumSpeed(bulletinSeed);
        	string tyepOfBulletin = NS_Bulletin.GetBulletinType(bulletinSeed);
        	
        	string actualBulletinViewText = Bulletinsrepo.Bulletin_View.BulletinReviewText.GetAttributeValue<string>("Text").Trim();
        	
        	

        	if(string.IsNullOrEmpty(actualBulletinViewText))
            {
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_View.OkButtonInfo, Bulletinsrepo.Bulletin_View.SelfInfo);
        		Ranorex.Report.Screenshot(Bulletinsrepo.Bulletin_View.Self);
        		Ranorex.Report.Failure("Bulletin View Text does not match");
        		return;
        	}

            bool match = true;
            bool hasAttributes = false;
            
            if (!string.IsNullOrEmpty(milepost1))
            {
                if (!actualBulletinViewText.Contains(milepost1))
                {
                    Ranorex.Report.Info("Bulletin Text for Bulletin View Form does not contain expected milepost 1: "+ milepost1);
                    match = false;
                }
                hasAttributes = true; 
            }

            if (!string.IsNullOrEmpty(milepost2))
            {
                if (!actualBulletinViewText.Contains(milepost2))
                {
                    Ranorex.Report.Info("Bulletin Text for Bulletin View Form does not contain expected milepost 2: "+ milepost2);
                    match = false;
                }
                hasAttributes = true; 
            }
            if (!string.IsNullOrEmpty(trackLine))
            {
                if (!actualBulletinViewText.Contains(trackLine))
                {
                    Ranorex.Report.Info("Bulletin Text for Bulletin View Form does not contain expected track line: "+ trackLine);
                    match = false;
                }
                hasAttributes = true; 
            }
            if (!string.IsNullOrEmpty(maximumSpeed))
            {
                if (!actualBulletinViewText.Contains(maximumSpeed))
                {
                    Ranorex.Report.Info("Bulletin Text for Bulletin View Form does not contain expected max speed: "+ maximumSpeed);
                    match = false;
                }
                hasAttributes = true; 
            }


            // Validation should fail if all of bulletin seed returns no properties
            if (!hasAttributes)
            {
                Report.Error("No bulletin properties match actual bulletin properties in form contents");
                return;
            }
            
            if (match)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_View.OkButtonInfo, Bulletinsrepo.Bulletin_View.SelfInfo);
                Ranorex.Report.Success("Bulletin Text for Bulletin View Form Matched");
                return;
            }
            else
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_View.OkButtonInfo, Bulletinsrepo.Bulletin_View.SelfInfo);
                Ranorex.Report.Screenshot(Bulletinsrepo.Bulletin_View.Self);
                Ranorex.Report.Failure("Bulletin View Text does not match");
                return;
            }
        	
        }
        
        
        /// <summary>
        /// Opens and validates bulletin view form from Trackline section
        /// </summary>
        /// <param name="bulletinSeed">Input - bulletin seed </param>
        /// <param name="bulletinObjectMenu">Input - view/open</param>
        /// <param name="milepost1">Input - milepost1</param>
        /// <param name="milepost2">Input - milepost2</param>
        /// <param name="trackLine">Input - trackLine</param>
        /// <param name="maximumSpeed">Input - maximumSpeed</param>
        public static void NS_validateBulletinViewForm_TrackLineSection(string bulletinSeed, string bulletinObjectMenu)
        {
        	int retries=0;
        	//Open or View Bulletin From Trackline
        	NS_OpenOrViewBulletinFrom_TrackLine(bulletinSeed, bulletinObjectMenu);
        	
        	while(!Bulletinsrepo.Bulletin_View.SelfInfo.Exists(0) && retries < 5)
        	{
        		Delay.Milliseconds(500);
        		retries++;
        	}
        	
        	if(Bulletinsrepo.Bulletin_View.SelfInfo.Exists(0))
        	{
        		NS_ValidateBulletinViewForm(bulletinSeed);
        	}
        	else
        	{
        		Ranorex.Report.Error("Bulletin View window does not exists");
        		return;
        	}
        }

        
        /// <summary>
        /// Opens and validates bulletin view form from bulletin input form
        /// </summary>
        /// <param name="bulletinSeed">Input - bulletin seed </param>
        /// <param name="milepost1">Input - milepost1</param>
        /// <param name="milepost2">Input - milepost2</param>
        /// <param name="trackLine">Input - trackLine</param>
        /// <param name="maximumSpeed">Input - maximumSpeed</param>
        /// <param name="district">Input - district</param>
        /// <param name="tyepOfBulletin">Input - tyepOfBulletin</param>
        /// <param name="closeBulletinInputForm">Input - True/false</param>
        public static void NS_ValidateBulletinViewForm_BulletinInputForm(string bulletinSeed, bool closeBulletinInputForm)
        {
            int retries = 0;
            
            string tyepOfBulletin = NS_Bulletin.GetBulletinType(bulletinSeed);
            string district = NS_Bulletin.GetBulletinDistrict(bulletinSeed);
            
            NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
            if (bulletinObject != null)
            {
                Bulletinsrepo.BulletinNumber= bulletinObject.bulletinNumber;
            }
            else
            {
                Bulletinsrepo.BulletinNumber = bulletinSeed;
            }
            //Opens bulletin Input form if not already opened
            NS_OpenBulletinInputForm_MainMenu();
            //Fills the Header of buletin form i.e district and Type
            NS_InputBulletins.InputBulletinHeader(district, tyepOfBulletin);
            
            while(!Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByBulletinNumber.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if(Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByBulletinNumber.SelfInfo.Exists(0))
            {
                //Sinec we cannot directly click on the menu object for the particular bulletin we need to get the index of the bulletin we want
                string indexValue = Convert.ToString(Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByBulletinNumber.ReferenceNumber.GetAttributeValue<int>("RowIndex"));
                Bulletinsrepo.BulletinRowIndex = indexValue;
                //click menu arrow in the bulletin row to Open bulletin Object Menu
                GeneralUtilities.RightClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.MenuCellInfo,
                                                               Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.SelfInfo);
                //To click on View in Bulletin Object Menu
                GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.ViewBulletinInfo,
                                                          Bulletinsrepo.Bulletin_View.SelfInfo);
                
                while(!Bulletinsrepo.Bulletin_View.SelfInfo.Exists(0) && retries < 5)
                {
                    Delay.Milliseconds(500);
                    retries++;
                }
                
                if(Bulletinsrepo.Bulletin_View.SelfInfo.Exists(0))
                {
                    NS_ValidateBulletinViewForm(bulletinSeed);
                }
                else
                {
                    Ranorex.Report.Error("Bulletin View window does not exists");
                    return;
                }
            }
            else
            {
                Ranorex.Report.Screenshot(Bulletinsrepo.Bulletins_Input_Relay.Self);
                Ranorex.Report.Failure("No bulletin found for bulletinseed{"+bulletinSeed+"}");
            }
            
            if(closeBulletinInputForm)
            {
                CloseBulletinItemsForm_NS();
                return;
            }
            
        }
        
        /// <summary>
        /// Opens and validates bulletin view form from bulletin input form
        /// </summary>
        /// <param name="bulletinSeed">Input - bulletin seed </param>
        /// <param name="milepost1">Input - milepost1</param>
        /// <param name="milepost2">Input - milepost2</param>
        /// <param name="trackLine">Input - trackLine</param>
        /// <param name="maximumSpeed">Input - maximumSpeed</param>
        /// <param name = "closeBulletinSummaryList">Input - True/false</c>
        public static void NS_ValidateBulletinViewForm_BulletinSummary(string bulletinSeed, bool closeBulletinSummaryList)
        {
            int retries = 0;
            
            NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
            if (bulletinObject != null)
            {
                Bulletinsrepo.BulletinNumber= bulletinObject.bulletinNumber;
            }
            else
            {
                Bulletinsrepo.BulletinNumber = bulletinSeed;
            }
            //Opens the bulletin summary list
            NS_OpenBulletinSummaryList_MainMenu();
            
            while(!Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByBulletinNumber.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if(Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByBulletinNumber.SelfInfo.Exists(0))
            {
                //Sinec we cannot directly click on the menu object for the particular bulletin we need to get the index of the bulletin we want
                string indexValue = Convert.ToString(Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByBulletinNumber.CellByColumnName.BulletinNumber.GetAttributeValue<int>("RowIndex"));
                Bulletinsrepo.RowIndex = indexValue;
                //click menu arrow in the bulletin row to Open bulletin Object Menu
                GeneralUtilities.RightClickAndWaitForWithRetry(Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByRowIndex.MenuCellInfo,
                                                               Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.MenuCellMenu.SelfInfo);
                //To click on View in Bulletin Object Menu
                GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.MenuCellMenu.ViewBulletinInfo,
                                                          Bulletinsrepo.Bulletin_View.SelfInfo);
                
                while(!Bulletinsrepo.Bulletin_View.SelfInfo.Exists(0) && retries < 5)
                {
                    Delay.Milliseconds(500);
                    retries++;
                }
                
                if(Bulletinsrepo.Bulletin_View.SelfInfo.Exists(0))
                {
                    NS_ValidateBulletinViewForm(bulletinSeed);
                }
                else
                {
                    Ranorex.Report.Error("Bulletin View window does not exists");
                    return;
                }
            }
            else
            {
                Ranorex.Report.Screenshot(Bulletinsrepo.Bulletins_Input_Relay.Self);
                Ranorex.Report.Failure("No bulletin found for bulletinseed{"+bulletinSeed+"}");
            }
            
            if(closeBulletinSummaryList)
            {
                CloseBulletinSummaryListForm_NS();
                return;
            }
            
        }
        /// <summary>
        /// Relays a bulletin for a train
        /// </summary>
        /// <param name="bulletinSeed">Input : bulletinSeed</param>
        [UserCodeMethod]
        public static void NS_RelayBulletin_BulletinItemRelay(string bulletinSeed)
        {
            int retries = 0;
            string bulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
            if(!String.IsNullOrEmpty(bulletinNumber))
            {
                Bulletinsrepo.BulletinNumber = bulletinNumber;
            }
            
            while(!Bulletinsrepo.Bulletin_Item_Relay.BulletinTable.BulletinItemByBulletinNumber.SelfInfo.Exists(0) && retries < 5)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            
            if(Bulletinsrepo.Bulletin_Item_Relay.BulletinTable.BulletinItemByBulletinNumber.SelfInfo.Exists(0))
            {
            	Bulletinsrepo.Bulletin_Item_Relay.BulletinTable.BulletinItemByBulletinNumber.MenuCell.Click();
            	retries = 0;
            	while(!Bulletinsrepo.Bulletin_Item_Relay.Details.SystemReferenceNumber.GetAttributeValue<string>("Text").Equals(bulletinNumber) && retries < 3)
            	{
            		Ranorex.Delay.Milliseconds(500);
            		retries++;
            	}
            	
            	if(Bulletinsrepo.Bulletin_Item_Relay.Details.SystemReferenceNumber.GetAttributeValue<string>("Text").Equals(bulletinNumber))
            	{
            		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Item_Relay.AddressTable.AddressLinesRowByIndex.TCNumberInfo,
            		                                                  Bulletinsrepo.Bulletin_Item_Relay.BulletinTable.BulletinItemByBulletinNumber.SelfInfo);
            	}
            	else
            	{
            		Ranorex.Report.Screenshot(Bulletinsrepo.Bulletin_Item_Relay.Self);
            		Ranorex.Report.Failure("System took more time to load bulleitn information or the information does not exist");
            		return;
            	}
            }
            else
            {
                Ranorex.Report.Failure("Bulletin Relay Form is not opened");
                return;
            }
            
            string displayTime = NS_Time.FormatDateTime(System.DateTime.Now,"E",0);
            string expFeedback = "OK Time for Bulletin Item "+bulletinNumber+" is :"+displayTime;
            string actFeedBack = Bulletinsrepo.Bulletin_Item_Relay.Feedback.GetAttributeValue<string>("Text");
            
            if(actFeedBack.Equals(expFeedback))
            {
                Ranorex.Report.Success("Expected feedback:{"+expFeedback+"} and Actual feedback:{"+actFeedBack+"} are same");
            }
            else
            {
                Ranorex.Report.Screenshot(Bulletinsrepo.Bulletin_Item_Relay.Self);
                Ranorex.Report.Failure("Expected feedback:{"+expFeedback+"} and Actual feedback:{"+actFeedBack+"} are not same");
            }
            return;
        }
        
        /// <summary> Opens bulletin item relay form from train Id context menu on trackline and realays all the bulletins</summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="bulletinSeed">Input : bulletin Seed</param>
        /// <param name="closeForm">Input : True/False</param>
        [UserCodeMethod]
        public static void NS_OpenRelayBulletinFromTrainIDContextMenu_Trackline(string trainSeed, string bulletinSeed, bool closeForm = true)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            if (trainId == null)
            {
                Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                return;
            }
            
            Tracklinerepo.TrainId = trainId;
            //To click on the Train Object in Trackline
            GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectInfo,
                                                           Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.SelfInfo);
            
            GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.OpenBulletinRelayInfo,
                                                      Bulletinsrepo.Bulletin_Item_Relay.SelfInfo);
            
            NS_RelayBulletin_BulletinItemRelay(bulletinSeed);
            
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Item_Relay.CloseButtonInfo,
                                                                  Bulletinsrepo.Bulletin_Item_Relay.SelfInfo);
            }
        }
        
        
        /// <summary>
        /// Validates that no bulletin left in bulletin relay form for a train
        /// </summary>
        /// <param name="trainSeed">Input : trainSeed</param>
        /// <param name="closeForm">Input : closeForm</param>
        [UserCodeMethod]
        public static void NS_ValidateNoBulletinLeftToRelay_BulletinItemRelay(string trainSeed, bool closeForm = true)
        {
            int retries =0;
            NS_Trainsheet.NS_OpenBulletinItemRelayForm_TrainStatusSummary(trainSeed,false);
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            
            if (trainId == null)
            {
                Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                return;
            }
            
            string expFeedBack = "No bulletin items found for relay to "+trainId+".";
            
            while(!Bulletinsrepo.Bulletin_Item_Relay.SelfInfo.Exists(0) && retries < 5)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            
            if(Bulletinsrepo.Bulletin_Item_Relay.SelfInfo.Exists(0))
            {
                string actFeedBack = Bulletinsrepo.Bulletin_Item_Relay.Feedback.GetAttributeValue<string>("Text");
                if(actFeedBack.Equals(expFeedBack))
                {
                    Ranorex.Report.Success("Expected feedback:{"+expFeedBack+"} and Actual feedback:{"+actFeedBack+"} are same");
                }
                else
                {
                    Ranorex.Report.Screenshot(Bulletinsrepo.Bulletin_Item_Relay.Self);
                    Ranorex.Report.Failure("Expected feedback:{"+expFeedBack+"} and Actual feedback:{"+actFeedBack+"} are different");
                }
            }
            else
            {
                Ranorex.Report.Failure("Unable to find bulletin relay form to relay bulletin");
                return;
            }
            
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Item_Relay.CloseButtonInfo,
                                                                  Bulletinsrepo.Bulletin_Item_Relay.SelfInfo);
            }
        }
        
        /// <summary>
        /// Relays a bulletin for a train from opening relay form from train status summary and validates its realayed
        /// </summary>
        /// <param name="trainSeed">Input: trainSeed</param>
        /// <param name="bulletinSeed">Input: bulletinSeed</param>
        /// <param name="closeForm">Input: closeForm</param>
        [UserCodeMethod]
        public static void NS_OpenRelayBulletinFromTrainIDContextMenu_TrainStatusSummary(string trainSeed, string bulletinSeed, bool closeForm = true)
        {
            NS_Trainsheet.NS_OpenBulletinItemRelayForm_TrainStatusSummary(trainSeed,false);
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            if (trainId == null)
            {
                Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                return;
            }
            
            NS_RelayBulletin_BulletinItemRelay(bulletinSeed);
            
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Item_Relay.CloseButtonInfo,
                                                                  Bulletinsrepo.Bulletin_Item_Relay.SelfInfo);
            }
            
        }
        
        public static int rowCountBeforeCopy;
        
        /// <summary>
        /// For Copy Bulletin use this recoding then call relevant recording in next step for the bulletin you want to replace with.
        /// </summary>
        /// <param name="bulletinSeedVoid">Input:bulletinSeedVoid to issue replace bulletin</param>
        [UserCodeMethod]
        public static void NS_CopyBulletin_BulletinInputRelayForm(string bulletinSeed, bool completeCopy, string optionalBulletinSeed, bool closeForm)
        {
            //If Bulletin seed doesn't exist assume the seed is the bulletin number
            string targetBulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
            string type = NS_Bulletin.GetBulletinType(bulletinSeed);
            string district = NS_Bulletin.GetBulletinDistrict(bulletinSeed);
            if (targetBulletinNumber == null)
            {
                targetBulletinNumber = bulletinSeed;
            }
            
            Bulletinsrepo.BulletinNumber = targetBulletinNumber;
            NS_OpenBulletinInputForm_MainMenu();
            Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
            
            NS_InputBulletins.InputBulletinHeader(district, type);
            
            Bulletinsrepo.BulletinRowIndex = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByBulletinNumber.ReferenceNumber.GetAttributeValue<int>("RowIndex").ToString();
            
            Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
            Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.MenuCell.Click(WinForms.MouseButtons.Right);
            Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.CopyBulletin.Click();
            rowCountBeforeCopy = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
            if (completeCopy)
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButtonInfo, Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButtonInfo);
                int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
                Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
                int attempts = 0;
                while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 10) {
                    Delay.Milliseconds(500);
                    Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
                    attempts++;
                }
                
                if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
                    Ranorex.Report.Failure("Failed to Complete Bulletin Copy");
                    if(closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo, Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
                    }
                    return;
                }
                if (optionalBulletinSeed != "")
                {
                    Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
                    string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
                    //Add Bulletin information to the persistent bulletin list
                    NS_Bulletin.CreateBulletinRecord(optionalBulletinSeed, bulletinNumber, type, "", "", district, "", "");
                }
            }
            if(closeForm)
            {
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo, Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
            }
            
        }
        
        /// <summary>
        /// Verifies that whaether the particular bulletin is replaced or not in bulletin summarry list
        /// </summary>
        /// <param name="bulletinSeed">Input : bulletinSeed</param>
        /// <param name="replaced">Input : True/False</param>
        [UserCodeMethod]
        public static void NS_ValidateBulletinReplaced_BulletinSummaryList(string bulletinSeed, bool replaced = false, bool closeForm = true)
        {
            NS_OpenBulletinSummaryList_MainMenu();
            
            string targetBulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
            if (targetBulletinNumber == null)
            {
                targetBulletinNumber = bulletinSeed;
            }
            
            Bulletinsrepo.BulletinNumber = targetBulletinNumber;
            int retries = 0;
            
            while(!Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByBulletinNumber.SelfInfo.Exists(0) && retries < 6)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            
            bool bulletinPresence = !(Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByBulletinNumber.SelfInfo.Exists(0));
            if(bulletinPresence == replaced)
            {
                Ranorex.Report.Success("Expected bulletin :{"+targetBulletinNumber+"} to be replaced {"+replaced+"} and found {"+bulletinPresence+"}");
            }
            else
            {
                Ranorex.Report.Screenshot(Bulletinsrepo.Bulletin_Summary_List.Self);
                Ranorex.Report.Failure("Expected bulletin :{"+targetBulletinNumber+"} to be replaced {"+replaced+"} and found {"+bulletinPresence+"}");
            }
            
            if(closeForm)
            {
                CloseBulletinSummaryListForm_NS();
            }

        }
        
        /// <summary>
        /// Validates whether bulletin is copied or not
        /// </summary>
        /// <param name="bulletinSeed">Input : bulletinSeed</param>
        /// <param name="expectedCopied">Input : expect bulletin copied True/False</param>
        [UserCodeMethod]
        public static void NS_ValidateBulletinCopied_BulletinInputRelayForm(string bulletinSeed, bool expectedCopied = false, bool closeForm = true)
        {
            bool actualCopied = false;
            string targetBulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
            if (targetBulletinNumber == null)
            {
                targetBulletinNumber = bulletinSeed;
            }
            
            Bulletinsrepo.BulletinNumber = targetBulletinNumber;
            
            string district = NS_Bulletin.GetBulletinDistrict(bulletinSeed);
            string bulletinType = NS_Bulletin.GetBulletinType(bulletinSeed);
            
            NS_OpenBulletinInputForm_MainMenu();
            NS_InputBulletins.InputBulletinHeader(district, bulletinType);
            
            int currentRowCount = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
            
            int attempts = 0;
            while (rowCountBeforeCopy >= currentRowCount && attempts < 4) {
            	Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
            	Delay.Milliseconds(500);
            	currentRowCount = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
            	attempts++;
            }
            if(rowCountBeforeCopy < currentRowCount)
            {
                actualCopied = true;
            }
            else
            {
                actualCopied = false;
            }
            
            if(actualCopied == expectedCopied)
            {
                Ranorex.Report.Success("Expeted bulletin is copied as {"+expectedCopied+"} and found {"+actualCopied+"}");
            }
            else
            {
                Ranorex.Report.Screenshot(Bulletinsrepo.Bulletin_Summary_List.Self);
                Ranorex.Report.Failure("Expeted bulletin is copied as {"+expectedCopied+"} and found {"+actualCopied+"}");
            }
            
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo,
                                                                  Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
            }
            
        }
        
        /// <summary>
        /// Presses Cancel on BulletinInputRelay Form
        /// </summary>
        [UserCodeMethod]
        public static void NS_PressCancel_BulletinInputRelayForm()
        {
            while(!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
            {
                Ranorex.Report.Warn("Bulletin Form is not open, so it cannot be closed");
                return;
            }
            
            Bulletinsrepo.Bulletins_Input_Relay.CancelButton.Click();
            
        }
        
        /// <summary>
        /// Validates Warning Popup Exists for BulletinInputRelay Form
        /// </summary>
        [UserCodeMethod]
        public static void NS_ValidateWarningPopupExists_BulletinInputRelayForm(bool clickYes)
        {
            if(!Bulletinsrepo.Bulletins_Input_Relay.Input.Warning_Form.SelfInfo.Exists(0))
            {
                Ranorex.Report.Screenshot(Bulletinsrepo.Bulletin_Summary_List.Self);
                Ranorex.Report.Failure("No warning popup appeared");
            }
            else
            {
                Ranorex.Report.Success("Warning Popup Exists for Bulletin Input/Relay Form");
                if (clickYes)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Warning_Form.YesButtonInfo,
                                                                      Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
                    Ranorex.Report.Info("Clicked Yes on popup");
                } else {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Warning_Form.NoButtonInfo,
                                                                      Bulletinsrepo.Bulletins_Input_Relay.Input.Warning_Form.SelfInfo);
                    Ranorex.Report.Info("Clicked No on popup");
                }
            }
        }
        /// <summary>
        /// Check pending bulletin count
        /// </summary>
        public static int NS_GetPendingBulletinCount_MainMenu()
        {
            string bulletinCount = MainMenurepo.PDS_Main_Menu.RibbonMenu.PendingBulletinsCount.GetAttributeValue<string>("Text");
            int pendingBulletinCount = int.Parse(bulletinCount);
            return pendingBulletinCount;
        }
        
        /// <summary>
        /// Validate pending bulletin count
        /// </summary>
        [UserCodeMethod]
        public static void NS_ValidatePendingBulletinCount_MainMenu(int expectedBulletinCount)
        {
            
            int actualPendingBulletinCount = NS_GetPendingBulletinCount_MainMenu();

            if(actualPendingBulletinCount == expectedBulletinCount)
            {
                Ranorex.Report.Success("Pendindg Bulletin count Actual{"+actualPendingBulletinCount+"} and Expected {"+expectedBulletinCount+"}.");
                return;
            }
            else
            {
                Ranorex.Report.Screenshot(MainMenurepo.PDS_Main_Menu.Self);
                Ranorex.Report.Failure("Pendindg Bulletin count Actual{"+actualPendingBulletinCount+"} and Expected{"+expectedBulletinCount+"}.");
                return;
            }
        }
        
        /// <summary>
        /// Removing Pending Bulletin From TaskList
        /// </summary>
        /// <param name="closeForm"></param>
        [UserCodeMethod]
        public static void NS_RemovePendingBulletins_TaskList(bool closeForm)
        {
            NS_Miscellaneous.NS_OpenTaskListForm_MainMenu();
            int taskRows = Miscellaneousrepo.Task_List.Tasks.TasksTable.Self.Rows.Count;
            Ranorex.Report.Info("Rowcount: {"+taskRows+"}");
            
            for(int i = 0; i < taskRows; i++)
            {
                Miscellaneousrepo.TaskIndex = i.ToString();
                string descriptionText = Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.TaskDescription.Text.ToLower();
                if(descriptionText.Contains("bulletin suspended"))
                {
                    GeneralUtilities.RightClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.MenuCellInfo,
                                                                   Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.SelfInfo);
                    
                    GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.OpenInfo,
                                                              Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
                    
                    GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo,
                                                              Bulletinsrepo.Bulletins_Input_Relay.Input.Warning_Form.SelfInfo);
                    
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Warning_Form.YesButtonInfo,
                                                                      Bulletinsrepo.Bulletins_Input_Relay.Input.Warning_Form.SelfInfo);
                    i--;
                    taskRows = Miscellaneousrepo.Task_List.Tasks.TasksTable.Self.Rows.Count;
                }
            }
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Task_List.CloseButtonInfo,Miscellaneousrepo.Task_List.SelfInfo);
            }
        }
        
        /// <summary>
        /// cancels the pending bulletins
        /// </summary>
        /// <param name="closeForm"></param>
        [UserCodeMethod]
        public static void NS_CancelPendingBulletin_TasklListform(bool closeForm)
        {
            NS_Miscellaneous.NS_OpenTaskListForm_MainMenu();
            
            Miscellaneousrepo.TaskIndex = "0";
            string descriptionText = Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.TaskDescription.Text.ToLower();
            if(descriptionText.Contains("bulletin suspended"))
            {
                GeneralUtilities.RightClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.MenuCellInfo,
                                                               Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.SelfInfo);
                
                GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.OpenInfo,
                                                          Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
                
                GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo,
                                                          Bulletinsrepo.Bulletins_Input_Relay.Input.Warning_Form.SelfInfo);
                
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Warning_Form.YesButtonInfo,
                                                                  Bulletinsrepo.Bulletins_Input_Relay.Input.Warning_Form.SelfInfo);
            }
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Task_List.CloseButtonInfo,Miscellaneousrepo.Task_List.SelfInfo);
            }
        }
        
        /// <summary>
        /// Suspends bulletin from the bulletin input form
        /// </summary>
        [UserCodeMethod]
        public static void NS_PressSuspendBulletin_BulletinInputRelayForm(bool pressRefresh, bool closeForm)
        {
            if (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Bulletin Input Relay Form is not open");
                return;
            }
            
            int attempts = 0;
            
            while(!Bulletinsrepo.Bulletins_Input_Relay.RibbonMenu.SuspendButton.Enabled && attempts < 3)
            {
                Delay.Milliseconds(500);
                attempts++;
            }
            
            if(Bulletinsrepo.Bulletins_Input_Relay.RibbonMenu.SuspendButton.Enabled)
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Bulletinsrepo.Bulletins_Input_Relay.RibbonMenu.SuspendButtonInfo,
                                                                  Bulletinsrepo.Bulletins_Input_Relay.RibbonMenu.SuspendButtonInfo);
                if (pressRefresh)
                {
                    Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
                }
            }
            else
            {
                Report.Error("Suspend button is not enabled to click");
                Report.Screenshot(Bulletinsrepo.Bulletins_Input_Relay.Self);
            }
            
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo,
                                                                  Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
            }
        }
        
        /// <summary>
		/// Compelete pending bulletin using bulletin seed
		/// </summary>
		/// <param name="closeForm"></param>
		/// <param name="bulletinSeed">Input:bulletinSeed</param>
		/// <param name="district">Input:district</param>
		/// <param name="milepost1">Input:milepost1</param>
		/// <param name="milepost2">Input:milepost2</param>
		/// <param name="tracks">Input:tracks</param>
		/// <param name="maximumSpeed">Input:maximumSpeed</param>
		[UserCodeMethod]
		public static void NS_CompleteSuspendedBulletin_TaskListForm(string bulletinSeed, string bulletinType, string district, string milepost1, string milepost2, string tracks, string maximumSpeed, bool closeForm)
		{
			NS_Miscellaneous.NS_OpenTaskListForm_MainMenu();

			bool foundPendingBulletin = false;
			int numberOfTasks = Miscellaneousrepo.Task_List.Tasks.TasksTable.Self.Rows.Count;
			for (int i = 0; i < numberOfTasks; i++)
			{
			    Miscellaneousrepo.TaskIndex = i.ToString();
    			string descriptionText = Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.TaskDescription.Text.ToLower();
    			if(descriptionText.Contains("bulletin suspended"))
    			{
    			    foundPendingBulletin = true;
    				GeneralUtilities.RightClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.MenuCellInfo,
    				                                               Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.SelfInfo);
    				
    				GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.OpenInfo,
    				                                          Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
    				
    				GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButtonInfo,
    				                                          Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
    				
    				GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButtonInfo,
    				                                          Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.SelfInfo);
    				
    				int bulletinRowIndex = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
    				Bulletinsrepo.BulletinRowIndex = (bulletinRowIndex - 1).ToString();
    				string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
    				
    				//Add Bulletin information to the persistent bulletin list
    				CreateBulletinRecord(bulletinSeed, bulletinNumber, bulletinType, milepost1, milepost2, district, tracks, maximumSpeed);
    				
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.OkButtonInfo, Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
    				break;
    			}
			}
			
			if (!foundPendingBulletin)
			{
			    Ranorex.Report.Failure("Could not find a pending bulletin in Task List");
			}
			
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Task_List.CloseButtonInfo, Miscellaneousrepo.Task_List.SelfInfo);
			}
		}
		
		/// <summary>
		/// Waits for Bulletin to be effective on the trackline
		/// </summary>
		/// <param name="bulletinSeed">Input:Either the seed of the bulletin or the value intended to be the bulletin number</param>
		/// <param name="maxWaitMinutes">Input:Maximum wait time in minutes</param>
		[UserCodeMethod]
		public static void NS_WaitForRemedyBulletinToBecomeActiveOnTrackline_TracklineForm(string bulletinSeed, string color, int maxWaitMinutes)
		{
			NS_BulletinObject bulletinObject = getBulletinObject(bulletinSeed);
			if (bulletinObject != null)
			{
				Tracklinerepo.BulletinNumber = bulletinObject.bulletinNumber;
			}
			else
			{
				Tracklinerepo.BulletinNumber = bulletinSeed;
			}
			
			Ranorex.Report.Info("Waiting for Bulletin {"+Tracklinerepo.BulletinNumber+"} to be effective within "+maxWaitMinutes.ToString()+" minutes.");
			if (Tracklinerepo.Trackline_Form.BulletinObjectInfo.Exists(0))
			{
				Ranorex.Adapter TrainSectionElement = Tracklinerepo.Trackline_Form.BulletinObject;
				bool success = PDS_CORE.Code_Utils.GeneralUtilities.CheckColorForTrackSectionAdapterByPixel(TrainSectionElement, color, true);
				System.DateTime timeoutTime = System.DateTime.Now.AddMinutes(maxWaitMinutes);
				while (!success && timeoutTime > System.DateTime.Now)
				{
					Ranorex.Delay.Seconds(5);
					success = PDS_CORE.Code_Utils.GeneralUtilities.CheckColorForTrackSectionAdapterByPixel(TrainSectionElement, color, true);
				}
				
				if (!success)
				{
					Ranorex.Report.Error("Did not get activated");
					Report.Screenshot(Tracklinerepo.Trackline_Form.BulletinObject);
				}
				else
				{
					Ranorex.Report.Info("Bulletin  get activated");
					Report.Screenshot(Tracklinerepo.Trackline_Form.BulletinObject);
				}
			} else {
			    Ranorex.Report.Failure("Bulletin with bulletinSeed {" + bulletinSeed + "} does not exist on any open trackline");
			}
		}
		/// <summary>
		/// Validates whether the bulletin is present or not in bulletinSummarry List form
		/// </summary>
		/// <param name="bulletinSeed">Input : bulletinSeed</param>
		/// <param name="expetedBulletinPresence">Input : expetedBulletinPresence True/False</param>
		/// <param name="closeBulletinSummaryList">Input : True/False</param>
		[UserCodeMethod]
		public static void NS_ValidateBulletinExists_BulletinSummaryList(string bulletinSeed, bool validateExists = false, bool closeBulletinSummaryList = true)
		{
			NS_OpenBulletinSummaryList_MainMenu();
			
			//If Bulletin seed doesn't exist assume the seed is the bulletin number
			string targetBulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
			if (targetBulletinNumber == null)
			{
				targetBulletinNumber = bulletinSeed;
			}
			
			Bulletinsrepo.BulletinNumber = targetBulletinNumber;
			
			//check if bulletin visible in bulletin summary list.
			if(validateExists)
			{
				Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByBulletinNumber.Self.EnsureVisible();
			}
			else
			{
				Ranorex.Report.Screenshot(Bulletinsrepo.Bulletin_Summary_List.Self);
				Ranorex.Report.Info("Bulletin number {"+targetBulletinNumber+"} is not present in the Bulletin Summary List");
			}
		
			bool actBulletinPresence = Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByBulletinNumber.SelfInfo.Exists(0);
			if (actBulletinPresence == validateExists)
			{
				Ranorex.Report.Success("Expected bulletin Presence to be :{"+validateExists+"} and found :{"+actBulletinPresence+"}");
			}
			else
			{
				Ranorex.Report.Screenshot(Bulletinsrepo.Bulletin_Summary_List.Self);
				Ranorex.Report.Failure("Expected bulletin Presence to be :{"+validateExists+"} and found :{"+actBulletinPresence+"}");
			}
			
			if (closeBulletinSummaryList)
			{
				CloseBulletinSummaryListForm_NS();
			}
		}
		
		/// <summary>
		/// Format Datetime , Set Effective Date and Specific timezone
		/// </summary>
		/// <param name="inputTimeZone"></param>
		/// <param name="effTimeDifference"></param>
		/// <param name="expFeedback"></param>
		/// <param name="bulletinSeed"></param>
		/// <param name="bulletinType"></param>
		/// <param name="district"></param>
		/// <param name="milepost1"></param>
		/// <param name="milepost2"></param>
		/// <param name="tracks"></param>
		/// <param name="maximumSpeed"></param>
		/// <param name="closeBulletinForm"></param>
		[UserCodeMethod]
		public static void NS_SetEffectiveDateAndTimezone_BulletinInputForm(string inputTimeZone, string effTimeDifference, string expFeedback, string bulletinSeed, string bulletinType, string district, string milepost1, string milepost2, string tracks, string maximumSpeed, bool closeBulletinForm)
		{
		    if (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
		    {
		        Ranorex.Report.Error("Bulletin Input form is not open");
		        return;
		    }
		    
		    string initialFeedback = Bulletinsrepo.Bulletins_Input_Relay.Feedback.GetAttributeValue<string>("Text");
		    
			string effectiveTime = NS_Bulletin.NS_FormatDateTime_Bulletin(System.DateTime.Now, inputTimeZone, effTimeDifference);
			if (effectiveTime != "")
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTime);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			int attempts = 0;
			while((Bulletinsrepo.Bulletins_Input_Relay.Feedback.GetAttributeValue<string>("Text").Equals("") || Bulletinsrepo.Bulletins_Input_Relay.Feedback.GetAttributeValue<string>("Text").Equals(" ") || Bulletinsrepo.Bulletins_Input_Relay.Feedback.GetAttributeValue<string>("Text").Contains(initialFeedback)) && attempts < 3)
			{
				Delay.Milliseconds(500);
				attempts++;
			}
			
			if(!expFeedback.Equals("") && Bulletinsrepo.Bulletins_Input_Relay.Feedback.GetAttributeValue<string>("Text").Equals(""))
			{
				Ranorex.Report.Error("Expecting a feedback, but no feedback received");
				if (closeBulletinForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
			}
		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expFeedback))
			{
				if (closeBulletinForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
			}
			else
			{
				GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButtonInfo,
				                                          Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);

				int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				attempts = 0;
				while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 3) {
					Delay.Milliseconds(500);
					Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
					attempts++;
				}
				
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
					Ranorex.Report.Failure("Failed to Issue Bulletin, As refreshing did not produce the bulletin.");
					if (closeBulletinForm)
					{
						NS_Bulletin.CloseBulletinItemsForm_NS();
					}
					return;
				}
				
				Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
				string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
				//Add Bulletin information to the persistent bulletin list
				NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, bulletinType, milepost1, milepost2, district, tracks, maximumSpeed);
				
				Ranorex.Report.Info("TestStep", "Bulletin has been succefully issued in {"+inputTimeZone+"} timezone.");
				if (closeBulletinForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
		}
		
		/// <summary>
		/// Format Datetime , Set Until Date and Specific timezone
		/// </summary>
		/// <param name="inputTimeZone"></param>
		/// <param name="untTimeDifference"></param>
		/// <param name="expFeedback"></param>
		/// <param name="bulletinSeed"></param>
		/// <param name="bulletinType"></param>
		/// <param name="district"></param>
		/// <param name="milepost1"></param>
		/// <param name="milepost2"></param>
		/// <param name="tracks"></param>
		/// <param name="maximumSpeed"></param>
		/// <param name="closeBulletinForm"></param>
		[UserCodeMethod]
		public static void NS_SetUntilDateAndTimezone_BulletinInputForm(string inputTimeZone, string untTimeDifference, string expFeedback, string bulletinSeed, string bulletinType, string district, string milepost1, string milepost2, string tracks, string maximumSpeed, bool closeBulletinForm)
		{
		    if (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
		    {
		        Ranorex.Report.Error("Bulletin Input form is not open");
		        return;
		    }
		    
		    string initialFeedback = Bulletinsrepo.Bulletins_Input_Relay.Feedback.GetAttributeValue<string>("Text");
		    
			string untilTime = NS_Bulletin.NS_FormatDateTime_Bulletin(System.DateTime.Now, inputTimeZone, untTimeDifference);
			if (untilTime != "")
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTime);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			int attempts = 0;
			while((Bulletinsrepo.Bulletins_Input_Relay.Feedback.GetAttributeValue<string>("Text").Equals("") || Bulletinsrepo.Bulletins_Input_Relay.Feedback.GetAttributeValue<string>("Text").Equals(" ") || Bulletinsrepo.Bulletins_Input_Relay.Feedback.GetAttributeValue<string>("Text").Equals(initialFeedback)) && attempts < 3)
			{
				Delay.Milliseconds(500);
				attempts++;
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expFeedback))
			{
				if (closeBulletinForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButtonInfo,
			                                          Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
			
		    if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expFeedback))
			{
				if (closeBulletinForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
		    
		    if(!expFeedback.Equals(""))
			{
				Ranorex.Report.Failure("Expected feedback of " + expFeedback + " but did not get it");
				if (closeBulletinForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
			}
			
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 3) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Issue Bulletin, As refreshing did not produce the bulletin.");
				if (closeBulletinForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, bulletinType, milepost1, milepost2, district, tracks, maximumSpeed);
			
			Ranorex.Report.Info("TestStep", "Bulletin has been succefully issued in {"+inputTimeZone+"} timezone.");
			if (closeBulletinForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
		}
		
		/// <summary>
		/// Opens bulletin summarry reportif not alredy open
		/// </summary>
		[UserCodeMethod]
		public static void NS_OpenBulletinSummaryReport_MainMenu()
		{
			int retries = 0;

			if (!Bulletinsrepo.Bulletin_Summary_Report.SelfInfo.Exists(0))
			{
				//Click Bulletin menu
				MainMenurepo.PDS_Main_Menu.MainMenuBar.BulletinButton.Click();
				//Click Summary Report in bulletins menu
				MainMenurepo.PDS_Main_Menu.BulletinMenu.SummaryReport.Click();
				//Wait for Bulletin Summary Report Form to exist in case of lag
				if (!Bulletinsrepo.Bulletin_Summary_Report.SelfInfo.Exists(0))
				{
					Ranorex.Delay.Milliseconds(500);
					while (!Bulletinsrepo.Bulletin_Summary_Report.SelfInfo.Exists(0) && retries < 6)
					{
						Ranorex.Delay.Milliseconds(500);
						retries++;
					}

					if (!Bulletinsrepo.Bulletin_Summary_Report.SelfInfo.Exists(0))
					{
						Ranorex.Report.Error("Bulletin Summary Report form did not open");
						return;
					}
				}
			}

			return;
		}

		/// <summary>
		/// Enters districts and 'Between mileposts' and 'And' mileposts in Bulletin summary report form
		/// </summary>
		/// <param name="district">Input: District</param>
		/// <param name="betweenMilepost1">Input: betweenMilepost1</param>
		/// <param name="andMilepost1">Input: andMilepost1</param>
		/// <param name="betweenMilepost2">Input: betweenMilepost2</param>
		/// <param name="andMilepost2">Input: andMilepost2</param>
		/// <param name="betweenMilepost3">Input: </param>
		/// <param name="andMilepost3">Input: andMilepost3</param>
		/// <param name="betweenMilepost4">Input: betweenMilepost4</param>
		/// <param name="andMilepost4">Input: andMilepost4</param>
		/// <param name="clickGenerateOrViewReport">Input: True/False</param>
		/// <param name="reset">Input: True/False</param>
		/// <param name="closeForm">Input: True/False</param>
		[UserCodeMethod]
		public static void NS_InputDistrictBetweenAndMileposts_BulletinSummaryReport(string district, string betweenMilepost1, string andMilepost1, string betweenMilepost2, string andMilepost2,string betweenMilepost3, string andMilepost3,string betweenMilepost4, string andMilepost4, string expectedFeedback, bool clickGenerateOrViewReport = false, bool reset = false, bool closeForm = false)
		{
			NS_OpenBulletinSummaryReport_MainMenu();
			//Selecting the district
			Bulletinsrepo.DistrictName = district;
			Bulletinsrepo.Bulletin_Summary_Report.District.DistrictMenuItem.Click();
			Bulletinsrepo.Bulletin_Summary_Report.District.DistrictMenuList.DistrictListItemByDistrictName.Click();
			
			
			if(betweenMilepost1 != "")
			{
				Bulletinsrepo.Bulletin_Summary_Report.Between1Text.Element.SetAttributeValue("Text", betweenMilepost1.ToUpper());
				
			}
			Bulletinsrepo.Bulletin_Summary_Report.Between1Text.PressKeys("{TAB}");
			
			int attempts=0;
			while((Bulletinsrepo.Bulletin_Summary_Report.Feedback.GetAttributeValue<string>("Text").Trim().Equals("") && attempts < 3))
			{
				Delay.Milliseconds(500);
				attempts++;
			}
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletin_Summary_Report.Feedback, expectedFeedback))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_Report.CloseButtonInfo,
				                                                 Bulletinsrepo.Bulletin_Summary_Report.SelfInfo);
				return;
			}
			if(andMilepost1 != "")
			{
			Bulletinsrepo.Bulletin_Summary_Report.And1Text.Element.SetAttributeValue("Text", andMilepost1.ToUpper());
			}
			
			Bulletinsrepo.Bulletin_Summary_Report.And1Text.PressKeys("{TAB}");
			
			attempts=0;
			while((Bulletinsrepo.Bulletin_Summary_Report.Feedback.GetAttributeValue<string>("Text").Trim().Equals("") && attempts < 3))
			{
				Delay.Milliseconds(500);
				attempts++;
			}
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletin_Summary_Report.Feedback, expectedFeedback))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_Report.CloseButtonInfo,
				                                                 Bulletinsrepo.Bulletin_Summary_Report.SelfInfo);
				return;
			}
			
			if(betweenMilepost2 != "")
			{
				Bulletinsrepo.Bulletin_Summary_Report.Between2Text.Element.SetAttributeValue("Text", betweenMilepost1.ToUpper());
				
			}
			Bulletinsrepo.Bulletin_Summary_Report.Between2Text.PressKeys("{TAB}");
			
			attempts=0;
			while((Bulletinsrepo.Bulletin_Summary_Report.Feedback.GetAttributeValue<string>("Text").Trim().Equals("") && attempts < 3))
			{
				Delay.Milliseconds(500);
				attempts++;
			}
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletin_Summary_Report.Feedback, expectedFeedback))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_Report.CloseButtonInfo,
				                                                 Bulletinsrepo.Bulletin_Summary_Report.SelfInfo);
				return;
			}
			if(andMilepost2 != "")
			{
			Bulletinsrepo.Bulletin_Summary_Report.And2Text.Element.SetAttributeValue("Text", andMilepost1.ToUpper());
			}
			
			Bulletinsrepo.Bulletin_Summary_Report.And2Text.PressKeys("{TAB}");
			
			attempts=0;
			while((Bulletinsrepo.Bulletin_Summary_Report.Feedback.GetAttributeValue<string>("Text").Trim().Equals("") && attempts < 3))
			{
				Delay.Milliseconds(500);
				attempts++;
			}
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletin_Summary_Report.Feedback, expectedFeedback))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_Report.CloseButtonInfo,
				                                                 Bulletinsrepo.Bulletin_Summary_Report.SelfInfo);
				return;
			}
			
			
			if(betweenMilepost3 != "")
			{
				Bulletinsrepo.Bulletin_Summary_Report.Between3Text.Element.SetAttributeValue("Text", betweenMilepost1.ToUpper());
				
			}
			Bulletinsrepo.Bulletin_Summary_Report.Between3Text.PressKeys("{TAB}");
			
			attempts=0;
			while((Bulletinsrepo.Bulletin_Summary_Report.Feedback.GetAttributeValue<string>("Text").Trim().Equals("") && attempts < 3))
			{
				Delay.Milliseconds(500);
				attempts++;
			}
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletin_Summary_Report.Feedback, expectedFeedback))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_Report.CloseButtonInfo,
				                                                 Bulletinsrepo.Bulletin_Summary_Report.SelfInfo);
				return;
			}
			if(andMilepost3 != "")
			{
			Bulletinsrepo.Bulletin_Summary_Report.And3Text.Element.SetAttributeValue("Text", andMilepost1.ToUpper());
			}
			
			Bulletinsrepo.Bulletin_Summary_Report.And1Text.PressKeys("{TAB}");
			
			attempts=0;
			while((Bulletinsrepo.Bulletin_Summary_Report.Feedback.GetAttributeValue<string>("Text").Trim().Equals("") && attempts < 3))
			{
				Delay.Milliseconds(500);
				attempts++;
			}
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletin_Summary_Report.Feedback, expectedFeedback))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_Report.CloseButtonInfo,
				                                                 Bulletinsrepo.Bulletin_Summary_Report.SelfInfo);
				return;
			}
			
			if(betweenMilepost4 != "")
			{
				Bulletinsrepo.Bulletin_Summary_Report.Between4Text.Element.SetAttributeValue("Text", betweenMilepost1.ToUpper());
				
			}
			Bulletinsrepo.Bulletin_Summary_Report.Between3Text.PressKeys("{TAB}");
			
			attempts=0;
			while((Bulletinsrepo.Bulletin_Summary_Report.Feedback.GetAttributeValue<string>("Text").Trim().Equals("") && attempts < 3))
			{
				Delay.Milliseconds(500);
				attempts++;
			}
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletin_Summary_Report.Feedback, expectedFeedback))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_Report.CloseButtonInfo,
				                                                 Bulletinsrepo.Bulletin_Summary_Report.SelfInfo);
				return;
			}
			if(andMilepost4 != "")
			{
			Bulletinsrepo.Bulletin_Summary_Report.And4Text.Element.SetAttributeValue("Text", andMilepost1.ToUpper());
			}
			
			Bulletinsrepo.Bulletin_Summary_Report.And1Text.PressKeys("{TAB}");
			
			attempts=0;
			while((Bulletinsrepo.Bulletin_Summary_Report.Feedback.GetAttributeValue<string>("Text").Trim().Equals("") && attempts < 3))
			{
				Delay.Milliseconds(500);
				attempts++;
			}
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletin_Summary_Report.Feedback, expectedFeedback))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_Report.CloseButtonInfo,
				                                                 Bulletinsrepo.Bulletin_Summary_Report.SelfInfo);
				return;
			}
			
			if(clickGenerateOrViewReport)
			{
				GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletin_Summary_Report.GenerateViewReportButtonInfo,
				                                          Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.SelfInfo);
			}

			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletin_Summary_Report.Feedback, expectedFeedback))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_Report.CloseButtonInfo,
				                                                 Bulletinsrepo.Bulletin_Summary_Report.SelfInfo);
				return;
			}
			if(reset)
			{
				GeneralUtilities.ClickAndWaitForDisabledWithRetry(Bulletinsrepo.Bulletin_Summary_Report.ResetButtonInfo,
				                                                  Bulletinsrepo.Bulletin_Summary_Report.GenerateViewReportButtonInfo);
				
				if(!Bulletinsrepo.Bulletin_Summary_Report.GenerateViewReportButton.Enabled)
				{
					Ranorex.Report.Success("Bulletin Summary Report form reseted successfully");
				}
				else
				{
					Ranorex.Report.Screenshot(Bulletinsrepo.Bulletin_Summary_Report.Self);
					Ranorex.Report.Failure("Bulletin Summary Report form failed to reset");
				}
			}

			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_Report.CloseButtonInfo,
				                                                  Bulletinsrepo.Bulletin_Summary_Report.SelfInfo);
			}
		}
		
		///<summary>
		///Validates contents on Bulletin item report form
		/// </summary>
		/// <param name="bulletinSeed">Input : Bulletinseed</param>
		[UserCodeMethod]
		public static void NS_ValidateSpeedAreaBulletinContents_BulletinItemsReport_BulletinSummaryReport(string bulletinSeed, bool closeForm = true)
		{
		    string bulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
			string milepost1 = NS_Bulletin.GetBulletinMilepost1(bulletinSeed);
			string milepost2 = NS_Bulletin.GetBulletinMilepost2(bulletinSeed);
			string trackLine = NS_Bulletin.GetBulletinTrackLine(bulletinSeed);
			string maximumSpeed = NS_Bulletin.GetBulletinMaximumSpeed(bulletinSeed);
			
			Bulletinsrepo.BulletinNumber = bulletinNumber;
			if(!Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("Bulletin Items Report form is not opened");
				return;
			}
			
			string actualBulletinViewText = Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.BulletinItemsReportText.BulletinReviewTextByBulletinNumber.GetAttributeValue<string>("InnerText");
			Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.BulletinItemsReportText.BulletinReviewTextByBulletinNumber.EnsureVisible();
			actualBulletinViewText = Regex.Replace(actualBulletinViewText, @"[^A-Za-z0-9]", ""); //Replaces all the invisible character with nothing, all the words will be appended and forms a single string without any spaces
			string expBulletinViewText = ("From"+milepost1+"to"+milepost2+"on"+trackLine+"observe a maximum speed of"+maximumSpeed+"MPH").Replace(" ","");
			expBulletinViewText = Regex.Replace(actualBulletinViewText, @"[^A-Za-z0-9]", "");  //Replaces all the invisible character with nothing, all the words will be appended and forms a single string without any spaces

			if (actualBulletinViewText.Contains(expBulletinViewText))
			{
				Ranorex.Report.Success("Contents in Bulletin Item Report Form Matches: ",expBulletinViewText);
			}
			else
			{
				Ranorex.Report.Screenshot(Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.Self);
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.CloseButtonInfo,
				                                                  Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.SelfInfo);
				Ranorex.Report.Failure("Bulletin Item Report Text does not match");
				return;
			}
			
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.CloseButtonInfo,
				                                                  Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.SelfInfo);
			}
			
		}
		
		/// <summary>
		/// Closes bulletin Summary report form
		/// </summary>
		[UserCodeMethod]
		public static void NS_CloseBulletinSummaryReport()
		{
			if (!Bulletinsrepo.Bulletin_Summary_Report.SelfInfo.Exists(0))
			{
				Ranorex.Report.Warn("Bulletin Summary Report Form is not open, so it cannot be closed");
				return;
			}
			//Bulletin Form had to have Ensure Visible turned off in the repo in order to work so we need to activate it specifically
			Bulletinsrepo.Bulletin_Summary_Report.Self.Activate();
			
			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_Report.CloseButtonInfo,
			                                                  Bulletinsrepo.Bulletin_Summary_Report.SelfInfo);
			return;
		}
		
		/// <summary>
		/// Validtes feedback in bulletin items relay form
		/// </summary>
		/// <param name="expectedFeedback">Input : expectedFeedback</param>
		/// <param name="closeBulletinRelayForm">Input: True/False</param>
		[UserCodeMethod]
		public static void NS_ValidateFeedback_BulletinInputRelayForm(string expectedFeedback, bool closeBulletinRelayForm = true)
		{
			if (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
			{
				Ranorex.Report.Failure("Bulletins Input Relay Form Doesn't exists");
				return;
			}
			else
			{
				Regex expectedFeedbackRegex = new Regex(expectedFeedback);
				string feedbackText = Bulletinsrepo.Bulletins_Input_Relay.Feedback.GetAttributeValue<string>("Text");
				if (expectedFeedbackRegex.IsMatch(feedbackText))
				{
					Ranorex.Report.Success("Expected Regex feedback of {"+@expectedFeedbackRegex+"} found feedback {"+feedbackText+"}.");
				}
				else
				{
					Ranorex.Report.Screenshot(Bulletinsrepo.Bulletins_Input_Relay.Self);
					CloseBulletinItemsForm_NS();
					Ranorex.Report.Failure("Expected Regex feedback of {"+@expectedFeedbackRegex+"} found feedback {"+feedbackText+"}.");
				}
			}
			if (closeBulletinRelayForm)
			{
				Ranorex.Report.Info("Going to close");
				CloseBulletinItemsForm_NS();
			}
		}
		
		/// <summary>
		/// Clicks on complete button in bulletin input relay form
		/// </summary>
		[UserCodeMethod]
		public static void NS_PressComplete_BulletinInputRelayForm(bool closeBulletinRelayForm = false)
		{
			if (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
			{
				Ranorex.Report.Failure("Bulletins Input Relay Form Doesn't exists, so canno't be closed");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
			
			if (closeBulletinRelayForm)
			{
				CloseBulletinItemsForm_NS();
			}
		}

        /// <summary>
		/// Validate Bulletin Relay Popup text from Track Line
		/// </summary>
		/// <param name="trainSeed">Input: trainSeed</param>
		/// <param name="bulletinSeed">Input : bulletinSeed</param>
		[UserCodeMethod]
		public static void NS_ValidateBulletinRelayPopupText_Trackline(string trainSeed,string bulletinSeed, string deviceId, bool validateFormExists = true,bool validateText = true, bool closeForm = true)
		{
			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
			string bulletinNumber = GetBulletinNumber(bulletinSeed);
			if(trainId == null)
			{
				Ranorex.Report.Error("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
				return;
			}
			bool actualValidate = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Relay_Bulletin_Popup.SelfInfo.Exists(0);
			if(validateFormExists == actualValidate)
			{
				Ranorex.Report.Success("Expected form to be present as{"+validateFormExists+"} and found {"+actualValidate+"}");
				if(validateText)
				{
					string expPopupText = "Invalid Signal Clear request for device "+deviceId+". Request is for train "+trainId+", which needs bulletins: "+bulletinNumber+".";
					string actPopupText = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Relay_Bulletin_Popup.BulletinText.GetAttributeValue<string>("Text");
					if(actPopupText.Contains(expPopupText))
					{
						Ranorex.Report.Success("Succesfully Bulletin relay popup text found actual :{"+actPopupText+"} and expected :{"+expPopupText+"}");
					}
					else
					{
						Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Relay_Bulletin_Popup.Self);
						NS_CloseBulletinRelayPopup();
						Ranorex.Report.Failure("Bulletin relay popup text not found actual :{"+actPopupText+"} and expected :{"+expPopupText+"}");
						return;
					}
				}
			}
			else
			{
				if(actualValidate)
				{
					NS_CloseBulletinRelayPopup();
				}
				Ranorex.Report.Failure("Expected form to be present as{"+validateFormExists+"} and found {"+actualValidate+"}");
			}
			
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Relay_Bulletin_Popup.CancelButtonInfo,
				                                                  Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Relay_Bulletin_Popup.SelfInfo);
				Ranorex.Report.Info("Relay Bulletin Popup is closed");
			}
		}
		
		/// <summary>
		/// Suspend Bulletin when you send RD-BIIQ meassage 
		/// </summary>
		/// <param name="closeForm">Input : closeForm</param>
		[UserCodeMethod]
		public static void ClickSuspendButton_CreateBulletinform(bool closeForm)
		{
			int retries = 0;
			while(!Bulletinsrepo.Bulletins_Input_Relay.RibbonMenu.SuspendButtonInfo.Exists(0) && retries < 5)
			{
				Ranorex.Delay.Milliseconds(500);
				retries++;
			}
			
			if(Bulletinsrepo.Bulletins_Input_Relay.RibbonMenu.SuspendButton.Enabled)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.RibbonMenu.SuspendButtonInfo,
				                                                  Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
				Ranorex.Report.Success("Successfully clicked on SUSPEND/PAUSE button in Create Bulletin form");			
			}
			else
			{
				Report.Screenshot(Bulletinsrepo.Bulletins_Input_Relay.Self);
				Ranorex.Report.Failure("SUSPEND/PAUSE Button is not enabled to click");
				return;
			}
			if(closeForm)
			{
				if(Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo,
					                                                  Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
				}
			}
			
		}
		
		/// <summary>
		/// Validate Feedback Message from Input Bulletin Form
		/// </summary>
		/// <param name="expectedFeedback"></param>
		[UserCodeMethod]
    	public static void NS_OpenTaskListWithValidateFeedback(string description,string employeeName, string expectedFeedback, bool expectTask)
    	{
    		int retries = 0;
    		NS_Miscellaneous.NS_OpenTaskByDescriptionAndEmployeeName(description, employeeName, expectTask);
    		
    		while(!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0) && retries< 5)
    		{
    			Delay.Milliseconds(500);
    			retries++;
    		}
    		if(Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
    		{
    			CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback);
    		}
    		else
    		{
    			Ranorex.Report.Error("Bulletin input form is not appered to validate feedback message.");
    		}
    		return;
    	}
    	    	
    	
    	/// <summary>
    	/// Check if trains are there in bulletin relay form under Trains that need Bulletin Items.
    	/// </summary>
    	/// <param name="closeBulletinRelayForm"></param>
    	[UserCodeMethod]
    	public static void NS_ValidateTrainNamesInList_BulletinRelayForm(string trainSeed, bool trainDoesExist = true, bool closeBulletinRelayForm = true)
    	{
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if(trainSeed == "")
    		{
    			Ranorex.Report.Failure("TrainSeed is blank, please input a valid trainSeed or Train Id");
    			return;
    		}
    
    		if (trainId == null)
    		{
    		    trainId = trainSeed;
    		}
    		
    		Bulletinsrepo.TrainID = trainId;
    		
    		NS_OpenBulletinRelayForm_MainMenu();
    		int innerRetry = 0;
    		string currentMouseState = Mouse.Cursor.ToString();
    		while (currentMouseState == "[Cursor: WaitCursor]" && innerRetry < 5)
    		{
    			Thread.Sleep(500);
    			currentMouseState = Mouse.Cursor.ToString();
    			innerRetry++;
    		}
    		
    		//Select All Controlled Districts
    		Bulletinsrepo.DistrictName = "All Controlled Districts";
    		if (Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuItem.SelectedItemText != Bulletinsrepo.DistrictName) {
    			GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuItemInfo,
    			                                          Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuList.DistrictListItemByDistrictNameInfo);
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuList.DistrictListItemByDistrictNameInfo,
    			                                                  Bulletinsrepo.Bulletins_Input_Relay.Relay.District.DistrictMenuList.SelfInfo);
    		}
    		
    		//Arrange by Trains that need Bulletin Items
    		if (!Bulletinsrepo.Bulletins_Input_Relay.Relay.ArrangeBy.TrainsThatNeedBulletinItemsRadioButton.Checked)
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Relay.ArrangeBy.TrainsThatNeedBulletinItemsRadioButton.Click();
    		}
    		
    		
    		int retries=0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.TrainsThatNeedBulletinItems.TreeItemByTrainID.SelfInfo.Exists(0) && retries< 5)
    		{
    			Delay.Milliseconds(500);
    			retries++;
    		}
    		
    		bool actualTrainExistance = Bulletinsrepo.Bulletins_Input_Relay.Relay.BulletinTree.TrainsThatNeedBulletinItems.TreeItemByTrainID.SelfInfo.Exists(0);
    		
    		if(trainDoesExist == actualTrainExistance)
    		{
    		    Ranorex.Report.Success("Expected and found train {" + trainId + "} " + (actualTrainExistance ? "Exists":"Does not Exist") + " in Bulletin Relay Form");
    		}
    		else
    		{
    		    Ranorex.Report.Failure("Expected train {" + trainId + "} " + (trainDoesExist ? "to Exist":"to not Exist") + " and found it " + (actualTrainExistance ? "does Exist":"does not Exist"));
    		}

    		if (closeBulletinRelayForm)
    		{
    			Ranorex.Report.Info("Closing Bulletin Relay Form");
    			
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo,
    			                                                  Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
    		}
    		return;
    	}
    	
    	/// <summary>
    	/// Click on Print button in Bulletin Items Report form
    	/// </summary>
    	/// <param name="pressOk">Input : True or False</param>
    	/// <param name="closeForm">Input : True or False</param>
    	[UserCodeMethod]
    	public static void NS_ClickOnPrint_BulletinItemsReport(bool pressOk = true, bool closeForm =false)
    	{
    		if(!Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Bulletin Items Report form is not opened");
    			return;
    		}
    		
    		GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.PrintButtonInfo,
    		                                          Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.PDS_Print_Fax_Dialog.SelfInfo);
    		
    		Bulletinsrepo.NameIndex = "1";
    		
    		GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.PDS_Print_Fax_Dialog.Name.NameTextInfo,
    		                                         Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.PDS_Print_Fax_Dialog.Name.NameList.SelfInfo);
    		
    		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.PDS_Print_Fax_Dialog.Name.NameList.NameListItemByIndexInfo,
    		                                                 Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.PDS_Print_Fax_Dialog.Name.NameList.SelfInfo);
    		
    		if(pressOk)
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.PDS_Print_Fax_Dialog.OkButtonInfo,
    			                                                  Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.PDS_Print_Fax_Dialog.SelfInfo);
    		}
    		
    		if(closeForm)
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.PDS_Print_Fax_Dialog.CancelButtonInfo,
    			                                                  Bulletinsrepo.Bulletin_Summary_Report.Bulletin_Items_Report.PDS_Print_Fax_Dialog.SelfInfo);
    		}
    	}
    	
    	/// <summary>
    	/// Adds Shift Engineering reservation time either from Bulletin Input Relay Form or Bulletin summary List
    	/// </summary>
    	/// <param name="bulletinSeed">Input: BulletinSeed</param>
    	/// <param name="newBulletinSeed">Input : New bulletinseed to create reord</param>
    	/// <param name="optionShiftFrom">Input : bulletinInputRelay/bulletinsummarylist</param>
    	/// <param name="reservationInTime">Input : Ex: "60 min later"</param>
    	/// <param name="validateListItemDisabled">Input : True/False</param>
    	/// <param name="closeForm">Input : True/False</param>
    	[UserCodeMethod]
    	public static void NS_ShiftEngineeringReservationInTime_MofwBulletin(string bulletinSeed, string newBulletinSeed,string optionShiftFrom, string reservationInTime, bool validateListItemDisabled, bool closeForm)
    	{
    		string targetBulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
    		string type = NS_Bulletin.GetBulletinType(bulletinSeed);
    		string district = NS_Bulletin.GetBulletinDistrict(bulletinSeed);
    		if (targetBulletinNumber == null)
    		{
    			targetBulletinNumber = bulletinSeed;
    		}
    		
    		Bulletinsrepo.BulletinNumber = targetBulletinNumber;
    		
    		string rowIndex = "";
    		switch(optionShiftFrom.ToLower())
    		{
    			case "bulletininputrelay" :
    				NS_OpenBulletinInputForm_MainMenu();
    				Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    				NS_InputBulletins.InputBulletinHeader(district, type);
    				rowIndex = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByBulletinNumber.ReferenceNumber.GetAttributeValue<int>("RowIndex").ToString();
    				Bulletinsrepo.BulletinRowIndex = rowIndex;
    				GeneralUtilities.RightClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.MenuCellInfo,
    				                                               Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.SelfInfo);
    				NS_ShiftEngineeringReservationInTime_BulletinInputRelay(bulletinSeed,newBulletinSeed,rowIndex,reservationInTime,validateListItemDisabled);
    				if(closeForm)
    				{
    					NS_CloseBulletinInputRelayForm();
    				}
    				break;
    				
    			case "bulletinsummarylist":
    				NS_OpenBulletinSummaryList_MainMenu();
    				Bulletinsrepo.Bulletin_Summary_List.Self.Activate();
    				rowIndex = Convert.ToString(Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByBulletinNumber.CellByColumnName.BulletinNumber.GetAttributeValue<int>("RowIndex"));
    				Bulletinsrepo.RowIndex = rowIndex;
    				GeneralUtilities.RightClickAndWaitForWithRetry(Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByRowIndex.MenuCellInfo,
    				                                               Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.MenuCellMenu.SelfInfo);
    				NS_ShiftEngineeringReservationInTime_BulletinSummaryList(bulletinSeed,newBulletinSeed,rowIndex,reservationInTime,validateListItemDisabled);
    				if(closeForm)
    				{
    					CloseBulletinSummaryListForm_NS();
    				}
    				break;
    				
    			default: 
    				Ranorex.Report.Error("Invalid choice");
    				break;
    		}
    		
    	}
    	
    	public static void NS_ShiftEngineeringReservationInTime_BulletinInputRelay(string bulletinSeed, string newBulletinSeed, string rowIndex, string reservationInTime, bool validateListItemDisabled)
    	{
    		GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.ShiftEngineeringReservationInTimeText.SelfInfo,
    		                                          Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.ShiftEngineeringReservationInTimeText.ShiftEngineeringReservationInTimeMenu.SelfInfo);
    		if(validateListItemDisabled)
    		{
    			int childCount = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.ShiftEngineeringReservationInTimeText.ShiftEngineeringReservationInTimeMenu.Self.Children.Count;
    			
    			for(int i = 0; i < childCount; i++)
    			{
    				Bulletinsrepo.ReservationInTimeIndex = i.ToString();
    				string elementName = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.ShiftEngineeringReservationInTimeText.ShiftEngineeringReservationInTimeMenu.ShiftEngineeringReservationInTimeMenuItemByReservationInTimeIndex.GetAttributeValue<string>("Text");
    				if(Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.ShiftEngineeringReservationInTimeText.ShiftEngineeringReservationInTimeMenu.ShiftEngineeringReservationInTimeMenuItemByReservationInTimeIndex.Enabled)
    				{
    					Ranorex.Report.Failure("List item {"+elementName+"} is enabled");
    				}
    				else
    				{
    					Ranorex.Report.Success("List item {"+elementName+"} is disabled");
    				}
    			}
    			return;
    		}
    		
    		int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
    		Bulletinsrepo.ReservationInTime = reservationInTime;
    		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.ShiftEngineeringReservationInTimeText.ShiftEngineeringReservationInTimeMenu.ShiftEngineeringReservationInTimeMenuItemByReservationInTimeInfo,
    		                                                  Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.SelfInfo);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    		int attempts = 0;
    		//Table items before refresh and after refresh should be same since we are replacing a bulletin.
    		while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count != tableItemsBeforeRefresh && attempts < 5)
    		{
    			Delay.Milliseconds(500);
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			attempts++;
    		}
    		
    		Bulletinsrepo.BulletinRowIndex = rowIndex;
    		string oldBulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text") != oldBulletinNumber)
    		{
    			Ranorex.Report.Success("Bulletin replaced by Shifting engineering reservation time");
    		}
    		else
    		{
    			Ranorex.Report.Screenshot(Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self);
    			NS_CloseBulletinInputRelayForm();
    			Ranorex.Report.Failure("Bulletin Not replaced");
    			return;
    		}

    		//the replaced bulletin will be the last bulletin in the table hence we can retrive the bulletin number using the last index
    		Bulletinsrepo.BulletinRowIndex = (tableItemsBeforeRefresh-1).ToString();
    		string newBulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
    		//Creating a new bulletin record with new seed with old bulletin characteristics
    		string bulletinType = NS_Bulletin.GetBulletinType(bulletinSeed);
    		string milepost1 = NS_Bulletin.GetBulletinMilepost1(bulletinSeed);
    		string milepost2 = NS_Bulletin.GetBulletinMilepost2(bulletinSeed);
    		string maxSpeed = NS_Bulletin.GetBulletinMaximumSpeed(bulletinSeed);
    		string district = NS_Bulletin.GetBulletinDistrict(bulletinSeed);
    		string trackline = NS_Bulletin.GetBulletinTrackLine(bulletinSeed);
    		
    		CreateBulletinRecord(newBulletinSeed,newBulletinNumber,bulletinType,milepost1,milepost2,district,trackline,maxSpeed,"");
    		return;
    		
    	}
    	
    	public static void NS_ShiftEngineeringReservationInTime_BulletinSummaryList(string bulletinSeed, string newBulletinSeed, string rowIndex, string reservationInTime, bool validateListItemDisabled)
    	{
    		GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.MenuCellMenu.ShiftEngineeringReservationInTimeInfo,
    		                                          Bulletinsrepo.Bulletin_Summary_List.ShiftEngineeringReservationInTimeMenu.SelfInfo);
    		if(validateListItemDisabled)
    		{
    			int childCount = Bulletinsrepo.Bulletin_Summary_List.ShiftEngineeringReservationInTimeMenu.Self.Children.Count;
    			for(int i = 0; i < childCount; i++)
    			{
    				Bulletinsrepo.ReservationInTimeIndex = i.ToString();
    				string elementName = Bulletinsrepo.Bulletin_Summary_List.ShiftEngineeringReservationInTimeMenu.ShiftEngineeringReservationInTimeMenuItemByIndex.GetAttributeValue<string>("Text");
    				if(Bulletinsrepo.Bulletin_Summary_List.ShiftEngineeringReservationInTimeMenu.ShiftEngineeringReservationInTimeMenuItemByIndex.Enabled)
    				{
    					Ranorex.Report.Failure("List item {"+elementName+"} is enabled");
    				}
    				else
    				{
    					Ranorex.Report.Success("List item {"+elementName+"} is disabled");
    				}
    			}
    			return;
    		}
    		
    		int tableItems = Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.Self.Rows.Count;
    		
    		Bulletinsrepo.ReservationInTime = reservationInTime;
    		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_List.ShiftEngineeringReservationInTimeMenu.ShiftEngineeringReservationInTimeMenuItemByNameInfo,
    		                                                  Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByBulletinNumber.CellByColumnName.BulletinNumberInfo);
    		
    		Bulletinsrepo.RowIndex = rowIndex;
    		string oldBulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
    		if(Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByRowIndex.CellByColumnName.BulletinNumber.GetAttributeValue<string>("Text") != oldBulletinNumber)
    		{
    			Ranorex.Report.Success("Bulletin replaced by Shifting engineering reservation time");
    		}
    		else
    		{
    			Ranorex.Report.Screenshot(Bulletinsrepo.Bulletin_Summary_List.Self);
    			CloseBulletinSummaryListForm_NS();
    			Ranorex.Report.Failure("Bulletin Not replaced");
    			return;
    		}

    		//the replaced bulletin will be the last bulletin in the table hence we can retrive the bulletin number using the last index
    		Bulletinsrepo.BulletinRowIndex = (tableItems-1).ToString();
    		string newBulletinNumber = Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByRowIndex.CellByColumnName.BulletinNumber.GetAttributeValue<string>("Text");
    		//Creating a new bulletin record with new seed with old bulletin characteristics
    		string bulletinType = NS_Bulletin.GetBulletinType(bulletinSeed);
    		string milepost1 = NS_Bulletin.GetBulletinMilepost1(bulletinSeed);
    		string milepost2 = NS_Bulletin.GetBulletinMilepost2(bulletinSeed);
    		string maxSpeed = NS_Bulletin.GetBulletinMaximumSpeed(bulletinSeed);
    		string district = NS_Bulletin.GetBulletinDistrict(bulletinSeed);
    		string trackline = NS_Bulletin.GetBulletinTrackLine(bulletinSeed);
    		
    		CreateBulletinRecord(newBulletinSeed,newBulletinNumber,bulletinType,milepost1,milepost2,district,trackline,maxSpeed,"");
    		return;
    	}
    	
    	/// <summary>
    	/// Click on Conver to track authority from Bulletin input form or bulletin summary list and validates whethr the craete tarck authority form is opend or not
    	/// </summary>
    	/// <param name="bulletinSeed"></param>
    	/// <param name="optionConvertFrom"></param>
    	/// <param name="closeForm"></param>
    	[UserCodeMethod]
    	public static void NS_ConvertBulletinToTrackAuthorityAndValidateFormOpened(string bulletinSeed, string optionConvertFrom, bool closeForm)
    	{
    		string targetBulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
    		string type = NS_Bulletin.GetBulletinType(bulletinSeed);
    		string district = NS_Bulletin.GetBulletinDistrict(bulletinSeed);
    		if (targetBulletinNumber == null)
    		{
    			targetBulletinNumber = bulletinSeed;
    		}
    		Bulletinsrepo.BulletinNumber = targetBulletinNumber;
    		
    		string rowIndex = "";
    		int retries = 0;
    		switch(optionConvertFrom.ToLower())
    		{
    			case "bulletininputrelay" :
    				NS_OpenBulletinInputForm_MainMenu();
    				Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    				NS_InputBulletins.InputBulletinHeader(district, type);
    				rowIndex = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByBulletinNumber.ReferenceNumber.GetAttributeValue<int>("RowIndex").ToString();
    				Bulletinsrepo.BulletinRowIndex = rowIndex;
    				GeneralUtilities.RightClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.MenuCellInfo,
    				                                               Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.SelfInfo);
    				retries = 0;
    				Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.MenuItemMenu.ConvertToTrackAuthority.Click();
    				while(!TrackAuthoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0) && !TrackAuthoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 10)
    				{
    					Ranorex.Delay.Milliseconds(500);
    					retries++;
    				}
    				
    				if(!TrackAuthoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
    				{
    					NS_CloseBulletinInputRelayForm();
    					Ranorex.Report.Error("Create Track Authority form not opened");
    					return;
    				}
    				else
    				{
    					Ranorex.Report.Success("Track Authority issue form is Opened");
    				}
    				
    				if(closeForm)
    				{
    					NS_CloseBulletinInputRelayForm();
    				}
    				break;
    				

    			case "bulletinsummarylist" :
    				NS_OpenBulletinSummaryList_MainMenu();
    				Bulletinsrepo.Bulletin_Summary_List.Self.Activate();
    				rowIndex = Convert.ToString(Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByBulletinNumber.CellByColumnName.BulletinNumber.GetAttributeValue<int>("RowIndex"));
    				Bulletinsrepo.RowIndex = rowIndex;
    				GeneralUtilities.RightClickAndWaitForWithRetry(Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByRowIndex.MenuCellInfo,
    				                                               Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.MenuCellMenu.SelfInfo);
    				retries = 0;
    				Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.MenuCellMenu.ConvertToTrackAuthority.Click();
    				while(!TrackAuthoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0) && !TrackAuthoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 10)
    				{
    					Ranorex.Delay.Milliseconds(500);
    					retries++;
    				}
    				
    				if(!TrackAuthoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
    				{
    					NS_CloseBulletinInputRelayForm();
    					Ranorex.Report.Error("Create Track Authority form not opened");
    					return;
    				}
    				else
    				{
    					Ranorex.Report.Success("Track Authority issue form is Opened");
    				}
    				
    				if(closeForm)
    				{
    					CloseBulletinSummaryListForm_NS();
    				}
    				break;
    				
    			default: 
    				Ranorex.Report.Failure("Invalid choice");
    				break;
    		}
    	}
    	/// Close popup
    	/// </summary>
    	public static void NS_CloseBulletinRelayPopup()
    	{
    		int attempts =0;
    		while(!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Relay_Bulletin_Popup.SelfInfo.Exists(0) && attempts <=3)
    		{
    			Delay.Milliseconds(500);
    			attempts++;
    		}
    		
    		if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Relay_Bulletin_Popup.SelfInfo.Exists(0))
    		{
    			Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Relay_Bulletin_Popup.Self.EnsureVisible();
    		}
    		else
    		{
    			Ranorex.Report.Failure("Relay Bulletin Popup is not present");
    			return;
    		}
    		
    		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Relay_Bulletin_Popup.CancelButtonInfo,
    			                                                  Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Relay_Bulletin_Popup.SelfInfo);
    	}
    	
    	/// <summary>
    	/// Opens bulletin relay form from bulletin relay pop up in trackline
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_OpenBulletinItemRelayForm_BulletinRelayPopup_Trackline()
    	{
    		if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Relay_Bulletin_Popup.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Relay_Bulletin_Popup.OpenBulletinRelayButtonInfo,
    			                                          Bulletinsrepo.Bulletin_Item_Relay.SelfInfo);
    		}
    		else
    		{
    			Ranorex.Report.Failure("The bulletin relay pop up doesn't exists");
    			return;
    		}
    	}
    	
    	/// <summary>
        /// Validate Bulletin Present in Bulletin Input Form
        /// </summary>
        /// <param name="bulletinSeed">Input: BulletinSeed</param>
        /// <param name="optionalDistrict">Input: optionalDistrict</param>
        /// <param name="optionalType">Input: optionalType</param>
        /// <param name="validationstatus">Input: validationstatus</param>
        /// <param name="closeForms">Input: closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidteBulletinPresent_BulletinInputForm(string bulletinSeed, string optionalDistrict, string optionalType, bool validationstatus, bool closeForms)
        {
        	int retries = 0;
        	bool bulletinNumberExists = false;
        	NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
        	NS_InputBulletins.InputBulletinHeader(optionalDistrict, optionalType);
        	string bulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
        	if (!Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
        	{
        		Ranorex.Report.Error("Bulletin Input form could not be opened");
        		return;
        	}
        	int rowCount = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
        	while(rowCount == 0 && retries < 5)
        	{
        		Delay.Milliseconds(500);
        		rowCount = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;	
        		retries++;
        	}
        	for(int i = 0; i < rowCount; i++)
        	{
        		Bulletinsrepo.BulletinRowIndex = i.ToString();
        		string currentBulletinReferenceNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
        		if(currentBulletinReferenceNumber.Contains(bulletinNumber))
        		{
        			bulletinNumberExists = true;
        			break;
        		}
        	}
        	
        	if(validationstatus == bulletinNumberExists)
        	{
        		Ranorex.Report.Success(String.Format("Bulletin Number " + (!bulletinNumberExists ? "not " : "") + "found in the Bulletin input form list : {0} ", bulletinNumber));
        	} else {
        		Ranorex.Report.Failure(String.Format("Bulletin Number " + (!bulletinNumberExists ? "not " : "") + "found in the Bulletin input form list : {0} ", bulletinNumber));
        	}
        	if (closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo,
        		                                                  Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
        	}
        	return;
        }

    }

    public static class NS_Bulletin_Input_Form
    {
        
        public static global::PDS_NS.Bulletins_Repo Bulletinsrepo = global::PDS_NS.Bulletins_Repo.Instance;
        
        private static Ranorex.Button upButton = Bulletinsrepo.Bulletins_Input_Relay.Input.VisibleItemsTable.VerticalScrollBar.UpButton;
        private static Ranorex.Button downButton = Bulletinsrepo.Bulletins_Input_Relay.Input.VisibleItemsTable.VerticalScrollBar.DownButton;


        private static bool isVisible(Ranorex.Row row, Ranorex.Container container)
        {
            return container.ScreenRectangle.Contains(row.ScreenRectangle);
        }

        /// <summary>
        /// This method assumes that isVisible() has already returned false.
        /// </summary>
        private static bool isBelowVisiblePanel(Ranorex.Row row, Ranorex.Container container)
        {
            return (container.ScreenRectangle.Y + container.ScreenRectangle.Height) < row.ScreenRectangle.Y;
        }

        private static Ranorex.Button getDirectionButton(Ranorex.Row row, Ranorex.Container container)
        {
            return isBelowVisiblePanel(row, container) ? upButton : downButton;
        }

        private static int getOffsetY(Ranorex.Row row, Ranorex.Container container)
        {
            int upperLeftCoordinate = container.ScreenRectangle.Y;
            int lowerLeftCoordinate = container.ScreenRectangle.Y + container.ScreenRectangle.Height;
            int rowCoordinate = row.ScreenRectangle.Y;
            
            int offset = 0;
            if (isBelowVisiblePanel(row, container))
            {
                offset = Math.Abs(lowerLeftCoordinate - rowCoordinate);
            } else {
                offset = Math.Abs(upperLeftCoordinate - rowCoordinate);
            }

            return offset;
        }

        public static void ScrollUntilVisible(Ranorex.Row row, Ranorex.Container container)
        {
            if (isVisible(row, container))
            {
                Report.Info("The row is visible in the current items table.");
                return;
            }

            // Choose whether to use the scrool up button, or the scroll down button, depending on the row relative to the visible items table.
            Ranorex.Button scrollButton = getDirectionButton(row, container);

            // Ensure that the row is making progress toward becoming visible, otherwise this could become an endless while loop.
            // The moment the row is not approaching the visible items table, report an error
            bool isOffsetDecreasing = true;
            int priorOffset = getOffsetY(row, container);
            while (!isVisible(row, container) && isOffsetDecreasing)
            {
                scrollButton.DoubleClick();
                isOffsetDecreasing = priorOffset > getOffsetY(row, container);
                priorOffset = getOffsetY(row, container);
            }

            if (!isOffsetDecreasing)
            {
                Report.Screenshot(container);
                Report.Error("The row is not approaching the visible items table.");
                return;
            }

            if (isVisible(row, container))
            {
                Report.Info("The row is now visible in the current items table.");
                return;
            }
        }
    }
}