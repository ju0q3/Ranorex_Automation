/*
 * Created by Ranorex
 * User: 502732101
 * Date: 12/16/2017
 * Time: 1:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace PDS_CORE.Code_Utils
{
    /// <summary>
    /// PDS Design Colors
    /// </summary>
    public static class PDSColors
    {
        // Individual Colors
        public static Color black = Color.FromArgb(0,0,0);
        public static Color blue = Color.FromArgb(0,0,255);
        public static Color brown = Color.FromArgb(204,167,98);
        public static Color cyan = Color.FromArgb(0,255,255);
        public static Color cyan2 = Color.FromArgb(0,233,233);
        public static Color darkGrey = Color.FromArgb(30,30,30);
        public static Color orange = Color.FromArgb(255,200,0);
        public static Color green = Color.FromArgb(0,255,0);
        public static Color greenMinus5 = Color.FromArgb(0,250,0);
		public static Color cnPTCGreen = Color.FromArgb(0,204,0);        
        public static Color darkGreen = Color.FromArgb(0,140,0);
        public static Color grey = Color.FromArgb(30,30,30);
        public static Color sidingGrey = Color.FromArgb(119,136,153);
        public static Color lightBlue = Color.FromArgb(48,213,200);
        public static Color lightGreen = Color.FromArgb(0,127,0);
        public static Color magenta = Color.FromArgb(255,0,255);
        public static Color magenta2 = Color.FromArgb(164,13,100);
        public static Color pink = Color.FromArgb(255,175,175);
        public static Color purple = Color.FromArgb(255,0,255);
        public static Color darkpurple = Color.FromArgb(170,131,201);
        public static Color red = Color.FromArgb(255,0,0);
        public static Color rustOrange = Color.FromArgb(61,36,2);
        public static Color silver = Color.FromArgb(192,192,192);
        public static Color standardGrey = Color.FromArgb(197,197,197);
        public static Color white = Color.FromArgb(255,255,255);
        public static Color yellow = Color.FromArgb(255,255,0);
        public static Color cursorColor = Color.FromArgb(170,0,240);
        public static Color textBoxWarning = Color.FromArgb(242,110,110);
        public static Color lightYellow = Color.FromArgb(191,198,106);
        public static Color lightOrange =Color.FromArgb(255,102,0);
        
        
        //Train Sheet Colors
        public static Color identifyingEngine = Color.FromArgb(170,131,201);
        public static Color tgboGreen = Color.FromArgb(34,139,34);
        public static Color tgboRed = Color.FromArgb(185,0,0);
        public static Color tgboNone = Color.FromArgb(164,13,100);
        public static Color TrainClearanceGreen = Color.FromArgb(113,144,108);
        public static Color ExcessDimension = Color.FromArgb(141,122,64);
        public static Color HazmatTrain = Color.FromArgb(196,41,18);
        public static Color TIH = Color.FromArgb(131,9,3);
        public static Color TrainManualMode = Color.FromArgb(44,195,183);
        public static Color TrainConsistSummary = Color.FromArgb(255,192,157);
        
        
        // Tag Colors
        public static Color bulletinFormY = Color.FromArgb(255,175,175);
        public static Color bulletinSpeedRestriction = Color.FromArgb(255,255,0);
        public static Color tagBlock = Color.FromArgb(0,0,255);
        public static Color tagReminder = Color.FromArgb(255,255,0);

        // Component Colors        
        public static Color deviceOff = Color.FromArgb(192,192,192);
        public static Color noTC = Color.FromArgb(164,13,100);
        public static Color signalClear = Color.FromArgb(0,255,0);
        public static Color signalStop = Color.FromArgb(255,0,0);
        public static Color trackAutomatic = Color.FromArgb(255,255,255);
        public static Color trackManual = Color.FromArgb(204,167,98);
        public static Color trackOccupied = Color.FromArgb(255,0,0);
        public static Color trainManual = Color.FromArgb(48,213,200);
        public static Color switchLock = Color.FromArgb(61,36,2);
        public static Color unplanned = Color.FromArgb(255,0,255);

        // Authority Colors
        public static Color authorityDarkGrey = Color.FromArgb(30,30,30);
        public static Color authorityLightGrey = Color.FromArgb(197,197,197);
        public static Color authorityOccupied = Color.FromArgb(255,0,255);
        public static Color authorityOT = Color.FromArgb(0,255,255);
        public static Color authorityRW = Color.FromArgb(0,255,255);
        public static Color authorityTE = Color.FromArgb(0,255,0);
        public static Color inactiveSwitch = Color.FromArgb(64,64,64);
        public static Color emtPurple = Color.FromArgb(128,0,128);

        // PTC Colors
        public static Color ptcActive = Color.FromArgb(0,255,0);
        public static Color ptcBannerLightBlue = Color.FromArgb(0,255,255);
        public static Color ptcBlueFence = Color.FromArgb(0,255,255);
        public static Color ptcGreyTrack = Color.FromArgb(127,127,127); 
        public static Color ptcInProgress = Color.FromArgb(255,255,0);
        public static Color ptcLightBlue = Color.FromArgb(63,175,175);
        public static Color ptcLightBlueNoRed1 = Color.FromArgb(0,63,63);
        public static Color ptcLightBlueNoRed2 = Color.FromArgb(0,233,233);
        public static Color ptcMapGrey = Color.FromArgb(156,156,156);
        public static Color ptcPending = Color.FromArgb(255,255,0);
        public static Color ptcRed = Color.FromArgb(255,0,0);
        public static Color ptcRedFence = Color.FromArgb(233,0,0);
        public static Color ptcReject = Color.FromArgb(255,200,0);
        public static Color ptcReviewActive = Color.FromArgb(0,127,0);
        public static Color ptcTrackGrey = Color.FromArgb(126,126,126);
        public static Color ptcXing = Color.FromArgb(0,159,159);
        public static Color ptcYellowFence = Color.FromArgb(63,63,0);
        public static Color ptcLightRed = Color.FromArgb(255,102,0);

        // Rum Colors
        public static Color rumPendingButtonPanel = Color.FromArgb(255,255,0);
        public static Color rumPendingToolbar = Color.FromArgb(252,252,6);
        public static Color rumRejectButtonPanel = Color.FromArgb(255,200,0);
        public static Color rumRejectToolbar = Color.FromArgb(252,199,6);
        
        // EMT Colors
        public static Color emtTrackline = Color.FromArgb(128,0,128);
        
		// Task Colors
        public static Color taskListGreen = Color.FromArgb(0,128,0);
        
        public static Color nvcCheckbox = Color.FromArgb(255,253,249);
 
        public static Color GetColorFromString(String colorName)
        {
            // Default to color that will always fail 
            Color returnColor = Color.FromArgb(211, 146, 47);
            
            switch (colorName.Trim().ToLower())
            {
                case "black":
                    returnColor = black;
                    break;
                case "blue":
                case "tagblock":
                			/* Tag Types treated as colors */
                case "track block":  								
                case "switch block":  
				case "roadway worker protection":
				case "blue signal / occupied camp car protection": 
				case "signal block":                    
                    returnColor = blue;
                    break;
                case "brown":
                case "trackmanual":
                    returnColor = brown;
                    break;
                case "cyan":
                case "authorityot":
               	case "authorityrw":
                    returnColor = authorityRW;
                    break;
               	case "authorityte":
                    returnColor = authorityTE;
                    break;
                case "ptcbannerlightblue":
                case "ptcbluefence":
                    returnColor = cyan;
                    break;
                case "cyan2":
                case "ptclightbluenored2":
                    returnColor = cyan2;
                    break;
                case "darkgray":
                case "darkgrey":
                    returnColor = darkGrey;
                    break;
               case "inactiveswitch":
                    returnColor = inactiveSwitch;
                    break;
                case "green":
                case "signalclear":
                case "ptcactive":
                    returnColor = green;
                    break;
                case "greenminus5":
                    returnColor = greenMinus5;
                    break;
                case "darkgreen":
                    returnColor = darkGreen;
                    break;
                case "gray":
                case "grey":         		
                case "authoritydarkgray":
                case "authoritydarkgrey":
                    returnColor = grey;
                    break;
                case "sidinggrey":
               		returnColor = sidingGrey;
					break;      
                case "lightblue":
                case "trainmanual":
                    returnColor = lightBlue;
                    break;
                case "lightgreen":
                case "ptcreviewactive":
                    returnColor = lightGreen;
                    break;
                case "magenta":
                case "unplanned":
                case "authorityoccupied":
                    returnColor = magenta;
                    break;
                case "magenta2":
                case "notc":
                    returnColor = magenta2;
                    break;
                case "pink":
                case "bulletinformy":
                    returnColor = pink;
                    break;
                case "purple":
                    returnColor = purple;
                    break;
                case "emtpurple":
                    returnColor = emtPurple;
                    break;
                case "red":
                case "signalstop":
                case "trackoccupied":
                case "ptcred":
                case "warning":
                    returnColor = red;
                    break;
                case "trainclearancegreen":
                    returnColor = TrainClearanceGreen;
                    break;
                case "hazmattrain":
                    returnColor = HazmatTrain;
                    break;
                case "tih":
                    returnColor = TIH;
                    break;
                case "excessdimension":
                    returnColor=ExcessDimension;
                    break;
                case "rustorange":
                case "switchlock":
                    returnColor = rustOrange;
                    break;
                case "silver":
                case "deviceoff":
                    returnColor = silver;
                    break;
                case "standardgray":
                case "standardgrey":
                case "authoritylightgray":
                case "authoritylightgrey":
                    returnColor = standardGrey;
                    break;
                case "white":
                case "trackautomatic":
                    returnColor = white;
                    break;                    
                case "yellow":
                case "bulletinspeedrestriction":
                case "ptcinprogress":
                case "ptcpending":
                case "rumpendingbuttonpanel":
                case "tagreminder":
               				/* Tag Types treated as colors */
                case "reminder track tag":
                case "reminder switch tag":
                case "ptc_depart_yellow":
               	case "watch":
                    returnColor = yellow;
                    break;
                case "orange":
                case "rumrejectbuttonpanel":
                case "ptcreject":
                    returnColor = orange;
                    break;
                case "ptclightblue":
                    returnColor = ptcLightBlue;
                    break;
                case "ptclightbluenored1":
                    returnColor = ptcLightBlueNoRed1;
                    break;
                case "ptcyellowfence":
                    returnColor = ptcYellowFence;
                    break;
                case "ptcgraytrack":
                case "ptcgreytrack":
                    returnColor = ptcGreyTrack;
                    break;
                case "ptcmapgray":
                case "ptcmapgrey":
                    returnColor = ptcMapGrey;
                    break;
                case "ptcredfence":
                    returnColor = ptcRedFence;
                    break;
                case "ptctrackgray":
                case "ptctrackgrey":
                    returnColor = ptcTrackGrey;
                    break;
                case "ptcxing":
                    returnColor = ptcXing;
                    break;
                case "rumpendingtoolbar":
                    returnColor = rumPendingToolbar;
                    break;
                case "rumrejecttoolbar":
                    returnColor = rumRejectToolbar;
                    break;   
                case "darkpurple":
                case "identifyingengine":
                    returnColor = identifyingEngine;
                    break;
                case "emttrackline":
                    returnColor = emtTrackline;
                    break;
                case "tgbogreen":
                    returnColor = tgboGreen;
                    break;
                case "tgbored":
                    returnColor = tgboRed;
                    break;
                case "tgbonone":
                    returnColor = tgboNone;
                    break;
                case "ptclightred" :
                    returnColor = ptcLightRed;
                    break; 
                case "cursorpurple" :
                    returnColor = cursorColor;
                    break;       
                case "trainmanualmode" :
                    returnColor = TrainManualMode;
                    break;
                case "trainconsistsummary" :
                    returnColor = TrainConsistSummary;
                    break;
                case "cnptcgreen" :
                    returnColor = cnPTCGreen;
                    break;
                case "textboxwarning" :
                    returnColor = textBoxWarning;
                    break;
                case "taskgreen":
                    returnColor = taskListGreen;
                    break;
                case "lightyellow" :
                    returnColor = lightYellow;
                    break;
                case "lightorange":
                    returnColor = lightOrange;
                    break;
                case "nvccheckbox":
                    returnColor = nvcCheckbox;
                    break;
            }
            
            return returnColor;
            
        }
        
    }
}
