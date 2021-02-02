/*
 * Created by Ranorex
 * User: 503073759
 * Date: 6/7/2019
 * Time: 5:49 AM
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
using System.Globalization;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace PDS_NS.UserCodeCollections
{
    public static class NS_Time
	{
		//private readonly static string pds_daylightSavingsFormat = "07-01-yyyy hh:mm t";
		//private readonly static string pds_stanardTimeFormat = "01-01-yyyy hh:mm t";
		private readonly static string pds_TimeFormat = "MM-dd-yyyy hh:mm t";
		
		public static string GetPDSTimeFormat()
		{
			return pds_TimeFormat;
		}
		
		// This method acts as a simple translation layer. 
		// The user is testing whether or not the correct time zone will appear in an error message (e.g. EDT vs EST)
		// This program will determine which time format should be displayed, and will append it to the error message
		public static string AppendTimeZoneToFeedback(string expectedFeedback, System.DateTime inputTime, string inputTimeZone, bool useInvalidDaylightTime = false) 
		{
			string outTimeZone = getFullTimeZone(inputTime, inputTimeZone, useInvalidDaylightTime);
			
			string outFeedback;
			if (string.IsNullOrEmpty(expectedFeedback.Trim()))
			{
				// If we're expecting no feedback, then we should still return a blank string for final feedback
				outFeedback = "";
			} else {
				outFeedback = string.Format("{0} {1}", expectedFeedback, outTimeZone);
			}
			return outFeedback;
		}

		// This is an overload that handles the nullable DateTime. An overload would be better than forcing other engineers to figure out how to deal with nullables in each scenario. 
		public static string AppendTimeZoneToFeedback(string expectedFeedback, System.DateTime? inputTime, string inputTimeZone, bool useInvalidDaylightTime = false)
		{
			return AppendTimeZoneToFeedback(expectedFeedback, (System.DateTime)inputTime, inputTimeZone, useInvalidDaylightTime);
		}

		public static string AppendTimeZoneToFeedback(string expectedFeedback, string inputTime, string inputTimeZone, bool useInvalidDaylightTime = false)
		{
			System.DateTime inputDateTime = NS_Time.ConvertTimeInputToDateTime(inputTime);
			return AppendTimeZoneToFeedback(expectedFeedback, inputDateTime, inputTimeZone, useInvalidDaylightTime);
		}

		private static string getFullTimeZone(System.DateTime inputTime, string inputTimeZone, bool useInvalidDaylightTime = false)
		{
			// For the 4, domestic timezones: <E>DT = daylight savings time & <E>ST = normal time
			bool isDaylightSavings = inputTime.IsDaylightSavingTime();
            
            if(string.IsNullOrEmpty(inputTimeZone))
            {
            	return "";
            }

			string outTimeZone;
            if(useInvalidDaylightTime)
            {
                if (isDaylightSavings)
                {
                    outTimeZone = inputTimeZone + "ST";
                } else {
                    outTimeZone = inputTimeZone + "DT";
                }
            }
            else
            {
                if(isDaylightSavings)
                {
                    outTimeZone = inputTimeZone + "DT";
                } else {
                    outTimeZone = inputTimeZone + "ST";
                }
            }
            return outTimeZone;
		}
		
		// This method will return the official name of the effective time zone, which is required to determine when daylight savings begins and ends for the time zone (if ever)
		// All time zones in the USA follow the same rules for daylight savings for the time being. However, this getter is useful to the extent that some time zone is required.
		private static TimeZoneInfo getTimeZoneId(string inputTz = "E")
		{
			string idTime = "Eastern Standard Time";
			if (inputTz.ToUpper() == "C")
			{
				idTime = "Central Standard Time";
			}
			return TimeZoneInfo.FindSystemTimeZoneById(idTime);
		}

		// Useful wrapper here and there
		private static int getInputYear(System.DateTime inputTime)
		{
			return inputTime.Year;
		}

		// Given a time zone, an adjustment rule is created to dictate the time-specific components where daylight savings begins and ends for the year
		// Whenever the culture/society updates the rules for when daylight savings begins or ends, a new adjustment rule is added 
		// For example: USA says DST will end on first Sunday in October, not third Sunday, starting in 2010. A new adjustment rule is added to array of adjustment rules for all USA time zones. 
		// Each adjustment rule includes start and end dates for when the rules are in effect.
		// The role of this method is to determine which adjustment rule to utilize for the time zone.		
		private static TimeZoneInfo.AdjustmentRule getAdjustmentRule(System.DateTime inputTime, TimeZoneInfo tzInfo)
		{
			TimeZoneInfo.AdjustmentRule[] adjustmentRules = tzInfo.GetAdjustmentRules();
			TimeZoneInfo.AdjustmentRule adjustmentRule = adjustmentRules[0];

			foreach (TimeZoneInfo.AdjustmentRule rule in adjustmentRules)
			{
				if (inputTime > rule.DateEnd)
				{
					continue;
				}
				
				if ((inputTime > rule.DateStart) && (inputTime < rule.DateEnd))
				{
					adjustmentRule = rule;
					break;
				}
				
			}

			return adjustmentRule;
		}

		// The TransitionTime struct is a set of internal properties which dictate when daylight savings time begins or ends
		// Since daylight savings time follows floating date rules (e.g. Begins at 2:45 AM on the first Sunday of October), 
		// a substantial amount of logic is required to wrangle these properties into a DateTime object.
		private static System.DateTime getTransitionDate(TimeZoneInfo.TransitionTime transitionTime, int inputYear)
		{
			// For non-fixed date rules, get local calendar
			Calendar calendar = CultureInfo.CurrentCulture.Calendar;
			// Get first day of week for transition
			// For example, the 3rd week starts no earlier than the 15th of the month
			int startOfTransitionWeek = transitionTime.Week * 7 - 6;
			// What day of the week does the month start on?
			int firstDayOfWeek = (int)calendar.GetDayOfWeek(new System.DateTime(inputYear, transitionTime.Month, 1));
			// Determine how much start date has to be adjusted
			int transitionDay;
			int transitionDayOfWeek = (int)transitionTime.DayOfWeek;

			if (firstDayOfWeek <= transitionDayOfWeek)
			{
				transitionDay = startOfTransitionWeek + (transitionDayOfWeek - firstDayOfWeek);
			} else {
				transitionDay = startOfTransitionWeek + (7 - firstDayOfWeek + transitionDayOfWeek);
			}

			// Adjust for months with no fifth week
			if (transitionDay > calendar.GetDaysInMonth(inputYear, transitionTime.Month))
			{
				transitionDay -= 7;
			}
			
			return new System.DateTime(inputYear, transitionTime.Month, transitionDay, transitionTime.TimeOfDay.Hour, transitionTime.TimeOfDay.Minute, transitionTime.TimeOfDay.Second);

		}

		// Given an existing DateTime object, as well as the current adjustment rule that is in effect during this DateTime,
		// this method changes the date and time of this DateTime object to reflect a date and time following the next daylight savings time transition.
		// If the DateTime exists in daylight savings time, then this method will transition out of daylight savings time, and vice versa.
		private static System.DateTime convertToTransitionDate(this System.DateTime inputTime, TimeZoneInfo.AdjustmentRule inputRule)
		{
			System.DateTime outTime = inputTime;

			int[] transitionYears = new int[] { getInputYear(inputTime), getInputYear(inputTime) + 1 };
			foreach (int year in transitionYears)
			{
				System.DateTime startTime = getTransitionDate(transitionTime: inputRule.DaylightTransitionStart, inputYear: year).AddHours(6);
				System.DateTime endTime = getTransitionDate(transitionTime: inputRule.DaylightTransitionEnd, inputYear: year).AddHours(6);
				if (inputTime < startTime)
				{
					outTime = startTime;
					break;
				}

				if (inputTime < endTime)
				{
					outTime = endTime;
					break;
				}
			}

			return outTime;
		}

		public static System.DateTime GetNextTransitionDate(System.DateTime inputTime, string inputTimeZone)
		{
			// Get time zone info
			TimeZoneInfo inputTz = getTimeZoneId(inputTimeZone);
			// Get adjustment rules for time zone
			// Get current adjustment rule for time zone
			TimeZoneInfo.AdjustmentRule rule = getAdjustmentRule(inputTime, inputTz);
			// Determine next transition date time from adjustment rule
			return inputTime.convertToTransitionDate(inputRule: rule);
		}

		public static System.DateTime ConvertTimeInputToDateTime(string inputTime, string outTimeFormat = "MM-dd-yyyy hh:mm t")
		{
			System.DateTime outTime = System.DateTime.Now;
			if ((inputTime.Length >= outTimeFormat.Length))
			{
				string convertTime = inputTime.Substring(0, outTimeFormat.Length);
				outTime = System.DateTime.ParseExact(convertTime, outTimeFormat, CultureInfo.InvariantCulture);
			}
			return outTime;
		}

		/// <summary>
		/// Input a date time string to a PDS field. 
		/// </summary>
		/// <param name="inputDateTime">Initial date time object provided by developer.</param>
		/// <param name="inputTimeZone">Time zone to be provided to PDS. E/C/M/P/bob/etc</param>
		public static string FormatDateTime(System.DateTime inputDateTime, string inputTimeZone, string outputTimeFormat = "MM-dd-yyyy hh:mm t")
        {			
            string outTime = inputDateTime.ToString(outputTimeFormat.Trim());
            string timeFormat = string.Format("{0} {1}", outTime, inputTimeZone);
            return timeFormat;
        }

		/// <summary>
		/// Input a date time string to a PDS field. 
		/// This overload allows for an offset from the current date time. In minutes.
		/// </summary>
		/// <param name="inputDateTime">Initial date time object provided by developer.</param>
		/// <param name="inputTimeZone">Time zone to be provided to PDS. E/C/M/P/bob/etc</param>
		/// <param name="inputOffset">Include a number to offset the current date time object. In minutes.</param>
		public static string FormatDateTime(System.DateTime inputDateTime, string inputTimeZone, double inputOffset, string outputTimeFormat = "MM-dd-yyyy hh:mm t")
		{
			System.DateTime finalTime = inputDateTime;
			
			finalTime = inputDateTime.AddMinutes(inputOffset);
			string outTime = FormatDateTime(finalTime, inputTimeZone, outputTimeFormat);
			return outTime;
		}

		/// <summary>
		/// Input a date time string to a PDS field. 
		/// This overload is meant for cases where strings were initially provided as inputs to offset the initial date time.
		/// This overload compensates for previous logic, whereby a field in PDS was not populated if the offset was an empty string.
		/// </summary>
		/// <param name="inputDateTime">Initial date time object provided by developer.</param>
		/// <param name="inputTimeZone">Time zone to be provided to PDS. E/C/M/P/bob/etc</param>
		/// <param name="inputStringOffset">Include a string representation of a number to offset the current date time object. In minutes.</param>
		/// <param name="allowEmptyString">Allow Ranorex to return an empty string, if and only if the `inputOffset` value is an empty string.</param>
		public static string FormatDateTime(System.DateTime inputDateTime, string inputTimeZone, string inputStringOffset, bool allowEmptyString, string outputTimeFormat = "MM-dd-yyyy hh:mm t")
		{
			System.DateTime finalTime = inputDateTime;
			
			string outTime = "";
			if (allowEmptyString && (inputStringOffset == ""))
			{
				return outTime;
			} 

			double offset = 0;
			if (Double.TryParse(inputStringOffset, out offset))
			{
				finalTime = inputDateTime.AddMinutes(offset);
			}

			outTime = FormatDateTime(finalTime, inputTimeZone, outputTimeFormat);
			return outTime;
		}
	}
}