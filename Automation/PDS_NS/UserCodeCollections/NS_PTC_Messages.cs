/*
 * Created by Ranorex
 * User: 503073759
 * Date: 11/29/2018
 * Time: 11:48 AM
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
using STE;
using STE.Code_Utils;
using PDS_CORE.Code_Utils;

using Env.Code_Utils;
using Oracle.Code_Utils;

namespace PDS_NS.UserCodeCollections
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_PTC_Messages
    {
    	 /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendCD_AK01_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac_trainSeed, 
                                           string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date, string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed, string header_heng_engine_number_engineSeed,
                                           string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_ack_message_id, string content_ack_sequence_number, string content_response_code, string content_text, string hostname)
        {
        	System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            //TODO: Need some mechanism for Ack Sequence Number
            
            STE.Code_Utils.messages.PTC.PTC_CD_AK01_7.createCD_AK01_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, 
                                                                      header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, 
                                                                      header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_ack_message_id, content_ack_sequence_number, 
                                                                      content_response_code, content_text, hostname);
        }
    	
    	 /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendCD_BARS_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac_trainSeed, 
                                           string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed, string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, 
										   string header_heng_engine_number_trainSeed, string header_heng_engine_number_engineSeed,
                                           string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_bulletin_item_number_bulletinSeed, string content_scac_trainSeed, string content_symbol_trainSeed,
                                           string content_section_trainSeed, string content_origin_date_trainSeed, string content_crew_ack_required, string content_electronic_ack_requested, string content_status_code, 
                                           string content_engine_initial_trainSeed, string content_engine_initial_engineSeed, string content_engine_number_trainSeed, string content_engine_number_engineSeed, string hostname)
        {
        	System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
            string content_symbol = NS_TrainID.GetTrainSymbol(content_symbol_trainSeed);
        	if (content_symbol == null)
        	{
        		content_symbol = content_symbol_trainSeed;
        	}
            string content_section = NS_TrainID.GetTrainSection(content_section_trainSeed);
            if (content_section == null)
        	{
        		content_section = content_section_trainSeed;
        	}
            string content_scac = NS_TrainID.GetTrainSCAC(content_scac_trainSeed);
            if (content_scac == null)
        	{
        		content_scac = content_scac_trainSeed;
        	}
            string content_origin_date = NS_TrainID.getOriginDate(content_origin_date_trainSeed);
            if (content_origin_date == null)
            {
            	content_origin_date = content_origin_date_trainSeed;
            }
            
            string content_engine_initial = NS_TrainID.GetEngineInitial(content_engine_initial_trainSeed, content_engine_initial_engineSeed);
            if (content_engine_initial == null)
        	{
        		content_engine_initial = content_engine_initial_engineSeed;
        	}
            string content_engine_number = NS_TrainID.GetEngineNumber(content_engine_number_trainSeed, content_engine_number_engineSeed);
            if (content_engine_number == null)
        	{
        		content_engine_number = content_engine_number_engineSeed;
        	}
            
            string content_bulletin_item_number = NS_Bulletin.GetBulletinNumber(content_bulletin_item_number_bulletinSeed);
            if (content_bulletin_item_number == null)
        	{
        		content_bulletin_item_number = content_bulletin_item_number_bulletinSeed;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_CD_BARS_7.createCD_BARS_7(header_event_date, header_event_time, header_sequence_number, header_message_version, 
        	                                                          header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, 
        	                                                          header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, 
        	                                                          header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, 
        	                                                          header_uid2_type, header_uid2, content_bulletin_item_number, content_scac, content_symbol, content_section, 
        	                                                          content_origin_date, content_crew_ack_required, content_electronic_ack_requested, content_status_code, 
        	                                                          content_engine_initial, content_engine_number, hostname);

        }
        
        
        /// <summary>
		/// Send a CD-CABI PTC message.
		/// </summary>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-CABI</param>
		/// <param name="bulletinSeed">The look-up key for the bulletin information used to send the CD-CABI</param>
		/// <param name="trigger_type">Crew acknoledgement type: 'Manual' or 'Prompt'</param>
        [UserCodeMethod]
        public static void SendCD_CABI_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac_trainSeed, 
                                           string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed, string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed, string header_heng_engine_number_engineSeed,
                                           string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac_trainSeed, string content_symbol_trainSeed, string content_section_trainSeed, string content_origin_date_trainSeed, string content_bulletin_item_number_bulletinSeed, 
                                           string content_crew_ack_type, string hostname)
        {
        	System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            string content_symbol = NS_TrainID.GetTrainSymbol(content_symbol_trainSeed);
        	if (content_symbol == null)
        	{
        		content_symbol = content_symbol_trainSeed;
        	}
            string content_section = NS_TrainID.GetTrainSection(content_section_trainSeed);
            if (content_section == null)
        	{
        		content_section = content_section_trainSeed;
        	}
            string content_scac = NS_TrainID.GetTrainSCAC(content_scac_trainSeed);
            if (content_scac == null)
        	{
        		content_scac = content_scac_trainSeed;
        	}
            string content_origin_date = NS_TrainID.getOriginDate(content_origin_date_trainSeed);
            if (content_origin_date == null)
            {
            	content_origin_date = content_origin_date_trainSeed;
            }
            
            string content_bulletin_item_number = NS_Bulletin.GetBulletinNumber(content_bulletin_item_number_bulletinSeed);
            if (content_bulletin_item_number == null)
        	{
        		content_bulletin_item_number = content_bulletin_item_number_bulletinSeed;
        	}
        	
        	STE.Code_Utils.messages.PTC.PTC_CD_CABI_7.createCD_CABI_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, 
			                                                          header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, content_section, content_origin_date, 
			                                                          content_bulletin_item_number, content_crew_ack_type, hostname);
        	                                                        
        }
        
        /// <summary>
		/// Send a CD-CABI PTC message.
		/// </summary>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-CABI</param>
		/// <param name="bulletinSeed">The look-up key for the bulletin information used to send the CD-CABI</param>
		/// <param name="trigger_type">Crew acknoledgement type: 'Manual' or 'Prompt'</param>
        [UserCodeMethod]
        public static void SendCD_CABI_7_Simple(string trainSeed, string bulletinSeed, string content_crew_ack_type, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = "";
        	string header_htrn_symbol_trainSeed = "";
        	string header_htrn_section_trainSeed = "";
        	string header_htrn_origin_date_trainSeed = "";
        	string header_heng_engine_initial_trainSeed = "";
        	string header_heng_engine_initial_engineSeed = "";
        	string header_heng_engine_number_trainSeed = "";
        	string header_heng_engine_number_engineSeed = "";
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	string content_bulletin_item_number_bulletinSeed = bulletinSeed;
        	
        	SendCD_CABI_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, header_source_sys, 
                                           header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac_trainSeed, 
                                           header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed, header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed,
                                           header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac_trainSeed, content_symbol_trainSeed, content_section_trainSeed, content_origin_date_trainSeed, content_bulletin_item_number_bulletinSeed, 
                                           content_crew_ack_type, hostname);
        }
        
        /// <summary>
        /// Send the CD-CABV PTC message
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="bulletinSeed">Input:bulletinSeed</param>
		[UserCodeMethod]
        public static void SendCD_CABV_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac_trainSeed, 
                                           string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed, string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed, string header_heng_engine_number_engineSeed,
                                           string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac_trainSeed, string content_symbol_trainSeed, string content_section_trainSeed, string content_origin_date_trainSeed, string content_bulletin_item_number_bulletinSeed, 
                                           string hostname)
		{
			System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            string content_symbol = NS_TrainID.GetTrainSymbol(content_symbol_trainSeed);
        	if (content_symbol == null)
        	{
        		content_symbol = content_symbol_trainSeed;
        	}
            string content_section = NS_TrainID.GetTrainSection(content_section_trainSeed);
            if (content_section == null)
        	{
        		content_section = content_section_trainSeed;
        	}
            string content_scac = NS_TrainID.GetTrainSCAC(content_scac_trainSeed);
            if (content_scac == null)
        	{
        		content_scac = content_scac_trainSeed;
        	}
            string content_origin_date = NS_TrainID.getOriginDate(content_origin_date_trainSeed);
            if (content_origin_date == null)
            {
            	content_origin_date = content_origin_date_trainSeed;
            }
            
            string content_bulletin_item_number = NS_Bulletin.GetBulletinNumber(content_bulletin_item_number_bulletinSeed);
            if (content_bulletin_item_number == null)
        	{
        		content_bulletin_item_number = content_bulletin_item_number_bulletinSeed;
        	}
			
			STE.Code_Utils.messages.PTC.PTC_CD_CABV_7.createCD_CABV_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, 
			                                                          header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, 
			                                                          header_uid2, content_scac, content_symbol, content_section, content_origin_date, content_bulletin_item_number, hostname);
		}
        
        /// <summary>
        /// Send the CD-CABV PTC message
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="bulletinSeed">Input:bulletinSeed</param>
		[UserCodeMethod]
        public static void SendCD_CABV_7_Simple(string trainSeed, string bulletinSeed, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = "";
        	string header_htrn_symbol_trainSeed = "";
        	string header_htrn_section_trainSeed = "";
        	string header_htrn_origin_date_trainSeed = "";
        	string header_heng_engine_initial_trainSeed = "";
        	string header_heng_engine_initial_engineSeed = "";
        	string header_heng_engine_number_trainSeed = "";
        	string header_heng_engine_number_engineSeed = "";
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	string content_bulletin_item_number_bulletinSeed = bulletinSeed;
        	
        	SendCD_CABV_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, header_source_sys, 
                                           header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac_trainSeed, 
                                           header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed, header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed,
                                           header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac_trainSeed, content_symbol_trainSeed, content_section_trainSeed, content_origin_date_trainSeed, content_bulletin_item_number_bulletinSeed, 
                                           hostname);
        }
        
        /// <summary>
		/// Send a CD-CSGF PTC message.
		/// </summary>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-CSGF</param>
		/// <param name="engineSeed">The look-up key for the engine information used to send the CD-CSGF</param>
		/// <param name="signoffType">Sign-off Type: 'CREW', 'CUTOUT', or 'TIMEOUT'</param>
		[UserCodeMethod]
        public static void SendCD_CSGF_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac_trainSeed, 
                                           string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed, string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed, string header_heng_engine_number_engineSeed,
                                           string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac_trainSeed, string content_symbol_trainSeed, string content_section_trainSeed, string content_origin_date_trainSeed, string content_signoff_type, 
                                           string hostname)
        {
			System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            string content_symbol = NS_TrainID.GetTrainSymbol(content_symbol_trainSeed);
        	if (content_symbol == null)
        	{
        		content_symbol = content_symbol_trainSeed;
        	}
            string content_section = NS_TrainID.GetTrainSection(content_section_trainSeed);
            if (content_section == null)
        	{
        		content_section = content_section_trainSeed;
        	}
            string content_scac = NS_TrainID.GetTrainSCAC(content_scac_trainSeed);
            if (content_scac == null)
        	{
        		content_scac = content_scac_trainSeed;
        	}
            string content_origin_date = NS_TrainID.getOriginDate(content_origin_date_trainSeed);
            if (content_origin_date == null)
            {
            	content_origin_date = content_origin_date_trainSeed;
            }
			
        	STE.Code_Utils.messages.PTC.PTC_CD_CSGF_7.createCD_CSGF_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys,
        	                                                          header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, 
        	                                                          header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, 
        	                                                          content_section, content_origin_date, content_signoff_type, hostname);
        }
        
        /// <summary>
		/// Send a CD-CSGF PTC message.
		/// </summary>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-CSGF</param>
		/// <param name="engineSeed">The look-up key for the engine information used to send the CD-CSGF</param>
		/// <param name="signoffType">Sign-off Type: 'CREW', 'CUTOUT', or 'TIMEOUT'</param>
		[UserCodeMethod]
        public static void SendCD_CSGF_7_Simple(string trainSeed, string engineSeed, string signoffType, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = engineSeed;
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = engineSeed;
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	string content_signoff_type = signoffType;
            
        	SendCD_CSGF_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, header_source_sys, 
                                           header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac_trainSeed, 
                                           header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed, header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed,
                                           header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac_trainSeed, content_symbol_trainSeed, content_section_trainSeed, content_origin_date_trainSeed, content_signoff_type, 
                                           hostname);
        }

		[UserCodeMethod]
		public static void SendCD_BARS_7_Simple(string trainSeed, string engineSeed, string bulletinSeed, string crewAckRequired, string electronicAckRequested, string statusCode, string hostName)
		{
			string header_event_date_offset_days = "0";
			string header_event_time_offset_minutes = "0";
			string header_sequence_number = "Default";
			string header_message_version = "7";
			string header_message_revision = "0";
			string header_source_sys = "CI";
			string header_destination_sys = "CAD";
			string header_user_id = "UserId";
			string header_track_file_version = "1234";
			string header_district_name = "";
			string header_district_scac = "";
			string header_uid1_type = ""; 
			string header_uid1 = ""; 
			string header_uid2_type = ""; 
			string header_uid2 = ""; 
			string header_htrn_scac_trainSeed = trainSeed;
			string header_htrn_symbol_trainSeed = trainSeed; 
			string header_htrn_section_trainSeed = trainSeed; 
			string header_htrn_origin_date_trainSeed = trainSeed; 
			string header_heng_engine_initial_trainSeed = trainSeed; 
			string header_heng_engine_initial_engineSeed = engineSeed; 
			string header_heng_engine_number_trainSeed = trainSeed; 
			string header_heng_engine_number_engineSeed = engineSeed;
			string content_bulletin_item_number_bulletinSeed = bulletinSeed; 
			string content_scac_trainSeed = trainSeed; 
			string content_symbol_trainSeed = trainSeed;
			string content_section_trainSeed = trainSeed; 
			string content_origin_date_trainSeed = trainSeed; 
			string content_crew_ack_required = crewAckRequired; 
			string content_electronic_ack_requested = electronicAckRequested; 
			string content_status_code = statusCode; 
			string content_engine_initial_trainSeed = trainSeed; 
			string content_engine_initial_engineSeed = engineSeed;
			string content_engine_number_trainSeed = trainSeed; 
			string content_engine_number_engineSeed = engineSeed; 

			sendCD_BARS_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, header_source_sys, 
                                           header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac_trainSeed, 
                                           header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed, header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, 
										   header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed,
                                           header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_bulletin_item_number_bulletinSeed, content_scac_trainSeed, content_symbol_trainSeed,
                                           content_section_trainSeed, content_origin_date_trainSeed, content_crew_ack_required, content_electronic_ack_requested, content_status_code, 
                                           content_engine_initial_trainSeed, content_engine_initial_engineSeed, content_engine_number_trainSeed, content_engine_number_engineSeed, hostName);
		}
        
        
        /// <summary>
		/// Send a CD-CSGN PTC message.
		/// </summary>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-CSGN</param>
		/// <param name="crewSeed">The look-up key for the crew information used to send the CD-CSGN</param>
		/// <param name="engineSeed">The look-up key for the engine information used to send the CD-CSGN</param>
		/// <param name="districts">A pipe-delimited string in '[division]|[district]' format</param> 
		[UserCodeMethod]
        public static void SendCD_CSGN_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac_trainSeed, 
                                           string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed, string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed, 
                                           string header_heng_engine_number_engineSeed, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac_trainSeed, string content_symbol_trainSeed, string content_section_trainSeed, 
                                           string content_origin_date_trainSeed, string content_engine_initial_trainSeed, string content_engine_initial_engineSeed, string content_engine_number_trainSeed, string content_engine_number_engineSeed, 
                                           string content_employee_id_crewSeed, string content_employee_first_crewSeed, string content_employee_middle_crewSeed, 
                                           string content_employee_last_crewSeed, string optional_new_crew_crewSeed, string optional_new_engine_trainSeed, string optional_new_engine_engineSeed, string hostname)
        {
        	System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            string content_symbol = NS_TrainID.GetTrainSymbol(content_symbol_trainSeed);
        	if (content_symbol == null)
        	{
        		content_symbol = content_symbol_trainSeed;
        	}
            string content_section = NS_TrainID.GetTrainSection(content_section_trainSeed);
            if (content_section == null)
        	{
        		content_section = content_section_trainSeed;
        	}
            string content_scac = NS_TrainID.GetTrainSCAC(content_scac_trainSeed);
            if (content_scac == null)
        	{
        		content_scac = content_scac_trainSeed;
        	}
            string content_origin_date = NS_TrainID.getOriginDate(content_origin_date_trainSeed);
            if (content_origin_date == null)
            {
            	content_origin_date = content_origin_date_trainSeed;
            }
            
            string content_engine_initial = NS_TrainID.GetEngineInitial(content_engine_initial_trainSeed, content_engine_initial_engineSeed);
            if (content_engine_initial == null)
        	{
        		content_engine_initial = content_engine_initial_engineSeed;
        	}
            string content_engine_number = NS_TrainID.GetEngineNumber(content_engine_number_trainSeed, content_engine_number_engineSeed);
            if (content_engine_number == null)
        	{
        		content_engine_number = content_engine_number_engineSeed;
        	}
            
            string content_employee_id = NS_CrewClass.GetCrewMemberEmployeeId(content_employee_id_crewSeed);
        	if (content_employee_id == null)
        	{
        		if (content_employee_id_crewSeed == "Default")
        		{
        			content_employee_id = NS_EmployeeId.EmployeeId;
        		} else {
        			content_employee_id = content_employee_id_crewSeed;
        		}
        	}
            string content_employee_first = NS_CrewClass.GetCrewMemberFirstInitial(content_employee_first_crewSeed);
            if (content_employee_first == null)
        	{
        		content_employee_first = content_employee_first_crewSeed;
        	}
            string content_employee_middle = NS_CrewClass.GetCrewMemberMiddleInitial(content_employee_middle_crewSeed);
            if (content_employee_middle == null)
        	{
        		content_employee_middle = content_employee_middle_crewSeed;
        	}
            string content_employee_last = NS_CrewClass.GetCrewMemberLastName(content_employee_last_crewSeed);
            if (content_employee_last == null)
        	{
        		content_employee_last = content_employee_last_crewSeed;
        	}
            
            if (optional_new_crew_crewSeed != "")
            {
            	string current_timezone = TimeZone.CurrentTimeZone.StandardName;
            	//Only do Central or Eastern for now
            	if (current_timezone == "Eastern Standard Time")
            	{
            		current_timezone = "E";
            	} else if (current_timezone == "Central Standard Time")
            	{
            		current_timezone = "C";
            	}
            	NS_CrewClass.CreateCrewMemberObject(optional_new_crew_crewSeed, onDutyLocation: "", offDutyLocation: "", onTrainLocation: "", onPassCount: "", onLocationMP: "", offTrainLocation: "", offPassCount: "", offLocationMP: "", crewPosition: "", crewMemberType: "", firstInitial: content_employee_first, middleInitial: content_employee_middle,
            	                                    lastName: content_employee_last, ssn: "", employeeId: content_employee_id, onDutyDate: now.ToString("MMddyyyy"), onDutyTime: now.ToString("HHmmss"), onDutyTimezone: current_timezone, onTrainDate: now.ToString("MMddyyyy"), onTrainTime: now.ToString("HHmmss"), onTrainTimezone: current_timezone,
            	                                    hosExpireDate: "", hosExpireTime: "", hosExpireTimezone: "", offDutyDate: "", offDutyTime: "", offDutyTimezone: "", offTrainDate: "", offTrainTime: "", offTrainTimezone: "", crewId: "", segment: "");
            }
            
            if (optional_new_engine_engineSeed != "")
            {
        		string engine_record = content_engine_initial + "|" + content_engine_number + "|||||||||||||N|Y|N|N||0|||0||0|";
        		NS_TrainID.CreateEngineConsistRecord(optional_new_engine_trainSeed, optional_new_engine_engineSeed, engine_record, assignedDivision: "", helperCrewPoolId: "", defaultDataApplied: "True", reportingPassCount: "", reportingLocation: "", reportingSource: "", messagePurpose: "");
            }
			
			STE.Code_Utils.messages.PTC.PTC_CD_CSGN_7.createCD_CSGN_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, 
			                                                          header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, content_section, content_origin_date, 
			                                                          content_engine_initial, content_engine_number, content_employee_id, content_employee_first, content_employee_middle, content_employee_last, hostname);
        }
        
    	
		/// <summary>
		/// Send a CD-CSGN PTC message.
		/// </summary>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-CSGN</param>
		/// <param name="crewSeed">The look-up key for the crew information used to send the CD-CSGN</param>
		/// <param name="engineSeed">The look-up key for the engine information used to send the CD-CSGN</param>
		[UserCodeMethod]
        public static void SendCD_CSGN_7Simple(string trainSeed, string crewSeed, string engineSeed, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = engineSeed;
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = engineSeed;
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	string content_engine_initial_trainSeed = trainSeed;
        	string content_engine_initial_engineSeed = engineSeed;
        	string content_engine_number_trainSeed = trainSeed;
        	string content_engine_number_engineSeed = engineSeed;
        	string content_employee_id_crewSeed = crewSeed;
        	string content_employee_first_crewSeed = crewSeed;
        	string content_employee_middle_crewSeed = crewSeed;
        	string content_employee_last_crewSeed = crewSeed;
        	
        	string optional_new_crew_crewSeed = "";
        	string optional_new_engine_trainSeed = "";
        	string optional_new_engine_engineSeed = "";
            
            SendCD_CSGN_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, header_source_sys, 
        	              header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac_trainSeed,
                          header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed, header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed, 
                          header_heng_engine_number_engineSeed, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac_trainSeed, content_symbol_trainSeed, content_section_trainSeed, 
                          content_origin_date_trainSeed, content_engine_initial_trainSeed, content_engine_initial_engineSeed, content_engine_number_trainSeed, content_engine_number_engineSeed, 
                          content_employee_id_crewSeed, content_employee_first_crewSeed, content_employee_middle_crewSeed, 
                          content_employee_last_crewSeed, optional_new_crew_crewSeed, optional_new_engine_trainSeed, optional_new_engine_engineSeed, hostname);
        }
        
        /// <summary>
		/// Send a CD-CSGN PTC message.
		/// </summary>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-CSGN</param>
		/// <param name="crewSeed">The look-up key for the crew information used to send the CD-CSGN</param>
		/// <param name="engineSeed">The look-up key for the engine information used to send the CD-CSGN</param>
		[UserCodeMethod]
        public static void SendCD_CSGN_7Simple_NewEngine(string trainSeed, string crewSeed, string engineSeed, string engineRecord, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = "";
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = "";
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	string content_engine_initial_trainSeed = trainSeed;
        	string content_engine_initial_engineSeed = "";
        	string content_engine_number_trainSeed = trainSeed;
        	string content_engine_number_engineSeed = "";
        	string content_employee_id_crewSeed = crewSeed;
        	string content_employee_first_crewSeed = crewSeed;
        	string content_employee_middle_crewSeed = crewSeed;
        	string content_employee_last_crewSeed = crewSeed;
        	
        	string optional_new_crew_crewSeed = "";
        	string optional_new_engine_trainSeed = trainSeed;
        	string optional_new_engine_engineSeed = engineSeed;
        	
        	
        	string[] engineRecordArray = engineRecord.Split('|');
        	if (engineRecordArray.Length >= 2)
            {
        		header_heng_engine_initial_engineSeed = engineRecordArray[0];
        		content_engine_initial_engineSeed = engineRecordArray[0];
        		header_heng_engine_number_engineSeed = engineRecordArray[1];
        		content_engine_number_engineSeed = engineRecordArray[1];
        	} else {
        		Ranorex.Report.Error("Engine Record has a length of {" + engineRecordArray.Length.ToString() + "} instead of the minimum expected of 2, not creating csgn");
        		return;
        	}
            
            SendCD_CSGN_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, header_source_sys, 
        	              header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac_trainSeed,
                          header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed, header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed, 
                          header_heng_engine_number_engineSeed, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac_trainSeed, content_symbol_trainSeed, content_section_trainSeed, 
                          content_origin_date_trainSeed, content_engine_initial_trainSeed, content_engine_initial_engineSeed, content_engine_number_trainSeed, content_engine_number_engineSeed, 
                          content_employee_id_crewSeed, content_employee_first_crewSeed, content_employee_middle_crewSeed, 
                          content_employee_last_crewSeed, optional_new_crew_crewSeed, optional_new_engine_trainSeed, optional_new_engine_engineSeed, hostname);
        }
        
		/// <summary>
		/// Send a CD-CSGN PTC message while using engine details that have not been sent to PDS.
		/// </summary>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-CSGN</param>
		/// <param name="crewSeed">The look-up key for the crew information used to send the CD-CSGN</param>
		/// <param name="engineSeed">The look-up key for the engine information used to send the CD-CSGN</param>
		/// <param name="districts">A pipe-delimited string in '[division]|[district]' format</param>
		/// <param name="assignedDivision">The assigned division of the engine corresponding to engineSeed</param>
		/// <param name="helperCrewPoolId">Pool name of the crew of the engine corresponding to engineSeed</param>
		/// <param name="defaultDataApplied">Whether or not to apply default HP to locomotive: 'Y' or 'N'</param>
		/// <param name="reportingPassCount">The number of route traversals through reportingLocation OPSTA for engine</param>
		/// <param name="reportingLocation">The message update location for engine</param>
		/// <param name="reportingSource">The source of locomotive information</param>
		/// <param name="purpose">Message purpose (e.g. (A) Add engine / (D) Delete engine / (R) Replace consist with included engines)</param>
		/// <param name="engineRecord">Pipe-delimited string of engine record</param>		
        [UserCodeMethod]
        public static void SendCD_CSGN_7Simple_NewCrewNewEngine(string trainSeed, string crewSeed, string engineSeed, string crewMemberRecord, string engineRecord, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = "";
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = "";
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	string content_engine_initial_trainSeed = trainSeed;
        	string content_engine_initial_engineSeed = "";
        	string content_engine_number_trainSeed = trainSeed;
        	string content_engine_number_engineSeed = "";
        	string content_employee_id_crewSeed = "Default";
        	string content_employee_first_crewSeed = "";
        	string content_employee_middle_crewSeed = "";
        	string content_employee_last_crewSeed = "";
        	
        	string optional_new_crew_crewSeed = crewSeed;
        	string optional_new_engine_trainSeed = trainSeed;
        	string optional_new_engine_engineSeed = engineSeed;
        	
        	
        	string[] engineRecordArray = engineRecord.Split('|');
        	if (engineRecordArray.Length >= 2)
            {
        		header_heng_engine_initial_engineSeed = engineRecordArray[0];
        		content_engine_initial_engineSeed = engineRecordArray[0];
        		header_heng_engine_number_engineSeed = engineRecordArray[1];
        		content_engine_number_engineSeed = engineRecordArray[1];
        	} else {
        		Ranorex.Report.Error("Engine Record has a length of {" + engineRecordArray.Length.ToString() + "} instead of the minimum expected of 2, not creating csgn");
        		return;
        	}
        	
        	string[] crewMemberRecordArray = crewMemberRecord.Split('|');
        	//Assume it's the long form of crew record
        	if (crewMemberRecordArray.Length >= 15)
        	{
        		content_employee_first_crewSeed = crewMemberRecordArray[10];
        		content_employee_middle_crewSeed = crewMemberRecordArray[11];
        		content_employee_last_crewSeed = crewMemberRecordArray[12];
        	} else if (crewMemberRecordArray.Length == 3)
        	{
        		content_employee_first_crewSeed = crewMemberRecordArray[0];
        		content_employee_middle_crewSeed = crewMemberRecordArray[1];
        		content_employee_last_crewSeed = crewMemberRecordArray[2];
        	} else {
        		Ranorex.Report.Error("Crew Record has a length of {" + crewMemberRecordArray.Length.ToString() + "} instead of the minimum expected of 4 or >= 15, not creating csgn");
        		return;
        	}
            
            SendCD_CSGN_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, header_source_sys, 
        	              header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac_trainSeed,
                          header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed, header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed, 
                          header_heng_engine_number_engineSeed, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac_trainSeed, content_symbol_trainSeed, content_section_trainSeed, 
                          content_origin_date_trainSeed, content_engine_initial_trainSeed, content_engine_initial_engineSeed, content_engine_number_trainSeed, content_engine_number_engineSeed, 
                          content_employee_id_crewSeed, content_employee_first_crewSeed, content_employee_middle_crewSeed, 
                          content_employee_last_crewSeed, optional_new_crew_crewSeed, optional_new_engine_trainSeed, optional_new_engine_engineSeed, hostname);
        }
        
        /// <summary>
		/// Send a CD-CSGN PTC message while using crew details that have not been sent to PDS.
		/// </summary>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-CSGN</param>
		/// <param name="crewSeed">The look-up key for the crew information used to send the CD-CSGN</param>
		/// <param name="crewMemberRecord">Pipe Delimited string of crew record</param>
		/// <param name="crewSequenceNumber">Sequence Number for Crew</param>
		/// <param name="crewLineSegment">Crew Line Segment</param>
		/// <param name="districts">A pipe-delimited string in '[division]|[district]' format</param>
		[UserCodeMethod]
        public static void SendCD_CSGN_7Simple_NewCrew(string trainSeed, string crewSeed, string engineSeed, string crewMemberRecord, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = engineSeed;
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = engineSeed;
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	string content_engine_initial_trainSeed = trainSeed;
        	string content_engine_initial_engineSeed = engineSeed;
        	string content_engine_number_trainSeed = trainSeed;
        	string content_engine_number_engineSeed = engineSeed;
        	string content_employee_id_crewSeed = "";
        	string content_employee_first_crewSeed = "";
        	string content_employee_middle_crewSeed = "";
        	string content_employee_last_crewSeed = "";
        	
        	string optional_new_crew_crewSeed = crewSeed;
        	string optional_new_engine_trainSeed = "";
        	string optional_new_engine_engineSeed = "";
        	
        	
        	string[] crewMemberRecordArray = crewMemberRecord.Split('|');
        	//Assume it's the long form of crew record
        	if (crewMemberRecordArray.Length >= 15)
        	{
        		content_employee_first_crewSeed = crewMemberRecordArray[10];
        		content_employee_middle_crewSeed = crewMemberRecordArray[11];
        		content_employee_last_crewSeed = crewMemberRecordArray[12];
        		content_employee_id_crewSeed = crewMemberRecordArray[14];
        	} else if (crewMemberRecordArray.Length == 4)
        	{
        		content_employee_first_crewSeed = crewMemberRecordArray[0];
        		content_employee_middle_crewSeed = crewMemberRecordArray[1];
        		content_employee_last_crewSeed = crewMemberRecordArray[2];
        		content_employee_id_crewSeed = crewMemberRecordArray[3];
        	} else {
        		Ranorex.Report.Error("Crew Record has a length of {" + crewMemberRecordArray.Length.ToString() + "} instead of the minimum expected of 4 or >= 15, not creating csgn");
        		return;
        	}
        	
            SendCD_CSGN_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, header_source_sys, 
        	              header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac_trainSeed,
                          header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed, header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed, 
                          header_heng_engine_number_engineSeed, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac_trainSeed, content_symbol_trainSeed, content_section_trainSeed, 
                          content_origin_date_trainSeed, content_engine_initial_trainSeed, content_engine_initial_engineSeed, content_engine_number_trainSeed, content_engine_number_engineSeed, 
                          content_employee_id_crewSeed, content_employee_first_crewSeed, content_employee_middle_crewSeed, 
                          content_employee_last_crewSeed, optional_new_crew_crewSeed, optional_new_engine_trainSeed, optional_new_engine_engineSeed, hostname);
        }
        
        [UserCodeMethod]
        public static void SendCD_EA01_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac_trainSeed, 
                                           string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed, string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed, 
                                           string header_heng_engine_number_engineSeed, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac_trainSeed, string content_symbol_trainSeed, string content_section_trainSeed, 
                                           string content_origin_date_trainSeed, string content_engine_initial_trainSeed, string content_engine_initial_engineSeed, string content_engine_number_trainSeed, string content_engine_number_engineSeed, 
                                           string content_application_date_offset_days, string content_application_time_offset_minutes, string content_target_type, string content_target_description,  string content_speed, string content_direction, string content_he_district, 
                                           string content_he_track, string content_he_milepost, string content_re_district, string content_re_track, string content_re_milepost, string hostname)
        {
        	System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            string content_symbol = NS_TrainID.GetTrainSymbol(content_symbol_trainSeed);
        	if (content_symbol == null)
        	{
        		content_symbol = content_symbol_trainSeed;
        	}
            string content_section = NS_TrainID.GetTrainSection(content_section_trainSeed);
            if (content_section == null)
        	{
        		content_section = content_section_trainSeed;
        	}
            string content_scac = NS_TrainID.GetTrainSCAC(content_scac_trainSeed);
            if (content_scac == null)
        	{
        		content_scac = content_scac_trainSeed;
        	}
            string content_origin_date = NS_TrainID.getOriginDate(content_origin_date_trainSeed);
            if (content_origin_date == null)
            {
            	content_origin_date = content_origin_date_trainSeed;
            }
            
            string content_engine_initial = NS_TrainID.GetEngineInitial(content_engine_initial_trainSeed, content_engine_initial_engineSeed);
            if (content_engine_initial == null)
        	{
        		content_engine_initial = content_engine_initial_engineSeed;
        	}
            string content_engine_number = NS_TrainID.GetEngineNumber(content_engine_number_trainSeed, content_engine_number_engineSeed);
            if (content_engine_number == null)
        	{
        		content_engine_number = content_engine_number_engineSeed;
        	}
            
            string content_application_date;
        	int content_application_date_offset_int = 0;
        	if (Int32.TryParse(content_application_date_offset_days, out content_application_date_offset_int))
        	{
        		content_application_date = now.AddDays(content_application_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_application_date = content_application_date_offset_days;
        	}
        	
        	string content_application_time;
        	int content_application_time_offset_int = 0;
        	if (Int32.TryParse(content_application_time_offset_minutes, out content_application_time_offset_int))
        	{
        		content_application_time = now.AddMinutes(content_application_time_offset_int).ToString("HHmm");
        	} else {
        		content_application_time = content_application_time_offset_minutes;
        	}
        	
        	STE.Code_Utils.messages.PTC.PTC_CD_EA01_7.createCD_EA01_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, 
        	                                                          header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, 
        	                                                          header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, 
        	                                                          content_symbol, content_section, content_origin_date, content_engine_initial, content_engine_number, content_application_date, content_application_time, 
        	                                                          content_target_type, content_target_description, content_speed, content_direction, content_he_district, content_he_track, content_he_milepost, content_re_district, 
        	                                                          content_re_track, content_re_milepost, hostname);
        }
        
        [UserCodeMethod]
        public static void SendCD_EA01_7Simple(string trainSeed, string engineSeed, string applicationDateOffsetDays, string applicationTimeOffsetMinutes, string targetType, string targetDescription, string speed, string direction, string heDistrict, 
                                           string heTrack, string heMilepost, string reDistrict, string reTrack, string reMilepost, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = engineSeed;
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = engineSeed;
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	string content_engine_initial_trainSeed = trainSeed;
        	string content_engine_initial_engineSeed = engineSeed;
        	string content_engine_number_trainSeed = trainSeed;
        	string content_engine_number_engineSeed = engineSeed;
        	
        	SendCD_EA01_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, header_source_sys, 
                                           header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac_trainSeed, 
                                           header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed, header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed, 
                                           header_heng_engine_number_engineSeed, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac_trainSeed, content_symbol_trainSeed, content_section_trainSeed, 
                                           content_origin_date_trainSeed, content_engine_initial_trainSeed, content_engine_initial_engineSeed, content_engine_number_trainSeed, content_engine_number_engineSeed, 
                                           applicationDateOffsetDays, applicationTimeOffsetMinutes, targetType, targetDescription,  speed, direction, heDistrict, 
                                           heTrack, heMilepost, reDistrict, reDistrict, reMilepost, hostname);
        }
        
        /// <summary>
		/// 
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="engineSeed"></param>
		/// <param name="applicationType"></param>
		/// <param name="trainSpeed"></param>
		/// <param name="trainDirection"></param>
		/// <param name="headDistrict"></param>
		/// <param name="headTrack"></param>
		/// <param name="headMilepost"></param>
		/// <param name="rearDistrict"></param>
		/// <param name="rearTrack"></param>
		/// <param name="rearMilepost"></param>
		[UserCodeMethod]
		public static void SendCD_EBAR_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, 
        	                                                          string header_message_revision, string header_source_sys, string header_destination_sys, string header_district_name, 
        	                                                          string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac_trainSeed, 
        	                                                          string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed, 
        	                                                          string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed, 
        	                                                          string header_heng_engine_number_engineSeed, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, 
        	                                                          string content_scac_trainSeed, string content_symbol_trainSeed, string content_section_trainSeed, string content_origin_date_trainSeed, 
        	                                                          string content_engine_initial_trainSeed, string content_engine_initial_engineSeed, string content_engine_number_trainSeed, 
        	                                                          string content_engine_number_engineSeed, string content_application_date_offset_days, string content_application_time_offset_minutes, 
        	                                                          string content_application_type, string content_speed, string content_direction, string content_he_district, string content_he_track, 
        	                                                          string content_he_milepost, string content_re_district, string content_re_track, string content_re_milepost, string hostname)
        {
        	System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            string content_symbol = NS_TrainID.GetTrainSymbol(content_symbol_trainSeed);
        	if (content_symbol == null)
        	{
        		content_symbol = content_symbol_trainSeed;
        	}
            string content_section = NS_TrainID.GetTrainSection(content_section_trainSeed);
            if (content_section == null)
        	{
        		content_section = content_section_trainSeed;
        	}
            string content_scac = NS_TrainID.GetTrainSCAC(content_scac_trainSeed);
            if (content_scac == null)
        	{
        		content_scac = content_scac_trainSeed;
        	}
            string content_origin_date = NS_TrainID.getOriginDate(content_origin_date_trainSeed);
            if (content_origin_date == null)
            {
            	content_origin_date = content_origin_date_trainSeed;
            }
            
            string content_engine_initial = NS_TrainID.GetEngineInitial(content_engine_initial_trainSeed, content_engine_initial_engineSeed);
            if (content_engine_initial == null)
        	{
        		content_engine_initial = content_engine_initial_engineSeed;
        	}
            string content_engine_number = NS_TrainID.GetEngineNumber(content_engine_number_trainSeed, content_engine_number_engineSeed);
            if (content_engine_number == null)
        	{
        		content_engine_number = content_engine_number_engineSeed;
        	}
            
            string content_application_date;
        	int content_application_date_offset_int = 0;
        	if (Int32.TryParse(content_application_date_offset_days, out content_application_date_offset_int))
        	{
        		content_application_date = now.AddDays(content_application_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_application_date = content_application_date_offset_days;
        	}
        	
        	string content_application_time;
        	int content_application_time_offset_int = 0;
        	if (Int32.TryParse(content_application_time_offset_minutes, out content_application_time_offset_int))
        	{
        		content_application_time = now.AddMinutes(content_application_time_offset_int).ToString("HHmm");
        	} else {
        		content_application_time = content_application_time_offset_minutes;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_CD_EBAR_7.createCD_EBAR_7(header_event_date, header_event_time, header_sequence_number, header_message_version, 
        	                                                          header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, 
        	                                                          header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, 
        	                                                          content_symbol, content_section, content_origin_date, content_engine_initial, content_engine_number, 
        	                                                          content_application_date, content_application_time, content_application_type, content_speed, 
        	                                                          content_direction, content_he_district, content_he_track, content_he_milepost, content_re_district, 
        	                                                          content_re_track, content_re_milepost, hostname);
        }
		
		[UserCodeMethod]
        public static void SendCD_EBAR_7Simple(string trainSeed, string engineSeed, string applicationDateOffsetDays, string applicationTimeOffsetMinutes, string applicationType, string speed, string direction, string heDistrict, 
                                           string heTrack, string heMilepost, string reDistrict, string reTrack, string reMilepost, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = engineSeed;
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = engineSeed;
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	string content_engine_initial_trainSeed = trainSeed;
        	string content_engine_initial_engineSeed = engineSeed;
        	string content_engine_number_trainSeed = trainSeed;
        	string content_engine_number_engineSeed = engineSeed;
        	
        	SendCD_EBAR_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, header_source_sys, 
        	              header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac_trainSeed, 
        	              header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed, header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, 
        	              header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac_trainSeed, 
        	              content_symbol_trainSeed, content_section_trainSeed, content_origin_date_trainSeed, content_engine_initial_trainSeed, content_engine_initial_engineSeed, 
        	              content_engine_number_trainSeed, content_engine_number_engineSeed, applicationDateOffsetDays, applicationTimeOffsetMinutes, applicationType, 
        	              speed, direction, heDistrict, heTrack, heMilepost, reDistrict, reTrack, reMilepost, hostname);
        }
		
		/// <summary>
		/// Send the CD-EEDS PTC message
		/// </summary>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="engineSeed">Input:engineSeed</param>
		/// <param name="enable_disable">Input:enable_disable</param>
		/// <param name="status_code">Input:status_code</param>
		/// <param name="dispatch_territory">Input:dispatch_territory</param>
		/// <param name="enable_disable_reason">Input:enable_disable_reason</param>
		/// <param name="enable_disable_reason_code">Input:enable_disable_reason_code</param>
        [UserCodeMethod]
       	public static void SendCD_EEDS_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, 
                                         string header_message_revision, string header_source_sys, string header_destination_sys, string header_district_name, 
                                         string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac_trainSeed, 
                                         string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed, 
                                         string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed, 
                                         string header_heng_engine_number_engineSeed, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, 
                                         string content_scac_trainSeed, string content_symbol_trainSeed, string content_section_trainSeed, string content_origin_date_trainSeed, 
                                         string content_enable_disable, string content_ena_disable_rsn_cd, string content_enable_disable_reason, string content_status_code, 
                                         string content_engine_initial_trainSeed, string content_engine_initial_engineSeed, string content_engine_number_trainSeed, 
                                         string content_engine_number_engineSeed, string content_dispatch_territory, string hostname)
        {
        	System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            string content_symbol = NS_TrainID.GetTrainSymbol(content_symbol_trainSeed);
        	if (content_symbol == null)
        	{
        		content_symbol = content_symbol_trainSeed;
        	}
            string content_section = NS_TrainID.GetTrainSection(content_section_trainSeed);
            if (content_section == null)
        	{
        		content_section = content_section_trainSeed;
        	}
            string content_scac = NS_TrainID.GetTrainSCAC(content_scac_trainSeed);
            if (content_scac == null)
        	{
        		content_scac = content_scac_trainSeed;
        	}
            string content_origin_date = NS_TrainID.getOriginDate(content_origin_date_trainSeed);
            if (content_origin_date == null)
            {
            	content_origin_date = content_origin_date_trainSeed;
            }
            
            string content_engine_initial = NS_TrainID.GetEngineInitial(content_engine_initial_trainSeed, content_engine_initial_engineSeed);
            if (content_engine_initial == null)
        	{
        		content_engine_initial = content_engine_initial_engineSeed;
        	}
            string content_engine_number = NS_TrainID.GetEngineNumber(content_engine_number_trainSeed, content_engine_number_engineSeed);
            if (content_engine_number == null)
        	{
        		content_engine_number = content_engine_number_engineSeed;
        	}
            
            STE.Code_Utils.messages.PTC.PTC_CD_EEDS_7.createCD_EEDS_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, 
                                                                      header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, 
                                                                      header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, 
                                                                      header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, 
                                                                      content_scac, content_symbol, content_section, content_origin_date, content_enable_disable, content_ena_disable_rsn_cd, 
                                                                      content_enable_disable_reason, content_status_code, content_engine_initial, content_engine_number, content_dispatch_territory, 
                                                                      hostname);
        
            
        }
        
        [UserCodeMethod]
        public static void SendCD_EEDS_7Simple(string trainSeed, string engineSeed, string enableDisable, string enableDisableReasonCode, string enableDisableReason, 
                                               string statusCode, string dispatchTerritory, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = engineSeed;
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = engineSeed;
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	string content_engine_initial_trainSeed = trainSeed;
        	string content_engine_initial_engineSeed = engineSeed;
        	string content_engine_number_trainSeed = trainSeed;
        	string content_engine_number_engineSeed = engineSeed;
        	
        	SendCD_EEDS_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, 
        	              header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	              header_district_scac, header_user_id, header_track_file_version, header_htrn_scac_trainSeed, 
        	              header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed, 
        	              header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed, 
        	              header_heng_engine_number_engineSeed, header_uid1_type, header_uid1, header_uid2_type, header_uid2, 
        	              content_scac_trainSeed, content_symbol_trainSeed, content_section_trainSeed, content_origin_date_trainSeed, 
        	              enableDisable, enableDisableReasonCode, enableDisableReason, statusCode, 
        	              content_engine_initial_trainSeed, content_engine_initial_engineSeed, content_engine_number_trainSeed, content_engine_number_engineSeed, 
        	              dispatchTerritory, hostname);
        }
        
        /// <summary>
		/// Send the CD-LOSR PTC message
		/// </summary>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="engineSeed">Input:engineSeed</param>
		/// <param name="enable_disable">Input:enable_disable</param>
		/// <param name="status_code">Input:status_code</param>
		/// <param name="dispatch_territory">Input:dispatch_territory</param>
		/// <param name="enable_disable_reason">Input:enable_disable_reason</param>
		/// <param name="enable_disable_reason_code">Input:enable_disable_reason_code</param>
        [UserCodeMethod]
       	public static void SendCD_LOSR_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, 
                                         string header_message_revision, string header_source_sys, string header_destination_sys, string header_district_name, 
                                         string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac_trainSeed, 
                                         string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed, 
                                         string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed, 
                                         string header_heng_engine_number_engineSeed, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, 
                                         string content_engine_initial_trainSeed, string content_engine_initial_engineSeed, string content_engine_number_trainSeed, 
                                         string content_engine_number_engineSeed, string content_scac_trainSeed, string content_symbol_trainSeed, string content_section_trainSeed, 
                                         string content_origin_date_trainSeed, string content_train_clearance_number_trainSeed, string content_trigger_type, string content_prev_loco_st_summ, 
                                         string content_prev_loco_state, string content_loco_state_summary, string content_loco_state, string content_loco_state_date_offset_days, 
                                         string content_loco_state_time_offset_minutes, string content_state_district, string content_state_milepost, string content_state_track, string hostname)
        {
        	System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            string content_engine_initial = NS_TrainID.GetEngineInitial(content_engine_initial_trainSeed, content_engine_initial_engineSeed);
            if (content_engine_initial == null)
        	{
        		content_engine_initial = content_engine_initial_engineSeed;
        	}
            string content_engine_number = NS_TrainID.GetEngineNumber(content_engine_number_trainSeed, content_engine_number_engineSeed);
            if (content_engine_number == null)
        	{
        		content_engine_number = content_engine_number_engineSeed;
        	}
            
            string content_symbol = NS_TrainID.GetTrainSymbol(content_symbol_trainSeed);
        	if (content_symbol == null)
        	{
        		content_symbol = content_symbol_trainSeed;
        	}
            string content_section = NS_TrainID.GetTrainSection(content_section_trainSeed);
            if (content_section == null)
        	{
        		content_section = content_section_trainSeed;
        	}
            string content_scac = NS_TrainID.GetTrainSCAC(content_scac_trainSeed);
            if (content_scac == null)
        	{
        		content_scac = content_scac_trainSeed;
        	}
            string content_origin_date = NS_TrainID.getOriginDate(content_origin_date_trainSeed);
            if (content_origin_date == null)
            {
            	content_origin_date = content_origin_date_trainSeed;
            }
            
            string content_train_clearance_number = NS_TrainID.GetTrainClearanceNumber(content_train_clearance_number_trainSeed);
            if (content_train_clearance_number == null)
            {
            	content_train_clearance_number = content_train_clearance_number_trainSeed;
            }
            
            string content_loco_state_date;
        	int content_loco_state_date_offset_int = 0;
        	if (Int32.TryParse(content_loco_state_date_offset_days, out content_loco_state_date_offset_int))
        	{
        		content_loco_state_date = now.AddDays(content_loco_state_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_loco_state_date = content_loco_state_date_offset_days;
        	}
        	
        	string content_loco_state_time;
        	int content_loco_state_time_offset_int = 0;
        	if (Int32.TryParse(content_loco_state_time_offset_minutes, out content_loco_state_time_offset_int))
        	{
        		content_loco_state_time = now.AddMinutes(content_loco_state_time_offset_int).ToString("HHmmss");
        	} else {
        		content_loco_state_time = content_loco_state_time_offset_minutes;
        	}
            
            STE.Code_Utils.messages.PTC.PTC_CD_LOSR_7.createCD_LOSR_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, 
                                                                      header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, 
                                                                      header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, 
                                                                      header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, 
                                                                      content_engine_initial, content_engine_number, content_scac, content_symbol, content_section, content_origin_date, 
                                                                      content_train_clearance_number, content_trigger_type, content_prev_loco_st_summ, content_prev_loco_state, 
                                                                      content_loco_state_summary, content_loco_state, content_loco_state_date, content_loco_state_time, content_state_district, 
                                                                      content_state_milepost, content_state_track, hostname);
        
            
        }
        
        /// <summary>
		/// 
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="engineSeed"></param>
		/// <param name="district"></param>
		/// <param name="precisionMilepost"></param>
		/// <param name="track"></param>
		/// <param name="triggerType"></param>
		/// <param name="prevLocoState"></param>
		/// <param name="prevLocoStateSummary"></param>
		/// <param name="locoState"></param>
		/// <param name="locoStateSummary"></param>
		/// <param name="optionalTrainClearance"></param>
		[UserCodeMethod]
		public static void SendCD_LOSR_7Simple(string trainSeed, string engineSeed, string triggerType, string previousLocoStateSummary, string previousLocoState, string locoStateSummary, string locoState,
		                                       string locoStateDateOffsetDays, string locoStateTimeOffsetMinutes, string stateDistrict, string stateMilepost, string stateTrack, string hostname)
		{
			string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = engineSeed;
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = engineSeed;
        	string content_engine_initial_trainSeed = trainSeed;
        	string content_engine_initial_engineSeed = engineSeed;
        	string content_engine_number_trainSeed = trainSeed;
        	string content_engine_number_engineSeed = engineSeed;
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	string content_train_clearance_number_trainSeed = trainSeed;

			
			SendCD_LOSR_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, 
                                         header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
                                         header_district_scac, header_user_id, header_track_file_version, header_htrn_scac_trainSeed, 
                                         header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed, 
                                         header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed, 
                                         header_heng_engine_number_engineSeed, header_uid1_type, header_uid1, header_uid2_type, header_uid2, 
                                         content_engine_initial_trainSeed, content_engine_initial_engineSeed, content_engine_number_trainSeed, 
                                         content_engine_number_engineSeed, content_scac_trainSeed, content_symbol_trainSeed, content_section_trainSeed, content_origin_date_trainSeed, 
                                         content_train_clearance_number_trainSeed, triggerType, previousLocoStateSummary, previousLocoState,
                                         locoStateSummary, locoState, locoStateDateOffsetDays, locoStateTimeOffsetMinutes, 
                                         stateDistrict, stateMilepost, stateTrack, hostname);
		}
		
		[UserCodeMethod]
        public static void SendCD_MEDS_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, 
		                                 string header_message_revision, string header_source_sys, string header_destination_sys, string header_district_name, string header_district_scac, 
		                                 string header_user_id, string header_track_file_version, string header_htrn_scac_trainSeed, string header_htrn_symbol_trainSeed, 
		                                 string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed, string header_heng_engine_initial_trainSeed, 
		                                 string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed, string header_heng_engine_number_engineSeed, 
		                                 string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_bulletin_item_number_bulletinSeed, 
		                                 string content_scac_trainSeed, string content_symbol_trainSeed, string content_section_trainSeed, string content_origin_date_trainSeed, 
		                                 string content_status_code, string content_engine_initial_trainSeed, string content_engine_initial_engineSeed, string content_engine_number_trainSeed, 
		                                 string content_engine_number_engineSeed, string hostname)
        {
        	System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            string content_bulletin_item_number = NS_Bulletin.GetBulletinNumber(content_bulletin_item_number_bulletinSeed);
            if (content_bulletin_item_number == null)
        	{
        		content_bulletin_item_number = content_bulletin_item_number_bulletinSeed;
        	}
                        
            string content_symbol = NS_TrainID.GetTrainSymbol(content_symbol_trainSeed);
        	if (content_symbol == null)
        	{
        		content_symbol = content_symbol_trainSeed;
        	}
            string content_section = NS_TrainID.GetTrainSection(content_section_trainSeed);
            if (content_section == null)
        	{
        		content_section = content_section_trainSeed;
        	}
            string content_scac = NS_TrainID.GetTrainSCAC(content_scac_trainSeed);
            if (content_scac == null)
        	{
        		content_scac = content_scac_trainSeed;
        	}
            string content_origin_date = NS_TrainID.getOriginDate(content_origin_date_trainSeed);
            if (content_origin_date == null)
            {
            	content_origin_date = content_origin_date_trainSeed;
            }
            
            string content_engine_initial = NS_TrainID.GetEngineInitial(content_engine_initial_trainSeed, content_engine_initial_engineSeed);
            if (content_engine_initial == null)
        	{
        		content_engine_initial = content_engine_initial_engineSeed;
        	}
            string content_engine_number = NS_TrainID.GetEngineNumber(content_engine_number_trainSeed, content_engine_number_engineSeed);
            if (content_engine_number == null)
        	{
        		content_engine_number = content_engine_number_engineSeed;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_CD_MEDS_7.createCD_MEDS_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_bulletin_item_number, content_scac, content_symbol, content_section, 
        	                                                          content_origin_date, content_status_code, content_engine_initial, content_engine_number, hostname);
        }
		
		[UserCodeMethod]
        public static void SendCD_MEDS_7Simple(string trainSeed, string engineSeed, string bulletinSeed, string statusCode, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = engineSeed;
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = engineSeed;
        	string content_bulletin_item_number_bulletinSeed = bulletinSeed;
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	string content_engine_initial_trainSeed = trainSeed;
        	string content_engine_initial_engineSeed = engineSeed;
        	string content_engine_number_trainSeed = trainSeed;
        	string content_engine_number_engineSeed = engineSeed;
        	
        	SendCD_MEDS_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, 
		                                 header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, 
		                                 header_user_id, header_track_file_version, header_htrn_scac_trainSeed, header_htrn_symbol_trainSeed, 
		                                 header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed, header_heng_engine_initial_trainSeed, 
		                                 header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed, 
		                                 header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_bulletin_item_number_bulletinSeed, content_scac_trainSeed, 
		                                 content_symbol_trainSeed, content_section_trainSeed, content_origin_date_trainSeed, statusCode, 
		                                 content_engine_initial_trainSeed, content_engine_initial_engineSeed, content_engine_number_trainSeed, 
		                                 content_engine_number_engineSeed, hostname);
        }
        
        [UserCodeMethod]
        public static void SendCD_RABI_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, 
                                         string header_source_sys, string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, 
                                         string header_htrn_scac_trainSeed, string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed, 
                                         string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed, 
                                         string header_heng_engine_number_engineSeed, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac_trainSeed, 
                                         string content_symbol_trainSeed, string content_section_trainSeed, string content_origin_date_trainSeed, string content_train_clearance_number_trainSeed, 
                                         string content_engine_initial_trainSeed, string content_engine_initial_engineSeed, string content_engine_number_trainSeed, string content_engine_number_engineSeed, 
                                         string content_request_type, string optional_new_engine_trainSeed, string optional_new_engine_engineSeed, string hostname)
        {
        	System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            string content_symbol = NS_TrainID.GetTrainSymbol(content_symbol_trainSeed);
        	if (content_symbol == null)
        	{
        		content_symbol = content_symbol_trainSeed;
        	}
            string content_section = NS_TrainID.GetTrainSection(content_section_trainSeed);
            if (content_section == null)
        	{
        		content_section = content_section_trainSeed;
        	}
            string content_scac = NS_TrainID.GetTrainSCAC(content_scac_trainSeed);
            if (content_scac == null)
        	{
        		content_scac = content_scac_trainSeed;
        	}
            string content_origin_date = NS_TrainID.getOriginDate(content_origin_date_trainSeed);
            if (content_origin_date == null)
            {
            	content_origin_date = content_origin_date_trainSeed;
            }
            
            string content_train_clearance_number = NS_TrainID.GetTrainClearanceNumber(content_train_clearance_number_trainSeed);
            if (content_train_clearance_number == null)
            {
            	content_train_clearance_number = content_train_clearance_number_trainSeed;
            }
            
            string content_engine_initial = NS_TrainID.GetEngineInitial(content_engine_initial_trainSeed, content_engine_initial_engineSeed);
            if (content_engine_initial == null)
        	{
        		content_engine_initial = content_engine_initial_engineSeed;
        	}
            string content_engine_number = NS_TrainID.GetEngineNumber(content_engine_number_trainSeed, content_engine_number_engineSeed);
            if (content_engine_number == null)
        	{
        		content_engine_number = content_engine_number_engineSeed;
        	}
            
            if (optional_new_engine_engineSeed != "")
            {
        		string engine_record = content_engine_initial + "|" + content_engine_number + "|||||||||||||N|Y|N|N||0|||0||0|";
        		NS_TrainID.CreateEngineConsistRecord(optional_new_engine_trainSeed, optional_new_engine_engineSeed, engine_record, assignedDivision: "", helperCrewPoolId: "", defaultDataApplied: "True", reportingPassCount: "", reportingLocation: "", reportingSource: "", messagePurpose: "");
            }
        	
        	STE.Code_Utils.messages.PTC.PTC_CD_RABI_7.createCD_RABI_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, 
        	                                                          header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, 
        	                                                          header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, 
        	                                                          header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, 
        	                                                          content_scac, content_symbol, content_section, content_origin_date, content_train_clearance_number, content_engine_initial, 
        	                                                          content_engine_number, content_request_type, hostname);
        }
        
        /// <summary>
		/// Send a CD-RABI PTC message.
		/// </summary>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-CSGN</param>
		/// <param name="engineSeed">The look-up key for the engine information used to send the CD-CSGN</param>
		/// <param name="districts">A pipe-delimited string in '[division]|[district]' format</param>
		/// <param name="Type">Request type: INITIAL or UPDATE</param>
		/// <param name="optionalTrainClearance">Mandatory parameter for RTID message. This field should be auto-populated for automation purposes.</param>
        [UserCodeMethod]
        public static void SendCD_RABI_7Simple(string trainSeed, string engineSeed, string requestType, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = engineSeed;
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = engineSeed;
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	string content_train_clearance_number_trainSeed = trainSeed;
        	string content_engine_initial_trainSeed = trainSeed;
        	string content_engine_initial_engineSeed = engineSeed;
        	string content_engine_number_trainSeed = trainSeed;
        	string content_engine_number_engineSeed = engineSeed;
        	
        	string optional_new_engine_trainSeed = "";
        	string optional_new_engine_engineSeed = "";
            
            SendCD_RABI_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, 
        	              header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version,
        	              header_htrn_scac_trainSeed, header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed,
        	              header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed,
        	              header_heng_engine_number_engineSeed, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac_trainSeed,
        	              content_symbol_trainSeed, content_section_trainSeed, content_origin_date_trainSeed, content_train_clearance_number_trainSeed,
        	              content_engine_initial_trainSeed, content_engine_initial_engineSeed, content_engine_number_trainSeed, content_engine_number_engineSeed,
        	              requestType, optional_new_engine_trainSeed, optional_new_engine_engineSeed, hostname);
        }
        
        /// <summary>
		/// Send a CD-RABI PTC message while using engine details that have not been sent to PDS.
		/// </summary>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-CSGN</param>
		/// <param name="engineSeed">The look-up key for the engine information used to send the CD-CSGN</param>
		/// <param name="districts">A pipe-delimited string in '[division]|[district]' format</param>
		/// <param name="Type">Request type: INITIAL or UPDATE</param>
		/// <param name="optionalTrainClearance">Mandatory parameter for RTID message. This field should be auto-populated for automation purposes.</param>
		/// <param name="assignedDivision">The assigned division of the engine corresponding to engineSeed</param>
		/// <param name="helperCrewPoolId">Pool name of the crew of the engine corresponding to engineSeed</param>
		/// <param name="defaultDataApplied">Whether or not to apply default HP to locomotive: 'Y' or 'N'</param>
		/// <param name="reportingPassCount">The number of route traversals through reportingLocation OPSTA for engine</param>
		/// <param name="reportingLocation">The message update location for engine</param>
		/// <param name="reportingSource">The source of locomotive information</param>
		/// <param name="purpose">Message purpose (e.g. (A) Add engine / (D) Delete engine / (R) Replace consist with included engines)</param>
		/// <param name="engineRecord">Pipe-delimited string of engine record</param>	
        [UserCodeMethod]
        public static void SendCD_RABI_7Simple_NewEngine(string trainSeed, string engineSeed, string requestType, string engineRecord, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = "";
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = "";
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	string content_train_clearance_number_trainSeed = trainSeed;
        	string content_engine_initial_trainSeed = trainSeed;
        	string content_engine_initial_engineSeed = "";
        	string content_engine_number_trainSeed = trainSeed;
        	string content_engine_number_engineSeed = "";
        	
        	string optional_new_engine_trainSeed = trainSeed;
        	string optional_new_engine_engineSeed = engineSeed;
            
            string[] engineRecordArray = engineRecord.Split('|');
        	if (engineRecordArray.Length >= 2)
            {
        		header_heng_engine_initial_engineSeed = engineRecordArray[0];
        		content_engine_initial_engineSeed = engineRecordArray[0];
        		header_heng_engine_number_engineSeed = engineRecordArray[1];
        		content_engine_number_engineSeed = engineRecordArray[1];
        	} else {
        		Ranorex.Report.Error("Engine Record has a length of {" + engineRecordArray.Length.ToString() + "} instead of the minimum expected of 2, not creating csgn");
        		return;
        	}
            
            SendCD_RABI_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, 
        	              header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version,
        	              header_htrn_scac_trainSeed, header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed,
        	              header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed,
        	              header_heng_engine_number_engineSeed, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac_trainSeed,
        	              content_symbol_trainSeed, content_section_trainSeed, content_origin_date_trainSeed, content_train_clearance_number_trainSeed,
        	              content_engine_initial_trainSeed, content_engine_initial_engineSeed, content_engine_number_trainSeed, content_engine_number_engineSeed,
        	              requestType, optional_new_engine_trainSeed, optional_new_engine_engineSeed, hostname);
        }
        
        [UserCodeMethod]
        public static void SendCD_RCON_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, 
                                         string header_source_sys, string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, 
                                         string header_htrn_scac_trainSeed, string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed, 
                                         string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed, 
                                         string header_heng_engine_number_engineSeed, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_trigger_type, 
                                         string content_scac_trainSeed, string content_symbol_trainSeed, string content_section_trainSeed, string content_origin_date_trainSeed, string content_requesting_district, 
                                         string content_requesting_milepost, string content_requesting_track, string hostname)
        {
        	System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            string content_symbol = NS_TrainID.GetTrainSymbol(content_symbol_trainSeed);
        	if (content_symbol == null)
        	{
        		content_symbol = content_symbol_trainSeed;
        	}
            string content_section = NS_TrainID.GetTrainSection(content_section_trainSeed);
            if (content_section == null)
        	{
        		content_section = content_section_trainSeed;
        	}
            string content_scac = NS_TrainID.GetTrainSCAC(content_scac_trainSeed);
            if (content_scac == null)
        	{
        		content_scac = content_scac_trainSeed;
        	}
            string content_origin_date = NS_TrainID.getOriginDate(content_origin_date_trainSeed);
            if (content_origin_date == null)
            {
            	content_origin_date = content_origin_date_trainSeed;
            }
            
            STE.Code_Utils.messages.PTC.PTC_CD_RCON_7.createCD_RCON_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, 
        	                                                          header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, 
        	                                                          header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, 
        	                                                          header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, 
        	                                                          content_trigger_type, content_scac, content_symbol, content_section, content_origin_date, content_requesting_district, 
        	                                                          content_requesting_milepost, content_requesting_track, hostname);
        }
        
        /// <summary>
		/// Send a CD-RCON PTC message.
		/// </summary>
		/// <param name="trigger_type">Reason for sending message: '02030' or 'CIBOS'</param>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-RCON</param>
		/// <param name="requesting_district">Timetable District Name associated with milepost value at requesting location</param>
		/// <param name="requesting_milepost">Exact milepost value with four decimal place precision</param>
		/// <param name="requesting_track">Track name at the requesting location</param>
		[UserCodeMethod]
        public static void SendCD_RCON_7Simple(string trainSeed, string engineSeed, string triggerType, string requestingDistrict, string requestingMilepost, string requestingTrack, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = "";
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = "";
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	
        	SendCD_RCON_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, 
        	              header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version,
        	              header_htrn_scac_trainSeed, header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed,
        	              header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed,
        	              header_heng_engine_number_engineSeed, header_uid1_type, header_uid1, header_uid2_type, header_uid2, triggerType, content_scac_trainSeed,
        	              content_symbol_trainSeed, content_section_trainSeed, content_origin_date_trainSeed, requestingDistrict, requestingMilepost, 
        	              requestingTrack, hostname);
        }
        
        
        [UserCodeMethod]
        public static void SendCD_RTDL_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, 
                                         string header_source_sys, string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, 
                                         string header_htrn_scac_trainSeed, string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed, 
                                         string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed, 
                                         string header_heng_engine_number_engineSeed, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac_trainSeed, 
                                         string content_symbol_trainSeed, string content_section_trainSeed, string content_origin_date_trainSeed, string content_request_type, string content_trigger_type, 
                                         string hostname)
        {
        	System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            string content_symbol = NS_TrainID.GetTrainSymbol(content_symbol_trainSeed);
        	if (content_symbol == null)
        	{
        		content_symbol = content_symbol_trainSeed;
        	}
            string content_section = NS_TrainID.GetTrainSection(content_section_trainSeed);
            if (content_section == null)
        	{
        		content_section = content_section_trainSeed;
        	}
            string content_scac = NS_TrainID.GetTrainSCAC(content_scac_trainSeed);
            if (content_scac == null)
        	{
        		content_scac = content_scac_trainSeed;
        	}
            string content_origin_date = NS_TrainID.getOriginDate(content_origin_date_trainSeed);
            if (content_origin_date == null)
            {
            	content_origin_date = content_origin_date_trainSeed;
            }
            
            STE.Code_Utils.messages.PTC.PTC_CD_RTDL_7.createCD_RTDL_7(header_event_date, header_event_time, header_sequence_number, header_message_version, 
                                                                      header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
                                                                      header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, 
                                                                      header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, 
                                                                      header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, 
                                                                      content_section, content_origin_date, content_request_type, content_trigger_type, hostname);
        }
        
        /// <summary>
		/// Send a CD-RTDL PTC message.
		/// </summary>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-RTDL</param>
		/// <param name="district">District name corresponding to the CD-RTDL</param>
		/// <param name="request_type">Indicates the type of request: 'LOCO' or 'UPDATE'</param>
		/// <param name="trigger_type">Indicates message that triggered the request - See ICD</param>
        [UserCodeMethod]
        public static void SendCD_RTDL_7Simple(string trainSeed, string requestType, string triggerType, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = "";
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = "";
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	
            SendCD_RTDL_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, 
        	              header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version,
        	              header_htrn_scac_trainSeed, header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed,
                          header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed, 
                          header_heng_engine_number_engineSeed, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac_trainSeed, 
                          content_symbol_trainSeed, content_section_trainSeed, content_origin_date_trainSeed, requestType, triggerType, hostname);
        }
        
        /// <summary>
		/// Send a CD-RTID PTC message.
		/// </summary>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-RTID</param>
		/// <param name="engineSeed">The look-up key for the engine information used to send the CD-RTID</param>
		/// <param name="optionalTrainClearance">Mandatory parameter for RTID message. This field should be auto-populated for automation purposes.</param>
        [UserCodeMethod]
        public static void SendCD_RTID_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, 
                                               string header_source_sys, string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version,
                                               string header_htrn_scac_trainSeed, string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed,
                                               string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed,
                                               string header_heng_engine_number_engineSeed, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_train_clearance_number_trainSeed, 
                                               string content_engine_initial_trainSeed, string content_engine_initial_engineSeed, string content_engine_number_trainSeed, string content_engine_number_engineSeed, string hostname)
        {
        	System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            string content_train_clearance_number = NS_TrainID.GetTrainClearanceNumber(content_train_clearance_number_trainSeed);
            if (content_train_clearance_number == null)
            {
            	content_train_clearance_number = content_train_clearance_number_trainSeed;
            }
            
            string content_engine_initial = NS_TrainID.GetEngineInitial(content_engine_initial_trainSeed, content_engine_initial_engineSeed);
            if (content_engine_initial == null)
        	{
        		content_engine_initial = content_engine_initial_engineSeed;
        	}
            string content_engine_number = NS_TrainID.GetEngineNumber(content_engine_number_trainSeed, content_engine_number_engineSeed);
            if (content_engine_number == null)
        	{
        		content_engine_number = content_engine_number_engineSeed;
        	}
            
        	STE.Code_Utils.messages.PTC.PTC_CD_RTID_7.createCD_RTID_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, 
        	                                                          header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, 
        	                                                          header_uid1, header_uid2_type, header_uid2, content_train_clearance_number, content_engine_initial, content_engine_number, hostname);
        }
        
        /// <summary>
		/// Send a CD-RTID PTC message.
		/// </summary>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-RTID</param>
		/// <param name="engineSeed">The look-up key for the engine information used to send the CD-RTID</param>
		/// <param name="optionalTrainClearance">Mandatory parameter for RTID message. This field should be auto-populated for automation purposes.</param>
        [UserCodeMethod]
        public static void SendCD_RTID_7Simple(string trainSeed, string engineSeed, string hostname)
        {
            string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = engineSeed;
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = engineSeed;
        	string content_train_clearance_number_trainSeed = trainSeed;
        	string content_engine_initial_trainSeed = trainSeed;
        	string content_engine_initial_engineSeed = engineSeed;
        	string content_engine_number_trainSeed = trainSeed;
        	string content_engine_number_engineSeed = engineSeed;
            
            SendCD_RTID_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, 
                                               header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version,
                                               header_htrn_scac_trainSeed, header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed,
                                               header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed,
                                               header_heng_engine_number_engineSeed, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_train_clearance_number_trainSeed, 
                                               content_engine_initial_trainSeed, content_engine_initial_engineSeed, content_engine_number_trainSeed, content_engine_number_engineSeed, hostname);
        }
        
        /// <summary>
		/// Send a CD-RCON PTC message.
		/// </summary>
		/// <param name="trigger_type">Reason for sending message: '02030' or 'CIBOS'</param>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-RCON</param>
		/// <param name="requesting_district">Timetable District Name associated with milepost value at requesting location</param>
		/// <param name="requesting_milepost">Exact milepost value with four decimal place precision</param>
		/// <param name="requesting_track">Track name at the requesting location</param>
		[UserCodeMethod]
        public static void SendCD_TCON_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, 
		                                 string header_source_sys, string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version,
		                                 string header_htrn_scac_trainSeed, string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed,
		                                 string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed, string header_heng_engine_number_engineSeed, 
		                                 string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac_trainSeed, string content_symbol_trainSeed, 
		                                 string content_section_trainSeed, string content_origin_date_trainSeed, string content_loads, string content_empties, string content_tonnage, string content_length, string content_axles, 
		                                 string content_operative_brakes, string content_total_braking_force, string content_speed_constraint, string content_speed, string content_restriction_count, 
		                                 string content_restriction_record, string content_speed_class, string content_reporting_district, string content_reporting_milepost, string content_reporting_track, 
		                                 string content_ptc_loco_orientation, string content_ptc_engine_initial_trainSeed, string content_ptc_engine_initial_engineSeed, string content_ptc_engine_number_trainSeed, 
		                                 string content_ptc_engine_number_engineSeed, string content_engine_count, string content_engine_record, string optional_engine_record_trainSeed, string optional_engine_record_engineSeeds, string hostname)
		{
			
            if (optional_engine_record_engineSeeds != "") //Remember to pass in fake seeds if there is NP testing to conserve object state
            {
                if (optional_engine_record_trainSeed == "")
                {
                    Ranorex.Report.Error("the optional_engine_record_trainSeed is necessary if adding engine records");
                    return;
                }
                int engineRecordSize = 5;
                string[] splitEngineRecords = content_engine_record.Split('|');
                int numberOfEngineRecords = splitEngineRecords.Length/engineRecordSize;
                string[] splitEngineSeeds = optional_engine_record_engineSeeds.Split('|');
                int recordLoopIterations = splitEngineSeeds.Length;
                if (splitEngineSeeds.Length != numberOfEngineRecords)
                {
                    Ranorex.Report.Error("There are an incorrect number of engineSeeds {" + splitEngineSeeds.Length + "} to engine records {" + numberOfEngineRecords + "}. Remember: Please assume CD-TCON is sent with DB_STATUS even though it is optional. You may just need to add one more |.");
                }
                
                if (splitEngineSeeds.Length > numberOfEngineRecords)
                {
                    recordLoopIterations = numberOfEngineRecords;
                }
                
                for (int i=0; i < recordLoopIterations; i++)
                {

                    string position = splitEngineRecords[engineRecordSize*i];
                    string engineInitial = splitEngineRecords[engineRecordSize*i + 1];
                    string engineNumber = splitEngineRecords[engineRecordSize*i + 2];
                    string engineStatus = splitEngineRecords[engineRecordSize*i + 3];
                    
                    NS_EngineConsistObject engineObj = NS_TrainID.getTrainObject(content_symbol_trainSeed).GetEngineObject(splitEngineSeeds[i]);
                    if (engineObj != null)
                    {
                    	engineObj.EngineInitial = engineInitial;
                    	engineObj.EnginePosition = position;
                    	engineObj.EngineNumber = engineNumber;
                    	engineObj.EngineStatus = engineStatus;
                    	engineObj.ReportingSource = "C";
                    }
                    else
                    {
	                    string engineRecord = engineInitial + "|" + engineNumber + "|" + position + "||||||||||" + engineStatus + "|||||||0|||0||0|";
	                    NS_TrainID.CreateEngineConsistRecord(optional_engine_record_trainSeed, splitEngineSeeds[i], engineRecord, assignedDivision:"", helperCrewPoolId:"", defaultDataApplied:"", reportingPassCount:"", reportingLocation:"", reportingSource:"C", messagePurpose:"");
                
                    }
                }
            }
            
            System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
        	//Use first item in pipe seperated list
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            string content_symbol = NS_TrainID.GetTrainSymbol(content_symbol_trainSeed);
        	if (content_symbol == null)
        	{
        		content_symbol = content_symbol_trainSeed;
        	}
            string content_section = NS_TrainID.GetTrainSection(content_section_trainSeed);
            if (content_section == null)
        	{
        		content_section = content_section_trainSeed;
        	}
            string content_scac = NS_TrainID.GetTrainSCAC(content_scac_trainSeed);
            if (content_scac == null)
        	{
        		content_scac = content_scac_trainSeed;
        	}
            string content_origin_date = NS_TrainID.getOriginDate(content_origin_date_trainSeed);
            if (content_origin_date == null)
            {
            	content_origin_date = content_origin_date_trainSeed;
            }
            
            string content_ptc_engine_initial = NS_TrainID.GetEngineInitial(content_ptc_engine_initial_trainSeed, content_ptc_engine_initial_engineSeed);
            if (content_ptc_engine_initial == null)
        	{
        		content_ptc_engine_initial = content_ptc_engine_initial_engineSeed;
        	}
            string content_ptc_engine_number = NS_TrainID.GetEngineNumber(content_ptc_engine_number_trainSeed, content_ptc_engine_number_engineSeed);
            if (content_ptc_engine_number == null)
        	{
        		content_ptc_engine_number = content_ptc_engine_number_engineSeed;
        	}
            
			STE.Code_Utils.messages.PTC.PTC_CD_TCON_7.createCD_TCON_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, 
			                                                          header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, 
			                                                          header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, 
			                                                          header_uid2, content_scac, content_symbol, content_section, content_origin_date, content_loads, content_empties, content_tonnage, content_length, 
			                                                          content_axles, content_operative_brakes, content_total_braking_force, content_speed_constraint, content_speed, content_restriction_count, 
			                                                          content_restriction_record, content_speed_class, content_reporting_district, content_reporting_milepost, content_reporting_track, content_ptc_loco_orientation, 
			                                                          content_ptc_engine_initial, content_ptc_engine_number, content_engine_count, content_engine_record, hostname);
		}
        
        
        /// <summary>
		/// Send a CD-RCON PTC message.
		/// </summary>
		/// <param name="trigger_type">Reason for sending message: '02030' or 'CIBOS'</param>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-RCON</param>
		/// <param name="requesting_district">Timetable District Name associated with milepost value at requesting location</param>
		/// <param name="requesting_milepost">Exact milepost value with four decimal place precision</param>
		/// <param name="requesting_track">Track name at the requesting location</param>
		[UserCodeMethod]
        public static void SendCD_TCON_7Simple(string trainSeed, string engineSeed, string loads, string empties, string tonnage, string length, string axles, string operativeBrakes, string totalBrakingForce, string speedConstraint, string speed, string speedClass, string reportingDistrict, string reportingMilepost, string reportingTrack, string locoOrientation, string engineRecords, string restrictionRecords, string optionalEngineRecordTrainSeed, string optionalEngineRecordEngineSeeds, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = "";
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "CI";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_district_scac = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = engineSeed; //recent change Maris
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = engineSeed;
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	string content_ptc_engine_initial_trainSeed = trainSeed;
        	string content_ptc_engine_initial_engineSeed = engineSeed;
        	string content_ptc_engine_number_trainSeed = trainSeed;
        	string content_ptc_engine_number_engineSeed = engineSeed;
        	
        	string content_restriction_count = "0";
        	if (restrictionRecords != "")
        	{
        		content_restriction_count = restrictionRecords.Split('|').Length.ToString();
        	}
        	
        	string content_engine_count = "0";
        	if (engineRecords != "")
        	{
        		content_engine_count = (engineRecords.Split('|').Length/5).ToString();
        	}
        	
        	SendCD_TCON_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, 
		                                 header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version,
		                                 header_htrn_scac_trainSeed, header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed,
		                                 header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed, 
		                                 header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac_trainSeed, content_symbol_trainSeed, 
		                                 content_section_trainSeed, content_origin_date_trainSeed, loads, empties, tonnage, length, axles, 
		                                 operativeBrakes, totalBrakingForce, speedConstraint, speed, content_restriction_count, 
		                                 restrictionRecords, speedClass, reportingDistrict, reportingMilepost, reportingTrack, 
		                                 locoOrientation, content_ptc_engine_initial_trainSeed, content_ptc_engine_initial_engineSeed, content_ptc_engine_number_trainSeed, 
		                                 content_ptc_engine_number_engineSeed, content_engine_count, engineRecords, optionalEngineRecordTrainSeed, optionalEngineRecordEngineSeeds, hostname);
        }
        
        /// <summary>
		/// Send a LLM message.
		/// </summary>
		/// <param name="trigger_type">Reason for sending message: '02030' or 'CIBOS'</param>
		/// <param name="trainSeed">The look-up key for the train information used to send the CD-RCON</param>
		/// <param name="requesting_district">Timetable District Name associated with milepost value at requesting location</param>
		/// <param name="requesting_milepost">Exact milepost value with four decimal place precision</param>
		/// <param name="requesting_track">Track name at the requesting location</param>
		[UserCodeMethod]
		public static void SendLLM_2(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
		                             string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string content_engine_initial_trainSeed, string content_engine_initial_engineSeed, string content_engine_number_trainSeed, string content_engine_number_engineSeed, 
		                             string content_scac_trainSeed, string content_symbol_trainSeed, string content_section_trainSeed, string content_origin_date_trainSeed, string content_milepost, string content_division, string content_track, 
		                             string content_source, string content_location_event_date_offset_days, string content_location_event_time_offset_minutes, string content_location_event_timezone, string content_report_date_offset_days, 
		                             string content_report_time_offset_minutes, string content_report_timezone, string content_speed, string hostname)
		{
			System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
            
            string content_symbol = NS_TrainID.GetTrainSymbol(content_symbol_trainSeed);
        	if (content_symbol == null)
        	{
        		content_symbol = content_symbol_trainSeed;
        	}
            string content_section = NS_TrainID.GetTrainSection(content_section_trainSeed);
            if (content_section == null)
        	{
        		content_section = content_section_trainSeed;
        	}
            string content_scac = NS_TrainID.GetTrainSCAC(content_scac_trainSeed);
            if (content_scac == null)
        	{
        		content_scac = content_scac_trainSeed;
        	}
            string content_origin_date = NS_TrainID.getOriginDate(content_origin_date_trainSeed);
            if (content_origin_date == null)
            {
            	content_origin_date = content_origin_date_trainSeed;
            }
            
            string content_engine_initial = NS_TrainID.GetEngineInitial(content_engine_initial_trainSeed, content_engine_initial_engineSeed);
            if (content_engine_initial == null)
        	{
        		content_engine_initial = content_engine_initial_engineSeed;
        	}
            string content_engine_number = NS_TrainID.GetEngineNumber(content_engine_number_trainSeed, content_engine_number_engineSeed);
            if (content_engine_number == null)
        	{
        		content_engine_number = content_engine_number_engineSeed;
        	}
            
            string content_location_event_date;
            int content_location_event_date_offset_int = 0;
        	if (Int32.TryParse(content_location_event_date_offset_days, out content_location_event_date_offset_int))
        	{
        		content_location_event_date = now.AddDays(content_location_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_location_event_date = content_location_event_date_offset_days;
        	}
        	string content_location_event_time;
        	int content_location_event_time_offset_int = 0;
        	if (Int32.TryParse(content_location_event_time_offset_minutes, out content_location_event_time_offset_int))
        	{
        		content_location_event_time = now.AddMinutes(content_location_event_time_offset_int).ToString("HHmm");
        	} else {
        		content_location_event_time = content_location_event_time_offset_minutes;
        	}
        	
        	string content_report_date;
        	int content_report_date_offset_int = 0;
        	if (Int32.TryParse(content_report_date_offset_days, out content_report_date_offset_int))
        	{
        		content_report_date = now.AddDays(content_report_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_report_date = content_report_date_offset_days;
        	}
        	string content_report_time;
        	int content_report_time_offset_int = 0;
        	if (Int32.TryParse(content_report_time_offset_minutes, out content_report_time_offset_int))
        	{
        		content_report_time = now.AddMinutes(content_report_time_offset_int).ToString("HHmm");
        	} else {
        		content_report_time = content_report_time_offset_minutes;
        	}
			
			STE.Code_Utils.messages.PTC.GPS_LLM_2.createLLM_2(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, 
			                                                  header_district_name, header_district_scac, header_user_id, content_engine_initial, content_engine_number, content_scac, content_symbol, content_section, 
			                                                  content_origin_date, content_milepost, content_division, content_track, content_source, content_location_event_date, content_location_event_time, 
			                                                  content_location_event_timezone, content_report_date, content_report_time, content_report_timezone, content_speed, hostname);
		}

		[UserCodeMethod]
        public static void SendLLM_2Simple(string trainSeed, string engineSeed, string milepost, string division, string track, string source, 
		                                   string district, string speed, string locationEventDay, string locationEventDateTime, string locationEventTimeZone, 
		                                   string reportDay, string reportDateTime, string reportTimeZone, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_name = district;
        	string header_sequence_number = "Default";
        	string header_message_version = "2";
        	string header_message_revision = "0";
        	string header_source_sys = "WLIS";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_district_scac = "";
        	string content_scac_trainSeed = trainSeed;
        	string content_symbol_trainSeed = trainSeed;
        	string content_section_trainSeed = trainSeed;
        	string content_origin_date_trainSeed = trainSeed;
        	string content_engine_initial_trainSeed = trainSeed;
        	string content_engine_initial_engineSeed = engineSeed;
        	string content_engine_number_trainSeed = trainSeed;
        	string content_engine_number_engineSeed = engineSeed;
        	string content_location_event_date_offset_days = locationEventDay;
        	string content_location_event_time_offset_minutes = locationEventDateTime;
        	string content_location_event_timezone = locationEventTimeZone;
        	string content_report_date_offset_days = reportDay;
        	string content_report_time_offset_minutes = reportDateTime;
        	string content_report_timezone = reportTimeZone;
        	
        	SendLLM_2(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, header_source_sys, 
		                             header_destination_sys, header_district_name, header_district_scac, header_user_id, content_engine_initial_trainSeed, content_engine_initial_engineSeed, content_engine_number_trainSeed, content_engine_number_engineSeed, 
		                             content_scac_trainSeed, content_symbol_trainSeed, content_section_trainSeed, content_origin_date_trainSeed, milepost, division, track, 
		                             source, content_location_event_date_offset_days, content_location_event_time_offset_minutes, content_location_event_timezone, content_report_date_offset_days, 
		                             content_report_time_offset_minutes, content_report_timezone, speed, hostname);
        }        
        
        /// <summary>
		/// Send GD-CATA PTC message
		/// </summary>
		/// <param name="district">Input:district</param>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="engineSeed">Input:engineSeed</param>
		/// <param name="crewSeed">Input:crewSeed</param>
		/// <param name="authoritySeed">Input:authoritySeed</param>
		/// <param name="action">Input:action</param>
       	[UserCodeMethod]
       	public static void SendGD_CATA_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, 
		                                 string header_source_sys, string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version,
		                                 string header_htrn_scac_trainSeed, string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed,
		                                 string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed, string header_heng_engine_number_engineSeed, 
		                                 string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_track_authority_number_authoritySeed, string content_action, 
		                                 string content_employee_first_crewSeed, string content_employee_middle_crewSeed, string content_employee_last_crewSeed, string hostname)
        {
       		System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            string content_track_authority_number = NS_Authorities.GetAuthorityNumber(content_track_authority_number_authoritySeed);
            if (content_track_authority_number == null)
        	{
        		content_track_authority_number = content_track_authority_number_authoritySeed;
        	}
            
            string content_employee_first = NS_CrewClass.GetCrewMemberFirstInitial(content_employee_first_crewSeed);
            if (content_employee_first == null)
        	{
        		content_employee_first = content_employee_first_crewSeed;
        	}
            string content_employee_middle = NS_CrewClass.GetCrewMemberMiddleInitial(content_employee_middle_crewSeed);
            if (content_employee_middle == null)
        	{
        		content_employee_middle = content_employee_middle_crewSeed;
        	}
            string content_employee_last = NS_CrewClass.GetCrewMemberLastName(content_employee_last_crewSeed);
            if (content_employee_last == null)
        	{
        		content_employee_last = content_employee_last_crewSeed;
        	}
            
       		STE.Code_Utils.messages.PTC.PTC_GD_CATA_7.createGD_CATA_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, 
       		                                                          header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, 
       		                                                          header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, 
       		                                                          header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, 
       		                                                          content_track_authority_number, content_action, content_employee_first, content_employee_middle, content_employee_last, 
       		                                                          hostname);
       	}
        
       	[UserCodeMethod]
       	public static void SendGD_BOSR_7Simple(string operatingMode, string operatingCondition, string districtName, string districtScac, string hostName)
       	{
       		string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_scac = districtScac;
        	string header_district_name = districtName;
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "GD";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
       		
        	System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	STE.Code_Utils.messages.PTC.PTC_GD_BOSR_7.createGD_BOSR_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys,
        	                                                          header_district_name, header_district_scac, header_user_id, header_track_file_version, header_district_scac, "", "", header_event_date, "", "", header_uid1_type, header_uid1,
        	                                                          header_uid2_type, header_uid2, operatingMode, operatingCondition, hostName);
       	}
       	
		/// <summary>
		/// Send GD-CATA PTC message
		/// </summary>
		/// <param name="district">Input:district</param>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="engineSeed">Input:engineSeed</param>
		/// <param name="crewSeed">Input:crewSeed</param>
		/// <param name="authoritySeed">Input:authoritySeed</param>
		/// <param name="action">Input:action</param>
       	[UserCodeMethod]
       	public static void SendGD_CATA_7Simple(string trainSeed, string authoritySeed, string crewSeed, string districtScac, string districtName, string action, string hostname)
        {
       		string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_scac = districtScac;
        	string header_district_name = districtName;
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "GD";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = "";
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = "";
        	string content_track_authority_number_authoritySeed = authoritySeed;
        	string content_employee_first_crewSeed = crewSeed;
        	string content_employee_middle_crewSeed = crewSeed;
        	string content_employee_last_crewSeed = crewSeed;
       		
       		SendGD_CATA_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, 
		                                 header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version,
		                                 header_htrn_scac_trainSeed, header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed,
		                                 header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed, 
		                                 header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_track_authority_number_authoritySeed, action, 
		                                 content_employee_first_crewSeed, content_employee_middle_crewSeed, content_employee_last_crewSeed, hostname);
       	}
       	
       	
       	/// <summary>
		/// Send GD-CATA PTC message
		/// </summary>
		/// <param name="district">Input:district</param>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="engineSeed">Input:engineSeed</param>
		/// <param name="crewSeed">Input:crewSeed</param>
		/// <param name="authoritySeed">Input:authoritySeed</param>
		/// <param name="action">Input:action</param>
       	[UserCodeMethod]
       	public static void SendGD_ADSR_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, 
		                                 string header_source_sys, string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version,
		                                 string header_htrn_scac_trainSeed, string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed,
		                                 string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed, string header_heng_engine_number_engineSeed, 
		                                 string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_track_authority_number_authoritySeed, string content_action, 
		                                 string content_status_code, string content_engine_initial_trainSeed, string content_engine_initial_engineSeed, string content_engine_number_trainSeed, string content_engine_number_engineSeed, 
		                                 string content_crew_ack_required, string content_electronic_ack_requested, string hostname)
        {
       		System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            string content_track_authority_number = NS_Authorities.GetAuthorityNumber(content_track_authority_number_authoritySeed);
            if (content_track_authority_number == null)
        	{
        		content_track_authority_number = content_track_authority_number_authoritySeed;
        	}
            
            string content_engine_initial = NS_TrainID.GetEngineInitial(content_engine_initial_trainSeed, content_engine_initial_engineSeed);
            if (content_engine_initial == null)
        	{
        		content_engine_initial = content_engine_initial_engineSeed;
        	}
            string content_engine_number = NS_TrainID.GetEngineNumber(content_engine_number_trainSeed, content_engine_number_engineSeed);
            if (content_engine_number == null)
        	{
        		content_engine_number = content_engine_number_engineSeed;
        	}
            
            
       		STE.Code_Utils.messages.PTC.PTC_GD_ADSR_7.createGD_ADSR_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, 
                                                                      header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, 
                                                                      header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, 
                                                                      header_uid1, header_uid2_type, header_uid2, content_track_authority_number, content_action, content_status_code, content_engine_initial, 
                                                                      content_engine_number, content_crew_ack_required, content_electronic_ack_requested, hostname);
       	}
       	
		/// <summary>
		/// Send the GD-ASDR PTC Message	
		/// </summary>
		/// <param name="district"></param>
		/// <param name="trainSeed"></param>
		/// <param name="engineSeed"></param>
		/// <param name="authoritySeed"></param>
		/// <param name="action"></param>
		/// <param name="status"></param>
		/// <param name="crewAckRequired"></param>
		/// <param name="electronicAckRequired"></param>
       	[UserCodeMethod]
       	public static void SendGD_ADSR_7Simple(string trainSeed, string engineSeed, string authoritySeed, string districtScac, string districtName, string action, string statusCode, string crewAckRequired, string electronicAckRequested, string hostname)
        {
       		string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_scac = districtScac;
        	string header_district_name = districtName;
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "GD";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_htrn_scac_trainSeed = trainSeed;
        	string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
        	string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = engineSeed;
        	string header_heng_engine_number_trainSeed = trainSeed;
        	string header_heng_engine_number_engineSeed = engineSeed;
        	string content_track_authority_number_authoritySeed = authoritySeed;
        	string content_engine_initial_trainSeed = trainSeed;
        	string content_engine_initial_engineSeed = engineSeed;
        	string content_engine_number_trainSeed = trainSeed;
        	string content_engine_number_engineSeed = engineSeed;
       		
       		SendGD_ADSR_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, 
		                                 header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version,
		                                 header_htrn_scac_trainSeed, header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed,
		                                 header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed, 
		                                 header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_track_authority_number_authoritySeed, action, 
		                                 statusCode, content_engine_initial_trainSeed, content_engine_initial_engineSeed, content_engine_number_trainSeed, content_engine_number_engineSeed, 
		                                 crewAckRequired, electronicAckRequested, hostname);
       	}
       	
       	[UserCodeMethod]
       	public static void SendGD_SY01_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, 
		                                 string header_source_sys, string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version,
		                                 string header_htrn_scac_trainSeed, string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed,
		                                 string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_trainSeed, string header_heng_engine_number_engineSeed, 
		                                 string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_synch_req_type, string content_district_version, string hostname)
        {
       		System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed);
        	if (header_htrn_symbol == null)
        	{
        		header_htrn_symbol = header_htrn_symbol_trainSeed;
        	}
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            if (header_htrn_section == null)
        	{
        		header_htrn_section = header_htrn_section_trainSeed;
        	}
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed);
            if (header_htrn_scac == null)
        	{
        		header_htrn_scac = header_htrn_scac_trainSeed;
        	}
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed);
            if (header_htrn_origin_date == null)
            {
            	header_htrn_origin_date = header_htrn_origin_date_trainSeed;
            }
            
        	
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed);
            if (header_heng_engine_initial == null)
        	{
        		header_heng_engine_initial = header_heng_engine_initial_engineSeed;
        	}
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed);
            if (header_heng_engine_number == null)
        	{
        		header_heng_engine_number = header_heng_engine_number_engineSeed;
        	}
            
            
       		STE.Code_Utils.messages.PTC.PTC_GD_SY01_7.createGD_SY01_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, 
                                                                      header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, 
                                                                      header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, 
                                                                      header_uid1, header_uid2_type, header_uid2, content_synch_req_type, content_district_version, hostname);
       	}

		/// <summary>
		/// Send a GD-SY01 PTC message.
		/// </summary>
		/// <param name="synch_req_type"></param>
		/// <param name="header_district_name"></param>
		/// <param name="header_district_scac"></param>
		/// <param name="header_user_id"></param>
		/// <param name="header_track_file_version"></param>
		/// <param name="header_heng_engine_initial_trainSeed"></param>
		/// <param name="header_heng_engine_initial_engineSeed"></param>
		/// <param name="header_uid2_type"></param>
		/// <param name="header_uid1"></param>
		/// <param name="header_uid1_type"></param>
		/// <param name="district_version"></param>
		[UserCodeMethod]
		public static void SendGD_SY01_7Simple(string districtScac, string districtName, string synchReqType, string districtVersion, string hostname)
		{
			string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_district_scac = districtScac;
        	string header_district_name = districtName;
        	string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
        	string header_source_sys = "GD";
        	string header_destination_sys = "CAD";
        	string header_user_id = "UserId";
        	string header_track_file_version = "1234";
        	string header_uid1_type ="";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
        	string header_htrn_scac_trainSeed = "";
        	string header_htrn_symbol_trainSeed = "";
        	string header_htrn_section_trainSeed = "";
        	string header_htrn_origin_date_trainSeed = "";
        	string header_heng_engine_initial_trainSeed = "";
        	string header_heng_engine_initial_engineSeed = "";
        	string header_heng_engine_number_trainSeed = "";
        	string header_heng_engine_number_engineSeed = "";
        	

			SendGD_SY01_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, 
		                                 header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version,
		                                 header_htrn_scac_trainSeed, header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed,
		                                 header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed, 
		                                 header_uid1_type, header_uid1, header_uid2_type, header_uid2, synchReqType, districtVersion, hostname);
		}
		/// <summary>
		/// Send LLM Version 3 Message
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="engineSeed"></param>
		/// <param name="milepost"></param>
		/// <param name="division"></param>
		/// <param name="track"></param>
		/// <param name="source"></param>
		/// <param name="district"></param>
		/// <param name="speed"></param>
		/// <param name="locationEventDateTime"></param>
		/// <param name="locationEventTimeZone"></param>
		/// <param name="reportDateTime"></param>
		/// <param name="reportTimeZone"></param>
		/// <param name="hostname"></param>
		[UserCodeMethod]
		public static void SendLLM_3Simple(string trainSeed, string engineSeed, string milepost, string division,  string track, string source, string district, string speed, string locationEventDateTime, string locationEventTimeZone, string reportDateTime, string reportTimeZone, string hostname)		{
			string header_event_date_offset_days = "0";
			string header_event_time_offset_minutes = "0";
			string header_district_name = district;
			string header_sequence_number = "Default";
			string header_message_version = "3";
			string header_message_revision = "0";
			string header_source_sys = "WLIS";
			string header_destination_sys = "CAD";
			string header_user_id = "UserId";
			string header_district_scac = "";
			string content_scac_trainSeed = trainSeed;
			string content_symbol_trainSeed = trainSeed;
			string content_section_trainSeed = trainSeed;
			string content_origin_date_trainSeed = trainSeed;
			string content_engine_initial_trainSeed = trainSeed;
			string content_engine_initial_engineSeed = engineSeed;
			string content_engine_number_trainSeed = trainSeed;
			string content_engine_number_engineSeed = engineSeed;
			string content_location_event_date_offset_days = "0";
			string content_location_event_time_offset_minutes = locationEventDateTime;
			string content_location_event_timezone = locationEventTimeZone;
			string content_report_date_offset_days = "0";
			string content_report_time_offset_minutes = reportDateTime;
			string content_report_timezone = reportTimeZone;
			
			SendLLM_2(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, header_source_sys,
			          header_destination_sys, header_district_name, header_district_scac, header_user_id, content_engine_initial_trainSeed, content_engine_initial_engineSeed, content_engine_number_trainSeed, content_engine_number_engineSeed,
			          content_scac_trainSeed, content_symbol_trainSeed, content_section_trainSeed, content_origin_date_trainSeed, milepost, division, track,
			          source, content_location_event_date_offset_days, content_location_event_time_offset_minutes, content_location_event_timezone, content_report_date_offset_days,
			          content_report_time_offset_minutes, content_report_timezone, speed, hostname);
		}
		
		/// <summary>
		/// Send GD-CTIR PTC message
		/// </summary>
		/// <param name="district">Input:district</param>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="engineSeed">Input:engineSeed</param>
		/// <param name="crewSeed">Input:crewSeed</param>
       	[UserCodeMethod]
       	public static void SendGD_CTIR_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, string header_destination_sys, string header_district_scac, string header_district_name, string header_user_id, string header_track_file_version, string header_htrn_scac_trainSeed, string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed,
       	                                 string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_engineSeed, string header_heng_engine_number_trainSeed, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac_trainseed, string content_symbol_trainseed, string content_section_trainseed, string content_origin_date_offset, string content_engine_initial_trainseed,
       	                                 string content_engine_initial_engineseed,string content_engine_number_trainseed,string content_engine_number_engineseed, string content_coupled_engine_initial, string content_coupled_engine_number, string content_employee_first_crewSeed, string content_employee_middle_crewSeed, string content_employee_last_crewSeed, string content_track_authority_to_void, string content_spaf_ack, string hostname)
       	{
       		System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed) ?? header_htrn_symbol_trainSeed;
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed) ?? header_htrn_section_trainSeed;
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed) ?? header_htrn_scac_trainSeed;
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed) ?? header_htrn_origin_date_trainSeed;
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed) ?? header_heng_engine_initial_engineSeed;
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed) ?? header_heng_engine_number_engineSeed;
            string content_employee_first = NS_CrewClass.GetCrewMemberFirstInitial(content_employee_first_crewSeed) ?? content_employee_first_crewSeed;
            string content_employee_middle = NS_CrewClass.GetCrewMemberMiddleInitial(content_employee_middle_crewSeed) ?? content_employee_middle_crewSeed;
            string content_employee_last = NS_CrewClass.GetCrewMemberLastName(content_employee_last_crewSeed) ?? content_employee_last_crewSeed;
            string content_scac = NS_TrainID.GetTrainSCAC(content_scac_trainseed) ?? content_scac_trainseed;
            string content_symbol = NS_TrainID.GetTrainSymbol(content_symbol_trainseed) ?? content_symbol_trainseed;
        	string content_section = NS_TrainID.GetTrainSection(content_section_trainseed) ?? content_section_trainseed;
            
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset;
        	}
        	
            string content_engine_initial = NS_TrainID.GetEngineInitial(content_engine_initial_trainseed, content_engine_initial_engineseed) ?? content_engine_initial_engineseed;
            string content_engine_number = NS_TrainID.GetEngineNumber(content_engine_number_trainseed, content_engine_number_engineseed) ?? content_engine_number_engineseed;
            
       		STE.Code_Utils.messages.PTC.PTC_GD_CTIR_7.createGD_CTIR_7(header_event_date,header_event_time,header_sequence_number,header_message_version,header_message_revision,header_source_sys,header_destination_sys,header_district_name,header_district_scac,header_user_id,header_track_file_version,header_htrn_scac,
                                                                      header_htrn_symbol,header_htrn_section,header_htrn_origin_date,header_heng_engine_initial,header_heng_engine_number,header_uid1_type,header_uid1,header_uid2_type,header_uid2,content_scac,content_symbol,content_section,content_origin_date,content_engine_initial,
                                                                      content_engine_number,content_coupled_engine_initial,content_coupled_engine_number,content_employee_first,content_employee_middle,content_employee_last,content_track_authority_to_void,content_spaf_ack,hostname);
       	}
        
		
		/// <summary>
		/// Send GD-CTIR PTC message
		/// </summary>
		/// <param name="district">Input:district</param>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="engineSeed">Input:engineSeed</param>
		/// <param name="crewSeed">Input:crewSeed</param>
       	[UserCodeMethod]
       	public static void SendGD_CTIR_7Simple(string trainSeed, string crewSeed, string engineSeed, string districtScac, string districtName, string hostname)
        {
       		string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
			string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
			string header_source_sys = "GD";
        	string header_destination_sys = "CAD";
			string header_district_scac = districtScac;
        	string header_district_name = districtName;
			string header_user_id = "UserId";
			string header_track_file_version = "1";
			string header_htrn_scac_trainSeed = trainSeed;
			string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
			string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = engineSeed;
        	string header_heng_engine_number_engineSeed = engineSeed;
        	string header_heng_engine_number_trainSeed = trainSeed;
			string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
			string content_scac_trainseed = trainSeed;
			string content_symbol_trainseed = trainSeed;
			string content_section_trainseed = trainSeed;
			string content_origin_date_offset = "0";
			string content_engine_initial_trainseed = trainSeed;
			string content_engine_initial_engineseed = engineSeed;
			string content_engine_number_trainseed = trainSeed;
			string content_engine_number_engineseed = engineSeed;
			string content_coupled_engine_initial = "";
			string content_coupled_engine_number = "";
			string content_employee_first_crewSeed = crewSeed;
        	string content_employee_middle_crewSeed = crewSeed;
        	string content_employee_last_crewSeed = crewSeed;
			string content_track_authority_to_void = "";
			string content_spaf_ack = "Y";

       		SendGD_CTIR_7(header_event_date_offset_days,header_event_time_offset_minutes,header_sequence_number,header_message_version,header_message_revision,header_source_sys,
			              header_destination_sys,header_district_scac,header_district_name,header_user_id,header_track_file_version,header_htrn_scac_trainSeed,
			              header_htrn_symbol_trainSeed,header_htrn_section_trainSeed,header_htrn_origin_date_trainSeed,header_heng_engine_initial_trainSeed,header_heng_engine_initial_engineSeed,header_heng_engine_number_engineSeed,header_heng_engine_number_trainSeed,
			              header_uid1_type,header_uid1,header_uid2_type,header_uid2,content_scac_trainseed,content_symbol_trainseed,content_section_trainseed,content_origin_date_offset,content_engine_initial_trainseed,content_engine_initial_engineseed,
			              content_engine_number_trainseed,content_engine_number_engineseed,content_coupled_engine_initial,content_coupled_engine_number,content_employee_first_crewSeed,content_employee_middle_crewSeed,content_employee_last_crewSeed,content_track_authority_to_void,content_spaf_ack,hostname);

       	}
       	
       	/// <summary>
		/// Send GD-CTRR PTC message
		/// </summary>
		/// <param name="district">Input:district</param>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="engineSeed">Input:engineSeed</param>
		/// <param name="crewSeed">Input:crewSeed</param>
		/// <param name="authoritySeed">Input:authoritySeed</param>
		/// <param name="milepostinterger">Input:milepostinterger</param>
       	[UserCodeMethod]
       	public static void SendGD_CTRR_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac_trainSeed, string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed,
       	                                 string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_engineSeed, string header_heng_engine_number_trainSeed, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, 
       	                                 string content_track_authority_number_authorityseed, string content_milepost_integer,string content_district,string content_track,string content_employee_first_crewSeed, string content_employee_middle_crewSeed, string content_employee_last_crewSeed, string content_spaf_ack, string hostname)
       	{
       		System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed) ?? header_htrn_symbol_trainSeed;
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed);
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed) ?? header_htrn_scac_trainSeed;
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed) ?? header_htrn_origin_date_trainSeed;
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed) ?? header_heng_engine_initial_engineSeed;
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed) ?? header_heng_engine_number_engineSeed;
            string content_track_authority_number = NS_Authorities.GetAuthorityNumber(content_track_authority_number_authorityseed) ?? content_track_authority_number_authorityseed;
            string content_employee_first = NS_CrewClass.GetCrewMemberFirstInitial(content_employee_first_crewSeed) ?? content_employee_first_crewSeed;
            string content_employee_middle = NS_CrewClass.GetCrewMemberMiddleInitial(content_employee_middle_crewSeed) ?? content_employee_middle_crewSeed;
            string content_employee_last = NS_CrewClass.GetCrewMemberLastName(content_employee_last_crewSeed) ?? content_employee_last_crewSeed;

       		STE.Code_Utils.messages.PTC.PTC_GD_CTRR_7.createGD_CTRR_7(header_event_date,header_event_time,header_sequence_number,header_message_version,header_message_revision,header_source_sys,header_destination_sys,header_district_name,header_district_scac,header_user_id,header_track_file_version,header_htrn_scac,
                                                                      header_htrn_symbol,header_htrn_section,header_htrn_origin_date,header_heng_engine_initial,header_heng_engine_number,header_uid1_type,header_uid1,header_uid2_type,header_uid2,
                                                                      content_track_authority_number,content_milepost_integer,content_district,content_track,content_employee_first,content_employee_middle,content_employee_last,content_spaf_ack,hostname);
       	}
        
		
		/// <summary>
		/// Send GD-CTRR PTC message
		/// </summary>
		/// <param name="district">Input:district</param>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="engineSeed">Input:engineSeed</param>
		/// <param name="crewSeed">Input:crewSeed</param>
		/// <param name="authoritySeed">Input:authoritySeed</param>
		/// <param name="milepostinterger">Input:milepostinterger</param>
       	[UserCodeMethod]
       	public static void SendGD_CTRR_7Simple(string trainSeed, string crewSeed, string engineSeed, string authorityseed, string milepostinteger, string districtScac, string districtName, string hostname)
        {
       		string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
			string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
			string header_source_sys = "GD";
        	string header_destination_sys = "CAD";
			string header_district_scac = districtScac;
        	string header_district_name = districtName;
			string header_user_id = "UserId";
			string header_track_file_version = "1";
			string header_htrn_scac_trainSeed = trainSeed;
			string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
			string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = engineSeed;
        	string header_heng_engine_number_engineSeed = engineSeed;
        	string header_heng_engine_number_trainSeed = trainSeed;
			string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
			string content_track_authority_number_authorityseed = authorityseed;
			string content_milepost_integer = milepostinteger;
			string content_district = districtName;
			string content_track = "MAIN";
			string content_employee_first_crewSeed = crewSeed;
        	string content_employee_middle_crewSeed = crewSeed;
        	string content_employee_last_crewSeed = crewSeed;
			string content_spaf_ack = "Y";

       		SendGD_CTRR_7(header_event_date_offset_days,header_event_time_offset_minutes,header_sequence_number,header_message_version,header_message_revision,header_source_sys,
			              header_destination_sys,header_district_name,header_district_scac,header_user_id,header_track_file_version,header_htrn_scac_trainSeed,
			              header_htrn_symbol_trainSeed,header_htrn_section_trainSeed,header_htrn_origin_date_trainSeed,header_heng_engine_initial_trainSeed,header_heng_engine_initial_engineSeed,header_heng_engine_number_engineSeed,header_heng_engine_number_trainSeed,
			              header_uid1_type,header_uid1,header_uid2_type,header_uid2,content_track_authority_number_authorityseed,content_milepost_integer,content_district,content_track,content_employee_first_crewSeed,
			              content_employee_middle_crewSeed,content_employee_last_crewSeed,content_spaf_ack,hostname);

       	}
       	
       	/// <summary>
		/// Send GD-CTER PTC message
		/// </summary>
		/// <param name="district">Input:district</param>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="engineSeed">Input:engineSeed</param>
		/// <param name="crewSeed">Input:crewSeed</param>
		/// <param name="authoritySeed">Input:authoritySeed</param>
		/// <param name="req_time_extension">Input:milepostinterger</param>
       	[UserCodeMethod]
       	public static void SendGD_CTER_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac_trainSeed, string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed,
       	                                 string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_engineSeed, string header_heng_engine_number_trainSeed, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, 
       	                                 string content_track_authority_number_authorityseed,string content_employee_first_crewSeed, string content_employee_middle_crewSeed, string content_employee_last_crewSeed, string req_time_extension, string hostname)
       	{
       		System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
        	string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed) ?? header_htrn_symbol_trainSeed;
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed) ?? header_htrn_section_trainSeed;
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed) ?? header_htrn_scac_trainSeed;
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed) ?? header_htrn_origin_date_trainSeed;
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed) ?? header_heng_engine_initial_engineSeed;
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed) ?? header_heng_engine_number_engineSeed;
            string content_track_authority_number = NS_Authorities.GetAuthorityNumber(content_track_authority_number_authorityseed) ?? content_track_authority_number_authorityseed;
            string content_employee_first = NS_CrewClass.GetCrewMemberFirstInitial(content_employee_first_crewSeed) ?? content_employee_first_crewSeed;
            string content_employee_middle = NS_CrewClass.GetCrewMemberMiddleInitial(content_employee_middle_crewSeed) ?? content_employee_middle_crewSeed;
            string content_employee_last = NS_CrewClass.GetCrewMemberLastName(content_employee_last_crewSeed) ?? content_employee_last_crewSeed;
                    
       		STE.Code_Utils.messages.PTC.PTC_GD_CTER_7.createGD_CTER_7(header_event_date,header_event_time,header_sequence_number,header_message_version,header_message_revision,header_source_sys,header_destination_sys,header_district_name,header_district_scac,header_user_id,header_track_file_version,header_htrn_scac,
                                                                      header_htrn_symbol,header_htrn_section,header_htrn_origin_date,header_heng_engine_initial,header_heng_engine_number,header_uid1_type,header_uid1,header_uid2_type,header_uid2,
                                                                      content_track_authority_number,content_employee_first,content_employee_middle,content_employee_last,req_time_extension,hostname);
       	}
        
		
		/// <summary>
		/// Send GD-CTER PTC message
		/// </summary>
		/// <param name="district">Input:district</param>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="engineSeed">Input:engineSeed</param>
		/// <param name="crewSeed">Input:crewSeed</param>
		/// <param name="authoritySeed">Input:authoritySeed</param>
		/// <param name="req_time_extension">Input:milepostinterger</param>
       	[UserCodeMethod]
       	public static void SendGD_CTER_7Simple(string trainSeed, string crewSeed, string engineSeed, string authorityseed, string req_time_extension, string districtScac, string districtName, string hostname)
        {
       		string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
			string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
			string header_source_sys = "GD";
        	string header_destination_sys = "CAD";
			string header_district_scac = districtScac;
        	string header_district_name = districtName;
			string header_user_id = "UserId";
			string header_track_file_version = "1";
			string header_htrn_scac_trainSeed = trainSeed;
			string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
			string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = engineSeed;
        	string header_heng_engine_number_engineSeed = engineSeed;
        	string header_heng_engine_number_trainSeed = trainSeed;
			string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
			string content_track_authority_number_authorityseed = authorityseed;
			string content_employee_first_crewSeed = crewSeed;
        	string content_employee_middle_crewSeed = crewSeed;
        	string content_employee_last_crewSeed = crewSeed;
			 
       		SendGD_CTER_7(header_event_date_offset_days,header_event_time_offset_minutes,header_sequence_number,header_message_version,header_message_revision,header_source_sys,
			              header_destination_sys,header_district_name,header_district_scac,header_user_id,header_track_file_version,header_htrn_scac_trainSeed,
			              header_htrn_symbol_trainSeed,header_htrn_section_trainSeed,header_htrn_origin_date_trainSeed,header_heng_engine_initial_trainSeed,header_heng_engine_initial_engineSeed,header_heng_engine_number_engineSeed,header_heng_engine_number_trainSeed,
			              header_uid1_type,header_uid1,header_uid2_type,header_uid2,content_track_authority_number_authorityseed,content_employee_first_crewSeed,content_employee_middle_crewSeed,content_employee_last_crewSeed,req_time_extension,hostname);

       	}
       	
       		/// <summary>
		/// Send GD-CTVR PTC message
		/// </summary>
		/// <param name="district">Input:district</param>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="engineSeed">Input:engineSeed</param>
		/// <param name="crewSeed">Input:crewSeed</param>
		/// <param name="authoritySeed">Input:authoritySeed</param>
       	[UserCodeMethod]
       	public static void SendGD_CTVR_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac_trainSeed, string header_htrn_symbol_trainSeed, string header_htrn_section_trainSeed, string header_htrn_origin_date_trainSeed,
       	                                 string header_heng_engine_initial_trainSeed, string header_heng_engine_initial_engineSeed, string header_heng_engine_number_engineSeed, string header_heng_engine_number_trainSeed, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, 
       	                                 string content_track_authority_number_authorityseed,string content_employee_first_crewSeed, string content_employee_middle_crewSeed, string content_employee_last_crewSeed, string content_spaf_ack, string hostname)
       	{
       		System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_event_date = header_event_date_offset_days;
        	}
        	
        	string header_event_time;
        	int header_event_time_offset_int = 0;
        	if (Int32.TryParse(header_event_time_offset_minutes, out header_event_time_offset_int))
        	{
        		header_event_time = now.AddMinutes(header_event_time_offset_int).ToString("HHmmss");
        	} else {
        		header_event_time = header_event_time_offset_minutes;
        	}
        	
			string header_htrn_symbol = NS_TrainID.GetTrainSymbol(header_htrn_symbol_trainSeed) ?? header_htrn_symbol_trainSeed;
            string header_htrn_section = NS_TrainID.GetTrainSection(header_htrn_section_trainSeed) ?? header_htrn_section_trainSeed;
            string header_htrn_scac = NS_TrainID.GetTrainSCAC(header_htrn_scac_trainSeed) ?? header_htrn_scac_trainSeed;
            string header_htrn_origin_date = NS_TrainID.getOriginDate(header_htrn_origin_date_trainSeed) ?? header_htrn_origin_date_trainSeed;
            string header_heng_engine_initial = NS_TrainID.GetEngineInitial(header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed) ?? header_heng_engine_initial_engineSeed;
            string header_heng_engine_number = NS_TrainID.GetEngineNumber(header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed) ?? header_heng_engine_number_engineSeed;
            string content_track_authority_number = NS_Authorities.GetAuthorityNumber(content_track_authority_number_authorityseed) ?? content_track_authority_number_authorityseed;
            string content_employee_first = NS_CrewClass.GetCrewMemberFirstInitial(content_employee_first_crewSeed) ?? content_employee_first_crewSeed;
            string content_employee_middle = NS_CrewClass.GetCrewMemberMiddleInitial(content_employee_middle_crewSeed) ?? content_employee_middle_crewSeed;
            string content_employee_last = NS_CrewClass.GetCrewMemberLastName(content_employee_last_crewSeed) ?? content_employee_last_crewSeed;
                    
       		STE.Code_Utils.messages.PTC.PTC_GD_CTVR_7.createGD_CTVR_7(header_event_date,header_event_time,header_sequence_number,header_message_version,header_message_revision,header_source_sys,header_destination_sys,header_district_name,header_district_scac,header_user_id,header_track_file_version,header_htrn_scac,
                                                                      header_htrn_symbol,header_htrn_section,header_htrn_origin_date,header_heng_engine_initial,header_heng_engine_number,header_uid1_type,header_uid1,header_uid2_type,header_uid2,
                                                                      content_track_authority_number,content_employee_first,content_employee_middle,content_employee_last,content_spaf_ack,hostname);
       	}
        
		
		/// <summary>
		/// Send GD-CTVR PTC message
		/// </summary>
		/// <param name="district">Input:district</param>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="engineSeed">Input:engineSeed</param>
		/// <param name="crewSeed">Input:crewSeed</param>
		/// <param name="authoritySeed">Input:authoritySeed</param>
       	[UserCodeMethod]
       	public static void SendGD_CTVR_7Simple(string trainSeed, string crewSeed, string engineSeed, string authorityseed, string districtScac, string districtName, string hostname)
        {
       		string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
			string header_sequence_number = "Default";
        	string header_message_version = "7";
        	string header_message_revision = "0";
			string header_source_sys = "GD";
        	string header_destination_sys = "CAD";
			string header_district_scac = districtScac;
        	string header_district_name = districtName;
			string header_user_id = "UserId";
			string header_track_file_version = "1";
			string header_htrn_scac_trainSeed = trainSeed;
			string header_htrn_symbol_trainSeed = trainSeed;
        	string header_htrn_section_trainSeed = trainSeed;
        	string header_htrn_origin_date_trainSeed = trainSeed;
			string header_heng_engine_initial_trainSeed = trainSeed;
        	string header_heng_engine_initial_engineSeed = engineSeed;
        	string header_heng_engine_number_engineSeed = engineSeed;
        	string header_heng_engine_number_trainSeed = trainSeed;
			string header_uid1_type = "";
        	string header_uid1 = "";
        	string header_uid2_type = "";
        	string header_uid2 = "";
			string content_track_authority_number_authorityseed = authorityseed;
			string content_employee_first_crewSeed = crewSeed;
        	string content_employee_middle_crewSeed = crewSeed;
        	string content_employee_last_crewSeed = crewSeed;
        	string content_spaf_ack = "Y";
			 
       		SendGD_CTVR_7(header_event_date_offset_days,header_event_time_offset_minutes,header_sequence_number,header_message_version,header_message_revision,header_source_sys,
			              header_destination_sys,header_district_name,header_district_scac,header_user_id,header_track_file_version,header_htrn_scac_trainSeed,
			              header_htrn_symbol_trainSeed,header_htrn_section_trainSeed,header_htrn_origin_date_trainSeed,header_heng_engine_initial_trainSeed,header_heng_engine_initial_engineSeed,header_heng_engine_number_engineSeed,header_heng_engine_number_trainSeed,
			              header_uid1_type,header_uid1,header_uid2_type,header_uid2,content_track_authority_number_authorityseed,content_employee_first_crewSeed,content_employee_middle_crewSeed,content_employee_last_crewSeed,content_spaf_ack,hostname);

       	}
		
    }

	[UserCodeCollection]
	public class NS_PTC_Message_Validations
	{
		/// <summary>
		/// Validates the DC-ENED XML Message produced by PDS.
		/// </summary>
		/// <param name="trainSeed">Input: trainSeed corresponding to the train in the DC-ENED. At this time, only the train symbol is validated.</param>
		/// <param name="optTerritory">Input: Optional dispatch territory to be included in the message</param>
		/// <param name="optEnableDisable">Input: (0) Enable, (1) Disable</param>
		/// <param name="optEnableDisableReason">Input: Text field for reason to be displayed to the crew.</param>
		/// <param name="enableDisableReasonCodeExists">Input: Whether to validate that the xml element exists. If false, validates that it does not exist in message.</param>
		/// <param name="optEnableDiableReasonCode">Input: Text field for reason to bne displayed to the crew. This will not be processed if `enableDisableReasonCodeExists` is false.</param>
		/// <param name="timeInSeconds">Input: timeInSeconds</param>
		/// <param name="retry">Input: retry</param>
		[UserCodeMethod]
		public static void ValidateDC_ENED_ByContent(
			string trainSeed, 
			string optTerritory, 
			string optEnableDisable = "1", 
			string optEnableDisableReason = "Crew logout by dispatcher", 
			bool enableDisableReasonCodeExists = true, 
			string optEnableDiableReasonCode = null,
			int timeInSeconds = 5, 
			bool retry = true
		) {
			Ranorex.Report.Info("TestStep", "Validating contents of DC-ENED");

			string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);

			MsgFilter msgFilters = new MsgFilter();

			msgFilters.AddFilter(trainSymbol, "SYMBOL");
			msgFilters.AddFilter(optTerritory, "DISPATCH_TERRITORY");
			msgFilters.AddFilter(optEnableDisable, "ENABLE_DISABLE");
			msgFilters.AddFilter(optEnableDisableReason, "ENABLE_DISABLE_REASON");

			if (enableDisableReasonCodeExists)
			{
				msgFilters.AddFilter(optEnableDiableReasonCode, "ENA_DISABLE_RSN_CD");
			} 
			else 
			{
				msgFilters.AddFilter_NotExistTag("ENA_DISABLE_RSN_CD");
			}

			string filters = msgFilters.FormatFilters();
			ReceivePTCFileCollection_NS.clearFilters();
			ReceivePTCFileCollection_NS.addValueToFilters(filters);
			ReceivePTCFileCollection_NS.validateDC_ENED_7(timeInSeconds, retry);
			ReceivePTCFileCollection_NS.clearFilters();
		}

		[UserCodeMethod]
		public static void ValidateDG_TAUT_ByContent(
			string authoritySeed, 
			string action, // this as a requirement might help to avoid false-positive scenarios with multiple dg-taut messages. 
			string optDistrict, 
			string optCrewAckRequired, 
			string optElectronicAckRequested, 
			string optCrewAckType,
			string optAdditionalFilters,
			bool validateNoCrewAckType = false,
			int timeInSeconds = 5, 
			bool retry = true
		) {
			Ranorex.Report.Info("TestStep", "Validating contents of DG-TAUT");

			string authorityNumber = NS_Authorities.GetAuthorityNumber(authoritySeed);

			MsgFilter msgFilters = new MsgFilter();

			msgFilters.AddFilter(authorityNumber, "H_TRACK_AUTHORITY_NUMBER");
			msgFilters.AddFilter(action, "ACTION");
			msgFilters.AddFilter(optDistrict, "DISTRICT_NAME");
			msgFilters.AddFilter(optCrewAckRequired, "CREW_ACK_REQUIRED");
			msgFilters.AddFilter(optElectronicAckRequested, "ELECTRONIC_ACK_REQUESTED");

			// This is an optional xml field that only shows up based on CDMS configuration. 
			if (validateNoCrewAckType)
			{
				msgFilters.AddFilter_NotExistTag("CREW_ACK_TYPE");
			} else {
				msgFilters.AddFilter(optCrewAckType, "CREW_ACK_TYPE");
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
			ReceivePTCFileCollection_NS.clearFilters();
			ReceivePTCFileCollection_NS.addValueToFilters(filters);
			ReceivePTCFileCollection_NS.validateDG_TAUT_7(timeInSeconds, retry);
			ReceivePTCFileCollection_NS.clearFilters();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="authoritySeed"></param>
		/// <param name="action"></param>
		/// <param name="district"></param>
		/// <param name="crewAckRequired"></param>
		/// <param name="electronicAckRequired"></param>
		/// <param name="optMessageVersion"></param>
		/// <param name="optMessageRevision"></param>
		/// <param name="timeInSeconds"></param>
		/// <param name="retry"></param>
		[UserCodeMethod]
		public static void ValidateDG_TAUT_WithAuthorityObj(string authoritySeed, string action, string district, bool crewAckRequired, bool electronicAckRequired, string optMessageVersion = "7", string optMessageRevision = "0", int timeInSeconds = 120, bool retry = true)
		{
			AuthorityObject authorityObj = NS_Authorities.GetAuthorityObject(authoritySeed);
			if (authorityObj.Equals(null))
			{
				Ranorex.Report.Failure("Authority for authority seed {"+authoritySeed+"} not found.");
				return;
			}
			Ranorex.Report.Info("TestStep", "Validating contents of DG-TAUT");
			MsgFilter msgFilters = new MsgFilter();
			action = action.ToLower();
			switch (action)
			{
				case "issue":
					msgFilters.AddFilter("0", "ACTION");
					break;
					
				case "void":
					msgFilters.AddFilter("1", "ACTION");
					break;
					
				case "rollup":
					msgFilters.AddFilter("2", "ACTION");
					break;
					
				case "extend":
					msgFilters.AddFilter("3", "ACTION");
					break;				
			}
			msgFilters.AddFilter("DG-TAUT", "MESSAGE_ID");
			msgFilters.AddFilter(optMessageVersion, "MESSAGE_VERSION");
			msgFilters.AddFilter(optMessageRevision, "MESSAGE_REVISION");
			msgFilters.AddFilter(district, "DISTRICT_NAME");
			msgFilters.AddFilter(crewAckRequired ? "Y" : "N", "CREW_ACK_REQUIRED");
			msgFilters.AddFilter(electronicAckRequired ? "Y" : "N", "ELECTRONIC_ACK_REQUESTED");
			msgFilters.AddFilter(authorityObj.authorityNumber, "H_TRACK_AUTHORITY_NUMBER");
			msgFilters.AddFilter(authorityObj.trackAuthorityType, "H_ADDRESSEE_TYPE");
			
			if (authorityObj.trackAuthorityType.Equals("TE"))
			{
				string trainId = NS_TrainID.GetTrainId(authorityObj.trainSeed);
				msgFilters.AddFilter(NS_TrainID.GetTrainSCAC(authorityObj.trainSeed), "H_SCAC");
				msgFilters.AddFilter(trainId.Substring(0, trainId.IndexOf(' ')), "H_SYMBOL");
				msgFilters.AddFilter(NS_TrainID.GetTrainSection(authorityObj.trainSeed), "H_SECTION");
                msgFilters.AddFilter(NS_TrainID.GetEngineInitial(authorityObj.trainSeed, authorityObj.engineSeed), "H_ENGINE_INITIAL");
                msgFilters.AddFilter(NS_TrainID.GetEngineNumber(authorityObj.trainSeed, authorityObj.engineSeed), "H_ENGINE_NUMBER");
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
			
			//**BOX 12** //TODO we need to make some changes to rwic so that we can make sure RWIC data is associated with one another other than just being rpesent in the message
			if (!authorityObj.box12RWIC1.Equals(""))
			{
				msgFilters.AddFilter("Y", "S12_PRESENCE");
				msgFilters.AddFilter(authorityObj.box12RWIC1, "S12_RWIC");
				msgFilters.AddFilter(authorityObj.box12Between1, "S12_BETWEEN_LOCATION");
             	msgFilters.AddFilter(authorityObj.box12And1, "S12_AND_LOCATION");
             	msgFilters.AddFilter(authorityObj.box12Track1, "S12_TRACK_TEXT");
             	//TODO-MAybe? Limit records????
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
			
			string filters = msgFilters.FormatFilters();

			ReceivePTCFileCollection_NS.clearFilters();
			ReceivePTCFileCollection_NS.addValueToFilters(filters);
			ReceivePTCFileCollection_NS.validateDG_TAUT_7(timeInSeconds, retry);
			ReceivePTCFileCollection_NS.clearFilters();
		}
		
		/// <summary>
		/// Validate DC-AK01
		/// </summary>
		/// <param name="optMessageId">Unique identifier of the message type of the original message that caused the return status response. Example: 'CD-CSGN'.</param>
		/// <param name="optResponseCode">Acknowledgment reponse code. Example: 'ACCEPT'. See PTC Message ICD for more information.</param>
		/// <param name="optTextField">Explanatory text.</param>
		/// <param name="optMessageVersion">Input:optMessageVersion</param>
		/// <param name="optMessageRevision">Input:optMessageRevision</param>
		/// <param name="timeInSeconds">Input:timeInSeconds</param>
		/// <param name="retry">Input:retry</param>
		[UserCodeMethod]
		public static void ValidateDC_AK01_ByContent(string optMessageId, string optResponseCode, string optTextField, string optMessageVersion = "7", string optMessageRevision = "0", int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DC-AK01");

			MsgFilter msgFilters = new MsgFilter();

			msgFilters.AddFilter(optMessageId, "ACK_MESSAGE_ID");
			msgFilters.AddFilter(optResponseCode, "RESPONSE_CODE");
			msgFilters.AddFilter(optTextField, "TEXT");
			msgFilters.AddFilter(optMessageVersion, "MESSAGE_VERSION");
			msgFilters.AddFilter(optMessageRevision, "MESSAGE_REVISION");
			
			string filters = msgFilters.FormatFilters();

			ReceivePTCFileCollection_NS.clearFilters();
			ReceivePTCFileCollection_NS.addValueToFilters(filters);
			ReceivePTCFileCollection_NS.validateDC_AK01_7(timeInSeconds, retry);
			ReceivePTCFileCollection_NS.clearFilters();
		}

		/// <summary>
		/// Validate DG-AK01
		/// </summary>
		/// <param name="optAckMessageId">Unique identifier of the message type of the original message that caused the return status response. Example: 'CD-CSGN'.</param>
		/// <param name="optResponseCode">Acknowledgment reponse code. Example: 'ACCEPT'. See PTC Message ICD for more information.</param>
		/// <param name="optTextField">Explanatory text.</param>
		/// <param name="optMessageVersion">Input:optMessageVersion</param>
		/// <param name="optMessageRevision">Input:optMessageRevision</param>
		/// <param name="timeInSeconds">Input:timeInSeconds</param>
		/// <param name="retry">Input:retry</param>
		[UserCodeMethod]
		public static void ValidateDG_AK01_ByContent(string optAckMessageId, string optResponseCode, string optTextField, string optMessageVersion = "7", string optMessageRevision = "0", int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DG-AK01");

			MsgFilter msgFilters = new MsgFilter();

			msgFilters.AddFilter(optAckMessageId, "ACK_MESSAGE_ID");
			msgFilters.AddFilter(optResponseCode, "RESPONSE_CODE");
			msgFilters.AddFilter(optTextField, "TEXT");
			msgFilters.AddFilter(optMessageVersion, "MESSAGE_VERSION");
			msgFilters.AddFilter(optMessageRevision, "MESSAGE_REVISION");
			
			string filters = msgFilters.FormatFilters();

			ReceivePTCFileCollection_NS.clearFilters();
			ReceivePTCFileCollection_NS.addValueToFilters(filters);
			ReceivePTCFileCollection_NS.validateDG_AK01_7(timeInSeconds, retry);
			ReceivePTCFileCollection_NS.clearFilters();
		}
		
//		[UserCodeMethod] we arent validating these
//		public static void ValidateGD_AK01_ByContent(string optAckMessageId, string optResponseCode, string optTextField, string optMessageVersion = "7", string optMessageRevision = "0", int timeInSeconds = 5, bool retry = true)
//		{
//			Ranorex.Report.Info("TestStep", "Validating contents of GD-AK01");
//
//			MsgFilter msgFilters = new MsgFilter();
//
//			msgFilters.AddFilter(optAckMessageId, "ACK_MESSAGE_ID");
//			msgFilters.AddFilter(optResponseCode, "RESPONSE_CODE");
//			msgFilters.AddFilter(optTextField, "TEXT");
//			msgFilters.AddFilter(optMessageVersion, "MESSAGE_VERSION");
//			msgFilters.AddFilter(optMessageRevision, "MESSAGE_REVISION");
//			
//			string filters = msgFilters.FormatFilters();
//
//			ReceivePTCFileCollection_NS.clearFilters();
//			ReceivePTCFileCollection_NS.addValueToFilters(filters);
//			ReceivePTCFileCollection_NS.validateGD_AK01_7(timeInSeconds, retry);
//			ReceivePTCFileCollection_NS.clearFilters();
//		}
		
		/// <summary>
		/// Validate DC-TLST
		/// </summary>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="engineSeed">Input:engineSeed</param>
		/// <param name="optTrainClearance">Input:optTrainClearance</param>
		/// <param name="timeInSeconds">Input:timeInSeconds</param>
		/// <param name="retry">Input:retry</param>
		[UserCodeMethod]
		public static void ValidateDC_TLST_ByContent(string trainSeed, string engineSeed, string optTrainClearance, int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DC-TLST");

			MsgFilter msgFilters = new MsgFilter();
			
			// TODO: This is sloppy. Shape it up when possible.
			string train_clearance = null;
			if (string.IsNullOrEmpty(optTrainClearance))
			{
				string trainId = NS_TrainID.GetTrainId(trainSeed);
				train_clearance = ADMSEnvironment.GetTrainClearanceNumber(trainId);
			}

			string engine_initial = NS_TrainID.GetEngineInitial(trainSeed, engineSeed);
			string engine_number = NS_TrainID.GetEngineNumber(trainSeed, engineSeed);

			msgFilters.AddFilter(train_clearance, "TRAIN_CLEARANCE_NUMBER");
			msgFilters.AddFilter(engine_initial, "ENGINE_INITIAL");
			msgFilters.AddFilter(engine_number, "ENGINE_NUMBER");

			string filters = msgFilters.FormatFilters();

			STE.Code_Utils.ReceivePTCFileCollection_NS.clearFilters();
			STE.Code_Utils.ReceivePTCFileCollection_NS.addValueToFilters(filters);
			STE.Code_Utils.ReceivePTCFileCollection_NS.validateDC_TLST_7(timeInSeconds, retry);
			STE.Code_Utils.ReceivePTCFileCollection_NS.clearFilters();
		}

		/// <summary>
		/// Validate DC-TCON
		/// </summary>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="engineSeed">Input:engineSeed</param>
		/// <param name="optTriggerType">Input:optTriggerType</param>
		/// <param name="timeInSeconds">Input:timeInSeconds</param>
		/// <param name="retry">Input:retry</param>
		[UserCodeMethod]
		public static void ValidateDC_TCON_ByContent(
			string trainSeed, 
			string engineSeed,
			string engineRecords,
			string optTriggerType, 
			string optPtcLocoOrientation,
			string optLoads, 
			string optEmpties,
			string optTonnage,
			string optLength,
			string optAxles,
			string optOperativeBrakes,
			string optTotalBrakingForce,
			int timeInSeconds = 5, 
			bool retry = true, 
			bool isPTCLocoOrientationPresent = true,
			bool isAxleCountPresent = true,
			bool isOperativeBrakesPresent = true,
			bool isTotalBrakingForcePresent = true
		)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DC-TCON");

			MsgFilter msg = new MsgFilter();

			string ptcEngineInitial = NS_TrainID.GetEngineInitial(trainSeed, engineSeed);
			string ptcEngineNumber = NS_TrainID.GetEngineNumber(trainSeed, engineSeed);

			msg.AddFilter(ptcEngineInitial, "PTC_ENGINE_INITIAL");
			msg.AddFilter(ptcEngineNumber, "PTC_ENGINE_NUMBER");
			
			if (isPTCLocoOrientationPresent)
			{
				msg.AddFilter(optPtcLocoOrientation, "PTC_LOCO_ORIENTATION");
			} else {
				msg.AddFilter_NotExistTag("PTC_LOCO_ORIENTATION");
			}

			if (isAxleCountPresent)
			{
				msg.AddFilter(optAxles, "AXLES");
			} else {
				msg.AddFilter_NotExistTag("AXLES");
			}

			if (isOperativeBrakesPresent)
			{
				msg.AddFilter(optOperativeBrakes, "OPERATIVE_BRAKES");
			} else {
				msg.AddFilter_NotExistTag("OPERATIVE_BRAKES");
			}

			if (isTotalBrakingForcePresent)
			{
				msg.AddFilter(optTotalBrakingForce, "TOTAL_BRAKING_FORCE");
			} else {
				msg.AddFilter_NotExistTag("TOTAL_BRAKING_FORCE");
			}
			
			msg.AddFilter(optTriggerType, "TRIGGER_TYPE");
			msg.AddFilter(optLoads, "LOADS");
			msg.AddFilter(optEmpties, "EMPTIES");
			msg.AddFilter(optTonnage, "TONNAGE");
			msg.AddFilter(optLength, "LENGTH");
			
			if (engineRecords != "")
			{
				string[] records = engineRecords.Split('|');
				//TODO handle multiples of 8*7
				if (((records.Length % 8) == 0 && !(records.Length % 7 == 0))) //TODO this is only a temporary solution as i dont have a bit more time, this needs to be able to handle sequential records that may have a mixture of horsepower and nonhorsepower records
					//or an alternative solution is to use 2 function calls with the different length records grouped, which is why im adding .* to the beggining and end
				{
					StringBuilder recordBuilder = new StringBuilder();
					for (int i =0; i<records.Length; i+=8)
					{
						recordBuilder.Append(".*<POSITION_IN_CONSIST>"+records[i]+"</POSITION_IN_CONSIST>");
						recordBuilder.Append("<ENGINE_INITIAL>"+records[i+1]+"</ENGINE_INITIAL>");
						recordBuilder.Append("<ENGINE_NUMBER>"+records[i+2]+"</ENGINE_NUMBER>");
						recordBuilder.Append("<ENGINE_STATUS>"+records[i+3]+"</ENGINE_STATUS>");
						recordBuilder.Append("<WEIGHT>"+records[i+4]+"</WEIGHT>");
						recordBuilder.Append("<ENGINE_LENGTH>"+records[i+5]+"</ENGINE_LENGTH>");
						recordBuilder.Append("<HORSEPOWER>"+records[i+6]+"</HORSEPOWER>");
						recordBuilder.Append("<DB_STATUS>"+records[i+7]+"</DB_STATUS>.*");
						msg.AddFilter(recordBuilder.ToString(), "ENGINE_RECORD");
						recordBuilder.Clear();
					}
					
				}
				else if ((records.Length % 7 == 0) && !(records.Length % 8 == 0)) //no dpu
				{
					StringBuilder recordBuilder = new StringBuilder();
					for (int i =0; i<records.Length; i+=7)
					{
						recordBuilder.Append(".*<POSITION_IN_CONSIST>"+records[i]+"</POSITION_IN_CONSIST>");
						recordBuilder.Append("<ENGINE_INITIAL>"+records[i+1]+"</ENGINE_INITIAL>");
						recordBuilder.Append("<ENGINE_NUMBER>"+records[i+2]+"</ENGINE_NUMBER>");
						recordBuilder.Append("<ENGINE_STATUS>"+records[i+3]+"</ENGINE_STATUS>");
						recordBuilder.Append("<WEIGHT>"+records[i+4]+"</WEIGHT>");
						recordBuilder.Append("<ENGINE_LENGTH>"+records[i+5]+"</ENGINE_LENGTH>");
						recordBuilder.Append("<HORSEPOWER>"+records[i+6]+"</HORSEPOWER>.*");
						msg.AddFilter(recordBuilder.ToString(), "ENGINE_RECORD");
						recordBuilder.Clear();
					}
				}
				else
				{
					Report.Error("Engine Record length != 7 or 8");
				}
				
			}

			string filters = msg.FormatFilters();

			//ReceivePTCFileCollection_NS.clearFilters();
			ReceivePTCFileCollection_NS.addValueToFilters(filters);
			ReceivePTCFileCollection_NS.validateDC_TCON_7(timeInSeconds, retry);
			ReceivePTCFileCollection_NS.clearFilters();
		}
		

		/// <summary>
		/// Validate DC-TRDL
		/// </summary>
		/// <param name="optDistrict">Input:optDistrict</param>
		/// <param name="optMessageVersion">Input:optMessageVersion</param>
		/// <param name="optMessageRevision">Input:optMessageRevision</param>
		/// <param name="timeInSeconds">Input:timeInSeconds</param>
		/// <param name="retry">Input:retry</param>
		[UserCodeMethod]
		public static void ValidateDC_TRDL_ByContent(string optDistrict, string optMessageVersion = "7", string optMessageRevision = "0", int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DC-TRDL");

			MsgFilter msg = new MsgFilter();
			msg.AddFilter(optDistrict, "DISTRICT");
			msg.AddFilter(optMessageVersion, "MESSAGE_VERSION");
			msg.AddFilter(optMessageRevision, "MESSAGE_REVISION");

			string filters = msg.FormatFilters();
			ReceivePTCFileCollection_NS.clearFilters();
			ReceivePTCFileCollection_NS.addValueToFilters(filters);
			ReceivePTCFileCollection_NS.validateDC_TRDL_7(timeInSeconds, retry);
			ReceivePTCFileCollection_NS.clearFilters();
		}

		/// <summary>
		/// Validate DG-BULI 7
		/// </summary>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="bulletinSeed">Input:bulletinSeed</param>
		/// <param name="optMessageVersion">Input:optMessageVersion</param>
		/// <param name="optMessageRevision">Input:optMessageRevision</param>
		/// <param name="optAction">Input:optAction</param>
		/// <param name="optRouteCount">Input:optRouteCount</param>
		/// <param name="optDistrict">Input:optDistrict</param>
		/// <param name="timeInSeconds">Input:timeInSeconds</param>
		/// <param name="retry">Input:retry</param>
		[UserCodeMethod]
		public static void ValidateDG_BULI7_ByContent(string bulletinSeed, string optMessageVersion = "7", string optMessageRevision = "0", string optAction = "", string optRouteCount = "", string optDistrict = "", string optSpeedRestrictCount = "", string optRouteDistrictCount = "", string optRouteDistrictName = "", string optCrossingDistrictCount = "", string optCrossingId = "", string optCrossingDistrictName = "", int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DG-BULI");
			MsgFilter msg = new MsgFilter();
			
			string bulletin_item_number = NS_Bulletin.GetBulletinNumber(bulletinSeed);

			msg.AddFilter(bulletin_item_number, "BULLETIN_ITEM_NUMBER");
			msg.AddFilter(optMessageVersion, "MESSAGE_VERSION");
			msg.AddFilter(optMessageRevision, "MESSAGE_REVISION");
			msg.AddFilter(optAction, "ACTION");
			msg.AddFilter(optRouteCount, "ROUTE_COUNT");
			msg.AddFilter(optSpeedRestrictCount, "SPEED_RESTRICT_CNT");
			msg.AddFilter(optRouteDistrictCount, "ROUTE_DISTRICT_COUNT");
			msg.AddFilter(optRouteDistrictName, "ROUTE_DISTRICT_NAME");
			msg.AddFilter(optCrossingDistrictCount, "CROSSING_DISTRICT_COUNT");
			msg.AddFilter(optCrossingDistrictName, "CROSSING_DISTRICT_NAME");
			msg.AddFilter(optCrossingId, "CROSSING_ID");
			msg.AddFilter(optDistrict, "DISTRICT_NAME");
			msg.AddFilter("Bulletin Item Number: "+bulletin_item_number, "TEXT");

			string filters = msg.FormatFilters();
			ReceivePTCFileCollection_NS.addValueToFilters(filters);
			ReceivePTCFileCollection_NS.validateDG_BULI_7(timeInSeconds, retry);
			ReceivePTCFileCollection_NS.clearFilters();
			
		}
		
		/// <summary>
		/// Validate DG-BULI 3
		/// </summary>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="bulletinSeed">Input:bulletinSeed</param>
		/// <param name="optMessageVersion">Input:optMessageVersion</param>
		/// <param name="optMessageRevision">Input:optMessageRevision</param>
		/// <param name="timeInSeconds">Input:timeInSeconds</param>
		/// <param name="retry">Input:retry</param>
		[UserCodeMethod]
		public static void ValidateDG_BULI3_ByContent(string bulletinSeed, string extraFilters, int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DG-BULI");
			MsgFilter msg = new MsgFilter();
			
			string bulletin_item_number = NS_Bulletin.GetBulletinNumber(bulletinSeed);

			msg.AddFilter(bulletin_item_number, "BULLETIN_ITEM_NUMBER");
			msg.AddFilter("Bulletin Item Number: "+bulletin_item_number, "TEXT");

			string filters = msg.FormatFilters();
			ReceivePTCFileCollection_NS.addValueToFilters(filters);
			ReceivePTCFileCollection_NS.addValueToFilters(extraFilters);
			ReceivePTCFileCollection_NS.validateDG_BULI_3(timeInSeconds, retry);
			ReceivePTCFileCollection_NS.clearFilters();
			
		}
      
      /// <summary>
		/// Validates did not receive DG-BULI
		/// </summary>
		/// <param name="bulletinSeed">Input:bulletinSeed</param>
		/// <param name="optMessageVersion">Input:optMessageVersion</param>
		/// <param name="optMessageRevision">Input:optMessageRevision</param>
		/// <param name="timeInSeconds">Input:timeInSeconds</param>
		/// <param name="retry">Input:retry</param>
		[UserCodeMethod]
		public static void ValidateNoDG_BULI_ByContent(string bulletinSeed, string optMessageVersion = "7", string optMessageRevision = "0", string action = "0", int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DG-BULI");
			MsgFilter msg = new MsgFilter();
			
			string bulletin_item_number = NS_Bulletin.GetBulletinNumber(bulletinSeed);

			msg.AddFilter(bulletin_item_number, "BULLETIN_ITEM_NUMBER");
			msg.AddFilter(action, "ACTION");
			msg.AddFilter(optMessageVersion, "MESSAGE_VERSION");
			msg.AddFilter(optMessageRevision, "MESSAGE_REVISION");

			string filters = msg.FormatFilters();
			ReceivePTCFileCollection_NS.clearFilters();
			ReceivePTCFileCollection_NS.addValueToFilters(filters);
			ReceivePTCFileCollection_NS.validateNoDG_BULI_7(timeInSeconds, retry);
			ReceivePTCFileCollection_NS.clearFilters();
			
		}

		[UserCodeMethod]
		public static void ValidateNoDC_TCON_ByContent(string trainSeed, int timeInSeconds = 5, bool retry = true)
		{
			// TODO: Add some additional filters
			string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
			
			Ranorex.Report.Info("TestStep", string.Format("Validating that no DC-TCON received for train '{0}'", trainSymbol));
			MsgFilter msg = new MsgFilter();

			msg.AddFilter(trainSymbol, "SYMBOL");
			string filters = msg.FormatFilters();

			ReceivePTCFileCollection_NS.clearFilters();
			ReceivePTCFileCollection_NS.addValueToFilters(filters);
			ReceivePTCFileCollection_NS.validateNoDC_TCON_7(timeInSeconds, retry);
			ReceivePTCFileCollection_NS.clearFilters();
		}
		
		[UserCodeMethod]
		public static void ValidateNoDG_AK01_ByContent(string msgId, int timeInSeconds = 5, bool retry = true)
		{
			
			Ranorex.Report.Info("TestStep", string.Format("Validating that no DG-AK01 received for msgId '{0}'", msgId));
			MsgFilter msg = new MsgFilter();

			msg.AddFilter(msgId, "ACK_MESSAGE_ID");
			string filters = msg.FormatFilters();

			ReceivePTCFileCollection_NS.clearFilters();
			ReceivePTCFileCollection_NS.addValueToFilters(filters);
			ReceivePTCFileCollection_NS.ValidateNoDG_AK01_7(timeInSeconds, retry);
			ReceivePTCFileCollection_NS.clearFilters();
		}
		
		[UserCodeMethod]
		public static void ValidateNoDC_AK01_ByContent(string msgId, int timeInSeconds = 5, bool retry = true)
		{
			
			Ranorex.Report.Info("TestStep", string.Format("Validating that no DC-AK01 received for msgId '{0}'", msgId));
			MsgFilter msg = new MsgFilter();

			msg.AddFilter(msgId, "ACK_MESSAGE_ID");
			string filters = msg.FormatFilters();

			ReceivePTCFileCollection_NS.clearFilters();
			ReceivePTCFileCollection_NS.addValueToFilters(filters);
			ReceivePTCFileCollection_NS.ValidateNoDC_AK01_7(timeInSeconds, retry);
			ReceivePTCFileCollection_NS.clearFilters();
		}

		/// <summary>
		/// Validate DG-VDBI
		/// </summary>
		/// <param name="bulletinSeed">Input:bulletinSeed</param>
		/// <param name="optDistrict">Input:optDistrict</param>
		/// <param name="optMessageVersion">Input:optMessageVersion</param>
		/// <param name="optMessageRevision">Input:optMessageRevision</param>
		/// <param name="timeInSeconds">Input:timeInSeconds</param>
		/// <param name="retry">Input:retry</param>
		[UserCodeMethod]
		public static void ValidateDG_VDBI_ByContent(string bulletinSeed, string optDistrict, string optMessageVersion = "7", string optMessageRevision = "0", int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DG-VDBI");
			MsgFilter msg = new MsgFilter();
			
			string bulletin_item_number = NS_Bulletin.GetBulletinNumber(bulletinSeed);

			msg.AddFilter(bulletin_item_number, "BULLETIN_ITEM_NUMBER");
			msg.AddFilter(optDistrict, "DISTRICT_NAME");
			msg.AddFilter(optMessageVersion, "MESSAGE_VERSION");
			msg.AddFilter(optMessageRevision, "MESSAGE_REVISION");
			msg.AddFilter_NotExistTag("TEXT");

			string filters = msg.FormatFilters();
			ReceivePTCFileCollection_NS.addValueToFilters(filters);
			ReceivePTCFileCollection_NS.validateDG_VDBI_7(timeInSeconds, retry);
			ReceivePTCFileCollection_NS.clearFilters();
		}
		
		[UserCodeMethod]
		public static void ValidateDC_MESS(string trainSeed, string bulletinSeed, int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DC-MESS");

			MsgFilter msgFilters = new MsgFilter();
			
			string symbol = NS_TrainID.GetTrainSymbol(trainSeed);
			string bulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
			string bulletinType = NS_Bulletin.GetBulletinType(bulletinSeed);

			msgFilters.AddFilter(symbol, "SYMBOL");
			msgFilters.AddFilter(bulletinNumber, "BULLETIN_ITEM_NUMBER");
			msgFilters.AddFilter(bulletinType, "BULLETIN_ITEM_TYPE");
			msgFilters.AddFilter("Bulletin Item Number: "+bulletinNumber, "TEXT");
			
			string filters = msgFilters.FormatFilters();

			STE.Code_Utils.ReceivePTCFileCollection_NS.clearFilters();
			STE.Code_Utils.ReceivePTCFileCollection_NS.addValueToFilters(filters);
			STE.Code_Utils.ReceivePTCFileCollection_NS.validateDC_MESS_7(timeInSeconds, retry);
			STE.Code_Utils.ReceivePTCFileCollection_NS.clearFilters();
		}

		[UserCodeMethod]
		public static void ValidateGenericMessage_PTC_SingleFilter(
			string messageType, int messageVersion, string xmlElement, string xmlValue, 
			bool xmlElementExists = true, int timeInSeconds = 5, bool retry = true
		)
		{
			// This is a POC. Please refrain from change requests at this time. 

			MsgFilter msg = new MsgFilter();
			if (xmlElementExists)
			{
				Report.Info("TestStep", string.Format("Validating that '{0}' is received, with the following xml element: '{1}'", messageType, xmlElement));
				msg.AddFilter(xmlVal: xmlValue, xmlAttr: xmlElement);
			} else {
				Report.Info("TestStep", string.Format("Validating that '{0}' is received, without the following xml element: '{1}'", messageType, xmlElement));
				msg.AddFilter_NotExistTag(xmlAttr: xmlElement);
			}

			string file = null;
			file = STE.Code_Utils.messages.SteMessageFileReader.GetFilteredFile(
				messageType: messageType.ToUpper(), version: messageVersion.ToString(), filters: msg.GetFiltersAsArray(), timeInSeconds: timeInSeconds
			);

			// TODO: Utilize bool: retry
			System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
			while (file == null && System.DateTime.Now < future)
			{
				file = STE.Code_Utils.messages.SteMessageFileReader.GetFilteredFile(
					messageType: messageType.ToUpper(), version: messageVersion.ToString(), filters: msg.GetFiltersAsArray(), timeInSeconds: timeInSeconds
				);
			}

			bool success = (file != null);
			string resultMessage = string.Format(
				"'{0}' message V-{1} found in a {2} second time span: {3}", 
				messageType, messageVersion.ToString(), timeInSeconds.ToString(), success.ToString()
			);

			if (success)
			{
				Report.Success("Validation", resultMessage);
			} else {
				Report.Failure("Validation", resultMessage);
			}
		}

		[UserCodeMethod]
        public static void ValidateNoPtcMessage(string messageType, int messageVersion, string filters, int timeInSeconds = 5, bool retry = true)
        {
            // This is a POC. Please refrain from change requests at this time. 
			
			string[] msgFilters = filters.Split('|');
            
            string file = null;
            file = STE.Code_Utils.messages.SteMessageFileReader.GetFilteredFile(
                messageType: messageType.ToUpper(), version: messageVersion.ToString(), filters: msgFilters, timeInSeconds: timeInSeconds
            );

            // TODO: Utilize bool: retry
			System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
			while (file == null && System.DateTime.Now < future)
			{
				file = STE.Code_Utils.messages.SteMessageFileReader.GetFilteredFile(
                    messageType: messageType.ToUpper(), version: messageVersion.ToString(), filters: msgFilters, timeInSeconds: timeInSeconds
                );
			}

            bool success = (file == null);
			string resultMessage = string.Format(
				"'{0}' message V-{1} found in a {2} second time span: {3}", 
				messageType, messageVersion.ToString(), timeInSeconds.ToString(), success.ToString()
			);

			if (success)
			{
				Report.Success("Validation", resultMessage);
			} else {
				Report.Failure("Validation", resultMessage);
			}
        }
		
		/// <summary>
		/// Validate the DC-VDME message sent on void of a bulletin to the train
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="bulletinSeed"></param>
		/// <param name="timeInSeconds"></param>
		/// <param name="retry"></param>
		[UserCodeMethod]
		public static void ValidateDC_VDME(string trainSeed, string bulletinSeed, int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DC-VDME");

			MsgFilter msgFilters = new MsgFilter();
			
			string symbol = NS_TrainID.GetTrainSymbol(trainSeed);
			string section = NS_TrainID.GetTrainSection(trainSeed);
			string originDate = NS_TrainID.getOriginDate(trainSeed);
			string bulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);


			msgFilters.AddFilter(symbol, "SYMBOL");
			msgFilters.AddFilter(section, "SECTION");
			msgFilters.AddFilter(originDate, "ORIGIN_DATE");
			msgFilters.AddFilter(bulletinNumber, "BULLETIN_ITEM_NUMBER");
			msgFilters.AddFilter_NotExistTag("TEXT");
			
			string filters = msgFilters.FormatFilters();

			STE.Code_Utils.ReceivePTCFileCollection_NS.clearFilters();
			STE.Code_Utils.ReceivePTCFileCollection_NS.addValueToFilters(filters);
			STE.Code_Utils.ReceivePTCFileCollection_NS.validateDC_VDME_7(timeInSeconds, retry);
			STE.Code_Utils.ReceivePTCFileCollection_NS.clearFilters();
		}
		
		/// <summary>
		/// Validate the DC-ASBI message sent to a train on relay of bulletin
		/// </summary>
		/// <param name="trainSeed">Seed for Train</param>
		/// <param name="bulletinSeed">Bulletin inside ASBI</param>
		/// <param name="optCrewAckRequired">Whether Crew Ack is Required</param>
		/// <param name="optElectronicAckRequested">Whether Electronic Ack is Requested</param>
		/// <param name="timeInSeconds"></param>
		/// <param name="retry"></param>
		[UserCodeMethod]
		public static void ValidateDC_ASBI_ByContent(string trainSeed, string bulletinSeed, string optCrewAckRequired, string optElectronicAckRequested, int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DC-ASBI");

			MsgFilter msgFilters = new MsgFilter();
			
			string symbol = NS_TrainID.GetTrainSymbol(trainSeed);
			string section = NS_TrainID.GetTrainSection(trainSeed);
			string originDate = NS_TrainID.getOriginDate(trainSeed);
			string bulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
			
			msgFilters.AddFilter(symbol, "SYMBOL");
			msgFilters.AddFilter(section, "SECTION");
			msgFilters.AddFilter(originDate, "ORIGIN_DATE");
			msgFilters.AddFilter(bulletinNumber, "BULLETIN_ITEM_NUMBER");
			msgFilters.AddFilter(optCrewAckRequired, "CREW_ACK_REQUIRED");
			msgFilters.AddFilter(optElectronicAckRequested, "ELECTRONIC_ACK_REQUESTED");
			
			string filters = msgFilters.FormatFilters();
			STE.Code_Utils.ReceivePTCFileCollection_NS.addValueToFilters(filters);
			STE.Code_Utils.ReceivePTCFileCollection_NS.validateDC_ASBI_7(timeInSeconds, retry);
			STE.Code_Utils.ReceivePTCFileCollection_NS.clearFilters();
		}
		
		/// <summary>
		/// Validate DG-UDIE
		/// </summary>
		/// <param name="reason_code">Input:reason code ex.DTCENA</param>
		/// <param name="timeInSeconds">Input:timeInSeconds</param>
		/// <param name="retry">Input:retry</param>
		[UserCodeMethod]
		public static void ValidateDG_UDIE_ByContent(string reason_code, int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DG-UDIE");
			MsgFilter msgFilters = new MsgFilter();
			msgFilters.AddFilter(reason_code, "REASON_CODE");
			
			string filters = msgFilters.FormatFilters();
			
			STE.Code_Utils.ReceivePTCFileCollection_NS.clearFilters();
			STE.Code_Utils.ReceivePTCFileCollection_NS.addValueToFilters(filters);
			STE.Code_Utils.ReceivePTCFileCollection_NS.validateDG_UDIE_7(timeInSeconds, retry);
			STE.Code_Utils.ReceivePTCFileCollection_NS.clearFilters();
		}
		
		
		[UserCodeMethod]
		public static void ValidateDC_DSSR_ByContent(string cadInterfaceStatus, string suspendTimeWindow, int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DC-DSSR");

			MsgFilter msgFilters = new MsgFilter();
			
			msgFilters.AddFilter(cadInterfaceStatus, "CAD_INTERFACE_STATUS");
			msgFilters.AddFilter(suspendTimeWindow, "SUSPEND_TIME_WINDOW");
			
			string filters = msgFilters.FormatFilters();
			STE.Code_Utils.ReceivePTCFileCollection_NS.addValueToFilters(filters);
			STE.Code_Utils.ReceivePTCFileCollection_NS.validateDC_DSSR_7(timeInSeconds, retry);
			STE.Code_Utils.ReceivePTCFileCollection_NS.clearFilters();
		}
		
		[UserCodeMethod]
		public static void ValidateDG_DSSR_ByContent(string cadInterfaceStatus, string suspendTimeWindow, int timeInSeconds = 5, bool retry = true)
		{
			Ranorex.Report.Info("TestStep", "Validating contents of DG-DSSR");

			MsgFilter msgFilters = new MsgFilter();

			msgFilters.AddFilter(cadInterfaceStatus, "CAD_INTERFACE_STATUS");
			msgFilters.AddFilter(suspendTimeWindow, "SUSPEND_TIME_WINDOW");
			
			
			string filters = msgFilters.FormatFilters();
			STE.Code_Utils.ReceivePTCFileCollection_NS.addValueToFilters(filters);
			STE.Code_Utils.ReceivePTCFileCollection_NS.validateDG_DSSR_7(timeInSeconds, retry);
			STE.Code_Utils.ReceivePTCFileCollection_NS.clearFilters();
		}
	}
}