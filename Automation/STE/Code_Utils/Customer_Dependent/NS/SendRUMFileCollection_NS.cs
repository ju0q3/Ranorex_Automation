/*
 * Created by Ranorex
 * User: 503073759
 * Date: 11/3/2018
 * Time: 1:50 PM
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

namespace STE.Code_Utils
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class SendRumFileCollection_NS
    {
		//Static string to keep track of request IDs
    	public static int request_id = 1000;
    	

        /// <summary>
        /// RD-RTIR Remote Track Authority Issue Request
        /// Sends a request message from the simulated remote client to PDS for a track authority that fits the sent information.
        /// </summary>
        /// <param name="header_district_name"> </param>
        /// <param name="header_user_id"> </param>
        /// <param name="header_divison_name"> </param>
        /// <param name="request_id"> Identifier to be used for the remote user request </param>
        /// <param name="pf_addressee"> Print / Fax Message recipient </param>
        /// <param name="pf_addressee_type"> Print / Fax Message type - "E" for e-mail, "P" for print, "F" for fax, "G" for group name</param>
        /// <param name="requesting_employeee"> Employee ID of the requestor </param>
        /// <param name="addressee_type"> Track authority addressee type - "RW", "OT", "TE" </param>
        /// <param name="scac"> Standard Carrier Alpha Code </param>
        /// <param name="symbol"> Name for the set of trains that operate periodically with a similar train schedule </param>
        /// <param name="section"> Identifier of an extra train </param>
        /// <param name="origin_date"> Origination date of the train -  </param>
        /// <param name="engine_initial"> Alphabetic portion of the engine ID </param>
        /// <param name="engine_number"> Numeric portion of the engine ID </param>
        /// <param name="coupled_engine_initial"> Alphabetic portion of the engine ID </param>
        /// <param name="employee_first"> Employee first name </param>
        /// <param name="employee_middle"> Employee middle initial </param>
        /// <param name="employee_last"> Employee surname </param>
        /// <param name="addressee_id"> Name or gang number of R/W or O/T equipment </param>
        /// <param name="at_location"> Location of the addressee as it is to appear in the authority </param>
        /// <param name="spac_ack"> Crew acknowledgment of having completed a switch position awareness form (GR-39) - "Y"/"N" </param>
        /// <param name="have_joint_occupants"> Determines if there is joint occupancy in the R/W authority being voided.  It is mandatory if S1_TRACK_AUTHORITY_TO_VOID is populated and is an R/W authority. - "Y"/"N" </param>
        /// <param name="s1_track_authority_to_void"> Unique track authority identifier of track authority for which a void is requested </param>
        /// <param name="s2_presence"> Block presence indicator - "Y"/"N" *MANDATORY*</param>
        /// <param name="s2_from_location"> From location name as it appears in the authority </param>
        /// <param name="s2_first_switch"> First switch indicator - "Y"/"N" </param>
        /// <param name="s2_record"> Records for line 2, inclues s2_sequence, s2_to_location, s2_track </param>
        /// <param name="s3_presence"> Block presence indicator - "Y"/"N" *MANDATORY*</param>
        /// <param name="s3_between"> Between location as it appears in the authority </param>
        /// <param name="s3_between_cp"> Between CP indicator - "Y"/"N" </param>
        /// <param name="s3_os"> OS indicator - "Y"/"N" </param>
        /// <param name="s3_and"> And location as it appears in the authority </param>
        /// <param name="s3_and_cp"> And CP indicator - "Y"/"N" </param>
        /// <param name="s3_track_count"> Quantity of records to follow </param>
        /// <param name="s3_track_record"> Records for line 3 track, includes s3_track_sequence and s3_track_text </param>
        /// <param name="s3_subdivide_from"> subdivided limits location as it appears in the authority (midpoint or same as s3_between) </param>
        /// <param name="s3_subdivide_to"> subdivided limits location as it appears in the authority (midpoint or same as s3_and) </param>
        /// <param name="s3_between_zone_count"> Quantity of records to follow </param>
        /// <param name="s3_between_zone_record"> Records for line 3 between zone, includes s3_between_zone </param>
        /// <param name="s3_and_zone_count"> Quantity of records to follow </param>
        /// <param name="s3_and_zone_record"> Records for line 3 and zone, includes s3_and_zone </param>
        /// <param name="s4_presence"> Block presence indicator - "Y"/"N" </param>
        /// <param name="s4_from_location"> From location name as it appears in the authority </param>
        /// <param name="s4_first_switch"> First switch indicator - "Y"/"N" </param>
        /// <param name="s4_count"> Quantity of records to follow </param>
        /// <param name="s4_record"> Record for line 4, includes s4_sequence, s4_to_location, s4_track </param>
        /// <param name="s4_track"> Track name at To limit </param>
        /// <param name="s5_until"> Nonbinding expected authority release time (local time + AM/PM) *MANDATORY*</param>
        /// <param name="s7_hold_main"> Y = Hold main track at last named point, "N" otherwise *MANDATORY* </param>
        /// <param name="s9_clear_main"> Y = Clear main track at last named point, "N" otherwise *MANDATORY*</param>
        /// 
        [UserCodeMethod]
        public static void createRD_RTIR_1(string header_district_name, string header_user_id, string header_division_name, string pf_addressee, string pf_addressee_type, string requesting_employee, string addressee_type, string scac, string symbol, string section, string origin_date, string engine_initial, string engine_number, string coupled_engine_initial, string coupled_engine_number, string employee_first, string employee_middle, string employee_last, string addressee_id, string at_location, string spaf_ack, string have_joint_occupants, string s1_track_authority_to_void, string s2_presence, string s2_from_location, string s2_first_switch, string s2_count, string s2_record, string s3_presence, string s3_between, string s3_between_cp, string s3_os, string s3_and, string s3_and_cp, string s3_track_count, string s3_track_record, string s3_subdivide_from, string s3_subdivide_to, string s3_between_zone_count, string s3_between_zone_record, string s3_and_zone_count, string s3_and_zone_record, string s4_presence, string s4_from_location, string s4_first_switch, string s4_count, string s4_record, string s5_until, string s7_hold_main, string s9_clear_main)
        {
        	//Use the FBACreateRD_RTIR unless you have a good reason to dust this one off and update
        	//request_id++;
            //messages.RUM.RUM_RD_RTIR_1.createRD_RTIR_1(header_district_name, header_user_id, header_division_name, request_id, pf_addressee, pf_addressee_type, requesting_employee, addressee_type, scac, symbol, section, origin_date, engine_initial, engine_number, coupled_engine_initial, coupled_engine_number, employee_first, employee_middle, employee_last, addressee_id, at_location, spaf_ack, s1_track_authority_to_void, s2_presence, s2_from_location, s2_first_switch, s2_count, s2_record, s3_presence, s3_between, s3_between_cp, s3_os, s3_and, s3_and_cp, s3_track_count, s3_track_record, s3_subdivide_from, s3_subdivide_to, s3_between_zone_count, s3_between_zone_record, s3_and_zone_count, s3_and_zone_record, s4_presence, s4_from_location, s4_first_switch, s4_count, s4_record, s5_until, s7_hold_main, s9_clear_main, s2_sequence, s2_to_location, s2_track, s3_track_sequence, s3_track_text, s3_between_zone, s3_and_zone, s4_sequence, s4_to_location, s4_track);
        }
        
        /// <summary>
        /// Use this send RTIR if you are using a data sheet that mirrors an FBA data sheet, several assumptions are taken into account for Simple
        /// Refer to UserCodeMethod createRD_RTIR_1 for explanation of parameters/fields to be interpreted from the data sheet.
        /// </summary>
        [UserCodeMethod]
        public static void FBACreateRD_RTIR (string optionalTrainSeed, string optionalEngineSeed, string district_name, string type, string to, string at, string box1_yn, string box1_void, string box1_void_trackAuthority_id, string box2_yn, string box2_from, string box2_fsw, string box2_to, string box2_track1, string box2_to2, string box2_track2, string box2_to3, string box2_track3, string box2_zones, string box3_yn, string box3_loc1, string box3_loc1_cp, string box3_loc1_os, string box3_loc2, string box3_loc2_cp, string box3_track1, string box3_track2, string box3_track3, string box3_track4, string box3_track5, string zone_list, string box4_yn, string box4_from, string box4_fsw, string box4_to, string box4_track1, string box4_to2, string box4_track2, string box4_to3, string box4_track3, string box5_time, string box7_yn, string box9_yn, string box13_subdiv, string box13_subdiv_limit, string box13_subdiv_side, string spaf_ack, string requesting_employee, string employee_name, string ru_comments, string box1_joint_occupancy, string userId, string division_name) {
        	
        	//prep defaulted fields
        	System.DateTime now = System.DateTime.Now;
        	string header_divison_name = division_name;
			string header_user_id = userId;
			request_id++;
			string pf_addressee = ""; //Optional
			string pf_addressee_type = ""; //Optional
			string engine_initial = "";
			string engine_number = "";
			string scac = "";
			string symbol = "";
			string section = "";
			string origindate = "";
			
			if (type.Equals("TE")) 
			{
                if (string.IsNullOrEmpty(optionalTrainSeed) | string.IsNullOrEmpty(optionalEngineSeed))
				{
					Ranorex.Report.Error("Train seed or engine seed not provided for RD-RTIR message.");
					return;
				}
                
				scac = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSCAC(optionalTrainSeed);
				symbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(optionalTrainSeed);
				section = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSection(optionalTrainSeed);
				origindate = PDS_CORE.Code_Utils.NS_TrainID.getOriginDate(optionalTrainSeed);
				engine_initial = PDS_CORE.Code_Utils.NS_TrainID.GetEngineInitial(optionalTrainSeed, optionalEngineSeed);
				engine_number = PDS_CORE.Code_Utils.NS_TrainID.GetEngineNumber(optionalTrainSeed, optionalEngineSeed);
			}
			
			string coupled_engine_initial = ""; //optional?
			string coupled_engine_number = ""; //optional?
			string addressee_id = to;
			
			
//			Currently broken, defect open for synergy
//			if (!1_void.equals("") && addressee_type.equals(RW) && have_joint_occupants.equals("")) {
//				Report.Failure("Error", "HAVE_JOINT_OCCUPANTS is required to be 'Y' or 'N' when voiding with RW.");
//			}
			
			string[] employeeName = employee_name.Split(' ');
			string employee_first = "";
			string employee_middle = "";
			string employee_last = "";
			if (employeeName.Length == 2) { //First Name + Surname only, no middle
				employee_first = employeeName[0];
				employee_last = employeeName[1];
			} else if (employeeName.Length == 3) { //first name, middle initial only, last name
				employee_first = employeeName[0];
				employee_middle = employeeName[1];
				employee_last = employeeName[2];
			} else {
				Report.Warn("Data Warning", "Improperly formatted name used, <First name> <singular Middle Initial> <Last Name, hyphens allowed> format only.");
			}
			
			
			int s2_count = 0;
			string s2_record = "";
			//Record bundling
			if (!box2_to.Equals("") && !box2_track1.Equals("")) {
				s2_count++;
				s2_record = string.Concat(s2_record, "1" + "|" + box2_to + "|" + box2_track1);
				
				if (!box2_to2.Equals("") && !box2_track2.Equals("")) {
					s2_count++;
					s2_record = string.Concat(s2_record, "|" + "2" + "|" + box2_to2 + "|" + box2_track2);
					
					if (!box2_to3.Equals("") && !box2_track3.Equals("")) {
						s2_count++;
						s2_record = string.Concat(s2_record, "|" + "3" + "|" + box2_to3 + "|" + box2_track3);		
					}
				}
			}
			
			
			int s3_track_count = 0;
			string s3_track_record = "";
			
			if (!box3_track1.Equals("")) {
				s3_track_count++;
				s3_track_record = string.Concat(s3_track_record, "1" + "|" + box3_track1);
				
				if (!box3_track2.Equals("")) {
					s3_track_count++;
					s3_track_record = string.Concat(s3_track_record, "|" + "2" + "|" + box3_track2);
        			
					if (!box3_track3.Equals("")) {
						s3_track_count++;
						s3_track_record = string.Concat(s3_track_record, "|" + "3" + "|" + box3_track3);
						
						if (!box3_track4.Equals("")) {
							s3_track_count++;
							s3_track_record = string.Concat(s3_track_record, "|" + "4" + "|" + box3_track4);
							
							if (!box3_track5.Equals("")) {
								s3_track_count++;
								s3_track_record = string.Concat(s3_track_record, "|" + "5" + "|" + box3_track5);
							}
						}
					}
				}
			}
			
         	string[] zones = zone_list.Split('|');
			int s3_between_zone_count = 0;
			int s3_and_zone_count = 0;
			
			string s3_between_zone_record = "";
			string s3_and_zone_record = "";
			if ((zones.Length % 2).Equals(0) && zones.Length != 0) { //will return 1 for empty string (which is fine, everything will stay at 0 or empty string, must be paired
				int i = 0;
				while (i < zones.Length) {
					if(zones[i].ToString() != "")
					{
						s3_between_zone_record = string.Concat(s3_between_zone_record, zones[i]);
						s3_between_zone_count++;
					}
					
					if(zones[i+1].ToString() != "")
					{
						s3_and_zone_record = string.Concat(s3_and_zone_record, zones[i+1]);
						s3_and_zone_count++;
					}
					i+=2;
				}
			}
			
			string s3_subdivide_from = "";
			string s3_subdivide_to = "";
			if (box13_subdiv.Equals("Y")) {
				if (box13_subdiv_side.Equals("Between")) {
					s3_subdivide_from = box3_loc1;
					s3_subdivide_to = box13_subdiv_limit;
				} else if (box13_subdiv_side.Equals("And")) {
			    	s3_subdivide_from = box13_subdiv_limit;
					s3_subdivide_to = box3_loc2;      	
	           } else {
		           	Ranorex.Report.Warn("Data Warning", "Invalid subdivision side.");
	           }
			}
			
			
			int s4_count = 0;
			string s4_record = "";
			if (!box4_to.Equals("") && !box4_track1.Equals("")) {
				s4_count++;
				s4_record = string.Concat(s4_record, "|" + box4_to + "|" + box4_track1);
				if (!box4_to2.Equals("") && !box4_track2.Equals("")) {
					s4_count++;
					s4_record = string.Concat(s4_record, "|" + box4_to2 + "|" + box4_track2);
					if (!box4_to3.Equals("") && !box4_track3.Equals ("")) {
						s4_count++;
						s4_record = string.Concat(s4_record, "|" + box4_to3 + "|" + box4_track3);
					}
				}
			}
			
			if (box5_time.Contains("h+")) {
				int extend = Convert.ToInt32(box5_time.Substring(2));
				box5_time = now.AddHours(extend).ToString("hh:mm tt");
			}
			
			if (box5_time.Contains("m+")) {
				int extend = Convert.ToInt32(box5_time.Substring(2));
				box5_time = now.AddMinutes(extend).ToString("hh:mm tt");
			}
			
			messages.RUM.RUM_RD_RTIR_1.createRD_RTIR_1(district_name, header_user_id, header_divison_name, request_id.ToString(), pf_addressee, pf_addressee_type, requesting_employee, type, scac, symbol, section, origindate, engine_initial, engine_number, coupled_engine_initial, coupled_engine_number, employee_first, employee_middle, employee_last, addressee_id, ru_comments, at, spaf_ack, box1_joint_occupancy, box1_void, box1_void_trackAuthority_id, box2_yn, box2_from, box2_fsw, s2_count.ToString(), s2_record, box3_yn, box3_loc1, box3_loc1_cp, box3_loc1_os, box3_loc2, box3_loc2_cp, s3_track_count.ToString(), s3_track_record, s3_subdivide_from, s3_subdivide_to, s3_between_zone_count.ToString(), s3_between_zone_record, s3_and_zone_count.ToString(), s3_and_zone_record, box4_yn, box4_from, box4_fsw, s4_count.ToString(), s4_record, box5_time, box7_yn, box9_yn);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createRD_RTVR_1(string header_district_name, string header_user_id, string header_division_name, string request_id, string pf_addressee, string pf_addressee_type, string requesting_employee, string track_authority_number, string track_authority_id, string employee_first, string employee_middle, string employee_last, string spaf_ack, string joint_occupancy, string ru_comments)
        {
            messages.RUM.RUM_RD_RTVR_1.createRD_RTVR_1(header_district_name, header_user_id, header_division_name, request_id, pf_addressee, pf_addressee_type, requesting_employee, track_authority_number, track_authority_id, employee_first, employee_middle, employee_last, joint_occupancy, spaf_ack, ru_comments);
        }


        /// <summary>
        /// RD-BIIQ, or the Bulletin Item Issue Request Message, is used by a remote user to request that a PDS dispatcher issue the bulletin identified in the message with the details specified.
        /// </summary>
        /// <param name="district_name">District where the bulletin is to be contained within.</param>
        /// <param name="requesting_employee">Employee ID of the requestor</param>
        /// <param name="requesting_employee_note">Note from requestor to dispatcher, not required.</param>
        /// <param name="bulletin_item_type">Bulletin item type name</param>
        /// <param name="effective_time">Requested effective date / time of creation or void. Absence implies current time. </param>
        /// <param name="bulletin_item_number_void">Unique identifier of the bulletin item to be voided as an issue-and-replace operation.</param>
        /// <param name="record">Piped delimited record string of format (field number)|(field name)|(field value). Organized by wrappers. (TBI)</param>
//        [UserCodeMethod]
//        public static void createRD_BIIQ_1(string district_name, string requesting_employee, string requesting_employee_note, string bulletin_item_type, string effective_time, string bulletin_item_number_void, string record)
//        {
//        	System.DateTime now = System.DateTime.Now;
//        	request_id++;
//        	string header_division_name = "Georgia";
//        	string pf_addressee = "000_CREW_SELF_PRINT";
//        	string pf_addressee_type = "E";
//        	string effective_date = now.ToString("MMddyyyy");
//        	string user_id = "AUTO";
//        	if (effective_time.Equals("Now")) {
//        		 effective_time = now.ToString("hh:mm tt");               	
//        	}
//        	string effective_time_zone = "E";
//        	messages.RUM.RUM_RD_BIIQ_1.createRD_BIIQ_1(district_name, user_id, header_division_name, request_id.ToString(), pf_addressee, pf_addressee_type, requesting_employee, requesting_employee_note, bulletin_item_type, effective_date, effective_time, effective_time_zone, bulletin_item_number_void, record);
//        }
//        
        [UserCodeMethod]
        public static string BIIQ_RecordPrep (string bulletin_item_type, string data_value1, string data_value2, string data_value3, string data_value4, string data_value5, string data_value6, string data_value7, string data_value8, string data_value9, string data_value10)
        {
        	string records = "";
        	switch (bulletin_item_type)
        	{
        		case "Speed - Area Restriction":
        			records = "1|Location_1|" + data_value1 + "|2|Location_2|" + data_value2 + "|3|Tracks|" + data_value3 + "|4|Max Speed|" + data_value4 + "|6|Issued by|" + data_value5;
        			return records;

        		case "Bad Footing - Area":
        			records = "1|Location_1|" + data_value1 + "|2|Location_2|" + data_value2 + "|3|Tracks|" + data_value3 + "|5|issued by|" + data_value5;
        			return records;
        			
        		case "Tracks Out of Service - Area":
        			records = "1|Location_1|" + data_value1 + "|2|Location_2|" + data_value2 + "|3|Tracks|" + data_value3 + "|4|300 fft account of|" + data_value6+ "|5|issued by|" + data_value5;
        			return records;

        		default:
        			Ranorex.Report.Error("Data Error", "Invalid Bulletin Type");
        			break;
        	}
        	return "";
        }
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
//        [UserCodeMethod]
//        public static void createRD_BINQ_1(string header_district_name, string header_user_id, string header_division_name, string request_id, string pf_addressee, string pf_addressee_type, string requesting_employee, string bulletin_item_number)
//        {
//            messages.RUM.RUM_RD_BINQ_1.createRD_BINQ_1(header_district_name, header_user_id, header_division_name, request_id, pf_addressee, pf_addressee_type, requesting_employee, bulletin_item_number);
//        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
//        [UserCodeMethod]
//        public static void createRD_BIVQ_1(string header_district_name, string header_user_id, string header_division_name, string request_id, string pf_addressee, string pf_addressee_type, string requesting_employee, string requesting_employee_note, string bulletin_item_number)
//        {
//            messages.RUM.RUM_RD_BIVQ_1.createRD_BIVQ_1(header_district_name, header_user_id, header_division_name, request_id, pf_addressee, pf_addressee_type, requesting_employee, requesting_employee_note, bulletin_item_number);
//        }
    }
}
