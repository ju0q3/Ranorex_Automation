/*
 * Created by Ranorex
 * User: 503036149
 * Date: 4/10/2019
 * Time: 3:46 PM
 *
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
    /// Description of NS_MIS_Messages.
    /// </summary>
    [UserCodeCollection]
    public class NS_MIS_Messages
    {

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        ///
        ///
        /// stations format is as follows with individual stations separated by a | between PTC_TRAIN_DEPARTURE and STATION_SEQ_NUM
        ///
        /// STATION_SEQ_NUM|STATION_LOCATION|DAY_OF_STA|STA_TIME|STA_ZONE|DAY_OF_STD|STD_TIME|STD_ZONE|CREW_CHANGE|crewLineSegment|
        /// setOut|PICKUP|FUEL|INSPECTION|PASSENGER_STOP|EXIT_TO_FOREIGN_RAILROAD|TURN_POINT|PTC_TRAIN_ARRIVAL|PTC_TRAIN_DEPARTURE
        /// </summary>
        [UserCodeMethod]
        public static void NS_SendCreateSchedule_43(string header_protocolid, string header_msgid, string header_trace_id, string header_message_version, string content_scac, string content_section,
                                                    string content_train_symbol, string content_origin_date_offset_days, string content_report_type, string content_train_category, string content_train_group,
                                                    string content_origin_location, string content_termination_location, string content_number_of_stations, string content_station, string hostname) {

            System.DateTime now = System.DateTime.Now;
            string content_origin_date;
            int content_origin_date_offset_int = 0;
            if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int) && content_origin_date_offset_days.Length < 8)
            {
                content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
            } else {
                content_origin_date = content_origin_date_offset_days;
            }

            string[] stations = content_station.Split('|');
            int numberOfRecords = stations.Length/19;
            for (int i = 0; i < numberOfRecords; i++)
            {
                int sta_time_offset_int = 0;
                if (Int32.TryParse(stations[i*19 + 3], out sta_time_offset_int) && stations[i*19 + 3].Length < 4)
                {
                    stations[i*19 + 3] = now.AddMinutes(sta_time_offset_int).ToString("HHmm");
                }
                int std_time_offset_int = 0;
                if (Int32.TryParse(stations[i*19 + 6], out std_time_offset_int) && stations[i*19 + 6].Length < 4)
                {
                    stations[i*19 + 6] = now.AddMinutes(std_time_offset_int).ToString("HHmm");
                }
            }
            content_station = string.Join("|", stations);

            //string content_train_symbol = PDS_CORE.Code_Utils.NS_TrainID.CreateTrainID(trainSeed, section, scac, originDay);
            //string originDate = NS_TrainID.getOriginDate(trainSeed);

            STE.Code_Utils.messages.MIS.NS.MIS_NS_TrainSchedule_43.createNS_TrainSchedule_43(header_protocolid, header_msgid, header_trace_id, header_message_version, content_scac, content_section,
                                                                                             content_train_symbol, content_origin_date, content_report_type, content_train_category, content_train_group,
                                                                                             content_origin_location, content_termination_location, content_number_of_stations, content_station, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        ///
        ///
        /// stations format is as follows with individual stations separated by a | between PTC_TRAIN_DEPARTURE and STATION_SEQ_NUM
        ///
        /// STATION_SEQ_NUM|STATION_LOCATION|DAY_OF_STA|STA_TIME|STA_ZONE|DAY_OF_STD|STD_TIME|STD_ZONE|CREW_CHANGE|crewLineSegment|
        /// setOut|PICKUP|FUEL|INSPECTION|PASSENGER_STOP|EXIT_TO_FOREIGN_RAILROAD|TURN_POINT|PTC_TRAIN_ARRIVAL|PTC_TRAIN_DEPARTURE
        /// </summary>
        [UserCodeMethod]
        public static void NS_SendCreateSchedule_43Simple(string trainSeed, string scac, string section, string originDateOffsetDays, string reportType, string trainCategory, string trainGroup,
                                                          string originLocation, string terminationLocation, string stations, string hostname) {

            System.DateTime now = System.DateTime.Now;
            string header_protocolid = "1";
            string header_msgid = "TrainSchedule";
            string header_trace_id = "1";
            string header_message_version = "0";

            string content_number_of_stations = "";

            if (originDateOffsetDays == "")
            {
                originDateOffsetDays = "0";
            }

            string content_train_symbol = NS_TrainID.CreateTrainID(trainSeed, section, scac, originDateOffsetDays);

            if (stations == "Defaults")
            {
                stations = "1|" + originLocation + "|00|"+now.ToString("HHmm")+"|E|00|"+now.ToString("HHmm")+"|E|N|G1|N|N|N|N|N|N|N|Empty|Empty" +
                    "|2|" + terminationLocation + "|00|"+now.ToString("HHmm")+"|E|00|"+now.ToString("HHmm")+"|E|N|G1|N|N|N|N|N|N|N|Empty|Empty";
                content_number_of_stations = "2";

                string staAndStd = now.ToString("MM-dd-yyyy hh:mm t") + " E";
                NS_TrainID.getTrainObject(trainSeed).AddTrainScheduleSTASTDRow(staAndStd, staAndStd);
                NS_TrainID.getTrainObject(trainSeed).AddTrainScheduleSTASTDRow(staAndStd, staAndStd);
            } else {
                string[] stationList = stations.Split('|');
                // TODO: Add logic to ensure record length is divisible by 19. If this should succeed despite erroneous record length, that's an input issue.
                int numberOfRecords = stationList.Length/19;
                for (int i = 0; i < numberOfRecords; i++)
                {
                    string formattedSta = "";
                    int sta_time_offset_int = 0;
                    int sta_date_offset_int = 0;
                    if (Int32.TryParse(stationList[i*19 + 3], out sta_time_offset_int) && stationList[i*19 + 3].Length < 4)
                    {
                        stationList[i*19 + 3] = now.AddMinutes(sta_time_offset_int).ToString("HHmm");

                        if (Int32.TryParse(stationList[i*19 + 2], out sta_date_offset_int))
                        {
                            formattedSta = now.AddDays(sta_date_offset_int).AddMinutes(sta_time_offset_int).ToString("MM-dd-yyyy hh:mm t") + " " + stationList[i*19 + 4];
                        }

                    } else {
                        if (Int32.TryParse(stationList[i*19 + 2], out sta_date_offset_int))
                        {
                            formattedSta = now.AddDays(sta_date_offset_int).ToString("MM-dd-yyyy");
                            System.DateTime exactTime;
                            CultureInfo enUS = new CultureInfo("en-US");
                            if (System.DateTime.TryParseExact(stationList[i*19 + 3], "HHmm", enUS, DateTimeStyles.None, out exactTime))
                            {
                                formattedSta = formattedSta + " " + exactTime.ToString("hh:mm t") + " " + stationList[i*19 + 4];
                            }
                        }
                    }
                    string formattedStd = "";
                    int std_time_offset_int = 0;
                    int std_date_offset_int = 0;
                    if (Int32.TryParse(stationList[i*19 + 6], out std_time_offset_int) && stationList[i*19 + 6].Length < 4)
                    {
                        stationList[i*19 + 6] = now.AddMinutes(std_time_offset_int).ToString("HHmm");

                        if (Int32.TryParse(stationList[i*19 + 5], out std_date_offset_int))
                        {
                            formattedStd = now.AddDays(std_date_offset_int).AddMinutes(std_time_offset_int).ToString("MM-dd-yyyy hh:mm t") + " " + stationList[i*19 + 7];
                        }
                    } else {
                        if (Int32.TryParse(stationList[i*19 + 5], out std_date_offset_int))
                        {
                            formattedStd = now.AddDays(std_date_offset_int).ToString("MM-dd-yyyy");
                            System.DateTime exactTime;
                            CultureInfo enUS = new CultureInfo("en-US");
                            if (System.DateTime.TryParseExact(stationList[i*19 + 6], "HHmm", enUS, DateTimeStyles.None, out exactTime))
                            {
                                formattedStd = formattedStd + " " + exactTime.ToString("hh:mm t") + " " + stationList[i*19 + 7];
                            }
                        }
                    }

                    //Adding STA and STD to Train Object
                    NS_TrainID.getTrainObject(trainSeed).AddTrainScheduleSTASTDRow(formattedSta, formattedStd);

                    if (stationList[i*19 + 8] == "")
                    {
                        stationList[i*19 + 8] = "Empty";
                    }
                    if (stationList[i*19 + 9] == "")
                    {
                        stationList[i*19 + 9] = "Empty";
                    }
                    if (stationList[i*19 + 10] == "")
                    {
                        stationList[i*19 + 10] = "Empty";
                    }
                    if (stationList[i*19 + 11] == "")
                    {
                        stationList[i*19 + 11] = "Empty";
                    }
                    if (stationList[i*19 + 12] == "")
                    {
                        stationList[i*19 + 12] = "Empty";
                    }
                    if (stationList[i*19 + 13] == "")
                    {
                        stationList[i*19 + 13] = "Empty";
                    }
                    if (stationList[i*19 + 14] == "")
                    {
                        stationList[i*19 + 14] = "Empty";
                    }
                    if (stationList[i*19 + 15] == "")
                    {
                        stationList[i*19 + 15] = "Empty";
                    }
                    if (stationList[i*19 + 16] == "")
                    {
                        stationList[i*19 + 16] = "Empty";
                    }
                    if (stationList[i*19 + 17] == "")
                    {
                        stationList[i*19 + 17] = "Empty";
                    }
                    if (stationList[i*19 + 18] == "")
                    {
                        stationList[i*19 + 18] = "Empty";
                    }
                }
                content_number_of_stations = numberOfRecords.ToString();
            }

            NS_SendCreateSchedule_43(header_protocolid, header_msgid, header_trace_id, header_message_version, scac, section,
                                     content_train_symbol, originDateOffsetDays, reportType, trainCategory, trainGroup,
                                     originLocation, terminationLocation, content_number_of_stations, stations, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        ///
        ///
        /// stations format is as follows with individual stations separated by a | between PTC_TRAIN_DEPARTURE and STATION_SEQ_NUM
        ///
        /// STATION_SEQ_NUM|STATION_LOCATION|DAY_OF_STA|STA_TIME|STA_ZONE|DAY_OF_STD|STD_TIME|STD_ZONE|CREW_CHANGE|crewLineSegment|
        /// setOut|PICKUP|FUEL|INSPECTION|PASSENGER_STOP|EXIT_TO_FOREIGN_RAILROAD|TURN_POINT|PTC_TRAIN_ARRIVAL|PTC_TRAIN_DEPARTURE
        /// </summary>
        [UserCodeMethod]
        public static void NS_SendCreateSchedule_43Simple_ExistingTrainId(string trainSeed, string reportType, string trainCategory, string trainGroup,
                                                                          string originLocation, string terminationLocation, string stations, string hostname) {

            System.DateTime now = System.DateTime.Now;
            string header_protocolid = "1";
            string header_msgid = "TrainSchedule";
            string header_trace_id = "1";
            string header_message_version = "0";

            string content_number_of_stations = "";

            string content_train_symbol = NS_TrainID.GetTrainSymbol(trainSeed);
            string scac = NS_TrainID.GetTrainSCAC(trainSeed);
            string section = NS_TrainID.GetTrainSection(trainSeed);
            string originDate = NS_TrainID.getOriginDate(trainSeed);

            if (originDate == "")
            {
                originDate = "0";
            }

            if (stations == "Defaults")
            {
                stations = "1|" + originLocation + "|00|"+now.ToString("HHmm")+"|E|00|"+now.ToString("HHmm")+"|E|N|G1|N|N|N|N|N|N|N|Empty|Empty" +
                    "|2|" + terminationLocation + "|00|"+now.ToString("HHmm")+"|E|00|"+now.ToString("HHmm")+"|E|N|G1|N|N|N|N|N|N|N|Empty|Empty";
                content_number_of_stations = "2";

                string staAndStd = now.ToString("MM-dd-yyyy hh:mm t") + " E";
                NS_TrainID.getTrainObject(trainSeed).AddTrainScheduleSTASTDRow(staAndStd, staAndStd);
                NS_TrainID.getTrainObject(trainSeed).AddTrainScheduleSTASTDRow(staAndStd, staAndStd);
            } else {
                string[] stationList = stations.Split('|');
                int numberOfRecords = stationList.Length/19;
                for (int i = 0; i < numberOfRecords; i++)
                {
                    string formattedSta = "";
                    int sta_time_offset_int = 0;
                    int sta_date_offset_int = 0;
                    if (Int32.TryParse(stationList[i*19 + 3], out sta_time_offset_int) && stationList[i*19 + 3].Length < 4)
                    {
                        stationList[i*19 + 3] = now.AddMinutes(sta_time_offset_int).ToString("HHmm");

                        if (Int32.TryParse(stationList[i*19 + 2], out sta_date_offset_int))
                        {
                            formattedSta = now.AddDays(sta_date_offset_int).AddMinutes(sta_time_offset_int).ToString("MM-dd-yyyy hh:mm t") + " " + stationList[i*19 + 4];
                        }

                    } else {
                        if (Int32.TryParse(stationList[i*19 + 2], out sta_date_offset_int))
                        {
                            formattedSta = now.AddDays(sta_date_offset_int).ToString("MM-dd-yyyy");
                            System.DateTime exactTime;
                            CultureInfo enUS = new CultureInfo("en-US");
                            if (System.DateTime.TryParseExact(stationList[i*19 + 3], "HHmm", enUS, DateTimeStyles.None, out exactTime))
                            {
                                formattedSta = formattedSta + " " + exactTime.ToString("hh:mm t") + " " + stationList[i*19 + 4];
                            }
                        }
                    }
                    string formattedStd = "";
                    int std_time_offset_int = 0;
                    int std_date_offset_int = 0;
                    if (Int32.TryParse(stationList[i*19 + 6], out std_time_offset_int) && stationList[i*19 + 6].Length < 4)
                    {
                        stationList[i*19 + 6] = now.AddMinutes(std_time_offset_int).ToString("HHmm");

                        if (Int32.TryParse(stationList[i*19 + 5], out std_date_offset_int))
                        {
                            formattedStd = now.AddDays(std_date_offset_int).AddMinutes(std_time_offset_int).ToString("MM-dd-yyyy hh:mm t") + " " + stationList[i*19 + 7];
                        }
                    } else {
                        if (Int32.TryParse(stationList[i*19 + 5], out std_date_offset_int))
                        {
                            formattedStd = now.AddDays(std_date_offset_int).ToString("MM-dd-yyyy");
                            System.DateTime exactTime;
                            CultureInfo enUS = new CultureInfo("en-US");
                            if (System.DateTime.TryParseExact(stationList[i*19 + 6], "HHmm", enUS, DateTimeStyles.None, out exactTime))
                            {
                                formattedStd = formattedStd + " " + exactTime.ToString("hh:mm t") + " " + stationList[i*19 + 7];
                            }
                        }
                    }

                    //Adding STA and STD to Train Object
                    NS_TrainID.getTrainObject(trainSeed).AddTrainScheduleSTASTDRow(formattedSta, formattedStd);

                    if (stationList[i*19 + 8] == "")
                    {
                        stationList[i*19 + 8] = "Empty";
                    }
                    if (stationList[i*19 + 9] == "")
                    {
                        stationList[i*19 + 9] = "Empty";
                    }
                    if (stationList[i*19 + 10] == "")
                    {
                        stationList[i*19 + 10] = "Empty";
                    }
                    if (stationList[i*19 + 11] == "")
                    {
                        stationList[i*19 + 11] = "Empty";
                    }
                    if (stationList[i*19 + 12] == "")
                    {
                        stationList[i*19 + 12] = "Empty";
                    }
                    if (stationList[i*19 + 13] == "")
                    {
                        stationList[i*19 + 13] = "Empty";
                    }
                    if (stationList[i*19 + 14] == "")
                    {
                        stationList[i*19 + 14] = "Empty";
                    }
                    if (stationList[i*19 + 15] == "")
                    {
                        stationList[i*19 + 15] = "Empty";
                    }
                    if (stationList[i*19 + 16] == "")
                    {
                        stationList[i*19 + 16] = "Empty";
                    }
                    if (stationList[i*19 + 17] == "")
                    {
                        stationList[i*19 + 17] = "Empty";
                    }
                    if (stationList[i*19 + 18] == "")
                    {
                        stationList[i*19 + 18] = "Empty";
                    }
                }
                content_number_of_stations = numberOfRecords.ToString();
            }
            
            NS_SendCreateSchedule_43(header_protocolid, header_msgid, header_trace_id, header_message_version, scac, section,
                                     content_train_symbol, originDate, reportType, trainCategory, trainGroup,
                                     originLocation, terminationLocation, content_number_of_stations, stations, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        ///
        ///
        /// stations format is as follows with individual stations separated by a | between PTC_TRAIN_DEPARTURE and STATION_SEQ_NUM
        ///
        /// STATION_SEQ_NUM|STATION_LOCATION|DAY_OF_STA|STA_TIME|STA_ZONE|DAY_OF_STD|STD_TIME|STD_ZONE|CREW_CHANGE|crewLineSegment|
        /// setOut|PICKUP|FUEL|INSPECTION|PASSENGER_STOP|EXIT_TO_FOREIGN_RAILROAD|TURN_POINT|PTC_TRAIN_ARRIVAL|PTC_TRAIN_DEPARTURE
        /// </summary>
        [UserCodeMethod]
        public static void NS_SendTrainSegment_48(string header_protocolid, string header_msgid, string header_trace_id, string header_message_version, string content_scac, string content_section,
                                                  string content_train_symbol, string content_origin_date_offset_days, string content_effective_location, string content_effective_pass_count, string content_date_offset_days,
                                                  string content_time_offset_minutes, string content_time_zone, string content_time_type, string content_train_origin, string content_train_destination, string hostname)
        {
            System.DateTime now = System.DateTime.Now;
            string content_origin_date;
            int content_origin_date_offset_int = 0;
            if (Int32.TryParse(content_origin_date_offset_days, out content_origin_date_offset_int) && content_origin_date_offset_days.Length < 8)
            {
                content_origin_date = now.AddDays(content_origin_date_offset_int).ToString("MMddyyyy");
            } else {
                content_origin_date = content_origin_date_offset_days;
            }

            string content_date;
            int content_date_offset_int = 0;
            if (Int32.TryParse(content_date_offset_days, out content_date_offset_int) && content_date_offset_days.Length < 8)
            {
                content_date = now.AddDays(content_date_offset_int).ToString("MMddyyyy");
            } else {
                content_date = content_date_offset_days;
            }

            string content_time;
            int content_time_offset_int = 0;
            if (Int32.TryParse(content_time_offset_minutes, out content_time_offset_int) && content_time_offset_minutes.Length < 8)
            {
                content_time = now.AddMinutes(content_time_offset_int).ToString("HHmm");
            } else {
                content_time = content_time_offset_minutes;
            }

            STE.Code_Utils.messages.MIS.NS.MIS_NS_TrainSegment_48.createNS_TrainSegment_48(header_protocolid, header_msgid, header_trace_id, header_message_version, content_scac, content_section, content_train_symbol, content_origin_date,
                                                                                           content_effective_location, content_effective_pass_count, content_date, content_time, content_time_zone, content_time_type, content_train_origin,
                                                                                           content_train_destination, hostname);
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        ///
        ///
        /// stations format is as follows with individual stations separated by a | between PTC_TRAIN_DEPARTURE and STATION_SEQ_NUM
        ///
        /// STATION_SEQ_NUM|STATION_LOCATION|DAY_OF_STA|STA_TIME|STA_ZONE|DAY_OF_STD|STD_TIME|STD_ZONE|CREW_CHANGE|crewLineSegment|
        /// setOut|PICKUP|FUEL|INSPECTION|PASSENGER_STOP|EXIT_TO_FOREIGN_RAILROAD|TURN_POINT|PTC_TRAIN_ARRIVAL|PTC_TRAIN_DEPARTURE
        /// </summary>
        [UserCodeMethod]
        public static void NS_SendTrainSegment_48Simple(string trainSeed, string content_effective_location, string content_effective_pass_count, string content_date_offset_days,
                                                        string content_time_offset_minutes, string content_time_zone, string content_time_type, string content_train_origin, string content_train_destination, string hostname)
        {
            System.DateTime now = System.DateTime.Now;
            string header_protocolid = "1";
            string header_msgid = "TrainSegment";
            string header_trace_id = "1";
            string header_message_version = "0";

            string content_train_symbol = NS_TrainID.GetTrainSymbol(trainSeed);
            string content_scac = NS_TrainID.GetTrainSCAC(trainSeed);
            string content_section = NS_TrainID.GetTrainSection(trainSeed);
            string originDate = NS_TrainID.getOriginDate(trainSeed);

            NS_SendTrainSegment_48(header_protocolid, header_msgid, header_trace_id, header_message_version, content_scac, content_section,
                                   content_train_symbol, originDate, content_effective_location, content_effective_pass_count, content_date_offset_days,
                                   content_time_offset_minutes, content_time_zone, content_time_type, content_train_origin, content_train_destination, hostname);
        }

        [UserCodeMethod]
        public static void NS_SendTrainConsistSummary_43(string header_protocolid, string header_msgid, string header_trace_id, string header_message_version, string content_scac_trainSeed, string content_section_trainSeed,
                                                         string content_train_symbol_trainSeed, string content_origin_date_trainSeed, string content_reporting_location, string content_reporting_pass_count, string content_reporting_date_offset_days,
                                                         string content_reporting_time_offset_minutes, string content_reporting_time_zone, string content_reporting_source, string content_number_of_tih_constraints,
                                                         string content_toxic_inhilation_hazard_constraint_record, string content_max_plate_size, string content_number_of_loads, string content_number_of_empties,
                                                         string content_trailing_tonnage, string content_train_length, string content_axles, string content_operative_brakes, string content_total_braking_force, string content_speed_class,
                                                         string content_number_of_max_car_weight_constraints, string content_max_car_weight_constrain_record, string content_number_of_max_car_height_constraints,
                                                         string content_max_car_height_constraint_record, string content_number_of_max_car_width_constraints, string content_max_car_width_constraint_record,
                                                         string content_number_of_hazmat_constraints, string content_hazmat_constraint_record, string optionalConsistRecordTrainSeed, string optionalConsistRecordConsistSeed, string hostname) {

            System.DateTime now = System.DateTime.Now;

            string content_train_symbol = NS_TrainID.GetTrainSymbol(content_train_symbol_trainSeed);
            if (content_train_symbol == null)
            {
                content_train_symbol = content_train_symbol_trainSeed;
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

            string content_reporting_date;
            int content_reporting_date_offset_int = 0;
            if (Int32.TryParse(content_reporting_date_offset_days, out content_reporting_date_offset_int) && content_reporting_date_offset_days.Length < 8)
            {
                content_reporting_date = now.AddDays(content_reporting_date_offset_int).ToString("MMddyyyy");
            } else {
                content_reporting_date = content_reporting_date_offset_days;
            }

            string content_reporting_time;
            int content_reporting_time_offset_int = 0;
            if (Int32.TryParse(content_reporting_time_offset_minutes, out content_reporting_time_offset_int) && content_reporting_time_offset_minutes.Length < 4)
            {
                content_reporting_time = now.AddMinutes(content_reporting_time_offset_int).ToString("HHmm");
            } else {
                content_reporting_time = content_reporting_time_offset_minutes;
            }

            if (!string.IsNullOrEmpty(optionalConsistRecordConsistSeed))
            {
                PDS_CORE.Code_Utils.NS_TrainID.CreateConsistSummaryRecord(optionalConsistRecordTrainSeed, optionalConsistRecordConsistSeed, content_reporting_location, content_reporting_pass_count, content_reporting_source, content_speed_class, content_max_plate_size,
                                                                          content_number_of_loads, content_number_of_empties, content_trailing_tonnage, content_train_length, content_axles, content_operative_brakes, content_total_braking_force,
                                                                          content_max_car_weight_constrain_record, content_max_car_height_constraint_record, content_max_car_width_constraint_record,
                                                                          content_hazmat_constraint_record, content_toxic_inhilation_hazard_constraint_record);
            }
            else
                return; //please talk to maris before deleting again

            STE.Code_Utils.messages.MIS.NS.MIS_NS_TrainConsistSummary_43.createNS_TrainConsistSummary_43(header_protocolid, header_msgid, header_trace_id, header_message_version, content_scac, content_section,
                                                                                                         content_train_symbol, content_origin_date, content_reporting_location, content_reporting_pass_count,
                                                                                                         content_reporting_date, content_reporting_time, content_reporting_time_zone, content_reporting_source,
                                                                                                         content_number_of_tih_constraints, content_toxic_inhilation_hazard_constraint_record, content_max_plate_size,
                                                                                                         content_number_of_loads, content_number_of_empties, content_trailing_tonnage, content_train_length, content_axles,
                                                                                                         content_operative_brakes, content_total_braking_force, content_speed_class, content_number_of_max_car_weight_constraints,
                                                                                                         content_max_car_weight_constrain_record, content_number_of_max_car_height_constraints,
                                                                                                         content_max_car_height_constraint_record, content_number_of_max_car_width_constraints,
                                                                                                         content_max_car_width_constraint_record, content_number_of_hazmat_constraints, content_hazmat_constraint_record, hostname);
        }

        [UserCodeMethod]
        public static void NS_SendTrainConsistSummary_43Simple(string trainSeed, string consistSeed, string reportingLocation, string reportingPassCount, string reportingSource, string tihConstraintRecord, string maxPlateSize,
                                                               string numberOfLoads, string numberOfEmpties, string trailingTonnage, string trainLength, string axles, string operativeBrakes, string totalBrakingForce,
                                                               string speedClass, string maxCarWeightConstraintRecord, string maxCarHeightConstraintRecord, string maxCarWidthConstraintRecord, string hazmatConstraintRecord,
                                                               string hostname)
        {
            string header_protocolid = "1";
            string header_msgid = "TrainConsistSummary";
            string header_trace_id = "1";
            string header_message_version = "0";

            string content_scac_trainSeed = trainSeed;
            string content_section_trainSeed = trainSeed;
            string content_train_symbol_trainSeed = trainSeed;
            string content_origin_date_trainSeed = trainSeed;
            string optionalConsistRecordTrainSeed = trainSeed;
            string optionalConsistRecordConsistSeed = consistSeed;

            string content_reporting_date_offset_days = "";
            string content_reporting_time_offset_minutes = "";
            string content_reporting_time_zone = "";

            string content_number_of_tih_constraints = (tihConstraintRecord.Split('|').Length/3).ToString();
            string content_number_of_max_car_weight_constraints = (maxCarWeightConstraintRecord.Split('|').Length/3).ToString();
            string content_number_of_max_car_height_constraints = (maxCarHeightConstraintRecord.Split('|').Length/3).ToString();
            string content_number_of_max_car_width_constraints = (maxCarWidthConstraintRecord.Split('|').Length/3).ToString();
            string content_number_of_hazmat_constraints = (hazmatConstraintRecord.Split('|').Length/3).ToString();

            NS_SendTrainConsistSummary_43(header_protocolid, header_msgid, header_trace_id, header_message_version, content_scac_trainSeed, content_section_trainSeed, content_train_symbol_trainSeed, content_origin_date_trainSeed, reportingLocation,
                                          reportingPassCount, content_reporting_date_offset_days, content_reporting_time_offset_minutes, content_reporting_time_zone, reportingSource, content_number_of_tih_constraints,
                                          tihConstraintRecord, maxPlateSize, numberOfLoads, numberOfEmpties, trailingTonnage, trainLength, axles, operativeBrakes, totalBrakingForce, speedClass,
                                          content_number_of_max_car_weight_constraints, maxCarWeightConstraintRecord, content_number_of_max_car_height_constraints, maxCarHeightConstraintRecord,
                                          content_number_of_max_car_width_constraints, maxCarWidthConstraintRecord, content_number_of_hazmat_constraints, hazmatConstraintRecord, optionalConsistRecordTrainSeed, optionalConsistRecordConsistSeed, hostname);
        }

        [UserCodeMethod]
        public static void NS_SendRemedyBulletin_48(string header_protocolid, string header_msgid, string header_trace_id, string header_message_version, string content_event_date_offset_days, string content_event_time_offset_minutes,
                                                    string content_sequence_number, string content_division_name, string content_district_name, string content_source, string content_source_id, string content_action, string content_comments,
                                                    string content_bulletin_item_type, string content_effective_date_offset_days, string content_effective_time_offset_minutes, string content_effective_time_zone, string content_bulletin_item_number_bulletinSeed,
                                                    string content_bulletin_unique_id_bulletinSeed, string content_field_count, string content_field_record, string hostname) {

            System.DateTime now = System.DateTime.Now;

            string content_event_date;
            int content_event_date_offset_int = 0;
            if (Int32.TryParse(content_event_date_offset_days, out content_event_date_offset_int) && content_event_date_offset_days.Length < 8)
            {
                content_event_date = now.AddDays(content_event_date_offset_int).ToString("MMddyyyy");
            } else {
                content_event_date = content_event_date_offset_days;
            }

            string content_event_time;
            int content_event_time_offset_int = 0;
            if (Int32.TryParse(content_event_time_offset_minutes, out content_event_time_offset_int) && content_event_time_offset_minutes.Length < 4)
            {
                content_event_time = now.AddMinutes(content_event_time_offset_int).ToString("HHmmss");
            } else {
                content_event_time = content_event_time_offset_minutes;
            }

            string content_effective_date;
            int content_effective_date_offset_int = 0;
            if (Int32.TryParse(content_effective_date_offset_days, out content_effective_date_offset_int) && content_effective_date_offset_days.Length < 8)
            {
                content_effective_date = now.AddDays(content_effective_date_offset_int).ToString("MMddyyyy");
            } else {
                content_effective_date = content_effective_date_offset_days;
            }

            string content_effective_time;
            int content_effective_time_offset_int = 0;
            if (Int32.TryParse(content_effective_time_offset_minutes, out content_effective_time_offset_int) && content_effective_time_offset_minutes.Length < 4)
            {
                content_effective_time = now.AddMinutes(content_effective_time_offset_int).ToString("HHmm");
            } else {
                content_effective_time = content_effective_time_offset_minutes;
            }

            string content_bulletin_item_number = NS_Bulletin.GetBulletinNumber(content_bulletin_item_number_bulletinSeed);
            if (content_bulletin_item_number == null)
            {
                content_bulletin_item_number = content_bulletin_item_number_bulletinSeed;
            }
            string content_bulletin_unique_id = NS_Bulletin.GetBulletinId(content_bulletin_unique_id_bulletinSeed);
            if (content_bulletin_unique_id == null)
            {
                content_bulletin_unique_id = content_bulletin_unique_id_bulletinSeed;
            }

            STE.Code_Utils.messages.MIS.NS.MIS_NS_RemedyBulletin_48.createNS_RemedyBulletin_48(header_protocolid, header_msgid, header_trace_id, header_message_version, content_event_date, content_event_time, content_sequence_number, content_division_name,
                                                                                               content_district_name, content_source, content_source_id, content_action, content_comments, content_bulletin_item_type, content_effective_date, content_effective_time,
                                                                                               content_effective_time_zone, content_bulletin_item_number, content_bulletin_unique_id, content_field_count, content_field_record, hostname);
        }
        [UserCodeMethod]
        public static void NS_SendRemedyBulletin_48ExistingBulletinObjectSimple(string bulletinSeed, string division, string district, string source, string sourceId, string action, string comments, string bulletinItemType,
                                                                                string fieldRecord, string hostname) {

            string header_protocolid = "1";
            string header_msgid = "RemedyBulletin";
            string header_trace_id = "1";
            string header_message_version = "0";
            string content_sequence_number = "Default";
            string content_event_date_offset_days = "0";
            string content_event_time_offset_minutes = "0";

            string content_bulletin_item_number_bulletinSeed = bulletinSeed;
            string content_bulletin_unique_id_bulletinSeed = bulletinSeed;
            string content_effective_date_offset_days = "";
            string content_effective_time_offset_minutes = "";
            string content_effective_time_zone = "";

            string content_field_count = (fieldRecord.Split('|').Length/3).ToString();

            NS_SendRemedyBulletin_48(header_protocolid, header_msgid, header_trace_id, header_message_version, content_event_date_offset_days, content_event_time_offset_minutes,
                                     content_sequence_number, division, district, source, sourceId, action, comments,
                                     bulletinItemType, content_effective_date_offset_days, content_effective_time_offset_minutes, content_effective_time_zone,
                                     content_bulletin_item_number_bulletinSeed, content_bulletin_unique_id_bulletinSeed, content_field_count, fieldRecord, hostname);
        }
        [UserCodeMethod]
        public static void NS_SendRemedyBulletin_48Simple(string bulletinSeed, string division, string district, string sequence_number, string source, string sourceId, string action, string comments, string bulletinItemType,
                                                          string fieldRecord,string bulletinSeedVoid, string effectiveDateOffsetDays, string hostname) {

            string header_protocolid = "1";
            string header_msgid = "RemedyBulletin";
            string header_trace_id = "1";
            string header_message_version = "0";
            string content_sequence_number = sequence_number;
            string content_event_date_offset_days = "0";
            string content_event_time_offset_minutes = "0";
            string adms_bulletin_number = ADMSEnvironment.GetBulletinLatestNumber_ADMS();
            string content_bulletin_unique_id_bulletinSeed = "Null";
            string content_effective_date_offset_days = (effectiveDateOffsetDays == "") ? "0" : effectiveDateOffsetDays;
            // Corner case with effective time becoming historical before bulletin issue
            string content_effective_time_offset_minutes = (System.DateTime.Now.Second < 40) ? "1" : "2"; 
            string content_effective_time_zone = "";
            string content_bulletin_item_number_bulletinSeed = "";
            string content_field_count = "";
            string dot_crossing_id = "";
            int bulletin_no_int = 0;

            Int32.TryParse(adms_bulletin_number, out bulletin_no_int);
            bulletin_no_int = bulletin_no_int + 1;

            string bulletin_item_number_obj = bulletin_no_int.ToString();
            string remedyBulletinUniqueIdStatus = CDMSEnvironment.GetCommonConfigValue_CDMS("RST_REMEDY_UNIQUE_ID_CONFIG");
            if(action == "1" && string.IsNullOrEmpty(bulletinSeedVoid))
            {
                Report.Info("Remedy bulletin issue.");
                content_bulletin_item_number_bulletinSeed = "";
            }
            else if(action == "1" && !string.IsNullOrEmpty(bulletinSeedVoid))
            {
                content_bulletin_item_number_bulletinSeed = NS_Bulletin.GetBulletinNumber(bulletinSeedVoid);
                Report.Info("Bulletin number to Issue and Replace: "+ content_bulletin_item_number_bulletinSeed);
                if(remedyBulletinUniqueIdStatus == "2")
                {
                    content_bulletin_unique_id_bulletinSeed = bulletinSeedVoid;
                }
            }
            else if(action == "2")
            {
                content_bulletin_item_number_bulletinSeed = NS_Bulletin.GetBulletinNumber(bulletinSeedVoid);
                Report.Info("Bulletin number to void: "+ content_bulletin_item_number_bulletinSeed);
                if(remedyBulletinUniqueIdStatus == "2")
                {
                    content_bulletin_unique_id_bulletinSeed = bulletinSeedVoid;
                }
            }
            else
            {
                Ranorex.Report.Warn("Given action value not correct to perform issue, issue replace or void remedy bulletin.");
            }

            if(!string.IsNullOrEmpty(fieldRecord))
            {
                string[] fieldRecordList = fieldRecord.Split('|');
                content_field_count = (fieldRecordList.Length/3).ToString();
                dot_crossing_id = fieldRecordList[2];
            }
            else
            {
                content_field_count = "0";
                dot_crossing_id = "";
            }
            NS_SendRemedyBulletin_48(header_protocolid, header_msgid, header_trace_id, header_message_version, content_event_date_offset_days, content_event_time_offset_minutes,
                                     content_sequence_number, division, district, source, sourceId, action, comments,
                                     bulletinItemType, content_effective_date_offset_days, content_effective_time_offset_minutes, content_effective_time_zone,
                                     content_bulletin_item_number_bulletinSeed, content_bulletin_unique_id_bulletinSeed, content_field_count, fieldRecord, hostname);


            NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletin_item_number_obj, bulletinItemType, "", "", district, "", "");
        }

        [UserCodeMethod]
        public static void NS_SendCrewMember_48Simple(
            string trainSeed, string crewSeed, string crewID, string crewLineSegment, string sequenceNumber, string crewMemberRecords, string hostname = "local"
           ) {
            string header_protocolid = "1";
            string header_msgid = "CrewMember";
            string header_trace_id = "1";
            string header_message_version = "0";

            string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
            string scac = NS_TrainID.GetTrainSCAC(trainSeed);
            string section = NS_TrainID.GetTrainSection(trainSeed);
            string originDate = NS_TrainID.getOriginDate(trainSeed);

            //Code to refactor the Member Records
            string localMemberRecords = NS_CrewClass.RefactorAndCreateCrewMemberObject_CrewMemberRecords(crewSeed, crewMemberRecords, crewID, crewLineSegment);

            string numberCrewRecords = !string.IsNullOrEmpty(localMemberRecords) ? (localMemberRecords.Split('|').Length/34).ToString() : "0";

            STE.Code_Utils.messages.MIS.NS.MIS_NS_CrewMember_48.createNS_CrewMember_48(
                header_protocolid: header_protocolid, header_msgid: header_msgid, header_trace_id: header_trace_id, header_message_version: header_message_version,
                content_scac: scac, content_section: section, content_train_symbol: trainSymbol, content_origin_date: originDate, content_crew_id: crewID, content_crew_line_segment: crewLineSegment,
                content_sequence_number: sequenceNumber, content_number_of_crew_members: numberCrewRecords, content_crew_member_record: localMemberRecords, hostname: hostname
               );

        }

        [UserCodeMethod]
        public static void NS_SendTrainConsistActivity_48Simple(
            string trainSeed, string location, string passCount, string reportingSource, string estimatedDwellInterval, string maxCarWeightConstraintIndicator,
            string maxCarWeight, string maxCarWeightTo, string maxCarWeightToPassCount, string maxCarHeightConstraintIndicator, string maxCarHeight, string maxCarHeightTo,
            string maxCarHeightToPassCount, string maxCarWidthConstraintIndicator, string maxCarWidth, string maxCarWidthTo, string maxCarWidthToPassCount,
            string hazmatTrainConstraintIndicator, string keyTrainIndicator, string hazmatTrainTo, string hazmatTrainToPassCount, string pickupsetOutRecords,
            string coalClassificationRecords, string hostname
           ) {
            string header_protocolid = "1";
            string header_msgid = "TrainConsistActivity";
            string header_trace_id = "1";
            string header_message_version = "0";

            string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
            string scac = NS_TrainID.GetTrainSCAC(trainSeed);
            string section = NS_TrainID.GetTrainSection(trainSeed);
            string originDate = NS_TrainID.getOriginDate(trainSeed);

            string numberPickupSetoutRecords = !string.IsNullOrEmpty(pickupsetOutRecords) ? (pickupsetOutRecords.Split('|').Length/17).ToString() : "0";
            string numberCoalClassificationRecords = !string.IsNullOrEmpty(coalClassificationRecords) ? (coalClassificationRecords.Split('|').Length/2).ToString() : "0";

            string[] recordArray = pickupsetOutRecords.Split('|');
            int elementCount = 17;
            if (recordArray.Length % elementCount != 0)
            {
                Report.Error(string.Format("The pickup setout records have an invalid length of '{0}'. Please check bindings, and try again.", recordArray.Length.ToString()));
                return;
            }

            if (numberPickupSetoutRecords != "0")
            {
                System.DateTime now = System.DateTime.Now;
                for (int i = 0; i < recordArray.Length; i+=elementCount)
                {
                    double ctime;
                    string completeTimeValue = recordArray[i + 10];
                    if (double.TryParse(completeTimeValue, out ctime))
                    {
                        System.DateTime complete_date_time = now.AddMinutes(ctime);
                        string complete_date = complete_date_time.ToString("MMddyyyy");
                        string complete_time = complete_date_time.ToString("HHmm");
                        recordArray[i + 10] = complete_date + "|" + complete_time;
                    } else {
                        recordArray[i + 10] = "|";
                    }

                    double ntime;
                    string needTimeValue = recordArray[i + 12];
                    if (double.TryParse(needTimeValue, out ntime))
                    {
                        System.DateTime need_date_time = now.AddMinutes(ntime);
                        string need_date = need_date_time.ToString("MMddyyyy");
                        string need_time = need_date_time.ToString("HHmm");
                        recordArray[i + 12] = need_date + "|" + need_time;
                    } else {
                        recordArray[i + 12] = "|";
                    }
                }
            }

            string outPickupSetoutRecords = string.Join("|", recordArray);

            STE.Code_Utils.messages.MIS.NS.MIS_NS_TrainConsistActivity_48.createNS_TrainConsistActivity_48(
                header_protocolid: header_protocolid, header_msgid: header_msgid, header_trace_id: header_trace_id, header_message_version: header_message_version,
                content_scac: scac, content_section: section, content_train_symbol: trainSymbol, content_origin_date: originDate, content_location: location,
                content_pass_count: passCount, content_reporting_source: reportingSource, content_estimated_dwell_interval: estimatedDwellInterval,
                content_max_car_weight_constraint_indicator: maxCarWeightConstraintIndicator, content_max_car_weight: maxCarWeight, content_max_car_weight_to: maxCarWeightTo,
                content_max_car_weight_to_pass_count: maxCarWeightToPassCount, content_max_car_height_constraint_indicator: maxCarHeightConstraintIndicator, content_max_car_height: maxCarHeight,
                content_max_car_height_to: maxCarHeightTo, content_max_car_height_to_pass_count: maxCarHeightToPassCount, content_max_car_width_constraint_indicator: maxCarWidthConstraintIndicator,
                content_max_car_width: maxCarWidth, content_max_car_width_to: maxCarWidthTo, content_max_car_width_to_pass_count: maxCarWidthToPassCount,
                content_hazmat_train_constraint_indicator: hazmatTrainConstraintIndicator, content_key_train_indicator: keyTrainIndicator, content_hazmat_train_to: hazmatTrainTo,
                content_hazmat_train_to_pass_count: hazmatTrainToPassCount, content_number_of_pickup_setout_records: numberPickupSetoutRecords,
                content_pickup_setout_record: outPickupSetoutRecords, content_number_of_coal_classification_records: "", content_coal_classification_record: coalClassificationRecords, hostname: hostname
               );
        }

        [UserCodeMethod]
        public static void NS_SendEOTCaboose_48Simple(string trainSeed, string equipmentCode, string origin, string destination, string initial, string number, string workingStatus, string hostname)
        {
            string scac = NS_TrainID.GetTrainSCAC(trainSeed);
            string section = NS_TrainID.GetTrainSection(trainSeed);
            string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
            string originDate = NS_TrainID.getOriginDate(trainSeed);

            string header_protocolid = "1";
            string header_msgid = "EOTCaboose";
            string header_trace_id = "1";
            string header_message_version = "0";

            STE.Code_Utils.messages.MIS.NS.MIS_NS_EOTCaboose_48.createNS_EOTCaboose_48(
                header_protocolid: header_protocolid, header_msgid: header_msgid, header_trace_id: header_trace_id, header_message_version: header_message_version,
                content_scac: scac, content_section: section, content_train_symbol: trainSymbol, content_origin_date: originDate, content_equipment_code: equipmentCode,
                content_origin: origin, content_destination: destination, content_initial: initial, content_number: number, content_working_status: workingStatus, hostname: hostname
               );
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        ///
        ///
        /// stations format is as follows with individual stations separated by a | between PTC_TRAIN_DEPARTURE and STATION_SEQ_NUM
        ///
        /// STATION_SEQ_NUM|STATION_LOCATION|DAY_OF_STA|STA_TIME|STA_ZONE|DAY_OF_STD|STD_TIME|STD_ZONE|CREW_CHANGE|crewLineSegment|
        /// setOut|PICKUP|FUEL|INSPECTION|PASSENGER_STOP|EXIT_TO_FOREIGN_RAILROAD|TURN_POINT|PTC_TRAIN_ARRIVAL|PTC_TRAIN_DEPARTURE
        /// </summary>
        [UserCodeMethod]
        public static void NS_SendEngineConsist_48(string header_protocolid, string header_msgid, string header_trace_id, string header_message_version, string content_scac_trainSeed, string content_section_trainSeed,
                                                   string content_train_symbol_trainSeed, string content_origin_date_trainSeed, string content_assigned_division, string content_helper_crew_pool_id,
                                                   string content_reporting_source, string content_reporting_location, string content_reporting_pass_count, string content_default_data_applied,
                                                   string content_purpose, string content_number_of_engines, string content_engine_record, string optionalTrainSeed, string optionalEngineSeeds, string hostname) {

            string content_train_symbol = NS_TrainID.GetTrainSymbol(content_train_symbol_trainSeed);
            if (content_train_symbol == null)
            {
                content_train_symbol = content_train_symbol_trainSeed;
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

            System.DateTime now = System.DateTime.Now;

            string[] splitEngineRecords = content_engine_record.Split('|');
            int splitLengthOfEngineRecord = splitEngineRecords.Length;
            int currentRecordSize = 26;

            if (splitLengthOfEngineRecord%currentRecordSize != 0)
            {
                Ranorex.Report.Error("Engine Record is not divisible by " + currentRecordSize + ", total size of record is {" + splitLengthOfEngineRecord + "}");
                return;
            }

            int numberOfEngineRecords = splitLengthOfEngineRecord/currentRecordSize;
            for (int i = 0; i < splitLengthOfEngineRecord; i = i + currentRecordSize)
            {
                int next_service_date_offset_int = 0;
                if (Int32.TryParse(splitEngineRecords[i+19], out next_service_date_offset_int) && splitEngineRecords[i+19].Length < 8)
                {
                    splitEngineRecords[i+19] = now.AddDays(next_service_date_offset_int).ToString("MMddyyyy");
                }

                int fra_test_due_date_offset_int = 0;
                if (Int32.TryParse(splitEngineRecords[i+22], out fra_test_due_date_offset_int) && splitEngineRecords[i+22].Length < 8)
                {
                    splitEngineRecords[i+22] = now.AddDays(fra_test_due_date_offset_int).ToString("MMddyyyy");
                }

                int last_fuel_date_offset_int = 0;
                if (Int32.TryParse(splitEngineRecords[i+24], out last_fuel_date_offset_int) && splitEngineRecords[i+24].Length < 8)
                {
                    splitEngineRecords[i+24] = now.AddDays(last_fuel_date_offset_int).ToString("MMddyyyy");
                }
            }

            content_engine_record = string.Join("|", splitEngineRecords);

        	if (optionalEngineSeeds != "" && optionalTrainSeed != "")
        	{
        	    string[] splitEngineSeeds = optionalEngineSeeds.Split('|');
        	    int lengthOfForLoop = 0;
        	    if (numberOfEngineRecords == splitEngineSeeds.Length)
        	    {
        	    	lengthOfForLoop = splitEngineSeeds.Length;
        	    } else if(numberOfEngineRecords > splitEngineSeeds.Length)
    	        {
    	            Report.Error("Number of engine records exceeds number of engineSeeds, some engines will not have associated seeds");
    	            lengthOfForLoop = splitEngineSeeds.Length;
    	        } else {
    	            Report.Error("Number of engine seeds exceeds number of engineRecords, some engineSeeds will not have associated engines");
    	            lengthOfForLoop = numberOfEngineRecords;
    	        }

    	        for (int i = 0; i < lengthOfForLoop; i++)
	            {
	                string[] subArray = new String[26];
	                Array.Copy(splitEngineRecords, i*26, subArray, 0, 26);
	                NS_EngineConsistObject EngineObject = NS_TrainID.CreateEngineConsistRecord(optionalTrainSeed, splitEngineSeeds[i], string.Join("|", subArray), content_assigned_division, content_helper_crew_pool_id, content_default_data_applied, content_reporting_pass_count, content_reporting_location, content_reporting_source, content_purpose);
	            }
        	}

            STE.Code_Utils.messages.MIS.NS.MIS_NS_EngineConsist_48.createNS_EngineConsist_48(header_protocolid, header_msgid, header_trace_id, header_message_version, content_scac, content_section,
                                                                                             content_train_symbol, content_origin_date, content_assigned_division, content_helper_crew_pool_id,
                                                                                             content_reporting_source, content_reporting_location, content_reporting_pass_count, content_default_data_applied,
                                                                                             content_purpose, content_number_of_engines, content_engine_record, hostname);
        }

        [UserCodeMethod]
        public static void NS_SendEngineConsist_48Simple(string trainSeed, string engineSeeds, string content_assigned_division, string content_helper_crew_pool_id,
                                                         string content_reporting_source, string content_reporting_location, string content_reporting_pass_count, string content_default_data_applied,
                                                         string content_purpose, string content_engine_record, string hostname)
        {
            string header_protocolid = "1";
            string header_msgid = "TrainEngineConsist";
            string header_trace_id = "1";
            string header_message_version = "0";

            string content_scac_trainSeed = trainSeed;
            string content_section_trainSeed = trainSeed;
            string content_train_symbol_trainSeed = trainSeed;
            string content_origin_date_trainSeed = trainSeed;
            string content_number_of_engines = (content_engine_record.Split('|').Length/26).ToString();

            NS_SendEngineConsist_48(header_protocolid, header_msgid, header_trace_id, header_message_version, content_scac_trainSeed, content_section_trainSeed,
                                    content_train_symbol_trainSeed, content_origin_date_trainSeed, content_assigned_division, content_helper_crew_pool_id,
                                    content_reporting_source, content_reporting_location, content_reporting_pass_count, content_default_data_applied,
                                    content_purpose, content_number_of_engines, content_engine_record, trainSeed, engineSeeds, hostname);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void NS_SendTrainDelay_48(string header_protocolid, string header_msgid, string header_trace_id, string header_message_version, string content_scac_trainSeed, string content_section_trainSeed, 
                                                string content_train_symbol_trainSeed, string content_origin_date_trainSeed, string content_from_division_number, string content_from_division, string content_from_district, 
                                                string content_from_location_type, string content_from_location, string content_end_division_number, string content_end_division, string content_end_district, string content_end_location_type, 
                                                string content_end_location, string content_delay_record_id, string content_delay_code, string content_transmission_type, string content_user_id, string content_source_system,
                                                string content_begin_delay_date_offset_days, string content_begin_delay_time_offset_minutes, string content_begin_delay_time_zone, string content_end_delay_date_offset_days, string content_end_delay_time_offset_minutes,
                                                string content_end_delay_time_zone, string content_delay_duration_offset_minutes, string content_crew_id_crewSeed, string content_crew_line_segment_crewSeed, string content_free_form_text, string content_field_1,
                                                string content_field_2, string content_field_3, string content_field_4, string content_field_5, string content_field_6, string content_field_7, string content_field_8, string hostname) 
        {
            System.DateTime now = System.DateTime.Now;
            
            string content_train_symbol = NS_TrainID.GetTrainSymbol(content_train_symbol_trainSeed);
            if (content_train_symbol == null)
            {
                content_train_symbol = content_train_symbol_trainSeed;
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
            
            string content_begin_delay_date;
            int content_begin_delay_date_offset_int = 0;
            if (Int32.TryParse(content_begin_delay_date_offset_days, out content_begin_delay_date_offset_int) && content_begin_delay_date_offset_days.Length < 8)
            {
                content_begin_delay_date = now.AddDays(content_begin_delay_date_offset_int).ToString("MMddyyyy");
            } else {
                content_begin_delay_date = content_begin_delay_date_offset_days;
            }
            string content_begin_delay_time;
            int content_begin_delay_time_offset_int = 0;
            if (Int32.TryParse(content_begin_delay_time_offset_minutes, out content_begin_delay_time_offset_int) && content_begin_delay_time_offset_minutes.Length < 4)
            {
                content_begin_delay_time = now.AddMinutes(content_begin_delay_time_offset_int).ToString("HHmm");
            } else {
                content_begin_delay_time = content_begin_delay_time_offset_minutes;
            }
            string content_end_delay_date;
            int content_end_delay_date_offset_int = 0;
            if (Int32.TryParse(content_end_delay_date_offset_days, out content_end_delay_date_offset_int) && content_end_delay_date_offset_days.Length < 8)
            {
                content_end_delay_date = now.AddDays(content_end_delay_date_offset_int).ToString("MMddyyyy");
            } else {
                content_end_delay_date = content_end_delay_date_offset_days;
            }
            string content_end_delay_time;
            int content_end_delay_time_offset_int = 0;
            if (Int32.TryParse(content_end_delay_time_offset_minutes, out content_end_delay_time_offset_int) && content_end_delay_time_offset_minutes.Length < 4)
            {
                content_end_delay_time = now.AddMinutes(content_end_delay_time_offset_int).ToString("HHmm");
            } else {
                content_end_delay_time = content_end_delay_time_offset_minutes;
            }
            string content_delay_duration;
            double content_delay_duration_offset_double = 0;
            if (Double.TryParse(content_delay_duration_offset_minutes, out content_delay_duration_offset_double) && content_delay_duration_offset_minutes.Length < 4)
            {
            	content_delay_duration = TimeSpan.FromMinutes(content_delay_duration_offset_double).ToString(@"hhmm");
            } else {
            	content_delay_duration = content_delay_duration_offset_minutes;
            }
            
            string content_crew_id = NS_CrewClass.GetCrewMemberEmployeeId(content_crew_id_crewSeed);
            if (content_crew_id == null)
            {
                content_crew_id = content_crew_id_crewSeed;
            }
            string content_crew_line_segment = NS_CrewClass.GetCrewMemberLineSegment(content_crew_line_segment_crewSeed);
            if (content_crew_line_segment == null)
            {
                content_crew_line_segment = content_crew_line_segment_crewSeed;
            }
            
            
            STE.Code_Utils.messages.MIS.NS.MIS_NS_TrainDelay_48.createNS_TrainDelay_48(header_protocolid, header_msgid, header_trace_id, header_message_version, content_scac, content_section, content_train_symbol, 
                                                                                    content_origin_date, content_from_division_number, content_from_division, content_from_district, content_from_location_type, 
                                                                                    content_from_location, content_end_division_number, content_end_division, content_end_district, content_end_location_type, 
                                                                                    content_end_location, content_delay_record_id, content_delay_code, content_transmission_type, content_user_id, content_source_system, 
                                                                                    content_begin_delay_date, content_begin_delay_time, content_begin_delay_time_zone, content_end_delay_date, content_end_delay_time, 
                                                                                    content_end_delay_time_zone, content_delay_duration, content_crew_id, content_crew_line_segment, content_free_form_text, content_field_1, 
                                                                                    content_field_2, content_field_3, content_field_4, content_field_5, content_field_6, content_field_7, content_field_8, hostname);
        }
        
        [UserCodeMethod]
        public static void NS_SendTrainDelay_48Simple(string trainSeed, string crewSeed, string content_from_division_number, string content_from_division, string content_from_district, 
                                                string content_from_location_type, string content_from_location, string content_end_division_number, string content_end_division, string content_end_district, string content_end_location_type, 
                                                string content_end_location, string content_delay_record_id, string content_delay_code, string content_transmission_type, string content_user_id, string content_source_system,
                                                string content_begin_delay_date_offset_days, string content_begin_delay_time_offset_minutes, string content_begin_delay_time_zone, string content_end_delay_date_offset_days, string content_end_delay_time_offset_minutes,
                                                string content_end_delay_time_zone, string content_delay_duration_offset_minutes, string content_free_form_text, string content_field_1, string content_field_2, string content_field_3, 
                                                string content_field_4, string content_field_5, string content_field_6, string content_field_7, string content_field_8, string hostname)
        {
            string header_protocolid = "1";
            string header_msgid = "TrainDelay";
            string header_trace_id = "1";
            string header_message_version = "0";
            
            string content_scac_trainSeed = trainSeed;
            string content_section_trainSeed = trainSeed;
            string content_train_symbol_trainSeed = trainSeed;
            string content_origin_date_trainSeed = trainSeed;
            
            string content_crew_id_crewSeed = crewSeed;
            string content_crew_line_segment_crewSeed = crewSeed;
            
            NS_SendTrainDelay_48(header_protocolid, header_msgid, header_trace_id, header_message_version, content_scac_trainSeed, content_section_trainSeed, 
                                 content_train_symbol_trainSeed, content_origin_date_trainSeed, content_from_division_number, content_from_division, content_from_district,
                                 content_from_location_type, content_from_location, content_end_division_number, content_end_division, content_end_district, content_end_location_type,
                                 content_end_location, content_delay_record_id, content_delay_code, content_transmission_type, content_user_id, content_source_system,
                                 content_begin_delay_date_offset_days, content_begin_delay_time_offset_minutes, content_begin_delay_time_zone, content_end_delay_date_offset_days, content_end_delay_time_offset_minutes,
                                 content_end_delay_time_zone, content_delay_duration_offset_minutes, content_crew_id_crewSeed, content_crew_line_segment_crewSeed, content_free_form_text, content_field_1,
                                 content_field_2, content_field_3, content_field_4, content_field_5, content_field_6, content_field_7, content_field_8, hostname);
        }

        [UserCodeMethod]
        public static void validateMovementInformationMessage(string trainSeed, string opstaLocation, string additionalFilters, string locationType="O",  int timeInSeconds=5,bool retry=true)
        {
            MsgFilter msgFilters = new MsgFilter();

            string symbol = NS_TrainID.GetTrainSymbol(trainSeed);
            string date = NS_TrainID.getOriginDate(trainSeed);

            msgFilters.AddFilter(symbol, "TRAIN_SYMBOL");
            msgFilters.AddFilter(locationType, "LOCATION_TYPE");
            msgFilters.AddFilter(opstaLocation, "DATA_LOCATION");
            msgFilters.AddFilter(date,"REPORTING_DATE");
            //msgFilters.AddFilter(date, "ETA_DATE");
            if(additionalFilters != "")
            {
                if(additionalFilters.Contains("|"))
                {
                    string[] filterArr = additionalFilters.Split('|');

                    foreach(string filter in filterArr)
                    {
                        msgFilters.AddFilter(filter);
                    }
                }
                else
                {
                    msgFilters.AddFilter(additionalFilters);
                }
            }
            string filters = msgFilters.FormatFilters();

            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();
            STE.Code_Utils.ReceiveMISFileCollection_NS.addValueToFilters(filters);
            STE.Code_Utils.ReceiveMISFileCollection_NS.validateMovementInformationMessage(timeInSeconds, retry);
            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();
        }

        [UserCodeMethod]
        public static void validatePrintFax(string optPrintTitle, string printType, int quantity, string address, int timeInSeconds = 5, bool retry = true)
        {
            // TODO: Separate this process so that XML attributes are also allowed to be passed in through NS_MsgFilter methods.
            // None of this XML string builder nonsense that's currently exposed to individual validation methods.

            string addressType;
            switch (printType.ToLower())
            {
                case "printer":
                    addressType = "P";
                    break;
                case "email":
                    addressType = "E";
                    break;
                case "pager":
                    addressType = "G";
                    break;
                case "fax":
                    addressType = "F";
                    break;
                default:
                    Ranorex.Report.Error(string.Format("Print type '{0}' not recognized", printType));
                    return;
            }

            string addressTypeAttr = string.Format("ADDRESS_TYPE=\"{0}\"", addressType);
            string quantityAttr = string.Format("COPIES=\"{0}\"", quantity.ToString());
            // Note that if the priority can be set to anything but 1 in PDS, this process is not yet known.
            string priorityAttr = "PRIORITY=\"1\"";

            // example: <ADDRESSEE ADDRESS_TYPE="E" COPIES="1" PRIORITY="1">some address</ADDRESSEE>
            string addresseeFilter = string.Format("<ADDRESSEE {0} {1} {2}>{3}</ADDRESSEE>", addressTypeAttr, quantityAttr, priorityAttr, address);

            // Last part of the temporarily solution for xml attributes is to include a constructor with a single, complete filter.
            // In this case, the filter is created above.
            MsgFilter msgFilters = new MsgFilter(addresseeFilter);

            msgFilters.AddFilter(optPrintTitle, "TITLE");

            string filters = msgFilters.FormatFilters();
            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();
            STE.Code_Utils.ReceiveMISFileCollection_NS.addValueToFilters(filters);
            STE.Code_Utils.ReceiveMISFileCollection_NS.validatePrintFaxMessage(timeInSeconds, retry);
            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();
        }

        [UserCodeMethod]
        public static void validateETAMessageInformation(string trainSeed, string opstaLocation, string optAdditionalFilters, string locationType="O", int timeInSeconds=5, bool retry=true)
        {
            MsgFilter msgFilters = new MsgFilter();

            string symbol = NS_TrainID.GetTrainSymbol(trainSeed);

            msgFilters.AddFilter(symbol, "TRAIN_SYMBOL");
            msgFilters.AddFilter(locationType, "LOCATION_TYPE");
            msgFilters.AddFilter(opstaLocation, "DATA_LOCATION");

            if(!string.IsNullOrEmpty(optAdditionalFilters))
            {
                string[] filterArray = optAdditionalFilters.Split('|');
                foreach (string filterTag in filterArray)
                {
                    Ranorex.Report.Info("Filter Tag: "+filterTag);
                    msgFilters.AddFilter(filterTag);
                }
            }

            string filters = msgFilters.FormatFilters();

            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();
            STE.Code_Utils.ReceiveMISFileCollection_NS.addValueToFilters(filters);
            STE.Code_Utils.ReceiveMISFileCollection_NS.validateETAInformationMessage(timeInSeconds, retry);
            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();
        }

        [UserCodeMethod]
        public static void NS_validateNoMovementInformationMessage(string trainSeed, string opstaLocation, string locationType="O", int timeInSeconds=5,bool retry=true)
        {
            MsgFilter msgFilters = new MsgFilter();

            string symbol = NS_TrainID.GetTrainSymbol(trainSeed);

            msgFilters.AddFilter(symbol, "TRAIN_SYMBOL");
            msgFilters.AddFilter(locationType, "LOCATION_TYPE");
            msgFilters.AddFilter(opstaLocation, "DATA_LOCATION");

            string filters = msgFilters.FormatFilters();

            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();
            STE.Code_Utils.ReceiveMISFileCollection_NS.addValueToFilters(filters);
            STE.Code_Utils.ReceiveMISFileCollection_NS.validateNoMovementInformationMessage(timeInSeconds, retry);
            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();

        }

        [UserCodeMethod]
        public static void NS_validateNoETAInformationMessage(string trainSeed, string opstaLocation, string locationType, int timeInSeconds=5, bool retry=true)
        {
            MsgFilter msgFilters = new MsgFilter();

            string symbol = NS_TrainID.GetTrainSymbol(trainSeed);

            msgFilters.AddFilter(symbol, "TRAIN_SYMBOL");
            msgFilters.AddFilter(locationType, "LOCATION_TYPE");
            msgFilters.AddFilter(opstaLocation, "DATA_LOCATION");

            string filters = msgFilters.FormatFilters();

            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();
            STE.Code_Utils.ReceiveMISFileCollection_NS.addValueToFilters(filters);
            STE.Code_Utils.ReceiveMISFileCollection_NS.validateNoETAInformationMessage(timeInSeconds, retry);
            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();
        }

        [UserCodeMethod]
        public static void ValidateExternalAlertEventMessage(string alertEventKey, string alertEventType, string deviceType, string deviceId, string milepost, string division, string messageText, int timeInSeconds=5, bool retry=true)
        {
            MsgFilter msgFilters = new MsgFilter();

            msgFilters.AddFilter(alertEventKey, "ALERT_EVENT_KEY");
            msgFilters.AddFilter(alertEventType, "ALERT_EVENT_TYPE");
            msgFilters.AddFilter(deviceType, "DEVICE_TYPE");
            msgFilters.AddFilter(deviceId, "DEVICE_ID");
            msgFilters.AddFilter(milepost, "MILEPOST");
            msgFilters.AddFilter(division, "DIVISION");
            msgFilters.AddFilter(messageText, "MESSAGE_TEXT");

            string filters = msgFilters.FormatFilters();

            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();
            STE.Code_Utils.ReceiveMISFileCollection_NS.addValueToFilters(filters);
            STE.Code_Utils.ReceiveMISFileCollection_NS.ValidateExternalAlertEventMessage(timeInSeconds, retry);
            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();

        }

        [UserCodeMethod]
        public static void ValidateNoExternalAlertEventMessage(string alertEventType, string deviceId, int timeInSeconds=5, bool retry=true)
        {
            MsgFilter msgFilters = new MsgFilter();

            msgFilters.AddFilter(alertEventType, "ALERT_EVENT_TYPE");
            msgFilters.AddFilter(deviceId, "DEVICE_ID");
            string filters = msgFilters.FormatFilters();

            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();
            STE.Code_Utils.ReceiveMISFileCollection_NS.addValueToFilters(filters);
            STE.Code_Utils.ReceiveMISFileCollection_NS.validateNoExternalAlertEventMessage(timeInSeconds, retry);
            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();
        }

		[UserCodeMethod]
		public static void NS_ValidateEngineConsistMessage_ByContent_Simple(
			string trainSeed, string engineSeed, string reportingLocation, string reportingSource, string otherFilters, bool validateDoesExist = true, int timeInSeconds = 5, bool retry = true
		) {
			MsgFilter msg = new MsgFilter(otherFilters);

			string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
			string scac = NS_TrainID.GetTrainSCAC(trainSeed);
			string originDate = NS_TrainID.getOriginDate(trainSeed);
			string engineInitial = NS_TrainID.GetEngineInitial(trainSeed, engineSeed);
			string engineNumber = NS_TrainID.GetEngineNumber(trainSeed, engineSeed);

			msg.AddFilter(trainSymbol, "TRAIN_SYMBOL");
			msg.AddFilter(scac, "SCAC");
			msg.AddFilter(originDate, "ORIGIN_DATE");
			msg.AddFilter(engineInitial, "ENGINE_INITIAL");
			msg.AddFilter(engineNumber, "ENGINE_NUMBER");
			msg.AddFilter(reportingLocation, "REPORTING_LOCATION");
			msg.AddFilter(reportingSource, "REPORTING_SOURCE");

			string msgFilters = msg.FormatFilters();

			ReceiveMISFileCollection_NS.clearFilters();
			ReceiveMISFileCollection_NS.addValueToFilters(msgFilters);
			ReceiveMISFileCollection_NS.ValidateEngineConsistMessage(validateDoesExist, timeInSeconds, retry);
			ReceiveMISFileCollection_NS.clearFilters();
		}

		[UserCodeMethod]
		public static void NS_ValidateEotCabooseMessage_ByContent(
			string trainSeed, string equipmentCode, string origin, string destination,
			string initial, string number, string workingStatus,
			bool validateDoesExist = true, int timeInSeconds = 5, bool retry = true
		) {
			MsgFilter msg = new MsgFilter();

			string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
			string scac = NS_TrainID.GetTrainSCAC(trainSeed);
			string originDate = NS_TrainID.getOriginDate(trainSeed);

			msg.AddFilter(trainSymbol, "TRAIN_SYMBOL");
			msg.AddFilter(scac, "SCAC");
			msg.AddFilter(originDate, "ORIGIN_DATE");
			msg.AddFilter(equipmentCode, "EQUIPMENT_CODE");
			msg.AddFilter(origin, "ORIGIN");
			msg.AddFilter(destination, "DESTINATION");
			msg.AddFilter(initial, "INITIAL");
			msg.AddFilter(number, "NUMBER");
			msg.AddFilter(workingStatus, "WORKING_STATUS");

			string msgFilters = msg.FormatFilters();

			ReceiveMISFileCollection_NS.clearFilters();
			ReceiveMISFileCollection_NS.addValueToFilters(msgFilters);
			ReceiveMISFileCollection_NS.ValidateEotCabooseMessage(validateDoesExist, timeInSeconds, retry);
			ReceiveMISFileCollection_NS.clearFilters();
		}

		[UserCodeMethod]
		public static void NS_ValidateTrainConsistActivityMessage_ByContent_Simple(string trainSeed, string location, string otherFilters, bool validateDoesExist = true, int timeInSeconds = 5, bool retry = true)
		{
			MsgFilter msg = new MsgFilter(otherFilters);

			string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
			string scac = NS_TrainID.GetTrainSCAC(trainSeed);
			string originDate = NS_TrainID.getOriginDate(trainSeed);

			msg.AddFilter(trainSymbol, "TRAIN_SYMBOL");
			msg.AddFilter(scac, "SCAC");
			msg.AddFilter(originDate, "ORIGIN_DATE");
			msg.AddFilter(location, "LOCATION");

			string msgFilters = msg.FormatFilters();

			ReceiveMISFileCollection_NS.clearFilters();
			ReceiveMISFileCollection_NS.addValueToFilters(msgFilters);
			ReceiveMISFileCollection_NS.ValidateTrainConsistActivityMessage(validateDoesExist, timeInSeconds, retry);
			ReceiveMISFileCollection_NS.clearFilters();
		}

		[UserCodeMethod]
		public static void NS_ValidateCrewMemberMessage_ByContent_Simple(string trainSeed, string crewSeed, string otherFilters, bool validateDoesExist = true, int timeInSeconds = 5, bool retry = true)
		{
			MsgFilter msg = new MsgFilter(otherFilters);

			string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
			string scac = NS_TrainID.GetTrainSCAC(trainSeed);
			string originDate = NS_TrainID.getOriginDate(trainSeed);

			string firstInitial = "";
			string lastName = "";
			if (!string.IsNullOrEmpty(crewSeed) && (NS_CrewClass.GetCrewMemberObject(crewSeed) != null))
			{
				firstInitial = NS_CrewClass.GetCrewMemberFirstInitial(crewSeed);
				lastName = NS_CrewClass.GetCrewMemberLastName(crewSeed);
			}

			msg.AddFilter(trainSymbol, "TRAIN_SYMBOL");
			msg.AddFilter(scac, "SCAC");
			msg.AddFilter(originDate, "ORIGIN_DATE");
			msg.AddFilter(firstInitial, "FIRST_INITIAL");
			msg.AddFilter(lastName, "LAST_NAME");

			string msgFilters = msg.FormatFilters();

			ReceiveMISFileCollection_NS.clearFilters();
			ReceiveMISFileCollection_NS.addValueToFilters(msgFilters);
			ReceiveMISFileCollection_NS.ValidateCrewMemberMessage(validateDoesExist, timeInSeconds, retry);
			ReceiveMISFileCollection_NS.clearFilters();
		}
		
		/// <summary>
        /// Sends Combo MIS message to Train
        /// </summary>
        /// <param name="from_trainSeed">Input: from_trainSeed</param>
        /// <param name="from_origin_time">Input: from_origin_time</param>
        /// <param name="to_trainSeed">Input: to_trainSeed</param>
        /// <param name="to_origin_time">Input: to_origin_time</param>
        /// <param name="link_and_annul_from_location">Input: link_and_annul_from_location</param>
        /// <param name="link_and_annul_from_pass_count">Input: link_and_annul_from_pass_count</param>
        /// <param name="unlink_and_annul_to_location">Input: unlink_and_annul_to_location</param>
        /// <param name="unlink_and_annul_to_pass_count">Input: unlink_and_annul_to_pass_count</param>
        [UserCodeMethod]
        public static void NS_SendTrainScheduleComboMessage(string from_trainSeed, string from_origin_time, string to_trainSeed, string to_origin_time, string link_and_annul_from_location, 
                                              string link_and_annul_from_pass_count, string unlink_and_annul_to_location, string unlink_and_annul_to_pass_count)
        {
        	
        	string from_scac = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSCAC(from_trainSeed) ?? from_trainSeed;
        	string from_section = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSection(from_trainSeed);
        	string from_train_symbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(from_trainSeed) ?? from_trainSeed;
        	string to_scac = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSCAC(to_trainSeed) ?? to_trainSeed;
        	string to_section = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSection(to_trainSeed);
        	string to_train_symbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(to_trainSeed) ?? to_trainSeed;
        	
        	STE.Code_Utils.messages.MIS.NS.MIS_TrainScheduleComboConfig.createTrainScheduleComboConfig(from_scac, from_section, from_train_symbol, from_origin_time, to_scac, to_section, to_train_symbol, to_origin_time,
        	                                                                                           link_and_annul_from_location, link_and_annul_from_pass_count, unlink_and_annul_to_location, unlink_and_annul_to_pass_count);
        	
        }
        
        /// <summary>
        /// Sends Activity Link MIS message from one train to another Train
        /// </summary>
        /// <param name="header_protocolid">Input: header_protocolid</param>
        /// <param name="header_msgid">Input: header_msgid</param>
        /// <param name="header_trace_id">Input: header_trace_id</param>
        /// <param name="header_message_version">Input: header_message_version</param>
        /// <param name="content_from_scac_trainSeed">Input: content_from_scac_trainSeed</param>
        /// <param name="content_from_section_trainSeed">Input: content_from_section_trainSeed</param>
        /// <param name="content_from_train_symbol_trainSeed">Input: content_from_train_symbol_trainSeed</param>
        /// <param name="content_from_origin_date_trainSeed">Input: content_from_origin_date_trainSeed</param>
        /// <param name="content_minimum_connection_time">Input: content_minimum_connection_time</param>
        /// <param name="content_to_scac_trainSeed">Input: content_to_scac_trainSeed</param>
        /// <param name="content_to_section_trainSeed">Input: content_to_section_trainSeed</param>
        /// <param name="content_to_train_symbol_trainSeed">Input: content_to_train_symbol_trainSeed</param>
        /// <param name="content_to_origin_date_trainSeed">Input: content_to_origin_date_trainSeed</param>
        /// <param name="content_link_unlink">Input: content_link_unlink</param>
        /// <param name="content_link_location">Input: content_link_location</param>
        /// <param name="hostname">Input: hostname</param>
        [UserCodeMethod]
        public static void NS_SendTrainActivityLink_50(string header_protocolid, string header_msgid, string header_trace_id, string header_message_version, string content_from_scac_trainSeed, string content_from_section_trainSeed, string content_from_train_symbol_trainSeed,
                                                       string content_from_origin_date_trainSeed, string content_minimum_connection_time, string content_to_scac_trainSeed, string content_to_section_trainSeed, string content_to_train_symbol_trainSeed,
                                                       string content_to_origin_date_trainSeed, string content_link_unlink, string content_link_location, string hostname)
        {
        	string content_from_scac = NS_TrainID.GetTrainSCAC(content_from_scac_trainSeed) ?? content_from_scac_trainSeed;
        	string content_from_section = NS_TrainID.GetTrainSection(content_from_section_trainSeed) ?? content_from_section_trainSeed;
        	string content_from_train_symbol = NS_TrainID.GetTrainSymbol(content_from_train_symbol_trainSeed) ?? content_from_train_symbol_trainSeed;
        	string content_from_origin_date = NS_TrainID.getOriginDate(content_from_origin_date_trainSeed) ?? content_from_origin_date_trainSeed;

        	string content_to_scac = NS_TrainID.GetTrainSCAC(content_to_scac_trainSeed) ?? content_to_scac_trainSeed;
        	string content_to_section = NS_TrainID.GetTrainSection(content_to_section_trainSeed) ?? content_to_section_trainSeed;
        	string content_to_train_symbol = NS_TrainID.GetTrainSymbol(content_to_train_symbol_trainSeed) ?? content_to_train_symbol_trainSeed;
        	string content_to_origin_date = NS_TrainID.getOriginDate(content_to_origin_date_trainSeed) ?? content_to_origin_date_trainSeed;

        	STE.Code_Utils.messages.MIS.NS.MIS_NS_TrainActivityLink_50.createNS_TrainActivityLink_50(header_protocolid, header_msgid, header_trace_id, header_message_version, content_from_scac, content_from_section, content_from_train_symbol,
        	                                                                                         content_from_origin_date, content_minimum_connection_time, content_to_scac, content_to_section, content_to_train_symbol, content_to_origin_date,
        	                                                                                         content_link_unlink, content_link_location, hostname);
        }
        
        /// <summary>
        /// Sends Activity Link MIS message from one train to another Train
        /// </summary>
        /// <param name="from_trainSeed">Input: from_trainSeed</param>
        /// <param name="content_minimum_connection_time">Input: content_minimum_connection_time</param>
        /// <param name="to_trainSeed">Input: to_trainSeed</param>
        /// <param name="content_link_unlink">Input: content_link_unlink</param>
        /// <param name="content_link_location">Input: content_link_location</param>
        /// <param name="hostname">Input: hostname</param>
        [UserCodeMethod]
        public static void NS_SendTrainActivityLink_50Simple(string from_trainSeed, string content_minimum_connection_time, string to_trainSeed, string content_link_unlink, string content_link_location, string hostname)
        {
        	string header_protocolid = "1";
        	string header_msgid = "TrainActivityLink";
        	string header_trace_id = "1";
        	string header_message_version = "0";
        	
        	string content_from_scac_trainSeed = from_trainSeed;
        	string content_from_section_trainSeed = from_trainSeed;
        	string content_from_train_symbol_trainSeed = from_trainSeed;
        	string content_from_origin_date_trainSeed = from_trainSeed;
        	
        	string content_to_scac_trainSeed = to_trainSeed;
        	string content_to_section_trainSeed = to_trainSeed;
        	string content_to_train_symbol_trainSeed = to_trainSeed;
        	string content_to_origin_date_trainSeed = to_trainSeed;
        	
        	NS_SendTrainActivityLink_50(header_protocolid, header_msgid, header_trace_id, header_message_version, content_from_scac_trainSeed, content_from_section_trainSeed, content_from_train_symbol_trainSeed,
        	                            content_from_origin_date_trainSeed, content_minimum_connection_time, content_to_scac_trainSeed, content_to_section_trainSeed, content_to_train_symbol_trainSeed,
        	                            content_to_origin_date_trainSeed, content_link_unlink, content_link_location, hostname);
        }
        
        /// <summary>
        /// Sends Partial Schedule Annulment MIS Message to Train
        /// </summary>
        /// <param name="trainSeed">Input: trainSeed</param>
        /// <param name="from_location">Input: from_location</param>
        /// <param name="from_pass_count">Input: from_pass_count</param>
        /// <param name="linkedTrain_trainSeed">Input: linkedTrain_trainSeed</param>
        /// <param name="linked_train_origin_time">Input: linked_train_origin_time</param>
        [UserCodeMethod]
        public static void NS_SendPartialScheduleAnnulmentMessage(string trainSeed, string from_location, string from_pass_count, string linkedTrain_trainSeed, string linked_train_origin_time)
        {
        	string scac = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSCAC(trainSeed);
        	string section = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSection(trainSeed);
        	string train_symbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
        	
        	string linked_train_scac = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSCAC(linkedTrain_trainSeed);
        	string linked_train_section = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSection(linkedTrain_trainSeed);
        	string linked_train_symbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(linkedTrain_trainSeed);
        	
        	STE.Code_Utils.messages.MIS.NS.MIS_PartialScheduleAnnulmentConfig.createPartialScheduleAnnulmentConfig(scac, section, train_symbol, from_location, from_pass_count, linked_train_scac, linked_train_section,
        	                                                                                                       linked_train_symbol, linked_train_origin_time);
        	
        }
        
    }

    /// <summary>
    /// This error message handling class is extremely unique.
    /// An error message contains a few of its own fields (see 'ErrorMessage' under MIS ICD).
    /// The message also wraps the entirety of any other MIS message that caused this error.
    /// Therefore, the xml elements to be validated cannot be limited to the fields contained in the error message structure itself.
    /// It also must consider any and all other potential content, generated from any other MIS message.
    /// </summary>
    [UserCodeCollection]
    public class NS_MIS_ErrorMessage
    {
        public static List<string> errMsgFilters = new List<string>();

        [UserCodeMethod]
        public static void NS_AddFilter_ErrorMessageValidation(string xmlElement, string xmlValue)
        {
            if (!string.IsNullOrEmpty(xmlValue) && !string.IsNullOrEmpty(xmlElement))
            {
                if (xmlValue == "Blank")
                {
                    xmlValue = "";
                }
                string xmlFilter = "<" + xmlElement + ">" + xmlValue + "</" + xmlElement + ">";
                errMsgFilters.Add(xmlFilter);
            }
        }

        public static void clearErrMsgFilters()
        {
            Ranorex.Report.Info("Clearing and resetting capacity of list of filters for STE message validation");
            errMsgFilters.Clear();
        }

        [UserCodeMethod]
        public static void NS_ValidateErrorMessage_ByContent(
            string optErrorCode, string optErrorText, string optErrorCategory,
            int timeInSeconds = 5, bool retry = true
           ) {
            // This method will allow filters that were previously placed by the method: NS_AddFilter_ErrorMessageValidation()
            MsgFilter msg = new MsgFilter(errMsgFilters);

            msg.AddFilter(optErrorCode, "ERROR_CODE");
            msg.AddFilter(optErrorText, "ERROR_TEXT");
            msg.AddFilter(optErrorCategory, "ERROR_CATEGORY");

            string filters = msg.FormatFilters();
            ReceiveMISFileCollection_NS.clearFilters();
            ReceiveMISFileCollection_NS.addValueToFilters(filters);
            ReceiveMISFileCollection_NS.validateErrorMessage(filterString: filters, timeInSeconds: timeInSeconds, retry: retry);
            ReceiveMISFileCollection_NS.clearFilters();

            clearErrMsgFilters();
        }

        [UserCodeMethod]
        public static void ValidateRemedyBulletinMessage(string bulletinSeed, string sequenceNumber, string source, string source_id, string action, string comments, string bulletinType, string bulletinSeedVoid, int timeInSeconds=5, bool retry=true)
        {
            MsgFilter msgFilters = new MsgFilter();
            NS_BulletinObject bulletinObj = NS_Bulletin.getBulletinObject(bulletinSeed);
            string bulletin_number= "";
            string remedyBulletinUniqueIdConfigValue = CDMSEnvironment.GetCommonConfigValue_CDMS("RST_REMEDY_UNIQUE_ID_CONFIG");
            if(string.IsNullOrEmpty(bulletinSeedVoid))
            {
                bulletin_number = NS_Bulletin.GetBulletinNumber(bulletinSeed);
            }
            else
            {
                bulletin_number = NS_Bulletin.GetBulletinNumber(bulletinSeedVoid);
            }

            msgFilters.AddFilter(sequenceNumber, "SEQUENCE_NUMBER");
            msgFilters.AddFilter(source, "SOURCE");
            msgFilters.AddFilter(source_id, "SOURCE_ID");
            msgFilters.AddFilter(action, "ACTION");
            msgFilters.AddFilter(comments, "COMMENTS");
            msgFilters.AddFilter(bulletinType, "BULLETIN_ITEM_TYPE");
            if (!string.IsNullOrEmpty(bulletin_number) && action != "4")
            {
                msgFilters.AddFilter(bulletin_number, "BULLETIN_ITEM_NUMBER");
            }
            
            if (!String.IsNullOrEmpty(bulletinObj.bulletinId) && action != "4")
            {
                msgFilters.AddFilter(bulletinObj.bulletinId, "BULLETIN_UNIQUE_ID");
            }
            //TODO: Fix the issue for not present BULLETIN_UNIQUE_ID in remedybulletin message.
            /*else
			{
				msgFilters.AddFilter_NotExistTag("BULLETIN_UNIQUE_ID");
			}*/
            string filters = msgFilters.FormatFilters();

            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();
            STE.Code_Utils.ReceiveMISFileCollection_NS.addValueToFilters(filters);
            STE.Code_Utils.ReceiveMISFileCollection_NS.ValidateRemedyBulletinMessage(timeInSeconds, retry);
            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();
        }

        [UserCodeMethod]
        public static void NS_ValidateNoRemedyBulletinMessage(string bulletinSeed, int timeInSeconds=5, bool retry=true)
        {
            MsgFilter msgFilters = new MsgFilter();

            string bulletinType = NS_Bulletin.GetBulletinType(bulletinSeed);
            msgFilters.AddFilter(bulletinType, "BULLETIN_ITEM_TYPE");

            string filters = msgFilters.FormatFilters();

            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();
            STE.Code_Utils.ReceiveMISFileCollection_NS.addValueToFilters(filters);
            STE.Code_Utils.ReceiveMISFileCollection_NS.ValidateNoRemedyBulletinMessage(timeInSeconds, retry);
            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();
        }
        /// <summary>
        /// It will validate train consist summary message content
        /// </summary>
        [UserCodeMethod]
        public static void NS_ValidateTrainConsistSummaryMessage_ByContent(string trainSeed, string consistSeed, string reportingSource, string reportingLocation, int timeInSeconds=5, bool retry=true)
        {
            Ranorex.Report.Info("TestStep", "Validating Train Consist Summary");

            MsgFilter msg = new MsgFilter();
            NS_ConsistObject consist = NS_TrainID.GetConsistObjectFromTrain(trainSeed, consistSeed);

            string consistLoads = NS_TrainID.GetConsistNumberOfLoads(trainSeed, consistSeed);
            string consistLength = NS_TrainID.GetConsistTrainLength(trainSeed, consistSeed);

            msg.AddFilter(reportingSource, "REPORTING_SOURCE");
            msg.AddFilter(consistLoads, "NUMBER_OF_LOADS");
            msg.AddFilter(consist.NumberEmpties, "NUMBER_OF_EMPTIES");
            msg.AddFilter(consist.TrailingTonnage, "TRAILING_TONNAGE");
            msg.AddFilter(consistLength, "TRAIN_LENGTH");
            msg.AddFilter(reportingLocation, "REPORTING_LOCATION");

            string filters = msg.FormatFilters();

            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();
            STE.Code_Utils.ReceiveMISFileCollection_NS.addValueToFilters(filters);
            STE.Code_Utils.ReceiveMISFileCollection_NS.ValidateTrainConsistSummaryMessage(timeInSeconds, retry);
            STE.Code_Utils.ReceiveMISFileCollection_NS.clearFilters();

        }
    }
}
