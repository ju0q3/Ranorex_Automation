/*
 * Created by Ranorex
 * User: akneekhr
 * Date: 13-02-2020
 * Time: 16:46
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

using PDS_CORE.Code_Utils;
using Oracle.Code_Utils;

namespace PDS_NS.UserCodeCollections
{
	/// <summary>
	/// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
	/// </summary>
	[UserCodeCollection]
	public class NS_UserDetails
	{
		public static global::PDS_NS.MainMenu_Repo MainMenurepo = global::PDS_NS.MainMenu_Repo.Instance;
		
		/// <summary>
		/// To Modify Configure UserPreferences
		/// </summary>
		/// <param name="handPreference">Input:handPreference </param>
		/// <param name="reset">Input:reset</param>
		/// <param name="clickApply">Input:clickApply</param>
		/// <param name="closeForms">Input:closeForms</param>
		[UserCodeMethod]
		public static void NS_ModifyHandPreference_ConfigureUserPreferences(string handPreference, bool reset, bool clickApply, bool closeForms)
		{
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.EditButtonInfo,
			                                                              MainMenurepo.PDS_Main_Menu.EditMenu.SelfInfo);
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.EditMenu.UserPreferencesInfo,
			                                                              MainMenurepo.Configure_User_Preferences.SelfInfo);
			if (MainMenurepo.Configure_User_Preferences.SelfInfo.Exists(0))
			{
				string currentHandPreference = MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.HandPreference.HandPreferenceMenuButton.GetAttributeValue<string>("Text");
			
				switch (handPreference)
				{
					case "RIGHT":
						if (!currentHandPreference.Equals(handPreference,StringComparison.OrdinalIgnoreCase))
						{
							PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.HandPreference.HandPreferenceMenuButtonInfo,
							                                                              MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.HandPreference.HandPreferenceMenuList.SelfInfo);
							PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.HandPreference.HandPreferenceMenuList.RightListItemInfo,
							                                                                      MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.HandPreference.HandPreferenceMenuList.SelfInfo);
							Ranorex.Report.Info("HandPreference value set to {"+handPreference+"} from value {"+currentHandPreference+"}" );
						}
						else
						{
							Ranorex.Report.Info("HandPreference {"+handPreference+"} already set with the value {"+currentHandPreference+"}" );
						}
						break;
						
					case "LEFT":
						if (!currentHandPreference.Equals(handPreference,StringComparison.OrdinalIgnoreCase))
						{
							Report.Info(currentHandPreference);
							PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.HandPreference.HandPreferenceMenuButtonInfo,
							                                                              MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.HandPreference.HandPreferenceMenuList.SelfInfo);
							
							PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.HandPreference.HandPreferenceMenuList.LeftListItemInfo,
							                                                                      MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.HandPreference.HandPreferenceMenuList.SelfInfo);
							Ranorex.Report.Info("HandPreference value set to {"+handPreference+"} from value {"+currentHandPreference+"} " );
						}
						else
						{
							Ranorex.Report.Info("HandPreference {"+handPreference+"} already set with the value {"+currentHandPreference+"}" );
						}
						break;
					default:
						Ranorex.Report.Failure("handPreference {"+handPreference+"} is not a known type");
						break;
				}
			}
			else
			{
				Ranorex.Report.Error("Configure_User_Preferences form does not exist");
			}
			//To Reset the Form
			if(reset)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(MainMenurepo.Configure_User_Preferences.ResetButtonInfo, MainMenurepo.Configure_User_Preferences.ResetButtonInfo);
			}
			// to Apply the Form
			if (clickApply)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(MainMenurepo.Configure_User_Preferences.ApplyButtonInfo, MainMenurepo.Configure_User_Preferences.ApplyButtonInfo);
			}
			//To Close the form
			if(closeForms)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Configure_User_Preferences.CancelButtonInfo, MainMenurepo.Configure_User_Preferences.SelfInfo);
			}
		}
		/// <summary>
		/// To Validate HandPreference in Configure UserPreferences
		/// </summary>
		/// <param name="expHandPreference">Input:expHandPreference </param>
		/// <param name="closeForms">Input:closeForms</param>
		[UserCodeMethod]
		public static void NS_ValidateHandPreference_ConfigureUserPreferences(string expHandPreference, bool closeForms)
		{
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.EditButtonInfo,
			                                                              MainMenurepo.PDS_Main_Menu.EditMenu.SelfInfo);
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.EditMenu.UserPreferencesInfo,
			                                                              MainMenurepo.Configure_User_Preferences.SelfInfo);
			if (MainMenurepo.Configure_User_Preferences.SelfInfo.Exists(0))
			{
				
				string currentHandPreference = MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.HandPreference.HandPreferenceMenuButton.GetAttributeValue<string>("SelectedItem");
				if(currentHandPreference.Equals(expHandPreference,StringComparison.OrdinalIgnoreCase))
					
				{
					Ranorex.Report.Success("Expected HandPreference {"+expHandPreference+"} got matched with currentHandPreference {"+currentHandPreference+"}");
				}
				else
				{
					Ranorex.Report.Failure("Expected HandPreference {"+expHandPreference+"}  does not matched currentHandPreference {"+currentHandPreference+"}");
					Ranorex.Report.Screenshot("Unable to find the value in the Form", MainMenurepo.Configure_User_Preferences.Self.Element);
					
				}
			}
			else
			{
				Ranorex.Report.Error("Configure_User_Preferences form does not exist");
			}
			//To Close the form
			if(closeForms)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Configure_User_Preferences.CancelButtonInfo, MainMenurepo.Configure_User_Preferences.SelfInfo);
			}
		}
		/// <summary>
		/// To Modify DoubleClickSpeed Configure UserPreferences
		/// </summary>
		/// <param name="doubleClickSpeed">Input:doubleClickSpeed </param>
		/// <param name="reset">Input:reset</param>
		/// <param name="clickApply">Input:clickApply</param>
		/// <param name="closeForms">Input:closeForms</param>
		[UserCodeMethod]
		public static void NS_ModifyDoubleClickSpeed_ConfigureUserPreferences(string doubleClickSpeed, bool reset,bool clickApply, bool closeForms)
		{
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.EditButtonInfo,
			                                                              MainMenurepo.PDS_Main_Menu.EditMenu.SelfInfo);
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.EditMenu.UserPreferencesInfo,
			                                                              MainMenurepo.Configure_User_Preferences.SelfInfo);
			if (MainMenurepo.Configure_User_Preferences.SelfInfo.Exists(0))
			{
				doubleClickSpeed = doubleClickSpeed.ToLower();
				if (doubleClickSpeed.Equals("maxvalue") || doubleClickSpeed.Equals("100"))
				{
					double currentDoubleClickSpeed = MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.DoubleClickSpeed.GetAttributeValue<double>("MaxValue");
					Ranorex.Report.Info("Max doubleClickSpeed value for " +doubleClickSpeed+ " is:- " +currentDoubleClickSpeed+ "");
					MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.DoubleClickSpeed.Element.SetAttributeValue("Value", currentDoubleClickSpeed);
				}
				else if (doubleClickSpeed.Equals("minvalue") || doubleClickSpeed.Equals("900"))
				{
					double currentDoubleClickSpeed = MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.DoubleClickSpeed.GetAttributeValue<double>("MinValue");
					Ranorex.Report.Info("Min doubleClickSpeed value for " +doubleClickSpeed+ " is:- " +currentDoubleClickSpeed+ "");
					MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.DoubleClickSpeed.Element.SetAttributeValue("Value", currentDoubleClickSpeed);
				}
				else
				{
					double doubleClickSpeedValue;
					if (!double.TryParse(doubleClickSpeed, out doubleClickSpeedValue))
					{
						Ranorex.Report.Error("double Click Speed Value can't be converted");
						return;
					}
					else
					{
						if (doubleClickSpeedValue < 100 || doubleClickSpeedValue > 900)
						{
							Report.Error("Expected value is not between 100 and 900");
							return;
						}
					}
					MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.DoubleClickSpeed.Element.SetAttributeValue("Value", doubleClickSpeedValue);
				}
			}
			else
			{
				Ranorex.Report.Error("Configure_User_Preferences form does not exist");
			}
			//To Reset the Form
			if(reset)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(MainMenurepo.Configure_User_Preferences.ResetButtonInfo, MainMenurepo.Configure_User_Preferences.ResetButtonInfo);
			}
			// to Apply the Form
			if (clickApply)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(MainMenurepo.Configure_User_Preferences.ApplyButtonInfo, MainMenurepo.Configure_User_Preferences.ApplyButtonInfo);
			}
			//To Close the form
			if(closeForms)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Configure_User_Preferences.CancelButtonInfo, MainMenurepo.Configure_User_Preferences.SelfInfo);
			}
		}
		/// <summary>
		/// To Validate DoubleClickSpeed in Configure UserPreferences
		/// </summary>
		/// <param name="expDoubleClickSpeed">Input:expDoubleClickSpeed </param>
		/// <param name="closeForms">Input:closeForms</param>
		[UserCodeMethod]
		public static void NS_ValidateDoubleClickSpeed_ConfigureUserPreferences(double expDoubleClickSpeed, bool closeForms)
		{
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.EditButtonInfo,
			                                                              MainMenurepo.PDS_Main_Menu.EditMenu.SelfInfo);
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.EditMenu.UserPreferencesInfo,
			                                                              MainMenurepo.Configure_User_Preferences.SelfInfo);
			if (MainMenurepo.Configure_User_Preferences.SelfInfo.Exists(0))
			{
				double currentDoubleClickSpeed = MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.DoubleClickSpeed.GetAttributeValue<double>("Value");
				if(currentDoubleClickSpeed.Equals(expDoubleClickSpeed))
				{
					Ranorex.Report.Success("Expected DoubleClickSpeed {"+expDoubleClickSpeed+"} got matched with currentDoubleClickSpeed {"+currentDoubleClickSpeed+"}");
				}
				else
				{
					Ranorex.Report.Failure("Expected DoubleClickSpeed {"+expDoubleClickSpeed+"}  does not matched currentDoubleClickSpeed {"+currentDoubleClickSpeed+"}");
					Ranorex.Report.Screenshot("Unable to find the value in the Form", MainMenurepo.Configure_User_Preferences.Self.Element);
					
				}
			}
			else
			{
				Ranorex.Report.Error("Configure_User_Preferences form does not exist");
			}
			//To Close the form
			if(closeForms)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Configure_User_Preferences.CancelButtonInfo, MainMenurepo.Configure_User_Preferences.SelfInfo);
			}
		}
		/// <summary>
		/// To Modify PointerSpeed in ConfigureUserPreferences
		/// </summary>
		/// <param name="pointerSpeed">Input:pointerSpeed </param>
		/// <param name="reset">Input:reset</param>
		/// <param name="clickApply">Input:clickApply</param>
		/// <param name="closeForms">Input:closeForms</param>
		[UserCodeMethod]
		public static void NS_ModifyPointerSpeed_ConfigureUserPreferences(string pointerSpeed, bool reset,bool clickApply, bool closeForms)
		{
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.EditButtonInfo,
			                                                              MainMenurepo.PDS_Main_Menu.EditMenu.SelfInfo);
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.EditMenu.UserPreferencesInfo,
			                                                              MainMenurepo.Configure_User_Preferences.SelfInfo);
			if (MainMenurepo.Configure_User_Preferences.SelfInfo.Exists(0))
			{
				pointerSpeed = pointerSpeed.ToLower();
				if (pointerSpeed.Equals("maxvalue"))
				{
					double currentMaximumPointerSpeed = MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.PointerSpeed.GetAttributeValue<double>("MaxValue");
					MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.PointerSpeed.Element.SetAttributeValue("Value", currentMaximumPointerSpeed);
				}
				else if (pointerSpeed.Equals("minvalue"))
				{
					double currentMinimumPointerSpeed = MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.PointerSpeed.GetAttributeValue<double>("MinValue");
					MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.DoubleClickSpeed.Element.SetAttributeValue("Value", currentMinimumPointerSpeed);
				}
				else
				{
					double pointerSpeedValue;
					if (!double.TryParse(pointerSpeed, out pointerSpeedValue))
					{
						Ranorex.Report.Error("Pointer Speed Value can't be converted");
						return;
					}
					else
					{
						if (pointerSpeedValue < 1 || pointerSpeedValue > 20)
						{
							Report.Error("Values must be between 1 - 20");
							return;
						}
					}
					MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.PointerSpeed.Element.SetAttributeValue("Value", pointerSpeedValue);
				}
			}
			else
			{
				Ranorex.Report.Error("Configure_User_Preferences form does not exist");
			}
			//To Reset the Form
			if(reset)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(MainMenurepo.Configure_User_Preferences.ResetButtonInfo, MainMenurepo.Configure_User_Preferences.ResetButtonInfo);
			}
			// to Apply the Form
			if (clickApply)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(MainMenurepo.Configure_User_Preferences.ApplyButtonInfo, MainMenurepo.Configure_User_Preferences.ApplyButtonInfo);
			}
			//To Close the form
			if(closeForms)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Configure_User_Preferences.CancelButtonInfo, MainMenurepo.Configure_User_Preferences.SelfInfo);
			}
		}
		/// <summary>
		/// To Validate PointerSpeed in Configure UserPreferences
		/// </summary>
		/// <param name="expPointerSpeed">Input:expPointerSpeed </param>
		/// <param name="closeForms">Input:closeForms</param>
		[UserCodeMethod]
		public static void NS_ValidatePointerSpeed_ConfigureUserPreferences(double expPointerSpeed, bool closeForms)
		{
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.EditButtonInfo,
			                                                              MainMenurepo.PDS_Main_Menu.EditMenu.SelfInfo);
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.EditMenu.UserPreferencesInfo,
			                                                              MainMenurepo.Configure_User_Preferences.SelfInfo);
			if (MainMenurepo.Configure_User_Preferences.SelfInfo.Exists(0))
			{
				double currentPointerSpeed = MainMenurepo.Configure_User_Preferences.MiscellaneousPreferences.PointerSpeed.GetAttributeValue<double>("Value");
				if(currentPointerSpeed.Equals(expPointerSpeed))
				{
					Ranorex.Report.Success("Expected PointerSpeed {"+expPointerSpeed+"} got matched with currentPointerSpeed {"+currentPointerSpeed+"}");
				}
				else
				{
					Ranorex.Report.Failure("Expected PointerSpeed {"+expPointerSpeed+"}  does not matched currentPointerSpeed {"+currentPointerSpeed+"}");
					Ranorex.Report.Screenshot("Unable to find the value in the Form", MainMenurepo.Configure_User_Preferences.Self.Element);
					
				}
			}
			else
			{
				Ranorex.Report.Error("Configure_User_Preferences form does not exist");
				}
			//To Close the form
			if(closeForms)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Configure_User_Preferences.CancelButtonInfo, MainMenurepo.Configure_User_Preferences.SelfInfo);
			}
		}
		
		public static void NS_OpenHoursOfServiceForm_MainMenu()
		{
			if(MainMenurepo.Hours_Of_Service.SelfInfo.Exists(0))
			{
				Ranorex.Report.Info("Hours of service form is already open");
				return;
			}

			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.EditButtonInfo,
			                                                              MainMenurepo.PDS_Main_Menu.EditMenu.SelfInfo);
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.EditMenu.HoursOfServiceInfo,
			                                                              MainMenurepo.Hours_Of_Service.SelfInfo);
			
			if(!MainMenurepo.Hours_Of_Service.SelfInfo.Exists(0))
			{
				int retries=0;
				while (!MainMenurepo.Hours_Of_Service.SelfInfo.Exists(0) && retries < 3)
				{
					Ranorex.Delay.Milliseconds(500);
					retries++;
				}
				
				if (!MainMenurepo.Hours_Of_Service.SelfInfo.Exists(0))
				{
					Ranorex.Report.Error("Hours of service form did not open");
					return;
				}
			}
			else
			{
				Ranorex.Report.Info("Hours of service form opened");
			}	
		}
		
		public static void NS_CloseHoursOfServiceForm()
		{
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Hours_Of_Service.WindowControls.CloseInfo,
			                                                                      MainMenurepo.Hours_Of_Service.SelfInfo);
			int retries=0;
			while(MainMenurepo.Hours_Of_Service.SelfInfo.Exists(0) && retries<3)
			{
				Ranorex.Delay.Milliseconds(500);
				retries++;
			}
			
			if(MainMenurepo.Hours_Of_Service.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("Hours of service form did not close");
				return;
			}
			else
			{
				Ranorex.Report.Info("Hours of service form closed");	
			}
		}
		
		[UserCodeMethod]
		public static void NS_InputHoursOfServiceDetails_HoursOfServiceForm(string logOnTimeDiff, string logOffTimeDiff, string expectedFeedback, bool apply, bool closeForm)
		{
			NS_OpenHoursOfServiceForm_MainMenu();
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.Hours_Of_Service.InsertRowButtonInfo,
			                                                              MainMenurepo.Hours_Of_Service.Insert_A_HOS_Row.SelfInfo);
			//input formatted LogOn Time
			if(logOnTimeDiff != "")
			{
				int logOnTimeDifferenceInt;
				string logOnTimeDifferenceFormatted;
				if (int.TryParse(logOnTimeDiff, out logOnTimeDifferenceInt))
				{
					System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(logOnTimeDifferenceInt);
					logOnTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
				} else {
					logOnTimeDifferenceFormatted = logOnTimeDiff;
				}
				
				MainMenurepo.Hours_Of_Service.Insert_A_HOS_Row.LogOnDateAndTime.LogOnDateAndTimeText.Element.SetAttributeValue("Text", logOnTimeDifferenceFormatted);
				MainMenurepo.Hours_Of_Service.Insert_A_HOS_Row.LogOnDateAndTime.LogOnDateAndTimeText.PressKeys("{TAB}");
			}
			
			//input formatted LogOFF Time
			if(logOffTimeDiff != "")
			{
				int logOffTimeDifferenceInt;
				string logOffTimeDifferenceFormatted;
				if (int.TryParse(logOffTimeDiff, out logOffTimeDifferenceInt))
				{
					System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(logOffTimeDifferenceInt);
					logOffTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
				} else {
					logOffTimeDifferenceFormatted = logOffTimeDiff;
				}
				
				MainMenurepo.Hours_Of_Service.Insert_A_HOS_Row.LogOffDateAndTime.LogOffDateAndTimeText.Element.SetAttributeValue("Text", logOffTimeDifferenceFormatted);
				MainMenurepo.Hours_Of_Service.Insert_A_HOS_Row.OkButton.Click();
			}
			
			int attempts=0;
			while(MainMenurepo.Hours_Of_Service.Insert_A_HOS_Row.SelfInfo.Exists(0) && attempts<3)
			{
				Ranorex.Delay.Milliseconds(500);
				attempts++;
			}
			//check if feedback is generated
			if(MainMenurepo.Hours_Of_Service.Insert_A_HOS_Row.SelfInfo.Exists(0))
			{
				string actualFeedback= MainMenurepo.Hours_Of_Service.Insert_A_HOS_Row.Feedback.GetAttributeValue<string>("Text").ToString();
				if(actualFeedback.Equals(expectedFeedback))
				{
					Ranorex.Report.Success("Expected feedback:{"+expectedFeedback+"} and Actual feedback:{"+actualFeedback+"} are same.");
					PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.Hours_Of_Service.Insert_A_HOS_Row.WindowControls.CloseInfo,
					                                                              MainMenurepo.Hours_Of_Service.SelfInfo);
				}
				else
				{
					Ranorex.Report.Screenshot(MainMenurepo.Hours_Of_Service.Insert_A_HOS_Row.Self);
					PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.Hours_Of_Service.Insert_A_HOS_Row.WindowControls.CloseInfo,
					                                                              MainMenurepo.Hours_Of_Service.SelfInfo);
					NS_CloseHoursOfServiceForm();
					Ranorex.Report.Failure("Expected feedback:{"+expectedFeedback+"} and Actual feedback:{"+actualFeedback+"} are not same.");
					return;
				}
			}
			else if(!MainMenurepo.Hours_Of_Service.Insert_A_HOS_Row.SelfInfo.Exists(0) && expectedFeedback != "")
			{
				Ranorex.Report.Failure("Did not receive expected feedback of {" + expectedFeedback + "}.");
			}
			
			//Click Apply
			if(apply)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.Hours_Of_Service.ApplyButtonInfo,
				                                                              MainMenurepo.Hours_Of_Service.Confirmation_Dialog.SelfInfo);
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Hours_Of_Service.Confirmation_Dialog.OkButtonInfo,
				                                                                      MainMenurepo.Hours_Of_Service.Confirmation_Dialog.SelfInfo);
			}
			
			//close the form
			if(closeForm)
			{
				NS_CloseHoursOfServiceForm();
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidateHoursOfServiceEntries_HoursOfServiceForm(string logOnTimeDiff, string logOffTimeDiff, bool closeForm)
		{
			NS_OpenHoursOfServiceForm_MainMenu();
			
			//format logon time
			int logOnTimeDifferenceInt = 0;
			string logOnTimeDifferenceFormatted = "";
			if(logOnTimeDiff != "")
			{
				if (int.TryParse(logOnTimeDiff, out logOnTimeDifferenceInt))
				{
					System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(logOnTimeDifferenceInt);
					logOnTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
				} else {
					logOnTimeDifferenceFormatted = logOnTimeDiff;
				}
			}
			
			//format logOff time
			int logOffTimeDifferenceInt = 0;
			string logOffTimeDifferenceFormatted = "";
			if(logOffTimeDiff != "")
			{
				if (int.TryParse(logOffTimeDiff, out logOffTimeDifferenceInt))
				{
					System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(logOffTimeDifferenceInt);
					logOffTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
				} else {
					logOffTimeDifferenceFormatted = logOffTimeDiff;
				}
			}
			
			int rowCount = MainMenurepo.Hours_Of_Service.HoursOfServiceTable.Self.Rows.Count;
			bool entryFound = false;
			for(int i = 1; i < rowCount; i++)
			{
				MainMenurepo.HoursOfServiceIndex = i.ToString();
				MainMenurepo.Hours_Of_Service.HoursOfServiceTable.HoursOfServiceByHoursOfServiceIndex.OnDateTime.OnDateTimeMenuButton.Click();
				string timeOfLogOn =MainMenurepo.Hours_Of_Service.HoursOfServiceTable.DateTimeText.GetAttributeValue<string>("Text");
				
				MainMenurepo.Hours_Of_Service.HoursOfServiceTable.HoursOfServiceByHoursOfServiceIndex.OffDateTime.OffDateTimeMenuButton.Click();
				string timeOfLogOff =MainMenurepo.Hours_Of_Service.HoursOfServiceTable.DateTimeText.GetAttributeValue<string>("Text");
				
				if(timeOfLogOn.Equals(logOnTimeDifferenceFormatted) && timeOfLogOff.Equals(logOffTimeDifferenceFormatted))
				{
					entryFound = true;
					break;
				}
				
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(MainMenurepo.Hours_Of_Service.ResetButtonInfo,
				                                                                      MainMenurepo.Hours_Of_Service.ResetButtonInfo);
			}
			
			if (entryFound)
			{
				Report.Success(String.Format("Hours Of Service Entry with logOn time:'{0}' and logOff time : '{1}' is found", logOnTimeDifferenceFormatted, logOffTimeDifferenceFormatted));
			} else {
				Report.Failure(String.Format("Entry with logOn time:'{0}' and logOff time :'{1}' was not found", logOnTimeDifferenceFormatted, logOffTimeDifferenceFormatted));
			}
			
			if(closeForm)
			{
				NS_CloseHoursOfServiceForm();
			}
		}
		
		[UserCodeMethod]
		public static void NS_DeleteHoursOfServiceEntries_HoursOfServiceForm(bool closeForm)
		{
			NS_OpenHoursOfServiceForm_MainMenu();
			int rowCount = MainMenurepo.Hours_Of_Service.HoursOfServiceTable.Self.Rows.Count;
			for(int i = 1; i < rowCount; i++)
			{
				MainMenurepo.HoursOfServiceIndex = i.ToString();
				MainMenurepo.Hours_Of_Service.HoursOfServiceTable.HoursOfServiceByHoursOfServiceIndex.OnDateTime.OnDateTimeMenuButton.Click();
				MainMenurepo.Hours_Of_Service.DeleteRowButton.Click();
			}
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.Hours_Of_Service.ApplyButtonInfo,
			                                                              MainMenurepo.Hours_Of_Service.SelfInfo);
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Hours_Of_Service.Confirmation_Dialog.OkButtonInfo,
			                                                                      MainMenurepo.Hours_Of_Service.Confirmation_Dialog.SelfInfo);
			int retries=0;
			while (rowCount > MainMenurepo.Hours_Of_Service.HoursOfServiceTable.Self.Rows.Count && retries < 3) {
				Ranorex.Delay.Milliseconds(500);
				retries++;
			}
			rowCount = MainMenurepo.Hours_Of_Service.HoursOfServiceTable.Self.Rows.Count;
			if(rowCount-1 == 0)
			{
				Ranorex.Report.Success("All entries have been deleted");
			}
			else
			{
				Report.Failure(rowCount+"entries were not deleted");
			}
			
			if(closeForm)
			{
				NS_CloseHoursOfServiceForm();
			}
		}
		
		public static void NS_OpenConfigureDispatcherTransferReport_UserPreference()
		{
			int retries = 0;

			//Open Dispatcher Transfer Report Form if it's not already open
			if (MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.SelfInfo.Exists(0))
			{
				Ranorex.Report.Info("Configure Dispatcher Transfer Report form is open.");
				return;
			}

			//Click Edit menu
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.EditButtonInfo,
				                                                              MainMenurepo.PDS_Main_Menu.EditMenu.SelfInfo);
			
			//Click User Preference in Edit menu
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.EditMenu.UserPreferencesInfo,
				                                                              MainMenurepo.Configure_User_Preferences.SelfInfo);
			
			//Click on Configure DTR Tab 
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.Configure_User_Preferences.ConfigUserPreferencesTabs.ConfigureDispatcherTransferReportInfo,
				                                                              MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.SelfInfo);
			
			//Wait for Dispatcher Transfer Reportn Form to exist in case of lag
			while (!MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.SelfInfo.Exists(0) && retries < 3)
			{
				Ranorex.Delay.Milliseconds(500);
				retries++;
			}
			
			if (!MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.SelfInfo.Exists(0))
			{
				Report.Screenshot();
				Ranorex.Report.Error("Configure Dispatcher Transfer Report form did not open");
				return;
			}
		}	
			
		public static void NS_ValidateSinglePrintCheckBoxEnabled_DTR_ConfigureUserPreferences(string dataItemName, bool isEnabled, bool closeForm)
		{
			// Open user preferences  window
			NS_OpenConfigureDispatcherTransferReport_UserPreference();

			bool isActualEnabled = NS_ValidateIsCheckboxEnabled(dataItemName);
			if(isActualEnabled == isEnabled)
			{
				Ranorex.Report.Success("Expected {"+dataItemName+"} print checkbox enable status to be {"+isEnabled+"} and found {"+isActualEnabled+"}");
			}
			else
			{
				Ranorex.Report.Failure("Expected {"+dataItemName+"} print checkbox enable status to be {"+isEnabled+"} and found {"+isActualEnabled+"}");
			}
			if(closeForm)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Configure_User_Preferences.WindowControls.CloseInfo,
				                                                                      MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.SelfInfo);
			}
		}
		
		public static void NS_ValidateSinglePrintCheckBoxChecked_DTR_ConfigureUserPreferences(string dataItemName, bool isChecked, bool closeForm)
		{
			// Open user preferences  window
			NS_OpenConfigureDispatcherTransferReport_UserPreference();
			bool isActualChecked = NS_ValidateCheckboxIsChecked(dataItemName);
			if(isActualChecked == isChecked)
			{
				Ranorex.Report.Success("Expected {"+dataItemName+"} print checkbox Checked status to be {"+isChecked+"} and found {"+isActualChecked+"}");
			}
			else{
				Ranorex.Report.Failure("Expected {"+dataItemName+"} print checkbox Checked status to be {"+isChecked+"} and found {"+isActualChecked+"}");
			}
			
			if(closeForm)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Configure_User_Preferences.WindowControls.CloseInfo,
				                                                                      MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.SelfInfo);
			}
		}
		
		public static bool NS_ValidateIsCheckboxEnabled(string dataItemName)
		{
			bool foundEnabled = true;

			MainMenurepo.DataItemName = dataItemName;
			if(MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.ConfigDispatcherTable.DispatcherTransferReportDataItemByDispatcherTransferReportDataItemName.DispatcherTransferReportDataItemNameInfo.Exists(0))
			{
				string beforeClickStatus = MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.ConfigDispatcherTable.DispatcherTransferReportDataItemByDispatcherTransferReportDataItemName.PrintCheckBox.Text;
				MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.ConfigDispatcherTable.DispatcherTransferReportDataItemIndex.PrintCheckBox.Click();
				string afterClickStatus = MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.ConfigDispatcherTable.DispatcherTransferReportDataItemByDispatcherTransferReportDataItemName.PrintCheckBox.Text;
				
				if(beforeClickStatus.Equals(afterClickStatus))
				{
					foundEnabled = false;
				}
			}
			else{
				Ranorex.Report.Error("DTR data item name not found, specify a valid data item name. Check data bindings and try again.");
			}

			return foundEnabled;
		}
		
		public static bool NS_ValidateCheckboxIsChecked(string dataItemName)
		{
			bool actualChecked = false;
			
			MainMenurepo.DataItemName = dataItemName;
			if(MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.ConfigDispatcherTable.DispatcherTransferReportDataItemByDispatcherTransferReportDataItemName.DispatcherTransferReportDataItemNameInfo.Exists(0))
			{
				actualChecked = bool.Parse(MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.ConfigDispatcherTable.DispatcherTransferReportDataItemByDispatcherTransferReportDataItemName.PrintCheckBox.Text);
			}
			else{
				Ranorex.Report.Error("DTR data item name not found, specify a valid data item name. Check data bindings and try again.");
			}
			
			return actualChecked;
		}
		
		[UserCodeMethod]
		public static void NS_ValidateAllPrintCheckBoxEnabled_DTR_ConfigureUserPreferences(bool isEnabled, bool closeForm)
		{
			// Open user preferences  window
			NS_OpenConfigureDispatcherTransferReport_UserPreference();
			int rowCount = MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.ConfigDispatcherTable.Self.Rows.Count;
			for (int i = 0; i < rowCount; i++) {
				MainMenurepo.DispatcherTransferReportIndex = i.ToString();
				string dataItemName = MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.ConfigDispatcherTable.DispatcherTransferReportDataItemIndex.DispatcherTransferReportDataItemsText.GetAttributeValue<string>("Text");
				if(NS_ValidateIsCheckboxEnabled(dataItemName) == isEnabled)
				{
					Ranorex.Report.Success("Expected {"+dataItemName+"} checkbox ENABLE status to be {"+isEnabled+"} and found as {"+NS_ValidateIsCheckboxEnabled(dataItemName)+"}");
				}
				else
				{
					Ranorex.Report.Failure("Expected {"+dataItemName+"} checkbox ENABLE status to be {"+isEnabled+"} and found few as:{"+NS_ValidateIsCheckboxEnabled(dataItemName)+"}");
					return;
				}
			}
			
			
			if(closeForm)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Configure_User_Preferences.WindowControls.CloseInfo,
				                                                                      MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.SelfInfo);
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidateAllPrintCheckBoxChecked_DTR_ConfigureUserPreferences(bool isChecked, bool closeForm)
		{
			// Open user preferences  window
			NS_OpenConfigureDispatcherTransferReport_UserPreference();
			int rowCount = MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.ConfigDispatcherTable.Self.Rows.Count;
			for (int i = 0; i < rowCount; i++) {
				MainMenurepo.DispatcherTransferReportIndex = i.ToString();
				string dataItemName = MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.ConfigDispatcherTable.DispatcherTransferReportDataItemIndex.DispatcherTransferReportDataItemsText.GetAttributeValue<string>("Text");
				if(NS_ValidateCheckboxIsChecked(dataItemName) == isChecked)
				{
					Ranorex.Report.Success("Expected  {"+dataItemName+"} CHECKED status to be {"+isChecked+"} and found as {"+NS_ValidateCheckboxIsChecked(dataItemName)+"}");
				}
				else
				{
					Ranorex.Report.Failure("Expected  {"+dataItemName+"} CHECKED status to be {"+isChecked+"} and found few as:{"+NS_ValidateCheckboxIsChecked(dataItemName)+"}");
					return;
				}
			}
			
			if(closeForm)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Configure_User_Preferences.WindowControls.CloseInfo,
				                                                                      MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.SelfInfo);
			}
		}
		
		public static void NS_ModifySinglePrintCheckBox_DTR_ConfigureUserPreferences(string dataItemName, bool doCheck, bool apply, bool closeForm)
		{

			NS_OpenConfigureDispatcherTransferReport_UserPreference();

			bool isChecked = NS_ModifyPrintCheckBox(dataItemName, doCheck);
			
			if(isChecked == doCheck)
			{
				Ranorex.Report.Success("Print checkbox for {"+dataItemName+"} has been checked");
			}
			else
			{
				Ranorex.Report.Failure("Print checkbox for {"+dataItemName+"} has not been checked");
			}
			
			//Click on apply button
			if(apply)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(MainMenurepo.Configure_User_Preferences.ApplyButtonInfo, MainMenurepo.Configure_User_Preferences.ApplyButtonInfo);
			}
			
			//Click on ok button
			if(closeForm)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Configure_User_Preferences.OkButtonInfo, MainMenurepo.Configure_User_Preferences.SelfInfo);
			}
		}
		
		public static bool NS_ModifyPrintCheckBox(string dataItemName, bool doCheck)
		{
			MainMenurepo.DataItemName = dataItemName;
			if(MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.ConfigDispatcherTable.DispatcherTransferReportDataItemByDispatcherTransferReportDataItemName.DispatcherTransferReportDataItemNameInfo.Exists(0))
			{
				if (NS_ValidateIsCheckboxEnabled(dataItemName))
				{
					bool chkBoxStatus = bool.Parse(MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.ConfigDispatcherTable.DispatcherTransferReportDataItemIndex.PrintCheckBox.GetAttributeValue<string>("Text"));
					if(chkBoxStatus != doCheck)
					{
						MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.ConfigDispatcherTable.DispatcherTransferReportDataItemIndex.PrintCheckBox.Click();
					}
				}
				else
				{
					Ranorex.Report.Error("Checkbox {"+dataItemName+"} is disabled");
					return false;
				}
				return true;
			}
			else{
				Ranorex.Report.Error("DTR data item name not found, specify a valid data item name. Check data bindings and try again.");
			}
			
			return false;
		}
		
		[UserCodeMethod]
		public static void NS_ModifyAllPrintCheckBox_DTR_ConfigureUserPreferences(bool doCheck, bool apply, bool closeForm)
		{
			NS_OpenConfigureDispatcherTransferReport_UserPreference();
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.Configure_User_Preferences.ConfigUserPreferencesTabs.ConfigureDispatcherTransferReportInfo,
			                                                              MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.SelfInfo);
			
			bool isCheckboxSetAsExpected = true;
			int rowCount = MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.ConfigDispatcherTable.Self.Rows.Count;
			for (int i = 0; i < rowCount; i++)
			{
				MainMenurepo.DispatcherTransferReportIndex = i.ToString();
				string dataItemName = MainMenurepo.Configure_User_Preferences.ConfigureDispatcherTransferReport.ConfigDispatcherTable.DispatcherTransferReportDataItemIndex.DispatcherTransferReportDataItemsText.GetAttributeValue<string>("Text");
				if(!NS_ModifyPrintCheckBox(dataItemName,doCheck))
				{
					isCheckboxSetAsExpected = false;
					break;
				}
			}
			
			if(isCheckboxSetAsExpected)
			{
				Ranorex.Report.Success("All Print checkboxes for Configure DTR have been {"+(doCheck ? "Checked": "Unchecked")+"}");
			}
			else
			{
				Ranorex.Report.Failure("Failed to {"+(doCheck ? "check" : "uncheck")+"} All checkboxes for Print Configure DTR");
			}
			
			//Click on apply button
			if(apply)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(MainMenurepo.Configure_User_Preferences.ApplyButtonInfo, MainMenurepo.Configure_User_Preferences.ApplyButtonInfo);
			}
			
			//Click on ok button
			if(closeForm)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Configure_User_Preferences.OkButtonInfo, MainMenurepo.Configure_User_Preferences.SelfInfo);
			}
		}   
	}
}
