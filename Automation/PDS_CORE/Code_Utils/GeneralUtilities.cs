/*
 * Created by Ranorex
 * User: 502732101
 * Date: 1/11/2018
 * Time: 9:33 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WinForms = System.Windows.Forms;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;
using Ranorex.Plugin;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;

namespace PDS_CORE.Code_Utils
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class GeneralUtilities
    {
        public static Dictionary<string, Bitmap> persistedImages = new Dictionary<string, Bitmap>();
        public static PDS_CORE.TrackLine trackLineRepo = PDS_CORE.TrackLine.Instance;
        
        /// <summary>
        /// Fills a text box with text, validates the text matches what is passed in, and presses tab.
        /// </summary>
        /// <param name="textBox">Repo Adapter of the text box to use</param>
        /// <param name="data">String you want in the text box</param>
        /// <param name="logName">Name to put in the logs for this item</param>
        [UserCodeMethod]
        public static void FillInputTextBoxWithTextAndTab(Adapter textBox, String data, String logName)
        {
            FillInputTextBoxWithTextAndTab(textBox, data, logName, false);
        }
        /// <summary>
        /// Fills a text box with text, validates the text matches what is passed in, and presses tab.
        /// </summary>
        /// <param name="textBox">Repo Adapter of the text box to use</param>
        /// <param name="data">String you want in the text box</param>
        /// <param name="logName">Name to put in the logs for this item</param>
        /// <param name="injectText">Use this true if you want to set the text box directly instead of typing keypresses</param>
        [UserCodeMethod]
        public static void FillInputTextBoxWithTextAndTab(Adapter textBox, String data, String logName, bool injectText)
        {
            Text repoItem = textBox.As<Text>();
            if (repoItem == null)
            {
                Report.Error("Adapater " + logName + " passed in Null. No action taken.");
                return;
            }
            
            for (int x = 0; x < 3; x++)
            {
                if (!repoItem.TextValue.Equals(data, StringComparison.OrdinalIgnoreCase))
                {
                    if (x > 0)
                    {
                        Report.Info(String.Format("{0} Data '{1}' does not match actual '{2}'", logName, data, repoItem.TextValue));
                        repoItem.TextValue = "";
                        Delay.Milliseconds(500);
                    }
                    else
                    {
                        // If we are here, then the text field is not emtpy and doesn't match, but since this is the first time through
                        // Just clear the string and try for the first entry.
                        repoItem.TextValue = "";
                        Delay.Milliseconds(500);
                    }
                    
                    repoItem.Focus();
                    Delay.Milliseconds(250);
                    if (injectText)
                    {
                        repoItem.TextValue = data;
                    }
                    else
                    {
                        repoItem.PressKeys(data);
                    }
                    Delay.Milliseconds(500);
                    repoItem.PressKeys("{Tab}");
                    Delay.Milliseconds(500);
                }
                else
                {
                    Report.Info(String.Format("Verified that both expected and actual {0} data are equal '{1}'", logName, data));
                    return;
                }
            }
            
            if (repoItem.TextValue.Equals(data, StringComparison.OrdinalIgnoreCase))
            {
                Report.Info(String.Format("Verified that both expected and actual {0} data are equal '{1}'", logName, data));
            }
            else
            {
                Report.Error(String.Format("{0} Data '{1}' does not match actual '{2}'", logName, data, repoItem.TextValue));
            }
        }

        /// <summary>
        /// Fills a text box with text, validates the text matches what is passed in, and presses tab.
        /// </summary>
        /// <param name="textBox">Repo Adapter of the text box to use</param>
        /// <param name="data">String you want in the text box</param>
        /// <param name="logName">Name to put in the logs for this item</param>
        [UserCodeMethod]
        public static void FillInputTextBoxWithTextAndTab_NoEnsureVisible(Adapter textBox, String data, String logName)
        {
            FillInputTextBoxWithTextAndTab_NoEnsureVisible(textBox, data, logName, false);
        }
        
        /// <summary>
        /// Fills a text box with text, validates the text matches what is passed in, and presses tab.
        /// </summary>
        /// <param name="textBox">Repo Adapter of the text box to use</param>
        /// <param name="data">String you want in the text box</param>
        /// <param name="logName">Name to put in the logs for this item</param>
        /// <param name="injectText">Use this true if you want to set the text box directly instead of typing keypresses</param>
        [UserCodeMethod]
        public static void FillInputTextBoxWithTextAndTab_NoEnsureVisible(Adapter textBox, String data, String logName, bool injectText)
        {
            Text repoItem = textBox.As<Text>();
            repoItem.UseEnsureVisible = false;
            
            if (!String.IsNullOrEmpty(repoItem.TextValue))
            {
                repoItem.TextValue = "";
            }
            
            for (int x = 0; x < 3; x++)
            {
                if (!repoItem.TextValue.Equals(data, StringComparison.OrdinalIgnoreCase))
                {
                    if (x > 0)
                    {
                        Report.Info(String.Format("{0} Data '{1}' does not match actual '{2}'", logName, data, repoItem.TextValue));
                        repoItem.TextValue = "";
                        Delay.Milliseconds(500);
                    }

                    // Make sure to set focus to the repo item before typing
                    repoItem.Focus();
                    Delay.Milliseconds(250);
                    if (injectText)
                    {
                        repoItem.TextValue = data;
                    }
                    else
                    {
                        repoItem.PressKeys(data);
                    }
                    repoItem.PressKeys("{Tab}");
                    Delay.Milliseconds(250);
                }
                else
                {
                    Report.Info(String.Format("Verified that both expected and actual {0} data are equal '{1}'", logName, data));
                    return;
                }
            }
            
            if (repoItem.TextValue.Equals(data, StringComparison.OrdinalIgnoreCase))
            {
                Report.Info(String.Format("Verified that both expected and actual {0} data are equal '{1}'", logName, data));
            }
            else
            {
                Report.Error(String.Format("{0} Data '{1}' does not match actual '{2}'", logName, data, repoItem.TextValue));
            }
        }
        /// <summary>
        /// Gets the 3 letter timezone abbreviation (based on system current timezone) and adds it to the
        /// date and time string.
        /// </summary>
        /// <param name="dateTime">System.DataTime object with the desired date time</param>
        /// <returns>String containing the formatted date time with 3 letter timezone abbreviation</returns>
        public static String GetDateTimeWithTimeZoneFormat(System.DateTime dateTime, String desiredZone = "X")
        {
            // Function taken from Stack Overload - STLDeveloper
            // https://stackoverflow.com/questions/15302083/timezone-abbreviations
            if (dateTime != null)
            {
                String output = String.Empty;
                String timeZoneName = "";
                
                // If the desiredZone is not specified and defaults to "X" then use the current timezone
                if (desiredZone.ToLower().Equals("x"))
                {
                    desiredZone = TimeZone.CurrentTimeZone.StandardName.Substring(0,1);
                }
                
                if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(System.DateTime.Now))
                {
                    timeZoneName = TimeZone.CurrentTimeZone.DaylightName;
                }
                else
                {
                    timeZoneName = TimeZone.CurrentTimeZone.StandardName;
                }
                
                String[] timeZoneWords = timeZoneName.Split(' ');
                foreach (String timeZoneWord in timeZoneWords)
                {
                    // Some timezones have country codes after e.g. (Mexico) - remove this and just
                    // return the 3 letter code
                    if (timeZoneWord[0] != '(')
                    {
                        output += timeZoneWord[0];
                    }
                }
                
                // Replace the first character with the desired zone
                output = desiredZone + output.Remove(0,1);
                
                String returnValue = dateTime.ToString("MM-dd-yyyy HH:mm") + " " + output;
                Report.Info("returning: " + returnValue);
                return returnValue;
            }
            else
            {
                return "";
            }
        }
        
        /// <summary>
        /// Create a timestamp for typing into forms using an offset from Now instead of a hardcoded time
        /// </summary>
        /// <param name="offsetInMinutes">Number of minutes in the future</param>
        /// <returns>String with the time in CN Format</returns>
        [UserCodeMethod]
        public static String CreateTimestampWithOffset(String offsetInMinutes)
        {
            // TODO Add some error handling here for invalid input
            System.DateTime current = System.DateTime.Now;
            current = current.AddMinutes(Convert.ToInt32(offsetInMinutes));
            return GetDateTimeWithTimeZoneFormat(current);
        }
        
        enum timeZoneShifting
        {
            P = 0, // Pacific
            M = 1, // Mountain
            C = 2, // Central
            E = 3  // Eastern
        }
        /// <summary>
        /// Create a timestamp for typing into forms using an offset from Now instead of a hardcoded time
        /// </summary>
        /// <param name="offsetInMinutes">Number of minutes in the future</param>
        /// <returns>String containing the time stamp in the desired zone</returns>
        [UserCodeMethod]
        public static String CreateTimestampWithOffsetAndTimeZone(String offsetInMinutes, String desiredZone = "E")
        {
            // TODO Add some error handling here for invalid input
            System.DateTime current = System.DateTime.Now;
            current = current.AddMinutes(Convert.ToInt32(offsetInMinutes));
            
            int cTimeZone;
            int dTimeZone;
            int offsetInHours = 0;
            
            // Get the first letter for the timezone
            String currentTimeZone = TimeZone.CurrentTimeZone.StandardName.Substring(0,1).ToLower();
            desiredZone = desiredZone.ToLower();

            switch(currentTimeZone)
            {
                case "p":
                    cTimeZone = (int)timeZoneShifting.P;
                    break;
                case "m":
                    cTimeZone = (int)timeZoneShifting.M;
                    break;
                case "c":
                    cTimeZone = (int)timeZoneShifting.C;
                    break;
                case "e":
                default:
                    cTimeZone = (int)timeZoneShifting.E;
                    break;
            }
            
            switch(desiredZone)
            {
                case "p":
                    dTimeZone = (int)timeZoneShifting.P;
                    break;
                case "m":
                    dTimeZone = (int)timeZoneShifting.M;
                    break;
                case "c":
                    dTimeZone = (int)timeZoneShifting.C;
                    break;
                case "e":
                default:
                    dTimeZone = (int)timeZoneShifting.E;
                    break;
            }

            if (cTimeZone > dTimeZone)
            {
                // negative offset to adjust east to west zones
                offsetInHours = dTimeZone - cTimeZone;
                Report.Info("Offset in hours: " + offsetInHours.ToString());
            }
            else if (cTimeZone < dTimeZone)
            {
                // positive offset to adjust west to east zones
                offsetInHours = dTimeZone - cTimeZone;
                Report.Info("Offset in hours: " + offsetInHours.ToString());
            }
            else
            {
                offsetInHours = 0;
            }
            
            current = current.AddHours(Convert.ToInt32(offsetInHours));
            String returnValue = GetDateTimeWithTimeZoneFormat(current, desiredZone.ToUpper());
            Report.Info("return time: " + returnValue);
            return returnValue;
        }

        /// <summary>
        /// Finds and clicks on list item
        /// Note: GeneralUtilities.ClickJavaElement does not work on list items
        /// </summary>
        /// <param name="listItemXpath"></param>
        public static void ClickListItem(String listItemXPath, int searchTimeout = 5000)
        {
            Ranorex.ListItem listItemElement;
            try
            {
                listItemElement = Host.Local.FindSingle(listItemXPath, searchTimeout);
            }
            catch(ElementNotFoundException ex)
            {
                Report.Error(String.Format(@"Could not find list item at {0}. Exception information: {1}", listItemXPath, ex.Message));
                return;
            }
            listItemElement.Click();
        }
        
        /// <summary>
        /// Using the text that will appear in the list, click that item in the list
        /// </summary>
        /// <param name="listItemText">The text that will appear on a list</param>
        /// <param name="searchTimeout">Duration in milliseconds to wait for the list item to appear</param>
        [UserCodeMethod]
        public static void ClickListItemByText(string listItemText, int searchTimeout = 5000)
        {
            string listItemXPath = "//listitem[@text='" + listItemText + "']";
            ClickListItem(listItemXPath, searchTimeout);
        }
        
        //should really merge this with IndexValidation sometime
        /// <summary>
        /// Verify the list items are present
        /// </summary>
        /// <param name="listItems">Text that will appear for the list item</param>
        /// <param name="visible">True for find it in the list, False for ensure it is not in the list</param>
        [UserCodeMethod]
        public static void ListItemPresent(string listItems, bool visible) {
            string[] listItemArray = listItems.Split('|');
            bool result = false;
            Ranorex.ListItem listItemElement;
            foreach (string listItem in listItemArray) {
                result = Host.Local.TryFindSingle(".//listitem[@text='" + listItem + "']", out listItemElement);
                if (visible == true && result == true) {
                    Report.Success("Success", listItem + "found in list.");
                } else if (visible == false && result == false) {
                    Report.Success("Success", listItem + "not found in list.");
                } else {
                    Report.Failure("Failure", listItem + "not in expected state '" + visible + "'.");
                }
            }
        }
        
        /// <summary>
        /// Verify the index location of the list item in the list
        /// </summary>
        /// <param name="listItem">The text that will appear in the list</param>
        /// <param name="index">The index the item is expected to be found at</param>
        public static void ListItemIndexValidation(string listItem, int index)
        {
            Report.Log(ReportLevel.Info, "Searching for list item " + listItem + ".");
            string listItemXPath = ".//listitem[@text='" + listItem + "']";
            Ranorex.ListItem listItemElement;
            
            bool result = false;
            
            try
            {
                listItemElement = Host.Local.FindSingle(listItemXPath);
                result = true;
                //if index matters, then you have to extract the text value from the found element and compare it to expected item text since we found it by index the first time
                if (index > -1 && listItemElement.Index != index)
                {
                    result = false;
                    Report.Error(String.Format(@"List item {0} was not present at index {1}.", listItem, index));
                    return;
                }
            }
            catch(ElementNotFoundException ex)
            {
                Report.Error(String.Format(@"Could not find list item at {0}. Exception information: {1}", listItemXPath, ex.Message));
            }
            finally
            {
                if (index > -1 && result == true)
                {
                    Report.Success("Success", listItem + " found in the list at index " + index + ".");
                }
                else if (result == true)
                {
                    Report.Success("Success", listItem + " found in the list.");
                }
                else
                {
                    Report.Failure("Failure", listItem + " absent from the list.");
                }
            }
        }

        /// <summary>
        /// Used to validate sequential items in a list
        /// </summary>
        /// <param name="listItems">bar seperated list of items to validate on the dropdown</param>
        /// <param name="startingIndex">which index on the list you wish to start your validations</param>
        [UserCodeMethod]
        public static void SequentialListItemValidation(string listItems, int startingIndex) {
            string[] dropDownList = listItems.Split('|');
            for (int i=0; i < dropDownList.Length; i++) {
                ListItemIndexValidation(dropDownList[i], startingIndex++);
            }
            //If you find more elements in the list, fail validation, TBD
        }
        
        /// <summary>
        /// Check the trackline component to see if a color swatch exists in the image
        /// </summary>
        /// <param name="window">Name of the window to find the component in</param>
        /// <param name="sectionIDs">Pipe delimited ID(s) of the trackline object to check</param>
        /// <param name="color">Color to make a swatch out of for checking against the component.  Must be from the PDSColors list</param>
        [UserCodeMethod]
        public static void ValidateColorOnTrackline(String window, String sectionIDs, String color)
        {
            if(String.IsNullOrEmpty(sectionIDs))
            {
                Report.Info("Track sections ids are not provided");
                return;
            }
            
            if(!String.IsNullOrEmpty(color))
            {
                var repo = TrackLine.Instance;
                repo.window = window.Trim();
                repo.TrackLineWindow.Self.Activate();
                
                String[] sections = sectionIDs.Split('|');
                
                foreach (String sectionID in sections)
                {
                    var element = Signaling.FindTrackLineAssetByContext(window, sectionID.Trim());
                    
                    Bitmap bmp = new Bitmap(2, 2);
                    Graphics g = Graphics.FromImage(bmp);
                    //Must use a named color from PDSColors
                    Color checkColor = PDS_CORE.Code_Utils.PDSColors.GetColorFromString(color);
                    g.FillRectangle(new SolidBrush(checkColor), new Rectangle(0,0,2,2));
                    
                    Imaging.FindOptions fOpt = new Imaging.FindOptions();
                    fOpt.Timeout = 3000;
                    Validate.ContainsImage(element, bmp, fOpt);
                    Delay.Milliseconds(100);
                }
            }
            
            else{
                Report.Info("No color value provided. Track Color not validated.");
            }
        }
        
        /// <summary>
        /// Polls a track section for a given color until either the color appears or timeout is reached
        /// </summary>
        /// <param name="window">Name of the window to find the component in</param>
        /// <param name="sectionIDs">Pipe delimited ID(s) of the trackline object to check</param>
        /// <param name="color">Color to make a swatch out of for checking against the component.  Must be from the PDSColors list</param>
        /// <param name="timeout">Timeout (in seconds) for color to appear</param>
        [UserCodeMethod]
        public static void WaitForColorOnTrackline(String window, String sectionID, String color, int timeout)
        {
            var repo = TrackLine.Instance;
            repo.window = window;
            repo.TrackLineWindow.Self.Activate();
            
            var element = Signaling.FindTrackLineAssetByContext(window, sectionID);
            
            Bitmap bmp = new Bitmap(2, 2);
            Graphics g = Graphics.FromImage(bmp);
            //Must use a named color from PDSColors
            Color checkColor = PDS_CORE.Code_Utils.PDSColors.GetColorFromString(color);
            g.FillRectangle(new SolidBrush(checkColor), new Rectangle(0,0,2,2));
            
            int i = 0;
            while(!Imaging.Contains(element, bmp, new Imaging.FindOptions()) && i < timeout)
            {
                Delay.Seconds(1);
                g.FillRectangle(new SolidBrush(checkColor), new Rectangle(0,0,2,2));
                i++;
            }
            
            if(Imaging.Contains(element, bmp, new Imaging.FindOptions()))
            {
                return;
            } else {
                Report.Failure("Wait for color to be visible has timed out");
            }
        }
        
        /// <summary>
        /// Check the trackline component to see if a color swatch does not exist in the image
        /// </summary>
        /// <param name="window">Name of the window to find the component in</param>
        /// <param name="sectionIDs">Pipe delimited ID(s) of the trackline object to check</param>
        /// <param name="color">Color to make a swatch out of for checking against the component.  Must be from the PDSColors list</param>
        [UserCodeMethod]
        public static void ValidateColorNotOnTrackline(String window, String sectionIDs, String color)
        {
            var repo = TrackLine.Instance;
            repo.window = window;
            repo.TrackLineWindow.Self.Activate();
            
            String[] sections = sectionIDs.Split('|');
            
            foreach (String sectionID in sections)
            {
                var element = Signaling.FindTrackLineAssetByContext(window, sectionID);
                
                Bitmap bmp = new Bitmap(2, 2);
                Graphics g = Graphics.FromImage(bmp);
                //Must use a named color from PDSColors
                Color checkColor = PDS_CORE.Code_Utils.PDSColors.GetColorFromString(color);
                g.FillRectangle(new SolidBrush(checkColor), new Rectangle(0,0,2,2));
                
                var hasEmt = Imaging.Contains(element, bmp, new Imaging.FindOptions());
                Validate.IsFalse(hasEmt);
                Delay.Milliseconds(100);
            }
        }
        
        [UserCodeMethod]
        public static void ValidateColorNotOnObject(Adapter objectElement, String color)
        {
            Bitmap bmp = new Bitmap(2, 2);
            
            Bitmap elementImage = Imaging.CaptureImageAuto(objectElement);
            Graphics g = Graphics.FromImage(bmp);
            //Must use a named color from PDSColors
            Color checkColor = PDS_CORE.Code_Utils.PDSColors.GetColorFromString(color);
            g.FillRectangle(new SolidBrush(checkColor), new Rectangle(0,0,2,2));
            
            var hasColor = Imaging.Contains(elementImage, bmp);
            
            if(!hasColor)
            {
                Ranorex.Report.Success("Color " +color+" not found in the object");
            }
            else
            {
                Ranorex.Report.Failure("Color " +color+" found in the object");
            }
            Delay.Milliseconds(100);
        }
        
        /// <summary>
        /// Check for any repository item if a color swatch exists in the image
        /// </summary>
        /// <param name="repoItem">Any single repository item for which a color validation is needed</param>
        /// <param name="color">Color to make a swatch out of for checking against the component.  Must be from the PDSColors list</param>
        [UserCodeMethod]
        public static void ValidateColorForAnyAdapter(Adapter repoItem, String color)
        {
            Bitmap bmp = new Bitmap(2, 2);
            Graphics g = Graphics.FromImage(bmp);
            //Must use a named color from PDSColors
            Color checkColor = PDS_CORE.Code_Utils.PDSColors.GetColorFromString(color);
            g.FillRectangle(new SolidBrush(checkColor), new Rectangle(0,0,2,2));
            
            Validate.ContainsImage(repoItem, bmp, new Imaging.FindOptions());
            Delay.Milliseconds(100);
        }
        
        /// <summary>
        /// Validates for any repository item if a color pixel exists in the image
        /// </summary>
        /// <param name="repoItem">Any single repository item for which a color validation is needed</param>
        /// <param name="color">Color to make a swatch out of for checking against the component.  Must be from the PDSColors list</param>
        /// <param name="validateExists">True to check if color exists, false to check if color doesn't exist</param>
        [UserCodeMethod]
        public static bool ValidateColorForAnyAdapterByPixel(Adapter repoItem, String color, bool validateExists = true)
        {
            HashSet<Color> colorsFound = new HashSet<Color>();
            HashSet<Color> expectedColors = new HashSet<Color>();
            //Must use a named color from PDSColors
            if (color.Contains("|")) {
                string[] colors = color.Split('|');
                foreach (string individualColor in colors) {
                    expectedColors.Add(PDS_CORE.Code_Utils.PDSColors.GetColorFromString(individualColor));
                }
            } else {
                expectedColors.Add(PDS_CORE.Code_Utils.PDSColors.GetColorFromString(color));
            }

            Bitmap itemImage = Imaging.CaptureImage(repoItem);
            Delay.Seconds(2);
            colorsFound = GetColorsFromBitmap(itemImage);
            string expectedColorsString = string.Join(", ", expectedColors);
            int preCheckHashSize = expectedColors.Count;
            expectedColors.ExceptWith(colorsFound);
            if (validateExists && expectedColors.Count == 0) {
                Ranorex.Report.Success("All colors: "+string.Join(" ",color.Split('|'))+", found in Repo Object");
                return true;
            }
            int postCheckHashSize = expectedColors.Count;
            if (!validateExists && (preCheckHashSize == postCheckHashSize)) {
                Ranorex.Report.Success("None of the colors: "+string.Join(" ",color.Split('|'))+", found in Repo Object");
                return true;
            }
            
            string notFoundColorsString = string.Join(", ", expectedColors);
            string imageColorsString = string.Join(", ", colorsFound);
            
            Report.LogData(ReportLevel.Info,"Info",itemImage);
            Ranorex.Report.Failure("Colors to search with: "+expectedColorsString+". Colors not found in Image: "+notFoundColorsString+". Colors in image: "+imageColorsString+".");
            return false;
        }
        
        /// <summary>
        /// Validates for any repository item if a color pixel exists in the image
        /// </summary>
        /// <param name="repoItem">Any single repository item for which a color validation is needed</param>
        /// <param name="color">Color to make a swatch out of for checking against the component.  Must be from the PDSColors list</param>
        /// <param name="validateExists">True to check if color exists, false to check if color doesn't exist</param>
        [UserCodeMethod]
        public static bool ValidateColorForAnyAdapterByPixel_EnsureVisible(Adapter repoItem, String color, bool validateExists = true, bool ensureVisible = true)
        {
            HashSet<Color> colorsFound = new HashSet<Color>();
            HashSet<Color> expectedColors = new HashSet<Color>();
            //Must use a named color from PDSColors
            if (color.Contains("|")) {
                string[] colors = color.Split('|');
                foreach (string individualColor in colors) {
                    expectedColors.Add(PDS_CORE.Code_Utils.PDSColors.GetColorFromString(individualColor));
                }
            } else {
                expectedColors.Add(PDS_CORE.Code_Utils.PDSColors.GetColorFromString(color));
            }

            Bitmap itemImage = null;
            if(ensureVisible)
            {
                itemImage = Imaging.CaptureImage(repoItem);
            }
            else
            {
                itemImage = Imaging.CaptureImageAuto(repoItem);
            }
            
            Delay.Seconds(2);
            colorsFound = GetColorsFromBitmap(itemImage);
            string expectedColorsString = string.Join(", ", expectedColors);
            int preCheckHashSize = expectedColors.Count;
            expectedColors.ExceptWith(colorsFound);
            int postCheckHashSize = expectedColors.Count;
            if ((validateExists && expectedColors.Count == 0) ||(preCheckHashSize < postCheckHashSize)) {
                Ranorex.Report.Success("All colors: "+string.Join(" ",color.Split('|'))+", found in Repo Object");
                return true;
            }
           // int postCheckHashSize = expectedColors.Count;
            if (!validateExists && (preCheckHashSize == postCheckHashSize)) {
                Ranorex.Report.Success("None of the colors: "+string.Join(" ",color.Split('|'))+", found in Repo Object");
                return true;
            }
            
            string notFoundColorsString = string.Join(", ", expectedColors);
            string imageColorsString = string.Join(", ", colorsFound);
            
            Report.LogData(ReportLevel.Info,"Info",itemImage);
            Ranorex.Report.Failure("Colors to search with: "+expectedColorsString+". Colors not found in Image: "+notFoundColorsString+". Colors in image: "+imageColorsString+".");
            return false;
        }
        
        /// <summary>
        /// Check for any repository item if a color pixel exists in the image
        /// </summary>
        /// <param name="repoItem">Any single repository item for which a color validation is needed</param>
        /// <param name="color">Color to make a swatch out of for checking against the component.  Must be from the PDSColors list</param>
        /// <param name="validateExists">True to check if color exists, false to check if color doesn't exist</param>
        [UserCodeMethod]
        public static bool CheckColorForAnyAdapterByPixel(Adapter repoItem, String color, bool validateExists = true)
        {
            HashSet<Color> colorsFound = new HashSet<Color>();
            HashSet<Color> expectedColors = new HashSet<Color>();
            //Must use a named color from PDSColors
            if (color.Contains("|")) {
                string[] colors = color.Split('|');
                foreach (string individualColor in colors) {
                    expectedColors.Add(PDS_CORE.Code_Utils.PDSColors.GetColorFromString(individualColor));
                }
            } else {
                expectedColors.Add(PDS_CORE.Code_Utils.PDSColors.GetColorFromString(color));
            }
            Bitmap itemImage = Imaging.CaptureImage(repoItem);
            colorsFound = GetColorsFromBitmap(itemImage);
            string expectedColorsString = string.Join(", ", expectedColors);
            int preCheckHashSize = expectedColors.Count;
            expectedColors.ExceptWith(colorsFound);
            if (validateExists && expectedColors.Count == 0) {
                return true;
            }
            int postCheckHashSize = expectedColors.Count;
            if (!validateExists && (preCheckHashSize == postCheckHashSize)) {
                return true;
            }
            
            string notFoundColorsString = string.Join(", ", expectedColors);
            string imageColorsString = string.Join(", ", colorsFound);
            
            Report.LogData(ReportLevel.Info,"Info",itemImage);
            return false;
        }
        
        public static bool CheckColorForAnyAdapterByPixelWithRetry(Adapter repoItem, string color, bool validateExists = true, int retrySeconds = 30)
        {
            if (!(retrySeconds > 0))
            {
                Report.Error("Cannot retry for zero or negative seconds");
            }
            System.DateTime tryUntil = System.DateTime.Now.AddSeconds(retrySeconds);
            
            Report.Info("Waiting for up to " + retrySeconds.ToString() + " seconds for color (" + color + ") to be " + (validateExists?"visible":"not visible"));
            
            while (System.DateTime.Now < tryUntil)
            {
                bool isColorFound = CheckColorForAnyAdapterByPixel(repoItem, color, validateExists);
                if (isColorFound == true)
                {
                    Report.Info("Found color (" + color + ")");
                    return isColorFound;
                }
                Delay.Milliseconds(1000);
            }
            
            return false;
        }
        
        /// <summary>
        /// Check for any repository item if a color pixel exists in the image. Same as ValidateColorForAnyAdapterByPixel
        /// but specified for track sections to avoid overlap of the other track section objects and also trackline devices
        /// </summary>
        /// <param name="repoItem">Any single repository item for which a color validation is needed</param>
        /// <param name="color">Color to make a swatch out of for checking against the component.  Must be from the PDSColors list</param>
        /// <param name="validateExists">True to check if color exists, false to check if color doesn't exist</param>
        [UserCodeMethod]
        public static bool CheckColorForTrackSectionAdapterByPixel(Adapter repoItem, String color, bool validateExists = true)
        {
            HashSet<Color> colorsFound = new HashSet<Color>();
            HashSet<Color> expectedColors = new HashSet<Color>();
            //Must use a named color from PDSColors
            if (color.Contains("|")) {
                string[] colors = color.Split('|');
                foreach (string individualColor in colors) {
                    expectedColors.Add(PDS_CORE.Code_Utils.PDSColors.GetColorFromString(individualColor));
                }
            } else {
                expectedColors.Add(PDS_CORE.Code_Utils.PDSColors.GetColorFromString(color));
            }
            //  Delay.Seconds(9);
            repoItem.EnsureVisible();
            Bitmap originalImage = Imaging.CaptureImage(repoItem);
            int x = Convert.ToInt32(originalImage.Width * .05);
            int width = Convert.ToInt32(originalImage.Width * .9);
            int y = Convert.ToInt32(originalImage.Height * .2);
            int height = Convert.ToInt32(originalImage.Height * .6);
            Rectangle cropTangle = new Rectangle(x, y, width, height);
            
            Bitmap itemImage = new Bitmap(cropTangle.Width, cropTangle.Height);
            Graphics itemGraphics = Graphics.FromImage(itemImage);
            itemGraphics.DrawImage(originalImage, -cropTangle.X, -cropTangle.Y);
            //   Delay.Seconds(9);
            //Offset of 5 was chosen due to it working for a specific purpose. These may need to be finer tuned later and should still work for the intended purpose
            colorsFound = GetColorsFromBitmap(itemImage);
            string expectedColorsString = string.Join(", ", expectedColors);
            int preCheckHashSize = expectedColors.Count;
            expectedColors.ExceptWith(colorsFound);
            if (validateExists && expectedColors.Count == 0) {
                //Ranorex.Report.Success("All colors: "+string.Join(" ",color.Split('|'))+", found in Repo Object");
                return true;
            }
            int postCheckHashSize = expectedColors.Count;
            if (!validateExists && (preCheckHashSize == postCheckHashSize)) {
                //Ranorex.Report.Success("None of the colors: "+string.Join(" ",color.Split('|'))+", found in Repo Object");
                return true;
            }
            
            string notFoundColorsString = string.Join(", ", expectedColors);
            string imageColorsString = string.Join(", ", colorsFound);
            
            Report.LogData(ReportLevel.Info,"Info",itemImage);
            //Ranorex.Report.Info("Colors to search with: "+expectedColorsString+". Colors not found in Image: "+notFoundColorsString+". Colors in image: "+imageColorsString+".");
            return false;
        }
        
        /// <summary>
        /// Check for occupancy in trackline repo item
        /// </summary>
        /// <param name="repoItem">Trackline repository item to check for occupancy/param>
        /// <param name="occupancyExists">Whether to check if the occupancy exists or doesn't</param>
        [UserCodeMethod]
        public static bool CheckTrackSectionAdapterForOccupancy(Element repoItem, bool occupancyExists)
        {
            string trackSectionCurrentState = repoItem.GetAttributeValue("CurrentState").ToString();
            bool occupied = false;
            if (trackSectionCurrentState.Contains(" OCC:"))
            {
                occupied = true;
            } else if (!trackSectionCurrentState.Contains(" UO:"))
            {
                Ranorex.Report.Error("Track Section does not contain whether it is occupied or unoccupied");
                return false;
            }
            
            if (occupied == occupancyExists)
            {
                return true;
            } else {
                return false;
            }
        }

        
        public static HashSet<Color> GetColorsFromBitmap(Bitmap itemImage, int xOffset = 0, int yOffset = 0) {
            HashSet<Color> uniqueColorList = new HashSet<Color>();
            for (int j = yOffset; j<itemImage.Height-yOffset; j++) {
                for (int i = xOffset; i<itemImage.Width-xOffset; i++) {
                    Color pixelColor = itemImage.GetPixel(i,j);
                    if (!uniqueColorList.Contains(pixelColor))
                    {
                        uniqueColorList.Add(pixelColor);
                    }
                }
            }
            return uniqueColorList;
        }

        /// <summary>
        /// Check the trackline component to see if a the currentState field contains the desired text
        /// </summary>
        /// <param name="window">Name of the window to find the component in</param>
        /// <param name="sectionIDs">Pipe delimited ID(s) of the trackline object to check</param>
        /// <param name="color">Text to check for</param>
        [UserCodeMethod]
        public static void ValidateCurrentStateContains(String window, String sectionIDs, String text)
        {
            String[] sections = sectionIDs.Split('|');
            
            foreach (String sectionID in sections)
            {
                var element = Signaling.FindTrackLineAssetByContext(window, sectionID);
                
                String currentState = element.Element.GetAttributeValue("currentState").ToString();
                
                if (currentState.Contains(text))
                {
                    Report.Info(String.Format("Found '{0}' in trackline object '{1}'", text, sectionID));
                }
                else
                {
                    Report.Error(String.Format("Did not find '{0}' in trackline object '{1}' in currentState '{2}'", text, sectionID, currentState));
                }
                
                Delay.Milliseconds(100);
            }
        }
        
        /// <summary>
        /// Sets offset date time in repo item
        /// </summary>
        /// <param name="repoItem">repository element</param>
        /// <param name="offsetInMinutes">The amount of minutes in the future from current time</param>
        [UserCodeMethod]
        public static void typeFutureDateTime(Adapter repoItem, String offsetInMinutes)
        {
            if(!String.IsNullOrEmpty(offsetInMinutes))
            {
                String futureDateTime = CreateTimestampWithOffset(offsetInMinutes);
                Report.Info(String.Format("Set '{0}' to the '{1}'", repoItem, futureDateTime));
                repoItem.PressKeys(futureDateTime);
            }
            else
            {
                Report.Info(" No Offset value given.");
            }
        }
        
        /// <summary>
        /// Selects multiple trackline assets by holding control and then clicking on each asset.
        /// This would usually be used when issuing multiple tags.
        /// </summary>
        /// <param name="window">window name</param>
        /// <param name="sectionIDs"> Section IDs seperated by '|'</param>
        [UserCodeMethod]
        public static void SelectMultipleTracklineAssets(String window, String sectionIDs)
        {
            String[] sections = sectionIDs.Split('|');
            Keyboard.Down(Keys.ControlKey);
            
            foreach(String sectionID in sections)
            {
                var element = Signaling.FindTrackLineAssetByContext(window, sectionID);
                element.Click();
            }
            Keyboard.Up(Keys.ControlKey);
        }
        
        /// <summary>
        /// This function validates the feedback text message for the RepoItem passed in as an argument.
        /// </summary>
        /// <param name="repoItem">Single Feedback repository item for which a Feedback validation is needed</param>
        /// <param name="expectedFeedback">The Expected Feedback which needs to be compared with the Actual Feedback</param>
        [UserCodeMethod]
        public static void validateAnyFeedback(Adapter repoItem, String expectedFeedback)
        {
            String actualFeedback ="";
            
            try
            {
                actualFeedback = repoItem.Element.GetAttributeValueText("Caption").Trim();
            }
            catch(Exception ex)
            {
                Validate.Fail("Invalid Feedback RepoItem. " + ex.Message);
            }

            if(actualFeedback.Equals(expectedFeedback))
            {
                Report.Success("Validation", String.Format("Displayed Feedback Message:{0}",actualFeedback));
            }
            else if(actualFeedback == null | actualFeedback.Equals(""))
            {
                Validate.Fail("No Feedback Message displayed.");
            }
            else
            {
                Report.Failure("Validation", String.Format("Displayed Feedback Message: {0}",actualFeedback));
                
                //Commented since Failure needed in Report and need the script to exxecute further.
                //Validate.Fail(String.Format("Displayed Feedback Message: {0}",actualFeedback));
            }
        }
        
        /// <summary>
        /// This function will validate any text for the given adapter [Containing Special Characters]
        /// </summary>
        /// <param name="textAdapter">Input: Adapter with Special Characters Text</param>
        /// <param name="expectedText">Input: User provided expected text</param>
        [UserCodeMethod]
        public static void validateSpecialCharacterText(Adapter textAdapter, string expectedText)
        {
            string textActual = textAdapter.Element.GetAttributeValueText("Text").Trim();
            string decodeXml = System.Net.WebUtility.HtmlDecode(textActual);
            
            if (decodeXml.Contains(expectedText))
            {
                Report.Success(String.Format("Found a matching value {0} in the text  {1}", expectedText, decodeXml));
            }
            else
            {
                Report.Failure(String.Format("Did not found a matching value {0} in the text {1}", expectedText, decodeXml));
            }
        }
        
        /// <summary>
        /// Create a timestamp for typing into forms using an offset from Now instead of a hardcoded time
        /// This method returns Null if we are passing null in variabel "offsetInMinutes"
        /// </summary>
        /// <param name="offsetInMinutes">Number of minutes in the future</param>
        /// <returns></returns>
        [UserCodeMethod]
        public static String CreateTimestampWithZoneAndOffset(String offsetInMinutes, String desiredZone = "E")
        {
            // Adding condition to check if time is not blank
            if(!(offsetInMinutes == ""))
            {
                // TODO Add some error handling here for invalid input
                System.DateTime current = System.DateTime.Now;
                current = current.AddMinutes(Convert.ToInt32(offsetInMinutes));
                
                int cTimeZone;
                int dTimeZone;
                int offsetInHours = 0;
                
                // Get the first letter for the timezone
                String currentTimeZone = TimeZone.CurrentTimeZone.StandardName.Substring(0,1).ToLower();
                desiredZone = desiredZone.ToLower();

                switch(currentTimeZone)
                {
                    case "p":
                        cTimeZone = (int)timeZoneShifting.P;
                        break;
                    case "m":
                        cTimeZone = (int)timeZoneShifting.M;
                        break;
                    case "c":
                        cTimeZone = (int)timeZoneShifting.C;
                        break;
                    case "e":
                    default:
                        cTimeZone = (int)timeZoneShifting.E;
                        break;
                }
                
                switch(desiredZone)
                {
                    case "p":
                        dTimeZone = (int)timeZoneShifting.P;
                        break;
                    case "m":
                        dTimeZone = (int)timeZoneShifting.M;
                        break;
                    case "c":
                        dTimeZone = (int)timeZoneShifting.C;
                        break;
                    case "e":
                    default:
                        dTimeZone = (int)timeZoneShifting.E;
                        break;
                }

                if (cTimeZone > dTimeZone)
                {
                    // negative offset to adjust east to west zones
                    offsetInHours = dTimeZone - cTimeZone;
                    Report.Info(offsetInHours.ToString());
                }
                else if (cTimeZone < dTimeZone)
                {
                    // positive offset to adjust west to east zones
                    offsetInHours = dTimeZone - cTimeZone;
                    Report.Info(offsetInHours.ToString());
                }
                else
                {
                    offsetInHours = 0;
                }
                
                current = current.AddHours(Convert.ToInt32(offsetInHours));
                
                return GetDateTimeWithTimeZoneFormat(current, desiredZone.ToUpper());
            }
            
            else
            {
                return offsetInMinutes;
            }
        }
        
        /// <summary>
        /// This function takes in string values, converts them into UTC Time Objects and performs a comparison.
        /// </summary>
        /// <param name="startTime">String Input: Start time of a range</param>
        /// <param name="endTime">String Input: End time of a range</param>
        /// <param name="checkTime">String Input: Check this Time value present in the range</param>
        /// <returns>Boolean Output: True / False Flag</returns></returns>
        [UserCodeMethod]
        public static bool isTimeInRange(String startTime, String endTime, String checkTime)
        {
            System.DateTime oDatebeforeClick  = TimeZoneInfo.ConvertTimeToUtc(Convert.ToDateTime(startTime.Remove(17, 3)), returnTimeZone(startTime));
            System.DateTime oDateafterClick  = TimeZoneInfo.ConvertTimeToUtc(Convert.ToDateTime(endTime.Remove(17, 3)), returnTimeZone(endTime));
            System.DateTime oDatefromPDS  = TimeZoneInfo.ConvertTimeToUtc(Convert.ToDateTime(checkTime.Remove(17, 3)), returnTimeZone(checkTime));
            
            if(oDatebeforeClick <= oDatefromPDS && oDatefromPDS <= oDateafterClick)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// This function returns the PDS-Timezone object required by the isTimeInRange function.
        /// </summary>
        /// <param name="timeValue">String Input: Time in particular PDS format dd-mm-yyyy hh:mm Timezone</param>
        /// <returns>Object: TimeZoneInfo</returns>
        public static TimeZoneInfo returnTimeZone(String timeValue)
        {
            TimeZoneInfo returnZone = null;
            
            if(timeValue.ToUpper().Contains("EDT") | timeValue.ToUpper().Contains("EST"))
            {
                returnZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            }
            else if(timeValue.ToUpper().Contains("PDT") | timeValue.ToUpper().Contains("PST"))
            {
                returnZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            }
            else if(timeValue.ToUpper().Contains("MDT") | timeValue.ToUpper().Contains("MST"))
            {
                returnZone = TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time");
            }
            else if(timeValue.ToUpper().Contains("CDT") | timeValue.ToUpper().Contains("CST"))
            {
                returnZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            }
            
            return returnZone;
        }

        /// <summary>
        /// Captures image of repo item, then stores it in a Dictionary. Used for comparing before/after images of an item
        /// </summary>
        /// <param name="repoItem">Adapter for repo item</param>
        /// <param name="itemName">Name of the repo item, used as Dictionary key</param>
        [UserCodeMethod]
        public static void captureAndPersist(Adapter repoItem, string itemName)
        {
            Bitmap itemImage = Imaging.CaptureImage(repoItem);
            Report.LogData(ReportLevel.Info,"Info", itemImage);
            Ranorex.Report.Info("Storing image for repo item " + itemName + ". Please use '" + itemName + "' as the key for lookup");
            persistedImages.Add(itemName, itemImage);
        }
        
        /// <summary>
        /// Compares an image stored from the captureAndPersist(...) method and compares it to a current image of the repo item.
        /// This is used for before/after image validation (i.e. to verify no changes have been made when an action occurs)
        /// </summary>
        /// <param name="repoItem">Adapter for repo item</param>
        /// <param name="itemName">Name of the repo item, used as Dictionary key</param>
        [UserCodeMethod]
        public static void compareImages(Adapter repoItem, string itemName)
        {
            Bitmap img = new Bitmap(2, 2);

            Ranorex.Report.Info("Looking up image for repo item " + itemName);
            try {
                persistedImages.TryGetValue(itemName, out img);
            } catch(RanorexException) {
                Ranorex.Report.Failure("Failed image lookup for image for repo item " + itemName);
                Validate.IsTrue(false);
            }
            Report.LogData(ReportLevel.Info,"Info", Imaging.CaptureImage(repoItem));
            
            Validate.ContainsImage(repoItem, img, Imaging.FindOptions.Default, "Image validation", true);
        }
        
        
        /// <summary>
        /// This function will wait for the mouse cursor to change from the WaitCursor to anything different
        /// (This may need to be tweaked in the future for other mouse states)
        /// If the cursor doesn't change from the waitState cursor in 'maxTimeInSeconds' seconds it will
        /// write a log entry and continue.
        /// </summary>
        /// <param name="maxTimeInSeconds">This is the maximum time it will wait (in seconds)</param>
        [UserCodeMethod]
        public static void CheckWaitState(int maxTimeInSeconds)
        {
            bool hadToWait = false;
            
            if (maxTimeInSeconds <= 0)
            {
                Report.Info("CheckWaitState time must be > 0.  Defaulting to 10s");
                maxTimeInSeconds = 10;
            }
            
            System.Diagnostics.Stopwatch newWatch = System.Diagnostics.Stopwatch.StartNew();
            
            while ((Mouse.Cursor == System.Windows.Forms.Cursors.WaitCursor) && newWatch.Elapsed.Seconds <= maxTimeInSeconds)
            {
                // Log the mouse cursor name (should be WaitCursor if you are here) just for logging to know what is going on
                Report.Info(String.Format("Current mouse cursor name: {0}", Mouse.CursorName));
                hadToWait = true;
                Delay.Milliseconds(1000);
            }
            
            if(hadToWait)
            {
                Report.Info(String.Format("Current mouse cursor name: {0}", Mouse.CursorName));
                Delay.Milliseconds(1000);
            }
            
            if (newWatch.Elapsed.Seconds > maxTimeInSeconds)
            {
                Report.Error(String.Format("Took longer than {0} seconds for the mouse to clear the wait state.", maxTimeInSeconds.ToString()));
            }
            
            newWatch.Stop();
        }
        
        /// <summary>
        /// This function presses the desired button then looks for the "waitFor" object to cease to exist.
        /// </summary>
        /// <param name="button">ButtonInfo to identify and press/click</param>
        /// <param name="waitFor">The objectInfo item to wait for to konw the button press worked</param>
        [UserCodeMethod]
        public static void ClickAndWaitForNotExistWithRetry(Ranorex.Core.Repository.RepoItemInfo buttonInfo, Ranorex.Core.Repository.RepoItemInfo waitFor)
        {
            Ranorex.Adapter button = buttonInfo.CreateAdapter<Unknown>(true);
            
            if (buttonInfo.Exists(0))
            {
                button.Click();
            }
            else
            {
                Report.Failure("button does not exist, cannot click it");
                return;
            }

            
            Delay.Milliseconds(50);
            // If the object disappears immediately, then don't wait
            if (!waitFor.Exists(0))
            {
                return;
            }
            
            for (int x = 0; x < 3; x++)
            {
                Delay.Milliseconds(1000);
                CheckWaitState(10);
                if (waitFor.Exists(0))
                {
                    Report.Info("Found waitFor item (should not exist), clicking again");
                    if (buttonInfo.Exists(0) && button.Valid)
                    {
                        button.Click();
                    }
                }
                else
                {
                    return;
                }
            }

            // Account for the last button click
            if (waitFor.Exists(0) == waitFor.UseEnsureVisible)
            {
                Report.Screenshot();
                Report.Error("Item that should close still exists");
            }
        }
        
        /// <summary>
        /// This function middle presses the desired button then looks for the "waitFor" object to cease to exist.
        /// </summary>
        /// <param name="button">ButtonInfo to identify and press/click</param>
        /// <param name="waitFor">The objectInfo item to wait for to konw the button press worked</param>
        [UserCodeMethod]
        public static void MiddleClickAndWaitForNotExistWithRetry(Ranorex.Core.Repository.RepoItemInfo buttonInfo, Ranorex.Core.Repository.RepoItemInfo waitFor)
        {
            Ranorex.Adapter button = buttonInfo.CreateAdapter<Unknown>(true);
            
            if (buttonInfo.Exists(0))
            {
                button.Click();
            }
            else
            {
                Report.Failure("button does not exist, cannot click it");
                return;
            }

            
            Delay.Milliseconds(50);
            // If the object disappears immediately, then don't wait
            if (!waitFor.Exists(0))
            {
                return;
            }
            
            for (int x = 0; x < 3; x++)
            {
                Delay.Milliseconds(500);
                CheckWaitState(10);
                if (waitFor.Exists(0))
                {
                    Report.Info("Found waitFor item (should not exist), clicking again");
                    
                    if (buttonInfo.Exists(0) && button.Valid)
                    {
                        button.Click(System.Windows.Forms.MouseButtons.Middle);
                    }
                }
                else
                {
                    return;
                }
            }

            // Account for the last button click
            if (waitFor.Exists(0) == waitFor.UseEnsureVisible) //UseEnsureVisible : Checks the visibility of Object
            {
                Report.Screenshot();
                Report.Error("Item that should close still exists");
            }
        }

        [UserCodeMethod]
        public static void LeftClickAndWaitForWithRetry(Ranorex.Core.Repository.RepoItemInfo button,
                                                        Ranorex.Core.Repository.RepoItemInfo waitFor)
        {
            GeneralUtilities.ClickAndWaitForWithRetry(button, waitFor, System.Windows.Forms.MouseButtons.Left);
        }

        [UserCodeMethod]
        public static void RightClickAndWaitForWithRetry(Ranorex.Core.Repository.RepoItemInfo button,
                                                         Ranorex.Core.Repository.RepoItemInfo waitFor)
        {
            GeneralUtilities.ClickAndWaitForWithRetry(button, waitFor, System.Windows.Forms.MouseButtons.Right);
        }

        
        
        public static void NestedClickAndWaitForWithRetry(
            Ranorex.Core.Repository.RepoItemInfo buttonOneInfo, Ranorex.Core.Repository.RepoItemInfo buttonTwoInfo, Ranorex.Core.Repository.RepoItemInfo waitForInfo,
            System.Windows.Forms.MouseButtons mouseButtonOne = System.Windows.Forms.MouseButtons.Left, System.Windows.Forms.MouseButtons mouseButtonTwo = System.Windows.Forms.MouseButtons.Left
           ) {
            Ranorex.Adapter buttonOne = buttonOneInfo.CreateAdapter<Unknown>(true);
            Ranorex.Adapter buttonTwo = buttonTwoInfo.CreateAdapter<Unknown>(true);

            GeneralUtilities.ClickAndWaitForWithRetry(buttonOneInfo, buttonTwoInfo, mouseButtonOne);
            if (buttonTwoInfo.Exists(0))
            {
                buttonTwo.Click(mouseButtonTwo);

                Delay.Milliseconds(1000);
                if (waitForInfo.Exists(0))
                {
                    return;
                }
            }
            
            // If unsuccessful on first attempt, then try some variant repeat.
            int retries = 0;
            while (!waitForInfo.Exists(0) && retries < 3)
            {
                // TODO: What if final repo item appears during the method execution below?
                // Wouldn't this method often fail in such a scenario, given that prior repo items might not be accessible once this repo item appears?
                // If the answer is sometimes yes, then how can this method be replaced by something more effective?
                GeneralUtilities.ClickAndWaitForWithRetry(buttonOneInfo, buttonTwoInfo, mouseButtonOne);
                
                if (buttonTwoInfo.Exists(0))
                {
                    buttonTwo.Click(mouseButtonTwo);
                    Delay.Milliseconds(1000);
                    if (waitForInfo.Exists(0))
                    {
                        return;
                    }
                }
                retries++;
            }
        }
        
        // Set as globals to increase the effeciency of the click and wait function.  This way it only sets the value once.
        static String rapidClickParam = "False";
        static int initialDelayTime = 0;
        /// <summary>
        /// This function presses the desired button then looks for the "waitFor" object to exist.
        /// </summary>
        /// <param name="button">ButtonInfo to identify and press/click</param>
        /// <param name="waitFor">The objectInfo item to wait for to know the button press worked</param>
        /// <param name="waitFor">Mouse button to click</param>
        public static void ClickAndWaitForWithRetry(Ranorex.Core.Repository.RepoItemInfo buttonInfo,
                                                    Ranorex.Core.Repository.RepoItemInfo waitForInfo       ,
                                                    System.Windows.Forms.MouseButtons mouseButton = System.Windows.Forms.MouseButtons.Left)
        {
            if (initialDelayTime == 0)
            {
                try
                {
                    rapidClickParam = TestSuite.Current.Parameters["RapidClick"];
                }
                catch (Exception ex)
                {
                    rapidClickParam = "False";
                    Report.Info("Test Suite parameter 'RapidClick' not found.  Defaulting to false.  Error : " + ex.Message);
                }
                
                
                if (rapidClickParam.ToLower().Equals("true"))
                {
                    initialDelayTime = 50;
                }
                else
                {
                    initialDelayTime = 500;
                }
            }
            
            if (buttonInfo.Exists(0))
            {
                buttonInfo.CreateAdapter<Unknown>(true).Click(mouseButton);
            }
            else
            {
                Report.Failure("button does not exist, cannot click it");
                return;
            }
            
            Delay.Milliseconds(initialDelayTime);
            // if the form exists immediately, then do not wait.
            if (waitForInfo.Exists(0))
            {
                return;
            }
            
            for (int x = 0; x < 3; x++)
            {
                // If the system is in a wait state, try to give it a little extra time to finish the process
                CheckWaitState(5);
                Delay.Milliseconds(1000);
                if (!waitForInfo.Exists(0))
                {
                    Report.Info("Did not find waitFor item, clicking again");
                    Report.Info("Item full name: " + waitForInfo.FullName);
                    if (buttonInfo.Exists(0))
                    {
                        buttonInfo.CreateAdapter<Unknown>(true).Click(mouseButton);
                    }
                }
                else
                {
                    return;
                }
            }
            
            // Account for the final button press by checking one more time
            Delay.Milliseconds(1000);
            if (!waitForInfo.Exists(0))
            {
                Report.Error("Did not find item we were waiting for.");
            }
        }
        
        /// <summary>
        /// This function double clicks the desired button then looks for the "waitFor" object to exist.
        /// </summary>
        /// <param name="button">ButtonInfo to identify and press/click</param>
        /// <param name="waitFor">The objectInfo item to wait for to know the button press worked</param>
        /// <param name="waitFor">Mouse button to click</param>
        public static void DoubleClickAndWaitForWithRetry(Ranorex.Core.Repository.RepoItemInfo buttonInfo,
                                                    Ranorex.Core.Repository.RepoItemInfo waitForInfo       ,
                                                    System.Windows.Forms.MouseButtons mouseButton = System.Windows.Forms.MouseButtons.Left)
        {
            if (initialDelayTime == 0)
            {
                try
                {
                    rapidClickParam = TestSuite.Current.Parameters["RapidClick"];
                }
                catch (Exception ex)
                {
                    rapidClickParam = "False";
                    Report.Info("Test Suite parameter 'RapidClick' not found.  Defaulting to false.  Error : " + ex.Message);
                }
                
                
                if (rapidClickParam.ToLower().Equals("true"))
                {
                    initialDelayTime = 50;
                }
                else
                {
                    initialDelayTime = 500;
                }
            }
            
            if (buttonInfo.Exists(0))
            {
                buttonInfo.CreateAdapter<Unknown>(true).DoubleClick(mouseButton);
            }
            else
            {
                Report.Failure("button does not exist, cannot click it");
                return;
            }
            
            Delay.Milliseconds(initialDelayTime);
            // if the form exists immediately, then do not wait.
            if (waitForInfo.Exists(0))
            {
                return;
            }
            
            for (int x = 0; x < 3; x++)
            {
                // If the system is in a wait state, try to give it a little extra time to finish the process
                CheckWaitState(5);
                Delay.Milliseconds(1000);
                if (!waitForInfo.Exists(0))
                {
                    Report.Info("Did not find waitFor item, clicking again");
                    Report.Info("Item full name: " + waitForInfo.FullName);
                    if (buttonInfo.Exists(0))
                    {
                        buttonInfo.CreateAdapter<Unknown>(true).DoubleClick(mouseButton);
                    }
                }
                else
                {
                    return;
                }
            }
            
            // Account for the final button press by checking one more time
            Delay.Milliseconds(1000);
            if (!waitForInfo.Exists(0))
            {
                Report.Error("Did not find item we were waiting for.");
            }
        }
        
        
        /// <summary>
        /// This function presses the desired button then looks for the "waitFor" object to exist.
        /// </summary>
        /// <param name="button">ButtonInfo to identify and press/click</param>
        /// <param name="waitFor">The objectInfo item to wait for to know the button press worked</param>
        /// <param name="waitFor">Mouse button to click</param>
        public static void MiddleClickAndWaitForWithRetry(Ranorex.Core.Repository.RepoItemInfo buttonInfo,
                                                          Ranorex.Core.Repository.RepoItemInfo waitForInfo       ,
                                                          System.Windows.Forms.MouseButtons mouseButton = System.Windows.Forms.MouseButtons.Middle)
        {
            if (initialDelayTime == 0)
            {
                try
                {
                    rapidClickParam = TestSuite.Current.Parameters["RapidClick"];
                }
                catch (Exception ex)
                {
                    rapidClickParam = "False";
                    Report.Info("Test Suite parameter 'RapidClick' not found.  Defaulting to false.  Error : " + ex.Message);
                }
                
                
                if (rapidClickParam.ToLower().Equals("true"))
                {
                    initialDelayTime = 50;
                }
                else
                {
                    initialDelayTime = 500;
                }
            }
            
            if (buttonInfo.Exists(0))
            {
                buttonInfo.CreateAdapter<Unknown>(true).Click(mouseButton);
            }
            else
            {
                Report.Failure("button does not exist, cannot click it");
                return;
            }
            
            Delay.Milliseconds(initialDelayTime);
            // if the form exists immediately, then do not wait.
            if (waitForInfo.Exists(0))
            {
                return;
            }
            
            for (int x = 0; x < 3; x++)
            {
                // If the system is in a wait state, try to give it a little extra time to finish the process
                CheckWaitState(5);
                Delay.Milliseconds(1000);
                if (!waitForInfo.Exists(0))
                {
                    Report.Info("Did not find waitFor item, clicking again");
                    Report.Info("Item full name: " + waitForInfo.FullName);
                    if (buttonInfo.Exists(0))
                    {
                        buttonInfo.CreateAdapter<Unknown>(true).Click(mouseButton);
                    }
                }
                else
                {
                    return;
                }
            }
            
            // Account for the final button press by checking one more time
            Delay.Milliseconds(1000);
            if (!waitForInfo.Exists(0))
            {
                Report.Error("Did not find item we were waiting for.");
            }
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buttonInfo"></param>
        /// <param name="waitForInfo"></param>
        /// <param name="objProperty"></param>
        /// <param name="propertyVal"></param>
        /// <param name="mouseButton"></param>
        public static void ClickAndWaitForObjValueWithRetry(Ranorex.Core.Repository.RepoItemInfo buttonInfo,
                                                            Ranorex.Core.Repository.RepoItemInfo waitForInfo, string objProperty, string propertyVal,
                                                            System.Windows.Forms.MouseButtons mouseButton = System.Windows.Forms.MouseButtons.Left)
        {
            ClickAndWaitForWithRetry(buttonInfo, waitForInfo, mouseButton);
            if (!waitForInfo.Exists(0)) { return; } //Failed, dont do the rest

            for (int x = 0; x < 3; x++)
            {
                // If the system is in a wait state, try to give it a little extra time to finish the process
                CheckWaitState(5);
                try
                {
                    waitForInfo.WaitForAttributeEqual(1000, objProperty, propertyVal);
                    Ranorex.Report.Info("Object {"+waitForInfo.ToString()+"} found with {"+objProperty+"} value {"+propertyVal+"}.");
                    return;
                } catch(RanorexException)
                {
                    if (!waitForInfo.Exists(0))
                    {
                        Report.Info("Did not find waitFor item with correct value, clicking again");
                        Report.Info("Item full name: " + waitForInfo.FullName);
                        if (buttonInfo.Exists(0))
                        {
                            buttonInfo.CreateAdapter<Unknown>(true).Click(mouseButton);
                        }
                    }
                    continue;
                }

            }
            
            // Account for the final button press by checking one more time
            Delay.Milliseconds(1000);
            if (!waitForInfo.Exists(0))
            {
                Report.Error("Did not find item we were waiting for.");
            }
        }

        /// <summary>
        /// This function presses the desired button then waits for the "waitfor" object to be enabled.
        /// </summary>
        /// <param name="button">Button to press/click</param>
        /// <param name="waitFor">The objectInfo item to wait for enabled to know the button press worked</param>
        [UserCodeMethod]
        public static void LeftClickAndWaitForEnabledWithRetry(Ranorex.Core.Repository.RepoItemInfo buttonInfo,
                                                               Ranorex.Core.Repository.RepoItemInfo waitForInfo)
        {
            ClickAndWaitForEnabledWithRetry(buttonInfo, waitForInfo, System.Windows.Forms.MouseButtons.Left);
        }
        
        /// <summary>
        /// This function presses the desired button then waits for the "waitfor" object to be enabled.
        /// </summary>
        /// <param name="button">Button to press/click</param>
        /// <param name="waitFor">The objectInfo item to wait for enabled to know the button press worked</param>
        [UserCodeMethod]
        public static void ClickAndWaitForEnabledWithRetry(Ranorex.Core.Repository.RepoItemInfo buttonInfo,
                                                           Ranorex.Core.Repository.RepoItemInfo waitForInfo,
                                                           System.Windows.Forms.MouseButtons mouseButton = System.Windows.Forms.MouseButtons.Left)
        {
            Ranorex.Adapter button = buttonInfo.CreateAdapter<Unknown>(true);
            Ranorex.Adapter waitFor = waitForInfo.CreateAdapter<Unknown>(true);
            
            if (buttonInfo.Exists(0))
            {
                button.Click(mouseButton);
            }
            else
            {
                Report.Failure("button does not exist, cannot click it");
                return;
            }

            
            for (int x = 0; x < 3; x++)
            {
                if (!waitFor.Enabled)
                {
                    Report.Info("waitFor item not enabled, clicking again");
                    Report.Info("Item full name: " + waitForInfo.FullName);
                    Delay.Milliseconds(1000);
                    
                    if (buttonInfo.Exists(0))
                    {
                        button.Click(mouseButton);
                    }
                }
                else
                {
                    return;
                }
            }
            
            Delay.Milliseconds(100);
            if (!waitFor.Enabled)
            {
                Report.Error("waitFor item did not become enabled.");
            }
        }
        
        /// <summary>
        /// This function presses the desired button then waits for the "waitfor" object to be disabled.
        /// </summary>
        /// <param name="button">Button to press/click</param>
        /// <param name="waitFor">The objectInfo item to wait for disabled to know the button press worked</param>
        public static void ClickAndWaitForDisabledWithRetry(Ranorex.Core.Repository.RepoItemInfo buttonInfo,
                                                            Ranorex.Core.Repository.RepoItemInfo waitForInfo,
                                                            System.Windows.Forms.MouseButtons mouseButton = System.Windows.Forms.MouseButtons.Left)
        {
            Ranorex.Adapter button = buttonInfo.CreateAdapter<Unknown>(true);
            Ranorex.Adapter waitFor = waitForInfo.CreateAdapter<Unknown>(true);
            
            if (buttonInfo.Exists(0))
            {
                button.Click(mouseButton);
            }
            else
            {
                Report.Failure("button does not exist, cannot click it");
                return;
            }

            
            for (int x = 0; x < 3; x++)
            {
                if (waitFor.Enabled)
                {
                    Report.Info("waitFor item not disabled, clicking again");
                    Report.Info("Item full name: " + waitForInfo.FullName);
                    Delay.Milliseconds(1000);
                    
                    if (buttonInfo.Exists(0))
                    {
                        button.Click(mouseButton);
                    }
                }
                else
                {
                    return;
                }
            }
            
            Delay.Milliseconds(100);
            if (waitFor.Enabled)
            {
                Report.Error("waitFor item did not become disabled.");
            }
        }
        
        /// <summary>
        /// This function left clicks on the desired button then waits for the "waitfor" object to be enabled.
        /// </summary>
        /// <param name="button">Button to press/click</param>
        /// <param name="waitFor">The objectInfo item to wait for disbaled to know the button press worked</param>
        [UserCodeMethod]
        public static void LeftClickAndWaitForDisabledWithRetry(Ranorex.Core.Repository.RepoItemInfo button,
                                                                Ranorex.Core.Repository.RepoItemInfo waitFor)
        {
            GeneralUtilities.ClickAndWaitForDisabledWithRetry(button, waitFor, System.Windows.Forms.MouseButtons.Left);
        }
        
        /// <summary>
        /// This method will click an object from the repo and wait for a form to appear with
        /// the title bar like 'String waitFor' (e.g., 'GBO Summary Report')
        /// </summary>
        /// <param name="button">Repo item button to click</param>
        /// <param name="waitFor">Title of the form to look for (regex matching with ~)</param>
        [UserCodeMethod]
        public static void ClickAndWaitForFormTitleWithRetry(Ranorex.Core.Repository.RepoItemInfo buttonInfo,
                                                             String waitFor)
        {
            Ranorex.Form formAdapter;
            String formXpath = String.Format("//form[@title~'{0}' and @visible='True']", waitFor);
            
            Ranorex.Adapter button = buttonInfo.CreateAdapter<Unknown>(true);
            
            if (buttonInfo.Exists(0))
            {
                button.Click();
            }
            else
            {
                Report.Failure("button does not exist, cannot click it");
                return;
            }
            
            if (Host.Local.TryFindSingle<Ranorex.Form>(formXpath, 0, out formAdapter))
            {
                formAdapter.Activate();
                return;
            }
            
            for (int x = 0; x < 3; x++)
            {
                Delay.Milliseconds(1000);
                if (Host.Local.TryFindSingle<Ranorex.Form>(formXpath, 0, out formAdapter))
                {
                    formAdapter.Activate();
                    return;
                }
                else
                {
                    Report.Info(String.Format("Did not find form title '{0}', clicking again", waitFor));
                    if (buttonInfo.Exists(0))
                    {
                        button.Click();
                    }
                }
            }
            
            // Account for the final button press by checking one more time
            Delay.Milliseconds(1000);
            if (!Host.Local.TryFindSingle(formXpath, 0, out formAdapter))
            {
                Report.Error(String.Format("Did not find form title '{0}', clicking again", waitFor));
            }
            
            return;
        }

        /// <summary>
        /// This function presses the desired button then waits for the "waitfor" object to be enabled.
        /// </summary>
        /// <param name="button">Button to press/click</param>
        /// <param name="waitFor">The objectInfo item to wait for enabled to know the button press worked</param>
        /// <param name="attributeName">The name of the attribute you want the value from</param>
        /// <param name="attributeValue">The String value to wait for</param>
        /// <param name="mouseButton">A System.Windows.Froms.MouseButtons of which button to press (default Left)</param>
        public static void ClickAndWaitForAttributeEqualWithRetry(Ranorex.Core.Repository.RepoItemInfo buttonInfo,
                                                                  Ranorex.Adapter waitFor,
                                                                  String attributeName,
                                                                  String attributeValue,
                                                                  System.Windows.Forms.MouseButtons mouseButton = System.Windows.Forms.MouseButtons.Left)
        {
            // This is still in development - Use at your own risk
            Ranorex.Adapter button = buttonInfo.CreateAdapter<Unknown>(true);
            //Ranorex.Adapter waitFor = waitForInfo.CreateAdapter<Unknown>(true);
            String currentAttributeValue = "";

            Report.Info("Checking for " + attributeName +" " + attributeValue);
            
            if (buttonInfo.Exists(0))
            {
                button.Click(mouseButton);
            }
            else
            {
                Report.Failure("button does not exist, cannot click it");
                return;
            }

            
            for (int x = 0; x < 3; x++)
            {
                currentAttributeValue = waitFor.Element.GetAttributeValueText(attributeName);

                Report.Info("current value " + currentAttributeValue);
                if (!currentAttributeValue.Equals(attributeValue, StringComparison.OrdinalIgnoreCase))
                {
                    Report.Info("waitFor item attribute[" + attributeName + "] does not equal expected: " + attributeValue + " Actual(" + currentAttributeValue + ") clicking again");
                    //Report.Info("Item full name: " + waitFor.FullName);
                    Delay.Milliseconds(1000);
                    
                    if (buttonInfo.Exists(0))
                    {
                        button.Click(mouseButton);
                    }
                }
                else
                {
                    return;
                }
            }
            
            Delay.Milliseconds(100);
            if (!currentAttributeValue.Equals(attributeValue, StringComparison.OrdinalIgnoreCase))
            {
                Report.Error("waitFor item attribute[" + attributeName + "] never became expected: " + attributeValue + " Actual(" + currentAttributeValue + ") clicking again");
            }
        }

        
        /// <summary>
        /// This function waits for the "waitfor" object to be equal to the value provided specifically if it is a button to wait for Enabled True or False.
        /// </summary>
        /// <param name="waitFor">The objectInfo item to wait for enabled to know the button press worked</param>
        /// <param name="attributeName">The name of the attribute you want the value from</param>
        /// <param name="attributeValue">The String value to wait for</param>
        /// <param name="mouseButton">A System.Windows.Froms.MouseButtons of which button to press (default Left)</param>
        [UserCodeMethod]
        public static void WaitForAttributeEqualWithRetry(Ranorex.Adapter waitFor,
                                                                  string attributeName,
                                                                  string attributeValue)
        {
            String currentAttributeValue = "";

            Report.Info("Checking for " + attributeName +" " + attributeValue);
            
            
            for (int x = 0; x < 5; x++)
            {
                currentAttributeValue = waitFor.Element.GetAttributeValueText(attributeName);

                Report.Info("current value " + currentAttributeValue);
                if (!currentAttributeValue.Equals(attributeValue, StringComparison.OrdinalIgnoreCase))
                {
                    Report.Info("waitFor item attribute[" + attributeName + "] does not equal expected: " + attributeValue + " Actual(" + currentAttributeValue + ") clicking again");
                    //Report.Info("Item full name: " + waitFor.FullName);
                    Delay.Milliseconds(2000);
                    GeneralUtilities.CheckWaitState(5);
                }
                else
                {
                	return;
                }
            }
            
            Delay.Milliseconds(100);
            if (!currentAttributeValue.Equals(attributeValue, StringComparison.OrdinalIgnoreCase))
            {
                Report.Error("waitFor item attribute[" + attributeName + "] never became expected: " + attributeValue + " Actual(" + currentAttributeValue + ") clicking again");
            }
        }
        
        /// <summary>
        /// Checks the checkbox item to ensure that it got checked.  If it did not, then it will attempt to check it again.
        /// </summary>
        /// <param name="checkbox">Checkbox repo item to check and validate/retry</param>
        public static void CheckCheckboxAndVerifyChecked(Ranorex.CheckBox checkbox)
        {
            int maxRetries = 3;
            if (!checkbox.Checked)
            {
                checkbox.Click();
            }
            else
            {
                Report.Info("Checkbox was already checked");
            }
            
            while (!checkbox.Checked)
            {
                checkbox.Click();
                Delay.Milliseconds(250);
                maxRetries--;
                if (maxRetries <= 0)
                {
                    Report.Error("Checkbox did not get checked");
                    Report.Screenshot(checkbox.Parent);
                    break;
                }
            }
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static void CheckCheckboxAdapterAndVerifyChecked(RepoItemInfo checkboxAdapter)
        {
            Ranorex.CheckBox newCheckbox = checkboxAdapter.CreateAdapter<Ranorex.CheckBox>(false);
            CheckCheckboxAndVerifyChecked(newCheckbox);
        }

        /// <summary>
        /// Checks the checkbox item to ensure that it got unchecked.  If it did not, then it will attempt to uncheck it again.
        /// </summary>
        /// <param name="checkbox">Checkbox repo item to check and validate/retry</param>
        public static void UncheckCheckboxAndVerifyUnchecked(Ranorex.CheckBox checkbox)
        {
            int maxRetries = 3;
            if (checkbox.Checked)
            {
                checkbox.Click();
            }
            else
            {
                Report.Info("Checkbox was already unchecked");
            }
            
            while (checkbox.Checked)
            {
                checkbox.Click();
                Delay.Milliseconds(250);
                maxRetries--;
                if (maxRetries <= 0)
                {
                    Report.Error("Checkbox did not get unchecked");
                    Report.Screenshot(checkbox.Parent);
                    break;
                }
            }
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static void UncheckCheckboxAdapterAndVerifyUnchecked(RepoItemInfo checkboxAdapter)
        {
            Ranorex.CheckBox newCheckbox = checkboxAdapter.CreateAdapter<Ranorex.CheckBox>(false);
            UncheckCheckboxAndVerifyUnchecked(newCheckbox);
        }

        /// <summary>
        /// Checks the checkbox item to ensure that it got checked.  If it did not, then it will attempt to check it again.
        /// </summary>
        /// <param name="checkbox">radioButton repo item to check and validate/retry</param>
        public static void CheckRadioButtonAndVerifyChecked(Ranorex.RadioButton radioButton)
        {
            int maxRetries = 3;
            radioButton.Click();
            
            while (!radioButton.Checked)
            {
                radioButton.Click();
                Delay.Milliseconds(250);
                maxRetries--;
                if (maxRetries <= 0)
                {
                    Report.Error("Checkbox did not get checked");
                    break;
                }
            }
        }
        
        /// <summary>
        /// Will validate that the string is a proper boolean and return the value of that boolean
        /// Will return false for any non-boolean values
        /// </summary>
        /// <param name="boolName">String containing the name of the bool (for logging)</param>
        /// <param name="boolValue">String containing a boolean type (True/False)</param>
        /// <returns>the boolean from the string</returns>
        public static bool ValidateAndConvertStringToBool(String boolName, String boolValue)
        {
            bool outputBool = false;
            
            if (boolValue.Equals("0") || boolValue.Equals("F", StringComparison.OrdinalIgnoreCase))
            {
                boolValue = "False";
            }
            if (boolValue.Equals("1") || boolValue.Equals("T", StringComparison.OrdinalIgnoreCase))
            {
                boolValue = "True";
            }
            
            if (String.IsNullOrEmpty(boolValue) || !Boolean.TryParse(boolValue, out outputBool))
            {
                Report.Info(String.Format("Data sheet invalid data for {0} '{1}' setting to 'false'", boolName, boolValue));
                return false;
            }
            else
            {
                return Boolean.Parse(boolValue);
            }
        }

        
        /// <summary>
        /// This function will left click the repo item passed in and retry it if it does not disappear
        /// </summary>
        /// <param name="item">The item to click</param>
        [UserCodeMethod]
        public static void clickItemIfItExists(RepoItemInfo item)
        {
            if(item.Exists(0))
            {
                //Adapter itemAdapter = item.CreateAdapter<Unknown>(true);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(item, item);
            }
            
        }
        
        /// <summary>
        /// Change the switch position and transmit if desired
        /// </summary>
        /// <param name="switchDirection">Normal or Reverse - the desired position to change to</param>
        /// <param name="switches">Pipe delimited list of switch IDs</param>
        /// <param name="Transmit">True or False - if you want it to transmit the control after changing direction</param>
        [UserCodeMethod]
        public static void ChangeSwitchDirectionFunc(string switchDirection, string switches, string Transmit = "true")
        {
            if (switches == "")
            {
                Report.Info("No value provided for switches, ChangeSwitchDirectionFunction skipped.");
                return;
            }
            
            string[] switchList = switches.Split('|');
            
            bool transmitBool = GeneralUtilities.ValidateAndConvertStringToBool("Transmit", Transmit);
            
            foreach (string switchId in switchList)
            {
                trackLineRepo.signalId = switchId;
                
                string modelSwitchDirection = "Fail";
                string actualModelSwitchDirection = trackLineRepo.TracklineByItemID.Device.Element.GetAttributeValueText("Model");
                
                if(switchDirection.Equals("Normal", StringComparison.OrdinalIgnoreCase))
                {
                    modelSwitchDirection = ",NORM,";
                    // Set the casing to match PDS UI
                    switchDirection = "Normal";
                }
                if(switchDirection.Equals("Reverse", StringComparison.OrdinalIgnoreCase))
                {
                    modelSwitchDirection = ",REV,";
                    // Set the casing to match PDS UI
                    switchDirection = "Reverse";
                }
                
                trackLineRepo.ContextMenuItem = switchDirection;
                
                if(actualModelSwitchDirection.Contains(modelSwitchDirection))
                {
                    Report.Info(String.Format("Switch device {0} is already in expected position, '{1}'. Switch was not modified.", switchId, switchDirection));
                }
                
                else
                {
                    trackLineRepo.TracklineByItemID.Device.Focus();
                    ClickAndWaitForWithRetry(trackLineRepo.TracklineByItemID.DeviceInfo, trackLineRepo.MenuItemForm.MenuItemInfo, System.Windows.Forms.MouseButtons.Right);
                    trackLineRepo.MenuItemForm.MenuItem.Click();

                    if(trackLineRepo.TracklineWindowGeneric.SwitchAtConfirmation.ContinueInfo.Exists(0))
                    {
                        trackLineRepo.TracklineWindowGeneric.SwitchAtConfirmation.TextBox.PressKeys("abc");
                        ClickAndWaitForNotExistWithRetry(trackLineRepo.TracklineWindowGeneric.SwitchAtConfirmation.ContinueInfo, trackLineRepo.TracklineWindowGeneric.SwitchAtConfirmation.ContinueInfo);
                    }
                    
                    if (transmitBool)
                    {
                        trackLineRepo.TracklineByItemID.SwankyToolbar.TransmitControlRequestButton.Click();
                        
                        int iterations = 0;
                        int maxIterations = 10;
                        bool hasSwitchMoved = actualModelSwitchDirection.Contains(modelSwitchDirection);
                        while(!hasSwitchMoved && iterations < maxIterations)
                        {
                            actualModelSwitchDirection = trackLineRepo.TracklineByItemID.Device.Element.GetAttributeValueText("Model");
                            string authType = trackLineRepo.TracklineByItemID.Device.Element.GetAttributeValueText("AuthorityType");
                            hasSwitchMoved = actualModelSwitchDirection.Contains(modelSwitchDirection);
                            if (authType.ToUpper().Equals("TWC"))
                            {
                                Ranorex.Delay.Seconds(1);
                            }
                            else
                            {
                                Ranorex.Delay.Seconds(5);
                            }
                            iterations++;
                        }
                        
                        if (iterations == maxIterations)
                        {
                            Report.Error(String.Format("Switch did not move to {0} within '{1}' seconds for switch '{2}'. System may be slow or Transmit was not pressed",switchDirection,(maxIterations * 5).ToString(),trackLineRepo.signalId));
                        }
                    }
                }
            }
            
            
            return;
        }

        /// <summary>
        /// This assists validation steps.
        /// </summary>
        /// <param name="validateDoesExist">Whether or not the user is validating if an entity exists. If validating that it does not exist, choose 'false'</param>
        /// <param name="wasRecordFound">Whether or not the entity was found</param>
        /// <param name="foundFeedback">String representation of the record being found. This should neither indicate success or failure.</param>
        /// <param name="notFoundFeedback">String representation of the record *not* being found. This should neither indicate success or failure.</param>
        [UserCodeMethod]
        public static void ReportValidationOutcome(bool validateDoesExist, bool wasRecordFound, string foundFeedback, string notFoundFeedback)
        {
            if (validateDoesExist)
            {
                if (wasRecordFound)
                {
                    Ranorex.Report.Success("Validation", foundFeedback);
                } else {
                    Ranorex.Report.Failure("Failure", notFoundFeedback);
                }
            } else {
                if (wasRecordFound)
                {
                    Ranorex.Report.Failure("Failure", foundFeedback);
                } else {
                    Ranorex.Report.Success("Validation", notFoundFeedback);
                }
            }
        }
        
        /// <summary>
        /// Verify that the checkbox item passed in exists and is checked
        /// </summary>
        /// <param name="checkBoxInfo">checkbox repo item to look at</param>
        [UserCodeMethod]
        public static void VerifyCheckBoxIsChecked(RepoItemInfo checkBoxInfo)
        {
            if(checkBoxInfo.Exists(0))
            {
                Ranorex.CheckBox checkBoxItem = checkBoxInfo.CreateAdapter<Ranorex.CheckBox>(true);
                
                if (!checkBoxItem.Checked)
                {
                    Report.Screenshot(checkBoxItem.Element);
                    Report.Failure(String.Format("Checkbox {0} is not checked", checkBoxInfo.Name));
                }
                else
                {
                    Report.Info(String.Format("Checkbox {0} is checked", checkBoxInfo.Name));
                }
            }
            else
            {
                Report.Failure(String.Format("Checkbox {0} does not exist", checkBoxInfo.Name));
            }

        }
        
        /// <summary>
        /// Verify that the checkbox item passed in exists and is checked
        /// </summary>
        /// <param name="checkBoxInfo">checkbox repo item to look at</param>
        [UserCodeMethod]
        public static void VerifyCheckBoxIsCheckedOrNot(RepoItemInfo checkBoxInfo, bool isChecked)
        {
            if(checkBoxInfo.Exists(0))
            {
                Ranorex.CheckBox checkBoxItem = checkBoxInfo.CreateAdapter<Ranorex.CheckBox>(true);
                
                if (!checkBoxItem.Checked && isChecked)
                {
                    Report.Screenshot(checkBoxItem.Element);
                    Report.Failure(String.Format("Checkbox {0} is not checked", checkBoxInfo.Name));
                }
                else if(checkBoxItem.Checked && !isChecked)
                {
                    Report.Screenshot(checkBoxItem.Element);
                    Report.Failure(String.Format("Checkbox {0} is checked", checkBoxInfo.Name));
                }
                else
                {
                    Report.Info(String.Format("Checkbox {0} is checked?"+checkBoxItem.Checked.ToString(), checkBoxInfo.Name));
                }
            }
            else
            {
                Report.Failure(String.Format("Checkbox {0} does not exist", checkBoxInfo.Name));
            }

        }
        
        /// <summary>
        /// This function validates text message for any RepoItem passed in as an argument.
        /// </summary>
        /// <param name="repoItem">Single repository item for which a text validation is needed</param>
        /// <param name="expectedText">The Expected Text [Regex / String] which needs to be compared with the Actual Text</param>
        /// <returns></returns>
        [UserCodeMethod]
        public static bool validateAnyRepoItemText(Adapter repoItem, String expectedText)
        {
            String actualText = "";
            Regex expectedTextRegex = new Regex(expectedText);
            
            try
            {
                actualText = repoItem.Element.GetAttributeValueText("Text").Trim();
            }
            catch(Exception ex)
            {
                Validate.Fail("Invalid RepoItem. " + ex.Message);
                return false;
            }

            if(expectedTextRegex.IsMatch(actualText))
            {
                Report.Success("Validation", String.Format("Pass: Actual Text: {0} Matches Expected Text: {1}",actualText, expectedText));
                return true;
            }
            else if(actualText == null | actualText.Equals(""))
            {
                Validate.Fail("No Text Message found.");
                return false;
            }
            else
            {
                Validate.Fail(String.Format("Fail: Actual Text {0} does not match Expected Text {1}", actualText, expectedText));
                return false;
            }
        }
        
        /// <summary>
        /// This function validates Cursor color, which passed in as an argument.
        /// </summary>
        /// <param name="CursorColor"> Color for which validation is needed</param>
        /// <returns></returns>
        [UserCodeMethod]
        public static void NS_CursorColorValidation(string CursorColor)
        {
            HashSet<Color> colorsFound = new HashSet<Color>();
            
            //Must use a named color from PDSColors
            Color checkColor = PDS_CORE.Code_Utils.PDSColors.GetColorFromString(CursorColor);
            var MouseImage = Ranorex.Mouse.GetCursorImage();
            colorsFound = GetColorsFromBitmap(MouseImage, 1 , 1);
            
            int colorsInMouse = colorsFound.Count;
            
            Ranorex.Report.Info("Number of Colors found in Mouse Image " +colorsInMouse.ToString());
            
            foreach (Color color in colorsFound)
            {
                Ranorex.Report.Info("Color in Mouse Image " + color.ToString());
            }
            
            if (colorsFound.Contains(checkColor))
            {
                Ranorex.Report.Success("Color: "+CursorColor+", found in Mouse Cursor");
                //return true;
            }
            else
            {
                Ranorex.Report.Failure("Color: "+CursorColor+", not found in Mouse Cursor");
            }
            
        }
        
        /// <summary>
        /// This function adds offset to a Timestamp and returns time in format MM-dd-yyyy HH:mm with Zone.
        /// </summary>
        /// <param name="offsetInMinutes"> offset in minutes</param>
        /// <param name="timeStamp"> Gets it from createTimestampwithoffset method</param>
        /// <returns></returns>
        [UserCodeMethod]
        public static string AddOffsetInMinutesToATimestamp(String offsetInMinutes ,String timeStamp)
        {
            String timeZone   = timeStamp.Substring(16,4).ToString();
            timeStamp = timeStamp.Remove(16,4);
            String offsetTime = System.DateTime.Parse(timeStamp).AddMinutes(Convert.ToInt32(offsetInMinutes)).ToString("MM-dd-yyyy HH:mm") + timeZone;
            return offsetTime;
        }
        
        /// <summary>
        /// This function returns a String with the text of all pages of a given pdf file.
        /// </summary>
        /// <param name="path">Input: String: Windows Path example: C:/pdf_path/ </param>
        /// <param name="filename">Input: String: Any pdf filename example: Some PDF.pdf</param>
        /// <returns>Output: returned String with all text extracted from all pages of the provided pdf</returns>
        [UserCodeMethod]
        public static string returnStringForPDF(string path, string filename)
        {
            string filepath = (path + "\\" + filename).ToString().Replace("/", "\\").Trim();
            string returnStringAllPages = string.Empty;
            
            PdfReader reader = new PdfReader(filepath);

            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                returnStringAllPages += PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
            }
            
            reader.Close();

            return returnStringAllPages;
        }
        
        /// <summary>
        /// /// This function fills a cell with input text and validates if the expected text of a cell contains input text,
        /// if it isn't it erases the entire text of that cell and fills it again and validates
        /// </summary>
        /// <param name="cell">Repo Adapter of the cell to use</param>
        /// <param name="data">String you want in the cell</param>
        /// <param name="validate">True to validate and False to not validate</param>
        [UserCodeMethod]
        public static void clickAndFillCellWithValidate(Adapter cell, String data, bool validate = true)
        {
            for (int x = 0; x < 3; x++)
            {
                
                cell.Click();
                ClearText(cell);
                Delay.Milliseconds(100);
                cell.PressKeys(data);
                Delay.Milliseconds(100);
                cell.PressKeys("{Tab}");
                Delay.Milliseconds(250);
                if (validate)
                {
                    if (cell.GetAttributeValue<String>("Text").Contains(data))
                    {
                        break;
                    }
                    else
                    {
                        Report.Info("Did not find matching text : data:" + data + " found:" + cell.GetAttributeValue<String>("Text"));
                        ClearText(cell);
                        continue;
                    }
                }
                else
                {
                    // If there is no validation requested, skip the remaining cycles
                    x = 999;
                }
            }
        }
        
        /// <summary>
        /// /// This function fills a calender Text box cell with input text and validates if the expected text of a cell contains input text,
        /// if it isn't it erases the entire text of that cell and fills it again and validates
        /// </summary>
        /// <param name="cell">Repo Adapter of the cell to use</param>
        /// <param name="data">String you want in the cell</param>
        /// <param name="validate">True to validate and False to not validate</param>
        [UserCodeMethod]
        public static void clickAndFillCellWithValidateForCalenderCells(Adapter cell, Adapter calendarTextBox, String data, bool validate = true)
        {
            for (int x = 0; x < 3; x++)
            {
                cell.Click();
                ClearText(cell);
                Delay.Milliseconds(200);
                cell.PressKeys(data);
                Delay.Milliseconds(100);
                if (validate)
                {
                    if (calendarTextBox.GetAttributeValue<String>("Text").Equals(data,StringComparison.OrdinalIgnoreCase))
                    {
                        cell.PressKeys("{Tab}");
                        break;
                    }
                    else
                    {
                        Report.Info("Did not find matching text : data:" + data + " found:" + cell.GetAttributeValue<String>("Text"));
                        ClearText(cell);
                        cell.PressKeys("{Tab}");
                        continue;
                    }
                }
                else
                {
                    // If there is no validation requested, skip the remaining cycles
                    cell.PressKeys("{Tab}");
                    x = 999;
                    
                }
            }
        }
        
        // <summary>
        /// This function clears the text of a cell/Text box
        /// </summary>
        /// <param name="cell">Repo Adapter of the cell to use</param>
        [UserCodeMethod]
        public static void ClearText(Adapter cell)
        {
            Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
            cell.PressKeys("{Delete}");
        }
        
        /// <summary>
        /// This function converts any Input time to UTC(Coordinated Universal Time)
        /// And returns true/false by validating time range (adding & substracting) to the Input time
        /// <param name="StaticTime">Input: System.DateTime:Constant Time example: StaticTime </param>
        /// <param name="DynamicTime">Input: System.DateTime:Changing Time example: DynamicTime </param>
        /// <param name="offsetTime">Input:Int:add or Substract a minute to Dynamic Time example: FutureTime, PastTime </param>
        /// <returns>Output: return bool true/false based on the validation</returns>
        /// </summary>
        [UserCodeMethod]
        public static bool ValidateTimeWithRange(System.DateTime StaticTime, System.DateTime DynamicTime, int offsetTime = 1)
        {
            bool validateTime = false;
            // convert Statictime to UTC
            System.DateTime UniversalTime1 = TimeZoneInfo.ConvertTimeToUtc(StaticTime);
            // convert Dynamic time(PDSTime) to UTC
            System.DateTime UniversalTime2 = TimeZoneInfo.ConvertTimeToUtc(DynamicTime);
            
            // add a minute & remove a minute to dynamic time
            if (!(offsetTime == 0))
            {
                System.DateTime FutureTime = UniversalTime2.AddMinutes(offsetTime);
                System.DateTime PastTime = (UniversalTime2.AddMinutes(offsetTime*-1));
                
                if (PastTime <= UniversalTime1  && UniversalTime1 <= FutureTime)
                {
                    validateTime = true;
                }
            }
            return validateTime;
        }
        /// <summary>
        /// This function validates the feedback text message for the RepoItem passed in as an argument.
        /// </summary>
        /// <param name="repoItem">Single Feedback repository item for which a Feedback validation is needed</param>
        /// <param name="expectedFeedback">The Expected Feedback which needs to be compared with the Actual Feedback</param>
        [UserCodeMethod]
        public static void validateAnyFeedbackUsingContainsMethod(Adapter repoItem, String expectedFeedback)
        {
            String actualFeedback ="";
            try
            {
                actualFeedback = repoItem.Element.GetAttributeValueText("Caption").Trim();
            }
            catch(Exception ex)
            {
                Validate.Fail("Invalid Feedback RepoItem. " + ex.Message);
            }
            if(actualFeedback.Contains(expectedFeedback))
            {
                Report.Success("Validation", String.Format("Displayed Feedback Message:{0}",actualFeedback));
            }
            else if(actualFeedback == null | actualFeedback.Equals(""))
            {
                Validate.Fail("No Feedback Message displayed.");
            }
            else
            {
                Report.Failure("Validation", String.Format("Displayed Feedback Message: {0}",actualFeedback));
            }
        }
        
        /// <summary>
        /// Check a dropdown list to see if objects exist or do not exist in it
        /// </summary>
        /// <param name="listAdapter">List adapter to look in</param>
        /// <param name="shouldExist">Pipe list of objects that should exist within the list</param>
        /// <param name="shouldNotExist">Pipe list of objects that should not exist withint the list</param>
        [UserCodeMethod]
        public static void ValidateListItemNames(Adapter listAdapter, String shouldExist, String shouldNotExist)
        {
            
            String[] existList = shouldExist.Split('|');
            String[] notExistList = shouldNotExist.Split('|');
            
            Ranorex.List listObj = listAdapter.As<List>();
            
            foreach (String findMe in existList)
            {
                bool found = false;

                foreach (ListItem li in listObj.Items)
                {
                    if (li.Text.Equals(findMe, StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;
                        break;
                    }
                }
                
                if (found)
                {
                    Report.Info("Verified " + findMe + " is in the list");
                }
                else
                {
                    Report.Failure("Did not find " + findMe + " in the list as expected");
                }
            }
            
            foreach (String dontFindMe in notExistList)
            {
                bool found = false;

                foreach (ListItem li in listObj.Items)
                {
                    if (li.Text.Equals(dontFindMe, StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;
                        break;
                    }
                }
                
                if (found)
                {
                    Report.Failure("Found " + dontFindMe + " in the list where it is not expected to be");
                }
                else
                {
                    Report.Info("Verified " + dontFindMe + " does not exist in the list");
                }
            }
            
        }

        /// <summary>
        /// Checks the checkbox item to ensure that it got unchecked.  If it did not, then it will attempt to uncheck it again.
        /// </summary>
        /// <param name="checkbox">Checkbox repo item to uncheck and validate/retry</param>
        public static void UnCheckCheckboxAndVerify(Ranorex.CheckBox checkbox)
        {
            int maxRetries = 3;
            if (checkbox.Checked)
            {
                Report.Info("Checkbox was checked, unchecking");
                checkbox.Click();
            }
            else
            {
                Report.Info("Checkbox was already unchecked");
            }
            
            CheckWaitState(5);
            Delay.Milliseconds(500);
            
            while (checkbox.Checked)
            {
                checkbox.Click();
                CheckWaitState(5);
                Delay.Milliseconds(500);
                maxRetries--;
                if (maxRetries <= 0)
                {
                    Report.Error("Checkbox did not get unchecked");
                    Report.Screenshot(checkbox.Parent);
                    break;
                }
            }
        }
        
        /// <summary>
        /// This function used to  uncheck the checkbox.
        /// </summary>
        /// <param name="checkboxAdapter">checkboxAdapter used for checkbox</param>
        [UserCodeMethod]
        public static void UnCheckCheckboxAdapterAndVerify(RepoItemInfo checkboxAdapter)
        {
            Ranorex.CheckBox newCheckbox = checkboxAdapter.CreateAdapter<Ranorex.CheckBox>(false);
            UnCheckCheckboxAndVerify(newCheckbox);
        }
        
        /// <summary>
        /// Compares feedback with regex of expectedFeedback
        /// </summary>
        /// <param name="feedback">Input:feedback</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        public static bool CheckFeedbackExists(Adapter feedback, string acceptableFeedback)
        {
            Regex acceptableFeedbackRegex = new Regex(acceptableFeedback);
            string feedbackText = feedback.GetAttributeValue<string>("Text");
            if (feedbackText == "" || feedbackText == " ")
            {
                //No feedback received, return
                return true;
            }
            if (acceptableFeedback != "" && acceptableFeedbackRegex.IsMatch(feedbackText))
            {
                return true;
            }
            return false;
        }
    	
    	/// <summary>
    	/// Converts a ulong to a byte array
    	/// <param name="uLongValue">Input:u long to convert</param>
    	/// <param name="size">Input:size of the byte array</param>
    	/// </summary>
    	public static byte[] ULongToByteArray(ulong uLongValue, int size)
        {
            var result = new byte[size];
    
            for (var i = 0; i < size; i++)
            {
                var bitOffset = (size - (i + 1)) * 8;
                result[i] = (byte)((uLongValue & ((ulong)0xFF << bitOffset)) >> bitOffset);
            }
    
            return result;
        }
        
        /// <summary>
        /// This function helps to check if the field is enabled or disabled
        /// </summary>
        /// <param name="repoItemInfo">object that needs to be verified as enabled or disabled</param>
        /// <param name="chkfield">boolean vaule (true - emable or false - disabled)</param>
        [UserCodeMethod]
        public static void CheckFieldEnableDisable(Ranorex.Core.Repository.RepoItemInfo repoItemInfo, bool chkfield){
            
            Ranorex.Adapter repoItem = repoItemInfo.CreateAdapter<Unknown>(true);
            
            string fieldName = repoItem.GetAttributeValue<string>("Text");
            
            if (repoItemInfo.Exists(0)) {
                
                if ((repoItem.Enabled ==true) && (chkfield == true)) {
                    Ranorex.Report.Success("The field "+fieldName+ " is Enabled");
                }
                else if((repoItem.Enabled ==true) && (chkfield == false)){
                    Ranorex.Report.Failure("The field "+fieldName+ " is not enabled/disabled as expected");
                }
                else if ((repoItem.Enabled ==false) && (chkfield == true)) {
                    Ranorex.Report.Failure("The field "+fieldName+ " is not enabled/disabled as expected");
                }
                else if ((repoItem.Enabled ==false) && (chkfield == false)) {
                    Ranorex.Report.Success("The field "+fieldName+ " is Disable");
                }
                
                else{
                    Ranorex.Report.Failure("RepoItem " +fieldName+ " does not exists");
                }
                
            }
        }

        
        /// <summary>
        /// This function helps to check if the menu item is enabled or disabled
        /// </summary>
        /// <param name="menuButtonInfo">Menu button the opens up the context menu</param>
        /// <param name="contextMenuInfo">Context menu that hold the object that needs to be verified as enabled or disabled</param>
        /// <param name="menuItemInfo">object that needs to be verified as enabled or disabled</param>
        /// <param name="isEnabled">boolean vaule (true - emable or false - disabled)</param>
        public static void NS_CheckMenuEnabled_MainMenu(Ranorex.Core.Repository.RepoItemInfo menuButtonInfo,
                                                Ranorex.Core.Repository.RepoItemInfo contextMenuInfo,
                                                Ranorex.Core.Repository.RepoItemInfo menuItemInfo,
                                                bool isEnabled)
        {
        	GeneralUtilities.ClickAndWaitForWithRetry(menuButtonInfo, contextMenuInfo);
        	GeneralUtilities.CheckFieldEnableDisable(menuItemInfo, isEnabled);
        }
		
		// <summary>
        /// This function perform shortcut key for Assign Function Keys in PDS
        /// </summary>
        /// <param name="key1">Input: keys for keyboard key name to perform shortcut</param>
        /// <param name="shiftKey">Input: shiftKey</param>
        [UserCodeMethod]
        public static void ShortcutKeypress(string keys, bool shiftKey)
        {   
        	if(!string.IsNullOrEmpty(keys))
        	{
	        	if(shiftKey)
	        	{
	        		Ranorex.Keyboard.Press("{Shift down}{"+keys+"}{Shift up}");        		
	        	}
	        	else
	        	{
	        		Ranorex.Keyboard.Press("{"+keys+"}");
	        	}     	
	        	//Keyboard.Press(System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F12, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        	}
        	else
        	{
        		Report.Error("Provide Keyboard Key to perform.");
        	}
        }
         // <summary>
        /// This method will validate any form Exist or Not by form title in PDS
        /// </summary>
        /// <param name="formTitle">Input: form title for find expected opened form</param>
        /// <param name="closeForm">Input: True or False to close expected form</param>
        /// <param name="validateFormExists">input:True or False to validate</param>
        [UserCodeMethod]
		public static void ValidateFormExists_FormTitle(string formTitle, bool closeForm, bool validateFormExists = true) 
		{
			Report.Info("TestStep", "Searching for form with form title: " + formTitle);

			RxPath form = string.Format(format: "form[@title~'{0}']", arg0: formTitle);
			Ranorex.Button closeButton = "/form[@title~'"+formTitle+"']/titlebar/button[@accessiblename~'Close']";	
			Ranorex.Core.Element outForm;
			
			bool exists = Host.Local.TryFindSingle(form, 3000, out outForm);
			int retries = 0;
			while ((exists != validateFormExists) && retries < 3)
			{
				exists = Host.Local.TryFindSingle(form, 3000, out outForm);
				retries++;
			}

			string feedbackMessage = string.Format(
				"Form '{0}' found actual status: '{1}' and expected found status: '{2}'",
				formTitle, exists.ToString(), validateFormExists.ToString()
			);

			if (exists == validateFormExists) 
			{
				Report.Success(feedbackMessage);
			} 
			else 
			{
				Report.Screenshot();
				Report.Failure(feedbackMessage);
			}
			if(closeForm)
			{
				Report.Info("Closing expected form.");
				closeButton.Click();
			}
		}
		
		// <summary>
		/// This method will copy content form text box and paste in same text field.
		/// </summary>
		/// <param name="repoItem">Input:repoItem </param>
		/// <param name="textContent">Input: textContent</param>
		[UserCodeMethod]
		public static void copyPasteText(Adapter repoItem, string textContent)
		{
			if(!string.IsNullOrEmpty(textContent))
			{
				repoItem.Element.SetAttributeValue("Text", textContent);
				repoItem.Click();
				repoItem.PressKeys("{ControlKey down}{AKey}{ControlKey up}");
				repoItem.PressKeys("{ControlKey down}{XKey}{ControlKey up}");
				repoItem.Click();
				repoItem.PressKeys("{ControlKey down}{VKey}{ControlKey up}");
			}
			else
			{
				Report.Failure("Provide text/data for copy and paste.");
			}
		}
        
    }
}
