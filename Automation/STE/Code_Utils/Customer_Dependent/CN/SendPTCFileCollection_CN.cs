/*
 * Created by Ranorex
 * User: r07000021
 * Date: 1/17/2018
 * Time: 9:46 AM
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

namespace STE.Code_Utils.messages
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class SendPTCFileCollection_CN
    {
        // You can use the "Insert New User Code Method" functionality from the context menu,
        // to add a new method with the attribute [UserCodeMethod].
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_AK01_2(string header_district_name, string header_district_scac, string header_user_id, string ack_message_id, string ack_sequence_number, 
                                           string response_code, string text)
        {
            STE.Code_Utils.messages.PTC.PTC_CD_AK01_2.createCD_AK01_2(header_district_name, header_district_scac, header_user_id, ack_message_id, ack_sequence_number, response_code, text);
        }
        
        
        [UserCodeMethod]
        public static void createGD_BUDS_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, 
        	                               string header_message_revision, string header_source_sys, string header_destination_sys, string header_district_name, 
        	                               string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, 
        	                               string header_htrn_section, string header_htrn_origin_date, string header_heng_engine_initial, string header_heng_engine_number, 
        	                               string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string bulletin_item_number, 
        	                               string action, string affected_trains, string train_record, string hostname)
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
        	
            STE.Code_Utils.messages.PTC.PTC_GD_BUDS_7.createGD_BUDS_7(header_event_date, header_event_time, header_sequence_number, header_message_version, 
        	                                                          header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, 
        	                                                          header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, 
        	                                                          header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, 
        	                                                          header_uid2_type, header_uid2, bulletin_item_number, action, affected_trains, train_record, hostname);
        }
        

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_AK01_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, 
                                           string header_message_revision, string header_source_sys, string header_destination_sys, string header_district_name, string header_district_scac,
                                           string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, string header_htrn_section,
                                           string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1,
                                           string header_uid2_type, string header_uid2, string content_ack_message_id, string content_ack_sequence_number, string content_response_code,
                                           string content_text, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
            
            
            STE.Code_Utils.messages.PTC.PTC_CD_AK01_7.createCD_AK01_7(header_event_date, header_event_time, header_sequence_number, header_message_version, 
        	                                                          header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, 
        	                                                          header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, 
        	                                                          header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, 
        	                                                          header_uid2_type, header_uid2, content_ack_message_id, content_ack_sequence_number, content_response_code, 
        	                                                          content_text, hostname);

        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_BARS_2(string header_district_name, string header_district_scac, string header_user_id, string bulletin_item_number, string scac, string symbol, 
                                           string section, string crew_ack_required, string electronic_ack_requested, string status_code, string engine_initial, string engine_number)
        {
            STE.Code_Utils.messages.PTC.PTC_CD_BARS_2.createCD_BARS_2(header_district_name, header_district_scac, header_user_id, bulletin_item_number, scac, symbol, section, crew_ack_required, 
                                                       electronic_ack_requested, status_code, engine_initial, engine_number);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_BARS_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, 
                                           string header_htrn_symbol, string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, 
                                           string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_bulletin_item_number, string content_scac, string content_symbol, 
                                           string content_section, string content_origin_date_offset_days, string content_crew_ack_required, string content_electronic_ack_requested, string content_status_code, 
                                           string content_engine_initial, string content_engine_number, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
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
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_CABI_2(string header_district_name, string header_district_scac, string header_user_id, string scac, string symbol, string section, string bulletin_item_number, string crew_ack_type)
        {
            STE.Code_Utils.messages.PTC.PTC_CD_CABI_2.createCD_CABI_2(header_district_name, header_district_scac, header_user_id, scac, symbol, section, bulletin_item_number, crew_ack_type);
        }

        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_CABI_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, 
                                           string header_htrn_symbol, string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, 
                                           string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac, string content_symbol, string content_section, string content_origin_date_offset_days, 
                                           string content_bulletin_item_number, string content_crew_ack_type, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
        	}
        	
        	STE.Code_Utils.messages.PTC.PTC_CD_CABI_7.createCD_CABI_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, 
        	                                                          header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, 
        	                                                          header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, 
        	                                                          header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, content_section, content_origin_date, content_bulletin_item_number, 
        	                                                          content_crew_ack_type, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_CABV_2(string header_district_name, string header_district_scac, string header_user_id, string scac, string symbol, string section, string bulletin_item_number)
        {
            STE.Code_Utils.messages.PTC.PTC_CD_CABV_2.createCD_CABV_2(header_district_name, header_district_scac, header_user_id, scac, symbol, section, bulletin_item_number);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_CABV_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, 
                                           string header_htrn_symbol, string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, 
                                           string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac, string content_symbol, string content_section, string content_origin_date_offset_days, 
                                           string content_bulletin_item_number, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
        	}
        	
        	STE.Code_Utils.messages.PTC.PTC_CD_CABV_7.createCD_CABV_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, 
        	                                                          header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, 
        	                                                          header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, 
        	                                                          header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, content_section, content_origin_date, content_bulletin_item_number, 
        	                                                          hostname);
        }


        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_CSGF_2(string header_district_name, string header_district_scac, string header_user_id, string scac, string symbol, string section, string signoff_type)
        {
            STE.Code_Utils.messages.PTC.PTC_CD_CSGF_2.createCD_CSGF_2(header_district_name, header_district_scac, header_user_id, scac, symbol, section, signoff_type);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_CSGF_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, 
                                           string header_htrn_symbol, string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, 
                                           string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac, string content_symbol, string content_section, string content_origin_date_offset_days, 
                                           string content_signoff_type, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_CD_CSGF_7.createCD_CSGF_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys,
        	                                                          header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, 
        	                                                          header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, 
        	                                                          content_section, content_origin_date, content_signoff_type, hostname);
        }
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_CSGN_2(string header_district_name, string header_district_scac, string header_user_id, string scac, string symbol, string section, string engine_initial, 
                                           string engine_number, string employee_id, string employee_first, string employee_middle, string employee_last)
        {
            STE.Code_Utils.messages.PTC.PTC_CD_CSGN_2.createCD_CSGN_2(header_district_name, header_district_scac, header_user_id, scac, symbol, section, engine_initial, engine_number, employee_id, 
                                                       employee_first, employee_middle, employee_last);
        }
        
         /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_CSGN_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol,
                                           string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, 
                                           string header_uid2, string content_scac, string content_symbol, string content_section, string content_origin_date_offset_days, string content_engine_initial, string content_engine_number, string content_employee_id, 
                                           string content_employee_first, string content_employee_middle, string content_employee_last, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_CD_CSGN_7.createCD_CSGN_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, content_section, content_origin_date, content_engine_initial, 
        	                                                          content_engine_number, content_employee_id, content_employee_first, content_employee_middle, content_employee_last, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_EA01_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, 
                                           string header_htrn_symbol, string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, 
                                           string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac, string content_symbol, string content_section, 
                                           string content_origin_date_offset_days, string content_engine_initial, string content_engine_number, string content_application_date_offset_days, string content_application_time_offset_minutes, 
                                           string content_target_type, string content_target_description,  string content_speed, string content_direction, string content_he_district, string content_he_track, string content_he_milepost, 
                                           string content_re_district, string content_re_track, string content_re_milepost, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
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

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_EBAR_4(string header_district_name, string header_district_scac, string header_user_id, string scac, string symbol, string section, string engine_initial, string engine_number, string application_time, 
                                           string application_type, string speed, string direction, string he_district, string he_track, string he_milepost, string re_district, string re_track, string re_milepost)
        {
            STE.Code_Utils.messages.PTC.PTC_CD_EBAR_4.createCD_EBAR_4(header_district_name, header_district_scac, header_user_id, scac, symbol, section, engine_initial, engine_number, application_time, application_type, speed, direction, he_district, 
                                                       he_track, he_milepost, re_district, re_track, re_milepost);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_EBAR_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, 
        	                                                          string header_message_revision, string header_source_sys, string header_destination_sys, string header_district_name, 
        	                                                          string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, 
        	                                                          string header_htrn_symbol, string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, 
        	                                                          string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac, 
        	                                                          string content_symbol, string content_section, string content_origin_date_offset_days, string content_engine_initial, string content_engine_number, 
        	                                                          string content_application_date_offset_days, string content_application_time_offset_minutes, string content_application_type, string content_speed, 
        	                                                          string content_direction, string content_he_district, string content_he_track, string content_he_milepost, string content_re_district, 
        	                                                          string content_re_track, string content_re_milepost, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
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

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_EEDS_2(string message_version, string header_district_name, string header_district_scac, string header_user_id, string scac, string symbol, string section, string enable_disable, string status_code, string engine_initial, 
                                           string engine_number, string dispatch_territory)
        {
            STE.Code_Utils.messages.PTC.PTC_CD_EEDS_2.createCD_EEDS_2(message_version,header_district_name, header_district_scac, header_user_id, scac, symbol, section, enable_disable, status_code, engine_initial, engine_number, dispatch_territory);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_EEDS_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, string header_destination_sys, string header_district_name, 
                                           string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, 
                                           string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac, string content_symbol, string content_section, string content_origin_date_offset_days, string content_enable_disable, 
                                           string content_ena_disable_rsn_cd, string content_enable_disable_reason, string content_status_code, string content_engine_initial, string content_engine_number, string content_dispatch_territory, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_CD_EEDS_7.createCD_EEDS_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, content_section, content_origin_date, content_enable_disable, 
        	                                                          content_ena_disable_rsn_cd, content_enable_disable_reason, content_status_code, content_engine_initial, content_engine_number, content_dispatch_territory, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_LOSR_5(string header_district_name, string header_district_scac, string header_user_id, string engine_initial, string engine_number, string scac, string symbol, string section, string train_clearance_number, 
                                           string trigger_type, string loco_state_summary, string loco_state, string loco_state_time)
        {
            STE.Code_Utils.messages.PTC.PTC_CD_LOSR_5.createCD_LOSR_5(header_district_name, header_district_scac, header_user_id, train_clearance_number, trigger_type, scac, symbol, section, engine_initial, engine_number, loco_state_summary, loco_state, 
                                                       loco_state_time);
        }

          /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_LOSR_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, 
                                           string header_message_revision, string header_source_sys, string header_destination_sys, string header_district_name, string header_district_scac, 
                                           string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, string header_htrn_section, 
                                           string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, 
                                           string header_uid1, string header_uid2_type, string header_uid2, string content_engine_initial, string content_engine_number, string content_scac, 
                                           string content_symbol, string content_section, string content_origin_date_offset_days, string content_train_clearance_number, string content_trigger_type, 
                                           string content_prev_loco_st_summ, string content_prev_loco_state, string content_loco_state_summary, string content_loco_state, 
                                           string content_loco_state_date_offset_days, string content_loco_state_time_offset_minutes, string content_state_district, string content_state_milepost, string content_state_track, 
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
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
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_MEDS_2(string header_district_name, string header_district_scac, string header_user_id, string bulletin_item_number, string scac, string symbol, string section, string status_code, string engine_initial, string engine_number)
        {
            STE.Code_Utils.messages.PTC.PTC_CD_MEDS_2.createCD_MEDS_2(header_district_name, header_district_scac, header_user_id, bulletin_item_number, scac, symbol, section, status_code, engine_initial, engine_number);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
//        [UserCodeMethod]
//        public static void createCD_MEDS_7(string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, string header_htrn_section, 
//                                           string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string bulletin_item_number, string scac, 
//                                           string symbol, string section, string status_code, string engine_initial, string engine_number)
//        {
//            STE.Code_Utils.messages.PTC.PTC_CD_MEDS_7.createCD_MEDS_7(header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_heng_engine_initial, 
//                                                       header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, bulletin_item_number, scac, symbol, section, status_code, engine_initial, engine_number);
//        }
        
		/// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_MEDS_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, string header_destination_sys, 
                                           string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, string header_htrn_section, string header_htrn_origin_date_offset_days, 
                                           string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_bulletin_item_number, string content_scac, string content_symbol, 
                                           string content_section, string content_origin_date_offset_days, string content_status_code, string content_engine_initial, string content_engine_number, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_CD_MEDS_7.createCD_MEDS_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_bulletin_item_number, content_scac, content_symbol, content_section, 
        	                                                          content_origin_date, content_status_code, content_engine_initial, content_engine_number, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_RABI_2(string header_district_name, string header_district_scac, string header_user_id, string scac, string symbol, string section, string train_clearance_number, string engine_initial, string engine_number, string request_type)
        {
            STE.Code_Utils.messages.PTC.PTC_CD_RABI_2.createCD_RABI_2(header_district_name, header_district_scac, header_user_id, scac, symbol, section, train_clearance_number, engine_initial, engine_number, request_type);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
//        [UserCodeMethod]
//        public static void createCD_RABI_7(string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, string header_htrn_section, 
//                                           string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string scac, string symbol, 
//                                           string section, string train_clearance_number, string engine_initial, string engine_number, string request_type)
//        {
//            STE.Code_Utils.messages.PTC.PTC_CD_RABI_7.createCD_RABI_7(header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_heng_engine_initial, 
//                                                       header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, scac, symbol, section, train_clearance_number, engine_initial, engine_number, request_type);
//        }

        
         /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_RABI_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, 
                                           string header_source_sys, string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, 
                                           string header_htrn_scac, string header_htrn_symbol, string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, 
                                           string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac, string content_symbol, 
                                           string content_section, string content_origin_date_offset_days, string content_train_clearance_number, string content_engine_initial, string content_engine_number, 
                                           string content_request_type, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_CD_RABI_7.createCD_RABI_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, 
        	                                                          header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, 
        	                                                          header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, 
        	                                                          header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, 
        	                                                          content_scac, content_symbol, content_section, content_origin_date, content_train_clearance_number, content_engine_initial, 
        	                                                          content_engine_number, content_request_type, hostname);
        }
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_RCON_2(string header_district_name, string header_district_scac, string header_user_id, string scac, string symbol, string section)
        {
            STE.Code_Utils.messages.PTC.PTC_CD_RCON_2.createCD_RCON_2(header_district_name, header_district_scac, header_user_id, scac, symbol, section);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_RCON_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, string header_destination_sys, string header_district_name, 
                                           string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, 
                                           string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_trigger_type, string content_scac, string content_symbol, string content_section, string content_origin_date_offset_days, string content_requesting_district, 
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_CD_RCON_7.createCD_RCON_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_trigger_type, content_scac, content_symbol, content_section, content_origin_date, 
        	                                                          content_requesting_district, content_requesting_milepost, content_requesting_track, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_RTID_2(string header_district_name, string header_district_scac, string header_user_id, string train_clearance_number, string engine_initial, string engine_number)
        {
            STE.Code_Utils.messages.PTC.PTC_CD_RTID_2.createCD_RTID_2(header_district_name, header_district_scac, header_user_id, train_clearance_number, engine_initial, engine_number);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
//        [UserCodeMethod]
//        public static void createCD_RTID_7(string header_message_version, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, string header_htrn_section, 
//                                           string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string train_clearance_number, 
//                                           string engine_initial, string engine_number)
//        {
//            STE.Code_Utils.messages.PTC.PTC_CD_RTID_7.createCD_RTID_7(header_message_version, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_heng_engine_initial, 
//                                                       header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, train_clearance_number, engine_initial, engine_number);
//        }

        
          /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_RTID_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, 
                                           string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, 
                                           string header_uid2_type, string header_uid2, string content_train_clearance_number, string content_engine_initial, string content_engine_number, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_CD_RTID_7.createCD_RTID_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, 
        	                                                          header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, 
        	                                                          header_uid1, header_uid2_type, header_uid2, content_train_clearance_number, content_engine_initial, content_engine_number, hostname);
        }
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_RTDL_2(string header_district_name, string header_district_scac, string header_user_id, string scac, string symbol, string section, string request_type, string trigger_type)
        {
            STE.Code_Utils.messages.PTC.PTC_CD_RTDL_2.createCD_RTDL_2(header_district_name, header_district_scac, header_user_id, scac, symbol, section, request_type, trigger_type);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_RTDL_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, string header_destination_sys, 
                                           string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, string header_htrn_section, 
                                           string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac, 
                                           string content_symbol, string content_section, string content_origin_date_offset_days, string content_request_type, string content_trigger_type, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_CD_RTDL_7.createCD_RTDL_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, 
        	                                                          header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, 
        	                                                          header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, content_section, content_origin_date, content_request_type, content_trigger_type, hostname);
        }

        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_TCON_5(string header_district_name, string header_district_scac, string header_user_id, string scac, string symbol, string section, string loads, string empties, string tonnage, string length, string axles, 
                                           string operative_brakes, string total_braking_force, string speed_constraint, string speed, string speed_class, string reporting_district, string reporting_milepost, string engine_count, 
                                           string engine_record, string position_in_consist, string engine_initial, string engine_number, string engine_status)
        {
            STE.Code_Utils.messages.PTC.PTC_CD_TCON_5.createCD_TCON_5(header_district_name, header_district_scac, header_user_id, scac, symbol, section, loads, empties, tonnage, length, axles, operative_brakes, total_braking_force, speed_constraint, 
                                                       speed, speed_class, reporting_district, reporting_milepost, engine_count, engine_record, position_in_consist, engine_initial, engine_number, engine_status);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_TCON_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, string header_destination_sys, string header_district_name, 
        	                                                          string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, 
        	                                                          string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac, string content_symbol, string content_section, string content_origin_date_offset_days, string content_loads, 
        	                                                          string content_empties, string content_tonnage, string content_length, string content_axles, string content_operative_brakes, string content_total_braking_force, string content_speed_constraint, string content_speed, string content_restriction_count, 
        	                                                          string content_restriction_record, string content_speed_class, string content_reporting_district, string content_reporting_milepost, string content_reporting_track, string content_ptc_loco_orientation, string content_ptc_engine_initial, 
        	                                                          string content_ptc_engine_number, string content_engine_count, string content_engine_record, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
        	}
        	
        	STE.Code_Utils.messages.PTC.PTC_CD_TCON_7.createCD_TCON_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, content_section, content_origin_date, content_loads, content_empties, 
        	                                                          content_tonnage, content_length, content_axles, content_operative_brakes, content_total_braking_force, content_speed_constraint, content_speed, content_restriction_count, 
        	                                                          content_restriction_record, content_speed_class, content_reporting_district, content_reporting_milepost, content_reporting_track, content_ptc_loco_orientation, content_ptc_engine_initial, 
        	                                                          content_ptc_engine_number, content_engine_count, content_engine_record, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_AK01_2(string header_district_name, string header_district_scac, string header_user_id, string ack_message_id, string ack_sequence_number, string response_code, string text)
        {
            STE.Code_Utils.messages.PTC.PTC_GD_AK01_2.createGD_AK01_2(header_district_name, header_district_scac, header_user_id, ack_message_id, ack_sequence_number, response_code, text);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_AK01_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, string header_destination_sys, 
                                           string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, string header_htrn_section, 
                                           string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, 
                                           string content_ack_message_id, string content_ack_sequence_number, string content_response_code, string content_text, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_GD_AK01_7.createGD_AK01_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_ack_message_id, content_ack_sequence_number, content_response_code, content_text, 
        	                                                          hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_ADSR_2(string header_district_name, string header_district_scac, string header_user_id, string track_authority_number, string action, string status_code, string engine_initial, string engine_number, 
                                           string crew_ack_required, string electronic_ack_requested)
        {
            STE.Code_Utils.messages.PTC.PTC_GD_ADSR_2.createGD_ADSR_2(header_district_name, header_district_scac, header_user_id, track_authority_number, action, status_code, engine_initial, engine_number, crew_ack_required, electronic_ack_requested);
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_ADSR_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, 
                                           string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, 
                                           string header_uid2_type, string header_uid2, string content_track_authority_number, string content_action, string content_status_code, string content_engine_initial, string content_engine_number, 
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_GD_ADSR_7.createGD_ADSR_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, 
        	                                                          header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, 
        	                                                          header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_track_authority_number, content_action, 
        	                                                          content_status_code, content_engine_initial, content_engine_number, content_crew_ack_required, content_electronic_ack_requested, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_BOSR_2(string header_district_name, string header_district_scac, string header_user_id, string operating_mode)
        {
            STE.Code_Utils.messages.PTC.PTC_GD_BOSR_2.createGD_BOSR_2(header_district_name, header_district_scac, header_user_id, operating_mode);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_BOSR_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, 
                                           string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, 
                                           string header_uid2, string content_operating_mode, string content_operating_condition, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_GD_BOSR_7.createGD_BOSR_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_operating_mode, content_operating_condition, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_CACA_2(string header_district_name, string header_district_scac, string header_user_id, string track_authority_number, string scac, string symbol, string section, string action, string ack_time, 
                                           string engine_initial, string engine_number, string direction, string employee_first, string employee_middle, string employee_last)
        {
            STE.Code_Utils.messages.PTC.PTC_GD_CACA_2.createGD_CACA_2(header_district_name, header_district_scac, header_user_id, track_authority_number, scac, symbol, section, action, ack_time, engine_initial, engine_number, direction, employee_first, 
                                                       employee_middle, employee_last);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_CACA_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, 
                                           string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, 
                                           string header_uid2, string content_track_authority_number, string content_scac, string content_symbol, string content_section, string content_origin_date_offset_days, string content_action, string content_ack_date_offset_days, 
                                           string content_ack_time_offset_minutes, string content_engine_initial, string content_engine_number, string content_direction, string content_employee_first, string content_employee_middle, string content_employee_last,
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
        	}
        	
        	string content_ack_date;
        	int content_ack_date_offset_int = 0;
        	if (Int32.TryParse(content_ack_date_offset_days, out content_ack_date_offset_int))
        	{
        		content_ack_date = now.AddDays(content_ack_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_ack_date = content_ack_date_offset_days;
        	}
        	
        	string content_ack_time;
        	int content_ack_time_offset_int = 0;
        	if (Int32.TryParse(content_ack_time_offset_minutes, out content_ack_time_offset_int))
        	{
        		content_ack_time = now.AddMinutes(content_ack_time_offset_int).ToString("HHmm");
        	} else {
        		content_ack_time = content_ack_time_offset_minutes;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_GD_CACA_7.createGD_CACA_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_track_authority_number, content_scac, content_symbol, content_section, content_origin_date, 
        	                                                          content_action, content_ack_date, content_ack_time, content_engine_initial, content_engine_number, content_direction, content_employee_first, content_employee_middle, content_employee_last, 
        	                                                          hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_CATA_5(string header_district_name, string header_district_scac, string header_user_id, string track_authority_number, string action, string employee_first, string employee_middle, string employee_last)
        {
            STE.Code_Utils.messages.PTC.PTC_GD_CATA_5.createGD_CATA_5(header_district_name, header_district_scac, header_user_id, track_authority_number, action, employee_first, employee_middle, employee_last);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_CATA_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, string header_htrn_section, 
                                           string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, 
                                           string content_track_authority_number, string content_action, string content_employee_first, string content_employee_middle, string content_employee_last, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_GD_CATA_7.createGD_CATA_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_track_authority_number, content_action, content_employee_first, content_employee_middle, 
        	                                                          content_employee_last, hostname);
        }


        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_CTER_2(string header_district_name, string header_district_scac, string header_user_id, string track_authority_number, string employee_first, string employee_middle, string employee_last, string req_time_extension)
        {
            STE.Code_Utils.messages.PTC.PTC_GD_CTER_2.createGD_CTER_2(header_district_name, header_district_scac, header_user_id, track_authority_number, employee_first, employee_middle, employee_last, req_time_extension);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_CTER_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, 
                                           string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, 
                                           string header_uid2, string content_track_authority_number, string content_employee_first, string content_employee_middle, string content_employee_last, string content_req_time_extension, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_GD_CTER_7.createGD_CTER_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_track_authority_number, content_employee_first, content_employee_middle, 
        	                                                          content_employee_last, content_req_time_extension, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_CTIR_2(string header_district_name, string header_district_scac, string header_user_id, string scac, string symbol, string section, string engine_initial, string engine_number, string coupled_engine_initial, 
                                           string coupled_engine_number, string employee_first, string employee_middle, string employee_last, string track_authority_to_void, string spaf_ack)
        {
            STE.Code_Utils.messages.PTC.PTC_GD_CTIR_2.createGD_CTIR_2(header_district_name, header_district_scac, header_user_id, scac, symbol, section, engine_initial, engine_number, coupled_engine_initial, coupled_engine_number, employee_first, 
                                                       employee_middle, employee_last, track_authority_to_void, spaf_ack);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_CTIR_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, 
                                           string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, 
                                           string header_uid2, string content_scac, string content_symbol, string content_section, string content_origin_date_offset_days, string content_engine_initial, string content_engine_number, 
                                           string content_coupled_engine_initial, string content_coupled_engine_number, string content_employee_first, string content_employee_middle, string content_employee_last, string content_track_authority_to_void, 
                                           string content_spaf_ack, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_GD_CTIR_7.createGD_CTIR_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, content_section, content_origin_date, content_engine_initial, 
        	                                                          content_engine_number, content_coupled_engine_initial, content_coupled_engine_number, content_employee_first, content_employee_middle, content_employee_last, 
        	                                                          content_track_authority_to_void, content_spaf_ack, hostname);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_CTRR_2(string header_district_name, string header_district_scac, string header_user_id, string track_authority_number, string milepost_integer, string district, string track, string employee_first, 
                                           string employee_middle, string employee_last, string spaf_ack)
        {
            STE.Code_Utils.messages.PTC.PTC_GD_CTRR_2.createGD_CTRR_2(header_district_name, header_district_scac, header_user_id, track_authority_number, milepost_integer, district, track, employee_first, employee_middle, employee_last, spaf_ack);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_CTRR_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, 
                                           string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, 
                                           string header_uid2, string content_track_authority_number, string content_milepost_integer, string content_district, string content_track, string content_employee_first, string content_employee_middle, 
                                           string content_employee_last, string content_spaf_ack, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_GD_CTRR_7.createGD_CTRR_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, 
        	                                                          header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, 
        	                                                          header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_track_authority_number, content_milepost_integer, 
        	                                                          content_district, content_track, content_employee_first, content_employee_middle, content_employee_last, content_spaf_ack, hostname);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_CTVR_2(string header_district_name, string header_district_scac, string header_user_id, string track_authority_number, string employee_first, string employee_middle, string employee_last, string spaf_ack)
        {
            STE.Code_Utils.messages.PTC.PTC_GD_CTVR_2.createGD_CTVR_2(header_district_name, header_district_scac, header_user_id, track_authority_number, employee_first, employee_middle, employee_last, spaf_ack);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_CTVR_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, 
                                           string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, 
                                           string header_uid2, string content_track_authority_number, string content_employee_first, string content_employee_middle, string content_employee_last, string content_spaf_ack, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_GD_CTVR_7.createGD_CTVR_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, 
        	                                                          header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, 
        	                                                          header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_track_authority_number, content_employee_first, 
        	                                                          content_employee_middle, content_employee_last, content_spaf_ack, hostname);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_DIVA_2(string header_district_name, string header_district_scac, string header_user_id, string bos_instance_id, string bos_host_name, string bos_ip_address, string old_file_version, string new_file_version, string activation_time)
        {
            STE.Code_Utils.messages.PTC.PTC_GD_DIVA_2.createGD_DIVA_2(header_district_name, header_district_scac, header_user_id, bos_instance_id, bos_host_name, bos_ip_address, old_file_version, new_file_version, activation_time);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_DIVA_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, string header_destination_sys, 
                                           string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, string header_htrn_section, 
                                           string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_bos_instance_id, 
                                           string content_bos_host_name, string content_bos_ip_address, string content_old_file_version, string content_new_file_version, string content_activation_date, string content_activation_time, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_GD_DIVA_7.createGD_DIVA_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, 
        	                                                          header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, 
        	                                                          header_uid1, header_uid2_type, header_uid2, content_bos_instance_id, content_bos_host_name, content_bos_ip_address, content_old_file_version, content_new_file_version, content_activation_date, 
        	                                                          content_activation_time, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_EA01_4(string header_district_name, string header_district_scac, string header_user_id, string scac, string symbol, string section, string engine_initial, string engine_number, string application_time, 
                                           string target_type, string target_description, string speed, string direction, string he_district, string he_track, string he_milepost, string re_district, string re_track, string re_milepost)
        {
            STE.Code_Utils.messages.PTC.PTC_GD_EA01_4.createGD_EA01_4(header_district_name, header_district_scac, header_user_id, scac, symbol, section, engine_initial, engine_number, application_time, target_type, target_description, speed, direction, 
                                                       he_district, he_track, he_milepost, re_district, re_track, re_milepost);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_EA01_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, string header_destination_sys, 
                                           string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, string header_htrn_section, string header_htrn_origin_date_offset_days, 
                                           string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac, string content_symbol, string content_section, 
                                           string content_origin_date_offset_days, string content_engine_initial, string content_engine_number, string content_application_date, string content_application_time, string content_target_type, string content_target_description, 
                                           string content_speed, string content_direction, string content_he_district, string content_he_track, string content_he_milepost, string content_re_district, string content_re_track, string content_re_milepost, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_GD_EA01_7.createGD_EA01_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, content_section, content_origin_date, content_engine_initial, 
        	                                                          content_engine_number, content_application_date, content_application_time, content_target_type, content_target_description, content_speed, content_direction, content_he_district, 
        	                                                          content_he_track, content_he_milepost, content_re_district, content_re_track, content_re_milepost, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_EBAR_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, 
                                           string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, 
                                           string header_uid2, string content_scac, string content_symbol, string content_section, string content_origin_date_offset_days, string content_engine_initial, string content_engine_number, 
                                           string content_application_date, string content_application_time, string content_application_type, string content_speed, string content_direction, string content_he_district, string content_he_track, 
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_GD_EBAR_7.createGD_EBAR_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, content_section, content_origin_date, content_engine_initial, 
        	                                                          content_engine_number, content_application_date, content_application_time, content_application_type, content_speed, content_direction, content_he_district, content_he_track, 
        	                                                          content_he_milepost, content_re_district, content_re_track, content_re_milepost, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_RTDL_2(string header_district_name, string header_district_scac, string header_user_id, string scac, string symbol, string section, string request_type, string trigger_type)
        {
            STE.Code_Utils.messages.PTC.PTC_GD_RTDL_2.createGD_RTDL_2(header_district_name, header_district_scac, header_user_id, scac, symbol, section, request_type, trigger_type);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_RTDL_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, 
                                           string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, 
                                           string header_uid2, string content_scac, string content_symbol, string content_section, string content_origin_date_offset_days, string content_request_type, string content_trigger_type, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_GD_RTDL_7.createGD_RTDL_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, 
        	                                                          header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, 
        	                                                          header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, 
        	                                                          content_symbol, content_section, content_origin_date, content_request_type, content_trigger_type, hostname);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_SY01_5(string header_district_name, string header_district_scac, string header_user_id, string synch_req_type, string district_version)
        {
            STE.Code_Utils.messages.PTC.PTC_GD_SY01_5.createGD_SY01_5(header_district_name, header_district_scac, header_user_id, synch_req_type, district_version);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_SY01_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, 
                                           string header_source_sys, string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, 
                                           string header_htrn_scac, string header_htrn_symbol, string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, 
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_GD_SY01_7.createGD_SY01_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_synch_req_type, content_district_version, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_TAUR_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, 
                                           string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, 
                                           string header_htrn_section, string header_htrn_origin_date_offset_days, string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, 
                                           string header_uid2, string content_track_authority_number, string content_authority_type, string content_engine_initial, string content_engine_number, string content_entry_district, string content_entry_milepost, 
                                           string content_entry_track, string content_site_name, string content_site_device_id, string content_device_type, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_GD_TAUR_7.createGD_TAUR_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_track_authority_number, content_authority_type, content_engine_initial, 
        	                                                          content_engine_number, content_entry_district, content_entry_milepost, content_entry_track, content_site_name, content_site_device_id, content_device_type, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_VICR_2(string header_district_name, string header_district_scac, string header_user_id, string scac, string symbol, string section, string engine_initial, string engine_number, string trigger_type, string violation_cleared_time)
        {
            STE.Code_Utils.messages.PTC.PTC_GD_VICR_2.createGD_VICR_2(header_district_name, header_district_scac, header_user_id, scac, symbol, section, engine_initial, engine_number, trigger_type, violation_cleared_time);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_VICR_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, string header_destination_sys, 
                                           string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, string header_htrn_section, string header_htrn_origin_date_offset_days, 
                                           string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac, string content_symbol, string content_section, 
                                           string content_origin_date_offset_days, string content_engine_initial, string content_engine_number, string content_trigger_type, string content_violation_date, string content_violation_time, string content_violation_cleared_date, 
                                           string content_violation_cleared_time, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_GD_VICR_7.createGD_VICR_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, 
        	                                                          header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, 
        	                                                          header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, content_section, content_origin_date, content_engine_initial, content_engine_number, content_trigger_type, content_violation_date, 
        	                                                          content_violation_time, content_violation_cleared_date, content_violation_cleared_time, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_VIRS_4(string header_district_name, string header_district_scac, string header_user_id, string scac, string symbol, string section, string engine_initial, string engine_number, string he_district, 
                                           string he_track, string he_milepost, string re_district, string re_track, string re_milepost, string direction, string violation_time, string speed)
        {
            STE.Code_Utils.messages.PTC.PTC_GD_VIRS_4.createGD_VIRS_4(header_district_name, header_district_scac, header_user_id, scac, symbol, section, engine_initial, engine_number, he_district, he_track, he_milepost, re_district, re_track, re_milepost, 
                                                       direction, violation_time, speed);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createGD_VIRS_7(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_message_revision, string header_source_sys, string header_destination_sys, 
                                           string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, string header_htrn_symbol, string header_htrn_section, string header_htrn_origin_date_offset_days, 
                                           string header_heng_engine_initial, string header_heng_engine_number, string header_uid1_type, string header_uid1, string header_uid2_type, string header_uid2, string content_scac, string content_symbol, string content_section, 
                                           string content_origin_date_offset_days, string content_engine_initial, string content_engine_number, string content_he_district, string content_he_track, string content_he_milepost, string content_re_district, string content_re_track, 
                                           string content_re_milepost, string content_direction, string content_violation_date, string content_violation_time, string content_speed, string hostname)
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
        	
        	string header_htrn_origin_date;
        	int header_htrn_origin_date_offset_int = 0;
        	if (Int32.TryParse(header_htrn_origin_date_offset_days, out header_htrn_origin_date_offset_int))
        	{
        		header_htrn_origin_date = now.AddDays(header_htrn_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		header_htrn_origin_date = header_htrn_origin_date_offset_days;
        	}
        	
        	string content_origin_date;
        	int content_origin_date_offset_int = 0;
        	if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int))
        	{
        		content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_origin_date = content_origin_date_offset_days;
        	}
        	
            STE.Code_Utils.messages.PTC.PTC_GD_VIRS_7.createGD_VIRS_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, 
        	                                                          header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, 
        	                                                          header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, content_section, content_origin_date, content_engine_initial, 
        	                                                          content_engine_number, content_he_district, content_he_track, content_he_milepost, content_re_district, content_re_track, content_re_milepost, content_direction, content_violation_date, 
        	                                                          content_violation_time, content_speed, hostname);
        }
        
                
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCD_CODS_7(string header_district_name, string header_district_scac, string header_user_id, string header_track_file_version, string header_htrn_scac, 
                                           string header_htrn_symbol, string header_htrn_section,
                                           string header_heng_engine_initial, string header_heng_engine_number, string TCON_Sequence_number,string scac, string symbol, 
                                           string section, string Status_code,string ptc_engine_initial, string ptc_engine_number)
        {
            STE.Code_Utils.messages.PTC.PTC_CD_CODS_7.createCD_CODS_7(header_district_name, header_district_scac, header_user_id,header_track_file_version, header_track_file_version, 
                                                                            header_htrn_scac, header_htrn_symbol, header_htrn_section,header_heng_engine_initial,
                                                                            header_heng_engine_number, TCON_Sequence_number,scac, symbol,section, Status_code,
                                                                            ptc_engine_initial, ptc_engine_number);
        }
        
    }
    
    
}
