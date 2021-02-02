/*
 * Created by Ranorex
 * User: r07000021
 * Date: 12/29/2018
 * Time: 4:35 PM
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
using Oracle.Code_Utils;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using STE.Code_Utils;
using PDS_CORE.Code_Utils;
using PDS_NS.UserCodeCollections;

namespace PDS_NS.UserCodeCollections
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_RUM
    {
    	public static global::PDS_NS.TrackAuthorities_Repo Authoritiesrepo = global::PDS_NS.TrackAuthorities_Repo.Instance;
    	
        /// <summary>
    	/// Scrapes the Rum Track Authority Acknowledgement form to send a RUM CATA to complete the Authority
    	/// </summary>
    	/// <param name="OkTrackAuthority">Input:Clicks Ok for the Track Authority if accepted</param>
    	[UserCodeMethod]
    	public static void NS_RUMCATAResponseToPendingAuthority(string districtName, string userId, string divisionName, string action, string employeeName, bool OkTrackAuthority, bool closeForm=false){
    		int retry = 0;
    		string trackAuthorityNumber = Authoritiesrepo.Communications_Exchange_Ok_Authority.AuthorityNumberText.TextValue;
    		string authoritySeed = NS_Authorities.GetAuthoritySeed(trackAuthorityNumber);
			AuthorityObject authorityObj = NS_Authorities.GetAuthorityObject(authoritySeed);
			string effectiveTime = authorityObj.extendUntilTime;
			
    		while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0) && retry < 5)
    		{
    			Ranorex.Delay.Milliseconds(1000);
    			retry++;
    		}
    		
    		if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Rum Track Authority Acknowledgement Form not open");
    			return;
    		}
    		
    		if(closeForm)
    		{
    			if (!String.IsNullOrEmpty(authorityObj.extendUntilTime))
    			{
    				authorityObj.extendUntilTime = "";
    			}
    			GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.WindowControls.CloseInfo,
    			                                          Authoritiesrepo.Please_Confirm_PopUp.SelfInfo);
    			if (!Authoritiesrepo.Please_Confirm_PopUp.SelfInfo.Exists(0))
    			{
    				Ranorex.Report.Error("Could not find Please confirm Form");
    				return;
    			}
    			else
    			{
    				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Please_Confirm_PopUp.YesButtonInfo,
    				                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
    			}
    			return;
    		}
    		
    		
    		
			string[] employeeNames = employeeName.Split(' ');
			string employeeFirstName = "";
			string employeeMiddleName = "";
			string employeeLastName = "";
			if (employeeNames.Length == 2) { //First Name + Surname only, no middle
				employeeFirstName = employeeNames[0];
				employeeLastName = employeeNames[1];
			} else if (employeeNames.Length == 3) { //first name, middle initial only, last name
				employeeFirstName = employeeNames[0];
				employeeMiddleName = employeeNames[1];
				employeeLastName = employeeNames[2];
			} else {
				Ranorex.Report.Error("Improperly formatted name used, <First name> <singular Middle Initial> <Last Name, hyphens allowed> format only.");
				return;
			}
    		
			if (!String.IsNullOrEmpty(authorityObj.extendUntilTime) && action == "7")
			{
				authorityObj.extendUntilTime = "";
			}
			
			if(action == "6")
			{
				NS_Authorities.AddExtendUntilTime(authoritySeed, effectiveTime);
			}
			

    		PDS_NS.UserCodeCollections.NS_RUM_Messages.SendRD_CATA_1SimpleEmployeeName(authoritySeed, districtName, divisionName, action, employeeFirstName, employeeMiddleName, employeeLastName, "");
    		
    		if (OkTrackAuthority)
    		{
    			int retries = 0;
    			while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.Precision_Dispatch_System.SelfInfo.Exists(0) && retries < 6)
    			{
    				Ranorex.Delay.Seconds(1);
    				retries++;
    			}
    			if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.Precision_Dispatch_System.SelfInfo.Exists(0))
    			{
    				Ranorex.Report.Failure("Ok Prompt for Accepting Authority did not appear");
    				return;
    			} else {
    				int actionResult = int.Parse(action);
    				Ranorex.Report.Success("Authority Action status:"+ NS_RUM_Message_Validations.CATAActionNumberToTextEquivalent(actionResult));
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.Precision_Dispatch_System.OkButtonInfo,
    				                                                 Authoritiesrepo.Communications_Exchange_Ok_Authority.Precision_Dispatch_System.OkButtonInfo);
    			}
    		}
    		return;
    	}
    	
//    	/// <summary>
//    	/// Sending RUM Authority Extend Request RTER for an already issued Authority
//    	/// </summary>
//    	/// <param name="authoritySeed">Authority Seed</param>
//    	/// <param name="districtName">District in which Authority is present</param>
//    	/// <param name="optUserId">User Id, if not provided it will send STE</param>
//    	/// <param name="optDivisionName">Division Name: If not provided it will send Georgia for now</param>
//    	/// <param name="requestId">Reuqestor's Id</param>
//    	/// <param name="pfAddressee">PF Addressee to whom it is issued</param>
//    	/// <param name="pfAddresseeType">PF AddresseeType to whom it is issued</param>
//    	/// <param name="requestingEmployee">Employee requesting for the request</param>
//    	/// <param name="employeeFirstName">Requesting Employee first name</param>
//    	/// <param name="employeeMiddleName">Requesting Employee middle name</param>
//    	/// <param name="employeeLastName">Requesting Employee last name</param>
//    	/// <param name="extendByMins">Extend the Authority by mins, e.g. 120</param>
//    	[UserCodeMethod]
//    	public static void NS_RUMRTERExtendAuthority(string authoritySeed, string districtName, string userId, string divisionName, string requestId, string pfAddressee, string pfAddresseeType, string requestingEmployee, string employeeFirstName, string employeeMiddleName, string employeeLastName, string extendByMins, string ru_comments)
//    	{
//    		string trackAuthorityNumber = NS_Authorities.GetAuthorityNumber(authoritySeed);
//    		int convertedIntegerValue = 0;
//    		string effectiveTimeDifferenceFormatted = "";
//    		
//    		if (int.TryParse(extendByMins, out convertedIntegerValue))
//    		{
//
//    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(convertedIntegerValue);
//    			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("hh:mm tt");
//    		} else 
//    		{
//    			effectiveTimeDifferenceFormatted = extendByMins;
//    		}
//    		
//    		AuthorityObject authorityObj = NS_Authorities.GetAuthorityObject(authoritySeed);
//    		authorityObj.extendUntilTime = effectiveTimeDifferenceFormatted;
//			STE.Code_Utils.SendRumFileCollection_NS.createRD_RTER_1(districtName, userId, divisionName, requestId, pfAddressee, pfAddresseeType, requestingEmployee, trackAuthorityNumber, employeeFirstName, employeeMiddleName, employeeLastName, effectiveTimeDifferenceFormatted, ru_comments);
//    		
//    		return;
//    	}
    	
    	/// <summary>
    	/// Sending RUM Authority Void Request RTVR for an already issued Authority
    	/// </summary>
    	/// <param name="authoritySeed">Authority Seed</param>
    	/// <param name="districtName">District in which Authority is present</param>
    	/// <param name="optUserId">User Id, if not provided it will send STE</param>
    	/// <param name="optDivisionName">Division Name: If not provided it will send Georgia for now</param>
    	/// <param name="requestId">Reuqestor's Id</param>
    	/// <param name="pfAddressee">PF Addressee to whom it is issued</param>
    	/// <param name="pfAddresseeType">PF AddresseeType to whom it is issued</param>
    	/// <param name="requestingEmployee">Employee requesting for the request</param>
    	/// <param name="employeeFirstName">Requesting Employee first name</param>
    	/// <param name="employeeMiddleName">Requesting Employee middle name</param>
    	/// <param name="employeeLastName">Requesting Employee last name</param>
    	/// <param name="spafAck">Acknowledge Yes or No, to be send as 'Y' or 'N'</param>
    	[UserCodeMethod]
    	public static void NS_RUMRTVRVoidAuthority(string authoritySeed, string districtName, string userId, string divisionName, string requestId, string pfAddressee, string pfAddresseeType, string requestingEmployee, string employeeFirstName, string employeeMiddleName, string employeeLastName, string spafAck, string joint_occupancy, string ru_comments)
    	{
    		string trackAuthorityNumber = NS_Authorities.GetAuthorityNumber(authoritySeed);
    		string track_authority_id = "";
			string trackAuthorityUniqueIdStatus = CDMSEnvironment.GetCommonConfigValue_CDMS("RUM_TA_UID_ENABLE");        	
        	if(trackAuthorityUniqueIdStatus == "2")
        	{
        		track_authority_id = NS_Authorities.NS_ADMSGetAuthorityId(authoritySeed);
        	}
        	if(string.IsNullOrEmpty(joint_occupancy))
        	{
        		joint_occupancy = null;
        	}
    	    		    		
			STE.Code_Utils.SendRumFileCollection_NS.createRD_RTVR_1(districtName, userId, divisionName, requestId, pfAddressee, pfAddresseeType, requestingEmployee, trackAuthorityNumber, track_authority_id, employeeFirstName, employeeMiddleName, employeeLastName, spafAck, joint_occupancy, ru_comments);
    		
    		return;
    	}
    	
    	/// <summary>
    	/// Sending RUM Authority Rollup Request RTRR for an already issued Authority
    	/// </summary>
    	/// <param name="authoritySeed">Authority Seed</param>
    	/// <param name="districtName">District in which Authority is present</param>
    	/// <param name="userId">User Id, if not provided it will send STE</param>
    	/// <param name="divisionName">Division Name: If not provided it will send Georgia for now</param>
    	/// <param name="requestId">Reuqestor's Id</param>
    	/// <param name="pfAddressee">PF Addressee to whom it is issued</param>
    	/// <param name="pfAddresseeType">PF AddresseeType to whom it is issued</param>
    	/// <param name="requestingEmployee">Employee requesting for the request</param>
    	/// <param name="rollupLocation">Rollup Location to which the authority needs to rollup</param>
    	/// <param name="employeeFirstName">Requesting Employee first name</param>
    	/// <param name="employeeMiddleName">Requesting Employee middle name</param>
    	/// <param name="employeeLastName">Requesting Employee last name</param>
    	/// <param name="spafAck">Acknowledge Yes or No, to be send as 'Y' or 'N'</param>
//    	[UserCodeMethod]
//    	public static void NS_RUMRTRR_RollupAuthority(string authoritySeed, string districtName, string userId, string divisionName, string requestId, string pfAddressee, string pfAddresseeType, string requestingEmployee, string rollupLocation, string employeeFirstName, string employeeMiddleName, string employeeLastName, string spafAck, string ru_comments)
//    	{
//    		string trackAuthorityNumber = NS_Authorities.GetAuthorityNumber(authoritySeed);    		    	
//    		
//    		STE.Code_Utils.SendRumFileCollection_NS.createRD_RTRR_1(districtName, userId, divisionName, requestId, pfAddressee, pfAddresseeType, requestingEmployee, trackAuthorityNumber, rollupLocation, employeeFirstName, employeeMiddleName, employeeLastName, spafAck, ru_comments);
//    		
//    		return;
//    	}
    	
    	/// <summary>
        /// Use this send RTIR if you are using a data sheet that mirrors an FBA data sheet, several assumptions are taken into account for Simple
        /// Refer to UserCodeMethod createRD_RTIR_1 for explanation of parameters/fields to be interpreted from the data sheet.
        /// </summary>
        [UserCodeMethod]
    	public static void NS_SendRD_RTIR_FBAStyle(string optionalTrainSeed, string optionalEngineSeed, string district_name, string type, string to, string at, string box1_yn, string box1_void, string box2_yn, string box2_from, string box2_fsw, string box2_to, string box2_track1, string box2_to2, string box2_track2, string box2_to3, string box2_track3, string box2_zones, string box3_yn, string box3_loc1, string box3_loc1_cp, string box3_loc1_os, string box3_loc2, string box3_loc2_cp, string box3_track1, string box3_track2, string box3_track3, string box3_track4, string box3_track5, string zone_list, string box4_yn, string box4_from, string box4_fsw, string box4_to, string box4_track1, string box4_to2, string box4_track2, string box4_to3, string box4_track3, string box5_time, string box7_yn, string box9_yn, string box13_subdiv, string box13_subdiv_limit, string box13_subdiv_side, string spaf_ack, string requesting_employee, string employee_name,string ru_comments, string box1_joint_occupancy, string userId, string division_name)
    	{
    		NS_Authorities.NS_GetPendingAuthorityCountFromMainMenu();
    		string authorityNumber = "";
    		string box1_void_authority_id = "";
    		if (box1_void != "")
    		{
    			authorityNumber = NS_Authorities.GetAuthorityNumber(box1_void);
    			if (authorityNumber == null)
    			{
    				authorityNumber = box1_void;
    			}
    			string trackAuthorityUniqueIdStatus = CDMSEnvironment.GetCommonConfigValue_CDMS("RUM_TA_UID_ENABLE");
    			if(trackAuthorityUniqueIdStatus == "2")
    			{
    				box1_void_authority_id = ADMSEnvironment.GetAuthorityId_ADMS(authorityNumber);
    			}
    		}
    		
    		STE.Code_Utils.SendRumFileCollection_NS.FBACreateRD_RTIR(optionalTrainSeed, optionalEngineSeed, district_name, type, to, at, box1_yn, authorityNumber, box1_void_authority_id, box2_yn, box2_from, box2_fsw, box2_to, box2_track1, box2_to2, box2_track2, box2_to3, box2_track3, box2_zones, box3_yn, box3_loc1, box3_loc1_cp, box3_loc1_os, box3_loc2, box3_loc2_cp, box3_track1, box3_track2, box3_track3, box3_track4, box3_track5, zone_list, box4_yn, box4_from, box4_fsw, box4_to, box4_track1, box4_to2, box4_track2, box4_to3, box4_track3, box5_time, box7_yn, box9_yn, box13_subdiv, box13_subdiv_limit, box13_subdiv_side, spaf_ack, requesting_employee, employee_name, ru_comments, box1_joint_occupancy, userId, division_name);
    	}
    }
    
    	[UserCodeCollection]
    	public class NS_RUM_Message_Validations{
    		
    		/// <summary>
			/// Validate DR-AK01
			/// </summary>
			/// <param name="optMessageId">Unique identifier of the message type of the original message that caused the return status response</param>
			/// <param name="optResponseCode">Acknowledgment reponse code. Example: 'ACCEPT'. See RUM Message ICD for more information.</param>
			/// <param name="optTextField">Explanatory text.</param>
			/// <param name="timeInSeconds">Input:timeInSeconds</param>
			/// <param name="retry">Input:retry</param>
			[UserCodeMethod]
	    	public static void ValidateRUM_DR_AK01_ByContent(string optMessageId, string optResponseCode, string optTextField, int timeInSeconds = 5, bool retry = true)
	    	{
	    		Ranorex.Report.Info("TestStep", "Validating contents of DR_AK01");
	
				MsgFilter msgFilters = new MsgFilter();
	
				msgFilters.AddFilter(optMessageId, "MESSAGE_ID");
				msgFilters.AddFilter(optResponseCode, "RESPONSE_CODE");
				msgFilters.AddFilter(optTextField, "TEXT");
				
				string filters = msgFilters.FormatFilters();
				
				ReceiveRumFileCollection_NS.clearFilters();
				ReceiveRumFileCollection_NS.addValueToFilters(filters);
				ReceiveRumFileCollection_NS.validateDR_AK01_1(timeInSeconds, retry);
				ReceiveRumFileCollection_NS.clearFilters();
				
	    	}
	    	
	    	/// <summary>
	    	/// validate DR_EROR error message recived from PDS UI
	    	/// <param name="messageType"></param>
	    	/// <param name="messageError"></param>
	    	/// <param name="errorMessageFilter"></param>
	    	/// <param name="timeInSeconds"></param>
	    	/// <param name="retry"></param>
	    	/// </summary>
	    	[UserCodeMethod]
	    	public static void NS_validateDR_EROR_1(string messageType, string messageError, string errorMessageFilter, int timeInSeconds, bool retry)
	    	{
	    		Ranorex.Report.Info("TestStep", "Validating contents of DR_EROR");
	    		MsgFilter msgFilters = new MsgFilter();
	    		
	    		msgFilters.AddFilter(messageType, "MESSAGE_TYPE");
	    		msgFilters.AddFilter(messageError, "MESSAGE_ERROR");
	    		msgFilters.AddFilter(errorMessageFilter, "DESCRIPTION");
	    		
	    		string filters =msgFilters.FormatFilters();
	    		STE.Code_Utils.ReceiveRumFileCollection_NS.addValueToFilters(filters);
	    		STE.Code_Utils.ReceiveRumFileCollection_NS.validateDR_EROR_1(timeInSeconds, retry);
	    		STE.Code_Utils.ReceiveRumFileCollection_NS.clearFilters();
	    	}
	    	
	    	/// <summary>
			/// Validate DR_RTVD
			/// </summary>
			/// <param name="optMessageId">Unique identifier of the message type of the original message that caused the return status response</param>
			/// <param name="errorFeedback">Error feedback received </param>
			/// <param name="dispatcherResponse">dispatcher response text.</param>
			/// <param name="timeInSeconds">Input:timeInSeconds</param>
			/// <param name="retry">Input:retry</param>
			[UserCodeMethod]
	    	public static void ValidateDR_RTVD_ByContent(string optMessageId, string errorFeedback, string dispatcherResponse, int timeInSeconds = 5, bool retry = true)
	    	{
	    		Ranorex.Report.Info("TestStep", "Validating contents of DR_RTVD");
	
				MsgFilter msgFilters = new MsgFilter();
	
				msgFilters.AddFilter(optMessageId, "MESSAGE_ID");
				msgFilters.AddFilter(errorFeedback, "ERROR_FEEDBACK");
				msgFilters.AddFilter(dispatcherResponse, "DISPATCHER_RESPONSE");
				
				string filters = msgFilters.FormatFilters();
				
				ReceiveRumFileCollection_NS.clearFilters();
				ReceiveRumFileCollection_NS.addValueToFilters(filters);
				ReceiveRumFileCollection_NS.validateDR_RTVD_1(timeInSeconds, retry);
				ReceiveRumFileCollection_NS.clearFilters();
	    	}
	    	
	    	/// <summary>
	    	/// Validate DR-RTCD message is generated when cancelling the authority issue request
	    	/// </summary>
	    	/// <param name="optMessageId">Message ID DR-RTCD</param>
	    	/// <param name="district_Name">District name in which authority was issued</param>
	    	/// <param name="errorFeedback">error feedback message</param>
	    	/// <param name="dispatcherResponse">Dispatcher response</param>
	    	/// <param name="isDispatcherResponsePresent">True to validate if the Dispatcher response tag is present, else False to validate no dispatcher response tag is present</param>
	    	/// <param name="timeInSeconds">Time within seconds to validate the message</param>
	    	/// <param name="retry">True or False</param>
	    	[UserCodeMethod]
	    	public static void ValidateDR_RTCD_ByContent(string optMessageId,string district_Name, string errorFeedback, string dispatcherResponse, bool isDispatcherResponsePresent=true, int timeInSeconds = 5, bool retry = true)
	    	{
	    		Ranorex.Report.Info("TestStep", "Validating contents of DR_RTCD");
	
				MsgFilter msgFilters = new MsgFilter();
	
				msgFilters.AddFilter(optMessageId, "MESSAGE_ID");
				msgFilters.AddFilter(district_Name, "DISTRICT_NAME");
				msgFilters.AddFilter(errorFeedback, "ERROR_FEEDBACK");
				
				if(!isDispatcherResponsePresent)
				{
					msgFilters.AddFilter_NotExistTag("DISPATCHER_RESPONSE");
				} 
				else
				{
					msgFilters.AddFilter(dispatcherResponse, "DISPATCHER_RESPONSE");
				}
				
				
				string filters = msgFilters.FormatFilters();
				
				ReceiveRumFileCollection_NS.clearFilters();
				ReceiveRumFileCollection_NS.addValueToFilters(filters);
				ReceiveRumFileCollection_NS.validateDR_RTCD_1(timeInSeconds, retry);
				ReceiveRumFileCollection_NS.clearFilters();
	    	}
	    	
	    	/// <summary>
			/// validate DR_TAUT
			/// </summary>
			/// <param name="authoritySeed"></param>
			/// <param name="action"></param>
			/// <param name="district"></param>
			/// <param name="crewAckRequired"></param>
			/// <param name="timeInSeconds"></param>
			/// <param name="retry"></param>
			[UserCodeMethod]
	    	public static void ValidateDR_TAUT_ByContent(string authoritySeed, string action, string district, bool crewAckRequired, string optAdditionalFilters, int timeInSeconds = 120, bool retry = true)
	    	{
	    		AuthorityObject authorityObj = NS_Authorities.GetAuthorityObject(authoritySeed);
				if (authorityObj.Equals(null))
				{
					Ranorex.Report.Failure("Authority for authority seed {"+authoritySeed+"} not found.");
					return;
				}
				Ranorex.Report.Info("TestStep", "Validating contents of DR-TAUT");
				MsgFilter msgFilters = new MsgFilter();
				
				msgFilters.AddFilter(action, "ACTION");
				msgFilters.AddFilter("DR-TAUT", "MESSAGE_ID");
				msgFilters.AddFilter(district, "DISTRICT_NAME");
				msgFilters.AddFilter(crewAckRequired ? "Y" : "N", "CREW_ACK_REQUIRED");
				msgFilters.AddFilter(authorityObj.authorityNumber, "H_TRACK_AUTHORITY_NUMBER");
				msgFilters.AddFilter(authorityObj.trackAuthorityType, "H_ADDRESSEE_TYPE");
				if (!String.IsNullOrEmpty(authorityObj.authorityId))
				{
					msgFilters.AddFilter(authorityObj.authorityId, "H_TRACK_AUTHORITY_ID");
				}
				else
				{
					msgFilters.AddFilter_NotExistTag("H_TRACK_AUTHORITY_ID");
				}
				if (authorityObj.trackAuthorityType.Equals("TE"))
				{
					string trainId = NS_TrainID.GetTrainId(authorityObj.trainSeed);
					msgFilters.AddFilter(NS_TrainID.GetTrainSCAC(authorityObj.trainSeed), "H_SCAC");
					msgFilters.AddFilter(trainId.Substring(0, trainId.IndexOf(' ')), "H_SYMBOL");
					msgFilters.AddFilter(NS_TrainID.GetTrainSection(authorityObj.trainSeed), "H_SECTION");
	                msgFilters.AddFilter(NS_TrainID.GetEngineInitial(authorityObj.trainSeed, authorityObj.engineSeed), "H_ENGINE_INITIAL");
	                msgFilters.AddFilter(NS_TrainID.GetEngineNumber(authorityObj.trainSeed, authorityObj.engineSeed), "H_ENGINE_NUMBER");
	                string addresseTrackEngine = NS_TrainID.GetEngineInitial(authorityObj.trainSeed, authorityObj.engineSeed) + " " + NS_TrainID.GetEngineNumber(authorityObj.trainSeed, authorityObj.engineSeed);
	                msgFilters.AddFilter(addresseTrackEngine + @".*", "H_ADDRESSEE");
				}
				else
				{
					msgFilters.AddFilter(authorityObj.rWOrOtWorker, "H_ADDRESSEE");
				}
				
				msgFilters.AddFilter(authorityObj.at + @".*", "H_AT_LOCATION");
				
				//**BOX 1**
				if (!authorityObj.box1TrackAuthorityNumber.Equals(""))
				{
					msgFilters.AddFilter("Y", "S1_PRESENCE");
					msgFilters.AddFilter(authorityObj.box1TrackAuthorityNumber, "S1_TRACK_AUTHORITY_NUMBER");
					if(crewAckRequired && action == "0")
					{
						msgFilters.AddFilter(authorityObj.box1TrackAuthorityId, "S1_TRACK_AUTHORITY_ID");
					}
				}
				else
				{
					msgFilters.AddFilter("N", "S1_PRESENCE");
				}
				
				//**BOX 2**
				if (!authorityObj.box2ProceedFrom.Equals(""))
				{
					msgFilters.AddFilter("Y", "S2_PRESENCE");
					msgFilters.AddFilter(authorityObj.box2ProceedFrom, "S2_FROM_LOCATION"); //FSW values end up here, i.e. "NORTH SWITCH" TODO this will need to be handled later, find out how to determine direction
					msgFilters.AddFilter(authorityObj.box2To1, "S2_TO_LOCATION");
					msgFilters.AddFilter(authorityObj.box2Track1, "S2_TRACK");
					if (!authorityObj.box2To2.Equals(""))
					{
						msgFilters.AddFilter(authorityObj.box2To2, "S2_TO_LOCATION");
						msgFilters.AddFilter(authorityObj.box2Track2, "S2_TRACK");
						if (!authorityObj.box2To3.Equals(""))
						{
							msgFilters.AddFilter(authorityObj.box2To3, "S2_TO_LOCATION");
							msgFilters.AddFilter(authorityObj.box2Track3, "S2_TRACK");
						}
					}
					
				}
				else
				{
					msgFilters.AddFilter("N", "S2_PRESENCE");
				}
				
				//**BOX 3**
				if (!authorityObj.box3WorkBetweenFrom.Equals(""))
				{
					msgFilters.AddFilter("Y", "S3_PRESENCE");
					msgFilters.AddFilter(authorityObj.box3WorkBetweenFrom, "S3_BETWEEN_LOCATION");
					msgFilters.AddFilter(authorityObj.box3To, "S3_AND_LOCATION");
					msgFilters.AddFilter(authorityObj.box3Track1, "S3_TRACK_TEXT");
					if (!authorityObj.box3Track2.Equals(""))
					{
						msgFilters.AddFilter(authorityObj.box3Track2, "S3_TRACK_TEXT");
						if (!authorityObj.box3Track3.Equals(""))
						{
							msgFilters.AddFilter(authorityObj.box3Track3, "S3_TRACK_TEXT");
							if (!authorityObj.box3Track4.Equals(""))
							{
								msgFilters.AddFilter(authorityObj.box3Track4, "S3_TRACK_TEXT");
								if (!authorityObj.box3Track5.Equals(""))
								{
									msgFilters.AddFilter(authorityObj.box3Track5, "S3_TRACK_TEXT");
								}
							}
						}
					}
				}
				else
				{
					msgFilters.AddFilter("N", "S3_PRESENCE");
				}
				//**Box 4**
				if (!authorityObj.box4ProceedFrom.Equals(""))
				{
					msgFilters.AddFilter("Y", "S4_PRESENCE");
					msgFilters.AddFilter(authorityObj.box4ProceedFrom, "S4_FROM_LOCATION");
					msgFilters.AddFilter(authorityObj.box4To1, "S4_TO_LOCATION");
					msgFilters.AddFilter(authorityObj.box4Track1, "S4_TRACK");
					if (!authorityObj.box4To2.Equals(""))
					{
						msgFilters.AddFilter(authorityObj.box4To2, "S4_TO_LOCATION");
						msgFilters.AddFilter(authorityObj.box4Track2, "S4_TRACK");
						if (!authorityObj.box4To3.Equals(""))
						{
							msgFilters.AddFilter(authorityObj.box4To3, "S4_TO_LOCATION");
							msgFilters.AddFilter(authorityObj.box4Track3, "S4_TRACK");
						}
					}
				}
				else
				{
					msgFilters.AddFilter("N", "S4_PRESENCE");
				}
				//**BOX 5**
				if (!authorityObj.box5UntilInMinutes.Equals(""))
				{
					msgFilters.AddFilter("Y", "S5_PRESENCE");
					msgFilters.AddFilter(authorityObj.box5UntilInMinutes, "S5_INITIAL_UNTIL");
				}
				else
				{
					msgFilters.AddFilter("N", "S5_PRESENCE");
				}
				if (!String.IsNullOrEmpty(authorityObj.extendUntil1))
				{
					msgFilters.AddFilter("1", "S5_SEQUENCE");
					msgFilters.AddFilter(authorityObj.extendUntil1, "S5_EXTENDED_UNTIL");
					
					if (!String.IsNullOrEmpty(authorityObj.extendUntil2))
					{
						msgFilters.AddFilter("2", "S5_SEQUENCE");
						msgFilters.AddFilter(authorityObj.extendUntil2, "S5_EXTENDED_UNTIL");
						
						if (!String.IsNullOrEmpty(authorityObj.extendUntil3))
						{
							msgFilters.AddFilter("3", "S5_SEQUENCE");
							msgFilters.AddFilter(authorityObj.extendUntil3, "S5_EXTENDED_UNTIL");
						}
					}
				}
				else if(!String.IsNullOrEmpty(authorityObj.extendUntilTime))
				{
					msgFilters.AddFilter("1", "S5_SEQUENCE");
					msgFilters.AddFilter(authorityObj.extendUntilTime, "S5_EXTENDED_UNTIL");
				}
				else
				{
					msgFilters.AddFilter("0", "S5_COUNT");
				}
				//**BOX 6**
				if (!authorityObj.box6EngineSeed1.Equals(""))
				{
					msgFilters.AddFilter("Y", "S6_PRESENCE");
					msgFilters.AddFilter(NS_TrainID.FindEngineIdFromEngineSeed(authorityObj.box6EngineSeed1), "S6_ENGINE_ID");
					msgFilters.AddFilter(authorityObj.box6Engine1Direction, "S6_DIRECTION");
					if (!authorityObj.box6EngineSeed2.Equals(""))
					{
						msgFilters.AddFilter(NS_TrainID.FindEngineIdFromEngineSeed(authorityObj.box6EngineSeed2), "S6_ENGINE_ID");
						msgFilters.AddFilter(authorityObj.box6Engine2Direction, "S6_DIRECTION");
						if (!authorityObj.box6EngineSeed3.Equals(""))
						{
							msgFilters.AddFilter(NS_TrainID.FindEngineIdFromEngineSeed(authorityObj.box6EngineSeed3), "S6_ENGINE_ID");
							msgFilters.AddFilter(authorityObj.box6Engine3Direction, "S6_DIRECTION");
						}
					}
				}
				else
				{
					msgFilters.AddFilter("N", "S6_PRESENCE");
				}
				
				//**BOX 7**
				if (authorityObj.box7)
				{
					msgFilters.AddFilter("Y", "S7_PRESENCE");
				}
				else
				{
					msgFilters.AddFilter("N", "S7_PRESENCE");
				}
				
				//**BOX 8** TODO DIRECTIONS FOR EACH ENGINE, change authority object to reflect these are engines
				if (!authorityObj.box8EngineSeed1.Equals(""))
				{
					msgFilters.AddFilter("Y", "S8_PRESENCE");
					msgFilters.AddFilter(NS_TrainID.FindEngineIdFromEngineSeed(authorityObj.box8EngineSeed1), "S8_ENGINE_ID");
					msgFilters.AddFilter(authorityObj.box8Engine1Direction, "S8_DIRECTION");
					if (!authorityObj.box8EngineSeed2.Equals(""))
					{
						msgFilters.AddFilter(NS_TrainID.FindEngineIdFromEngineSeed(authorityObj.box8EngineSeed2), "S8_ENGINE_ID");
						msgFilters.AddFilter(authorityObj.box8Engine2Direction, "S8_DIRECTION");
						if (!authorityObj.box8EngineSeed3.Equals(""))
						{
							msgFilters.AddFilter(NS_TrainID.FindEngineIdFromEngineSeed(authorityObj.box8EngineSeed3), "S8_ENGINE_ID");
							msgFilters.AddFilter(authorityObj.box8Engine3Direction, "S8_DIRECTION");
						}
					}
				}
				else
				{
					msgFilters.AddFilter("N", "S8_PRESENCE");
				}
				
				//**BOX 9**
				if (authorityObj.box9)
				{
					msgFilters.AddFilter("Y", "S9_PRESENCE");
				}
				else
				{
					msgFilters.AddFilter("N", "S9_PRESENCE");
				}
				
				//**BOX 10**
				if (!authorityObj.box10Between1.Equals(""))
				{
					msgFilters.AddFilter("Y", "S10_PRESENCE");
					msgFilters.AddFilter(authorityObj.box10Between1, "S10_BETWEEN_LOCATION");
					msgFilters.AddFilter(authorityObj.box10Between2, "S10_AND_LOCATION");
				}
				else
				{
					msgFilters.AddFilter("N", "S10_PRESENCE");
				}
				
				//**Box 11**
				if (!authorityObj.box11StopShort.Equals(""))
				{
					msgFilters.AddFilter("Y", "S11_PRESENCE");
					msgFilters.AddFilter(authorityObj.box11StopShort, "S11_LOCATION");
					msgFilters.AddFilter(authorityObj.box11Track   , "S11_TRACK");
				}
				else
				{
					msgFilters.AddFilter("N", "S11_PRESENCE");
				}
				
				if (!authorityObj.box12RWIC1.Equals(""))
				{
					msgFilters.AddFilter("Y", "S12_PRESENCE");
					msgFilters.AddFilter(authorityObj.box12RWIC1, "S12_RWIC");
					msgFilters.AddFilter(authorityObj.box12Between1, "S12_BETWEEN_LOCATION");
	             	msgFilters.AddFilter(authorityObj.box12And1, "S12_AND_LOCATION");
	             	msgFilters.AddFilter(authorityObj.box12Track1, "S12_TRACK_TEXT");
	             	
	             	if (!authorityObj.box12RWIC2.Equals(""))
					{
						msgFilters.AddFilter(authorityObj.box12RWIC2, "S12_RWIC");
						msgFilters.AddFilter(authorityObj.box12Between2, "S12_BETWEEN_LOCATION");
		             	msgFilters.AddFilter(authorityObj.box12And2, "S12_AND_LOCATION");
		             	msgFilters.AddFilter(authorityObj.box12Track2, "S12_TRACK_TEXT");
		             	if (!authorityObj.box12RWIC3.Equals(""))
						{
							msgFilters.AddFilter(authorityObj.box12RWIC3, "S12_RWIC");
							msgFilters.AddFilter(authorityObj.box12Between3, "S12_BETWEEN_LOCATION");
			             	msgFilters.AddFilter(authorityObj.box12And3, "S12_AND_LOCATION");
			             	msgFilters.AddFilter(authorityObj.box12Track3, "S12_TRACK_TEXT");
		             	}
					}
				}
				else
				{
					msgFilters.AddFilter("N", "S12_PRESENCE");
				}
				
				//**BOX 13**TODO SUBDIVIDED LIMITS? Not in auth object
				if (!authorityObj.box13AutomaticInstructions.Equals("") || !authorityObj.box13ManualInstructions.Equals(""))
				{
					msgFilters.AddFilter("Y", "S13_PRESENCE");
					//TODO looks like more investigation into how box 13 actually deposits info into a ptc message is needed
				}
				else
				{
					msgFilters.AddFilter("N", "S13_PRESENCE");
				}
				
				if(!String.IsNullOrEmpty(optAdditionalFilters))
				{
					
					string[] filterArray = optAdditionalFilters.Split('|');
					foreach (string filterTag in filterArray)
					{
						Ranorex.Report.Info("Filter Tag: "+filterTag);
						msgFilters.AddFilter(filterTag);
						
					}
					
				}
				
				string filters = msgFilters.FormatFilters();
				ReceiveRumFileCollection_NS.clearFilters();
				ReceiveRumFileCollection_NS.addValueToFilters(filters);
				ReceiveRumFileCollection_NS.validateDR_TAUT_1(timeInSeconds,retry);
				ReceiveRumFileCollection_NS.clearFilters();
	    	}
	    	
	    /// <summary>
		/// Validate RD-CATA authority Action status
		/// </summary>
		/// <param name="authorityStatusAction">input:action type(issue,void,rollup etc)</param>
	
		public static string CATAActionNumberToTextEquivalent(int actionResult)
		{
			string actionName = "";
			switch(actionResult)
			{
				case 0:
					actionName =  "Issue Accept Authority";
					break;
				case 1:
					actionName =  "Issue Reject Authority";
					break;
				case 2:
					actionName = "Void Accept Authority";
					break;
				case 3:
					actionName = "Void Reject Authority";
					break;
				case 4:
					actionName = "Rollup Accept Authority";
					break;
				case 5:
					actionName = "Rollup Reject Authority";
					break;
				case 6:
					actionName = "Extend Accept Authority";
					break;
				case 7:
					actionName = "Extend Reject Authority";
					break;
				default:
					Ranorex.Report.Error("Ok Prompt not appered for Authority Action status");
					break;
			}
			
			return actionName;
		}
		
		/// <summary>
		/// Validate DR-BULI by Content
		/// </summary>
		/// <param name="bulletinSeed">Input:bulletinSeed</param>
		/// <param name="optMessageVersion">Input:optMessageVersion</param>
		/// <param name="optRouteCount">Input:optRouteCount</param>
		/// <param name="optDistrict">Input:optDistrict</param>
		/// <param name="timeInSeconds">Input:timeInSeconds</param>
		/// <param name="retry">Input:retry</param>
		[UserCodeMethod]
		public static void ValidateDR_BULI_ByContent(string bulletinSeed, string optMessageVersion = "1",  string optRouteCount = "", string optDistrict = "", int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DR-BULI");
			MsgFilter msg = new MsgFilter();
			NS_BulletinObject bulletinObj = NS_Bulletin.getBulletinObject(bulletinSeed);
			string bulletin_item_number = NS_Bulletin.GetBulletinNumber(bulletinSeed);
			string bulletin_item_type = NS_Bulletin.GetBulletinType(bulletinSeed);
			
			msg.AddFilter(bulletin_item_number, "BULLETIN_ITEM_NUMBER");
			msg.AddFilter(bulletin_item_type, "BULLETIN_ITEM_TYPE");
			msg.AddFilter(optMessageVersion, "MESSAGE_VERSION");
			msg.AddFilter(optRouteCount, "ROUTE_COUNT");
			msg.AddFilter(optDistrict, "DISTRICT_NAME");
			msg.AddFilter("Bulletin Item Number: "+bulletin_item_number, "TEXT");
			if (!String.IsNullOrEmpty(bulletinObj.bulletinId))
			{
				msg.AddFilter(bulletinObj.bulletinId, "BULLETIN_ID");
			}
			else
			{
				msg.AddFilter_NotExistTag("BULLETIN_ID");
			}
			string filters = msg.FormatFilters();
			ReceiveRumFileCollection_NS.clearFilters();
			ReceiveRumFileCollection_NS.addValueToFilters(filters);
			ReceiveRumFileCollection_NS.validateDR_BULI_1(timeInSeconds,retry);
			ReceiveRumFileCollection_NS.clearFilters();
			
		}
		
		
		/// <summary>
		/// Validate DR-BIVA
		/// </summary>
		/// <param name="bulletinSeed">Input:bulletinSeed</param>
		/// <param name="optDistrict">Input:optDistrict</param>
		/// <param name="optMessageVersion">Input:optMessageVersion</param>
		/// <param name="optMessageRevision">Input:optMessageRevision</param>
		/// <param name="timeInSeconds">Input:timeInSeconds</param>
		/// <param name="retry">Input:retry</param>
		[UserCodeMethod]
		public static void ValidateDR_BIVA_ByContent(string bulletinSeed, string optDistrict, string optMessageVersion = "1", int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DR-BIVA");
			MsgFilter msg = new MsgFilter();
			
			string bulletin_item_number = NS_Bulletin.GetBulletinNumber(bulletinSeed);

			msg.AddFilter(bulletin_item_number, "BULLETIN_ITEM_NUMBER");
			msg.AddFilter(optDistrict, "DISTRICT_NAME");
			msg.AddFilter(optMessageVersion, "MESSAGE_VERSION");
			
			string filters = msg.FormatFilters();
			ReceiveRumFileCollection_NS.clearFilters();
			ReceiveRumFileCollection_NS.addValueToFilters(filters);
			ReceiveRumFileCollection_NS.validateDR_BIVA_1(timeInSeconds, retry);
			ReceiveRumFileCollection_NS.clearFilters();
		}
		
		/// <summary>
		/// Validate DR-PTUR by Content
		/// </summary>
		/// <param name="optMessageVersion">Input:optMessageVersion</param>
		/// <param name="optDistrict">Input:optDistrict</param>
		/// <param name="optDivisonName">Input:optDivisonName</param>
		/// <param name="optFromstation">Input:optFromstation</param>
		/// <param name="optTostation">Input:optTostation</param>
		/// <param name="timeInSeconds">Input:timeInSeconds</param>
		/// <param name="retry">Input:retry</param>
		[UserCodeMethod]
		public static void ValidateDR_PTUR_ByContent( string optDistrict, string optDivisonName,string employeeName, string optFromStation, string optToStation, string track, string utlizationCount, string entryType, string optMessageVersion = "1", int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DR-PTUR");
			MsgFilter msg = new MsgFilter();
			msg.AddFilter(optMessageVersion, "MESSAGE_VERSION");
			msg.AddFilter(optDistrict, "DISTRICT_NAME");
			msg.AddFilter(optDivisonName, "DIVISION_NAME");	
			msg.AddFilter(employeeName, "REQUESTING_EMPLOYEE");
			msg.AddFilter(optFromStation, "FROM_STATION");
			msg.AddFilter(optToStation, "TO_STATION");
			msg.AddFilter(track, "TRACK");
			msg.AddFilter(utlizationCount, "UTILIZATION_COUNT");
			msg.AddFilter(entryType, "ENTRY_TYPE");
			string filters = msg.FormatFilters();
			ReceiveRumFileCollection_NS.clearFilters();
			ReceiveRumFileCollection_NS.addValueToFilters(filters);
			ReceiveRumFileCollection_NS.validateDR_PTUR_1(timeInSeconds,retry);
			ReceiveRumFileCollection_NS.clearFilters();
			
		}
		
		/// <summary>
		/// Validate DR-BICR by content
		/// </summary>
		/// <param name="messageId">Input:messageId</param>
		/// <param name="bulletinType">Input:bulletinType</param>
		/// <param name="optDistrict">Input:optDistrict</param>
		/// <param name="fieldCount">Input:fieldCount</param>
		/// <param name="optMessageVersion">Input:optMessageVersion</param>
		/// <param name="timeInSeconds">Input:timeInSeconds</param>
		/// <param name="retry">Input:retry</param>
		[UserCodeMethod]
		public static void ValidateDR_BICR_ByContent( string messageId, string bulletinType , string optDistrict, string fieldCount, string optMessageVersion = "1", int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DR-BICR");
			MsgFilter msg = new MsgFilter();
			msg.AddFilter(messageId, "MESSAGE_ID");
			msg.AddFilter(bulletinType, "BULLETIN_ITEM_TYPE");
			msg.AddFilter(optDistrict, "DISTRICT_NAME");
			msg.AddFilter(fieldCount, "FIELD_COUNT");
			msg.AddFilter(optMessageVersion, "MESSAGE_VERSION");
			string filters = msg.FormatFilters();
			ReceiveRumFileCollection_NS.clearFilters();
			ReceiveRumFileCollection_NS.addValueToFilters(filters);
			ReceiveRumFileCollection_NS.validateDR_BICR_1(timeInSeconds, retry);
			ReceiveRumFileCollection_NS.clearFilters();
		}
		
		/// <summary>
		/// Validate DR-BICD by content
		/// </summary>
		/// <param name="messageId">Input:messageId</param>
		/// <param name="optDistrict">Input:optDistrict</param>
		/// <param name="requestingEmployee">Input:requestingEmployee</param>
		/// <param name="errorFeedback">Input:errorFeedback</param>
		/// <param name="dispatcherResponse">Input:dispatcherResponse</param>
		/// <param name="optMessageVersion">Input:optMessageVersion</param>
		/// <param name="timeInSeconds">Input:timeInSeconds</param>
		/// <param name="retry">Input:retry</param>
		[UserCodeMethod]
		public static void ValidateDR_BICD_ByContent( string messageId, string optDistrict, string requestingEmployee, string errorFeedback, string dispatcherResponse, string optMessageVersion = "1", int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DR-BICD");
			MsgFilter msg = new MsgFilter();
			msg.AddFilter(messageId, "MESSAGE_ID");
			msg.AddFilter(requestingEmployee, "REQUESTING_EMPLOYEE");
			msg.AddFilter(optDistrict, "DISTRICT_NAME");
			msg.AddFilter(errorFeedback, "ERROR_FEEDBACK");
			msg.AddFilter(dispatcherResponse, "DISPATCHER_RESPONSE");
			msg.AddFilter(optMessageVersion, "MESSAGE_VERSION");
			string filters = msg.FormatFilters();
			ReceiveRumFileCollection_NS.clearFilters();
			ReceiveRumFileCollection_NS.addValueToFilters(filters);
			ReceiveRumFileCollection_NS.validateDR_BICD_1(timeInSeconds, retry);
			ReceiveRumFileCollection_NS.clearFilters();
		}
		
		/// <summary>
		/// Validate DR-BIVD by content
		/// </summary>
		/// <param name="bulletinSeed">Input:bulletinSeed</param>
		/// <param name="messageId">Input:messageId</param>
		/// <param name="optDistrict">Input:optDistrict</param>
		/// <param name="requestingEmployee">Input:requestingEmployee</param>
		/// <param name="errorFeedback">Input:errorFeedback</param>
		/// <param name="dispatcherResponse">Input:dispatcherResponse</param>
		/// <param name="optMessageVersion">Input:optMessageVersion</param>
		/// <param name="timeInSeconds">Input:timeInSeconds</param>
		/// <param name="retry">Input:timeInSeconds</param>
		[UserCodeMethod]
		public static void ValidateDR_BIVD_ByContent(string bulletinSeed, string messageId, string optDistrict, string requestingEmployee, string errorFeedback, string dispatcherResponse, string optMessageVersion = "1", int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DR-BIVD");
			MsgFilter msg = new MsgFilter();	
			string bulletin_item_number = NS_Bulletin.GetBulletinNumber(bulletinSeed);
			msg.AddFilter(bulletin_item_number, "BULLETIN_ITEM_NUMBER");
			msg.AddFilter(messageId, "MESSAGE_ID");
			msg.AddFilter(requestingEmployee, "REQUESTING_EMPLOYEE");
			msg.AddFilter(optDistrict, "DISTRICT_NAME");
			msg.AddFilter(errorFeedback, "ERROR_FEEDBACK");
			msg.AddFilter(dispatcherResponse, "DISPATCHER_RESPONSE");
			msg.AddFilter(optMessageVersion, "MESSAGE_VERSION");
			string filters = msg.FormatFilters();
			ReceiveRumFileCollection_NS.clearFilters();
			ReceiveRumFileCollection_NS.addValueToFilters(filters);
			ReceiveRumFileCollection_NS.validateDR_BIVD_1(timeInSeconds, retry);
			ReceiveRumFileCollection_NS.clearFilters();
		}	
    }
}
