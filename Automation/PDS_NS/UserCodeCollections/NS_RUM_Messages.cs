/*
 * Created by Ranorex
 * User: 212719544
 * Date: 11/4/2019
 * Time: 10:33 AM
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
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_RUM_Messages
    {
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendRD_AK01_1(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_source_sys, 
                                         string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_division_name,
                                         string content_ack_sequence_number, string content_response_code, string content_text, string hostname)
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
            
            //TODO: Need some mechanism for Ack Sequence Number
            
            STE.Code_Utils.messages.RUM.RUM_RD_AK01_1.createRD_AK01_1(header_event_date, header_event_time, header_sequence_number, header_message_version, header_source_sys, 
                                                                      header_destination_sys, header_district_name, header_district_scac, header_user_id, header_division_name, 
                                                                      content_ack_sequence_number, content_response_code, content_text, hostname);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendRD_BICQ_1(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_source_sys, 
                                         string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_division_name,
                                         string content_request_id, string content_requesting_employee, string content_bulletin_item_type, string hostname)
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
            
            STE.Code_Utils.messages.RUM.RUM_RD_BICQ_1.createRD_BICQ_1(header_event_date, header_event_time, header_sequence_number, header_message_version, header_source_sys, 
                                                                      header_destination_sys, header_district_name, header_district_scac, header_user_id, header_division_name, 
                                                                      content_request_id, content_requesting_employee, content_bulletin_item_type, hostname);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendRD_BIIQ_1(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_source_sys, 
                                         string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_division_name,
                                         string content_request_id, string content_pf_addressee, string content_pf_addressee_type, string content_requesting_employee, 
                                         string content_requesting_employee_note, string content_bulletin_item_type, string content_effective_date_offset_days, string content_effective_time_offset_minutes, 
                                         string content_effective_time_zone, string content_bulletin_item_number_void_bulletinSeed, string content_bulletin_id_void_bulletinSeed, string content_field_count, string content_field_record, string hostname)
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
        	
        	string content_effective_date;
        	int content_effective_date_offset_int = 0;
        	if (Int32.TryParse(content_effective_date_offset_days, out content_effective_date_offset_int))
        	{
        		content_effective_date = now.AddDays(content_effective_date_offset_int).ToString("MMddyyyy");
        	} else {
        		content_effective_date = content_effective_date_offset_days;
        	}
        	
        	string content_effective_time;
        	int content_effective_time_offset_int = 0;
        	if (Int32.TryParse(content_effective_time_offset_minutes, out content_effective_time_offset_int))
        	{
        		content_effective_time = now.AddMinutes(content_effective_time_offset_int).ToString("HHmm");
        	} else {
        		content_effective_time = content_effective_time_offset_minutes;
        	}
        	
        	string content_bulletin_item_number_void = NS_Bulletin.GetBulletinNumber(content_bulletin_item_number_void_bulletinSeed);
            if (content_bulletin_item_number_void == null)
        	{
        		content_bulletin_item_number_void = content_bulletin_item_number_void_bulletinSeed;
        	}
            string content_bulletin_id_void = NS_Bulletin.GetBulletinId(content_bulletin_id_void_bulletinSeed);
            
            STE.Code_Utils.messages.RUM.RUM_RD_BIIQ_1.createRD_BIIQ_1(header_event_date, header_event_time, header_sequence_number, header_message_version, header_source_sys, 
                                                                      header_destination_sys, header_district_name, header_district_scac, header_user_id, header_division_name, 
                                                                      content_request_id, content_pf_addressee, content_pf_addressee_type, content_requesting_employee, 
                                                                      content_requesting_employee_note, content_bulletin_item_type, content_effective_date, content_effective_time, 
                                                                      content_effective_time_zone, content_bulletin_item_number_void, content_bulletin_id_void, content_field_count, content_field_record, hostname);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendRD_BIIQ_1Simple(string bulletinSeed, string district, string division, string pfAddressee, string pfAddresseeType, string requestingEmployee,string content_requesting_employee_note, string bulletinItemType, string bulletinItemNumberVoidBulletinSeed, string contentEffectiveTimeZone, string headerEventTimeOffsetMinutes, string fieldRecord, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_sequence_number = "default";
        	string header_message_version = "1";
        	string header_source_sys = "RU";
        	string header_destination_sys = "CAD";
        	string header_district_scac = "";
        	string header_user_id = "AUTO";
        	string content_request_id = "default";
        	string content_effective_date_offset_days = "0";
        	string content_effective_time_offset_minutes = "0";
        	string content_field_count = (fieldRecord.Split('|').Length/3).ToString();
        	string adms_bulletin_number = ADMSEnvironment.GetBulletinLatestNumber_ADMS();
        	int bulletin_number_int = 0;
        	Int32.TryParse(adms_bulletin_number, out bulletin_number_int);
        	bulletin_number_int = bulletin_number_int + 1;
        	string bulletin_number = bulletin_number_int.ToString();
            string bulletinIdStatus = CDMSEnvironment.GetCommonConfigValue_CDMS("RST_BULLETIN_ID_FEATURE_ENABLE");
            string content_bulletin_id_void = "";
            if(bulletinIdStatus == "2")
            {
            	content_bulletin_id_void = bulletinItemNumberVoidBulletinSeed;
            }
            
             sendRD_BIIQ_1(header_event_date_offset_days, headerEventTimeOffsetMinutes, header_sequence_number, header_message_version, header_source_sys,
                          header_destination_sys, district, header_district_scac, header_user_id, division, content_request_id, pfAddressee, pfAddresseeType, requestingEmployee,
                          content_requesting_employee_note, bulletinItemType, content_effective_date_offset_days, content_effective_time_offset_minutes,
                          contentEffectiveTimeZone, bulletinItemNumberVoidBulletinSeed, content_bulletin_id_void, content_field_count, fieldRecord, hostname);

            //Add Bulletin information to the persistent bulletin list
            NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletin_number, bulletinItemType, "", "", district, "", "");
			
        }
        
        [UserCodeMethod]
        public static void sendRD_BICQ_1Simple(string district, string division, string bulletinItemType, string pfAddresseeType, string requestingEmployee, string hostname)
        {
            string header_event_date_offset_days = "0";
            string header_event_time_offset_minutes = "0";
            string header_sequence_number = "default";
            string header_message_version = "1";
            string header_source_sys = "RU";
            string header_destination_sys = "CAD";
            string header_district_scac = "";
            string header_user_id = "AUTO";
            string content_request_id = "default";
            
            sendRD_BICQ_1(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_source_sys, header_destination_sys, 
                          district, header_district_scac, header_user_id, division, content_request_id, requestingEmployee, bulletinItemType, hostname);
            
			
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendRD_BINQ_1(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_source_sys, 
                                         string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_division_name,
                                         string content_request_id, string content_pf_addressee, string content_pf_addressee_type, string content_requesting_employee, 
                                         string content_bulletin_item_number_bulletinSeed, string content_bulletin_id_bulletinSeed, string hostname)
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
        	
        	string content_bulletin_item_number = NS_Bulletin.GetBulletinNumber(content_bulletin_item_number_bulletinSeed);
            if (content_bulletin_item_number == null)
        	{
        		content_bulletin_item_number = content_bulletin_item_number_bulletinSeed;
        	}
            
            string content_bulletin_id = NS_Bulletin.GetBulletinId(content_bulletin_id_bulletinSeed);
            if (content_bulletin_id == null)
        	{
        		content_bulletin_id = content_bulletin_id_bulletinSeed;
        	}
            
            STE.Code_Utils.messages.RUM.RUM_RD_BINQ_1.createRD_BINQ_1(header_event_date, header_event_time, header_sequence_number, header_message_version, header_source_sys, 
        	                                                          header_destination_sys, header_district_name, header_district_scac, header_user_id, header_division_name, 
        	                                                          content_request_id, content_pf_addressee, content_pf_addressee_type, content_requesting_employee, 
        	                                                          content_bulletin_item_number, content_bulletin_id, hostname);
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendRD_BINQ_1Simple(string bulletinSeed, string district, string division, string pfAddressee, string pfAddresseeType, string requestingEmployee, string hostname)
        {
        	string header_event_date_offset_days = "0";
            string header_event_time_offset_minutes = "0";
            string header_sequence_number = "default";
            string header_message_version = "1";
            string header_source_sys = "RU";
            string header_destination_sys = "CAD";
            string header_district_scac = "";
            string header_user_id = "AUTO";
            string content_request_id = "default";
            string content_bulletin_item_number_bulletinSeed = bulletinSeed;
            string bulletinIdStatus = CDMSEnvironment.GetCommonConfigValue_CDMS("RST_BULLETIN_ID_FEATURE_ENABLE");
            string content_bulletin_id = "";
            if(bulletinIdStatus == "2")
            {
            	content_bulletin_id = bulletinSeed;
            }
            sendRD_BINQ_1(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_source_sys, header_destination_sys, district, header_district_scac, header_user_id, division,
                          content_request_id, pfAddressee, pfAddresseeType, requestingEmployee, content_bulletin_item_number_bulletinSeed, content_bulletin_id, hostname);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendRD_BIVQ_1(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_source_sys, 
                                         string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_division_name,
                                         string content_request_id, string content_pf_addressee, string content_pf_addressee_type, string content_requesting_employee, string content_requesting_employee_note,
                                         string content_bulletin_item_number_bulletinSeed, string content_bulletin_id_bulletinSeed, string hostname)
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
        	
        	string content_bulletin_item_number = NS_Bulletin.GetBulletinNumber(content_bulletin_item_number_bulletinSeed);
            if (content_bulletin_item_number == null)
        	{
        		content_bulletin_item_number = content_bulletin_item_number_bulletinSeed;
        	}
            
            string content_bulletin_id = NS_Bulletin.GetBulletinId(content_bulletin_id_bulletinSeed);
            if (content_bulletin_id == null)
        	{
        		content_bulletin_id = content_bulletin_id_bulletinSeed;
        	}
            
            STE.Code_Utils.messages.RUM.RUM_RD_BIVQ_1.createRD_BIVQ_1(header_event_date, header_event_time, header_sequence_number, header_message_version, header_source_sys, header_destination_sys, 
                                                                      header_district_name, header_district_scac, header_user_id, header_division_name, content_request_id, content_pf_addressee, 
                                                                      content_pf_addressee_type, content_requesting_employee, content_requesting_employee_note, content_bulletin_item_number, content_bulletin_id, hostname);
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendRD_BIVQ_1Simple(string bulletinSeed, string district, string division, string pfAddressee, string pfAddresseeType, string requestingEmployee, string requestingEmployeeNote, string hostname)
        {
        	string header_event_date_offset_days = "0";
        	string header_event_time_offset_minutes = "0";
        	string header_sequence_number = "default";
        	string header_message_version = "1";
        	string header_source_sys = "RU";
        	string header_destination_sys = "CAD";
        	string header_district_scac = "";
        	string header_user_id = "AUTO";
        	string content_request_id = "default";
        	string content_bulletin_item_number_bulletinSeed = bulletinSeed;
        	string content_bulletin_id = "";
        	string bulletinIdStatus = CDMSEnvironment.GetCommonConfigValue_CDMS("RST_BULLETIN_ID_FEATURE_ENABLE");
            if(bulletinIdStatus == "2")
            {
            	content_bulletin_id = bulletinSeed;
            }
        	sendRD_BIVQ_1(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_source_sys, header_destination_sys,
        	              district, header_district_scac, header_user_id, division, content_request_id, pfAddressee,
        	              pfAddresseeType, requestingEmployee, requestingEmployeeNote, content_bulletin_item_number_bulletinSeed, content_bulletin_id, hostname);
        	
        }
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendRD_CATA_1(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_source_sys, 
                                         string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_division_name,
                                         string content_track_authority_number_authoritySeed, string content_track_authority_id_authoritySeed, string content_action, string content_employee_first_crewSeed, string content_employee_middle_crewSeed, 
                                         string content_employee_last_crewSeed, string hostname)
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
        	
            string content_track_authority_number = NS_Authorities.GetAuthorityNumber(content_track_authority_number_authoritySeed);
            if (content_track_authority_number == null)
        	{
        		content_track_authority_number = content_track_authority_number_authoritySeed;
        	}
            
            string content_track_authority_id = NS_Authorities.NS_ADMSGetAuthorityId(content_track_authority_id_authoritySeed);
            if (content_track_authority_id == null)
        	{
        		content_track_authority_id = content_track_authority_id_authoritySeed;
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
            
            STE.Code_Utils.messages.RUM.RUM_RD_CATA_1.createRD_CATA_1(header_event_date, header_event_time, header_sequence_number, header_message_version, header_source_sys, header_destination_sys, 
                                                                      header_district_name, header_district_scac, header_user_id, header_division_name, content_track_authority_number, content_track_authority_id, content_action, 
                                                                      content_employee_first, content_employee_middle, content_employee_last, hostname);
        }
        
        [UserCodeMethod]
       	public static void SendRD_CATA_1Simple(string authoritySeed, string crewSeed, string district, string division, string action, string hostname)
        {
       		string header_event_date_offset_days = "0";
            string header_event_time_offset_minutes = "0";
            string header_sequence_number = "default";
            string header_message_version = "1";
            string header_source_sys = "RU";
            string header_destination_sys = "CAD";
            string header_district_scac = "";
            string header_user_id = "AUTO";
        	string content_track_authority_number_authoritySeed = authoritySeed;
        	string content_employee_first_crewSeed = crewSeed;
        	string content_employee_middle_crewSeed = crewSeed;
        	string content_employee_last_crewSeed = crewSeed;
        	string trackAuthorityUniqueIdStatus = CDMSEnvironment.GetCommonConfigValue_CDMS("RUM_TA_UID_ENABLE");
			string content_track_authority_id_authoritySeed = "Null";
			if(trackAuthorityUniqueIdStatus == "2")
			{
       		   content_track_authority_id_authoritySeed = authoritySeed;
			}
       		sendRD_CATA_1(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_source_sys, 
                                         header_destination_sys, district, header_district_scac, header_user_id, division, content_track_authority_number_authoritySeed, 
                                         content_track_authority_id_authoritySeed, action, content_employee_first_crewSeed, content_employee_middle_crewSeed, content_employee_last_crewSeed, hostname);
       	}
       	
       	[UserCodeMethod]
       	public static void SendRD_CATA_1SimpleEmployeeName(string authoritySeed, string district, string division, string action, string content_employee_first_crewSeed, 
       	                                                   string content_employee_middle_crewSeed, string content_employee_last_crewSeed, string hostname)
        {
       		string header_event_date_offset_days = "0";
            string header_event_time_offset_minutes = "0";
            string header_sequence_number = "default";
            string header_message_version = "1";
            string header_source_sys = "RU";
            string header_destination_sys = "CAD";
            string header_district_scac = "";
            string header_user_id = "AUTO";
        	string content_track_authority_number_authoritySeed = authoritySeed;
       		string trackAuthorityUniqueIdStatus = CDMSEnvironment.GetCommonConfigValue_CDMS("RUM_TA_UID_ENABLE");
			string content_track_authority_id_authoritySeed = "Null";
			if(trackAuthorityUniqueIdStatus == "2")
			{
       		   content_track_authority_id_authoritySeed = authoritySeed;
			}
       		sendRD_CATA_1(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_source_sys, 
                                         header_destination_sys, district, header_district_scac, header_user_id, division, content_track_authority_number_authoritySeed, 
                                         content_track_authority_id_authoritySeed, action, content_employee_first_crewSeed, content_employee_middle_crewSeed, content_employee_last_crewSeed, hostname);
       	}
       	
       	/// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendRD_PTUQ_1(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_source_sys, 
                                         string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_division_name,
                                         string content_request_id, string content_pf_addressee, string content_pf_addressee_type, string content_requesting_employee, string content_district, 
                                         string content_from_station, string content_to_station, string content_track, string hostname)
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
            
            STE.Code_Utils.messages.RUM.RUM_RD_PTUQ_1.createRD_PTUQ_1(header_event_date, header_event_time, header_sequence_number, header_message_version, header_source_sys, 
                                                                      header_destination_sys, header_district_name, header_district_scac, header_user_id, header_division_name, 
                                                                      content_request_id, content_pf_addressee, content_pf_addressee_type, content_requesting_employee, 
                                                                      content_district, content_from_station, content_to_station, content_track, hostname);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendRD_RTER_1(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_source_sys, 
                                         string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_division_name,
                                         string content_request_id, string content_pf_addressee, string content_pf_addressee_type, string content_requesting_employee, string content_track_authority_number_authoritySeed, string content_track_authority_id_authoritySeed, 
                                         string content_employee_first_crewSeed, string content_employee_middle_crewSeed, string content_employee_last_crewSeed, string content_req_time_extension_offset_minutes, 
                                         string content_ru_comments, string hostname)
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
        	
        	
            string content_req_time_extension;
        	int content_req_time_extension_offset_int = 0;
        	if (Int32.TryParse(content_req_time_extension_offset_minutes, out content_req_time_extension_offset_int))
        	{
        		content_req_time_extension = now.AddMinutes(content_req_time_extension_offset_int).ToString("hh:mm tt");
        	} else {
        		content_req_time_extension = content_req_time_extension_offset_minutes;
        	}
        	
        	string content_track_authority_number = NS_Authorities.GetAuthorityNumber(content_track_authority_number_authoritySeed);
            if (content_track_authority_number == null)
        	{
        		content_track_authority_number = content_track_authority_number_authoritySeed;
            } else {
                AuthorityObject authorityObj = NS_Authorities.GetAuthorityObject(content_track_authority_number_authoritySeed);
    		    authorityObj.extendUntilTime = content_req_time_extension;
            }
        	
            string content_track_authority_id = NS_Authorities.NS_ADMSGetAuthorityId(content_track_authority_id_authoritySeed);
            if (content_track_authority_id == null)
        	{
        		content_track_authority_id = content_track_authority_id_authoritySeed;
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
        	
            STE.Code_Utils.messages.RUM.RUM_RD_RTER_1.createRD_RTER_1(header_event_date, header_event_time, header_sequence_number, header_message_version, header_source_sys, 
                                                                      header_destination_sys, header_district_name, header_district_scac, header_user_id, header_division_name, 
                                                                      content_request_id, content_pf_addressee, content_pf_addressee_type, content_requesting_employee, 
                                                                      content_track_authority_number, content_track_authority_id, content_employee_first, content_employee_middle, content_employee_last, 
                                                                      content_req_time_extension, content_ru_comments, hostname);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendRD_RTER_1Simple(string authoritySeed, string crewSeed, string district, string division, string pfAddressee, string pfAddresseeType, string requestingEmployee, string content_req_time_extension_offset_minutes, string ruComments, string hostname)
        {
            string header_event_date_offset_days = "0";
            string header_event_time_offset_minutes = "0";
            string header_sequence_number = "default";
            string header_message_version = "1";
            string header_source_sys = "RU";
            string header_destination_sys = "CAD";
            string header_district_scac = "";
            string header_user_id = "AUTO";
            string content_request_id = "default";
        	string content_track_authority_number_authoritySeed = authoritySeed;
        	string content_employee_first_crewSeed = crewSeed;
        	string content_employee_middle_crewSeed = crewSeed;
        	string content_employee_last_crewSeed = crewSeed;
        	string content_track_authority_id_authoritySeed = "Null";
			string trackAuthorityUniqueIdStatus = CDMSEnvironment.GetCommonConfigValue_CDMS("RUM_TA_UID_ENABLE");
        	if(trackAuthorityUniqueIdStatus == "2")
        	{
        		content_track_authority_id_authoritySeed = authoritySeed;
        	}
        	sendRD_RTER_1(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_source_sys, 
        	              header_destination_sys, district, header_district_scac, header_user_id, division, content_request_id, pfAddressee, pfAddresseeType, requestingEmployee, 
        	              content_track_authority_number_authoritySeed, content_track_authority_id_authoritySeed, content_employee_first_crewSeed, content_employee_middle_crewSeed, content_employee_last_crewSeed, content_req_time_extension_offset_minutes,
        	              ruComments, hostname);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendRD_RTER_1SimpleEmployeeName(string authoritySeed, string district, string division, string pfAddressee, string pfAddresseeType, string requestingEmployee, 
                                                           string content_employee_first_crewSeed, string content_employee_middle_crewSeed, string content_employee_last_crewSeed, 
                                                           string content_req_time_extension_offset_minutes, string ruComments, string hostname)
        {
            string header_event_date_offset_days = "0";
            string header_event_time_offset_minutes = "0";
            string header_sequence_number = "default";
            string header_message_version = "1";
            string header_source_sys = "RU";
            string header_destination_sys = "CAD";
            string header_district_scac = "";
            string header_user_id = "AUTO";
            string content_request_id = "default";
        	string content_track_authority_number_authoritySeed = authoritySeed;
        	string content_track_authority_id_authoritySeed = "Null";
			string trackAuthorityUniqueIdStatus = CDMSEnvironment.GetCommonConfigValue_CDMS("RUM_TA_UID_ENABLE");        	
        	if(trackAuthorityUniqueIdStatus == "2")
        	{
        		content_track_authority_id_authoritySeed = authoritySeed;
        	}
        	sendRD_RTER_1(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_source_sys, 
        	              header_destination_sys, district, header_district_scac, header_user_id, division, 
        	              content_request_id, pfAddressee, pfAddresseeType, requestingEmployee, content_track_authority_number_authoritySeed, content_track_authority_id_authoritySeed,
        	              content_employee_first_crewSeed, content_employee_middle_crewSeed, content_employee_last_crewSeed, content_req_time_extension_offset_minutes,
        	              ruComments, hostname);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendRD_RTRR_1(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_source_sys, 
                                         string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_division_name,
                                         string content_request_id, string content_pf_addressee, string content_pf_addressee_type, string content_requesting_employee, string content_track_authority_number_authoritySeed, string content_track_authority_id_authoritySeed,
                                         string content_rollup_location, string content_employee_first_crewSeed, string content_employee_middle_crewSeed, string content_employee_last_crewSeed, string content_spaf_ack, 
                                         string content_ru_comments, string hostname)
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
        	
        	string content_track_authority_number = NS_Authorities.GetAuthorityNumber(content_track_authority_number_authoritySeed);
            if (content_track_authority_number == null)
        	{
        		content_track_authority_number = content_track_authority_number_authoritySeed;
            }
            
            string content_track_authority_id = NS_Authorities.NS_ADMSGetAuthorityId(content_track_authority_id_authoritySeed);
            if (content_track_authority_id == null)
        	{
        		content_track_authority_id = content_track_authority_id_authoritySeed;
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
        	
            STE.Code_Utils.messages.RUM.RUM_RD_RTRR_1.createRD_RTRR_1(header_event_date, header_event_time, header_sequence_number, header_message_version, header_source_sys, 
                                                                      header_destination_sys, header_district_name, header_district_scac, header_user_id, header_division_name, 
                                                                      content_request_id, content_pf_addressee, content_pf_addressee_type, content_requesting_employee, 
                                                                      content_track_authority_number, content_track_authority_id, content_rollup_location, content_employee_first, content_employee_middle, 
                                                                      content_employee_last, content_spaf_ack, content_ru_comments, hostname);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendRD_RTRR_1Simple(string authoritySeed, string crewSeed, string district, string division, string pfAddressee, string pfAddresseeType, string requestingEmployee, string rollupLocation, string spafAck, string ruComments, string hostname)
        {
            string header_event_date_offset_days = "0";
            string header_event_time_offset_minutes = "0";
            string header_sequence_number = "default";
            string header_message_version = "1";
            string header_source_sys = "RU";
            string header_destination_sys = "CAD";
            string header_district_scac = "";
            string header_user_id = "AUTO";
            string content_request_id = "default";
        	string content_track_authority_number_authoritySeed = authoritySeed;
        	string content_employee_first_crewSeed = crewSeed;
        	string content_employee_middle_crewSeed = crewSeed;
        	string content_employee_last_crewSeed = crewSeed;
        	string content_track_authority_id_authoritySeed = "Null";
			string trackAuthorityUniqueIdStatus = CDMSEnvironment.GetCommonConfigValue_CDMS("RUM_TA_UID_ENABLE");        	
        	if(trackAuthorityUniqueIdStatus == "2")
        	{
        		content_track_authority_id_authoritySeed = authoritySeed;
        	}
        	sendRD_RTRR_1(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_source_sys, 
        	              header_destination_sys, district, header_district_scac, header_user_id, division, 
        	              content_request_id, pfAddressee, pfAddresseeType, requestingEmployee, content_track_authority_number_authoritySeed, content_track_authority_id_authoritySeed, rollupLocation,
        	              content_employee_first_crewSeed, content_employee_middle_crewSeed, content_employee_last_crewSeed, spafAck, 
        	              ruComments, hostname);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void sendRD_RTRR_1SimpleEmployeeName(string authoritySeed, string district, string division, string pfAddressee, string pfAddresseeType, string requestingEmployee, 
                                                           string rollupLocation, string content_employee_first_crewSeed, string content_employee_middle_crewSeed, string content_employee_last_crewSeed, 
                                                           string spafAck, string ruComments, string hostname)
        {
            string header_event_date_offset_days = "0";
            string header_event_time_offset_minutes = "0";
            string header_sequence_number = "default";
            string header_message_version = "1";
            string header_source_sys = "RU";
            string header_destination_sys = "CAD";
            string header_district_scac = "";
            string header_user_id = "AUTO";
            string content_request_id = "default";
        	string content_track_authority_number_authoritySeed = authoritySeed;
        	string content_track_authority_id_authoritySeed = "Null";
			string trackAuthorityUniqueIdStatus = CDMSEnvironment.GetCommonConfigValue_CDMS("RUM_TA_UID_ENABLE");        	
        	if(trackAuthorityUniqueIdStatus == "2")
        	{
        		content_track_authority_id_authoritySeed = authoritySeed;
        	}
        	sendRD_RTRR_1(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_source_sys, 
        	              header_destination_sys, district, header_district_scac, header_user_id, division, 
        	              content_request_id, pfAddressee, pfAddresseeType, requestingEmployee, content_track_authority_number_authoritySeed, content_track_authority_id_authoritySeed, rollupLocation,
        	              content_employee_first_crewSeed, content_employee_middle_crewSeed, content_employee_last_crewSeed, spafAck, 
        	              ruComments, hostname);
        }
        
        

        [UserCodeMethod]
        public static void sendRD_RTQR_1(string header_event_date_offset_days, string header_event_time_offset_minutes, string header_sequence_number, string header_message_version, string header_source_sys,
                                         string header_destination_sys, string header_district_name, string header_district_scac, string header_user_id, string header_division_name,
                                         string content_request_id, string content_pf_addressee, string content_pf_addressee_type, string content_requesting_employee, string content_track_authority_number_authoritySeed, 
                                         string content_track_authority_id_authoritySeed, string hostname)
        {
        	System.DateTime now = System.DateTime.Now;
        	string header_event_date;
        	int header_event_date_offset_int = 0;
        	if (Int32.TryParse(header_event_date_offset_days, out header_event_date_offset_int))
        	{
        		header_event_date = now.AddDays(header_event_date_offset_int).ToString("MMddyyyy");
        	} else 
        	{
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

        		string content_track_authority_number = NS_Authorities.GetAuthorityNumber(content_track_authority_number_authoritySeed);
        		if (content_track_authority_number == null)
        		{
        			content_track_authority_number = content_track_authority_number_authoritySeed;
        		}
        		string content_track_authority_id = NS_Authorities.NS_ADMSGetAuthorityId(content_track_authority_id_authoritySeed);
        		if (content_track_authority_id == null)
        		{
        			content_track_authority_id = content_track_authority_id_authoritySeed;
        		}
        		
            STE.Code_Utils.messages.RUM.RUM_RD_RTQR_1.createRD_RTQR_1(header_event_date, header_event_time, header_sequence_number, header_message_version, header_source_sys, 
        	                                                          header_destination_sys, header_district_name, header_user_id, header_division_name,
        	                                                          content_request_id, content_pf_addressee, content_pf_addressee_type, content_requesting_employee, 
        	                                                          content_track_authority_number, content_track_authority_id, hostname);
        }
        

        [UserCodeMethod]
        public static void send_RTQR_1Simple(string authoritySeed, string district, string division, string pfAddressee, string pfAddresseeType, string requestingEmployee, string hostname, string userId, string authorityseedId)
        {
        	string header_event_date_offset_days = "0";
            string header_event_time_offset_minutes = "0";
            string header_sequence_number = "default";
            string header_message_version = "1";
            string header_source_sys = "RU";
            string header_destination_sys = "CAD";
            string header_district_scac = "";
            string header_user_id = userId;
            string content_request_id = "default";
            string content_track_authority_number_authoritySeed = authoritySeed;
			string content_track_authority_id_authoritySeed = "NULL";
			string trackAuthorityUniqueIdStatus = CDMSEnvironment.GetCommonConfigValue_CDMS("RUM_TA_UID_ENABLE");
			if(trackAuthorityUniqueIdStatus == "2")
        	{
        		content_track_authority_id_authoritySeed = authorityseedId;
        	}
            
            sendRD_RTQR_1(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_source_sys, header_destination_sys, district, header_district_scac, division, header_user_id,
                          content_request_id, pfAddressee, pfAddresseeType, requestingEmployee, content_track_authority_number_authoritySeed, content_track_authority_id_authoritySeed, hostname);
        }
    }
}