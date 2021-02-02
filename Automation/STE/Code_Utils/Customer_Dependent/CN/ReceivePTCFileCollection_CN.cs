/*
 * Created by Ranorex
 * User: r07000021
 * Date: 1/18/2018
 * Time: 8:11 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using STE.Code_Utils.messages.PTC;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace STE.Code_Utils
{
	/// <summary>
	/// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
	/// </summary>
	[UserCodeCollection]
	public class ReceivePTCFileCollection_CN
	{
		public static List<string> msgFilters = new List<string>();
		
		[UserCodeMethod]
		public static void addValueToFilters(string val)
		{
			string[] vals;
			vals = val.Split('|');
			foreach (string item in vals) {
				Ranorex.Report.Info("TestStep","Adding " +item+ " to list of filters for STE message validation");
				msgFilters.Add(item);
			}
		}
		
		[UserCodeMethod]
		public static void clearFilters()
		{
			Ranorex.Report.Info("Clearing and resetting capacity of list of filters for STE message validation");
			msgFilters.Clear();
			msgFilters.TrimExcess();
		}
		
		[UserCodeMethod]
		public static PTC_DC_ERROR_1 getMessageDC_ERROR_1(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_ERROR_1 ptc_dc_error = null;
			ptc_dc_error = messages.SteMessageFileReader.getMessageDC_ERROR_1(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_error;
		}
		
		[UserCodeMethod]
		public static void validateDC_ERROR_1(int timeInSeconds, bool retry)
		{
			foreach(string message in msgFilters) {
				Ranorex.Report.Info("TestStep","FILTER = " + message);
			}
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_ERROR_1 ptc_dc_error = null;
			ptc_dc_error = getMessageDC_ERROR_1(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_error != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_ERROR_1 getMessageDG_ERROR_1(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_ERROR_1 ptc_dg_error = null;
			ptc_dg_error = messages.SteMessageFileReader.getMessageDG_ERROR_1(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_error;
		}
		
		[UserCodeMethod]
		public static void validateDG_ERROR_1(int timeInSeconds, bool retry)
		{
			foreach(string message in msgFilters) {
				Ranorex.Report.Info("TestStep","FILTER = " + message);
			}
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_ERROR_1 ptc_dg_error = null;
			ptc_dg_error = getMessageDG_ERROR_1(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_error != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_AK01_2 getMessageDC_AK01_2(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_AK01_2 ptc_dc_ak01 = null;
			ptc_dc_ak01 = messages.SteMessageFileReader.getMessageDC_AK01_2(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_ak01;
		}
		
		[UserCodeMethod]
		public static void validateDC_AK01_2(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_AK01_2 ptc_dc_ak01 = null;
			ptc_dc_ak01 = getMessageDC_AK01_2(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_ak01 != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_AK01_7 getMessageDC_AK01_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_AK01_7 ptc_dc_ak01 = null;
			ptc_dc_ak01 = messages.SteMessageFileReader.getMessageDC_AK01_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_ak01;
		}
		
		[UserCodeMethod]
		public static bool getMessageGD_AK01_7(int timeInSeconds=5, bool retry=true)
		{
			//PTC_GD_AK01_7 ptc_gd_ak01 = null;
			bool ptc_gd_ak01 = messages.SteMessageFileReader.getMessageGD_AK01_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_gd_ak01;
		}
		
		[UserCodeMethod]
		public static void validateDC_AK01_7(int timeInSeconds, bool retry)
		{
			foreach(string message in msgFilters) {
				Ranorex.Report.Info("TestStep","FILTER = " + message);
			}
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_AK01_7 ptc_dc_ak01 = null;
			ptc_dc_ak01 = getMessageDC_AK01_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_ak01 != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}
		
		[UserCodeMethod]
		public static void validateGD_AK01_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			//PTC_GD_AK01_7 ptc_gd_ak01 = null;
			bool ptc_gd_ak01 = getMessageGD_AK01_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_gd_ak01);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_ASBI_2 getMessageDC_ASBI_2(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_ASBI_2 ptc_dc_asbi = null;
			ptc_dc_asbi = messages.SteMessageFileReader.getMessageDC_ASBI_2(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_asbi;
		}
		
		[UserCodeMethod]
		public static void validateDC_ASBI_2(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_ASBI_2 ptc_dc_asbi = null;
			ptc_dc_asbi = getMessageDC_ASBI_2(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_asbi != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_ASBI_7 getMessageDC_ASBI_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_ASBI_7 ptc_dc_asbi = null;
			ptc_dc_asbi = messages.SteMessageFileReader.getMessageDC_ASBI_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_asbi;
		}
		
		[UserCodeMethod]
		public static void validateDC_ASBI_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_ASBI_7 ptc_dc_asbi = null;
			ptc_dc_asbi = getMessageDC_ASBI_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_asbi != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_DIBS_2 getMessageDC_DIBS_2(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_DIBS_2 ptc_dc_dibs = null;
			ptc_dc_dibs = messages.SteMessageFileReader.getMessageDC_DIBS_2(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_dibs;
		}
		
		[UserCodeMethod]
		public static void validateDC_DIBS_2(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_DIBS_2 ptc_dc_dibs = null;
			ptc_dc_dibs = getMessageDC_DIBS_2(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_dibs != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_DIBS_7 getMessageDC_DIBS_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_DIBS_7 ptc_dc_dibs = null;
			ptc_dc_dibs = messages.SteMessageFileReader.getMessageDC_DIBS_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_dibs;
		}
		
		[UserCodeMethod]
		public static void validateDC_DIBS_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_DIBS_7 ptc_dc_dibs = null;
			ptc_dc_dibs = getMessageDC_DIBS_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_dibs != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}
		
		[UserCodeMethod]
		public static PTC_DC_MESS_7 getMessageDC_MESS_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_MESS_7 ptc_dc_mess = null;
			ptc_dc_mess = messages.SteMessageFileReader.getMessageDC_MESS_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_mess;
		}
		
		[UserCodeMethod]
		public static void validateDC_MESS_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_MESS_7 ptc_dc_mess = null;
			ptc_dc_mess = getMessageDC_MESS_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_mess != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_ENED_2 getMessageDC_ENED_2(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_ENED_2 ptc_dc_ened = null;
			ptc_dc_ened = messages.SteMessageFileReader.getMessageDC_ENED_2(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_ened;
		}
		
		
		[UserCodeMethod]
		public static void validateDC_ENED_2(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_ENED_2 ptc_dc_ened = null;
			ptc_dc_ened = getMessageDC_ENED_2(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_ened != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_ENED_7 getMessageDC_ENED_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_ENED_7 ptc_dc_ened = null;
			ptc_dc_ened = messages.SteMessageFileReader.getMessageDC_ENED_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_ened;
		}
		
		[UserCodeMethod]
		public static void validateDC_ENED_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_ENED_7 ptc_dc_ened = null;
			ptc_dc_ened = getMessageDC_ENED_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_ened != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_KA01_2 getMessageDC_KA01_2(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_KA01_2 ptc_dc_ka01 = null;
			ptc_dc_ka01 = messages.SteMessageFileReader.getMessageDC_KA01_2(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_ka01;
		}
		
		[UserCodeMethod]
		public static void validateDC_KA01_2(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_KA01_2 ptc_dc_ka01 = null;
			ptc_dc_ka01 = getMessageDC_KA01_2(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_ka01 != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_KA01_7 getMessageDC_KA01_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_KA01_7 ptc_dc_ka01 = null;
			ptc_dc_ka01 = messages.SteMessageFileReader.getMessageDC_KA01_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_ka01;
		}
		
		[UserCodeMethod]
		public static void validateDC_KA01_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_KA01_7 ptc_dc_ka01 = null;
			ptc_dc_ka01 = getMessageDC_KA01_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_ka01 != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_MESS_2 getMessageDC_MESS_2(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_MESS_2 ptc_dc_mess = null;
			ptc_dc_mess = messages.SteMessageFileReader.getMessageDC_MESS_2(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_mess;
		}
		
		[UserCodeMethod]
		public static void validateDC_MESS_2(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_MESS_2 ptc_dc_mess = null;
			ptc_dc_mess = getMessageDC_MESS_2(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_mess != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_TCON_6 getMessageDC_TCON_6(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_TCON_6 ptc_dc_tcon = null;
			ptc_dc_tcon = messages.SteMessageFileReader.getMessageDC_TCON_6(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_tcon;
		}
		
		[UserCodeMethod]
		public static void validateDC_TCON_6(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_TCON_6 ptc_dc_tcon = null;
			ptc_dc_tcon = getMessageDC_TCON_6(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_tcon != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_TCON_7 getMessageDC_TCON_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_TCON_7 ptc_dc_tcon = null;
			ptc_dc_tcon = messages.SteMessageFileReader.getMessageDC_TCON_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_tcon;
		}
		
		[UserCodeMethod]
		public static void validateDC_TCON_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_TCON_7 ptc_dc_tcon = null;
			ptc_dc_tcon = getMessageDC_TCON_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_tcon != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_TLST_5 getMessageDC_TLST_5(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_TLST_5 ptc_dc_tlst = null;
			ptc_dc_tlst = messages.SteMessageFileReader.getMessageDC_TLST_5(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_tlst;
		}
		
		[UserCodeMethod]
		public static void validateDC_TLST_5(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_TLST_5 ptc_dc_tlst = null;
			ptc_dc_tlst = getMessageDC_TLST_5(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_tlst != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_TLST_7 getMessageDC_TLST_7(int timeInSeconds=5, bool retry=true)
		{
			Ranorex.Report.Info("TestStep","getMessageDC_TLST_7");
			PTC_DC_TLST_7 ptc_dc_tlst = null;
			ptc_dc_tlst = messages.SteMessageFileReader.getMessageDC_TLST_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_tlst;
		}
		
		[UserCodeMethod]
		public static void validateDC_TLST_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_TLST_7 ptc_dc_tlst = null;
			ptc_dc_tlst = getMessageDC_TLST_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_tlst != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_TRDL_2 getMessageDC_TRDL_2(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_TRDL_2 ptc_dc_trdl = null;
			ptc_dc_trdl = messages.SteMessageFileReader.getMessageDC_TRDL_2(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_trdl;
		}
		
		[UserCodeMethod]
		public static void validateDC_TRDL_2(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_TRDL_2 ptc_dc_trdl = null;
			ptc_dc_trdl = getMessageDC_TRDL_2(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_trdl != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_TRDL_7 getMessageDC_TRDL_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_TRDL_7 ptc_dc_trdl = null;
			ptc_dc_trdl = messages.SteMessageFileReader.getMessageDC_TRDL_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_trdl;
		}

		
		[UserCodeMethod]
		public static void validateDC_TRDL_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_TRDL_7 ptc_dc_trdl = null;
			ptc_dc_trdl = getMessageDC_TRDL_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_trdl != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}
		[UserCodeMethod]
		public static PTC_DC_VDME_2 getMessageDC_VDME_2(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_VDME_2 ptc_dc_vdme = null;
			ptc_dc_vdme = messages.SteMessageFileReader.getMessageDC_VDME_2(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_vdme;
		}
		
		[UserCodeMethod]
		public static void validateDC_VDME_2(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_VDME_2 ptc_dc_vdme = null;
			ptc_dc_vdme = getMessageDC_VDME_2(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_vdme != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_VDME_7 getMessageDC_VDME_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_VDME_7 ptc_dc_vdme = null;
			ptc_dc_vdme = messages.SteMessageFileReader.getMessageDC_VDME_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_vdme;
		}
		
		[UserCodeMethod]
		public static void validateDC_VDME_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_VDME_7 ptc_dc_vdme = null;
			ptc_dc_vdme = getMessageDC_VDME_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_vdme != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DC_DSSR_7 getMessageDC_DSSR_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DC_DSSR_7 ptc_dc_dssr = null;
			ptc_dc_dssr = messages.SteMessageFileReader.getMessageDC_DSSR_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dc_dssr;
		}
		
		[UserCodeMethod]
		public static void validateDC_DSSR_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_DSSR_7 ptc_dc_dssr = null;
			ptc_dc_dssr = getMessageDC_DSSR_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dc_dssr != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_AK01_2 getMessageDG_AK01_2(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_AK01_2 ptc_dg_ak01 = null;
			ptc_dg_ak01 = messages.SteMessageFileReader.getMessageDG_AK01_2(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_ak01;
		}
		
		[UserCodeMethod]
		public static void validateDG_AK01_2(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_AK01_2 ptc_dg_ak01 = null;
			ptc_dg_ak01 = getMessageDG_AK01_2(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_ak01 != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_AK01_7 getMessageDG_AK01_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_AK01_7 ptc_dg_ak01 = null;
			ptc_dg_ak01 = messages.SteMessageFileReader.getMessageDG_AK01_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_ak01;
		}
		
		[UserCodeMethod]
		public static void validateDG_AK01_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_AK01_7 ptc_dg_ak01 = null;
			ptc_dg_ak01 = getMessageDG_AK01_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_ak01 != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_BULI_3 getMessageDG_BULI_3(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_BULI_3 ptc_dg_buli = null;
			ptc_dg_buli = messages.SteMessageFileReader.getMessageDG_BULI_3(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_buli;
		}
		
		[UserCodeMethod]
		public static void validateDG_BULI_3(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_BULI_3 ptc_dg_buli = null;
			ptc_dg_buli = getMessageDG_BULI_3(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_buli != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_BULI_7 getMessageDG_BULI_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_BULI_7 ptc_dg_buli = null;
			ptc_dg_buli = messages.SteMessageFileReader.getMessageDG_BULI_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_buli;
		}
		
		[UserCodeMethod]
		public static void validateDG_BULI_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_BULI_7 ptc_dg_buli = null;
			ptc_dg_buli = getMessageDG_BULI_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_buli != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_KA01_2 getMessageDG_KA01_2(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_KA01_2 ptc_dg_ka01 = null;
			ptc_dg_ka01 = messages.SteMessageFileReader.getMessageDG_KA01_2(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_ka01;
		}
		
		[UserCodeMethod]
		public static void validateDG_KA01_2(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_KA01_2 ptc_dg_ka01 = null;
			ptc_dg_ka01 = getMessageDG_KA01_2(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_ka01 != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_KA01_7 getMessageDG_KA01_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_KA01_7 ptc_dg_ka01 = null;
			ptc_dg_ka01 = messages.SteMessageFileReader.getMessageDG_KA01_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_ka01;
		}
		
		[UserCodeMethod]
		public static void validateDG_KA01_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_KA01_7 ptc_dg_ka01 = null;
			ptc_dg_ka01 = getMessageDG_KA01_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_ka01 != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_SGCN_2 getMessageDG_SGCN_2(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_SGCN_2 ptc_dg_sgcn = null;
			ptc_dg_sgcn = messages.SteMessageFileReader.getMessageDG_SGCN_2(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_sgcn;
		}
		
		[UserCodeMethod]
		public static void validateDG_SGCN_2(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_SGCN_2 ptc_dg_sgcn = null;
			ptc_dg_sgcn = getMessageDG_SGCN_2(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_sgcn != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_SGCN_7 getMessageDG_SGCN_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_SGCN_7 ptc_dg_sgcn = null;
			ptc_dg_sgcn = messages.SteMessageFileReader.getMessageDG_SGCN_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_sgcn;
		}
		
		[UserCodeMethod]
		public static void validateDG_SGCN_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_SGCN_7 ptc_dg_sgcn = null;
			ptc_dg_sgcn = getMessageDG_SGCN_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_sgcn != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_SGIN_2 getMessageDG_SGIN_2(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_SGIN_2 ptc_dg_sgin = null;
			ptc_dg_sgin = messages.SteMessageFileReader.getMessageDG_SGIN_2(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_sgin;
		}
		
		[UserCodeMethod]
		public static void validateDG_SGIN_2(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_SGIN_2 ptc_dg_sgin = null;
			ptc_dg_sgin = getMessageDG_SGIN_2(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_sgin != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_SGIN_7 getMessageDG_SGIN_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_SGIN_7 ptc_dg_sgin = null;
			ptc_dg_sgin = messages.SteMessageFileReader.getMessageDG_SGIN_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_sgin;
		}
		
		[UserCodeMethod]
		public static void validateDG_SGIN_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_SGIN_7 ptc_dg_sgin = null;
			ptc_dg_sgin = getMessageDG_SGIN_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_sgin != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_SWCN_2 getMessageDG_SWCN_2(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_SWCN_2 ptc_dg_swcn = null;
			ptc_dg_swcn = messages.SteMessageFileReader.getMessageDG_SWCN_2(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_swcn;
		}
		
		[UserCodeMethod]
		public static void validateDG_SWCN_2(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_SWCN_2 ptc_dg_swcn = null;
			ptc_dg_swcn = getMessageDG_SWCN_2(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_swcn != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}
		
		[UserCodeMethod]
		public static PTC_DG_SWCN_7 getMessageDG_SWCN_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_SWCN_7 ptc_dg_swcn = null;
			ptc_dg_swcn = messages.SteMessageFileReader.getMessageDG_SWCN_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_swcn;
		}
		
		[UserCodeMethod]
		public static void validateDG_SWCN_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_SWCN_7 ptc_dg_swcn = null;
			ptc_dg_swcn = getMessageDG_SWCN_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_swcn != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_SWIN_2 getMessageDG_SWIN_2(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_SWIN_2 ptc_dg_swin = null;
			ptc_dg_swin = messages.SteMessageFileReader.getMessageDG_SWIN_2(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_swin;
		}
		
		[UserCodeMethod]
		public static void validateDG_SWIN_2(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_SWIN_2 ptc_dg_swin = null;
			ptc_dg_swin = getMessageDG_SWIN_2(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_swin != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_SWIN_7 getMessageDG_SWIN_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_SWIN_7 ptc_dg_swin = null;
			ptc_dg_swin = messages.SteMessageFileReader.getMessageDG_SWIN_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_swin;
		}
		
		[UserCodeMethod]
		public static void validateDG_SWIN_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_SWIN_7 ptc_dg_swin = null;
			ptc_dg_swin = getMessageDG_SWIN_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_swin != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_SY01_2 getMessageDG_SY01_2(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_SY01_2 ptc_dg_sy01 = null;
			ptc_dg_sy01 = messages.SteMessageFileReader.getMessageDG_SY01_2(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_sy01;
		}
		
		[UserCodeMethod]
		public static void validateDG_SY01_2(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_SY01_2 ptc_dg_sy01 = null;
			ptc_dg_sy01 = getMessageDG_SY01_2(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_sy01 != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_SY01_7 getMessageDG_SY01_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_SY01_7 ptc_dg_sy01 = null;
			ptc_dg_sy01 = messages.SteMessageFileReader.getMessageDG_SY01_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_sy01;
		}
		
		[UserCodeMethod]
		public static void validateDG_SY01_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_SY01_7 ptc_dg_sy01 = null;
			ptc_dg_sy01 = getMessageDG_SY01_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_sy01 != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_TAUT_3 getMessageDG_TAUT_3(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_TAUT_3 ptc_dg_taut = null;
			ptc_dg_taut = messages.SteMessageFileReader.getMessageDG_TAUT_3(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_taut;
		}
		
		[UserCodeMethod]
		public static void validateDG_TAUT_3(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_TAUT_7 ptc_dg_taut = null;
			ptc_dg_taut = getMessageDG_TAUT_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_taut != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_TAUT_7 getMessageDG_TAUT_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_TAUT_7 ptc_dg_taut = null;
			ptc_dg_taut = messages.SteMessageFileReader.getMessageDG_TAUT_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_taut;
		}
		
		[UserCodeMethod]
		public static void validateDG_TAUT_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_TAUT_7 ptc_dg_taut = null;
			ptc_dg_taut = getMessageDG_TAUT_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_taut != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_TRDL_2 getMessageDG_TRDL_2(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_TRDL_2 ptc_dg_trdl = null;
			ptc_dg_trdl = messages.SteMessageFileReader.getMessageDG_TRDL_2(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_trdl;
		}
		
		[UserCodeMethod]
		public static void validateDG_TRDL_2(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_TRDL_2 ptc_dg_trdl = null;
			ptc_dg_trdl = getMessageDG_TRDL_2(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_trdl != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_TRDL_7 getMessageDG_TRDL_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_TRDL_7 ptc_dg_trdl = null;
			ptc_dg_trdl = messages.SteMessageFileReader.getMessageDG_TRDL_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_trdl;
		}
		
		[UserCodeMethod]
		public static void validateDG_TRDL_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_TRDL_7 ptc_dg_trdl = null;
			ptc_dg_trdl = getMessageDG_TRDL_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_trdl != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_UDIE_5 getMessageDG_UDIE_5(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_UDIE_5 ptc_dg_udie = null;
			ptc_dg_udie = messages.SteMessageFileReader.getMessageDG_UDIE_5(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_udie;
		}
		
		[UserCodeMethod]
		public static void validateDG_UDIE_5(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_UDIE_5 ptc_dg_udie = null;
			ptc_dg_udie = getMessageDG_UDIE_5(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_udie != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_UDIE_7 getMessageDG_UDIE_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_UDIE_7 ptc_dg_udie = null;
			ptc_dg_udie = messages.SteMessageFileReader.getMessageDG_UDIE_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_udie;
		}
		
		[UserCodeMethod]
		public static void validateDG_UDIE_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_UDIE_7 ptc_dg_udie = null;
			ptc_dg_udie = getMessageDG_UDIE_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_udie != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_VDBI_4 getMessageDG_VDBI_4(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_VDBI_4 ptc_dg_vdbi = null;
			ptc_dg_vdbi = messages.SteMessageFileReader.getMessageDG_VDBI_4(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_vdbi;
		}
		
		[UserCodeMethod]
		public static void validateDG_VDBI_4(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_VDBI_4 ptc_dg_vdbi = null;
			ptc_dg_vdbi = getMessageDG_VDBI_4(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_vdbi != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_VDBI_7 getMessageDG_VDBI_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_VDBI_7 ptc_dg_vdbi = null;
			ptc_dg_vdbi = messages.SteMessageFileReader.getMessageDG_VDBI_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_vdbi;
		}
		
		[UserCodeMethod]
		public static void validateDG_VDBI_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_VDBI_7 ptc_dg_vdbi = null;
			ptc_dg_vdbi = getMessageDG_VDBI_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_vdbi != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static PTC_DG_DSSR_7 getMessageDG_DSSR_7(int timeInSeconds=5, bool retry=true)
		{
			PTC_DG_DSSR_7 ptc_dg_dssr = null;
			ptc_dg_dssr = messages.SteMessageFileReader.getMessageDG_DSSR_7(msgFilters.ToArray(), timeInSeconds, retry);
			return ptc_dg_dssr;
		}
		
		[UserCodeMethod]
		public static void validateDG_DSSR_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_DSSR_7 ptc_dg_dssr = null;
			ptc_dg_dssr = getMessageDG_DSSR_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(ptc_dg_dssr != null);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}

		[UserCodeMethod]
		public static bool getMessageGD_RTDL_7(int timeInSeconds=5, bool retry=true)
		{
			bool exists = messages.SteMessageFileReader.getMessageGD_RTDL_7(msgFilters.ToArray(), timeInSeconds, retry);
			return exists;
		}
		
		[UserCodeMethod]
		public static void validateGD_RTDL_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			bool exists = getMessageGD_RTDL_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(exists);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}
		
		[UserCodeMethod]
		public static bool getMessageCD_RTDL_7(int timeInSeconds=5, bool retry=true)
		{
			bool exists = messages.SteMessageFileReader.getMessageCD_RTDL_7(msgFilters.ToArray(), timeInSeconds, retry);
			return exists;
		}
		
		[UserCodeMethod]
		public static void validateCD_RTDL_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			bool exists = getMessageCD_RTDL_7(timeInSeconds, retry);
			try {
				Validate.IsTrue(exists);
			} catch(RanorexException) {
				Report.Error("STE message containing filters not found");
			}
			return;
		}
		
		[UserCodeMethod]
		public static void validateRejectedMessage(int timeInSeconds=5, bool retry=true)
		{
			bool hasFilter = true;
			bool foundFile = false;
			System.DateTime fromDate;
			System.DateTime toDate;
			List<string> paths;
			System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
			while (System.DateTime.Now < future && !foundFile) {
				fromDate = System.DateTime.Now.AddSeconds(-System.Math.Abs(timeInSeconds));
				toDate = System.DateTime.Now;
				paths = Directory.EnumerateFiles(SteUtils.getInboundPtcDir(), "*", SearchOption.AllDirectories)
					.Where(path => {
					       	System.DateTime lastWriteTime = File.GetLastWriteTime(path);
					       	return lastWriteTime >= fromDate && lastWriteTime <= toDate;
					       })
					.ToList();
				if (paths.Count == 0)
				{
					Ranorex.Report.Failure("No files found within timespan");
					Validate.IsTrue(false);
				}
				foreach (var path in paths)
				{
					//Ranorex.Report.Info("TestStep","Check file for filters: " + path);
					using (StreamReader sr = new StreamReader(path))
					{
						string contents = sr.ReadToEnd();
						if ((contents.Contains("<ERROR>")) && (contents.Contains("</ERROR>")))
						{
							foreach (var filter in msgFilters)
							{
								Ranorex.Report.Info("TestStep","Checking filter: " + filter);
								if(!contents.Contains(filter))
								{
									hasFilter = false;
									break;
								}
							}
							if(hasFilter)
							{
								foundFile = true;
								break;
							}
						}
					}
				}
			}
			Validate.IsTrue(foundFile);
		}
		/// <summary>
		/// Validate if there is not DG-Taut message sent
		/// </summary>
		/// <param name="timeInSeconds">Integer parameter</param>
		/// <param name="retry">Boolean parameter</param>
		[UserCodeMethod]
		public static void validateNoDG_TAUT_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_TAUT_7 ptc_dg_taut = null;
			ptc_dg_taut = getMessageDG_TAUT_7(timeInSeconds, retry);
			if(ptc_dg_taut==null){
				Ranorex.Report.Info("No DG-TAUT message found");
			}
			else{
				Ranorex.Report.Error("DG-TAUT message found");
			}
			return;
		}
		
		/// <summary>
		/// Validate if there is not DC-TCON message sent
		/// </summary>
		/// <param name="timeInSeconds">Integer parameter</param>
		/// <param name="retry">Boolean parameter</param>
		
		[UserCodeMethod]
		public static void validateNoDC_TCON_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DC_TCON_7 ptc_dc_tcon = null;
			ptc_dc_tcon = getMessageDC_TCON_7(timeInSeconds, retry);
			if(ptc_dc_tcon==null){
				Ranorex.Report.Success("No DC-TCON message found");
			}
			else{
				Ranorex.Report.Failure("DC-TCON message found");
			}
			return;
		}
		
		/// <summary>
		/// Getting Header Sequence number from DC_TCON
		/// </summary>
		/// <param name="timeInSeconds">Integer parameter</param>
		/// <param name="retry">Boolean parameter</param>
		
		[UserCodeMethod]
		public static string getSequenceNumber_DC_TCON(int timeInSeconds=5, bool retry=true)
		{
			string sequenceNumber = null;
			PTC_DC_TCON_7 ptc_dc_tcon = null;
			ptc_dc_tcon = messages.SteMessageFileReader.getMessageDC_TCON_7(msgFilters.ToArray(), timeInSeconds, retry);
			if (ptc_dc_tcon != null)
			{
				sequenceNumber = ptc_dc_tcon.HEADER.SEQUENCE_NUMBER;
			}
			return sequenceNumber;
		}
		
		public static PTC_MQ_ERROR_1 getMessageDMQ_ERROR(int timeInSeconds=5, bool retry=true)
        {
            PTC_MQ_ERROR_1 ptc_mq_error = null;
            ptc_mq_error = messages.SteMessageFileReader.getMessageMQ_ERROR(msgFilters.ToArray(), timeInSeconds, retry);
            return ptc_mq_error;
        }        
        /// <summary>
        /// Validate if there is not MQ_ERROR message sent
        /// </summary>
        /// <param name="timeInSeconds">Integer parameter</param>
        /// <param name="retry">Boolean parameter</param>
        [UserCodeMethod]
        public static void validateMQ_ERROR_CN(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	PTC_MQ_ERROR_1 ptc_mq_error = null;
        	ptc_mq_error = getMessageDMQ_ERROR(timeInSeconds, retry);
        	if(ptc_mq_error==null){
        		Ranorex.Report.Failure("No MQ_ERROR message found");
        	}
        	else{
        		Ranorex.Report.Success("MQ_ERROR message found");
        	}
        	return;
        }        
        /// <summary>
        /// Getting Header Sequence number from DG_BULI
        /// </summary>
        /// <param name="timeInSeconds">Integer parameter</param>
        /// <param name="retry">Boolean parameter</param>
        [UserCodeMethod]
        public static string getSequenceNumber_BULI_7(int timeInSeconds, bool retry)
        {
        	string sequenceNumber = null;
        	PTC_DG_BULI_7 ptc_dg_buli = null;
        	ptc_dg_buli = messages.SteMessageFileReader.getMessageDG_BULI_7(msgFilters.ToArray(), timeInSeconds, retry);
        	if (ptc_dg_buli != null)
        	{
        		sequenceNumber = ptc_dg_buli.HEADER.SEQUENCE_NUMBER;
        	}
        	return sequenceNumber;
        	
        }        
        /// <summary>
        /// Getting Header Sequence number from DC_ASBI
        /// </summary>
        /// <param name="timeInSeconds">Integer parameter</param>
        /// <param name="retry">Boolean parameter</param>
        [UserCodeMethod]
        public static string getSequenceNumber_ASBI_7(int timeInSeconds, bool retry)
        {
        	string sequenceNumber = null;
        	PTC_DC_ASBI_7 ptc_dc_asbi  = null;
        	ptc_dc_asbi = messages.SteMessageFileReader.getMessageDC_ASBI_7(msgFilters.ToArray(), timeInSeconds, retry);
        	if (ptc_dc_asbi != null)
        	{
        		sequenceNumber = ptc_dc_asbi.HEADER.SEQUENCE_NUMBER;
        	}
        	return sequenceNumber;

        }        
        /// <summary>
        /// Getting Header Sequence number from DG_VABI
        /// </summary>
        /// <param name="timeInSeconds">Integer parameter</param>
        /// <param name="retry">Boolean parameter</param>
        [UserCodeMethod]
        public static string getSequenceNumber_VDBI_7(int timeInSeconds, bool retry)
        {
        	string sequenceNumber = null;
        	PTC_DG_VDBI_7 ptc_dg_vdbi = null;
        	ptc_dg_vdbi = messages.SteMessageFileReader.getMessageDG_VDBI_7(msgFilters.ToArray(), timeInSeconds, retry);
        	if (ptc_dg_vdbi != null)
        	{
        		sequenceNumber = ptc_dg_vdbi.HEADER.SEQUENCE_NUMBER;
        	}
        	return sequenceNumber;
        }
        
        /// <summary>
        /// Getting Header Sequence number from DC_TCON
        /// </summary>
        /// <param name="timeInSeconds">Integer parameter</param>
        /// <param name="retry">Boolean parameter</param>
        [UserCodeMethod]
        public static string getSequenceNumber_DC_TCON_7(int timeInSeconds, bool retry)
        {
        	string sequenceNumber = null;
        	PTC_DC_TCON_7  ptc_dc_tcon  = null;
        	ptc_dc_tcon = messages.SteMessageFileReader.getMessageDC_TCON_7(msgFilters.ToArray(), timeInSeconds, retry);
        	if (ptc_dc_tcon != null)
        	{
        		sequenceNumber = ptc_dc_tcon.HEADER.SEQUENCE_NUMBER;
        	}
        	return sequenceNumber;
        }
        
        /// <summary>
        /// Getting Header Sequence number from DG_TAUT
        /// </summary>
        /// <param name="timeInSeconds">Integer parameter</param>
        /// <param name="retry">Boolean parameter</param>
        [UserCodeMethod]
        public static string getSequenceNumber_DG_TAUT_7(int timeInSeconds, bool retry)
        {
        	string sequenceNumber = null;
        	PTC_DG_TAUT_7  ptc_dg_taut  = null;
        	ptc_dg_taut = messages.SteMessageFileReader.getMessageDG_TAUT_7(msgFilters.ToArray(), timeInSeconds, retry);
        	if (ptc_dg_taut != null)
        	{
        		sequenceNumber = ptc_dg_taut.HEADER.SEQUENCE_NUMBER;
        		Ranorex.Report.Info("DG-TAUT sequence number: " + sequenceNumber );
        	}
        	else
        	{
        	    Report.Info("DG-TAUT Not found in timeframe");
        	}
        	return sequenceNumber;
        }
        
        /// <summary>
        /// Getting Authority number from DG_TATU
        /// </summary>
        /// <param name="timeInSeconds">Integer parameter</param>
        /// <param name="retry">Boolean parameter</param>
        [UserCodeMethod]
        public static string getAuthorityNumber_DG_TAUT_7(int timeInSeconds, bool retry)
        {
        	string authorityNumber = null;
        	PTC_DG_TAUT_7 ptc_dg_taut = null;
        	ptc_dg_taut = messages.SteMessageFileReader.getMessageDG_TAUT_7(msgFilters.ToArray(), timeInSeconds, retry);
        	if (ptc_dg_taut != null)
        	{
        		authorityNumber = ptc_dg_taut.CONTENT.H_TRACK_AUTHORITY_NUMBER;
        	}
        	return authorityNumber;
        }
        
        /// <summary>
        /// Getting Sequence number from DC-ENED messages
        /// </summary>
        /// <param name="timeInSeconds">Integer parameter</param>
        /// <param name="retry">Boolean parameter</param>
        [UserCodeMethod]
        public static string getSequenceNumber_DC_ENED_7(int timeInSeconds, bool retry)
        {
        	string sequenceNumber = null;
        	PTC_DC_ENED_7 ptc_dc_ened = null;
			ptc_dc_ened = messages.SteMessageFileReader.getMessageDC_ENED_7(msgFilters.ToArray(), timeInSeconds, retry);
        	if (ptc_dc_ened != null)
        	{
        		sequenceNumber = ptc_dc_ened.HEADER.SEQUENCE_NUMBER;
        	}
        	return sequenceNumber;
        }
        
         /// <summary>
        /// Validate if there is no MQ_ERROR message
        /// </summary>
        /// <param name="timeInSeconds">Integer parameter</param>
        /// <param name="retry">Boolean parameter</param>
        [UserCodeMethod]
        public static void validateNoMQERROR_CN(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	PTC_MQ_ERROR_1 ptc_mq_error = null;
        	ptc_mq_error = getMessageDMQ_ERROR(timeInSeconds, retry);
        	if(ptc_mq_error==null){
        		Ranorex.Report.Success("No MQ_ERROR message found");
        	}
        	else{
        		Ranorex.Report.Failure("MQ_ERROR message found");
        	}
        	return;
        }
         /// <summary>
        /// Validate if there is no DG-BULI message
        /// </summary>
        /// <param name="timeInSeconds">Integer parameter</param>
        /// <param name="retry">Boolean parameter</param>
        [UserCodeMethod]
        public static void validateNoDG_BULI_7(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	PTC_DG_BULI_7 ptc_dg_buli = null;
        	ptc_dg_buli = getMessageDG_BULI_7(timeInSeconds, retry);
        	if (ptc_dg_buli == null)
        	{
        		Ranorex.Report.Success("Ste message containing filters not found");
        	}
        	else
        	{
        		Ranorex.Report.Failure("Ste message containing filters found");
        	}
        	return;
        }
        
        /// <summary>
        /// Validate if there is no DG-TRDL message
        /// </summary>
        /// <param name="timeInSeconds">Integer parameter</param>
        /// <param name="retry">Boolean parameter</param>
        [UserCodeMethod]
		public static void validateNoDG_TRDL_7(int timeInSeconds, bool retry)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			PTC_DG_TRDL_7 ptc_dg_trdl = null;
			ptc_dg_trdl = getMessageDG_TRDL_7(timeInSeconds, retry);
			if (ptc_dg_trdl == null)
        	{
        		Ranorex.Report.Success("Ste message containing filters not found");
        	}
        	else
        	{
        		Ranorex.Report.Failure("Ste message containing filters found");
        	}
			return;
		}

	}
}
