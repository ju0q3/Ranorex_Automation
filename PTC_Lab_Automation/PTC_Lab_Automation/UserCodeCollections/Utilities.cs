/*
 * Created by Ranorex
 * User: 212719544
 * Date: 2/13/2020
 * Time: 8:48 AM
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

namespace PTC_Lab_Automation.UserCodeCollections
{
    /// <summary>
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class Utilities
    {
        [UserCodeMethod]
        public static string SubstituteStringValues(string originalText, string textReplace1, string textReplacement1Type, string textReplace2, string textReplacement2Type, string textReplace3, string textReplacement3Type, string textReplace4, string textReplacement4Type)
        {
            string replacedText = originalText;
            
            if (originalText.Contains("$TextReplace1"))
            {
                if (!textReplacement1Type.IsEmpty())
                {
                    textReplace1 = StringConversion(textReplace1, textReplacement1Type);
                }
                replacedText = replacedText.Replace("$TextReplace1", textReplace1);
            } else {
                return replacedText;
            }
            
            if (originalText.Contains("$TextReplace2"))
            {
                if (!textReplacement2Type.IsEmpty())
                {
                    textReplace2 = StringConversion(textReplace2, textReplacement2Type);
                }
                replacedText = replacedText.Replace("$TextReplace2", textReplace2);
            } else {
                return replacedText;
            }
            
            if (originalText.Contains("$TextReplace3"))
            {
                if (!textReplacement3Type.IsEmpty())
                {
                    textReplace3 = StringConversion(textReplace3, textReplacement3Type);
                }
                replacedText = replacedText.Replace("$TextReplace3", textReplace3);
            } else {
                return replacedText;
            }
            
            if (originalText.Contains("$TextReplace4"))
            {
                if (!textReplacement4Type.IsEmpty())
                {
                    textReplace4 = StringConversion(textReplace4, textReplacement4Type);
                }
                replacedText = replacedText.Replace("$TextReplace4", textReplace4);
            }
            
            return replacedText;
        }
        
        public static string StringConversion(string textReplace, string textReplacementType)
        {
            if (textReplacementType == "PTCEngineNumber")
            {
                //Assume textReplace is the TrainSeed
                PDS_CORE.Code_Utils.NS_TrainObject trainRecord = PDS_CORE.Code_Utils.NS_TrainID.getTrainObject(textReplace);
                if (trainRecord == null)
                {
                    Ranorex.Report.Error("Train Record under trainSeed {" + textReplace + "} does not exist");
                    textReplace = "";
                } else {
                    PDS_CORE.Code_Utils.NS_EngineConsistObject engineRecord = trainRecord.GetFirstEngineObject();
                    if (engineRecord == null)
                    {
                        Ranorex.Report.Error("Engine Record under trainSeed {" + textReplace + "} does not exist");
                        textReplace = "";
                    }
                    textReplace = engineRecord.EngineNumber;
                }
                
            } else if (textReplacementType == "PTCEngineId")
            {
                //Assume textReplace is the TrainSeed
                PDS_CORE.Code_Utils.NS_TrainObject trainRecord = PDS_CORE.Code_Utils.NS_TrainID.getTrainObject(textReplace);
                if (trainRecord == null)
                {
                    Ranorex.Report.Error("Train Record under trainSeed {" + textReplace + "} does not exist");
                    textReplace = "";
                } else {
                    PDS_CORE.Code_Utils.NS_EngineConsistObject engineRecord = trainRecord.GetFirstEngineObject();
                    if (engineRecord == null)
                    {
                        Ranorex.Report.Error("Engine Record under trainSeed {" + textReplace + "} does not exist");
                        textReplace = "";
                    }
                    textReplace = engineRecord.EngineInitial + " " + engineRecord.EngineNumber;
                }
                
            } else if (textReplacementType == "PTCTrainSymbol") {
                //Assume textReplace is the TrainSeed
                PDS_CORE.Code_Utils.NS_TrainObject trainRecord = PDS_CORE.Code_Utils.NS_TrainID.getTrainObject(textReplace);
                if (trainRecord == null)
                {
                    Ranorex.Report.Error("Train Record under trainSeed {" + textReplace + "} does not exist");
                    textReplace = "";
                }
                
                textReplace = trainRecord.TrainSymbol;
            } else if (textReplacementType == "PTCTrainId") {
                //Assume textReplace is the TrainSeed
                PDS_CORE.Code_Utils.NS_TrainObject trainRecord = PDS_CORE.Code_Utils.NS_TrainID.getTrainObject(textReplace);
                if (trainRecord == null)
                {
                    Ranorex.Report.Error("Train Record under trainSeed {" + textReplace + "} does not exist");
                    textReplace = "";
                }
                
                textReplace = trainRecord.TrainId;
            }
            
            return textReplace;
        }
    }
}
