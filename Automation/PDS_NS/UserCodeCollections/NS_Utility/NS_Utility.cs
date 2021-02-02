/*
 * Created by Ranorex
 * User: 503073759
 * Date: 4/29/2019
 * Time: 11:24 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Data;
using System.Linq;
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

namespace PDS_NS.UserCodeCollections
{
	/// <summary>
	/// Utility methods that can be utilized across the NS project
	/// I only tend to keep methods here as part of a layover. 
	/// If the method is here now, they'll get their own class once similar functionality is identified/defined/organized.
	/// </summary>
	[UserCodeCollection]
	public class NS_Utility
	{
		public static global::PDS_NS.PDS_NSRepository pds_nsrepo = global::PDS_NS.PDS_NSRepository.Instance;
		
		/// <summary>
		/// This method allows for a variable to be set to an empty string for particular testing conditions.
		/// This becomes helpful for variables aren't typically exposed outside of a method, but need to be tested as an empty string to ensure the method fails properly.
		/// </summary>
		/// <param name="inputVariable">Input:inputVariable</param>
		/// <param name="isVariableMissing">Input:isVariableMissing</param>
		/// <param name="variableName">Input:variableName</param>
		/// <param name="optionalInvalidVariable">If this is not an empty string, then it will replace the default string for that variable</param>
		/// <returns></returns>
		[UserCodeMethod]
		public static string DefineOrReportVariableContents(string inputVariable, bool isVariableMissing, string variableName, string optionalInvalidVariable = null)
        {
        	string outputVariable = inputVariable;
        	// By design, if the variable is set to missing, then any non-empty string contained in optionalInputVariable will be ignored
			if (isVariableMissing | !string.IsNullOrEmpty(optionalInvalidVariable))
        	{
				if (isVariableMissing)
				{
					outputVariable = "";
					Ranorex.Report.Info("TestStep", "The following variable is set to an empty string: " + variableName);
				} else {
					outputVariable = optionalInvalidVariable;
					Ranorex.Report.Info("TestStep", string.Format("The following variable is set to '{0}': {1}", optionalInvalidVariable, variableName));
				}
			}
			return outputVariable;
        }

		[UserCodeMethod]
		public static void NS_ClosePdsParentProcess_CmdWindow()
		{
			if (pds_nsrepo.Pds_Cmd_Window.SelfInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(
					pds_nsrepo.Pds_Cmd_Window.WindowControls.CloseInfo,
					pds_nsrepo.Pds_Cmd_Window.SelfInfo
				);
			}

			if (pds_nsrepo.Pds_Cmd_Window.SelfInfo.Exists(0))
			{
				Report.Screenshot(pds_nsrepo.Pds_Cmd_Window.Self);
				Report.Error("Unable to close PDS Process.");
			}
		}

		[UserCodeMethod]
		public static void NS_ValidateFormExists_FormTitle(string formTitle, bool validateFormExists = true) 
		{
			Report.Info("TestStep", "Searching for form with form title: " + formTitle);

			RxPath form = string.Format(format: "form[@title~'{0}']", arg0: formTitle);

			Ranorex.Core.Element outForm;
			bool exists = Host.Local.TryFindSingle(form, 3000, out outForm);
			
			string feedbackMessage = string.Format(
				"Form '{0}' found status: '{1}' and expected found status: '{2}'",
				formTitle, exists.ToString(), validateFormExists.ToString()
			);

			if (exists == validateFormExists) 
			{
				Report.Success(feedbackMessage);
				return;
			}
			
			int retries = 0;
			while ((exists != validateFormExists) && retries < 3)
			{
				exists = Host.Local.TryFindSingle(form, 3000, out outForm);
				retries++;
			}

			feedbackMessage = string.Format(
				"Form '{0}' found actual status: '{1}' and expected found status: '{2}'",
				formTitle, exists.ToString(), validateFormExists.ToString()
			);

			if (exists == validateFormExists) 
			{
				Report.Success(feedbackMessage);
			} else {
				Report.Screenshot();
				Report.Failure(feedbackMessage);
			}
		}

		public static void NS_OpenForm_MainMenu(
			Ranorex.Core.Repository.RepoItemInfo menuButtonInfo,
			Ranorex.Core.Repository.RepoItemInfo contextMenuInfo,
			Ranorex.Core.Repository.RepoItemInfo menuItemInfo
		) {

			GeneralUtilities.ClickAndWaitForWithRetry(menuButtonInfo, contextMenuInfo);
			GeneralUtilities.ClickAndWaitForNotExistWithRetry(menuItemInfo, contextMenuInfo);
		}

		public static void NS_OpenForm_MainMenu(
			Ranorex.Core.Repository.RepoItemInfo menuButtonInfo,
			Ranorex.Core.Repository.RepoItemInfo contextMenuInfo,
			Ranorex.Core.Repository.RepoItemInfo outerMenuItemInfo,
			Ranorex.Core.Repository.RepoItemInfo innerMenuItemInfo
		) {

			GeneralUtilities.ClickAndWaitForWithRetry(menuButtonInfo, contextMenuInfo);
			GeneralUtilities.ClickAndWaitForWithRetry(outerMenuItemInfo, innerMenuItemInfo);
			GeneralUtilities.ClickAndWaitForNotExistWithRetry(innerMenuItemInfo, contextMenuInfo);
		}
	}
}
