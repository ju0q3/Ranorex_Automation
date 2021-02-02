/*
 * Created by Ranorex
 * User: r07000021
 * Date: 12/19/2018
 * Time: 9:01 PM
 *
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using Oracle.Code_Utils;
using PDS_CORE.Code_Utils;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace PDS_NS.UserCodeCollections
{
    public class AuthorityObject
    {
        public string trackAuthorityType { get; set; }
        public string authorityNumber { get; set; }
        public string trainSeed { get; set; }
        public string engineSeed { get; set; }
        public string copiedBy { get; set; }
        public string rWOrOtWorker { get; set; }
        public string at { get; set; }
        public string box1TrackAuthorityNumber { get; set; }
        public string box2ProceedFrom { get; set; }
        public bool box2Fsw { get; set; }
        public string box2To1 { get; set; }
        public string box2Track1 { get; set; }
        public string box2To1HoldClearMain { get; set; }
        public string box2To2 { get; set; }
        public string box2Track2 { get; set; }
        public string box2To2HoldClearMain { get; set; }
        public string box2To3 { get; set; }
        public string box2Track3 { get; set; }
        public string box2To3HoldClearMain { get; set; }
        public string box3WorkBetweenFrom { get; set; }
        public bool box3FromCP { get; set; }
        public string box3To { get; set; }
        public bool box3ToCP { get; set; }
        public string box3Track1 { get; set; }
        public string box3Track2 { get; set; }
        public string box3Track3 { get; set; }
        public string box3Track4 { get; set; }
        public string box3Track5 { get; set; }
        public string box4ProceedFrom { get; set; }
        public bool box4Fsw { get; set; }
        public string box4To1 { get; set; }
        public string box4Track1 { get; set; }
        public string box4To1HoldClearMain { get; set; }
        public string box4To2 { get; set; }
        public string box4Track2 { get; set; }
        public string box4To2HoldClearMain { get; set; }
        public string box4To3 { get; set; }
        public string box4Track3 { get; set; }
        public string box4To3HoldClearMain { get; set; }
        public string box5UntilInMinutes { get; set; }
        public string box6EngineSeed1 { get; set; }
        public string box6EngineSeed2 { get; set; }
        public string box6EngineSeed3 { get; set; }
        public string box6Engine1Direction { get; set; }
        public string box6Engine2Direction { get; set; }
        public string box6Engine3Direction { get; set; }
        public string box6At { get; set; }
        public bool box7 { get; set; }
        public string box8EngineSeed1 { get; set; }
        public string box8EngineSeed2 { get; set; }
        public string box8EngineSeed3 { get; set; }
        public string box8Engine1Direction { get; set; }
        public string box8Engine2Direction { get; set; }
        public string box8Engine3Direction { get; set; }
        public bool box9 { get; set; }
        public string box10Between1 { get; set; }
        public string box10Between2 { get; set; }
        public string box11StopShort { get; set; }
        public string box11Track { get; set; }
        public string box12RWIC1 { get; set; }
        public string box12Between1 { get; set; }
        public string box12And1 { get; set; }
        public string box12Track1 { get; set; }
        public string box12RWIC2 { get; set; }
        public string box12Between2 { get; set; }
        public string box12And2 { get; set; }
        public string box12Track2 { get; set; }
        public string box12RWIC3 { get; set; }
        public string box12Between3 { get; set; }
        public string box12And3 { get; set; }
        public string box12Track3 { get; set; }
        public bool box13SubdivideLimits { get; set; }
        public string box13AutomaticInstructions { get; set; }
        public string box13ManualInstructions { get; set; }
        public string zones { get; set; }
        public string box13SubdividedLimitsText { get; set; }
        public bool box13BetweenSide { get; set; }
        public bool box13AndSide { get; set; }
        public string extendUntilTime { get; set; }
        public string extendUntil1 { get; set; }
        public string extendUntil2 { get; set; }
        public string extendUntil3 { get; set; }
        public string authorityId { get; set; }
        public string box1TrackAuthorityId { get; set; }
    }

    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_Authorities
    {
        private static Dictionary<string, AuthorityObject> authorityDictionary = new Dictionary<string, AuthorityObject>();

        public static AuthorityObject GetAuthorityObject(string authoritySeed)
        {
            AuthorityObject authority = null;
            if (authorityDictionary.ContainsKey(authoritySeed))
            {
                authority = authorityDictionary[authoritySeed];
            }
            return authority;
        }

        public static string GetAuthorityNumber(string authoritySeed)
        {
            string authorityNumber = null;
            AuthorityObject authority = GetAuthorityObject(authoritySeed);
            if (authority != null)
            {
                authorityNumber = authority.authorityNumber;
            }
            return authorityNumber;
        }
        public static string GetAuthorityEngineSeed(string authoritySeed)
        {
            string authorityEngineSeed = null;
            AuthorityObject authority = GetAuthorityObject(authoritySeed);
            if (authority != null)
            {
                authorityEngineSeed = authority.engineSeed;
            }
            return authorityEngineSeed;
        }
        public static string GetAuthorityType(string authoritySeed)
        {
            string authorityType = null;
            AuthorityObject authority = GetAuthorityObject(authoritySeed);
            if (authority != null)
            {
                authorityType = authority.trackAuthorityType;
            }
            return authorityType;
        }
        public static string GetAuthorityBox2ProceedFrom(string authoritySeed)
        {
            string box2ProceedFrom = null;
            AuthorityObject authority = GetAuthorityObject(authoritySeed);
            if (authority != null)
            {
                box2ProceedFrom = authority.box2ProceedFrom;
            }
            return box2ProceedFrom;
        }
        public static string GetAuthorityBox2To1(string authoritySeed)
        {
            string box2To1 = null;
            AuthorityObject authority = GetAuthorityObject(authoritySeed);
            if (authority != null)
            {
                box2To1 = authority.box2To1;
            }
            return box2To1;
        }
        /// <summary>
        /// Finds the associated authoritySeed from particualr authority number
        /// </summary>
        /// <param name="authorityNumber">authorityNumber to get Authority Seed"</param>
        /// <returns></returns>
        public static string GetAuthoritySeed(string authorityNumber)
        {
            List<string> keyList = new List<string> (authorityDictionary.Keys);
            AuthorityObject authorityObj = null;
            foreach (string authoritySeed in keyList)
            {
                authorityObj = GetAuthorityObject(authoritySeed);

                if (authorityObj.authorityNumber.Equals(authorityNumber))
                {
                    return authoritySeed;
                }
            }
            return "";
        }

        public static global::PDS_NS.MainMenu_Repo MainMenurepo = global::PDS_NS.MainMenu_Repo.Instance;
        public static global::PDS_NS.TrackAuthorities_Repo Authoritiesrepo = global::PDS_NS.TrackAuthorities_Repo.Instance;
        public static global::PDS_NS.Miscellaneous_Repo Miscellaneousrepo = global::PDS_NS.Miscellaneous_Repo.Instance;
        public static global::PDS_NS.Trackline_Repo Tracklinerepo = global::PDS_NS.Trackline_Repo.Instance;
        public static global::PDS_NS.Bulletins_Repo Bulletinsrepo = global::PDS_NS.Bulletins_Repo.Instance;
        public static global::PDS_NS.Trains_Repo Trainsrepo = global::PDS_NS.Trains_Repo.Instance;
        public static int pendingAuthorityCount = 0;

        /// <summary>
        /// Opens the Track Authority Summary Form if not already open
        /// </summary>
        public static void AddAuthorityToObjectDictionary(string authoritySeed, string trackAuthorityType, string authorityNumber, string trainSeed, string engineSeed, string copiedBy, string rWOrOtWorker, string at, string box1TrackAuthorityNumber,
                                                          string box2ProceedFrom, bool box2Fsw, string box2To1, string box2Track1,
                                                          string box2To1HoldClearMain, string box2To2, string box2Track2, string box2To2HoldClearMain,
                                                          string box2To3, string box2Track3, string box2To3HoldClearMain,
                                                          string box3WorkBetweenFrom, bool box3FromCP, string box3To, bool box3ToCP, string box3Track1,
                                                          string box3Track2, string box3Track3, string box3Track4, string box3Track5,
                                                          string box4ProceedFrom, bool box4Fsw, string box4To1, string box4Track1,
                                                          string box4To1HoldClearMain, string box4To2, string box4Track2, string box4To2HoldClearMain,
                                                          string box4To3, string box4Track3, string box4To3HoldClearMain,
                                                          string box5UntilInMinutes, string box6EngineSeed1, string box6Engine1Direction, string box6EngineSeed2, string box6Engine2Direction,
                                                          string box6EngineSeed3, string box6Engine3Direction, string box6At, bool box7, string box8EngineSeed1, string box8Engine1Direction,
                                                          string box8EngineSeed2, string box8Engine2Direction,
                                                          string box8EngineSeed3, string box8Engine3Direction, bool box9,
                                                          string box10Between1, string box10Between2, string box11StopShort,
                                                          string box11Track, string box12RWIC1, string box12Between1,
                                                          string box12And1, string box12Track1, string box12RWIC2, string box12Between2,
                                                          string box12And2, string box12Track2, string box12RWIC3, string box12Between3,
                                                          string box12And3, string box12Track3, bool box13SubdivideLimits,
                                                          string box13AutomaticInstructions, string box13ManualInstructions, string zones,
                                                          string box13SubdividedLimitsText, bool box13BetweenSide, bool box13AndSide)
        {
            if (authorityDictionary.ContainsKey(authoritySeed))
            {
                authorityDictionary[authoritySeed] = new AuthorityObject();
            } else {
                authorityDictionary.Add(authoritySeed, new AuthorityObject());
            }

            AuthorityObject currentObject = authorityDictionary[authoritySeed];
            currentObject.trackAuthorityType = trackAuthorityType;
            currentObject.authorityNumber = authorityNumber;
            currentObject.trainSeed = trainSeed;
            currentObject.engineSeed = engineSeed;
            currentObject.copiedBy = copiedBy;
            currentObject.rWOrOtWorker = rWOrOtWorker;
            currentObject.at = at;
            currentObject.box1TrackAuthorityNumber = box1TrackAuthorityNumber;
            currentObject.box2ProceedFrom = box2ProceedFrom; currentObject.box2Fsw = box2Fsw; currentObject.box2To1 = box2To1; currentObject.box2Track1 = box2Track1;
            currentObject.box2To1HoldClearMain = box2To1HoldClearMain; currentObject.box2To2 = box2To2; currentObject.box2Track2 = box2Track2; currentObject.box2To2HoldClearMain = box2To2HoldClearMain;
            currentObject.box2To3 = box2To3; currentObject.box2Track3 = box2Track3; currentObject.box2To3HoldClearMain =box2To3HoldClearMain; currentObject.box3WorkBetweenFrom = box3WorkBetweenFrom;
            currentObject.box3FromCP = box3FromCP; currentObject.box3To = box3To; currentObject.box3ToCP = box3ToCP; currentObject.box3Track1 = box3Track1; currentObject.box3Track2 = box3Track2;
            currentObject.box3Track3 = box3Track3; currentObject.box3Track4 = box3Track4; currentObject.box3Track5 = box3Track5; currentObject.box4ProceedFrom = box4ProceedFrom; currentObject.box4Fsw = box4Fsw; currentObject.box4To1 = box4To1;
            currentObject.box4Track1 = box4Track1; currentObject.box4To1HoldClearMain = box4To1HoldClearMain; currentObject.box4To2 = box4To2; currentObject.box4Track2 = box4Track2; currentObject.box4To2HoldClearMain = box4To2HoldClearMain;
            currentObject.box4To3 = box4To3; currentObject.box4Track3 = box4Track3; currentObject.box4To3HoldClearMain = box4To3HoldClearMain; currentObject.box5UntilInMinutes = box5UntilInMinutes; currentObject.box6EngineSeed1 = box6EngineSeed1;
            currentObject.box6EngineSeed2 = box6EngineSeed2; currentObject.box6EngineSeed3 = box6EngineSeed3; currentObject.box6Engine1Direction = box6Engine1Direction;	currentObject.box6Engine2Direction = box6Engine2Direction;
            currentObject.box6Engine3Direction = box6Engine3Direction; currentObject.box6At = box6At;currentObject.box7 = box7;
            currentObject.box8EngineSeed1 = box8EngineSeed1;currentObject.box8EngineSeed2 = box8EngineSeed2; currentObject.box8EngineSeed3 = box8EngineSeed3;
            currentObject.box8Engine1Direction = box8Engine1Direction; currentObject.box8Engine2Direction = box8Engine2Direction; currentObject.box8Engine3Direction = currentObject.box8Engine3Direction;
            currentObject.box9 = box9; currentObject.box10Between1 = box10Between1; currentObject.box10Between2 = box10Between2; currentObject.box11StopShort = box11StopShort; currentObject.box11Track = box11Track;
            currentObject.box12RWIC1 = box12RWIC1; currentObject.box12Between1 = box12Between1; currentObject.box12And1 = box12And1; currentObject.box12Track1 = box12Track1; currentObject.box12RWIC2 = box12RWIC2; currentObject.box12Between2 = box12Between2; currentObject.box12And2 = box12And2; currentObject.box12Track2 = box12Track2;
            currentObject.box12RWIC3 = box12RWIC3; currentObject.box12Between3 = box12Between3; currentObject.box12And3 = box12And3; currentObject.box12Track3 = box12Track3; currentObject.box13SubdivideLimits = box13SubdivideLimits;
            currentObject.box13AutomaticInstructions = box13AutomaticInstructions; currentObject.box13ManualInstructions = box13ManualInstructions;
            currentObject.box13SubdividedLimitsText=box13SubdividedLimitsText;
            currentObject.box13BetweenSide=box13BetweenSide;
            currentObject.box13AndSide=box13AndSide;
            currentObject.zones=zones;
            return;
        }

        [UserCodeMethod]
        public static void AddAuthorityNumber (string authoritySeed)
        {
            AuthorityObject currentObj = authorityDictionary[authoritySeed];
            currentObj.authorityNumber = Authoritiesrepo.Communications_Exchange_Ok_Authority.AuthorityNumberText.TextValue;
        }

        public static void AddAuthorityId(string authoritySeed)
        {
        	string authorityNumber = NS_Authorities.GetAuthorityNumber(authoritySeed);
        	AuthorityObject currentObj = authorityDictionary[authoritySeed];
        	currentObj.authorityId = ADMSEnvironment.GetAuthorityId_ADMS(authorityNumber);
        }
        public static void Addbox1TrackAuthorityId(string authoritySeed, string authorityNumber)
        {
        	AuthorityObject currentObj = authorityDictionary[authoritySeed];
        	currentObj.box1TrackAuthorityId = ADMSEnvironment.GetAuthorityId_ADMS(authorityNumber);
        }

        [UserCodeMethod]
        public static void AddAuthorityBox13_SubDivideLimits (string authoritySeed)
        {
            AuthorityObject currentObj = authorityDictionary[authoritySeed];
            currentObj.box13SubdividedLimitsText=Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.EnterLocationsToSubdivide.SubdividedLocationText.TextValue;
            currentObj.box13BetweenSide=Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.EnterLocationsToSubdivide.BetweenSideRadioButton.Checked;
            currentObj.box13AndSide=Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.EnterLocationsToSubdivide.AndSideRadioButton.Checked;

        }
        [UserCodeMethod]
        public static void AddAuthorityCopiedBy (string authoritySeed)
        {
            AuthorityObject currentObj = authorityDictionary[authoritySeed];
            currentObj.copiedBy = Authoritiesrepo.Communications_Exchange_Ok_Authority.CopiedByText.GetAttributeValue<string>("Text");
        }

        public static void AddExtendUntilTime (string authoritySeed, string extendTime)
        {
            AuthorityObject currentObj = authorityDictionary[authoritySeed];
            if(string.IsNullOrEmpty(currentObj.extendUntil1)){
                currentObj.extendUntil1 = extendTime;
                return;
            }
            else if(String.IsNullOrEmpty(currentObj.extendUntil2))
            {
                currentObj.extendUntil2 = extendTime;
                return;
            }
            else
            {
                currentObj.extendUntil3 = extendTime;
                return;
            }
        }

        /// <summary>
        /// Creates and adds a new authority object to the dictionary from whatever information is current on the create track authority form.
        /// </summary>
        /// <param name="newAuthoritySeed">The string a user will be able to access the new authority with.</param>
        [UserCodeMethod]
        public static void AddAuthorityObjectFromOpenAuthority (string newAuthoritySeed)
        {
        	Authoritiesrepo = new TrackAuthorities_Repo();
            Ranorex.Delay.Milliseconds(500);
            GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Authoritiesrepo.Create_Track_Authority.RibbonMenu.LongFormInfo, Authoritiesrepo.Create_Track_Authority.RibbonMenu.LongFormInfo);
            if (!authorityDictionary.ContainsKey(newAuthoritySeed))
            	authorityDictionary.Add(newAuthoritySeed, new AuthorityObject());
            AuthorityObject currentObject = authorityDictionary[newAuthoritySeed];
            //Authority type
            //currentObj.authorityNumber -> cant get this without going to commex, which with tac authorities in 3-12, you cannot go in and back out
            //which is very unfortunate becasuse that would be the best way to confirm a message correlates to the authority being tested
            if (Authoritiesrepo.Create_Track_Authority.OTRadio.Checked)
            {
                currentObject.trackAuthorityType = "OT";
                currentObject.rWOrOtWorker = Authoritiesrepo.Create_Track_Authority.To.NonEngineToText.GetAttributeValue<string>("SelectedItemText");
            }
            else if (Authoritiesrepo.Create_Track_Authority.RWRadio.Checked)
            {
                currentObject.trackAuthorityType = "RW";
                Ranorex.Report.Info(Authoritiesrepo.Create_Track_Authority.To.NonEngineToText.Visible.ToString());
                currentObject.rWOrOtWorker = Authoritiesrepo.Create_Track_Authority.To.NonEngineToText.GetAttributeValue<string>("SelectedItemText");
            }
            else if (Authoritiesrepo.Create_Track_Authority.TERadio.Checked)
            {
                currentObject.trackAuthorityType = "TE";
                currentObject.trainSeed = NS_TrainID.GetTrainSeedFromTrainId(Authoritiesrepo.Create_Track_Authority.TrainID.TrainIDMenuButton.Text.Substring(0, Authoritiesrepo.Create_Track_Authority.TrainID.TrainIDMenuButton.Text.IndexOf(' ')));
                //TODO make a function that can also just look into a given train object for an engine seed
                if(!String.IsNullOrEmpty(currentObject.trainSeed.ToString()))
                {
                    currentObject.engineSeed = NS_TrainID.getTrainObject(currentObject.trainSeed).GetEngineSeedfromEngineId(Authoritiesrepo.Create_Track_Authority.To.EngineToText.Text);
                }
            }
            else
            {
                Ranorex.Report.Error("Unknown authority type. Please check radio buttons for unusualy behaviour.");
            }

            currentObject.copiedBy = "Automation";
            currentObject.at = Authoritiesrepo.Create_Track_Authority.At.AtText.GetAttributeValue<string>("Text");
            currentObject.box1TrackAuthorityNumber = Authoritiesrepo.Create_Track_Authority.Box1.VoidTrackAuthorityNumberText.Text;
            currentObject.box2ProceedFrom = Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Between.Text;
            currentObject.box2Fsw = Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.FSWToCheckbox.Checked;
            currentObject.box2To1 = Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1To1.Text;
            currentObject.box2Track1 = Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Track1.Text;
            currentObject.box2To1HoldClearMain = null; //Does not matter really, as box 7 and 9 always refer to the last point mentioned in the authority
            currentObject.box2To2 = Authoritiesrepo.Create_Track_Authority.Box2.Proceed2.Proceed1To2.Text;
            currentObject.box2Track2 = Authoritiesrepo.Create_Track_Authority.Box2.Proceed2.Proceed1Track2.Text;
            currentObject.box2To2HoldClearMain = null; //Does not matter really, as box 7 and 9 always refer to the last point mentioned in the authority
            currentObject.box2To3 = Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1To3.Text;
            currentObject.box2Track3 = Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1Track3.Text;
            currentObject.box2To3HoldClearMain = null; //Does not matter really, as box 7 and 9 always refer to the last point mentioned in the authority
            currentObject.box3WorkBetweenFrom = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenBetween.Text;
            currentObject.box3FromCP = Authoritiesrepo.Create_Track_Authority.Box3.ControlPoint1Checkbox.Checked;
            currentObject.box3To = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenAnd.Text;
            currentObject.box3ToCP = Authoritiesrepo.Create_Track_Authority.Box3.ControlPoint2Checkbox.Checked;
            currentObject.zones = null;
            currentObject.box3Track1 = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack1.Text;
            currentObject.box3Track2 = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack2.Text;
            currentObject.box3Track3 = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack3.Text;
            currentObject.box3Track4 = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack4.Text;
            currentObject.box3Track5 = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack5.Text;
            currentObject.box4ProceedFrom = Authoritiesrepo.Create_Track_Authority.Box4.Proceed1.Proceed2Between.Text;
            currentObject.box4Fsw = Authoritiesrepo.Create_Track_Authority.Box4.Box4Checkbox.Checked;
            currentObject.box4To1 = Authoritiesrepo.Create_Track_Authority.Box4.Proceed1.Proceed2To1.Text;
            currentObject.box4Track1 = Authoritiesrepo.Create_Track_Authority.Box4.Proceed1.Proceed2Track1.Text;
            currentObject.box4To1HoldClearMain = null; //Does not matter really, as box 7 and 9 always refer to the last point mentioned in the authority
            currentObject.box4To2 = Authoritiesrepo.Create_Track_Authority.Box4.Proceed2.Proceed2To2.Text;
            currentObject.box4Track2 = Authoritiesrepo.Create_Track_Authority.Box4.Proceed2.Proceed2Track2.Text;
            currentObject.box4To2HoldClearMain = null; //Does not matter really, as box 7 and 9 always refer to the last point mentioned in the authority
            currentObject.box4To3 = Authoritiesrepo.Create_Track_Authority.Box4.Proceed3.Proceed2To3.Text;
            currentObject.box4Track3 = Authoritiesrepo.Create_Track_Authority.Box4.Proceed3.Proceed2Track3.Text;
            currentObject.box4To3HoldClearMain = null; //Does not matter really, as box 7 and 9 always refer to the last point mentioned in the authority
            currentObject.box5UntilInMinutes = Authoritiesrepo.Create_Track_Authority.Box5.EffectiveUntilText.TextValue;

            string box6Strings = Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainField1Text.TextValue;
            if (!box6Strings.Equals(""))
            {
                currentObject.box6EngineSeed1 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineSeedFromEngineId(box6Strings.Substring(0, box6Strings.LastIndexOf(' ')));
                currentObject.box6Engine1Direction = box6Strings.Substring(box6Strings.LastIndexOf(' ')+1);
                currentObject.box6At = Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainsLocation.TextValue;
                box6Strings = Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainField2Text.TextValue;
                if (!box6Strings.Equals(""))
                {
                    currentObject.box6EngineSeed2 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineSeedFromEngineId(box6Strings.Substring(0, box6Strings.LastIndexOf(' ')));
                    currentObject.box6Engine2Direction = box6Strings.Substring(box6Strings.LastIndexOf(' ')+1);
                    box6Strings = Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainField3Text.TextValue;
                    if (!box6Strings.Equals(""))
                    {
                        currentObject.box6EngineSeed3 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineSeedFromEngineId(box6Strings.Substring(0, box6Strings.LastIndexOf(' ')));
                        currentObject.box6Engine3Direction = box6Strings.Substring(box6Strings.LastIndexOf(' ')+1);
                    }
                    else
                    {
                        currentObject.box6EngineSeed3 = "";
                        currentObject.box6Engine3Direction = "";
                    }
                }
                else
                {
                    currentObject.box6EngineSeed2 = "";
                    currentObject.box6Engine2Direction = "";
                    currentObject.box6EngineSeed3 = "";
                    currentObject.box6Engine3Direction = "";
                }
            }
            else
            {
                currentObject.box6EngineSeed1 = "";
                currentObject.box6Engine1Direction = "";
                currentObject.box6EngineSeed2 = "";
                currentObject.box6Engine2Direction = "";
                currentObject.box6EngineSeed3 = "";
                currentObject.box6Engine3Direction = "";
                currentObject.box6At = "";
            }

            //If anyone wants to do some error checking for defec
            currentObject.box7 = Authoritiesrepo.Create_Track_Authority.Box7.Box7Checkbox.Checked;
            string box8Strings = Authoritiesrepo.Create_Track_Authority.Box8.TrainsToFollowTrain1Text.TextValue;
            if (!box8Strings.Equals(""))
            {
                currentObject.box8EngineSeed1 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineSeedFromEngineId(box8Strings.Substring(0, box8Strings.LastIndexOf(' '))); //This should be the{scac} {id} portion
                currentObject.box8Engine1Direction = box8Strings.Substring(box8Strings.LastIndexOf(' ')+1);
                box8Strings = Authoritiesrepo.Create_Track_Authority.Box8.TrainsToFollowTrain2Text.TextValue;
                if (!box8Strings.Equals(""))
                {
                    currentObject.box8EngineSeed2 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineSeedFromEngineId(box8Strings.Substring(0, box8Strings.LastIndexOf(' '))); //This should be the{scac} {id} portion
                    currentObject.box8Engine2Direction = box8Strings.Substring(box8Strings.LastIndexOf(' ')+1);
                    box8Strings = Authoritiesrepo.Create_Track_Authority.Box8.TrainsToFollowTrain3Text.TextValue;
                    if (!box8Strings.Equals(""))
                    {
                        currentObject.box8EngineSeed3 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineSeedFromEngineId(box8Strings.Substring(0, box8Strings.LastIndexOf(' '))); //This should be the{scac} {id} portion
                        currentObject.box8Engine3Direction = box8Strings.Substring(box8Strings.LastIndexOf(' ')+1);
                    }
                    else
                    {
                        currentObject.box8EngineSeed3 = "";
                        currentObject.box8Engine3Direction = "";
                    }
                }
                else
                {
                    currentObject.box8EngineSeed2 = "";
                    currentObject.box8Engine2Direction = "";
                    currentObject.box8EngineSeed3 = "";
                    currentObject.box8Engine3Direction = "";
                }

            }
            else
            {
                currentObject.box8EngineSeed1 = "";
                currentObject.box8Engine1Direction = "";
                currentObject.box8EngineSeed2 = "";
                currentObject.box8Engine2Direction = "";
                currentObject.box8EngineSeed3 = "";
                currentObject.box8Engine3Direction = "";
            }

            currentObject.box9 = Authoritiesrepo.Create_Track_Authority.Box9.Box9Checkbox.Checked;
            currentObject.box10Between1 = Authoritiesrepo.Create_Track_Authority.Box10.TrainsSpeedRestrictionBetweenText.Text;
            currentObject.box10Between2 = Authoritiesrepo.Create_Track_Authority.Box10.TrainsSpeedRestrictionAndText.Text;
            currentObject.box11StopShort = Authoritiesrepo.Create_Track_Authority.Box11.StopShortPointText.Text;
            currentObject.box11Track = Authoritiesrepo.Create_Track_Authority.Box11.StopShortTrackText.Text;
            currentObject.box12RWIC1 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC1.WorkersInChargeName1Text.TextValue;
            currentObject.box12Between1 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC1.WorkersInChargeBetween1Text.TextValue;
            currentObject.box12And1 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC1.WorkersInChargeAnd1Text.TextValue;
            currentObject.box12Track1 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC1.WorkersInChargeTrack1Text.TextValue;
            currentObject.box12RWIC2 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC2.WorkersInChargeName2Text.TextValue;
            currentObject.box12Between2 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC2.WorkersInChargeBetween2Text.TextValue;
            currentObject.box12And2 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC2.WorkersInChargeAnd2Text.TextValue;
            currentObject.box12Track2 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC2.WorkersInChargeTrack2Text.TextValue;
            currentObject.box12RWIC3 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC3.WorkersInChargeName3Text.TextValue;
            currentObject.box12Between3 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC3.WorkersInChargeBetween3Text.TextValue;
            currentObject.box12And3 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC3.WorkersInChargeAnd3Text.TextValue;
            currentObject.box12Track3 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC3.WorkersInChargeTrack3Text.TextValue;
            //TODO Seems like this isnt implemented correctly currentObject.box13SubdivideLimits = Authoritiesrepo.Create_Track_Authority.Box13.SubdivideLimitsCheckbox.Checked;
            currentObject.box13SubdivideLimits = Authoritiesrepo.Create_Track_Authority.Box13.SubdivideLimitsCheckbox.Checked; //TODO see above comment
            //currentObject.box13SubdividedLimitsText=Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.EnterLocationsToSubdivide.SubdividedLocationText.TextValue;
            currentObject.box13AutomaticInstructions = Authoritiesrepo.Create_Track_Authority.Box13.OtherInstructionsSystemText.TextValue;
            currentObject.box13ManualInstructions = Authoritiesrepo.Create_Track_Authority.Box13.OtherInstructionsUserText.TextValue;
            return;
        }
        /// <summary>
        /// Opens the Track Authority Summary Form if not already open
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenAuthoritySummaryList_MainMenu()
        {
            int retries = 0;

            //Open Authority Summary List Form if it's not already open
            if (!Authoritiesrepo.Track_Authority_Summary_List.SelfInfo.Exists(0))
            {
                //Click Track Authorites menu
                GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrackAuthoritesButtonInfo,
                                                          MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.SummaryListInfo);

                //Click Summary List in Track Authorities menu
                GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.SummaryListInfo,
                                                          Authoritiesrepo.Track_Authority_Summary_List.SelfInfo);

                //Wait for Track Authority Summary List Form to exist in case of lag
                if (!Authoritiesrepo.Track_Authority_Summary_List.SelfInfo.Exists(0))
                {
                    while (!Authoritiesrepo.Track_Authority_Summary_List.SelfInfo.Exists(0) && retries < 2)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }

                    if (!Authoritiesrepo.Track_Authority_Summary_List.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("Track Authority Summary List form did not open");
                        return;
                    }
                }

                retries = 0;
                int trackAuthorityRows = Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.Self.Rows.Count;
                bool finished = false;
                while (!finished && retries < 2)
                {
                    Ranorex.Delay.Milliseconds(500);
                    //As long as the count changes within the half second, we will continue waiting in the loop

                    if (Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.Self.Rows.Count == 0)
                    {
                        retries++;
                        continue;
                    }

                    if (Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.Self.Rows.Count != trackAuthorityRows)
                    {
                        trackAuthorityRows = Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.Self.Rows.Count;
                        continue;
                    }

                    finished = true;
                }

                if (trackAuthorityRows == 0)
                {
                    Ranorex.Report.Info("No Track Authorities found in Track Authority Summary");
                }
            }

            return;
        }

        /// <summary>
        /// Opens the Track Authority Summary Form if not already open
        /// </summary>
        /// /// <param name="authorityType">Input:Types of authorities(e.g. TE/RW/OT)</param>
        [UserCodeMethod]
        public static void NS_OpenAuthorityForm_MainMenu(string authorityType)
        {
            int retries = 0;

            //Open Create Authority Form if it's not already open
            if (!Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
            {
                //Click Track Authorites menu
                GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrackAuthoritesButtonInfo,
                                                         MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.SelfInfo);

                Ranorex.Report.Info("Trying to open " + authorityType + " Authority form");

                //Click on Authority type from Track Authorities menu
                switch(authorityType){

                    case "TE":
                        GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.ToTrainOrEngineInfo,
                		                                          Authoritiesrepo.Create_Track_Authority.SelfInfo);
                        break;

                    case "RW":
                        GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.ToRoadwayWorkerInfo,
                		                                          Authoritiesrepo.Create_Track_Authority.SelfInfo);
                        break;

                    case "OT":
                        GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.ToOnTrackEquipmentInfo,
                		                                          Authoritiesrepo.Create_Track_Authority.SelfInfo);
                        break;

                }

                //Wait for Create Authority Form to exist in case of lag
                if (!Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
                {
                    Ranorex.Delay.Milliseconds(500);
                    while (!Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0) && retries < 2)
                    {
                    	GeneralUtilities.CheckWaitState(10);
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }

                    if (!Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("Create Track Authority form did not open");
                        return;
                    }
                }

            }

            Ranorex.Report.Info(authorityType + " create Authority form is opened");

            switch(authorityType){

                case "TE":
                    if (!Authoritiesrepo.Create_Track_Authority.TERadio.Checked)
                    {
                        Authoritiesrepo.Create_Track_Authority.TERadio.Click();
                    }
                    break;

                case "RW":
                    if (!Authoritiesrepo.Create_Track_Authority.RWRadio.Checked)
                    {
                        Authoritiesrepo.Create_Track_Authority.RWRadio.Click();
                    }
                    break;

                case "OT" :
                    if (!Authoritiesrepo.Create_Track_Authority.OTRadio.Checked)
                    {
                        Authoritiesrepo.Create_Track_Authority.OTRadio.Click();
                    }
                    break;
            }

            return;
        }

        /// <summary>
        /// Opens the Track Authority Summary Form if not already open
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenTETrackAuthorityForm_MainMenu()
        {
            NS_OpenAuthorityForm_MainMenu("TE");
        }

        /// <summary>
        /// Opens the RW Track Authority Form if not already open
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenRWTrackAuthorityForm_MainMenu()
        {
            NS_OpenAuthorityForm_MainMenu("RW");
        }

        /// <summary>
        /// Opens the OT Track Authority Form if not already open
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenOTTrackAuthorityFrom_MainMenu()
        {
            NS_OpenAuthorityForm_MainMenu("OT");
        }

        /// <summary>
        /// Opens an authority from the Authority Summary List
        /// </summary>
        /// <param name="authoritySeed">Input:Authority seed for the authority object, if none exists, checks if a form is already open</param>
        [UserCodeMethod]
        public static void NS_OpenAuthority_AuthoritySummaryList(string authoritySeed)
        {
            string authorityNumber = "";
            int retries = 0;
            if (authorityDictionary.ContainsKey(authoritySeed))
            {
                authorityNumber = authorityDictionary[authoritySeed].authorityNumber;
            }
            Authoritiesrepo.AuthorityNumber = authorityNumber;
            if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0) && authorityNumber == "")
            {
                Ranorex.Report.Error("No Authority Number present and no open authorities");
                return;
            } else if (authorityNumber == "")
            {
                Ranorex.Report.Info("Authority form already open.");
                return;
            }
            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AuthorityNumberText.TextValue == authorityNumber)
                {
                    Ranorex.Report.Info("Authority form for Authority Number {"+authorityNumber+"} already open.");
                    return;
                }
            }

            NS_OpenAuthoritySummaryList_MainMenu();
            if (!Authoritiesrepo.Track_Authority_Summary_List.SelfInfo.Exists(0))
            {
                //We do not have to say there's a failure as the previous function will have said that
                return;
            }

            Authoritiesrepo.AuthorityNumber = authorityNumber;

            while(!Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.TrackAuthorityRowByAuthorityNumber.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(1000);
                retries++;
            }

            if (!Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.TrackAuthorityRowByAuthorityNumber.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("No authority found for Authority Number {"+authorityNumber+"}");
                return;
            }
            else
            {
                Authoritiesrepo.TrackAuthorityIndex = Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.TrackAuthorityRowByAuthorityNumber.Self.GetAttributeValue<int>("index").ToString();
            }
            
            Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.TrackAuthorityRowByAuthorityNumber.Self.EnsureVisible();
            Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.TrackAuthorityRowByAuthorityNumber.MenuCell.Click(WinForms.MouseButtons.Right);
            Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.MenuCellMenu.ViewTrackAuthority.Click();

            while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0) && retries < 5)
            {
                if (retries == 2 && Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.MenuCellMenu.SelfInfo.Exists(0))
                {
                    Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.MenuCellMenu.ViewTrackAuthority.Click();
                }
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Track Authority with Authority Number {"+authorityNumber+"} could not be opened from Authority Summary List");
            }
            Authoritiesrepo.Track_Authority_Summary_List.WindowControls.Close.Click();
            return;
        }
        /// <summary>
        /// Opens an authority from the Authority Summary List Choice
        /// </summary>
        /// <param name="authoritySeed">Input:Authority seed for the authority object, if none exists, checks if a form is already open</param>
        [UserCodeMethod]
        public static void NS_OpenAuthority_AuthoritySummaryListChoice(string authoritySeed, string optDivision, string optLogicalPosition)
        {

            //Open Authority Summary List Choice Form if it's not already open
            if (!Authoritiesrepo.Track_Authority_Summary_List_Choice.SelfInfo.Exists(0))
            {

                GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrackAuthoritesButtonInfo,MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.SummaryListChoiceInfo);
                GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.SummaryListChoiceInfo,Authoritiesrepo.Track_Authority_Summary_List_Choice.OkButtonInfo);

                if(optDivision != "")
                {
                    Authoritiesrepo.Division = optDivision;

                    GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Track_Authority_Summary_List_Choice.Division.DivisionMenuItemInfo,
                                                              Authoritiesrepo.Track_Authority_Summary_List_Choice.Division.DivisionMenuList.DivisionListItemByDivisionNameInfo);

                    Authoritiesrepo.Track_Authority_Summary_List_Choice.Division.DivisionMenuList.DivisionListItemByDivisionName.Click();
                }

                if(optLogicalPosition != "")
                {
                    Authoritiesrepo.LogicalPosition = optLogicalPosition;

                    GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Track_Authority_Summary_List_Choice.LogicalPosition.LogicalDivisionMenuItemInfo,
                                                              Authoritiesrepo.Track_Authority_Summary_List_Choice.LogicalPosition.LogicalPositionMenuList.LogicalPositionItemByLogicalPositionNameInfo);

                    Authoritiesrepo.Track_Authority_Summary_List_Choice.LogicalPosition.LogicalPositionMenuList.LogicalPositionItemByLogicalPositionName.Click();
                }

                GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Track_Authority_Summary_List_Choice.OkButtonInfo,Authoritiesrepo.Track_Authority_Summary_List.SelfInfo);

            }
            if (!Authoritiesrepo.Track_Authority_Summary_List.SelfInfo.Exists(0))
            {

                Ranorex.Report.Error("Track Authority Summary List form did not open");

            }

            NS_OpenAuthority_AuthoritySummaryList(authoritySeed);

        }

        /// <summary>
        /// Open Track authority using short cut keys.
        /// </summary>
        /// <param name="trackAuthorityType">Input:Types of authorities(e.g. TE/RW/OT)</param>
        [UserCodeMethod]
        public static void NS_OpenTrackAuthority_ShortCutKeys_MainMenu(string trackAuthorityType)
        {
            int retries=0;
            switch(trackAuthorityType)
            {
                case "RW":
                    MainMenurepo.PDS_Main_Menu.MainMenuBar.TrackAuthoritesButton.PressKeys("{Shift down}{F6}{shift up}");
                    while(!Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0) && retries<5)
                    {
                        Delay.Milliseconds(1000);
                        retries++;
                    }
                    break;
                case "OT":
                    MainMenurepo.PDS_Main_Menu.MainMenuBar.TrackAuthoritesButton.PressKeys("{Shift down}{F7}{shift up}");
                    while(!Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0) && retries<5)
                    {
                        Delay.Milliseconds(1000);
                        retries++;
                    }
                    break;
                case "TE":
                    MainMenurepo.PDS_Main_Menu.MainMenuBar.TrackAuthoritesButton.PressKeys("{Shift down}{F5}{shift up}");
                    while(!Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0) && retries<5)
                    {
                        Delay.Milliseconds(1000);
                        retries++;
                    }
                    break;
                    default: Ranorex.Report.Error("No authority type Found");
                    break;
            }
            return;
        }

        /// <summary>
        /// Validate TO Field is Enabled in Creating Track Authority Form
        /// </summary>
        /// <param name="closeForms">close The create Track Authority form</param>
        [UserCodeMethod]
        public static void NS_ValidateAuthorityTOFieldIsEnabled_CreateTrackAuthority(bool closeForms)
        {
            bool isEnabled = false;
            if(Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
            {
                isEnabled = Authoritiesrepo.Create_Track_Authority.To.NonEngineToText.Enabled;
                if(isEnabled)
                {
                    Ranorex.Report.Success("To field is enabled");
                }
                else
                {
                    Ranorex.Report.Failure("To field is not enabled");
                }
            }
            else
            {
                Ranorex.Report.Failure("Track Authority form not open");
            }
            if(closeForms)
            {

                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.WindowControls.CloseInfo,
                                                                  Authoritiesrepo.Create_Track_Authority.SelfInfo);
            }
            return;
        }

        /// <summary>
        ///validate TO Filed Disabled in Communication Exchange TrackAuthority Form
        /// </summary>
        /// <param name="closeForms">close The Communication Exchange Track Authority form</param>
        [UserCodeMethod]
        public static void NS_ValidateAuthorityTOFieldIsDisabled_IssueTrackAuthority(bool closeForms)
        {
            bool toAck=true;
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                toAck=Authoritiesrepo.Communications_Exchange_Ok_Authority.To.NonEngineToText.Enabled;
                if(toAck)
                {
                    Ranorex.Report.Failure("To field is Enabled");
                }
                else
                {
                    Ranorex.Report.Success("To field is Disabled");
                }
            }
            else
            {
                Ranorex.Report.Failure("Track Authority form not open");
            }
            if(closeForms)
            {
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.WindowControls.CloseInfo,
            	                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
            }
            return;
        }


        /// <summary>
        /// Open Authority Right click on trackline
        /// </summary>
        /// <param name="authoritySeed">Input:authroity seed for Authority object</param>

        [UserCodeMethod]
        public static void NS_OpenAuthority_RightClick_TrackLine(string authoritySeed)
        {

            string authorityNumber = "";
            if (authorityDictionary.ContainsKey(authoritySeed))
            {
                authorityNumber = authorityDictionary[authoritySeed].authorityNumber;
            }

            if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.ViewTrainsButtonInfo.Exists(0) && authorityNumber == "")
            {
                Ranorex.Report.Error("No Authority Number present and no open authorities");
                return;
            } else if (authorityNumber == "")
            {
                Ranorex.Report.Info("Authority form already open.");
                return;
            }
            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.ViewTrainsButtonInfo.Exists(0))
            {
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AuthorityNumberText.TextValue == authorityNumber)
                {
                    Ranorex.Report.Info("Authority form for Authority Number {"+authorityNumber+"} already open.");
                    return;
                }
            }
            //Authorities are displayed like a train and use train id
            if (authorityDictionary[authoritySeed].trackAuthorityType == "TE") {
                Tracklinerepo.TrainId = authorityDictionary[authoritySeed].authorityNumber + " " + PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(authorityDictionary[authoritySeed].trainSeed) + " ("+PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authorityDictionary[authoritySeed].trainSeed, authorityDictionary[authoritySeed].engineSeed).EngineInitial + " " + PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authorityDictionary[authoritySeed].trainSeed, authorityDictionary[authoritySeed].engineSeed).EngineNumber + ")";
            } else {
                Tracklinerepo.TrainId = authorityDictionary[authoritySeed].authorityNumber + " " + authorityDictionary[authoritySeed].rWOrOtWorker;
            }

            Ranorex.Report.Info("Train Id is: "+Tracklinerepo.TrainId.ToString());
            if(!Tracklinerepo.Trackline_Form.AuthorityObjectInfo.Exists(0))
            {
                Ranorex.Report.Error("Authority with id {"+Tracklinerepo.TrainId+"} not found on any open trackline.");
                return;
            }

            if(Tracklinerepo.Trackline_Form.VisibleAuthorityObjectInfo.Exists(0))
            {
                GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.VisibleAuthorityObjectInfo,Tracklinerepo.Trackline_Form.AuthorityObjectMenu.OpenAuthorityInfo);
                GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.AuthorityObjectMenu.OpenAuthorityInfo,Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);

                if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Error("Track Authority with Authority Number {"+authorityNumber+"} could not be opened from Authority Summary List");
                }
                return;
            }

            if(Tracklinerepo.Trackline_Form.HiddenAuthorityObjectInfo.Exists(0))
            {
                if(Tracklinerepo.Trackline_Form.HiddenAuthorityObject.EnsureVisible())
                {
                    GeneralUtilities.MiddleClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.HiddenAuthorityObjectInfo,
                                                                    Tracklinerepo.Trackline_Form.MenuTrainObjectInfo);
                }

                if(Tracklinerepo.Trackline_Form.MenuTrainObjectInfo.Exists(0))
                {
                    GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.MenuTrainObjectInfo,
                                                                   Tracklinerepo.Trackline_Form.AuthorityObjectMenu.OpenAuthorityInfo);
                    GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.AuthorityObjectMenu.OpenAuthorityInfo,Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);

                }

                if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Error("Track Authority with Authority Number {"+authorityNumber+"} could not be opened from Authority Summary List");
                }
                return;
            }

        }

        /// <summary>
        ///validate Suspend Button Disabled in Communication Exchange TrackAuthority Form
        /// </summary>
        /// <param name="closeForms">close The Communication Exchange Track Authority form</param>
        [UserCodeMethod]
        public static void NS_ValidateAuthoritySuspendButtonIsDisabled_Communication_ExchangeAuthorityForm(bool closeForms, bool rumDenyPopup)
        {
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                if(Authoritiesrepo.Communications_Exchange_Ok_Authority.RibbonMenu.Suspend.Enabled)
                {
                    Ranorex.Report.Failure("Suspend Button is Enabled");
                }
                else
                {
                    Ranorex.Report.Success("Suspend Button is Disabled");
                }
            }
            else
            {
                Ranorex.Report.Failure("Track Authority form not open");
            }
            if(closeForms)
            {
            	if(rumDenyPopup)
            	{

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
            			Ranorex.Report.Info("Denying Autority by closing the Form");
            		}
            	}
            	else
            	{
            		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.WindowControls.CloseInfo,
            		                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
            	}
            }
            return;
        }

        /// <summary>
        /// Open Authority via the trackline
        /// </summary>
        /// <param name="authoritySeed">Input:authroity seed for Authority object</param>
        [UserCodeMethod]
        public static void NS_OpenAuthority_Trackline(string authoritySeed)
        {
            string authorityNumber = "";
            if (authorityDictionary.ContainsKey(authoritySeed))
            {
                authorityNumber = authorityDictionary[authoritySeed].authorityNumber;
            }

            if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.ViewTrainsButtonInfo.Exists(0) && authorityNumber == "")
            {
                Ranorex.Report.Error("No Authority Number present and no open authorities");
                return;
            } else if (authorityNumber == "")
            {
                Ranorex.Report.Info("Authority form already open.");
                return;
            }
            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.ViewTrainsButtonInfo.Exists(0))
            {
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AuthorityNumberText.TextValue == authorityNumber)
                {
                    Ranorex.Report.Info("Authority form for Authority Number {"+authorityNumber+"} already open.");
                    return;
                }
            }

            AuthorityObject authority = authorityDictionary[authoritySeed];
            //Authorities are displayed like a train and use trainid
            if (authority.trackAuthorityType == "TE") {
                Tracklinerepo.TrainId = authority.authorityNumber + " " + PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(authority.trainSeed) + " ("+PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authority.trainSeed, authority.engineSeed).EngineInitial + " " + PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authority.trainSeed, authority.engineSeed).EngineNumber + ")";
            } else {
                Tracklinerepo.TrainId = authority.authorityNumber + " " + authority.rWOrOtWorker;
            }

            Ranorex.Report.Info("Train Id is: "+Tracklinerepo.TrainId.ToString());
            if(!Tracklinerepo.Trackline_Form.AuthorityObjectInfo.Exists(0))
            {
                Ranorex.Report.Error("Authority with id {"+Tracklinerepo.TrainId+"} not found on any open trackline.");
                return;
            }

            Tracklinerepo.Trackline_Form.AuthorityObject.DoubleClick();
            int retries = 0;
            while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.ViewTrainsButtonInfo.Exists(0) && retries < 5)
            {
                if (retries == 2)
                {
                    Tracklinerepo.Trackline_Form.AuthorityObject.DoubleClick();
                }
                Ranorex.Delay.Seconds(1);
                retries++;
            }

            if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.ViewTrainsButtonInfo.Exists(0))
            {
                Ranorex.Report.Error("Track Authority with Authority Number {"+authorityNumber+"} could not be opened from Authority Summary List");
            }
            return;
        }

        /// <summary>
        /// Voids a particular Authority by Authority Seed
        /// </summary>
        /// <param name="authoritySeed">Input:Authority seed for the authority object</param>
        /// <param name="expectedFeedback">Input:Expected Feedback for failure cases using regex</param>
        /// <param name="openFromSummaryList">Input:If true, opens the authority from the summary list, else opens from the trackline</param>
        /// <param name="issueAuthorityPTCVoice"> Will click the Voice button if true, if false it will end at voice form if it exists, otherwise complete it</param>
        /// <param name="closeForms">Input:Closes Authority Summary List if open</param>
        /// <param name="optionalJointOccupancyChoice">Input:No, Yes, or blank for anything else</param>
        [UserCodeMethod]
        public static void NS_VoidAuthorityFunction(string authoritySeed, string expectedFeedback, bool openFromSummaryList, bool issueAuthorityPTCVoice, bool pressAcknowledge, bool closeForms, string optionalJointOccupancyChoice = "No")
        {

            int retries = 0;

            if(openFromSummaryList){
                NS_OpenAuthority_AuthoritySummaryList(authoritySeed);
            } else{
                NS_OpenAuthority_Trackline(authoritySeed);
            }

            AuthorityObject authorityObject = NS_Authorities.authorityDictionary[authoritySeed];

            //Waiting for the Authority form to open, {Maris} -- need to make sure the entire thing loa
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0) && retries < 5 )
            {
                Ranorex.Delay.Milliseconds(200);
                retries++;
            }
            retries = 0;

            if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("Failed to Open Authority");
                return;
            }

            if (authorityObject.trackAuthorityType == "RW")
            {
                //Seems to have a hard time seeing the joint occupansts text, give it some buffer room
                while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsTextInfo.Exists(0) && retries < 5 )
                {
                    Ranorex.Delay.Milliseconds(200);
                    retries++;
                }
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.Enabled)
                {
                    if (optionalJointOccupancyChoice.ToLower() == "yes")
                    {
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.Click();

                        GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsTextInfo,
                                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.YesInfo);
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.Yes.Click();
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.PressKeys("{TAB}");
                    } else if (optionalJointOccupancyChoice.ToLower() == "no")
                    {
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.Click();

                        GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsTextInfo,
                                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.NoInfo);
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.No.Click();
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.PressKeys("{TAB}");
                    }
                }
            }

            //Input Limits Reported Clear User
            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.GetAttributeValue<string>("Text") == "")
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.Element.SetAttributeValue("Text", authorityObject.copiedBy);
                Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.PressKeys("{TAB}");
            }

            GeneralUtilities.CheckWaitState(10);

            Report.Info("Voiding Authority");

            if (!CheckFeedback(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback, expectedFeedback))
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                return;
            }

            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.SelfInfo.Exists(0))
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.YesButton.Click();
                Report.Info("Acknowledging the Releaser Not Copier Popup");
            }

            if(!string.IsNullOrEmpty(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback.GetAttributeValue<string>("Text").ToString()))
            {
                GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButtonInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                return;
            }
            //Click on Clear button
            retries = 0;
            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButtonInfo.Exists(0))
            {
            	while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButton.Enabled && retries < 3)
            	{
            		Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.Click();
            		Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.PressKeys("{TAB}");
            		GeneralUtilities.CheckWaitState(10);
            	}
            	
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButton.Enabled)
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButton.Click();
                    Report.Info("Clicked Clear Button to Void Authority");
                } else {
                    Ranorex.Report.Failure("Clear Button was not enabled after inputting Limits Cleared By");
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                    return;
                }

                if (!CheckFeedback(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback, expectedFeedback))
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                    return;
                }
            } else if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AcceptButtonInfo.Exists(0))
            {
                while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.AcceptButton.Enabled && retries < 3) {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }

                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AcceptButton.Enabled)
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.AcceptButton.Click();
                    Report.Info("Clicked Accept Button to Void Authority");
                } else {
                    Ranorex.Report.Failure("Accept Button was not enabled after inputting Limits Cleared By");
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.AddCommentsButton.Click();
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.CommentText.Element.SetAttributeValue("Text", "Automation");
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.OkButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.SelfInfo);
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.DenyButton.Click();
                    return;
                }
            }


            retries = 0;
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.SelfInfo.Exists(0) && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            //Click on Yes Button if Notification is displayed
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.SelfInfo.Exists(0))
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.YesButton.Click();
                Report.Info("Acknowledging the Releaser Not Copier Popup");
            }


            retries = 0;
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            //Click on Yes Button if Notification is displayed
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.YesButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo);
                Report.Info("Acknowledging the Notification Popup");
            }

            //If form is PTC, handle here
            while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0) && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0))
            {
                if (issueAuthorityPTCVoice)
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButton.Click();
                } else {
                    Report.Success("Successfully Voided Authority.");
                    return;
                }
            } else if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0) && issueAuthorityPTCVoice)
            {
                Report.Failure("Expected PTC Voice Form but none appeared");
            }

            //Wait for Acknowledge Button to exist and click it
            if (pressAcknowledge)
            {
                retries = 0;
                while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0) && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }

                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0))
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                    Report.Info("Acknowledging the Void Authority request");
                } else {
                    Ranorex.Report.Failure("Acknowledge Form did not appear for Voiding");
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                    return;
                }

                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0))
                {
                    Ranorex.Report.Failure("Communication Exchnage Form for Track Authority Void did not disappear");
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                    Ranorex.Delay.Milliseconds(500);
                    //Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                    return;
                }
            }


            Report.Success("Successfully Voided Authority");

            if(closeForms){
                if (Authoritiesrepo.Track_Authority_Summary_List.SelfInfo.Exists(0))
                {
                    Authoritiesrepo.Track_Authority_Summary_List.WindowControls.Close.Click();
                }
            }

            return;
        }

        /// <summary>
        /// Removes all Authorities
        /// </summary>
        /// <param name="closeForms">Input:Closes the Track Authority Summary List Form</param>
        [UserCodeMethod]
        public static void NS_RemoveAllAuthorities(bool closeForms)
        {
            NS_OpenAuthoritySummaryList_MainMenu();

            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo,
                                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
            }

            if(Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,
                                                                  Authoritiesrepo.Create_Track_Authority.SelfInfo);
            }

            try
            {
                Authoritiesrepo.TrackAuthorityIndex = "0";
                Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.TrackAuthorityRowByRowIndex.SelfInfo.WaitForExists(5000);
            }
            catch (RanorexException)
            {
                Ranorex.Report.Screenshot(Authoritiesrepo.Track_Authority_Summary_List.Self);
                Ranorex.Report.Info("No Authorities were generated in summary list.");

                if (closeForms)
                {
                    Authoritiesrepo.Track_Authority_Summary_List.WindowControls.Close.Click();
                }
                return;
            }

            Ranorex.Delay.Seconds(2); //Ranorex seems to struggle getting the right number of rows

            int numberOfTrackAuthorities = Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.Self.Rows.Count;
            int authorityIndexCounter = 0;
            if(numberOfTrackAuthorities > 0)
            {
                authorityIndexCounter = numberOfTrackAuthorities - 1;
            }
            Authoritiesrepo.TrackAuthorityIndex = authorityIndexCounter.ToString();
            int taIndex = authorityIndexCounter;
            Authoritiesrepo.ColumnIndex = "0";
            string lastAuth = "";
            string currentAuth = "";
            int retries = 0;

            for (int i=authorityIndexCounter; i>=0; i--)
            {
                if(!Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.TrackAuthorityRowByRowIndex.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Track_Authority_Summary_List.Self);
                    Ranorex.Report.Info("No Authorities present in Summary List");

                    if (closeForms)
                    {
                        Authoritiesrepo.Track_Authority_Summary_List.WindowControls.Close.Click();
                    }
                    return;
                }
                currentAuth = Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.TrackAuthorityRowByRowIndex.CellByColumnIndex.Text;
                while (currentAuth.Equals(lastAuth) && retries < 3) //Same authority from last void exists
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                    currentAuth = Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.TrackAuthorityRowByRowIndex.CellByColumnIndex.Text;
                }
                if (currentAuth.Equals(lastAuth)) //If its still the same, unable to void, move to next authority
                {
                    taIndex--;
                    Authoritiesrepo.TrackAuthorityIndex = taIndex.ToString();

                    if(Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                          Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                    }
                }
                Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.TrackAuthorityRowByRowIndex.MenuCell.Click(WinForms.MouseButtons.Right);
                Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.MenuCellMenu.ViewTrackAuthority.Click();

                retries = 0;
                while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0) && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }
                if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
                {
                    Authoritiesrepo.TrackAuthorityIndex = (Convert.ToInt32(Authoritiesrepo.TrackAuthorityIndex) - 1).ToString();
                }
                //Check if the Joint Occupants Button is selectable and if so choose No
                if (Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.TrackAuthorityRowByRowIndex.CellByColumnName.Type.Text == "R/W")
                {
                    if (Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.GetAttributeValue<bool>("Enabled"))
                    {
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.Click();
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.No.Click();
                    }
                }

                //Fill Track Authority By
                Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.PressKeys("Automation");
                Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.PressKeys("{TAB}");

                //Press clear button to remove Authority
                GeneralUtilities.CheckWaitState(10);
                Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButton.Click();

                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.SelfInfo.Exists(0))
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.YesButton.Click();
                    retries = 0;
                    while (Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.SelfInfo.Exists(0) && retries < 3)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }
                    if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.SelfInfo.Exists(0))
                    {
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.YesButton.Click();
                    }
                }

                Delay.Milliseconds(500);
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists())
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.YesButton.Click();
                    retries = 0;
                    while (Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 3)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }
                    if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0))
                    {
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.YesButton.Click();
                    }
                }

                retries = 0;
                while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0) && retries < 2)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }

                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0))
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButton.Click();
                }

                //Press Acknowledge to confirm removal
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                //TODO Wait for authority to be removed from list, currently, tries to proceed too quickly
                lastAuth = currentAuth;

                if(Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                }

                if(Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,
                                                                      Authoritiesrepo.Create_Track_Authority.SelfInfo);
                }
                Authoritiesrepo.TrackAuthorityIndex = (i-1).ToString();
            }

            retries = 0;
            while (Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.Self.Rows.Count != 0 && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.Self.Rows.Count != 0)
            {
                Ranorex.Report.Error("Not all Track Authorities could be removed");
            }

            if (closeForms)
            {
                Authoritiesrepo.Track_Authority_Summary_List.WindowControls.Close.Click();
            }

            return;
        }

        /// <summary>
        /// Data driven form that appears after track authorities are given when trains are in the departure list and other locations other than the intended track authority limits.
        /// </summary>
        /// <param name="expected">do we expect the form to appear in the current flow?</param>
        /// <param name="confirmRequest">if it is expected, how do we handle the pop up? "True" to confirm to location, "False" to select don't track, any other input selects the cancel option. Not case-sensitive.</param>
        [UserCodeMethod]
        public static void NS_ConfirmTrackingRequest (bool expected, string confirmRequest)
        {
        	if (!expected && Authoritiesrepo.Confirm_Tracking_Request.SelfInfo.Exists(0))
        	{
        		Report.Failure("Confirm tracking Request pop up is unexpectedly present.");
        		Report.Screenshot();
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Confirm_Tracking_Request.CancelInfo, Authoritiesrepo.Confirm_Tracking_Request.SelfInfo);
        		return;
        	}
        	else if (!expected)
        		return;

        	//Currently, this method puts a bit more responsibility on the automation engineer for correct data input, if we had any performance requirements for how long it takes for the pop
        	//up to appear, this could be neater
        	try
        	{
        		Authoritiesrepo.Confirm_Tracking_Request.SelfInfo.WaitForExists(5000); //At worst, if it doesnt pop up right away and we're expecting it to, then wait
        	}
        	catch (RanorexException)
        	{
        			Report.Failure("Expected Confirm Tracking Request pop up but it did not appear.");
        			Report.Screenshot();
        			return;
        	}

        	if (confirmRequest.ToLower().Equals("true"))
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Confirm_Tracking_Request.TrackToAuthorityInfo, Authoritiesrepo.Confirm_Tracking_Request.SelfInfo);
    		else if (confirmRequest.ToLower().Equals("false"))
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Confirm_Tracking_Request.DontTrackInfo, Authoritiesrepo.Confirm_Tracking_Request.SelfInfo);
    		else
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Confirm_Tracking_Request.CancelInfo, Authoritiesrepo.Confirm_Tracking_Request.SelfInfo);
        }

        /// <summary>
        /// Open Authority remote request from task list
        /// </summary>
        /// <param name="optTrainSeed">Required only for TE authority</param>
        /// <param name="optEngineSeed">Required only for TE authority</param>
        /// <param name="type">TE,OT,RW</param>
        /// <param name="requestType">Issue,Extend,Rollup,Void values can be provided</param>
        /// <param name="employee_name">employee_name</param>
        /// <param name="expectTask">expect Task in task list</param>
        [UserCodeMethod]
        public static void NS_OpenAuthorityRemoteRequest_TaskList(string optTrainSeed, string optEngineSeed, string type, string requestType, string employee_name, bool expectTask)
        {
            string description = "";
            requestType = requestType.ToLower();
            int retries = 0;

            while(!Authoritiesrepo.Remote_Track_Authority_Request.SelfInfo.Exists(0) && retries < 5)
            {
                Ranorex.Delay.Milliseconds(1000);
                retries++;
            }
            if (type.Equals("TE"))
            {
                if (string.IsNullOrEmpty(optTrainSeed) | string.IsNullOrEmpty(optEngineSeed))
                {
                    Ranorex.Report.Error("Train seed or engine seed not provided for TE Authority.");
                    return;
                }

                switch(requestType)
                {
                    case "issue":
                        description = "T/E issue request received from";
                        break;
                    case "extend":
                        description = "T/E extend request received from";
                        break;
                    case "void":
                        description = "T/E void request received from";
                        break;
                    case "rollup":
                        description = "T/E rollup request received from";
                        break;
                    default:
                        Ranorex.Report.Error("Invalid Request Type Received");
                        break;
                }

                string engineId = NS_TrainID.GetEngineInitial(optTrainSeed, optEngineSeed) + " " + NS_TrainID.GetEngineNumber(optTrainSeed, optEngineSeed);
                string employeeId = "";

                employeeId = NS_TrainID.GetTrainId(optTrainSeed) + " (" + engineId + ")";
                NS_Miscellaneous.NS_OpenTaskByDescriptionAndEmployeeName(description, employeeId, expectTask);
            }
            else if (type.Equals("OT"))
            {
                switch(requestType)
                {
                    case "issue":
                        description = "O/T issue request received from";
                        break;
                    case "extend":
                        description = "O/T extend request received from";
                        break;
                    case "void":
                        description = "O/T void request received from";
                        break;
                    default:
                        Ranorex.Report.Error("Invalid Request Type Received: "+requestType);
                        break;
                }
                NS_Miscellaneous.NS_OpenTaskByDescriptionAndEmployeeName(description, employee_name, expectTask);
            }
            else if (type.Equals("RW"))
            {
                switch(requestType)
                {
                    case "issue":
                        description = "R/W issue request received from";
                        break;
                    case "extend":
                        description = "R/W extend request received from";
                        break;
                    case "rollup":
                        description = "R/W rollup request received from";
                        break;
                    case "void":
                        description = "R/W void request received from";
                        break;
                    default:
                        Ranorex.Report.Error("Invalid Request Type Received: "+requestType);
                        break;
                }

                NS_Miscellaneous.NS_OpenTaskByDescriptionAndEmployeeName(description, employee_name, expectTask);
            }
            else{
            	Ranorex.Report.Error("Invalid Authority type specified. Please verify!!");
            }
        }


        /// <summary>
        /// Complete Granting or Denying a Authority recived via RUM
        /// </summary>
        /// <param name="authoritySeed">Input: authoritySeed value to be sent only if user wants to Accept the Authority, Else can be blank</param>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        /// <param name="closeAuthorityForm">Input:Closes the Authority Form</param>
        [UserCodeMethod]
        public static void NS_GrantOrDenyRUMAuthority(string authoritySeed, string box8EngineSeed1,string box8Engine1Direction, string box8EngineSeed2,
                                                      string box8Engine2Direction,string box8EngineSeed3,string box8Engine3Direction,string box10Between1,
                                                      string box10Between2,string box11StopShort,string box11Track, string commentsText, bool grantAuthority, bool closeForms,
                                                      string expectedFeedback, bool closeAuthorityForm, string optexpectedFeedback)
        {

            int retries = 0;
            bool success = true;
            Authoritiesrepo.Create_Track_Authority.Self.Activate();

            //Click on Yes Button if Notification is displayed
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.YesButtonInfo,
                                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo);
                Report.Info("Acknowledging the Notification Popup");
            }

            if(Authoritiesrepo.Create_Track_Authority.RibbonMenu.Suspend.Visible)
            {
                Ranorex.Report.Error("Suspend Button is Enabled");
            }
            else
            {
                Ranorex.Report.Info("Suspend Button is Disabled");
            }

            if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback))
            {
            	Ranorex.Report.Failure("Received Feedback message not mached as expected message.");
            }
            else
            {
            	GeneralUtilities.CheckWaitState(10);
            	Ranorex.Report.Success("Received Feedback message: "+Authoritiesrepo.Create_Track_Authority.Feedback.GetAttributeValue<string>("Text").ToString());
            	Ranorex.Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Self);
            	if(closeAuthorityForm)
            	{
            		if(Authoritiesrepo.Create_Track_Authority.RibbonMenu.LongForm.Enabled)
            		{
            			GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Authoritiesrepo.Create_Track_Authority.RibbonMenu.LongFormInfo,
            			                                                      Authoritiesrepo.Create_Track_Authority.RibbonMenu.LongFormInfo);
            			if(!Authoritiesrepo.Create_Track_Authority.Box12.Box12Checkbox.Enabled)
            			{
            				Ranorex.Report.Success("Box 12 checkbox is Disabled");
            			}
            			else
            			{
            				Ranorex.Report.Error("Box 12 checkbox is Enabled");
            			}
            		}
            		Ranorex.Report.Info("Denying Autority by closing the Form");
            		GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Create_Track_Authority.WindowControls.CloseInfo,
            		                                          Authoritiesrepo.Please_Confirm_PopUp.SelfInfo);
            		if (!Authoritiesrepo.Please_Confirm_PopUp.SelfInfo.Exists(0))
            		{
            			Ranorex.Report.Error("Could not find Please confirm Form");
            			return;
            		}
            		else
            		{
            			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Please_Confirm_PopUp.YesButtonInfo,
            			                                                                      Authoritiesrepo.Create_Track_Authority.SelfInfo);
            		}
            		return;
            	}
            }


            if (grantAuthority)
            {
                Ranorex.Report.Info("Granting Authority");

                success = NS_FillBox8(box8EngineSeed1, box8Engine1Direction, box8EngineSeed2, box8Engine2Direction, box8EngineSeed3, box8Engine3Direction, expectedFeedback);
                if (!success)
                {
                    CheckFeedback(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback);
                    Authoritiesrepo.Create_Track_Authority.AddCommentsButton.Click();
                    Authoritiesrepo.Create_Track_Authority.Enter_Comments.CommentText.Element.SetAttributeValue("Text", commentsText);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Enter_Comments.OkButtonInfo,
                                                                      Authoritiesrepo.Create_Track_Authority.Enter_Comments.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.DenyButtonInfo,
                                                                      Authoritiesrepo.Create_Track_Authority.SelfInfo);
                    return;
                }

                //Perform Box10
                success = NS_FillBox10(box10Between1, box10Between2, expectedFeedback);
                if (!success)
                {
                    CheckFeedback(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback);

                    Authoritiesrepo.Create_Track_Authority.AddCommentsButton.Click();
                    Authoritiesrepo.Create_Track_Authority.Enter_Comments.CommentText.Element.SetAttributeValue("Text", commentsText);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Enter_Comments.OkButtonInfo,
                                                                      Authoritiesrepo.Create_Track_Authority.Enter_Comments.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.DenyButtonInfo,
                                                                      Authoritiesrepo.Create_Track_Authority.SelfInfo);
                    return;
                }

                //Perform Box11
                success = NS_FillBox11(box11StopShort, box11Track);
                if (!success)
                {
                    CheckFeedback(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback);

                    Authoritiesrepo.Create_Track_Authority.AddCommentsButton.Click();
                    Authoritiesrepo.Create_Track_Authority.Enter_Comments.CommentText.Element.SetAttributeValue("Text", commentsText);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Enter_Comments.OkButtonInfo,
                                                                      Authoritiesrepo.Create_Track_Authority.Enter_Comments.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.DenyButtonInfo,
                                                                      Authoritiesrepo.Create_Track_Authority.SelfInfo);
                    return;
                }

                AddAuthorityObjectFromOpenAuthority(authoritySeed);

                Ranorex.Report.Info("Select Joint Occupancy if blank");
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsTextInfo.Exists(0) && Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.Enabled)
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.Click();
                    GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsTextInfo,
                                                              Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.YesInfo);
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.Yes.Click();
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.PressKeys("{TAB}");
                }

                Authoritiesrepo.Create_Track_Authority.AcceptButton.Click();


                //GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Create_Track_Authority.AcceptButtonInfo,
                //																				 Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                while(Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0) && retries < 5)
                {
                	Delay.Milliseconds(500);
                	retries++;
                }

                if(Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
                {
                	if(!CheckFeedback(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback))
                	{
                		Authoritiesrepo.Create_Track_Authority.AddCommentsButton.Click();
                		Authoritiesrepo.Create_Track_Authority.Enter_Comments.CommentText.Element.SetAttributeValue("Text", commentsText);
                		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Enter_Comments.OkButtonInfo,
                		                                                  Authoritiesrepo.Create_Track_Authority.Enter_Comments.SelfInfo);
                		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.DenyButtonInfo,
                		                                                  Authoritiesrepo.Create_Track_Authority.SelfInfo);
                		return;
                	}
                }

                retries = 0;

                while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 2)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }

                //Click on Yes Button if Notification is displayed
                if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.YesButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo);
                    Report.Info("Acknowledging the Notification Popup");
                }

                AddAuthorityNumber(authoritySeed);
                AddAuthorityCopiedBy(authoritySeed);

                string trackAuthorityUniqueIdStatus = CDMSEnvironment.GetCommonConfigValue_CDMS("RUM_TA_UID_ENABLE");
                AuthorityObject authorityObj = NS_Authorities.GetAuthorityObject(authoritySeed);
                if(trackAuthorityUniqueIdStatus == "1" || trackAuthorityUniqueIdStatus == "2")
                {
                	AddAuthorityId(authoritySeed);
                	if (!authorityObj.box1TrackAuthorityNumber.Equals(""))
                	{
                		Addbox1TrackAuthorityId(authoritySeed, authorityObj.box1TrackAuthorityNumber);
                	}
                }

                AuthorityObject currentObject = authorityDictionary[authoritySeed];
                if(currentObject.trackAuthorityType == "RW")
                {
                    if(Authoritiesrepo.Communications_Exchange_Ok_Authority.RibbonMenu.Suspend.Visible)
                    {
                        Ranorex.Report.Error("Suspend Button is Enabled");
                    }
                    else
                    {
                        Ranorex.Report.Info("Suspend Button is Disabled");
                    }
                }

            } else {
            	//Check if there is already a comment, due to one being required to deny
            	//                GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Create_Track_Authority.AddCommentsButtonInfo, Authoritiesrepo.Create_Track_Authority.Enter_Comments.OkButtonInfo);
            	//                string popupCommentText = Authoritiesrepo.Create_Track_Authority.Enter_Comments.CommentText.TextValue;
            	//                if (popupCommentText != "")
            	//                {
            	//                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Enter_Comments.OkButtonInfo, Authoritiesrepo.Create_Track_Authority.Enter_Comments.SelfInfo);
            	//                }
            	//                else if(commentsText!="")
            	//                {
            	//                    Authoritiesrepo.Create_Track_Authority.Enter_Comments.CommentText.Element.SetAttributeValue("Text", commentsText);
            	//                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Enter_Comments.OkButtonInfo, Authoritiesrepo.Create_Track_Authority.Enter_Comments.SelfInfo);
            	//                }
            	//                else
            	//                {
            	//                    Authoritiesrepo.Create_Track_Authority.Enter_Comments.CommentText.Element.SetAttributeValue("Text", "Automation");
            	//                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Enter_Comments.OkButtonInfo, Authoritiesrepo.Create_Track_Authority.Enter_Comments.SelfInfo);
            	//                }
            	//                Ranorex.Report.Info("Denying Authority");
            	//                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.DenyButtonInfo, Authoritiesrepo.Create_Track_Authority.SelfInfo);

        		if(!string.IsNullOrEmpty(commentsText))
        		{
    				GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Create_Track_Authority.AddCommentsButtonInfo,
    				                                          Authoritiesrepo.Create_Track_Authority.Enter_Comments.CommentTextInfo);
    				Authoritiesrepo.Create_Track_Authority.Enter_Comments.CommentText.Element.SetAttributeValue("Text", commentsText);
    				Authoritiesrepo.Create_Track_Authority.Enter_Comments.OkButton.Click();
    				retries = 0;
    				while (!Authoritiesrepo.Create_Track_Authority.Enter_Comments.SelfInfo.Exists(0) && retries < 2)
    				{
    				    Ranorex.Delay.Milliseconds(500);
    				    retries++;
    				}
    				if (Authoritiesrepo.Create_Track_Authority.Enter_Comments.SelfInfo.Exists(0))
    				{
        				if(!string.IsNullOrEmpty(optexpectedFeedback))
        				{
        					if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Enter_Comments.Feedback, optexpectedFeedback))
        					{
        						Ranorex.Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Enter_Comments.Self);
        						Ranorex.Report.Failure("Received Feedback message of {"+Authoritiesrepo.Create_Track_Authority.Enter_Comments.Feedback.GetAttributeValue<string>("Text") + "}, expected {" + optexpectedFeedback + "}.");
        					}
        					else
        					{
        						Ranorex.Report.Success("Received Feedback message: {"+Authoritiesrepo.Create_Track_Authority.Enter_Comments.Feedback.GetAttributeValue<string>("Text") + "}, expected {" + optexpectedFeedback + "}.");
        					}
        				} else {
        				    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Enter_Comments.OkButtonInfo,
        				                                          Authoritiesrepo.Create_Track_Authority.Enter_Comments.SelfInfo);
        				}
        				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Enter_Comments.CancelButtonInfo,
        				                                                 Authoritiesrepo.Create_Track_Authority.Enter_Comments.SelfInfo);
        				return;
    				}
        		}
            }
            if(Authoritiesrepo.Create_Track_Authority.DenyButtonInfo.Exists(0))
            {
            	Ranorex.Report.Info("Denying Authority");
            	Authoritiesrepo.Create_Track_Authority.DenyButton.Click();
            }
            retries = 0;
            while(Authoritiesrepo.Create_Track_Authority.FeedbackInfo.Exists(0) && retries < 3)
            {
            	Delay.Milliseconds(500);
            	retries++;
            }
            if (Authoritiesrepo.Create_Track_Authority.FeedbackInfo.Exists(0) && expectedFeedback != "")
            {
	            string actualFeedback = Authoritiesrepo.Create_Track_Authority.Feedback.GetAttributeValue<string>("Text");
	            if(!string.IsNullOrEmpty(expectedFeedback) && !string.IsNullOrEmpty(actualFeedback))
	            {
	            	if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback))
	            	{
	            		Ranorex.Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Self);
	            		Ranorex.Report.Failure("Received Feedback message of {"+actualFeedback+ "}, expected {" + expectedFeedback + "}.");
	            	}
	            	else
	            	{
	            		Ranorex.Report.Success("Received Feedback message: {"+actualFeedback+ "}, expected {" + expectedFeedback + "}.");
	            	}
	            }
            }

            if (closeForms)
            {
            	Ranorex.Report.Info("Closing Task List Form");
            	if(Miscellaneousrepo.Task_List.SelfInfo.Exists(0))
            	{
            		Miscellaneousrepo.Task_List.CloseButton.Click();
            	}
            }
            return;
        }

        /// <summary>
        /// Makes a basic Line 2 TE Authority, only basic feedback validations
        /// </summary>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        [UserCodeMethod]
        public static void NS_IssueTEProceedAuthorityBasic(string trainSeed, string engineSeed, string at, string box2ProceedFrom, bool box2Fsw, string box2To1, string box2Track1, string box2To1HoldClearMain, string box2To2, string box2Track2, string box2To2HoldClearMain, string box2To3, string box2Track3, string box2To3HoldClearMain, string newAuthoritySeed = "MostRecent")
        {
            NS_OpenTETrackAuthorityForm_MainMenu();
            NS_FillTrackAuthorityHeader("TE", trainSeed, engineSeed, "", "", at, "");
            NS_FillBox2(box2ProceedFrom, box2Fsw, box2To1, box2Track1, box2To1HoldClearMain, box2To2, box2Track2, box2To2HoldClearMain,
                        box2To3, box2Track3, box2To3HoldClearMain);

            AddAuthorityObjectFromOpenAuthority(newAuthoritySeed);

            Authoritiesrepo.Create_Track_Authority.IssueButton.Click();

            //Make sure the form closes, or if it's not supposed to close that we check the feedback for expected results.
            int retries = 0;
            while (Authoritiesrepo.Create_Track_Authority.IssueButtonInfo.Exists(0) && retries < 4)
            {
                if (retries == 2)
                {
                    Authoritiesrepo.Create_Track_Authority.IssueButton.Click();
                }
                Ranorex.Delay.Seconds(1);
                retries++;
            }

            if (Authoritiesrepo.Create_Track_Authority.IssueButtonInfo.Exists(0))
            {
                if (!CheckFeedback(Authoritiesrepo.Create_Track_Authority.Feedback, ""))
                {
                    Authoritiesrepo.Create_Track_Authority.CancelButton.Click();
                    return;
                } else {
                    Ranorex.Report.Failure("Track Authority Failed to Issue.");
                    Authoritiesrepo.Create_Track_Authority.CancelButton.Click();
                    return;
                }
            }

            CompleteAuthorityIssue(newAuthoritySeed, "Automation", "", "", true);
            return;

//				NS_IssueTEAuthority("TE", trainSeed, engineSeed, at, "", false, box2ProceedFrom, box2Fsw, box2To1, box2Track1,
//																						 box2To1HoldClearMain, box2To2, box2Track2, box2To2HoldClearMain, box2To3, box2Track3,
//																						 box2To3HoldClearMain, false, "", false, "", false, "", "", "", "", "", false, "", false, "",
//																						 "", "", "", "", "", "", "", "", false, "", false, "", "", "", false, false, false, "", "", "",
//																						 false, false, false, "", "", false, "", "", false, "", "",
//																						 "", "", string box12RWIC2, string box12Between2,
//																						 string box12And2, string box12Track2, string box12RWIC3, string box12Between3,
//																						 string box12And3, string box12Track3, bool box12Validate, string box13SubdivideLimits,
//																						 string box13AutomaticInstructions, string box13ManualInstructions, bool box13Validate,
//																						 bool issueAuthority, string issueAuthorityCopiedBy, string issueAuthorityRelayingEmployee,
//																						 string issueAuthorityAt, bool issueAuthorityPTCVoice, string expectedFeedback
//				NS_OpenTETrackAuthorityForm_MainMenu();
//
//				string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
//				if (trainId == null)
//				{
//					Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
//					return;
//				}
//
//				Authoritiesrepo.Create_Track_Authority.TrainID.FindTrainButton.Click();
//				Authoritiesrepo.Create_Track_Authority.TrainID.Find_Train.TrainIDText.Click();
//				Authoritiesrepo.Create_Track_Authority.TrainID.Find_Train.TrainIDText.Element.SetAttributeValue("Text", trainId);
//				Authoritiesrepo.Create_Track_Authority.TrainID.Find_Train.OkButton.Click();
//
//				string engineId = "";
//				var engineObject = PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(trainSeed, engineSeed);
//				if (engineObject != null)
//				{
//					if (engineObject.EngineInitial != "" && engineObject.EngineNumber != "")
//					{
//						engineId = engineObject.EngineInitial + " " + engineObject.EngineNumber;
//					}
//				}
//
//				if (engineId == "")
//				{
//					Authoritiesrepo.EngineIdIndex = "0";
//					Authoritiesrepo.Create_Track_Authority.To.EngineToMenuButton.Click();
//					if (!Authoritiesrepo.Create_Track_Authority.To.EngineToMenuList.EngineIdListItemByIndexInfo.Exists(0))
//					{
//						Ranorex.Report.Error("No Engine for train {"+trainId+"} to assign Track Authority to");
//						Authoritiesrepo.Create_Track_Authority.CancelButton.Click();
//						return;
//					}
//					Authoritiesrepo.Create_Track_Authority.To.EngineToMenuList.EngineIdListItemByIndex.Click();
//				} else {
//					Authoritiesrepo.EngineId = engineId;
//					Authoritiesrepo.Create_Track_Authority.To.EngineToMenuButton.Click();
//					if (!Authoritiesrepo.Create_Track_Authority.To.EngineToMenuList.EngineIdListItemByEngineIdInfo.Exists(0))
//					{
//						Authoritiesrepo.EngineIdIndex = "0";
//						if (!Authoritiesrepo.Create_Track_Authority.To.EngineToMenuList.EngineIdListItemByIndexInfo.Exists(0))
//						{
//							Ranorex.Report.Error("Engine Id {"+engineId+"} not found for train {"+trainId+"} to assign Track Authority to");
//							Authoritiesrepo.Create_Track_Authority.CancelButton.Click();
//							return;
//						}
//						Authoritiesrepo.Create_Track_Authority.To.EngineToMenuList.EngineIdListItemByIndex.Click();
//					} else {
//						Authoritiesrepo.Create_Track_Authority.To.EngineToMenuList.EngineIdListItemByIndex.Click();
//					}
//				}
//
//				Authoritiesrepo.Create_Track_Authority.At.AtText.Click();
//				Authoritiesrepo.Create_Track_Authority.At.AtText.Element.SetAttributeValue("Text", at);
//				Authoritiesrepo.Create_Track_Authority.At.AtText.PressKeys("{TAB}");
//
//				string feedback = Authoritiesrepo.Create_Track_Authority.Feedback.GetAttributeValue<string>("Text");
//				if (!(feedback == "" || feedback == " "))
//				{
//					Ranorex.Report.Failure("Feedback received {"+feedback+"}");
//					Authoritiesrepo.Create_Track_Authority.CancelButton.Click();
//					return;
//				}
//
//
//				Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Between.Click();
//				Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Between.Element.SetAttributeValue("Text", from);
//				Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Between.PressKeys("{TAB}");
//
//				feedback = Authoritiesrepo.Create_Track_Authority.Feedback.GetAttributeValue<string>("Text");
//				if (!(feedback == "" || feedback == " "))
//				{
//					Ranorex.Report.Failure("Feedback received {"+feedback+"}");
//					Authoritiesrepo.Create_Track_Authority.CancelButton.Click();
//					return;
//				}
//
//
//				Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1To1.Click();
//				Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1To1.Element.SetAttributeValue("Text", to);
//				Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1To1.PressKeys("{TAB}");
//
//				feedback = Authoritiesrepo.Create_Track_Authority.Feedback.GetAttributeValue<string>("Text");
//				if (!(feedback == "" || feedback == " "))
//				{
//					Ranorex.Report.Failure("Feedback received {"+feedback+"}");
//					Authoritiesrepo.Create_Track_Authority.CancelButton.Click();
//					return;
//				}
//
//
//				if (Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Track1.Enabled)
//				{
//					Authoritiesrepo.Track = track;
//					Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Track1.Click();
//					Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Track1.Element.SetAttributeValue("Text", track);
//					Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Track1.PressKeys("{TAB}");
//
//					feedback = Authoritiesrepo.Create_Track_Authority.Feedback.GetAttributeValue<string>("Text");
//					if (!(feedback == "" || feedback == " "))
//					{
//						Ranorex.Report.Failure("Feedback received {"+feedback+"}");
//						Authoritiesrepo.Create_Track_Authority.CancelButton.Click();
//						return;
//					}
//				}
//
//				if (Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.SelfInfo.Exists(0))
//				{
//					switch(holdClearMain)
//					{
//						case "Clear":
//							Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.ClearMainButton.Click();
//							break;
//						case "Cancel":
//							Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.CancelButton.Click();
//							break;
//						case "Neither":
//							Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.NeitherButton.Click();
//							break;
//						default:
//							Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.HoldMainButton.Click();
//							break;
//					}
//				}
//
//				if (fsw)
//				{
//					if (!Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.FSWToCheckbox.Enabled && !Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.FSWToCheckbox.Checked)
//					{
//						Ranorex.Report.Failure("Unable to select fsw checkbox");
//						Authoritiesrepo.Create_Track_Authority.CancelButton.Click();
//						return;
//					} else {
//						Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.FSWToCheckbox.Click();
//					}
//				}
//
//				if (to2 != "")
//				{
//
//					Authoritiesrepo.Create_Track_Authority.Box2.Proceed2.Proceed1To2.Click();
//					Authoritiesrepo.Create_Track_Authority.Box2.Proceed2.Proceed1To2.Element.SetAttributeValue("Text", to2);
//					Authoritiesrepo.Create_Track_Authority.Box2.Proceed2.Proceed1To2.PressKeys("{TAB}");
//
//					feedback = Authoritiesrepo.Create_Track_Authority.Feedback.GetAttributeValue<string>("Text");
//					if (!(feedback == "" || feedback == " "))
//					{
//						Ranorex.Report.Failure("Feedback received {"+feedback+"}");
//						Authoritiesrepo.Create_Track_Authority.CancelButton.Click();
//						return;
//					}
//
//
//					if (Authoritiesrepo.Create_Track_Authority.Box2.Proceed2.Proceed1Track2.Enabled)
//					{
//						Authoritiesrepo.Track = track;
//						Authoritiesrepo.Create_Track_Authority.Box2.Proceed2.Proceed1Track2.Click();
//						Authoritiesrepo.Create_Track_Authority.Box2.Proceed2.Proceed1Track2.Element.SetAttributeValue("Text", track2);
//						Authoritiesrepo.Create_Track_Authority.Box2.Proceed2.Proceed1Track2.PressKeys("{TAB}");
//
//						feedback = Authoritiesrepo.Create_Track_Authority.Feedback.GetAttributeValue<string>("Text");
//						if (!(feedback == "" || feedback == " "))
//						{
//							Ranorex.Report.Failure("Feedback received {"+feedback+"}");
//							Authoritiesrepo.Create_Track_Authority.CancelButton.Click();
//							return;
//						}
//					}
//
//					if (Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.SelfInfo.Exists(0))
//					{
//						switch(holdClearMain)
//						{
//							case "Clear":
//								Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.ClearMainButton.Click();
//								break;
//							case "Cancel":
//								Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.CancelButton.Click();
//								break;
//							case "Neither":
//								Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.NeitherButton.Click();
//								break;
//							default:
//								Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.HoldMainButton.Click();
//								break;
//						}
//					}
//				}
//
//				if (to3 != "")
//				{
//
//					Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1To3.Click();
//					Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1To3.Element.SetAttributeValue("Text", to3);
//					Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1To3.PressKeys("{TAB}");
//
//					feedback = Authoritiesrepo.Create_Track_Authority.Feedback.GetAttributeValue<string>("Text");
//					if (!(feedback == "" || feedback == " "))
//					{
//						Ranorex.Report.Failure("Feedback received {"+feedback+"}");
//						Authoritiesrepo.Create_Track_Authority.CancelButton.Click();
//						return;
//					}
//
//
//					if (Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1Track3.Enabled)
//					{
//						Authoritiesrepo.Track = track;
//						Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1Track3.Click();
//						Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1Track3.Element.SetAttributeValue("Text", track3);
//						Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1Track3.PressKeys("{TAB}");
//
//						feedback = Authoritiesrepo.Create_Track_Authority.Feedback.GetAttributeValue<string>("Text");
//						if (!(feedback == "" || feedback == " "))
//						{
//							Ranorex.Report.Failure("Feedback received {"+feedback+"}");
//							Authoritiesrepo.Create_Track_Authority.CancelButton.Click();
//							return;
//						}
//					}
//
//					if (Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.SelfInfo.Exists(0))
//					{
//						switch(holdClearMain)
//						{
//							case "Clear":
//								Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.ClearMainButton.Click();
//								break;
//							case "Cancel":
//								Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.CancelButton.Click();
//								break;
//							case "Neither":
//								Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.NeitherButton.Click();
//								break;
//							default:
//								Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.HoldMainButton.Click();
//								break;
//						}
//					}
//				}
//
//				Authoritiesrepo.Create_Track_Authority.IssueButton.Click();
//
//				Authoritiesrepo.Communications_Exchange_Ok_Authority.CopiedByText.Click();
//				Authoritiesrepo.Communications_Exchange_Ok_Authority.CopiedByText.Element.SetAttributeValue("Text", "Automation");
//				Authoritiesrepo.Communications_Exchange_Ok_Authority.CopiedByText.PressKeys("{TAB}");
//				Authoritiesrepo.Communications_Exchange_Ok_Authority.ContinueButton.Click();
//
//				int retries = 0;
//				while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0) && retries < 3)
//				{
//					Ranorex.Delay.Milliseconds(500);
//					retries++;
//				}
//
//				if (Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0))
//				{
//					Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButton.Click();
//				}
//
//				Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButton.Click();
//				return;
        }


        /// <summary>
        /// Issues and validates any TE Authority
        /// </summary>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        [UserCodeMethod]
        public static bool NS_FillBox1(string box1TrackAuthorityNumber)
        {
            if (box1TrackAuthorityNumber == "")
            {
                return true;
            }

            string voidAuthorityNumber = NS_Authorities.GetAuthorityNumber(box1TrackAuthorityNumber);
            Report.Info("Entering Authority Number: "+voidAuthorityNumber);
            GeneralUtilities.CheckWaitState(10);
            Authoritiesrepo.Create_Track_Authority.Box1.VoidTrackAuthorityNumberText.Click();
            Authoritiesrepo.Create_Track_Authority.Box1.VoidTrackAuthorityNumberText.Element.SetAttributeValue("Text", voidAuthorityNumber);
            Authoritiesrepo.Create_Track_Authority.Box1.VoidTrackAuthorityNumberText.PressKeys("{TAB}");

            string acceptableFeedback = "";
            if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
            {
                return false;
            }
            return true;
        }

        [UserCodeMethod]
        public static void NotificationDialog (string text, string action)
        {
        	int retries = 0;
        	while (!Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 5)
        	{
        		Delay.Milliseconds(500);
        		retries++;
        	}
        	if (Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0))
        	{
        		if (!Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.TextWithAuthority.TextValue.Contains(text))
        		{
        			Report.Screenshot();
        			Report.Failure("Unexpected Notification form has appeared. Found: " + Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.TextWithAuthority.TextValue);
        		}

        		action = action.ToLower();
        		if (action.Equals("yes"))
    		    {
    		    	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButtonInfo, Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);
        			return;
        		}

        		//TODO I guess we could put something here for No and then if neither hit the x to close out but the result is same as no in all cases ive seen so far
		    	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.NoButtonInfo, Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);
				return;
        	}
        	Report.Failure("Anticipated Notification dailog did not appear.");
        	Report.Screenshot();
        }
        [UserCodeMethod]
        public static void ClearHoldMainDialog  (bool clearMain, bool holdMain)
        {
        	if (clearMain && !holdMain)
        		ClearHoldMainDialog("Clear");
        	else if (!clearMain && holdMain)
        		ClearHoldMainDialog("default"); //will click hold main
        	else if (!clearMain && !holdMain)
        		ClearHoldMainDialog("Neither");
        	else
        		ClearHoldMainDialog("Cancel"); //Automation user input error
        }
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static void ClearHoldMainDialog(string box2To1HoldClearMain)
        {
        	if (Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.SelfInfo.Exists(0))
            {
                switch(box2To1HoldClearMain)
                {
                    case "Clear":
                		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.ClearMainButtonInfo, Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.SelfInfo);
                        break;
                    case "Cancel":
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.CancelButtonInfo, Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.SelfInfo);
                        break;
                    case "Neither":
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.NeitherButtonInfo, Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.SelfInfo);
                        break;
                    default:
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.HoldMainButtonInfo, Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.SelfInfo);
                        break;
                }
            }

        }
        /// <summary>
        /// Issues and validates any TE Authority
        /// </summary>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        [UserCodeMethod]
        public static bool NS_FillBox2(string box2ProceedFrom, bool box2Fsw, string box2To1, string box2Track1, string box2To1HoldClearMain,
                                       string box2To2, string box2Track2, string box2To2HoldClearMain, string box2To3, string box2Track3,
                                       string box2To3HoldClearMain)
        {
            if (box2ProceedFrom == "" && box2To1 == "")
            {
                return true;
            }
			
            GeneralUtilities.CheckWaitState(10);
            if(Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Between.GetAttributeValue<string>("Text").Equals(box2ProceedFrom, StringComparison.OrdinalIgnoreCase))
            {
                Ranorex.Report.Success("Proceed1Between value is already pre-selected");
            }
            else
            {
                Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Between.Click();
                Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Between.Element.SetAttributeValue("Text", box2ProceedFrom);
                Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Between.PressKeys("{TAB}");
            }

            string acceptableFeedback = "";
            if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
            {
                return false;
            }


            if (box2Fsw)
            {
                if (!Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.FSWToCheckbox.Enabled && !Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.FSWToCheckbox.Checked)
                {
                    Ranorex.Report.Failure("Unable to select fsw checkbox");

                    return false;
                } else {
                    Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.FSWToCheckbox.PressKeys("{SPACE}");
                }
            }
            Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.FSWToCheckbox.PressKeys("{TAB}");

			GeneralUtilities.CheckWaitState(10);
            if(Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1To1.GetAttributeValue<string>("Text").Equals(box2To1, StringComparison.OrdinalIgnoreCase))
            {
                Ranorex.Report.Success("Proceed1To1 value is already pre-selected");
            }
            else
            {
                Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1To1.Click();
                Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1To1.Element.SetAttributeValue("Text", box2To1);
                Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1To1.PressKeys("{TAB}");
            }


            if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
            {
                return false;
            }
			GeneralUtilities.CheckWaitState(10);
            if (Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Track1.Enabled)
            {
                Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Track1.Click();
                Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Track1.Element.SetAttributeValue("Text", box2Track1);
                Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Track1.PressKeys("{TAB}");

                if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
                {
                    return false;
                }
            } else {
                string box2Track1Text = Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Track1.SelectedItemText;
                if (box2Track1Text != box2Track1 && box2Track1 != "")
                {
                    Ranorex.Report.Failure("Track could not be changed from {"+box2Track1Text+"} expected to be {"+box2Track1+"}.");
                    return false;
                }
            }

            ClearHoldMainDialog(box2To1HoldClearMain);
            
            if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0))// && Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.TextWithAuthority.TextValue.Contains("O/T"))
            {
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButtonInfo,
            	                                                 Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);
            }

            Authoritiesrepo.Create_Track_Authority.Box2.Proceed2.Proceed1To2.Click();
            Authoritiesrepo.Create_Track_Authority.Box2.Proceed2.Proceed1To2.Element.SetAttributeValue("Text", box2To2);
            Authoritiesrepo.Create_Track_Authority.Box2.Proceed2.Proceed1To2.PressKeys("{TAB}");

            if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
            {
                return false;
            }

            if (Authoritiesrepo.Create_Track_Authority.Box2.Proceed2.Proceed1Track2.Enabled)
            {
                Authoritiesrepo.Create_Track_Authority.Box2.Proceed2.Proceed1Track2.Click();
                Authoritiesrepo.Create_Track_Authority.Box2.Proceed2.Proceed1Track2.Element.SetAttributeValue("Text", box2Track2);
                Authoritiesrepo.Create_Track_Authority.Box2.Proceed2.Proceed1Track2.PressKeys("{TAB}");

                if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
                {
                    return false;
                }
            } else {
                string box2Track2Text = Authoritiesrepo.Create_Track_Authority.Box2.Proceed2.Proceed1Track2.SelectedItemText;
                if (box2Track2Text != box2Track2 && box2Track2 != "")
                {
                    Ranorex.Report.Failure("Track could not be changed from {"+box2Track2Text+"} expected to be {"+box2Track2+"}.");
                    return false;
                }
            }

            if (Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.SelfInfo.Exists(0))
            {
                switch(box2To2HoldClearMain)
                {
                    case "Clear":
                        Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.ClearMainButton.Click();
                        break;
                    case "Cancel":
                        Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.CancelButton.Click();
                        break;
                    case "Neither":
                        Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.NeitherButton.Click();
                        break;
                    default:
                        Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.HoldMainButton.Click();
                        break;
                }
            }

            if (Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1To3.Enabled)
            {
                Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1To3.Click();
                Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1To3.Element.SetAttributeValue("Text", box2To3);
                Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1To3.PressKeys("{TAB}");

                if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
                {
                    return false;
                }


                if (Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1Track3.Enabled)
                {
                    Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1Track3.Click();
                    Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1Track3.Element.SetAttributeValue("Text", box2Track3);
                    Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1Track3.PressKeys("{TAB}");

                    if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
                    {
                        return false;
                    }
                } else {
                    string box2Track3Text = Authoritiesrepo.Create_Track_Authority.Box2.Proceed3.Proceed1Track3.SelectedItemText;
                    if (box2Track3Text != box2Track3 && box2Track3 != "")
                    {
                        Ranorex.Report.Failure("Track could not be changed from {"+box2Track3Text+"} expected to be {"+box2Track3+"}.");
                        return false;
                    }
                }

                if (Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.SelfInfo.Exists(0))
                {
                    switch(box2To3HoldClearMain)
                    {
                        case "Clear":
                            Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.ClearMainButton.Click();
                            break;
                        case "Cancel":
                            Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.CancelButton.Click();
                            break;
                        case "Neither":
                            Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.NeitherButton.Click();
                            break;
                        default:
                            Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.HoldMainButton.Click();
                            break;
                    }
                }
            }

            return true;
        }

        [UserCodeMethod]
        /// <summary>
        /// Handle the rule 202 popup on the communications exchange form
        /// </summary>
        /// <param name="expect202">Is the popup expected to appear? True for yes and False for no.</param>
        /// <param name="ack">True to press Yes on the form and false to push No on the form.</param>
        public static void NS_Rule202 (bool expect202, bool ack)
        {
            if (expect202)
            {
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(5000) && Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.NotificationTextByNotificationText.TextValue.Contains("NS Operating Rule 202"))
                {
                    if (ack)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.YesButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo);
                    }
                    else
                    {
                        //Form should back to create state
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.YesButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                    }
                }
                else
                {
                    Report.Screenshot();
                    Report.Error("Notification for rule 202 did not appear.");
                }
            }
        }
        /// <summary>
        /// Fill Box3 in FBA
        /// </summary>
        /// <param name="box3WorkBetweenFrom">Rw authority 'From' opsta</param>
        /// <param name="box3FromCP">Rw authority 'From' control point check box</param>
        /// <param name="box3To">Rw authority 'To' opsta</param>
        /// <param name="box3ToCP">Rw authority 'From' control point check box</param>
        /// <param name="box3Track1">Rw authority Track 1</param>
        /// <param name="box3Track2">Rw authority Track 2</param>
        /// <param name="box3Track3">Rw authority Track 3</param>
        /// <param name="box3Track4">Rw authority Track 4</param>
        /// <param name="box3Track5">Rw authority Track 5</param>
        /// <param name="zones">Specify zones with '|' delimiter</param>
        /// <returns></returns>
        [UserCodeMethod]
        public static bool NS_FillBox3(string box3WorkBetweenFrom, bool box3FromCP, string box3To, bool box3ToCP, string box3Track1,
                                       string box3Track2, string box3Track3, string box3Track4, string box3Track5,
                                       string zones, bool limitsDoNotAdjoin, bool zonesSelect)
        {
            int retries=0;
            if (box3WorkBetweenFrom == "" && box3To == "")
            {
                return true;
            }

            GeneralUtilities.CheckWaitState(10);
            string acceptableFeedback = "";
            if(Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenBetween.GetAttributeValue<string>("Text").Equals(box3WorkBetweenFrom, StringComparison.OrdinalIgnoreCase))
            {
                Ranorex.Report.Success("Box3 WorkBetweenForm is already pre-selected");
            }
            else
            {
                Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenBetween.Click();
                Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenBetween.Element.SetAttributeValue("Text", box3WorkBetweenFrom);
                Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenBetween.PressKeys("{TAB}");
                GeneralUtilities.CheckWaitState(10);

            }

            if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
            {
                return false;
            }

            if (box3FromCP)
            {
                while(!Authoritiesrepo.Create_Track_Authority.Box3.ControlPoint1Checkbox.Enabled && retries<5)
                {
                    Delay.Milliseconds(500);
                    retries ++;
                }
                if(Authoritiesrepo.Create_Track_Authority.Box3.ControlPoint1Checkbox.Enabled)

                {
                    GeneralUtilities.CheckCheckboxAndVerifyChecked(Authoritiesrepo.Create_Track_Authority.Box3.ControlPoint1Checkbox);
                    Ranorex.Report.Success("controlpoint1 check box enabled");
                }
                else
                {
                    Ranorex.Report.Failure("controlpoint1 check box Disabled");
                }
            }
            Authoritiesrepo.Create_Track_Authority.Box3.ControlPoint1Checkbox.PressKeys("{TAB}");
            GeneralUtilities.CheckWaitState(10);

            if(Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenAnd.GetAttributeValue<string>("Text").Equals(box3To, StringComparison.OrdinalIgnoreCase))
            {
                Ranorex.Report.Success("Box3 WorkBetweenAnd is already pre-selected");
            }
            else
            {
            	Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenAnd.Click();
            	Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenAnd.Element.SetAttributeValue("Text", box3To);
            	Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenAnd.PressKeys("{TAB}");
            	GeneralUtilities.CheckWaitState(10);
            	if(Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.OKButtonInfo.Exists())
            	{
            		if(!Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.OKButton.Enabled)
            		{
            			Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.CancelButton.Click();
            		}
            		return false;
            	}
            }


            if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
            {
                return false;
            }
            if (box3ToCP)
            {
                while(!Authoritiesrepo.Create_Track_Authority.Box3.ControlPoint2Checkbox.Enabled && retries<5)
                {
                    Delay.Milliseconds(500);
                    retries ++;
                }
                if(Authoritiesrepo.Create_Track_Authority.Box3.ControlPoint2Checkbox.Enabled)
                {
                    GeneralUtilities.CheckCheckboxAndVerifyChecked(Authoritiesrepo.Create_Track_Authority.Box3.ControlPoint2Checkbox);
                    Ranorex.Report.Success("controlpoint2 check box enabled");
                }
                else
                {
                    Ranorex.Report.Failure("controlpoint2 check box Disabled");
                }
                Authoritiesrepo.Create_Track_Authority.Box3.ControlPoint2Checkbox.PressKeys("{TAB}");
                GeneralUtilities.CheckWaitState(10);
            }

            GeneralUtilities.CheckWaitState(10);
            if (Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack1.Enabled)
            {
            	Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack1.Click();
            	Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack1.Element.SetAttributeValue("Text", box3Track1);
            	Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack1.PressKeys("{TAB}");
            	GeneralUtilities.CheckWaitState(10);
            	while(!Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 5)
            	{
            		Delay.Milliseconds(500);
            		retries ++;
            	}
            	if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0))
            	{
            		if(limitsDoNotAdjoin)
            		{
            			if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButton.Enabled)
            			{

            				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButtonInfo,

            				                                                  Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);
            				Ranorex.Report.Info("Clicking YES button");
            				if(Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
            				{
            					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.AddressLinesRowByIndex.TCNumberInfo,
            					                                                  Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.AddressLinesRowByIndex.TCNumberInfo);
            					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.WindowControls.CloseInfo,
            					                                                  Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
            				}

            				if(Bulletinsrepo.Bulletin_Item_Relay.SelfInfo.Exists(0))
            				{
            					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Item_Relay.AddressTable.AddressLinesRowByIndex.TCNumberInfo,
            					                                                  Bulletinsrepo.Bulletin_Item_Relay.AddressTable.AddressLinesRowByIndex.TCNumberInfo);
            					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Item_Relay.WindowControls.CloseInfo,
            					                                                  Bulletinsrepo.Bulletin_Item_Relay.SelfInfo);
            				}

            			}
            		}
            		else
            		{
            			if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.NoButton.Enabled)
            			{
            				GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.NoButtonInfo,
            				                                          Authoritiesrepo.Create_Track_Authority.SelfInfo);

            				Ranorex.Report.Info("clicking NO button");
            			}
            		}
            	}


            } else {
            	string box3Track1Text = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack1.SelectedItemText;
            	if (box3Track1Text != box3Track1 && box3Track1 != "")
            	{
            		Ranorex.Report.Failure("Track could not be changed from {"+box3Track1Text+"} expected to be {"+box3Track1+"}.");
            		return false;
            	}
//					return true;
            }

            if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
            {
            	string feedbackText = Authoritiesrepo.Create_Track_Authority.Feedback.GetAttributeValue<string>("Text");
            	if(feedbackText.Contains("Required line 8") || feedbackText.Contains("Recommended line 8"))
            	{
            		Ranorex.Report.Info("Feedback Text: "+feedbackText);
            	}
            	else
            	{
            		return false;
            	}
            }
            
            if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0))// && Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.TextWithAuthority.TextValue.Contains("O/T"))
            {
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButtonInfo,
            	                                                 Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);
            }

            if (Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack2.Enabled && !string.IsNullOrEmpty(box3Track2))
            {
            	Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack2.Click();
                Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack2.Element.SetAttributeValue("Text", box3Track2);
                Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack2.PressKeys("{TAB}");
                GeneralUtilities.CheckWaitState(10);
                while(!Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 5)
                {
                	Delay.Milliseconds(500);
                	retries ++;
                }
                if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0))
                {
                	if(limitsDoNotAdjoin)
                	{
                		if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButton.Enabled)
                		{
                			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButtonInfo,
                			                                                  Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);
                			Ranorex.Report.Info("Clicking YES button on Notifications popup");
                		}
                	}
                	else
                	{
                		if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.NoButton.Enabled)
                		{
                			GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.NoButtonInfo,
                			                                          Authoritiesrepo.Create_Track_Authority.SelfInfo);
                			Ranorex.Report.Info("clicking NO button on Notifications popup");
                		}
                	}
                }
                if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
                {
                    return false;
                }
            } else {
                string box3Track2Text = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack2.SelectedItemText;
                if (box3Track2Text != box3Track2 && box3Track2 != "")
                {
                    Ranorex.Report.Failure("Track could not be changed from {"+box3Track2Text+"} expected to be {"+box3Track2+"}.");
                    return false;
                }
//					return true;
            }

            if (Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack3.Enabled && !string.IsNullOrEmpty(box3Track3))
            {
                Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack3.Element.SetAttributeValue("Text", box3Track3);
                Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack3.PressKeys("{TAB}");

                if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
                {
                    return false;
                }
            } else {
                string box3Track3Text = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack3.SelectedItemText;
                if (box3Track3Text != box3Track3 && box3Track3 != "")
                {
                    Ranorex.Report.Failure("Track could not be changed from {"+box3Track3Text+"} expected to be {"+box3Track3+"}.");
                    return false;
                }
//					return true;
            }

            if (Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack4.Enabled	&& !string.IsNullOrEmpty(box3Track4))
            {
                Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack4.Element.SetAttributeValue("Text", box3Track4);
                Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack4.PressKeys("{TAB}");

                if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
                {
                    return false;
                }
            } else {
                string box3Track4Text = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack4.SelectedItemText;
                if (box3Track4Text != box3Track4 && box3Track4 != "")
                {
                    Ranorex.Report.Failure("Track could not be changed from {"+box3Track4Text+"} expected to be {"+box3Track4+"}.");
                    return false;
                }
//					return true;
            }

            if (Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack5.Enabled && !string.IsNullOrEmpty(box3Track5))
            {
                Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack5.Element.SetAttributeValue("Text", box3Track5);
                Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack5.PressKeys("{TAB}");

                if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
                {
                    Ranorex.Report.Info("Inside WorkBetweenTrack5 checkfeedback");
                    return false;
                }
            } else {
                string box3Track5Text = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack5.SelectedItemText;
                if (box3Track5Text != box3Track5 && box3Track5 != "")
                {
                    Ranorex.Report.Failure("Track could not be changed from {"+box3Track5Text+"} expected to be {"+box3Track5+"}.");
                    return false;
                }
//					return true;
            }
            if(Authoritiesrepo.Create_Track_Authority.Box3.ZoneListButton.Enabled)
            {
                if(FillBox3_SelectZoneList(zones,zonesSelect))
                {
                    Report.Success("Zones Selected");
                }
                else
                {
                    Report.Success("Unable to select Zone");
                }

                if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Issues and validates any TE Authority
        /// </summary>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        [UserCodeMethod]
        public static bool NS_FillBox4(string box4ProceedFrom, bool box4Fsw, string box4To1, string box4Track1, string box4To1HoldClearMain,
                                       string box4To2, string box4Track2, string box4To2HoldClearMain, string box4To3, string box4Track3,
                                       string box4To3HoldClearMain)
        {
            if (box4ProceedFrom == "" && box4To1 == "")
            {
                return true;
            }

            Authoritiesrepo.Create_Track_Authority.Box4.Proceed1.Proceed2Between.Element.SetAttributeValue("Text", box4ProceedFrom);
            Authoritiesrepo.Create_Track_Authority.Box4.Proceed1.Proceed2Between.PressKeys("{TAB}");

            string acceptableFeedback = "";
            if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
            {
                return false;
            }


            if (box4Fsw)
            {
                if (!Authoritiesrepo.Create_Track_Authority.Box4.Proceed1.FSWToCheckbox.Enabled && !Authoritiesrepo.Create_Track_Authority.Box4.Proceed1.FSWToCheckbox.Checked)
                {
                    Ranorex.Report.Failure("Unable to select fsw checkbox");
                    return false;
                } else {
                    Authoritiesrepo.Create_Track_Authority.Box4.Proceed1.FSWToCheckbox.PressKeys("{SPACE}");
                }
            }
            Authoritiesrepo.Create_Track_Authority.Box4.Proceed1.FSWToCheckbox.PressKeys("{TAB}");


            Authoritiesrepo.Create_Track_Authority.Box4.Proceed1.Proceed2To1.Element.SetAttributeValue("Text", box4To1);
            Authoritiesrepo.Create_Track_Authority.Box4.Proceed1.Proceed2To1.PressKeys("{TAB}");

            if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
            {
                return false;
            }

            if (Authoritiesrepo.Create_Track_Authority.Box4.Proceed1.Proceed2Track1.Enabled)
            {
                Authoritiesrepo.Create_Track_Authority.Box4.Proceed1.Proceed2Track1.Element.SetAttributeValue("Text", box4Track1);
                Authoritiesrepo.Create_Track_Authority.Box4.Proceed1.Proceed2Track1.PressKeys("{TAB}");

                if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
                {
                    return false;
                }
            } else {
                string box4Track1Text = Authoritiesrepo.Create_Track_Authority.Box4.Proceed1.Proceed2Track1.SelectedItemText;
                if (box4Track1Text != box4Track1 && box4Track1 != "")
                {
                    Ranorex.Report.Failure("Track could not be changed from {"+box4Track1Text+"} expected to be {"+box4Track1+"}.");
                    return false;
                }
            }

            if (Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.SelfInfo.Exists(0))
            {
                switch(box4To1HoldClearMain)
                {
                    case "Clear":
                        Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.ClearMainButton.Click();
                        break;
                    case "Cancel":
                        Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.CancelButton.Click();
                        break;
                    case "Neither":
                        Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.NeitherButton.Click();
                        break;
                    default:
                        Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.HoldMainButton.Click();
                        break;
                }
            }

            Authoritiesrepo.Create_Track_Authority.Box4.Proceed2.Proceed2To2.Element.SetAttributeValue("Text", box4To2);
            Authoritiesrepo.Create_Track_Authority.Box4.Proceed2.Proceed2To2.PressKeys("{TAB}");

            if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
            {
                return false;
            }

            if (Authoritiesrepo.Create_Track_Authority.Box4.Proceed2.Proceed2Track2.Enabled)
            {
                Authoritiesrepo.Create_Track_Authority.Box4.Proceed2.Proceed2Track2.Element.SetAttributeValue("Text", box4Track2);
                Authoritiesrepo.Create_Track_Authority.Box4.Proceed2.Proceed2Track2.PressKeys("{TAB}");

                if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
                {
                    return false;
                }
            } else {
                string box4Track2Text = Authoritiesrepo.Create_Track_Authority.Box4.Proceed2.Proceed2Track2.SelectedItemText;
                if (box4Track2Text != box4Track2 && box4Track2 != "")
                {
                    Ranorex.Report.Failure("Track could not be changed from {"+box4Track2Text+"} expected to be {"+box4Track2+"}.");
                    return false;
                }
            }

            if (Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.SelfInfo.Exists(0))
            {
                switch(box4To2HoldClearMain)
                {
                    case "Clear":
                        Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.ClearMainButton.Click();
                        break;
                    case "Cancel":
                        Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.CancelButton.Click();
                        break;
                    case "Neither":
                        Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.NeitherButton.Click();
                        break;
                    default:
                        Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.HoldMainButton.Click();
                        break;
                }
            }

            if (Authoritiesrepo.Create_Track_Authority.Box4.Proceed3.Proceed2To3.Enabled)
            {
                Authoritiesrepo.Create_Track_Authority.Box4.Proceed3.Proceed2To3.Element.SetAttributeValue("Text", box4To3);
                Authoritiesrepo.Create_Track_Authority.Box4.Proceed3.Proceed2To3.PressKeys("{TAB}");

                if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
                {
                    return false;
                }


                if (Authoritiesrepo.Create_Track_Authority.Box4.Proceed3.Proceed2Track3.Enabled)
                {
                    Authoritiesrepo.Create_Track_Authority.Box4.Proceed3.Proceed2Track3.Element.SetAttributeValue("Text", box4Track3);
                    Authoritiesrepo.Create_Track_Authority.Box4.Proceed3.Proceed2Track3.PressKeys("{TAB}");

                    if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
                    {
                        return false;
                    }
                } else {
                    string box4Track3Text = Authoritiesrepo.Create_Track_Authority.Box4.Proceed3.Proceed2Track3.SelectedItemText;
                    if (box4Track3Text != box4Track3 && box4Track3 != "")
                    {
                        Ranorex.Report.Failure("Track could not be changed from {"+box4Track3Text+"} expected to be {"+box4Track3+"}.");
                        return false;
                    }
                }

                if (Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.SelfInfo.Exists(0))
                {
                    switch(box4To3HoldClearMain)
                    {
                        case "Clear":
                            Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.ClearMainButton.Click();
                            break;
                        case "Cancel":
                            Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.CancelButton.Click();
                            break;
                        case "Neither":
                            Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.NeitherButton.Click();
                            break;
                        default:
                            Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.HoldMainButton.Click();
                            break;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Issues and validates any TE Authority
        /// </summary>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        [UserCodeMethod]
        public static bool NS_FillBox5(string box5UntilInMinutes, string acceptableFeedback)
        {
            if (box5UntilInMinutes != "")
            {
                int convertedIntegerValue;
                if (int.TryParse(box5UntilInMinutes, out convertedIntegerValue)) {
                    System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(convertedIntegerValue);
                    string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("hh:mm tt");

                    Authoritiesrepo.Create_Track_Authority.Box5.EffectiveUntilText.Click();
                    Authoritiesrepo.Create_Track_Authority.Box5.EffectiveUntilText.PressKeys(effectiveTimeDifferenceFormatted);
                    Authoritiesrepo.Create_Track_Authority.Box5.EffectiveUntilText.PressKeys("{TAB}");

                    if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
                    {
                        return false;
                    }
                } else {
                    Authoritiesrepo.Create_Track_Authority.Box5.EffectiveUntilText.Click();
                    Authoritiesrepo.Create_Track_Authority.Box5.EffectiveUntilText.PressKeys(box5UntilInMinutes);
                    Authoritiesrepo.Create_Track_Authority.Box5.EffectiveUntilText.PressKeys("{TAB}");

                    if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
                    {
                        return false;
                    }
                }
            } else {
                Authoritiesrepo.Create_Track_Authority.Box5.EffectiveUntilText.PressKeys("{TAB}");
            }
            return true;
        }

        [UserCodeMethod]
        public static bool NS_FillBox6(string engineSeed1, string engine1Direction, string engineSeed2, string engine2Direction, string engineSeed3, string engine3Direction, string expectedFeedback)
        {
            string engineId1 = "";
            if (!engineSeed1.Equals(""))
            {
                engineId1 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineIdFromEngineSeed(engineSeed1);
                if (engineId1 == null)
                {
                    Ranorex.Report.Warn("Non-train object values being input for Engine 1 in box 6.");
                    engineId1 = engineSeed1;
                }
            }
            else
            {
                Ranorex.Report.Info("Skipping box 6.");
                return true;
            }

            string engineId2 = "";
            if (!engineSeed2.Equals("")) //or skip
            {
                engineId2 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineIdFromEngineSeed(engineSeed2);
                if (engineId2 == null)
                {
                    Ranorex.Report.Warn("Non-train object values being input for Engine 2 in box 6.");
                    engineId2 = engineSeed2;
                }
            }

            string engineId3 = "";
            if (!engineSeed3.Equals(""))
            {
                engineId3 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineIdFromEngineSeed(engineSeed3);
                if (engineId3 == null)
                {
                    Ranorex.Report.Warn("Non-train object values being input for Engine 3 in box 6.");
                    engineId3 = engineSeed3;
                }
            }
            
            if (!string.IsNullOrEmpty(engineId1))
            {
            	GeneralUtilities.CheckWaitState(10);
            	Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainField1Text.Click();
                Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainField1Text.Element.SetAttributeValue("Text", engineId1 + " " + engine1Direction);
                Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainField1Text.PressKeys("{TAB}");
                GeneralUtilities.CheckWaitState(10);
                if (!string.IsNullOrEmpty(engineId2))
                {
                	Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainField2Text.Click();
                    Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainField2Text.Element.SetAttributeValue("Text", engineId2 + " " + engine2Direction);
                    Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainField1Text.PressKeys("{TAB}");
                    GeneralUtilities.CheckWaitState(10);
                    if (!string.IsNullOrEmpty(engineId3))
                    {
                    	Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainField3Text.Click();
                        Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainField3Text.Element.SetAttributeValue("Text", engineId3 + " " + engine3Direction);
                        Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainField1Text.PressKeys("{TAB}");
                        GeneralUtilities.CheckWaitState(10);
                    }
                }
            }

            if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback))
            {
                return false;
            }

            return true;
        }

        [UserCodeMethod]
        public static void NS_ClickBox7(bool check, bool limitsDoNotAdjoin)
        {

            if (Authoritiesrepo.Create_Track_Authority.Box7.Box7Checkbox.Checked != check)
            {
                Authoritiesrepo.Create_Track_Authority.Box7.Box7Checkbox.Click();
                Authoritiesrepo.Create_Track_Authority.Box7.Box7Checkbox.PressKeys("{TAB}");

                int retries = 0;
                while(!Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 3)
                {
                    Delay.Milliseconds(500);
                    retries ++;
                }
                if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0))
                {
                    if(limitsDoNotAdjoin)
                    {
                        if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButton.Enabled)
                        {

                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButtonInfo,

                                                                              Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);
                            Ranorex.Report.Info("Clicking YES button");
                            if(Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.AddressLinesRowByIndex.TCNumberInfo,
                                                                                  Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.AddressLinesRowByIndex.TCNumberInfo);
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.WindowControls.CloseInfo,
                                                                                  Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
                            }
                        }
                    }
                    else
                    {
                        if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.NoButton.Enabled)
                        {
                            GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.NoButtonInfo,
                                                                      Authoritiesrepo.Create_Track_Authority.SelfInfo);

                            Ranorex.Report.Info("clicking NO button");
                        }
                    }
                }

            }

            return;
        }

        [UserCodeMethod]
        public static bool NS_FillBox8(string engineSeed1, string engine1Direction, string engineSeed2, string engine2Direction, string engineSeed3, string engine3Direction, string expectedFeedback)
        {
            string engineId1 = "";
            if (!engineSeed1.Equals(""))
            {
                engineId1 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineIdFromEngineSeed(engineSeed1);
                if (engineId1 == null)
                {
                    Ranorex.Report.Warn("Non-train object values being input for Engine 1 in box 8.");
                    engineId1 = engineSeed1;
                }
            }
            else
            {
                Ranorex.Report.Info("Skipping box 8.");
                return true;
            }

            string engineId2 = "";
            if (!engineSeed2.Equals("")) //or skip
            {
                engineId2 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineIdFromEngineSeed(engineSeed2);
                if (engineId2 == null)
                {
                    Ranorex.Report.Warn("Non-train object values being input for Engine 2 in box 8.");
                    engineId2 = engineSeed2;
                }
            }

            string engineId3 = "";
            if (!engineSeed3.Equals(""))
            {
                engineId3 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineIdFromEngineSeed(engineSeed3);
                if (engineId3 == null)
                {
                    Ranorex.Report.Warn("Non-train object values being input for Engine 3 in box 8.");
                    engineId3 = engineSeed3;
                }
            }

            if (!engineId1.Equals(""))
            {
            	Authoritiesrepo.Create_Track_Authority.Box8.TrainsToFollowTrain1Text.Click();
                Authoritiesrepo.Create_Track_Authority.Box8.TrainsToFollowTrain1Text.Element.SetAttributeValue("Text", engineId1 + " " + engine1Direction);
                Authoritiesrepo.Create_Track_Authority.Box8.TrainsToFollowTrain1Text.PressKeys("{TAB}");

                if (!engineId2.Equals(""))
                {
                    Authoritiesrepo.Create_Track_Authority.Box8.TrainsToFollowTrain2Text.Element.SetAttributeValue("Text", engineId2 + " " + engine2Direction);
                    Authoritiesrepo.Create_Track_Authority.Box8.TrainsToFollowTrain1Text.PressKeys("{TAB}");
                    if (!engineId3.Equals(""))
                    {
                        Authoritiesrepo.Create_Track_Authority.Box8.TrainsToFollowTrain3Text.Element.SetAttributeValue("Text", engineId3 + " " + engine3Direction);
                        Authoritiesrepo.Create_Track_Authority.Box8.TrainsToFollowTrain1Text.PressKeys("{TAB}");
                    }
                }
            }

            if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback))
            {
                return false;
            }

            return true;
        }

        [UserCodeMethod]
        public static bool NS_FillBox9()
        {
            bool box9Checked = false;

            if(Authoritiesrepo.Create_Track_Authority.Box9.Box9Checkbox.Enabled)
            {
                Authoritiesrepo.Create_Track_Authority.Box9.Box9Checkbox.Click();
                Authoritiesrepo.Create_Track_Authority.Box9.Box9Checkbox.PressKeys("{TAB}");
                if (Authoritiesrepo.Create_Track_Authority.Box9.Box9Checkbox.Checked)
                {
                    box9Checked = true;
                }
            }

            return box9Checked;
        }

        /// <summary>
        /// Issues and validates any TE Authority
        /// </summary>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        [UserCodeMethod]
        public static bool NS_FillBox11(string box11StopShort, string box11Track)
        {
            if (box11StopShort == "" && box11Track == "")
            {
                return true;
            }
            //Box 11 is the only one it tabs to the checkbox first
            Authoritiesrepo.Create_Track_Authority.Box11.Box11Checkbox.PressKeys("{TAB}");

            Authoritiesrepo.Create_Track_Authority.Box11.StopShortPointText.Element.SetAttributeValue("Text", box11StopShort);
            Authoritiesrepo.Create_Track_Authority.Box11.StopShortPointText.PressKeys("{TAB}");

            string acceptableFeedback = "";
            if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
            {
                return false;
            }

            if (Authoritiesrepo.Create_Track_Authority.Box11.StopShortTrackText.Enabled)
            {
                Authoritiesrepo.Create_Track_Authority.Box11.StopShortTrackText.Element.SetAttributeValue("Text", box11Track);
                Authoritiesrepo.Create_Track_Authority.Box11.StopShortTrackText.PressKeys("{TAB}");

                if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, acceptableFeedback))
                {
                    return false;
                }
            } else {
                string box11TrackText = Authoritiesrepo.Create_Track_Authority.Box11.StopShortTrackText.SelectedItemText;
                if (box11TrackText != box11Track && box11Track != "")
                {
                    Ranorex.Report.Failure("Track could not be changed from {"+box11TrackText+"} expected to be {"+box11Track+"}.");
                    return false;
                }
            }
            return true;
        }

        [UserCodeMethod]
        public static bool NS_FillBox10 (string location1, string location2, string expectedFeedback)
        {
            if (!location1.Equals(""))
            {
                Authoritiesrepo.Create_Track_Authority.Box10.TrainsSpeedRestrictionBetweenText.Click();
                Authoritiesrepo.Create_Track_Authority.Box10.TrainsSpeedRestrictionBetweenText.Element.SetAttributeValue("Text", location1);
                Authoritiesrepo.Create_Track_Authority.Box10.TrainsSpeedRestrictionBetweenText.PressKeys("{TAB}");
            }

            if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback))
            {
                //Ranorex.Report.Failure("Unexpected feedback found after first box 10 location entry.");
                return false;
            }

            //Not doing any self input validation, but skip input if its empty, i.e. fail if you have a first location but not a second or vice versa
            if (!location2.Equals(""))
            {
                Authoritiesrepo.Create_Track_Authority.Box10.TrainsSpeedRestrictionAndText.Click();
                Authoritiesrepo.Create_Track_Authority.Box10.TrainsSpeedRestrictionAndText.Element.SetAttributeValue("Text", location2);
                Authoritiesrepo.Create_Track_Authority.Box10.TrainsSpeedRestrictionAndText.PressKeys("{TAB}");
            }

            if (!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback))
            {
                //Ranorex.Report.Failure("Unexpected feedback found after second box 10 location entry.");
                return false;
            }
            return true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="subdivideLimits"></param>
        /// <param name="SubdividedLimitsText"></param>
        /// <param name="betweenSide"></param>
        /// <param name="andSide"></param>
        /// <param name="box13ManualInstructions"></param>
        /// <returns></returns>
        [UserCodeMethod]
        public static void NS_FillBox13(string authoritySeed, bool subdivideLimits, string SubdividedLimitsText, bool betweenSide, bool andSide, string box13ManualInstructions, string expectedFeedback)
        {
            if(subdivideLimits)
            {
            	FillBox13_SelectSubdividedLimits(authoritySeed, SubdividedLimitsText, betweenSide,	andSide);
            }
            if(box13ManualInstructions != "")
            {
            	Authoritiesrepo.Create_Track_Authority.Box13.OtherInstructionsUserText.Click();
            	Authoritiesrepo.Create_Track_Authority.Box13.OtherInstructionsUserText.PressKeys(box13ManualInstructions);
            	Authoritiesrepo.Create_Track_Authority.Box13.OtherInstructionsUserText.PressKeys("{TAB}");
            }
        }


        /// <summary>
        /// Seems weird since normally box 1 is populated by user, but TAC will auto-populate
        /// </summary>
        /// <param name="expected">Is box 1 going to be checked and enabled?</param>
        /// <param name="authoritySeed">If it is populated, what authority should it be?</param>
        /// <returns></returns>
        [UserCodeMethod]
        public static bool NS_ValidateBox1 (bool expected, string authoritySeed)
        {
        	if (!expected && !Authoritiesrepo.Create_Track_Authority.Box1.Box1Checkbox.Checked)
        	{
        		Ranorex.Report.Success("Box 1 not populated.");
        		return true;
        	}
        	else if (!expected && Authoritiesrepo.Create_Track_Authority.Box1.Box1Checkbox.Checked)
        	{
        		Ranorex.Report.Failure("Box 1 is unexpectedly enabled.");
        		return false;
        	}
        	else if (expected && !Authoritiesrepo.Create_Track_Authority.Box1.Box1Checkbox.Checked)
        	{
        		Report.Failure("Box 1 is unexpectedly disabled.");
        		return false;
        	}
        	else
        	{
        		Report.Success("Box 1 is enabled as expected.");
        	}

        	AuthorityObject authToBeVoided = new AuthorityObject();
        	authToBeVoided = GetAuthorityObject(authoritySeed);

        	if (authToBeVoided.Equals(null))
        	{
        		Ranorex.Report.Error("Could not find authority for authority seed {"+authoritySeed+"}.");
        		return false;
        	}

        	string box1Text = Authoritiesrepo.Create_Track_Authority.Box1.VoidTrackAuthorityNumberText.Text;
        	if (authToBeVoided.authorityNumber.Equals(box1Text))
        	{
        		Report.Success("Expected track authority number {"+authToBeVoided.box1TrackAuthorityNumber+"} matches box 1 contents {"+box1Text+"}.");
        		return true;
        	}
        	else{
        		Report.Failure("Expected track authority number {"+authToBeVoided.box1TrackAuthorityNumber+"} in box 1 contents. Box 1 contains {"+box1Text+"}.");
        		return false;
        	}
        }

        /// <summary>
        /// Issues and validates any TE Authority TODO if someone who uses this could clean this up for me that'd be great, including cases where we do 1 engine 2 engines, 3 engines. Right now it tries to do all. Thanks. ~Maris
        /// </summary>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        [UserCodeMethod]
        public static bool NS_ValidateBox6(string box6EngineSeed1, string box6Engine1Direction, string box6EngineSeed2, string box6Engine2Direction, string box6EngineSeed3, string box6Engine3Direction, string box6At)
        {
            bool exists = Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainField1TextInfo.Exists(0);
            if (!exists && !box6EngineSeed1.Equals(""))
            {
                Ranorex.Report.Failure("Box 6 does not exist.");
                return false;
            } else if (!exists && box6EngineSeed1.Equals(""))
            {
                Ranorex.Report.Info("Skip box 6 validations.");
                return true;
            }
            else if (exists && Authoritiesrepo.Create_Track_Authority.Box6.Box6Checkbox.Checked && box6EngineSeed1.Equals(""))
            {
            	Ranorex.Report.Failure("Unexpected Box 6 present.");
            	return false;
            }


            string foundEngine1 = Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainField1Text.GetAttributeValue<string>("Text");
            string foundEngine2 = Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainField2Text.GetAttributeValue<string>("Text");
            string foundEngine3 = Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainField3Text.GetAttributeValue<string>("Text");
            if (box6EngineSeed1.Equals("") && foundEngine1.Equals("")) //Double checks if your intent is to skip this validation, make sure nothing si in that first field
            {
                Ranorex.Report.Info("Skip box 6 validations.");
                return true;
            }

            string engineId1 = "";
            if (!box6EngineSeed1.Equals(""))
            {
                engineId1 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineIdFromEngineSeed(box6EngineSeed1);
                if (engineId1 == null)
                {
                    engineId1 = box6EngineSeed1;
                }
                engineId1 = engineId1 + " " + box6Engine1Direction;
            }

            string engineId2	= "";
            if (!box6EngineSeed2.Equals(""))
            {
                engineId2 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineIdFromEngineSeed(box6EngineSeed2);
                if (engineId2 == null)
                {
                    engineId2 = box6EngineSeed2;
                }
                engineId2 = engineId2 + " " + box6Engine2Direction;
            }

            string engineId3 = "";
            if (!box6EngineSeed3.Equals(""))
            {
                engineId3 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineIdFromEngineSeed(box6EngineSeed3);
                if (engineId3 == null)
                {
                    engineId3 = box6EngineSeed3;
                }
                engineId3 = engineId3 + " " + box6Engine3Direction;
            }


            if (foundEngine1.Equals(engineId1))
            {
                Ranorex.Report.Success("{"+engineId1+"} found in engine spot 1 {"+foundEngine1+"} of Box 6.");
            }
            else
            {
                Ranorex.Report.Failure("{"+engineId1+"} not found in engine spot 1 {"+foundEngine1+"} of Box 6.");
            }

            //If you dont expect anything to be there, check if there is something there, if there is, return a fialure
            if (!box6EngineSeed2.Equals(""))
            {
                Ranorex.Report.Success("{"+engineId2+"} found in engine spot 2 {"+foundEngine2+"} of Box 6.");

            }
            else if (!foundEngine2.Equals(""))
            {

                Ranorex.Report.Failure("{"+engineId2+"} not found in engine spot 2 {"+foundEngine2+"} of Box 6.");
                return false;

            }

            if (foundEngine3.Equals(engineId3))
            {
                Ranorex.Report.Success("{"+engineId3+"} found in engine spot 3 {"+foundEngine3+"} of Box 6.");

            }
            else
            {
                Ranorex.Report.Failure("{"+engineId3+"} not found in engine spot 3 {"+foundEngine3+"} of Box 6.");
                return false;
            }

            string atLocation = Authoritiesrepo.Create_Track_Authority.Box6.OpposingTrainsLocation.GetAttributeValue<string>("Text");
            if (!atLocation.Equals(box6At))
            {
                Ranorex.Report.Failure("{"+box6At+"} not found as At location {"+atLocation+"} of Box 6.");
                return false;
            }

            Ranorex.Report.Success("Engines {"+engineId1+"}, {"+engineId2+"}, {"+engineId3+"} at {"+box6At+"} found as part of Box 6");

            return true;
        }

        /// <summary>
        /// Issues and validates any TE Authority
        /// </summary>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        [UserCodeMethod]
        public static bool NS_ValidateBox7(bool box7)
        {

            if (Authoritiesrepo.Create_Track_Authority.Box7.Box7Checkbox.Checked != box7)
            {
                Ranorex.Report.Failure("Box 7 was found to be {"+(Authoritiesrepo.Create_Track_Authority.Box7.Box7Checkbox.Checked ? "Checked}." : "Not Checked}.")+"Expected: {"+(box7 ? "Checked}." : "Not Checked}."));
                return false;
            }
            Ranorex.Report.Success("Box 7 was found to be {"+(box7 ? "Checked}." : "Not Checked}."));
            return true;
        }

        /// <summary>
        /// Issues and validates any TE Authority
        /// </summary>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        [UserCodeMethod]
        public static bool NS_ValidateBox8(string box8EngineSeed1, string box8Engine1Direction, string box8EngineSeed2, string box8Engine2Direction, string box8EngineSeed3, string box8Engine3Direction)
        {
            string engineId1 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineIdFromEngineSeed(box8EngineSeed1);
            if (engineId1 == null)
            {
                Ranorex.Report.Warn("Non-train object values being validated for Engine 1 in box 8.");
                engineId1 = box8EngineSeed1;
            }

            string engineId2 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineIdFromEngineSeed(box8EngineSeed2);
            if (engineId2 == null)
            {
                Ranorex.Report.Warn("Non-train object values being validated for Engine 2 in box 8.");
                engineId2 = box8EngineSeed2;
            }

            string engineId3 = PDS_CORE.Code_Utils.NS_TrainID.FindEngineIdFromEngineSeed(box8EngineSeed3);
            if (engineId3 == null)
            {
                Ranorex.Report.Warn("Non-train object values being validated for Engine 3 in box 8.");
                engineId3 = box8EngineSeed3;
            }

            string foundEngine1 = Authoritiesrepo.Create_Track_Authority.Box8.TrainsToFollowTrain1Text.GetAttributeValue<string>("Text");
            string foundEngine2 = Authoritiesrepo.Create_Track_Authority.Box8.TrainsToFollowTrain2Text.GetAttributeValue<string>("Text");
            string foundEngine3 = Authoritiesrepo.Create_Track_Authority.Box8.TrainsToFollowTrain3Text.GetAttributeValue<string>("Text");
            if (engineId1 != "")
            {
                engineId1 = engineId1 + " " + box8Engine1Direction;
            }
            if (engineId2 != "")
            {
                engineId2 = engineId2 + " " + box8Engine2Direction;
            }
            if (engineId3 != "")
            {
                engineId3 = engineId3 + " " + box8Engine3Direction;
            }
            if (!foundEngine1.Contains(engineId1))
            {
                Ranorex.Report.Failure("{"+engineId1+"} not found in engine spot 1 {"+foundEngine1+"} of Box 8.");
                return false;
            }

            if (!foundEngine2.Contains(engineId2))
            {
                Ranorex.Report.Failure("{"+engineId2+"} not found in engine spot 2 {"+foundEngine2+"} of Box 8.");
                return false;
            }

            if (!foundEngine3.Contains(engineId3))
            {
                Ranorex.Report.Failure("{"+engineId3+"} not found in engine spot 3 {"+foundEngine3+"} of Box 8.");
                return false;
            }

            Ranorex.Report.Success("Trains {"+engineId1+"}, {"+engineId2+"}, {"+engineId3+"} found as part of Box 8");
            return true;
        }


        /// <summary>
        /// Issues and validates any TE Authority
        /// </summary>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        [UserCodeMethod]
        public static bool NS_ValidateBox9(bool box9)
        {

            if (Authoritiesrepo.Create_Track_Authority.Box9.Box9Checkbox.Checked != box9)
            {
                Ranorex.Report.Failure("Box 9 was found to be {"+(Authoritiesrepo.Create_Track_Authority.Box9.Box9Checkbox.Checked ? "Checked}." : "Not Checked}.")+"Expected: {"+(box9 ? "Checked}." : "Not Checked}."));
                return false;
            }
            Ranorex.Report.Success("Box 9 was found to be {"+(box9 ? "Checked}." : "Not Checked}."));
            return true;
        }

        /// <summary>
        /// Issues and validates any TE Authority
        /// </summary>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        [UserCodeMethod]
        public static bool NS_ValidateBox10(string box10Between1, string box10Between2)
        {

            if (Authoritiesrepo.Create_Track_Authority.Box10.TrainsSpeedRestrictionBetweenText.SelectedItemText != box10Between1)
            {
                Ranorex.Report.Failure("Box 10 Between found to be {"+Authoritiesrepo.Create_Track_Authority.Box10.TrainsSpeedRestrictionBetweenText.SelectedItemText+"} when expected is {"+box10Between1+"}.");
                return false;
            }

            if (Authoritiesrepo.Create_Track_Authority.Box10.TrainsSpeedRestrictionAndText.SelectedItemText != box10Between2)
            {
                Ranorex.Report.Failure("Box 10 And found to be {"+Authoritiesrepo.Create_Track_Authority.Box10.TrainsSpeedRestrictionAndText.SelectedItemText+"} when expected is {"+box10Between2+"}.");
                return false;
            }

            Ranorex.Report.Success("Box 10 items {"+box10Between1+"} and {"+box10Between2+"} successfully found.");
            return true;
        }

        /// <summary>
        /// Issues and validates any TE Authority
        /// </summary>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        [UserCodeMethod]
        public static bool NS_ValidateBox12(string box12RWIC1, string box12Between1, string box12And1, string box12Track1, string box12RWIC2,
                                            string box12Between2, string box12And2, string box12Track2, string box12RWIC3, string box12Between3,
                                            string box12And3, string box12Track3)
        {
            bool success	= true;

            string RWICName1 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC1.WorkersInChargeName1Text.TextValue;
            if (RWICName1 != box12RWIC1)
            {
                Ranorex.Report.Failure("Box 12 First RWIC Name found to be {"+RWICName1+"} when expected is {"+box12RWIC1+"}.");
                success = false;
            }
            string RWICName2 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC2.WorkersInChargeName2Text.TextValue;
            if (RWICName2 != box12RWIC2)
            {
                Ranorex.Report.Failure("Box 12 Second RWIC Name found to be {"+RWICName2+"} when expected is {"+box12RWIC2+"}.");
                success = false;
            }
            string RWICName3 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC3.WorkersInChargeName3Text.TextValue;
            if (RWICName3 != box12RWIC3)
            {
                Ranorex.Report.Failure("Box 12 Third RWIC Name found to be {"+RWICName3+"} when expected is {"+box12RWIC3+"}.");
                success = false;
            }

            string RWICBetween1 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC1.WorkersInChargeBetween1Text.TextValue;
            if (RWICBetween1 != box12Between1)
            {
                Ranorex.Report.Failure("Box 12 First RWIC Between found to be {"+RWICBetween1+"} when expected is {"+box12Between1+"}.");
                success = false;
            }
            string RWICBetween2 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC2.WorkersInChargeBetween2Text.TextValue;
            if (RWICBetween2 != box12Between2)
            {
                Ranorex.Report.Failure("Box 12 Second RWIC Between found to be {"+RWICBetween2+"} when expected is {"+box12Between2+"}.");
                success = false;
            }
            string RWICBetween3 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC3.WorkersInChargeBetween3Text.TextValue;
            if (RWICBetween3 != box12Between3)
            {
                Ranorex.Report.Failure("Box 12 Third RWIC Between found to be {"+RWICBetween3+"} when expected is {"+box12Between3+"}.");
                success = false;
            }

            string RWICAnd1 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC1.WorkersInChargeAnd1Text.TextValue;
            if (RWICAnd1 != box12And1)
            {
                Ranorex.Report.Failure("Box 12 First RWIC And found to be {"+RWICAnd1+"} when expected is {"+box12And1+"}.");
                success = false;
            }
            string RWICAnd2 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC2.WorkersInChargeAnd2Text.TextValue;
            if (RWICAnd2 != box12And2)
            {
                Ranorex.Report.Failure("Box 12 Second RWIC And found to be {"+RWICAnd2+"} when expected is {"+box12And2+"}.");
                success = false;
            }
            string RWICAnd3 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC3.WorkersInChargeAnd3Text.TextValue;
            if (RWICAnd3 != box12And3)
            {
                Ranorex.Report.Failure("Box 12 Third RWIC And found to be {"+RWICAnd3+"} when expected is {"+box12And3+"}.");
                success = false;
            }

            string RWICTrack1 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC1.WorkersInChargeTrack1Text.TextValue;
            if (RWICTrack1 != box12Track1)
            {
                Ranorex.Report.Failure("Box 12 First RWIC Track found to be {"+RWICTrack1+"} when expected is {"+box12Track1+"}.");
                success = false;
            }
            string RWICTrack2 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC2.WorkersInChargeTrack2Text.TextValue;
            if (RWICTrack2 != box12Track2)
            {
                Ranorex.Report.Failure("Box 12 Second RWIC Track found to be {"+RWICTrack2+"} when expected is {"+box12Track2+"}.");
                success = false;
            }
            string RWICTrack3 = Authoritiesrepo.Create_Track_Authority.Box12.RWIC3.WorkersInChargeTrack3Text.TextValue;
            if (RWICTrack3 != box12Track3)
            {
                Ranorex.Report.Failure("Box 12 Third RWIC Track found to be {"+RWICTrack3+"} when expected is {"+box12Track3+"}.");
                success = false;
            }

            if (success)
            {
                Ranorex.Report.Success("Box 12 matches expected values of {{"+RWICName1+"}{"+RWICBetween1+"}{"+RWICAnd1+"}{"+RWICTrack1+"}} {{"+RWICName2+"}{"+RWICBetween2+"}{"+RWICAnd2+"}{"+RWICTrack2+"}} {{"+RWICName3+"}{"+RWICBetween3+"}{"+RWICAnd3+"}{"+RWICTrack3+"}}");
            }
            return success;
        }

        /// <summary>
        /// Issues and validates any TE Authority
        /// </summary>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        [UserCodeMethod]
        public static bool NS_ValidateBox13(string box13AutomaticInstructions)
        {
            Regex box13AutomaticInstructionsRegex = new Regex(box13AutomaticInstructions);
            string automaticInstructions = Authoritiesrepo.Create_Track_Authority.Box13.OtherInstructionsSystemText.TextValue;
            if (box13AutomaticInstructionsRegex.IsMatch(automaticInstructions))
            {
                Ranorex.Report.Success("System Instruction regex {"+box13AutomaticInstructions+"} found in System Instruction {"+automaticInstructions+"}.");
                return true;
            }

            Ranorex.Report.Failure("System Instruction regex {"+box13AutomaticInstructions+"} not found in System Instruction {"+automaticInstructions+"}.");
            return false;
        }

        /// <summary>
        /// Issues and validates any TE Authority
        /// </summary>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        [UserCodeMethod]
        public static bool NS_FillTrackAuthorityHeader(string trackAuthorityType, string trainSeed, string engineSeed, string rwicUser, string rWOrOtWorker, string at, string expectedFeedback)
        {
            //Input the train
            if (trackAuthorityType == "TE")
            {
                string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
                if (trainId == null)
                {
                    Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                    Authoritiesrepo.Create_Track_Authority.CancelButton.Click();
                    return false;
                }

                GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Create_Track_Authority.TrainID.FindTrainButtonInfo,
                                                         Authoritiesrepo.Create_Track_Authority.TrainID.Find_Train.TrainIDTextInfo);
                //Authoritiesrepo.Create_Track_Authority.TrainID.FindTrainButton.Click();
                Authoritiesrepo.Create_Track_Authority.TrainID.Find_Train.TrainIDText.Click();
                Authoritiesrepo.Create_Track_Authority.TrainID.Find_Train.TrainIDText.Element.SetAttributeValue("Text", trainId);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.TrainID.Find_Train.OkButtonInfo,
                                                                 Authoritiesrepo.Create_Track_Authority.TrainID.Find_Train.SelfInfo);
                //Authoritiesrepo.Create_Track_Authority.TrainID.Find_Train.OkButton.Click();

                //Input the Engine
                PDS_CORE.Code_Utils.NS_EngineConsistObject engineObject = null;
                if (PDS_CORE.Code_Utils.NS_TrainID.EngineRecordExists(trainSeed, engineSeed))
                {
                    engineObject = PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(trainSeed, engineSeed);
                }

                if (engineObject != null)
                {
                    if (engineObject.EngineInitial != "" && engineObject.EngineNumber != "")
                    {
                        Authoritiesrepo.EngineId = engineObject.EngineInitial + " " + engineObject.EngineNumber;
                        Authoritiesrepo.Create_Track_Authority.To.EngineToMenuButton.Click();
                        if (Authoritiesrepo.Create_Track_Authority.To.EngineToMenuList.EngineIdListItemByEngineIdInfo.Exists(0))
                        {
                            Ranorex.Delay.Milliseconds(500);
                            Authoritiesrepo.Create_Track_Authority.To.EngineToMenuList.EngineIdListItemByEngineId.Click();
                        }
                        else
                        {
                            Ranorex.Report.Failure("Engine ID: " + Authoritiesrepo.EngineId + " associated with train seed: " + trainSeed + " not found.");
                            return false;
                        }
                    }
                }
                else
                {
                    if(Authoritiesrepo.Create_Track_Authority.To.EngineToText.GetAttributeValue<string>("Text").Equals(engineSeed, StringComparison.OrdinalIgnoreCase))
                    {
                        Ranorex.Report.Success("Engine ID value is already pre-selected");
                    }
                    else
                    {
                        Authoritiesrepo.Create_Track_Authority.To.EngineToText.Click();
                        Authoritiesrepo.Create_Track_Authority.To.EngineToText.Element.SetAttributeValue("Text", engineSeed);
                        Authoritiesrepo.Create_Track_Authority.To.EngineToText.PressKeys("{TAB}");
                        Ranorex.Report.Info("Engine ID Manually Entered.");
                    }

                }
                GeneralUtilities.CheckWaitState(10);

            }
            else if(trackAuthorityType == "RW" && Authoritiesrepo.Create_Track_Authority.RACFIDTextInfo.Exists(0))
            {
                Authoritiesrepo.Create_Track_Authority.RACFIDText.Element.SetAttributeValue("Text", rwicUser);
                Authoritiesrepo.Create_Track_Authority.RACFIDText.PressKeys("{TAB}");
            }
            else
            {
                if(Authoritiesrepo.Create_Track_Authority.To.NonEngineToText.GetAttributeValue<string>("Text").Equals(rWOrOtWorker, StringComparison.OrdinalIgnoreCase))
                {
                    Ranorex.Report.Success("RW or OT worker value is already pre-selected");
                }
                else
                {
                    Authoritiesrepo.Create_Track_Authority.To.NonEngineToText.Element.SetAttributeValue("Text", rWOrOtWorker);
                    Authoritiesrepo.Create_Track_Authority.To.NonEngineToText.PressKeys("{TAB}");
                }

            }

            //Fill in the train 'at'
            if(Authoritiesrepo.Create_Track_Authority.At.AtText.GetAttributeValue<string>("Text").Equals(at, StringComparison.OrdinalIgnoreCase))
            {
                Ranorex.Report.Success("At location is already already pre-selected");
            }
            else
            {
                Authoritiesrepo.Create_Track_Authority.At.AtText.Click();
                Authoritiesrepo.Create_Track_Authority.At.AtText.Element.SetAttributeValue("Text", at);
                Authoritiesrepo.Create_Track_Authority.At.AtText.PressKeys("{TAB}");
            }


            if (!CheckFeedback(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback))
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Issues and validates any TE Authority
        /// </summary>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        [UserCodeMethod]
        public static void NS_ValidateAuthorityCommunicationsExchangeForm(bool box1Validate, string box2ProceedFrom, bool box2Fsw, string box2To1, string box2Track1,
                                                                          string box2To1HoldClearMain, string box2To2, string box2Track2, string box2To2HoldClearMain,
                                                                          string box2To3, string box2Track3, string box2To3HoldClearMain, bool box2Validate,
                                                                          string box3WorkBetweenFrom, bool box3FromCP, string box3To, bool box3ToCP, string box3Track1,
                                                                          string box3Track2, string box3Track3, string box3Track4, string box3Track5, bool box3Validate,
                                                                          string box4ProceedFrom, bool box4Fsw, string box4To1, string box4Track1,
                                                                          string box4To1HoldClearMain, string box4To2, string box4Track2, string box4To2HoldClearMain,
                                                                          string box4To3, string box4Track3, string box4To3HoldClearMain, bool box4Validate,
                                                                          string box5UntilInMinutes, bool box5Validate, string box6EngineSeed1, string box6Engine1Direction,
                                                                          string box6EngineSeed2, string box6Engine2Direction, string box6EngineSeed3,
                                                                          string box6Engine3Direction, bool box6Validate, bool box7, bool box7Validate,
                                                                          string box8EngineSeed1, string box8Engine1Direction, string box8EngineSeed2,
                                                                          string box8Engine2Direction, string box8EngineSeed3, string box8Engine3Direction,
                                                                          bool box8Validate, bool box9, bool box9Validate,
                                                                          string box10Between1, string box10Between2, bool box10Validate, string box11StopShort,
                                                                          string box11Track, bool box11Validate, string box12RWIC1, string box12Between1,
                                                                          string box12And1, string box12Track1, string box12RWIC2, string box12Between2,
                                                                          string box12And2, string box12Track2, string box12RWIC3, string box12Between3,
                                                                          string box12And3, string box12Track3, bool box12Validate, bool box13SubdivideLimits,
                                                                          string box13AutomaticInstructions, string box13ManualInstructions, bool box13Validate)
        {
            //TODO need to perform exchange validations here
            return;
        }

        [UserCodeMethod]
        public static void CompleteAuthorityIssue(string issueAuthorityCopiedBy, string issueAuthorityRelayingEmployee, string issueAuthorityAt, bool issueAuthorityPTCVoice)
        {
            int retries = 0;
            GeneralUtilities.CheckWaitState(3);
            if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                Ranorex.Report.Info("Communication Exchange form did not appear, waiting for some more time");

                while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0) && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }
            }
            Authoritiesrepo.Communications_Exchange_Ok_Authority.CopiedByText.Click();
            Authoritiesrepo.Communications_Exchange_Ok_Authority.CopiedByText.Element.SetAttributeValue("Text", issueAuthorityCopiedBy);
            Authoritiesrepo.Communications_Exchange_Ok_Authority.CopiedByText.PressKeys("{TAB}");

            //Click on Yes Button if Notification is displayed
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0))
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.YesButton.Click();
                Report.Info("Acknowledging the Notification Popup");
            }
            
            GeneralUtilities.CheckWaitState(3);
            Authoritiesrepo.Communications_Exchange_Ok_Authority.RelayingEmployeeText.Click();
            Authoritiesrepo.Communications_Exchange_Ok_Authority.RelayingEmployeeText.Element.SetAttributeValue("Text", issueAuthorityRelayingEmployee);
            Authoritiesrepo.Communications_Exchange_Ok_Authority.RelayingEmployeeText.PressKeys("{TAB}");

            GeneralUtilities.CheckWaitState(3);
            Authoritiesrepo.Communications_Exchange_Ok_Authority.RelayingAtText.Click();
            Authoritiesrepo.Communications_Exchange_Ok_Authority.RelayingAtText.Element.SetAttributeValue("Text", issueAuthorityAt);
            Authoritiesrepo.Communications_Exchange_Ok_Authority.RelayingAtText.PressKeys("{TAB}");

            //Click on Yes Button if Notification is displayed
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0))
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.YesButton.Click();
                Report.Info("Acknowledging the Notification Popup");
            }

            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsTextInfo.Exists(0))
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.Click();
                GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsTextInfo,
                                                          Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.YesInfo);
                Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.Yes.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.PressKeys("{TAB}");
                Authoritiesrepo.Communications_Exchange_Ok_Authority.RelayingEmployeeText.PressKeys("{TAB}");
            }

            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.ContinueButtonInfo,
                                                              Authoritiesrepo.Communications_Exchange_Ok_Authority.ContinueButtonInfo);

            retries = 0;
            while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0) && retries < 3)
            {
            	GeneralUtilities.CheckWaitState(10);
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0))
            {
                if (issueAuthorityPTCVoice)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo);
                } else {
                    //If we're waiting for a PTC Message to accept the authority, we can quit here.
                    return;
                }
            }
            retries = 0;
            while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0) && retries < 3)
            {
            	GeneralUtilities.CheckWaitState(10);
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
        }

        [UserCodeMethod]
        public static void CompleteAuthorityIssue(string authoritySeed, string issueAuthorityCopiedBy, string issueAuthorityRelayingEmployee, string issueAuthorityAt, bool issueAuthorityPTCVoice)
        {
            int retries = 0;
            GeneralUtilities.CheckWaitState(3);
            if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                Ranorex.Report.Info("Communication Exchange form did not appear, waiting for some more time");

                while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0) && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }
            }

            NS_Authorities.AddAuthorityNumber(authoritySeed);
            Authoritiesrepo.Communications_Exchange_Ok_Authority.CopiedByText.Click();
            Authoritiesrepo.Communications_Exchange_Ok_Authority.CopiedByText.Element.SetAttributeValue("Text", issueAuthorityCopiedBy);
            Authoritiesrepo.Communications_Exchange_Ok_Authority.CopiedByText.PressKeys("{TAB}");

            Authoritiesrepo.Communications_Exchange_Ok_Authority.RelayingEmployeeText.Element.SetAttributeValue("Text", issueAuthorityRelayingEmployee);
            Authoritiesrepo.Communications_Exchange_Ok_Authority.RelayingEmployeeText.PressKeys("{TAB}");

            Authoritiesrepo.Communications_Exchange_Ok_Authority.RelayingAtText.Element.SetAttributeValue("Text", issueAuthorityAt);
            Authoritiesrepo.Communications_Exchange_Ok_Authority.RelayingAtText.PressKeys("{TAB}");

            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.ContinueButtonInfo,
                                                              Authoritiesrepo.Communications_Exchange_Ok_Authority.ContinueButtonInfo);

            retries = 0;
            while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0) && retries < 3)
            {
            	GeneralUtilities.CheckWaitState(10);
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0))
            {
                if (issueAuthorityPTCVoice)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo);
                } else {
                    //If we're waiting for a PTC Message to accept the authority, we can quit here.
                    return;
                }
            }

            retries = 0;
            while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0) && retries < 3)
            {
            	GeneralUtilities.CheckWaitState(10);
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
        }
        
        
        /// <summary>
        /// Issues and validates any TE Authority
        /// </summary>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        [UserCodeMethod]
        public static void NS_IssueAuthorityFunction(string authoritySeed, string trackAuthorityType, string trainSeed, string engineSeed,
                                                     string rWOrOtWorker, string at, string box1TrackAuthorityNumber,
                                                     bool box1Validate, string box2ProceedFrom, bool box2Fsw, string box2To1, string box2Track1,
                                                     string box2To1HoldClearMain, string box2To2, string box2Track2, string box2To2HoldClearMain,
                                                     string box2To3, string box2Track3, string box2To3HoldClearMain, bool box2Validate,
                                                     string box3WorkBetweenFrom, bool box3FromCP, string box3To, bool box3ToCP, string box3Track1,
                                                     string box3Track2, string box3Track3, string box3Track4, string box3Track5, bool box3Validate,
                                                     string box4ProceedFrom, bool box4Fsw, string box4To1, string box4Track1,
                                                     string box4To1HoldClearMain, string box4To2, string box4Track2, string box4To2HoldClearMain,
                                                     string box4To3, string box4Track3, string box4To3HoldClearMain, bool box4Validate,
                                                     string box5UntilInMinutes, bool box5Validate, string box6EngineSeed1, string box6Engine1Direction,string box6EngineSeed2, string box6Engine2Direction,
                                                     string box6EngineSeed3, string box6Engine3Direction, string box6At, bool box6Validate, bool box7, bool box7Validate, string box8EngineSeed1,
                                                     string box8Engine1Direction, string box8EngineSeed2, string box8Engine2Direction,
                                                     string box8EngineSeed3, string box8Engine3Direction, bool box8Validate, bool box9, bool box9Validate,
                                                     string box10Between1, string box10Between2, bool box10Validate, string box11StopShort,
                                                     string box11Track, bool box11Validate, string box12RWIC1, string box12Between1,
                                                     string box12And1, string box12Track1, string box12RWIC2, string box12Between2,
                                                     string box12And2, string box12Track2, string box12RWIC3, string box12Between3,
                                                     string box12And3, string box12Track3, bool box12Validate, bool box13SubdivideLimits,
                                                     string box13AutomaticInstructions, string box13ManualInstructions, bool box13Validate,
                                                     bool pressIssue, bool completeAuthorityIssue, string issueAuthorityCopiedBy, string issueAuthorityRelayingEmployee,
                                                     string issueAuthorityAt, bool issueAuthorityPTCVoice, string expectedFeedback,string zones,
                                                     string box13SubdividedLimitsText, bool box13BetweenSide, bool box13AndSide, string rwicUser, bool limitsDoNotAdjoin=true, bool zonesSelect=true)
        {
            NS_OpenAuthorityForm_MainMenu(trackAuthorityType);


            //Show all available inputs on the Authorities Form
            Authoritiesrepo.Create_Track_Authority.RibbonMenu.LongForm.Click();


            bool success = NS_FillTrackAuthorityHeader(trackAuthorityType, trainSeed, engineSeed, rwicUser, rWOrOtWorker, at, expectedFeedback);
            string feedbackText = "";

            if (!success)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,
                                                                  Authoritiesrepo.Create_Track_Authority.SelfInfo);
                return;
            }

            //Perform Box1
            success = NS_FillBox1(box1TrackAuthorityNumber);
            if (!success)
            {
                CheckFeedback(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,Authoritiesrepo.Create_Track_Authority.SelfInfo);
                return;
            }

            //Perform Box2
            success = NS_FillBox2(box2ProceedFrom, box2Fsw, box2To1, box2Track1, box2To1HoldClearMain, box2To2, box2Track2, box2To2HoldClearMain, box2To3, box2Track3, box2To3HoldClearMain);
            if (!success)
            {
                //CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback);
                feedbackText =Authoritiesrepo.Create_Track_Authority.Feedback.GetAttributeValue<string>("Text");
                if(feedbackText.Contains("Required line 8") || feedbackText.Contains("Recommended line 8"))
                {
                    Ranorex.Report.Info("Feedback Text: "+feedbackText);
                }
                else
                {
                    CheckFeedback(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,Authoritiesrepo.Create_Track_Authority.SelfInfo);
                    return;
                }
            }

            GeneralUtilities.CheckWaitState(10);
            if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0))// && Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.TextWithAuthority.TextValue.Contains("O/T"))
            {
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButtonInfo,
            	                                                 Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);
            }
            
            GeneralUtilities.CheckWaitState(10);
            Ranorex.Delay.Seconds(1);
            String trainID = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            Bulletinsrepo.TrainID = trainID;
            if(Bulletinsrepo.Bulletin_Item_Relay.AddressTable.AddressLinesRowByTrainID.SelfInfo.Exists(0))
            {
            	Bulletinsrepo.Bulletin_Item_Relay.AddressTable.AddressLinesRowByTrainID.TCNumber.Click();
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Item_Relay.CloseButtonInfo,
            	                                                 Bulletinsrepo.Bulletin_Item_Relay.SelfInfo);
            }
            success = NS_FillBox3(box3WorkBetweenFrom, box3FromCP, box3To, box3ToCP, box3Track1, box3Track2, box3Track3, box3Track4, box3Track5,
                                  zones, limitsDoNotAdjoin, zonesSelect);
            if (!success)
            {
                //CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback);
                feedbackText =Authoritiesrepo.Create_Track_Authority.Feedback.GetAttributeValue<string>("Text");
                if(feedbackText.Contains("Required line 8") || feedbackText.Contains("Recommended line 8"))
                {
                    Ranorex.Report.Info("Feedback Text: "+feedbackText);
                }
                else
                {
                    CheckFeedback(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,Authoritiesrepo.Create_Track_Authority.SelfInfo);
                    return;
                }
//					if(Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0) && feedbackText!="")
//					{
//						if(Authoritiesrepo.Create_Track_Authority.CancelButton.Enabled)
//						{
//
//							GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,Authoritiesrepo.Create_Track_Authority.SelfInfo);
//						}
//					}
//					return;
            }
            
            GeneralUtilities.CheckWaitState(10);
            if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0))// && Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.TextWithAuthority.TextValue.Contains("O/T"))
            {
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButtonInfo,
            	                                                 Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);
            }
            GeneralUtilities.CheckWaitState(10);
            if(Bulletinsrepo.Bulletin_Item_Relay.AddressTable.SelfInfo.Exists(0))
            {
            	int rowCount = Bulletinsrepo.Bulletin_Item_Relay.AddressTable.Self.GetAttributeValue<int>("RowCount");
            	
            	for(int i =0; i<rowCount;i++)
            	{
            		Bulletinsrepo.AddressLinesRowIndex = i.ToString();
            		Ranorex.Report.Info("RW TO:"+Bulletinsrepo.Bulletin_Item_Relay.AddressTable.AddressLinesRowByIndex.To.Self.GetAttributeValue<string>("Text"));
            		if(Bulletinsrepo.Bulletin_Item_Relay.AddressTable.AddressLinesRowByIndex.To.Self.GetAttributeValue<string>("Text").Equals(rWOrOtWorker))
            		{
            			Bulletinsrepo.Bulletin_Item_Relay.AddressTable.AddressLinesRowByIndex.TCNumber.Click();
            			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Item_Relay.CloseButtonInfo,
            	                                                 Bulletinsrepo.Bulletin_Item_Relay.SelfInfo);
            			break;
            		}
            	}
            	
            }

            // If 'Specify Subdivided Limits' popup appears just handel it
            if(Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.SelfInfo.Exists(0))
            {
                if(Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.CancelButtonInfo.Exists(0))
                {
                    Ranorex.Report.Info("Clicking on Cancel button in SpecifySubdividedLimits popup");
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.CancelButtonInfo,
                                                                      Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.SelfInfo);
                }
            }

            //Perform Box4
            success = NS_FillBox4(box4ProceedFrom, box4Fsw, box4To1, box4Track1, box4To1HoldClearMain, box4To2, box4Track2, box4To2HoldClearMain, box4To3, box4Track3, box4To3HoldClearMain);
            if (!success)
            {
                CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback);
                feedbackText =Authoritiesrepo.Create_Track_Authority.Feedback.GetAttributeValue<string>("Text");
                if(feedbackText.Contains("Required line 8") || feedbackText.Contains("Recommended line 8"))
                {
                    Ranorex.Report.Info("Feedback Text: "+feedbackText);
                }
                else
                {
                    CheckFeedback(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,Authoritiesrepo.Create_Track_Authority.SelfInfo);
                    return;
                }
            }
            GeneralUtilities.CheckWaitState(10);
            if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0))// && Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.TextWithAuthority.TextValue.Contains("O/T"))
            {
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButtonInfo,
            	                                                 Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);
            }

            GeneralUtilities.CheckWaitState(10);
            //Perform Box5
            if (box5UntilInMinutes != "")
            {
                //expectedFeedback = "";
                int convertedIntegerValue;
                if (int.TryParse(box5UntilInMinutes, out convertedIntegerValue))
                {
                    System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(convertedIntegerValue);
                    string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("hh:mm tt");

                    box5UntilInMinutes = effectiveTimeDifferenceFormatted;
                }
            }
            success = NS_FillBox5(box5UntilInMinutes, expectedFeedback);
            if (!success)
            {
                //CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback);
                feedbackText =Authoritiesrepo.Create_Track_Authority.Feedback.GetAttributeValue<string>("Text");
                if(feedbackText.Contains("Required line 8") || feedbackText.Contains("Recommended line 8"))
                {
                    Ranorex.Report.Info("Feedback Text: "+feedbackText);
                }
                else
                {
                    if(!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback))
                    {
                        Ranorex.Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Self);
                        Ranorex.Report.Failure("Feedback received is not as expected");
                    }
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,Authoritiesrepo.Create_Track_Authority.SelfInfo);
                    return;
                }
            }

            //Uncheck Box 7, if user provided box7 value is False as after filling Box 6 if user unchecks Box7 then it clears Box6 data too.
            if(!box7 && Authoritiesrepo.Create_Track_Authority.Box7.Box7Checkbox.Checked)
            {
            	GeneralUtilities.UncheckCheckboxAdapterAndVerifyUnchecked(Authoritiesrepo.Create_Track_Authority.Box7.Box7CheckboxInfo);
            }
            GeneralUtilities.CheckWaitState(10);
            if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0))// && Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.TextWithAuthority.TextValue.Contains("O/T"))
            {
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButtonInfo,
            	                                                 Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);
            }
            //Perform Box6
            GeneralUtilities.CheckWaitState(10);
            success = NS_FillBox6(box6EngineSeed1, box6Engine1Direction, box6EngineSeed2, box6Engine2Direction, box6EngineSeed3, box6Engine3Direction, expectedFeedback);
            if (!success)
            {
                if(!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Self);
                    Ranorex.Report.Failure("Feedback received is not as expected");
                }
                else
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,Authoritiesrepo.Create_Track_Authority.SelfInfo);
                    return;
                }
            }

            //Perform Box7
            NS_ClickBox7(box7, limitsDoNotAdjoin);
            GeneralUtilities.CheckWaitState(10);
			if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0))// && Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.TextWithAuthority.TextValue.Contains("O/T"))
            {
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButtonInfo,
            	                                                 Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);
            }
			
			GeneralUtilities.CheckWaitState(10);
            //Perform Box8
            success = NS_FillBox8(box8EngineSeed1, box8Engine1Direction, box8EngineSeed2, box8Engine2Direction, box8EngineSeed3, box8Engine3Direction, expectedFeedback);
            if (!success)
            {
                if(!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Self);
                    Ranorex.Report.Failure("Feedback received is not as expected");
                }
                else
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,Authoritiesrepo.Create_Track_Authority.SelfInfo);
                    return;
                }
            }

            if(Authoritiesrepo.Create_Track_Authority.Feedback.TextValue != "" )
            {
                if(!CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Self);
                    Ranorex.Report.Failure("Feedback received is not as expected");
                }
                else
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,Authoritiesrepo.Create_Track_Authority.SelfInfo);
                    return;
                }
            }

            GeneralUtilities.CheckWaitState(10);
            //Perform Box9
            if(box9)
            {
                success = NS_FillBox9();
                if (!success)
                {
                    CheckFeedback(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,Authoritiesrepo.Create_Track_Authority.SelfInfo);
                    return;
                }
            }



            GeneralUtilities.CheckWaitState(10);
            //Perform Box10
            success = NS_FillBox10(box10Between1, box10Between2, expectedFeedback);
            if (!success)
            {
                CheckFeedback(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,Authoritiesrepo.Create_Track_Authority.SelfInfo);
                return;
            }

            //Perform Box11
            success = NS_FillBox11(box11StopShort, box11Track);
            if (!success)
            {
                CheckFeedbackExists(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,Authoritiesrepo.Create_Track_Authority.SelfInfo);
                return;
            }

            //Perform Box13
            string box13AutomaticInstructionsText = "";
            NS_FillBox13(authoritySeed, box13SubdivideLimits, box13SubdividedLimitsText, box13BetweenSide, box13AndSide, box13ManualInstructions, expectedFeedback);
            box13AutomaticInstructionsText = Authoritiesrepo.Create_Track_Authority.Box13.OtherInstructionsSystemText.TextValue;
            success = true;
            bool validationSuccess = true;
            //Start Validations within Trainsheet
            if (box6Validate)
            {
                validationSuccess = NS_ValidateBox6(box6EngineSeed1, box6Engine1Direction, box6EngineSeed2, box6Engine2Direction, box6EngineSeed3, box6Engine3Direction, box6At);
                if (!validationSuccess)
                {
                    success = false;
                }
            }

            if (box7Validate)
            {
                validationSuccess = NS_ValidateBox7(box7);
                if (!validationSuccess)
                {
                    success = false;
                }
            }

            if (box8Validate)
            {
                validationSuccess = NS_ValidateBox8(box8EngineSeed1, box8Engine1Direction, box8EngineSeed2, box8Engine2Direction, box8EngineSeed3, box8Engine3Direction);
                if (!validationSuccess)
                {
                    success = false;
                }
            }

            if (box9Validate)
            {
                validationSuccess = NS_ValidateBox9(box9);
                if (!validationSuccess)
                {
                    success = false;
                }
            }

            if (box10Validate)
            {
                validationSuccess = NS_ValidateBox10(box10Between1, box10Between2);
                if (!validationSuccess)
                {
                    success = false;
                }
            }

            if (box12Validate)
            {
                validationSuccess = NS_ValidateBox12(box12RWIC1, box12Between1, box12And1, box12Track1, box12RWIC2, box12Between2, box12And2, box12Track2,
                                                     box12RWIC3, box12Between3, box12And3, box12Track3);
                if (!validationSuccess)
                {
                    success = false;
                }
            }

            if (box13Validate)
            {
                validationSuccess = NS_ValidateBox13(box13AutomaticInstructions);
                if (!validationSuccess)
                {
                    success = false;
                }
            }

            //If PressIssue is false, we're done
            if (!pressIssue)
            {
                Ranorex.Report.Info("pressIssue set to false so ending here.");
                return;
            }

            //if we had a validation failure, do we want to kill the Authority, or push on? As of writing this, I say, push on!
            //Click on Issue button
            int retries = 0;
            while(!Authoritiesrepo.Create_Track_Authority.IssueButton.Enabled && retries < 3) {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (!Authoritiesrepo.Create_Track_Authority.IssueButton.Enabled)
            {
                Ranorex.Report.Info("Issue Button is not enabled when trying to issue");
            }

            Authoritiesrepo.Create_Track_Authority.IssueButton.Click();
            retries = 0;
            while (Authoritiesrepo.Create_Track_Authority.IssueButtonInfo.Exists(0) && retries < 4)
            {
                if (retries == 2)
                {
                    Authoritiesrepo.Create_Track_Authority.IssueButton.Click();
                }
                Ranorex.Delay.Seconds(1);
                retries++;
            }

            Report.Info("Clicked Issue Button to Issue Authority.");

            if (Authoritiesrepo.Create_Track_Authority.IssueButtonInfo.Exists(0))
            {
                if (!CheckFeedback(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,Authoritiesrepo.Create_Track_Authority.SelfInfo);
                    return;
                } else {
                    Ranorex.Report.Failure("Track Authority Failed to Issue.");
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,Authoritiesrepo.Create_Track_Authority.SelfInfo);
                    return;
                }
            }


            string authorityNumber = Authoritiesrepo.Communications_Exchange_Ok_Authority.AuthorityNumberText.TextValue;
            //Need to add authority number in object dictionary not authority seed
            if(!string.IsNullOrEmpty(box1TrackAuthorityNumber))
            {
            	box1TrackAuthorityNumber = NS_Authorities.GetAuthorityNumber(box1TrackAuthorityNumber);
            	if (box1TrackAuthorityNumber == null)
            	{
            		box1TrackAuthorityNumber = authoritySeed;
            	}
            }


            //Need to add authority to it's own authority object
            if (authoritySeed != "")
            {
                AddAuthorityToObjectDictionary(authoritySeed, trackAuthorityType, authorityNumber, trainSeed, engineSeed, issueAuthorityCopiedBy, rWOrOtWorker, at, box1TrackAuthorityNumber,
                                               box2ProceedFrom, box2Fsw, box2To1, box2Track1,
                                               box2To1HoldClearMain, box2To2, box2Track2, box2To2HoldClearMain,
                                               box2To3, box2Track3, box2To3HoldClearMain,
                                               box3WorkBetweenFrom, box3FromCP, box3To, box3ToCP, box3Track1,
                                               box3Track2, box3Track3, box3Track4, box3Track5,
                                               box4ProceedFrom, box4Fsw, box4To1, box4Track1,
                                               box4To1HoldClearMain, box4To2, box4Track2, box4To2HoldClearMain,
                                               box4To3, box4Track3, box4To3HoldClearMain,
                                               box5UntilInMinutes, box6EngineSeed1, box6Engine1Direction, box6EngineSeed2, box6Engine2Direction,
                                               box6EngineSeed3, box6Engine3Direction, box6At, box7, box8EngineSeed1, box8Engine1Direction,
                                               box8EngineSeed2, box8Engine2Direction, box8EngineSeed3, box8Engine3Direction, box9,
                                               box10Between1, box10Between2, box11StopShort,
                                               box11Track, box12RWIC1, box12Between1,
                                               box12And1, box12Track1, box12RWIC2, box12Between2,
                                               box12And2, box12Track2, box12RWIC3, box12Between3,
                                               box12And3, box12Track3, box13SubdivideLimits,
                                               box13AutomaticInstructionsText, box13ManualInstructions,zones,
                                               box13SubdividedLimitsText, box13BetweenSide, box13AndSide);
            }

            //After this point, the communications form should be shown, based on what has true for validate, we will also be validating on the form
            NS_ValidateAuthorityCommunicationsExchangeForm(box1Validate, box2ProceedFrom, box2Fsw, box2To1, box2Track1, box2To1HoldClearMain,
                                                           box2To2, box2Track2, box2To2HoldClearMain, box2To3, box2Track3, box2To3HoldClearMain,
                                                           box2Validate, box3WorkBetweenFrom, box3FromCP, box3To, box3ToCP, box3Track1,
                                                           box3Track2, box3Track3, box3Track4, box3Track5, box3Validate, box4ProceedFrom, box4Fsw,
                                                           box4To1, box4Track1, box4To1HoldClearMain, box4To2, box4Track2, box4To2HoldClearMain,
                                                           box4To3, box4Track3, box4To3HoldClearMain, box4Validate, box5UntilInMinutes, box5Validate,
                                                           box6EngineSeed1, box6Engine1Direction, box6EngineSeed2, box6Engine2Direction, box6EngineSeed3, box6Engine3Direction,
                                                           box6Validate, box7, box7Validate, box8EngineSeed1, box8Engine1Direction, box8EngineSeed2,
                                                           box8Engine2Direction, box8EngineSeed3, box8Engine3Direction, box8Validate, box9, box9Validate,
                                                           box10Between1, box10Between2, box10Validate, box11StopShort, box11Track, box11Validate,
                                                           box12RWIC1, box12Between1, box12And1, box12Track1, box12RWIC2, box12Between2, box12And2,
                                                           box12Track2, box12RWIC3, box12Between3, box12And3, box12Track3, box12Validate,
                                                           box13SubdivideLimits, box13AutomaticInstructions, box13ManualInstructions, box13Validate);

            //If we're issuing the authority, then we finish up here
            retries = 0;
            if (completeAuthorityIssue)
            {
                Ranorex.Report.Info("On Communication Exchange form");
                CompleteAuthorityIssue(issueAuthorityCopiedBy, issueAuthorityRelayingEmployee, issueAuthorityAt, issueAuthorityPTCVoice);

                while(Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0) && retries < 3){
                	GeneralUtilities.CheckWaitState(10);
                    Ranorex.Delay.Milliseconds(200);
                    retries++;
                }

                if(Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0)){
                    Report.Failure("Unable to acknowledge the Authority");
                }
            }

            return;
        }

        /// <summary>
        /// Compares feedback with regex of expectedFeedback
        /// </summary>
        /// <param name="feedback">Input:feedback</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        public static bool CheckFeedback(Adapter feeback, string expectedFeedback)
        {

            Regex expectedFeedbackRegex = new Regex(expectedFeedback);
            string feedbackText = feeback.GetAttributeValue<string>("Text");
            if (feedbackText == "" || feedbackText == " ")
            {
                //No feedback received, return
                return true;
            }
            if (expectedFeedback == "")
            {
                Ranorex.Report.Failure("Expected no feedback, got feedback of {"+feedbackText+"}.");
                return false;
            }
            if (expectedFeedbackRegex.IsMatch(feedbackText))
            {
                if(Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Self.Element);
                }

                Ranorex.Report.Success("Expected Regex feedback of {"+@expectedFeedbackRegex+"} found feedback {"+feedbackText+"}.");
                return false;
            }
            return true;
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
        /// Validate color of PTC Voice Form
        /// </summary>
        /// <param name="clickVoiceButton">Input:If True, Clicks voice button</param>
        /// <param name="clickAcknowledgeButton">Input:If True, Clicks acknowledge button following voice form</param>
        [UserCodeMethod]
        public static void ValidateYellowVoiceFormExistsFunction(bool clickVoiceButton, bool clickAcknowledgeButton)
        {
            if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("Voice Form not present");
                return;
            }

            string color = "Yellow";
            Ranorex.Adapter PTCVoiceForm = Authoritiesrepo.Communications_Exchange_Ok_Authority.Self;
            PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(PTCVoiceForm, color, true);

            if (clickVoiceButton)
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButton.Click();
            }

            if (clickAcknowledgeButton)
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButton.Click();
            }
            return;
        }

        /// <summary>
        /// Validate color of PTC Voice Form
        /// </summary>
        [UserCodeMethod]
        public static void ValidateGreenActiveAuthorityFormExistsFunction()
        {
            if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("PTC Active Authority Form not present");
                return;
            }

            string color = "Green";
            Ranorex.Adapter PTCActiveAuthorityForm = Authoritiesrepo.Communications_Exchange_Ok_Authority.Self;
            PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(PTCActiveAuthorityForm, color, true);

            return;
        }

        /// <summary>
        /// Validates the PTC Communication Form no longer exists
        /// </summary>
        [UserCodeMethod]
        public static void ValidatePTCCommunicationFormNoLongerExistsFunction()
        {
            int retries = 0;
            //Due to communications form encompassing several forms, we want to specify the voice button since it's unique to the form
            while (Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0) && retries < 5)
            {
                Ranorex.Delay.Seconds(1);
                retries++;
            }
            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0))
            {
                Ranorex.Report.Failure("PTC Communications Form still exists");
                return;
            }
            Ranorex.Report.Success("PTC Communications Form does not exist");
            return;
        }

        /// <summary>
        /// Validate authority exists on trackline
        /// </summary>
        /// <param name="authoritySeed">Input:Authority Seed for Authority to verify</param>
        /// <param name="validateExists">Input:if true, validates it exists, if false, validates it doesn't exist</param>
        [UserCodeMethod]
        public static void ValidateAuthorityOnTracklineFunction(string authoritySeed, bool validateExists)
        {
            if (!authorityDictionary.ContainsKey(authoritySeed))
            {
                Ranorex.Report.Error("No authority for authority seed {"+authoritySeed+"}.");
                return;
            }

            AuthorityObject authority = authorityDictionary[authoritySeed];
            //Authorities are displayed like a train and use trainid
            if (authority.trackAuthorityType == "TE") {
                Ranorex.Report.Info("Engine Seed:"+authority.engineSeed);
                Ranorex.Report.Info("Engine Initial:"+PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authority.trainSeed, authority.engineSeed).EngineInitial.ToString());
                Ranorex.Report.Info("Engine Number:"+PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authority.trainSeed, authority.engineSeed).EngineNumber.ToString());
                Tracklinerepo.TrainId = authority.authorityNumber + " " + PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(authority.trainSeed) + " ("+PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authority.trainSeed, authority.engineSeed).EngineInitial + " " + PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authority.trainSeed, authority.engineSeed).EngineNumber + ")";
            } else {
                Tracklinerepo.TrainId = authority.authorityNumber + " " + authority.rWOrOtWorker;
            }    
            if(Tracklinerepo.Trackline_Form.AuthorityObjectInfo.Exists(0))
            {
                if (validateExists)
                {
                    Ranorex.Report.Success("Track Authority with number {"+authority.authorityNumber+"} found on trackline");
                } else {
                    Ranorex.Report.Failure("Track Authority with number {"+authority.authorityNumber+"} found on trackline");
                }
            } else {
                if (validateExists)
                {
                    Ranorex.Report.Failure("Track Authority with number {"+authority.authorityNumber+"} not found on trackline");
                } else {
                    Ranorex.Report.Success("Track Authority with number {"+authority.authorityNumber+"} not found on trackline");
                }
            }     
            return;
        }


        /// <summary>
        /// This method will rollup the T/E Proceed Authority to rollupLocation
        /// </summary>
        /// <param name="rollupLocation">location upto where need to rollup</param>
        /// <param name="authoritySeed">Seed of the Authority you want to extend</param>
        /// <param name="expectedFeedback"> Feedback if need to validate the error message</param>
        /// <param name="openFromSummaryList"> True if needs to be opened from SummaryList else false to open from Trackline</param>
        /// <param name="issueAuthorityPTCVoice"> Will click the Voice button if true, if false it will end at voice form if it exists, otherwise complete it</param>
        /// <param name="closeForms"> Close the existing forms</param>
        ///
        [UserCodeMethod]
        public static void NS_Rollup_Authority(string rollupLocation, string authoritySeed, string expectedFeedback, bool openFromSummaryList, bool issueAuthorityPTCVoice, bool closeForms, bool pressCancel=false)
        {
            int retries = 0;

            //Open Authority either from Summary list or Trackline
            if(openFromSummaryList){
                NS_OpenAuthority_AuthoritySummaryList(authoritySeed);
            } else{
                NS_OpenAuthority_Trackline(authoritySeed);
            }


            //Waiting for the Authority form to open
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0) && retries < 5 )
            {
                Ranorex.Delay.Milliseconds(200);
                retries++;
            }


            if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("Failed to Open Authority");
                return;
            }


            //Enter the Rollup Location in Authority form and click tab
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendOSLocationText.Enabled)
            {
            	Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendOSLocationText.Click();
            	Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendOSLocationText.Element.SetAttributeValue("Text", rollupLocation);
            	Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendOSLocationText.PressKeys("{TAB}");
            }
            else
            {
            	Report.Warn("Rollup location field is not enabled, no action performed");
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                return;
            }
            
            Report.Info("Entered Rollup Location " + rollupLocation);
            GeneralUtilities.CheckWaitState(10);
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0))
            {
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.YesButtonInfo,
            	                                                 Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo);
            }
            if (!CheckFeedback(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback, expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo,Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                return;
            }

            //Click on Update button
            retries = 0;
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.UpdateButton.Enabled && retries < 3) {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.UpdateButton.Enabled)
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.UpdateButton.Click();
                GeneralUtilities.CheckWaitState(10);
                if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0))
                {
                	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.YesButtonInfo,
                	                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo);
                	GeneralUtilities.CheckWaitState(10);
                	if(Authoritiesrepo.Communications_Exchange_Ok_Authority.UpdateButtonInfo.Exists(0))
                	{
                		Authoritiesrepo.Communications_Exchange_Ok_Authority.UpdateButton.Click();
                	}
                }
                Report.Info("Clicked Update Button to Extend Authority");
            } else {
                Ranorex.Report.Failure("Update Button was not enabled after inputting Rollup location of {" + rollupLocation + "}");
                GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo,Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                return;
            }
            GeneralUtilities.CheckWaitState(10);

            if (!CheckFeedback(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback, expectedFeedback))
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                return;
            }
            if(pressCancel)
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo,Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                return;
            }

            retries = 0;
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            //Click on Yes Button if Notification is displayed
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0))
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.YesButton.Click();
                Report.Info("Acknowledging the Notification Popup");
            }

            //If form is PTC, handle here
            while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0) && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0))
            {
                if (issueAuthorityPTCVoice)
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButton.Click();
                } else {
                    Report.Success("Successfully Rolled up Authority to {"+rollupLocation+ "}");
                    return;
                }
            } else if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0) && issueAuthorityPTCVoice)
            {
                Report.Failure("Expected PTC Voice Form but none appeared");
            }

            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.UpdateButtonInfo.Exists(0))
            {
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.UpdateButtonInfo,
                                                             Authoritiesrepo.Communications_Exchange_Ok_Authority.UpdateButtonInfo);
            }
            //Wait for Acknowledge Button to exist and click it
            retries = 0;
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                GeneralUtilities.CheckWaitState(10);
                retries++;
            }

            
            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                Report.Info("Acknowledging the Rollup Authority request");
            } else {
                Ranorex.Report.Failure("Acknowledge Form did not appear for Rollup after inputting rollup location of {" + rollupLocation + "}");
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                return;
            }

            GeneralUtilities.CheckWaitState(10);
            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0))
            {
                Ranorex.Report.Failure("Communication Exhcnage Form for Track Authority Rollup did not disappear");
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                return;
            }


            Report.Success("Successfully Rolled up Authority location to {"+rollupLocation+ "}");

            if(closeForms){
                if (Authoritiesrepo.Track_Authority_Summary_List.SelfInfo.Exists(0))
                {
                    Authoritiesrepo.Track_Authority_Summary_List.WindowControls.Close.Click();
                }
            }

            return;

        }

        /// <summary>
        /// This Method will Extend Authority and it will add the extendTime to the current time and extend the TA by that much time.
        /// </summary>
        /// <param name="extendTime"> by how much do you want to extend the authority from current time</param>
        /// <param name="authoritySeed">Seed of the Authority you want to extend</param>
        /// <param name="expectedFeedback"> If you want to validate the feedback with expected Feedback value</param>
        /// <param name="openFromSummaryList"> True if needs to be opened from SummaryList else false to open from Trackline</param>
        /// <param name="issueAuthorityPTCVoice"> Will click the Voice button if true, if false it will end at voice form if it exists, otherwise complete it</param>
        /// <param name="closeForms"> Close the existing forms</param>
        [UserCodeMethod]
        public static void NS_Extend_Authority(string extendTime, string authoritySeed, string expectedFeedback, bool openFromSummaryList, bool issueAuthorityPTCVoice, bool closeForms)
        {

            int retries = 0;
            int convertedIntegerValue;
            string effectiveTimeDifferenceFormatted = "";

            if(openFromSummaryList){
                NS_OpenAuthority_AuthoritySummaryList(authoritySeed);
            } else{
                NS_OpenAuthority_Trackline(authoritySeed);
            }

            //If the value of extendTime is an integer, convert to time else, use that as the value to enter
            if (int.TryParse(extendTime, out convertedIntegerValue))
            {

                System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(convertedIntegerValue);
                effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("hh:mm tt");
            } else {
                effectiveTimeDifferenceFormatted = extendTime;
            }

            //Waiting for the Authority form to open
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0) && retries < 5 )
            {
                Ranorex.Delay.Milliseconds(200);
                retries++;
            }


            if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("Failed to Open Authority");
                return;
            }

            //Input ExtendTime
            Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendUntilText.Element.SetAttributeValue("Text",effectiveTimeDifferenceFormatted);
            Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendUntilText.PressKeys("{TAB}");
            Report.Info("Extending the Authority up to {" + effectiveTimeDifferenceFormatted + "}");

            if (!CheckFeedback(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback, expectedFeedback))
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                return;
            }

            //Click on Update button
            retries = 0;
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.UpdateButton.Enabled && retries < 3) {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.UpdateButton.Enabled)
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.UpdateButton.Click();
                Report.Info("Clicked Update Button to Extend Authority");
            } else {
                Ranorex.Report.Failure("Update Button was not enabled after inputting extend time of {" + effectiveTimeDifferenceFormatted + "}");
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                return;
            }

            if (!CheckFeedback(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback, expectedFeedback))
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                return;
            }

            retries = 0;
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            //Click on Yes Button if Notification is displayed
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0))
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.YesButton.Click();
                Report.Info("Acknowledging the Notification Popup");
            }

            //If form is PTC, handle here
            while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0) && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0))
            {
                if (issueAuthorityPTCVoice)
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButton.Click();
                } else {
                    Report.Success("Successfully Extended Authority time up to {"+effectiveTimeDifferenceFormatted+ "}");
                    return;
                }
            } else if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0) && issueAuthorityPTCVoice)
            {
                Report.Failure("Expected PTC Voice Form but none appeared");
            }

            //Wait for Acknowledge Button to exist and click it
            retries = 0;
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0))
            {
                AddExtendUntilTime(authoritySeed, effectiveTimeDifferenceFormatted);
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                Report.Info("Acknowledging the Extend Authority request");
            } else {
                Ranorex.Report.Failure("Acknowledge Form did not appear for Extending after inputting extend time of {" + effectiveTimeDifferenceFormatted + "}");
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                return;
            }

            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0))
            {
                Ranorex.Report.Failure("Communication Exchnage Form for Track Authority Extend did not disappear");
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                return;
            }


            Report.Success("Successfully Extended Authority time up to {"+effectiveTimeDifferenceFormatted+ "}");

            if(closeForms){
                if (Authoritiesrepo.Track_Authority_Summary_List.SelfInfo.Exists(0))
                {
                    Authoritiesrepo.Track_Authority_Summary_List.WindowControls.Close.Click();
                }
            }

            return;
        }

        /// <summary>
        /// Verify the list items are present
        /// </summary>
        /// <param name="checkBoxes">Label that will appear for the CheckBoxes</param>
        /// <param name="visible">True for find it in the list, False for ensure it is not in the list</param>
        [UserCodeMethod]
        public static void ValidateCheckboxItemPresent_CreateTrackAuthority(string checkBoxes, bool visible) {
            string[] checkBoxArray = checkBoxes.Split('|');
            bool result = false;
            foreach (string checkBox in checkBoxArray) {
                Authoritiesrepo.CheckboxName = checkBox;
                result = Authoritiesrepo.Create_Track_Authority.BoxCheckboxByCheckboxNameInfo.Exists(0);
                if (visible == true && result == true) {
                    Report.Success("Success", checkBox + " found in list as expected.");
                } else if (visible == false && result == false) {
                    Report.Success("Success", checkBox + " not found in list as expected.");
                } else {
                    Report.Failure("Failure", checkBox + " not in expected state '" + visible + "'.");
                }
            }
        }

        /// <summary>
        /// Select required line number in 'Create Authority Form'(e.g. Line6,7,8....13)
        /// </summary>
        /// <param name="lineNumbers">Input:LineNumbers(e.g. 6,7,8...13)</param>
        [UserCodeMethod]
        public static void SelectLineNumberFromSelectItemMenu(string lineNumbers)
        {
            string[] lineNumberArray = lineNumbers.Split('|');
            foreach(string lineNumber in lineNumberArray)
            {
                Authoritiesrepo.Item = lineNumber;
                Authoritiesrepo.Create_Track_Authority.SelectItem.SelectItemMenuButton.Click();
                Ranorex.Report.Info("Trying to select Line number : " + lineNumber);
                if( Authoritiesrepo.Create_Track_Authority.SelectItem.SelectItemMenuList.SelectItemMenuItemByItem.Visible)
                {
                    Authoritiesrepo.Create_Track_Authority.SelectItem.SelectItemMenuList.SelectItemMenuItemByItem.Click();
                    Ranorex.Report.Success("Successfully selected Line " + lineNumber);
                } else {
                    Ranorex.Report.Failure("Unable to find Line " + lineNumber);
                }
            }
        }

        /// <summary>
        /// Validate TE,OT and RW radiobuttons are selected or not as per expectation
        /// </summary>
        /// <param name="radioButtonTE">Input:Expected status of TE Radiobutton(True/False)</param>
        /// <param name="radioButtonOT">Input:Expected status of OT Radiobutton(True/False)</param>
        /// <param name="radioButtonRW">Input:Expected status of RW Radiobutton(True/False)</param>

        [UserCodeMethod]
        public static void ValidateAuthorityRadioButtonSelected(bool radioButtonTE, bool radioButtonOT, bool radioButtonRW)
        {


            bool radioButtonTEActStatus = Authoritiesrepo.Create_Track_Authority.TERadio.Checked;
            if(radioButtonTEActStatus == radioButtonTE)
            {
                Ranorex.Report.Success("Success", Authoritiesrepo.Create_Track_Authority.TERadio + " selected status is expected to be '" +radioButtonTE+ "' and found '" + radioButtonTEActStatus + "'.");
            } else {
                Ranorex.Report.Failure("Failure", Authoritiesrepo.Create_Track_Authority.TERadio + " is expected to be '" +radioButtonTE+ "' but found '" + radioButtonTEActStatus + "'.");
            }



            bool radioButtonOTActStatus = Authoritiesrepo.Create_Track_Authority.OTRadio.Checked;
            if(radioButtonOTActStatus ==radioButtonOT)
            {
                Ranorex.Report.Success("Success", Authoritiesrepo.Create_Track_Authority.OTRadio + " selected status is expected to be '" +radioButtonOT+ "' and found '" + radioButtonOTActStatus + "'.");
            } else {
                Ranorex.Report.Failure("Failure", Authoritiesrepo.Create_Track_Authority.OTRadio + " is expected to be '" +radioButtonOT+ "' but found '" + radioButtonOTActStatus + "'.");
            }



            bool radioButtonRWActStatus = Authoritiesrepo.Create_Track_Authority.RWRadio.Checked;
            if(radioButtonRWActStatus == radioButtonRW)
            {
                Ranorex.Report.Success("Success", Authoritiesrepo.Create_Track_Authority.RWRadio + " selected status is expected to be '" +radioButtonRW+ "' and found '" + radioButtonRWActStatus + "'.");
            } else {
                Ranorex.Report.Failure("Failure", Authoritiesrepo.Create_Track_Authority.RWRadio + " is expected to be '" +radioButtonRW+ "' but found '" + radioButtonRWActStatus + "'.");
            }

        }

        /// <summary>
        /// Note: Make sure that Craete TRack Autority form is in Expanded view before using this Usercode/Recording
        /// Validate Enable/Disable status of all the lines in 'Create Authority' long form based on value passed from the CSV. If user wants to validate one or multiple lines,
        /// user has to pass expected status of those lines form CSV and remaining can be left as blank.
        /// </summary>
        /// <param name="line#Status">Input:Expected status of lines that user wants to validate.
        ///													 line#Status param values are optional.
        ///													 Expected status of 'line#Status' could be 'TRUE' or 'FALSE' and could be blank if user does not want to validate that particular line#.
        ///													 </param>
        [UserCodeMethod]
        public static void ValidateEnableStatusOfLinesInAuthorityForm(string line1Status, string line2Status, string line3Status, string line4Status, string line5Status,
                                                                      string line6Status, string line7Status, string line8Status, string line9Status, string line10Status,
                                                                      string line11Status, string line12Status, string line13Status)
        {
            bool[] enableActStatus = new bool[]
            {Authoritiesrepo.Create_Track_Authority.Box1.VoidTrackAuthorityNumberText.Enabled,
                Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1Between.Enabled,
                Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenBetween.Enabled,
                Authoritiesrepo.Create_Track_Authority.Box4.Proceed1.Proceed2Between.Enabled,
                Authoritiesrepo.Create_Track_Authority.Box5.EffectiveUntilText.Enabled,
                Authoritiesrepo.Create_Track_Authority.Box6.Box6Checkbox.Enabled,
                Authoritiesrepo.Create_Track_Authority.Box7.Box7Checkbox.Enabled,
                Authoritiesrepo.Create_Track_Authority.Box8.Box8Checkbox.Enabled,
                Authoritiesrepo.Create_Track_Authority.Box9.Box9Checkbox.Enabled,
                Authoritiesrepo.Create_Track_Authority.Box10.TrainsSpeedRestrictionBetweenText.Enabled,
                Authoritiesrepo.Create_Track_Authority.Box11.StopShortPointText.Enabled,
                Authoritiesrepo.Create_Track_Authority.Box12.Box12Checkbox.Enabled,
                Authoritiesrepo.Create_Track_Authority.Box13.OtherInstructionsUserText.Enabled};

            string[] enableExpStatus = new string[]
            {line1Status, line2Status, line3Status, line4Status, line5Status,
                line6Status, line7Status, line8Status, line9Status, line10Status,
                line11Status, line12Status, line13Status};

            for(int i = 0; i < enableActStatus.Length; i++)
            {
                if(enableExpStatus[i].ToString() != "")
                {
                    if(enableActStatus[i] == bool.Parse(enableExpStatus[i]))
                    {
                        Ranorex.Report.Success("Success", "Line_" + (i + 1) + " enable status is expected to be '" + enableExpStatus[i] + "' and found '" + enableActStatus[i] + "'.");
                    } else {
                        Ranorex.Report.Failure("Failure", "Line_" + (i + 1) + " enable status is expected to be '" +enableExpStatus[i]+ "' but found '" + enableActStatus[i] + "'.");
                    }
                }
            }
        }

        [UserCodeMethod]
        public static void ValidateLineItemsChecked (string lineNumbers, bool status)
        {
            //ow wish we could just pass in arrays
            string[] lines = lineNumbers.Split('|');
            CheckBox currentBox = Authoritiesrepo.Create_Track_Authority.Box1.Box1Checkbox; //Lets try to avoid using null values
            foreach (string line in lines)
            {
                switch (line)
                {
                    case ("1"):
                        currentBox = Authoritiesrepo.Create_Track_Authority.Box1.Box1Checkbox;
                        break;
                    case ("2"):
                        currentBox = Authoritiesrepo.Create_Track_Authority.Box2.Box2Checkbox;
                        break;
                    case ("3"):
                        currentBox = Authoritiesrepo.Create_Track_Authority.Box3.Box3Checkbox;
                        break;
                    case ("4"):
                        currentBox = Authoritiesrepo.Create_Track_Authority.Box4.Box4Checkbox;
                        break;
                    case ("5"):
                        currentBox = Authoritiesrepo.Create_Track_Authority.Box5.Box5Checkbox;
                        break;
                    case ("6"):
                        currentBox = Authoritiesrepo.Create_Track_Authority.Box6.Box6Checkbox;
                        break;
                    case ("7"):
                        currentBox = Authoritiesrepo.Create_Track_Authority.Box7.Box7Checkbox;
                        break;
                    case ("8"):
                        currentBox = Authoritiesrepo.Create_Track_Authority.Box8.Box8Checkbox;
                        break;
                    case ("9"):
                        currentBox = Authoritiesrepo.Create_Track_Authority.Box9.Box9Checkbox;
                        break;
                    case ("10"):
                        currentBox = Authoritiesrepo.Create_Track_Authority.Box10.Box10Checkbox;
                        break;
                    case ("11"):
                        currentBox = Authoritiesrepo.Create_Track_Authority.Box11.Box11Checkbox;
                        break;
                    case ("12"):
                        currentBox = Authoritiesrepo.Create_Track_Authority.Box12.Box12Checkbox;
                        break;
                    case ("13"):
                        currentBox = Authoritiesrepo.Create_Track_Authority.Box13.Box13Checkbox;
                        break;
                    default:
                        Ranorex.Report.Error("Line item: " + line + " is not a valid line number.");
                        return;
                }
                if (currentBox.Checked == status)
                {
                    Ranorex.Report.Success("Line item " + line + " has expected status: " + status);
                }
                else
                {
                    Ranorex.Report.Failure("Line item " + line + " has unexpected status: " + !status);
                }
            }
        }
        /// <summary>
        /// Voids a particular Authority by Authority Seed
        /// </summary>
        /// <param name="authoritySeed">Input:Authority seed for the authority object</param>
        /// <param name="expectedFeedback">Input:Expected Feedback for failure cases using regex</param>
        /// <param name="openFromSummaryList">Input:If true, opens the authority from the summary list, else opens from the trackline</param>
        /// <param name="issueAuthorityPTCVoice"> Will click the Voice button if true, if false it will end at voice form if it exists, otherwise complete it</param>
        /// <param name="closeForms">Input:Closes Authority Summary List if open</param>
        [UserCodeMethod]
        public static void NS_VoidAuthorityFunctionFromDTAD(string authoritySeed, string expectedFeedback, bool issueAuthorityPTCVoice, bool closeForms)
        {

            int retries = 0;

            NS_OpenAuthority_DTAD(authoritySeed);

            var authorityObject = NS_Authorities.authorityDictionary[authoritySeed];

            //Waiting for the Authority form to open
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0) && retries < 5 )
            {
                Ranorex.Delay.Milliseconds(200);
                retries++;
            }


            if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("Failed to Open Authority");
                return;
            }

            if (authorityObject.trackAuthorityType == "RW")
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.No.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.PressKeys("{TAB}");
            }

            //Input Limits Reported Clear User
            Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.Click();
            Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.PressKeys(authorityObject.copiedBy);
            Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.PressKeys("{TAB}");
            Report.Info("Voiding Authority");

            if (!CheckFeedback(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback, expectedFeedback))
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                return;
            }

            if(!string.IsNullOrEmpty(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback.GetAttributeValue<string>("Text").ToString()))
            {
                GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButtonInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                return;
            }
            //Click on Clear button
            GeneralUtilities.CheckWaitState(10);

            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButton.Enabled)
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButton.Click();
                Report.Info("Clicked Clear Button to Void Authority");
            } else {
                Ranorex.Report.Failure("Clear Button was not enabled after inputting Limits Cleared By");
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                return;
            }

            if (!CheckFeedback(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback, expectedFeedback))
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                return;
            }

            retries = 0;
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            //Click on Yes Button if Notification is displayed
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0))
            {
                Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.YesButton.Click();
                Report.Info("Acknowledging the Notification Popup");
            }

            //If form is PTC, handle here
            while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0) && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0))
            {
                if (issueAuthorityPTCVoice)
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButton.Click();
                } else {
                    Report.Success("Successfully Voided Authority.");
                    return;
                }
            } else if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0) && issueAuthorityPTCVoice)
            {
                Report.Failure("Expected PTC Voice Form but none appeared");
            }

            //Wait for Acknowledge Button to exist and click it
            retries = 0;
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                Report.Info("Acknowledging the Void Authority request");
            } else {
                Ranorex.Report.Failure("Acknowledge Form did not appear for Voiding");
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                return;
            }

            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0))
            {
                Ranorex.Report.Failure("Communication Exchnage Form for Track Authority Void did not disappear");
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                return;
            }


            Report.Success("Successfully Voided Authority");

            if(closeForms){
                if (Authoritiesrepo.Track_Authority_Summary_List.SelfInfo.Exists(0))
                {
                    Authoritiesrepo.Track_Authority_Summary_List.WindowControls.Close.Click();
                }
            }

            return;
        }
        /// <summary>
        /// Validate Communication exchange form details
        /// </summary>
        /// <param name="AuthoritySeed"></param>
        /// <param name="authorityType"></param>
        /// <param name="To"></param>
        /// <param name="At"></param>
        /// <param name="CopiedBy"></param>
        /// <param name="RelayingEmployee"></param>
        /// <param name="RelayingAt"></param>
        /// <param name="ExtendUntil"></param>
        /// <param name="ExtendBy"></param>
        /// <param name="ExtendOSLocation"></param>
        /// <param name="Box1"></param>
        /// <param name="Box2"></param>
        /// <param name="Box3"></param>
        /// <param name="Box4"></param>
        /// <param name="Box5"></param>
        /// <param name="Box6"></param>
        /// <param name="Box7"></param>
        /// <param name="Box8"></param>
        /// <param name="Box9"></param>
        /// <param name="Box10"></param>
        /// <param name="Box11"></param>
        /// <param name="Box12"></param>
        /// <param name="Box13"></param>
        /// <param name="ExtendFSW"></param>
        /// <param name="ExtendRecordedTime"></param>
        /// <param name="AuthorityToVoid"></param>
        /// <param name="Box4Proceed2Between"></param>
        /// <param name="Box4Proceed2To1"></param>
        /// <param name="Box4Proceed2Track1"></param>
        /// <param name="Box4Proceed2To2"></param>
        /// <param name="Box4Proceed2Track2"></param>
        /// <param name="Box4Proceed2To3"></param>
        /// <param name="Box4Proceed2Track3"></param>
        /// <param name="Proceed1Between"></param>
        /// <param name="Proceed1To1"></param>
        /// <param name="Proceed1Track1"></param>
        /// <param name="Proceed1To2"></param>
        /// <param name="Proceed1Track2"></param>
        /// <param name="Proceed1To3"></param>
        /// <param name="Proceed1Track3"></param>
        /// <param name="WorkBetweenBetween"></param>
        /// <param name="WorkBetweenAnd"></param>
        /// <param name="WorkBetweenTrack1"></param>
        /// <param name="WorkBetweenTrack2"></param>
        /// <param name="WorkBetweenTrack3"></param>
        /// <param name="WorkBetweenTrack4"></param>
        /// <param name="WorkBetweenTrack5"></param>
        /// <param name="EffectiveUntil"></param>
        /// <param name="StopShortPoint"></param>
        /// <param name="StopShortTrack"></param>
        /// <param name="OpposingTrainField1Text"></param>
        /// <param name="OpposingTrainField2Text"></param>
        /// <param name="OpposingTrainField3Text"></param>
        /// <param name="OpposingTrainsLocationText"></param>
        /// <param name="TrainsToFollowTrainText"></param>
        /// <param name="TrainsToFollowTrain1Text"></param>
        /// <param name="TrainsToFollowTrain2Text"></param>
        /// <param name="TrainsSpeedRestrictionBetweenText"></param>
        /// <param name="TrainsSpeedRestrictionAndText"></param>
        /// <param name="box12RWIC1"></param>
        /// <param name="box12Between1"></param>
        /// <param name="box12And1"></param>
        /// <param name="box12Track1"></param>
        /// <param name="box12RWIC2"></param>
        /// <param name="box12Between2"></param>
        /// <param name="box12And2"></param>
        /// <param name="box12Track2"></param>
        /// <param name="box12RWIC3"></param>
        /// <param name="box12Between3"></param>
        /// <param name="box12And3"></param>
        /// <param name="box12Track3"></param>
        /// <param name="OtherInstructionsSystem"></param>
        /// <param name="OtherInstructionsUser"></param>
        [UserCodeMethod]
        public static void validateAuthorityDetails(string AuthoritySeed, string authorityType,string To, string At, string CopiedBy, string RelayingEmployee, string RelayingAt,string ExtendUntil,string ExtendBy,
                                                    string ExtendOSLocation, bool Box1,bool Box2,bool Box3,bool Box4,bool Box5,bool Box6,bool Box7,bool Box8,bool Box9,bool Box10,bool Box11,bool Box12,bool Box13,
                                                    bool ExtendFSW, string ExtendRecordedTime,string AuthorityToVoid,string Box4Proceed2Between, string Box4Proceed2To1,string Box4Proceed2Track1, string Box4Proceed2To2,
                                                    string Box4Proceed2Track2, string Box4Proceed2To3,string Box4Proceed2Track3, string Proceed1Between, string Proceed1To1,string Proceed1Track1, string Proceed1To2,
                                                    string Proceed1Track2, string Proceed1To3,string Proceed1Track3,string WorkBetweenBetween, string WorkBetweenAnd, string WorkBetweenTrack1, string WorkBetweenTrack2,
                                                    string WorkBetweenTrack3, string WorkBetweenTrack4, string WorkBetweenTrack5, string EffectiveUntil, string StopShortPoint, string StopShortTrack,
                                                    string OpposingTrainField1Text,string OpposingTrainField2Text,string OpposingTrainField3Text,string OpposingTrainsLocationText,
                                                    string TrainsToFollowTrainText,string TrainsToFollowTrain1Text,string TrainsToFollowTrain2Text,string TrainsSpeedRestrictionBetweenText, string TrainsSpeedRestrictionAndText,
                                                    string box12RWIC1, string box12Between1, string box12And1, string box12Track1, string box12RWIC2, string box12Between2, string box12And2, string box12Track2,
                                                    string box12RWIC3, string box12Between3,string box12And3, string box12Track3, string OtherInstructionsSystem, string OtherInstructionsUser, bool closeForm)
        {
            bool success=false;
            success=NS_ValidateMiscFromActiveAuthority( AuthoritySeed, To, At, CopiedBy,	RelayingEmployee,	RelayingAt, ExtendUntil, ExtendBy, ExtendOSLocation, ExtendFSW, ExtendRecordedTime);

            if (success)
            {
                Ranorex.Report.Success("Copied By, Relaying Employee, Relaying At,Extend Until,Extend By,Extend OS Location,Extend FSW,Extend Recorded Time values are as expected");
            }
            else
            {
                Ranorex.Report.Failure("Some of the values are not as expected");
            }

            if(Box1)
            {
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Box1.Box1CheckboxInfo.Exists() && Authoritiesrepo.Communications_Exchange_Ok_Authority.Box1.Box1Checkbox.Checked==true){
                    success=NS_ValidateBox1FromActiveAuthority(AuthorityToVoid);
                    DisplayMsg(success,"Box1");
                }
            }
            if(Box2)
            {
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Box2.Box2CheckboxInfo.Exists() && Authoritiesrepo.Communications_Exchange_Ok_Authority.Box2.Box2Checkbox.Checked==true){
                    success=NS_ValidateBox2FromActiveAuthority(Proceed1Between, Proceed1To1,Proceed1Track1, Proceed1To2,Proceed1Track2, Proceed1To3,Proceed1Track3);
                    DisplayMsg(success,"Box2");
                }
            }
            if(Box3)
            {
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Box3.Box3CheckboxInfo.Exists() && Authoritiesrepo.Communications_Exchange_Ok_Authority.Box3.Box3Checkbox.Checked==true){
                    success=NS_ValidateBox3FromActiveAuthority(WorkBetweenBetween, WorkBetweenAnd, WorkBetweenTrack1, WorkBetweenTrack2, WorkBetweenTrack3, WorkBetweenTrack4, WorkBetweenTrack5);
                    DisplayMsg(success,"Box3");
                }
            }
            if(Box4)
            {
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Box4.Box4CheckboxInfo.Exists() && Authoritiesrepo.Communications_Exchange_Ok_Authority.Box4.Box4Checkbox.Checked==true){
                    success=NS_ValidateBox4FromActiveAuthority(Box4Proceed2Between,	Box4Proceed2To1, Box4Proceed2Track1,	Box4Proceed2To2, Box4Proceed2Track2,	Box4Proceed2To3, Box4Proceed2Track3);
                    DisplayMsg(success,"Box4");
                }
            }
            if(Box5)
            {
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Box5.Box5CheckboxInfo.Exists() && Authoritiesrepo.Communications_Exchange_Ok_Authority.Box5.Box5Checkbox.Checked==true){
                    EffectiveUntil = authorityDictionary[AuthoritySeed].box5UntilInMinutes;
                    success=NS_ValidateBox5FromActiveAuthority(EffectiveUntil);
                    DisplayMsg(success,"Box5");
                }
            }
            if(Box6)
            {
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Box6.Box6CheckboxInfo.Exists() && Authoritiesrepo.Communications_Exchange_Ok_Authority.Box6.Box6Checkbox.Checked==true){
                    success=NS_ValidateBox6FromActiveAuthority(OpposingTrainField1Text, OpposingTrainField2Text, OpposingTrainField3Text,OpposingTrainsLocationText);
                    DisplayMsg(success,"Box6");
                }
            }
            if(Box7)
            {
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Box7.Box7CheckboxInfo.Exists() && Authoritiesrepo.Communications_Exchange_Ok_Authority.Box7.Box7Checkbox.Checked==true){
                    success=NS_ValidateBox7FromActiveAuthority();
                    DisplayMsg(success,"Box7");
                }
            }
            if(Box8)
            {
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Box8.Box8CheckboxInfo.Exists() && Authoritiesrepo.Communications_Exchange_Ok_Authority.Box8.Box8Checkbox.Checked==true){
                    success=NS_ValidateBox8FromActiveAuthority(TrainsToFollowTrainText, TrainsToFollowTrain1Text, TrainsToFollowTrain2Text);
                    DisplayMsg(success,"Box8");

                }
            }
            if(Box9)
            {
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Box9.Box9CheckboxInfo.Exists() && Authoritiesrepo.Communications_Exchange_Ok_Authority.Box9.Box9Checkbox.Checked==true)
                {
                    success=NS_ValidateBox9FromActiveAuthority();
                    DisplayMsg(success,"Box9");
                }
            }
            if(Box10)
            {
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Box10.Box10CheckboxInfo.Exists() && Authoritiesrepo.Communications_Exchange_Ok_Authority.Box10.Box10Checkbox.Checked==true)
                {
                    success=NS_ValidateBox10FromActiveAuthority(TrainsSpeedRestrictionBetweenText, TrainsSpeedRestrictionAndText);
                    DisplayMsg(success,"Box10");
                }
            }
            if(Box11)
            {
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Box11.Box11CheckboxInfo.Exists() && Authoritiesrepo.Communications_Exchange_Ok_Authority.Box11.Box11Checkbox.Checked==true)
                {
                    success=NS_ValidateBox11FromActiveAuthority(StopShortPoint, StopShortTrack);
                    DisplayMsg(success,"Box11");
                }
            }
            if(Box12)
            {
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.Box12CheckboxInfo.Exists() && Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.Box12Checkbox.Checked==true)
                {
                    success=NS_ValidateBox12FromActiveAuthority(box12RWIC1, box12Between1, box12And1, box12Track1, box12RWIC2, box12Between2, box12And2, box12Track2, box12RWIC3, box12Between3, box12And3, box12Track3);
                    DisplayMsg(success,"Box12");
                }
            }
            if(Box13)
            {
                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Box13.Box13CheckboxInfo.Exists() && Authoritiesrepo.Communications_Exchange_Ok_Authority.Box13.Box13Checkbox.Checked==true)
                {
                    success=NS_ValidateBox13FromActiveAuthority(OtherInstructionsSystem, OtherInstructionsUser);
                    DisplayMsg(success,"Box13");
                }
            }

            if(closeForm)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.clickItemIfItExists(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo);
                if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo.Exists(0))
                {
                    Ranorex.Report.Success("Communications Exchange Form closed");
                }
                else
                {
                    Ranorex.Report.Failure("Communications Exchange Form still open");
                }
            }
        }
        public static void DisplayMsg(bool success, string boxnumber)
        {
            if (success)
            {
                Ranorex.Report.Success(boxnumber+" - All values are as expected");
            }
            else
            {
                Ranorex.Report.Failure(boxnumber+" - some of the values are not as expected");
            }
        }
        /// <summary>
        /// Validate Box1	From Active Authority
        /// </summary>
        /// <param name="VoidTrackAuthorityNumberText"></param>
        /// <returns>bool</returns>
        [UserCodeMethod]
        public static bool NS_ValidateBox1FromActiveAuthority(string AuthorityToVoid)
        {
            bool success	= true;
            string AuthorityNumberToVoid = NS_Authorities.GetAuthorityNumber(AuthorityToVoid);
            string VoidAuthority = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box1.VoidTrackAuthorityNumberText.GetAttributeValue<string>("SelectedItemText");
            if (VoidAuthority != AuthorityNumberToVoid)
            {
                Ranorex.Report.Failure("Box 1 - Between found to be {"+VoidAuthority+"} when expected is {"+AuthorityNumberToVoid+"}.");
                success = false;
            }

            if (success)
            {
                Ranorex.Report.Success("Box 1 matches expected values of {{"+VoidAuthority+"}{"+AuthorityNumberToVoid+"}}");
            }
            return success;
        }
        /// <summary>
        /// Validate Box2 From Active Authority
        /// </summary>
        /// <param name="Proceed1Between"></param>
        /// <param name="Proceed1To1"></param>
        /// <param name="Proceed1Track1"></param>
        /// <param name="Proceed1To2"></param>
        /// <param name="Proceed1Track2"></param>
        /// <param name="Proceed1To3"></param>
        /// <param name="Proceed1Track3"></param>
        /// <returns>bool</returns>
        [UserCodeMethod]
        public static bool NS_ValidateBox2FromActiveAuthority(string Proceed1Between, string Proceed1To1,string Proceed1Track1, string Proceed1To2,string Proceed1Track2, string Proceed1To3,string Proceed1Track3)
        {
            bool success	= true;
            StringBuilder msg=new StringBuilder("Box 2 matches expected values of ");
            string P1B = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box2.Proceed1.Proceed1BetweenText.TextValue;
            if (P1B != Proceed1Between)
            {
                Ranorex.Report.Failure("Box 2 - Between found to be {"+P1B+"} when expected is {"+Proceed1Between+"}.");
                success = false;
            }
            else
            {
                msg.Append("{{"+P1B+"}{"+Proceed1Between+"}");
            }
            string P1T1 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box2.Proceed1.Proceed1To1Text.TextValue;
            if (P1T1 != Proceed1To1)
            {
                Ranorex.Report.Failure("Box 2 - To found to be {"+P1T1+"} when expected is {"+Proceed1To1+"}.");
                success = false;
            }
            else
            {
                msg.Append("{"+P1T1+"}{"+Proceed1To1+"}");
            }
            string P1Tr1 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box2.Proceed1.Proceed1Track1.TextValue;
            if (P1Tr1 != Proceed1Track1)
            {
                Ranorex.Report.Failure("Box 2 - Track found to be {"+P1Tr1+"} when expected is {"+Proceed1Track1+"}.");
                success = false;
            }
            else
            {
                msg.Append("{"+P1Tr1+"}{"+Proceed1Track1+"}");
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box2.Proceed2.Proceed1To2TextInfo.Exists(0))
            {
                string P1T2 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box2.Proceed2.Proceed1To2Text.TextValue;
                if (P1T2 != Proceed1To2)
                {
                    Ranorex.Report.Failure("Box 2 - To found to be {"+P1T2+"} when expected is {"+Proceed1To2+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+P1T2+"}{"+Proceed1To2+"}");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box2.Proceed2.Proceed1Track2Info.Exists(0))
            {
                string P1Tr2 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box2.Proceed2.Proceed1Track2.TextValue;
                if (P1Tr2 != Proceed1Track2)
                {
                    Ranorex.Report.Failure("Box 2 - Track found to be {"+P1Tr2+"} when expected is {"+Proceed1Track2+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+P1Tr2+"}{"+Proceed1Track2+"}");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box2.Proceed3.Proceed1To3TextInfo.Exists(0))
            {
                string P1T3 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box2.Proceed3.Proceed1To3Text.TextValue;
                if (P1T3 != Proceed1To3)
                {
                    Ranorex.Report.Failure("Box 2 - To found to be {"+P1T3+"} when expected is {"+Proceed1To3+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+P1T3+"}{"+Proceed1To3+"}");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box2.Proceed3.Proceed1Track3Info.Exists(0))
            {
                string P1Tr3 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box2.Proceed3.Proceed1Track3.TextValue;
                if (P1Tr3 != Proceed1Track3)
                {
                    Ranorex.Report.Failure("Box 2 - Track found to be {"+P1Tr3+"} when expected is {"+Proceed1Track3+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+P1Tr3+"}{"+Proceed1Track3+"}");
                }
            }
            if (success)
            {
                msg.Append("}");
                Ranorex.Report.Success(msg.ToString());
            }
            return success;
        }
        /// <summary>
        /// Validate Box3 From Active Authority
        /// </summary>
        /// <param name="WorkBetweenBetween"></param>
        /// <param name="WorkBetweenAnd"></param>
        /// <param name="WorkBetweenTrack1"></param>
        /// <param name="WorkBetweenTrack2"></param>
        /// <param name="WorkBetweenTrack3"></param>
        /// <param name="WorkBetweenTrack4"></param>
        /// <param name="WorkBetweenTrack5"></param>
        /// <returns>bool</returns>
        [UserCodeMethod]
        public static bool NS_ValidateBox3FromActiveAuthority(string WorkBetweenBetween, string WorkBetweenAnd, string WorkBetweenTrack1, string WorkBetweenTrack2, string WorkBetweenTrack3, string WorkBetweenTrack4, string WorkBetweenTrack5)
        {
            bool success	= true;
            StringBuilder msg=new StringBuilder();
            string WBB = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box3.WorkBetweenBetweenText.TextValue;
            if (WBB != WorkBetweenBetween)
            {
                Ranorex.Report.Failure("Box 3 Work between found to be {"+WBB+"} when expected is {"+WorkBetweenBetween+"}.");
                success = false;
            }
            else
            {
                msg.Append("Box 3 matches expected values of {{"+WBB+"}{"+WorkBetweenBetween+"}");
            }

            string WBA = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box3.WorkBetweenAndText.TextValue;
            if (WBA != WorkBetweenAnd)
            {
                Ranorex.Report.Failure("Box 3 Work Between And found to be {"+WBA+"} when expected is {"+WorkBetweenAnd+"}.");
                success = false;
            }
            else
            {
                msg.Append("{"+WBA+"}{"+WorkBetweenAnd+"}");
            }
            string WBT1 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box3.WorkBetweenTrack1Text.TextValue;
            if (WBT1 != WorkBetweenTrack1)
            {
                Ranorex.Report.Failure("Box 3 Work Between Track1 found to be {"+WBT1+"} when expected is {"+WorkBetweenTrack1+"}.");
                success = false;
            }
            else
            {
                msg.Append("{"+WBT1+"}{"+WorkBetweenTrack1+"}");
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box3.WorkBetweenTrack2TextInfo.Exists(0))
            {
                string WBT2 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box3.WorkBetweenTrack2Text.TextValue;
                if (WBT2 != WorkBetweenTrack2)
                {
                    Ranorex.Report.Failure("Box 3 Effective until time found to be {"+WBT2+"} when expected is {"+WorkBetweenTrack2+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+WBT2+"}{"+WorkBetweenTrack2+"}");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box3.WorkBetweenTrack3TextInfo.Exists(0))
            {
                string WBT3 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box3.WorkBetweenTrack3Text.TextValue;
                if (WBT3 != WorkBetweenTrack3)
                {
                    Ranorex.Report.Failure("Box 3 Effective until time found to be {"+WBT3+"} when expected is {"+WorkBetweenTrack3+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+WBT3+"}{"+WorkBetweenTrack3+"}");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box3.WorkBetweenTrack4TextInfo.Exists(0))
            {
                string WBT4 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box3.WorkBetweenTrack4Text.TextValue;
                if (WBT4 != WorkBetweenTrack4)
                {
                    Ranorex.Report.Failure("Box 3 Effective until time found to be {"+WBT4+"} when expected is {"+WorkBetweenTrack4+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+WBT4+"}{"+WorkBetweenTrack4+"}");
                }
            }

            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box3.WorkBetweenTrack5TextInfo.Exists(0))
            {
                string WBT5 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box3.WorkBetweenTrack5Text.TextValue;
                if (WBT5 != WorkBetweenTrack5)
                {
                    Ranorex.Report.Failure("Box 3 Effective until time found to be {"+WBT5+"} when expected is {"+WorkBetweenTrack5+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+WBT5+"}{"+WorkBetweenTrack5+"}");
                }
            }
            msg.Append("}");
            if (success)
            {
                Ranorex.Report.Success(msg.ToString());
            }
            return success;
        }
        /// <summary>
        /// Validate Box4 From Active Authority
        /// </summary>
        /// <param name="Proceed2Between"></param>
        /// <param name="Proceed2To1"></param>
        /// <param name="Proceed2Track1"></param>
        /// <param name="Proceed2To2"></param>
        /// <param name="Proceed2Track2"></param>
        /// <param name="Proceed2To3"></param>
        /// <param name="Proceed2Track3"></param>
        /// <returns></returns>
        [UserCodeMethod]
        public static bool NS_ValidateBox4FromActiveAuthority(string Box4Proceed2Between, string Box4Proceed2To1,string Box4Proceed2Track1, string Box4Proceed2To2,string Box4Proceed2Track2, string Box4Proceed2To3,string Box4Proceed2Track3)
        {
            bool success	= true;
            StringBuilder msg=new StringBuilder("Box 4 matches expected values of ");
            string P1B = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box4.Proceed1.Proceed2BetweenText.TextValue;
            if (P1B != Box4Proceed2Between)
            {
                Ranorex.Report.Failure("Box 4 - Between found to be {"+P1B+"} when expected is {"+Box4Proceed2Between+"}.");
                success = false;
            }
            else
            {
                msg.Append("{{"+P1B+"}{"+Box4Proceed2Between+"}");
            }
            string P1T1 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box4.Proceed1.Proceed2To1Text.TextValue;
            if (P1T1 != Box4Proceed2To1)
            {
                Ranorex.Report.Failure("Box 2 - To found to be {"+P1T1+"} when expected is {"+Box4Proceed2To1+"}.");
                success = false;
            }
            else
            {
                msg.Append("{"+P1T1+"}{"+Box4Proceed2To1+"}");
            }
            string P1Tr1 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box4.Proceed1.Proceed2Track1.TextValue;
            if (P1Tr1 != Box4Proceed2Track1)
            {
                Ranorex.Report.Failure("Box 2 - Track found to be {"+P1Tr1+"} when expected is {"+Box4Proceed2Track1+"}.");
                success = false;
            }
            else
            {
                msg.Append("{"+P1Tr1+"}{"+Box4Proceed2Track1+"}");
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box4.Proceed2.Proceed2To2TextInfo.Exists(0))
            {
                string P1T2 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box4.Proceed2.Proceed2To2Text.TextValue;
                if (P1T2 != Box4Proceed2To2)
                {
                    Ranorex.Report.Failure("Box 2 - To found to be {"+P1T2+"} when expected is {"+Box4Proceed2To2+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+P1T2+"}{"+Box4Proceed2To2+"}");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box4.Proceed2.Proceed2Track2Info.Exists(0))
            {
                string P1Tr2 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box4.Proceed2.Proceed2Track2.TextValue;
                if (P1Tr2 != Box4Proceed2Track2)
                {
                    Ranorex.Report.Failure("Box 2 - Track found to be {"+P1Tr2+"} when expected is {"+Box4Proceed2Track2+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+P1Tr2+"}{"+Box4Proceed2Track2+"}");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box4.Proceed3.Proceed2To3TextInfo.Exists(0))
            {
                string P1T3 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box4.Proceed3.Proceed2To3Text.TextValue;
                if (P1T3 != Box4Proceed2To3)
                {
                    Ranorex.Report.Failure("Box 2 - To found to be {"+P1T3+"} when expected is {"+Box4Proceed2To3+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+P1T3+"}{"+Box4Proceed2To3+"}");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box4.Proceed3.Proceed2Track3Info.Exists(0))
            {
                string P1Tr3 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box4.Proceed3.Proceed2Track3.TextValue;
                if (P1Tr3 != Box4Proceed2Track3)
                {
                    Ranorex.Report.Failure("Box 2 - Track found to be {"+P1Tr3+"} when expected is {"+Box4Proceed2Track3+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+P1Tr3+"}{"+Box4Proceed2Track3+"}");
                }
            }
            if (success)
            {
                msg.Append("}");
                Ranorex.Report.Success(msg.ToString());
            }
            return success;
        }
        /// <summary>
        /// Validate Box5 From Active Authority
        /// </summary>
        /// <param name="EffectiveUntil">Authority is effective until what time</param>
        /// <returns>Bool</returns>
        [UserCodeMethod]
        public static bool NS_ValidateBox5FromActiveAuthority(string EffectiveUntil)
        {
            bool success	= true;

            string Time = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box5.EffectiveUntilText.TextValue;
            if (!Time.Contains(EffectiveUntil))
            {
                Ranorex.Report.Failure("Box 5 Effective until time found to be {"+Time+"} when expected is {"+EffectiveUntil+"}.");
                success = false;
            }

            if (success)
            {
                Ranorex.Report.Success("Box 5 matches expected values of {{"+Time+"}{"+EffectiveUntil+"}}");
            }
            return success;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="OpposingTrainField1Text"></param>
        /// <param name="OpposingTrainField2Text"></param>
        /// <param name="OpposingTrainField3Text"></param>
        /// <param name="OpposingTrainsLocationText"></param>
        /// <returns></returns>
        [UserCodeMethod]
        public static bool NS_ValidateBox6FromActiveAuthority(string OpposingTrainField1Text,string OpposingTrainField2Text,string OpposingTrainField3Text,string OpposingTrainsLocationText)
        {
            bool success	= true;

            string OTF1 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box6.OpposingTrainField1Text.TextValue;
            if (OTF1!=OpposingTrainField1Text)
            {
                Ranorex.Report.Failure("Box 6 Opposing Train Field1 Text found to be {"+OTF1+"} when expected is {"+OpposingTrainField1Text+"}.");
                success = false;
            }
            string OTF2 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box6.OpposingTrainField2Text.TextValue;
            if (OTF2!=OpposingTrainField2Text)
            {
                Ranorex.Report.Failure("Box 6 Opposing Train Field2 Text found to be {"+OTF2+"} when expected is {"+OpposingTrainField2Text+"}.");
                success = false;
            }
            string OTF3 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box6.OpposingTrainField3Text.TextValue;
            if (OTF3!=OpposingTrainField3Text)
            {
                Ranorex.Report.Failure("Box 6 Opposing Train Field3 Text found to be {"+OTF3+"} when expected is {"+OpposingTrainField3Text+"}.");
                success = false;
            }
            string OTL = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box6.OpposingTrainsLocationText.TextValue;
            if (OTL!=OpposingTrainsLocationText)
            {
                Ranorex.Report.Failure("Box 6 Opposing Trains Location Text found to be {"+OTL+"} when expected is {"+OpposingTrainsLocationText+"}.");
                success = false;
            }

            if (success)
            {
                Ranorex.Report.Success("Box 6 matches expected values of {{"+OTF1+"}{"+OpposingTrainField1Text+"}} {{"+OTF2+"}{"+OpposingTrainField2Text+"}} {{"+OTF3+"}{"+OpposingTrainField3Text+"}} {{"+OTL+"}{"+OpposingTrainsLocationText+"}}");
            }
            return success;
        }
        [UserCodeMethod]
        public static bool NS_ValidateBox7FromActiveAuthority()
        {
            return true;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="TrainsToFollowTrainText"></param>
        /// <param name="TrainsToFollowTrain1Text"></param>
        /// <param name="TrainsToFollowTrain2Text"></param>
        /// <returns></returns>
        [UserCodeMethod]
        public static bool NS_ValidateBox8FromActiveAuthority(string TrainsToFollowTrainText,string TrainsToFollowTrain1Text,string TrainsToFollowTrain2Text)
        {
            bool success=true;
            string TTFT = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box8.TrainsToFollowTrain1Text.TextValue;
            if (TTFT!=TrainsToFollowTrainText)
            {
                Ranorex.Report.Failure("Box 8 Opposing Trains Location Text found to be {"+TTFT+"} when expected is {"+TrainsToFollowTrainText+"}.");
                success = false;
            }

            string TTFT1 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box8.TrainsToFollowTrain2Text.TextValue;
            if (TTFT1!=TrainsToFollowTrain1Text)
            {
                Ranorex.Report.Failure("Box 8 Opposing Trains Location Text found to be {"+TTFT1+"} when expected is {"+TrainsToFollowTrain1Text+"}.");
                success = false;
            }

            string TTFT2 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box8.TrainsToFollowTrainText.TextValue;
            if (TTFT2!=TrainsToFollowTrain2Text)
            {
                Ranorex.Report.Failure("Box 8 Opposing Trains Location Text found to be {"+TTFT2+"} when expected is {"+TrainsToFollowTrain2Text+"}.");
                success = false;
            }

            if (success)
            {
                Ranorex.Report.Success("Box 8 matches expected values of {{"+TTFT+"}{"+TrainsToFollowTrainText+"}} - {{"+TTFT1+"}{"+TrainsToFollowTrain1Text+"}} - {{"+TTFT2+"}{"+TrainsToFollowTrain2Text+"}}");
            }
            return success;
        }
        [UserCodeMethod]
        public static bool NS_ValidateBox9FromActiveAuthority()
        {
            return true;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="TrainsSpeedRestrictionBetweenText"></param>
        /// <param name="TrainsSpeedRestrictionAndText"></param>
        /// <returns></returns>
        [UserCodeMethod]
        public static bool NS_ValidateBox10FromActiveAuthority(string TrainsSpeedRestrictionBetweenText, string TrainsSpeedRestrictionAndText)
        {
            bool success	= true;

            string TSRB = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box10.TrainsSpeedRestrictionBetweenText.SelectedItemText;
            if (TSRB != TrainsSpeedRestrictionBetweenText)
            {
                Ranorex.Report.Failure("Box 10 Trains Speed Restriction Between found to be {"+TSRB+"} when expected is {"+TrainsSpeedRestrictionBetweenText+"}.");
                success = false;
            }
            string TSRA = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box10.TrainsSpeedRestrictionAndText.SelectedItemText;
            if (TSRA != TrainsSpeedRestrictionAndText)
            {
                Ranorex.Report.Failure("Box 10 Trains Speed Restriction And found to be {"+TSRA+"} when expected is {"+TrainsSpeedRestrictionAndText+"}.");
                success = false;
            }

            if (success)
            {
                Ranorex.Report.Success("Box 10 matches expected values of {{"+TSRB+"}{"+TrainsSpeedRestrictionBetweenText+"}} {{"+TSRA+"}{"+TrainsSpeedRestrictionAndText+"}}");
            }
            return success;
        }
        /// <summary>
        /// Validate Box11 From Active Authority
        /// </summary>
        /// <param name="StopShortPoint"></param>
        /// <param name="StopShortTrack"></param>
        /// <returns>Bool</returns>
        [UserCodeMethod]
        public static bool NS_ValidateBox11FromActiveAuthority(string StopShortPoint, string StopShortTrack)
        {
            bool success	= true;

            string SSP = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box11.StopShortPointText.SelectedItemText;
            if (SSP != StopShortPoint)
            {
                Ranorex.Report.Failure("Box 11 Stop Short Point found to be {"+SSP+"} when expected is {"+StopShortPoint+"}.");
                success = false;
            }
            string SST = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box11.StopShortTrackText.SelectedItemText;
            if (SST != StopShortTrack)
            {
                Ranorex.Report.Failure("Box 11 Stop Short Track found to be {"+SST+"} when expected is {"+StopShortTrack+"}.");
                success = false;
            }

            if (success)
            {
                Ranorex.Report.Success("Box 11 matches expected values of {{"+SSP+"}{"+SST+"}}");
            }
            return success;
        }
        /// <summary>
        /// Validate Box12 From Active Authority
        /// </summary>
        /// <param name="box12RWIC1">First RW Authority</param>
        /// <param name="box12Between1">First RW Authority Between field</param>
        /// <param name="box12And1">First RW Authority And field</param>
        /// <param name="box12Track1">First RW Authority Track field</param>
        /// <param name="box12RWIC2">Second RW Authority</param>
        /// <param name="box12Between2">Second RW Authority Between field</param>
        /// <param name="box12And2">Second RW Authority And field</param>
        /// <param name="box12Track2">Second RW Authority Track field</param>
        /// <param name="box12RWIC3">Third RW Authority</param>
        /// <param name="box12Between3">Third RW Authority Between field</param>
        /// <param name="box12And3">Third RW Authority And field</param>
        /// <param name="box12Track3">Third RW Authority Track field</param>
        /// <returns>Bool</returns>
        [UserCodeMethod]
        public static bool NS_ValidateBox12FromActiveAuthority(string box12RWIC1, string box12Between1, string box12And1, string box12Track1, string box12RWIC2,
                                                               string box12Between2, string box12And2, string box12Track2, string box12RWIC3, string box12Between3,
                                                               string box12And3, string box12Track3)
        {
            bool success	= true;
            StringBuilder msg=new StringBuilder();


            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC1.WorkersInChargeName1TextInfo.Exists())
            {
                string RWICName1 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC1.WorkersInChargeName1Text.TextValue;
                if (RWICName1 != box12RWIC1)
                {
                    Ranorex.Report.Failure("Box 12 First RWIC Name found to be {"+RWICName1+"} when expected is {"+box12RWIC1+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("Box 12 matches expected values of {{"+RWICName1+"}{"+box12RWIC1+"}");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC1.WorkersInChargeBetween1TextInfo.Exists())
            {
                string RWICBetween1 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC1.WorkersInChargeBetween1Text.TextValue;
                if (RWICBetween1 != box12Between1)
                {
                    Ranorex.Report.Failure("Box 12 First RWIC Between found to be {"+RWICBetween1+"} when expected is {"+box12Between1+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+RWICBetween1+"}{"+box12Between1+"}");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC1.WorkersInChargeAnd1TextInfo.Exists())
            {
                string RWICAnd1 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC1.WorkersInChargeAnd1Text.TextValue;
                if (RWICAnd1 != box12And1)
                {
                    Ranorex.Report.Failure("Box 12 First RWIC And found to be {"+RWICAnd1+"} when expected is {"+box12And1+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+RWICAnd1+"}{"+box12And1+"}");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC1.WorkersInChargeTrack1TextInfo.Exists())
            {
                string RWICTrack1 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC1.WorkersInChargeTrack1Text.TextValue;
                if (RWICTrack1 != box12Track1)
                {
                    Ranorex.Report.Failure("Box 12 First RWIC Track found to be {"+RWICTrack1+"} when expected is {"+box12Track1+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+RWICTrack1+"}{"+box12Track1+"}}");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC2.WorkersInChargeName2TextInfo.Exists())
            {
                string RWICName2 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC2.WorkersInChargeName2Text.TextValue;
                if (RWICName2 != box12RWIC2)
                {
                    Ranorex.Report.Failure("Box 12 Second RWIC Name found to be {"+RWICName2+"} when expected is {"+box12RWIC2+"}.");
                    success = false;
                }
                else
                {
                    msg.Append(" {{"+RWICName2+"}{"+box12RWIC2+"}");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC2.WorkersInChargeBetween2TextInfo.Exists())
            {
                string RWICBetween2 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC2.WorkersInChargeBetween2Text.TextValue;
                if (RWICBetween2 != box12Between2)
                {
                    Ranorex.Report.Failure("Box 12 Second RWIC Between found to be {"+RWICBetween2+"} when expected is {"+box12Between2+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+RWICBetween2+"}{"+box12Between2+"}");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC2.WorkersInChargeAnd2TextInfo.Exists())
            {
                string RWICAnd2 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC2.WorkersInChargeAnd2Text.TextValue;
                if (RWICAnd2 != box12And2)
                {
                    Ranorex.Report.Failure("Box 12 Second RWIC And found to be {"+RWICAnd2+"} when expected is {"+box12And2+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+RWICAnd2+"}{"+box12And2+"}");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC2.WorkersInChargeAnd2TextInfo.Exists())
            {
                string RWICTrack2 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC2.WorkersInChargeTrack2Text.TextValue;
                if (RWICTrack2 != box12Track2)
                {
                    Ranorex.Report.Failure("Box 12 Second RWIC Track found to be {"+RWICTrack2+"} when expected is {"+box12Track2+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+RWICTrack2+"}{"+box12Track2+"}} ");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC3.WorkersInChargeName3TextInfo.Exists())
            {
                string RWICName3 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC3.WorkersInChargeName3Text.TextValue;
                if (RWICName3 != box12RWIC3)
                {
                    Ranorex.Report.Failure("Box 12 Third RWIC Name found to be {"+RWICName3+"} when expected is {"+box12RWIC3+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{{"+RWICName3+"}{"+box12RWIC3+"}");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC3.WorkersInChargeBetween3TextInfo.Exists())
            {
                string RWICBetween3 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC3.WorkersInChargeBetween3Text.TextValue;
                if (RWICBetween3 != box12Between3)
                {
                    Ranorex.Report.Failure("Box 12 Third RWIC Between found to be {"+RWICBetween3+"} when expected is {"+box12Between3+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+RWICBetween3+"}{"+box12Between3+"}");
                }
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC3.WorkersInChargeAnd3TextInfo.Exists())
            {
                string RWICAnd3 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC3.WorkersInChargeAnd3Text.TextValue;
                if (RWICAnd3 != box12And3)
                {
                    Ranorex.Report.Failure("Box 12 Third RWIC And found to be {"+RWICAnd3+"} when expected is {"+box12And3+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+RWICAnd3+"}{"+box12And3+"}");
                }
            }

            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC3.WorkersInChargeTrack3TextInfo.Exists())
            {
                string RWICTrack3 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.RWIC3.WorkersInChargeTrack3Text.TextValue;
                if (RWICTrack3 != box12Track3)
                {
                    Ranorex.Report.Failure("Box 12 Third RWIC Track found to be {"+RWICTrack3+"} when expected is {"+box12Track3+"}.");
                    success = false;
                }
                else
                {
                    msg.Append("{"+RWICTrack3+"}{"+box12Track3+"}");
                }
            }
            msg.Append("}");
            if (success)
            {
                Ranorex.Report.Success(msg.ToString());
            }
            return success;
        }
        /// <summary>
        /// Validate Box13 From Active Authority
        /// </summary>
        /// <param name="OtherInstructionsSystem"></param>
        /// <param name="OtherInstructionsUser"></param>
        /// <returns>bool</returns>
        [UserCodeMethod]
        public static bool NS_ValidateBox13FromActiveAuthority(string OtherInstructionsSystem, string OtherInstructionsUser)
        {
            bool success	= true;
            string OIS = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box13.OtherInstructionsSystemText.GetAttributeValue<string>("Text").Trim();
            OIS=OIS.Replace("\n","");
            OtherInstructionsSystem=OtherInstructionsSystem.Replace("\n","");
            if (!OIS.Equals(OtherInstructionsSystem))
            {
                Ranorex.Report.Failure("Box 13 Other Instructions System found to be {"+OIS+"} when expected is {"+OtherInstructionsSystem+"}");
                success = false;
            }
            string OIU = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box13.OtherInstructionsUserText.TextValue;
            if (OIU != OtherInstructionsUser)
            {
                Ranorex.Report.Failure("Box 13 Other Instructions User found to be {"+OIU+"} when expected is {"+OtherInstructionsUser+"}.");
                success = false;
            }

            if (success)
            {
                Ranorex.Report.Success("Box 13 matches expected values of {{"+OIS+"}{"+OIU+"}}");
            }
            return success;
        }

        /// <summary>
        /// Validate Misc From Active Authority
        /// </summary>
        /// <param name="AuthorityNumber"></param>
        /// <param name="EngineToText"></param>
        /// <param name="Attext"></param>
        /// <param name="CopiedBy"></param>
        /// <param name="RelayingEmployee"></param>
        /// <param name="RelayingAt"></param>
        /// <param name="ExtendUntil"></param>
        /// <param name="ExtendBy"></param>
        /// <param name="ExtendOSLocation"></param>
        /// <param name="ExtendFSW"></param>
        /// <param name="ExtendRecordedTime"></param>
        /// <returns>bool</returns>
        [UserCodeMethod]
        public static bool NS_ValidateMiscFromActiveAuthority(string AuthoritySeed,string EngineToText,string Attext,string CopiedBy, string RelayingEmployee, string RelayingAt,string ExtendUntil,string ExtendBy,string ExtendOSLocation,bool ExtendFSW,string ExtendRecordedTime)
        {
            bool success	= true;
            var authorityDictionary = PDS_NS.UserCodeCollections.NS_Authorities.authorityDictionary;
            if (authorityDictionary.ContainsKey(AuthoritySeed))
            {
                Authoritiesrepo.AuthorityNumber = authorityDictionary[AuthoritySeed].authorityNumber;
            }
            else
            {
                Authoritiesrepo.AuthorityNumber = "";
            }
            //Report.Info( AuthorityNumber+","+EngineToText+","+ Attext+","+ CopiedBy+","+	RelayingEmployee+","+	RelayingAt+","+ ExtendUntil+","+ ExtendBy+","+ ExtendOSLocation+","+ ExtendFSW+","+ ExtendRecordedTime);
            string AN = Authoritiesrepo.Communications_Exchange_Ok_Authority.AuthorityNumberText.TextValue;
            if (!Authoritiesrepo.AuthorityNumber.Contains(AN))
            {
                Ranorex.Report.Failure("Authority Number found to be {"+AN+"} when expected is {"+Authoritiesrepo.AuthorityNumber+"}.");
                success = false;
            }
            string To="";
            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.To.AuthorityTypeText.TextValue=="T/E"){
                To = Authoritiesrepo.Communications_Exchange_Ok_Authority.To.EngineToText.SelectedItemText;}
            else {
                To = Authoritiesrepo.Communications_Exchange_Ok_Authority.To.NonEngineToText.SelectedItemText;}

            if (To != EngineToText)
            {
                Ranorex.Report.Failure("Engine To Text found to be {"+To+"} when expected is {"+EngineToText+"}.");
                success = false;
            }
            string At = Authoritiesrepo.Communications_Exchange_Ok_Authority.AtText.SelectedItemText;
            if (At != Attext)
            {
                Ranorex.Report.Failure("At found to be {"+At+"} when expected is {"+Attext+"}.");
                success = false;
            }
            string CB = Authoritiesrepo.Communications_Exchange_Ok_Authority.CopiedByText.SelectedItemText;
            if (CB != CopiedBy)
            {
                Ranorex.Report.Failure("Copied by found to be {"+CB+"} when expected is {"+CopiedBy+"}.");
                success = false;
            }
            string RE = Authoritiesrepo.Communications_Exchange_Ok_Authority.RelayingEmployeeText.SelectedItemText;
            if (RE != RelayingEmployee && !string.IsNullOrEmpty(RelayingEmployee))
            {
                Ranorex.Report.Failure("Relaying Employee found to be {"+RE+"} when expected is {"+RelayingEmployee+"}.");
                success = false;
            }

            string RA = "";
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.RelayingAtText.SelectedItemIndex != -1)
            {
                RA = Authoritiesrepo.Communications_Exchange_Ok_Authority.RelayingAtText.SelectedItemText;
            }

            if (!RA.Contains(RelayingAt))
            {
                Ranorex.Report.Failure("Relaying at found to be {"+RA+"} when expected is {"+RelayingAt+"}.");
                success = false;
            }
            string EU = Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendUntilText.TextValue;
            string extendUntilTime =	authorityDictionary[AuthoritySeed].extendUntilTime;

            if(string.IsNullOrEmpty(extendUntilTime))
            {
                if (EU != ExtendUntil)
                {
                    Ranorex.Report.Failure("Extend Until found to be {"+EU+"} when expected is {"+ExtendUntil+"}.");
                    success = false;
                }
            }
            else
            {
                if(EU != extendUntilTime)
                {
                    Ranorex.Report.Failure("Extend Until found to be {"+EU+"} when expected is {"+extendUntilTime+"}.");
                    success = false;
                }
                else
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                    Ranorex.Report.Success("Extend Until matches expected values of {"+extendUntilTime+"} actual values of {"+EU+"}.");
                }
            }
            string EB = Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendByText.TextValue;
            if (EB != ExtendBy)
            {
                Ranorex.Report.Failure("Extend By found to be {"+EB+"} when expected is {"+ExtendBy+"}.");
                success = false;
            }
            string EOSL = Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendOSLocationText.Text;
            if (ExtendOSLocation!="")
            {
                if (!EOSL.Contains(ExtendOSLocation))
                {
                    Ranorex.Report.Failure("Extend OS Location found to be {"+EOSL+"} when expected is {"+ExtendOSLocation+"}.");
                    success = false;
                }
            }
            bool EFSW = Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendFSWCheckbox.Checked;
            if (EFSW != ExtendFSW)
            {
                Ranorex.Report.Failure("Extend FSW found to be {"+EFSW+"} when expected is {"+ExtendFSW+"}.");
                success = false;
            }
            string ERT = Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendRecordedTimeText.TextValue;
            if (ERT != ExtendRecordedTime)
            {
                Ranorex.Report.Failure("Extend Recorded Time found to be {"+ERT+"} when expected is {"+ExtendRecordedTime+"}.");
                success = false;
            }
            return success;
        }

        /// <summary>
        /// Open Communication exchange form from DTAD screen
        /// </summary>
        /// <param name="authoritySeed"></param>
        /// <returns></returns>
        [UserCodeMethod]
        public static void NS_OpenAuthority_DTAD(string authoritySeed)
        {
            var authorityDictionary = PDS_NS.UserCodeCollections.NS_Authorities.authorityDictionary;
            if (authorityDictionary.ContainsKey(authoritySeed))
            {
                Authoritiesrepo.AuthorityNumber = authorityDictionary[authoritySeed].authorityNumber;
            }
            else
            {
                Authoritiesrepo.AuthorityNumber = "";
            }
            if (Authoritiesrepo.Detailed_Track_Authority_Display.DetailedTrackAuthorityByAuthorityNumberInfo.Exists())
            {
                Authoritiesrepo.Detailed_Track_Authority_Display.DetailedTrackAuthorityByAuthorityNumber.Click(WinForms.MouseButtons.Right);
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Detailed_Track_Authority_Display.TrackAuthorityMenuItems.OpenAuthorityInfo,Authoritiesrepo.Communications_Exchange_Ok_Authority.WindowControls.CloseInfo);
            }
            else
            {
                Ranorex.Report.Failure("Failed to open communication Exchange form");
            }
        }

        /// <summary>
        /// Validate presence of Authority in 'Summary List' as per user expection
        /// </summary>
        /// <param name="authoritySeed">Input:Pass Authority seed for the authority object</param>
        /// <param name="validateExists">Input:if true, validates it exists, if false, validates it doesn't exist</param>
        /// <returns></returns>
        [UserCodeMethod]
        public static void ValidatePresenceOfAuthorityInSummaryList(string authoritySeed, bool validateExists)
        {
            if (!authorityDictionary.ContainsKey(authoritySeed))
            {
                Ranorex.Report.Error("No authority for authority seed {"+authoritySeed+"}.");
                return;
            }

            //Get the Authority number from dictionary
            string authorityNumber = authorityDictionary[authoritySeed].authorityNumber;
            Authoritiesrepo.AuthorityNumber = authorityNumber;

            //Open SummaryList from Main menu
            NS_OpenAuthoritySummaryList_MainMenu();

            //Validate existance of Authority in SummaryList
            if(Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.TrackAuthorityRowByAuthorityNumber.SelfInfo.Exists(0))
            {
                if (validateExists)
                {
                    switch(authorityDictionary[authoritySeed].trackAuthorityType)
                    {
                        case "RW":
                        case "OT":
                            if(Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.TrackAuthorityRowByAuthorityNumber.CellByColumnName.To.GetAttributeValue<string>("Text").Equals(authorityDictionary[authoritySeed].rWOrOtWorker.ToString()))
                            {
                                Ranorex.Report.Success("Track Authority with number {"+authorityNumber+"} found in SummaryList");
                            }
                            else
                            {
                                Ranorex.Report.Failure("Track Authority with number {"+authorityNumber+"} not found in SummaryList");
                            }
                            break;

                        case "TE":
                            string trainId = Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.TrackAuthorityRowByAuthorityNumber.CellByColumnName.TrainID.GetAttributeValue<string>("Text");
                            if(authorityDictionary[authoritySeed].trainSeed.Equals(NS_TrainID.GetTrainSeedFromTrainId(trainId.Substring(0, trainId.IndexOf(' ')))))
                            {
                                Ranorex.Report.Success("Track Authority with number {"+authorityNumber+"} found in SummaryList");
                            }
                            else
                            {
                                Ranorex.Report.Failure("Track Authority with number {"+authorityNumber+"} not found in SummaryList");
                            }
                            break;

                        default:
                            Ranorex.Report.Failure("Invalid Authority Type");
                            break;
                    }
                }
                else
                {
                    Ranorex.Report.Failure("Track Authority with number {"+authorityNumber+"} found on SummaryList");
                }
            }
            else
            {
                if (validateExists)
                    Ranorex.Report.Failure("Track Authority with number {"+authorityNumber+"} not found in SummaryList");
                else
                    Ranorex.Report.Success("Track Authority with number {"+authorityNumber+"} not found on SummaryList");
            }

            //Close SummaryList window
            if(Authoritiesrepo.Track_Authority_Summary_List.SelfInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Track_Authority_Summary_List.WindowControls.CloseInfo, Authoritiesrepo.Track_Authority_Summary_List.SelfInfo);
            }

            return;
        }

        /// <summary>
        /// Function helps to void any Authority based on authoritySeed value,
        /// Validates any feedback on Communication Exchange Form,
        /// Validates/Handels all popup window on the Communication Exchange Form</summary>
        /// <param name="authoritySeed">Input:Pass Authority seed for the authority object</param>
        /// <param name="openAuthorityFrom">Input:Pass where user wants to open Authority(SummaryList/TrackLine/DTAD), not case sensitive</param>
        /// <param name="jointOccupantsValue">Input:Pass JointOccupants value(YES/NO), not case sensitive</param>
        /// <param name="extendTime">by how much do you want to extend the authority from current time
        ///													1 - pass value as 'effectiveuntiltime', if user wants keep ExtendTime same as EffectiveUntilTime for negative scenarios
        ///													2 - either pass value in proper time format like '09:00 AM' or pass as integer like '120'</param>
        /// <param name="clearByPerson">Input:Pass clearByValue as 'copiedBy', if user wants 'Releaser' same as 'Copier'
        ///														Pass other than 'copiedBy, if user does not want 'Releaser' same as 'Copier'
        ///														It is not case sensitive</param>
        /// <param name="expectedFeedback">Input:Expected Feedback for failure cases using regex</param>
        /// <param name="updateBtn">Click on Update button based on value (TRUE/FALSE)</param>
        /// <param name="clearBtn">Click on Clear button based on value (TRUE/FALSE)</param>
        /// <param name="closeBtn">Click on Close button based on value (TRUE/FALSE)</param>
        /// <param name="cancelBtn">Click on Cancel button based on value (TRUE/FALSE)</param>
        /// <param name="expNotificationsPopupHeader">Input:Pass exact 'Notifications' popup header</param>
        /// <param name="expNotificationsPopupText">Input:Pass text inside 'Notifications' popup</param>
        /// <param name="notificationPopupValue">Input:Pass notificationPopupValue as YES/NO/CLOSE (not case sensitive)</param>
        /// <param name="expRNCPopupHeader">Input:Pass exact 'Releaser Not Copier' popup header</param>
        /// <param name="expRNCPopupText">Input:Pass text inside 'Releaser Not Copier' popup</param>
        /// <param name="releaserNotCopierPopupValue">Input:Pass releaserNotCopierPopupValue as YES/NO/CLOSE(not case sensitive)</param>
        /// <param name="issueAuthorityPTCVoice"> Will click the Voice button if true, if false it will end at voice form if it exists, otherwise complete it</param>
        /// <param name="completeAcknowledge">Complete Void process based on value (TRUE/FALSE)</param>
        /// <param name="closeForms">Input:Closes Authority Summary List if open, based on value (TRUE/FALSE)</param>
        [UserCodeMethod]
        public static void VoidAuthorityWithAllFlows(string authoritySeed, string openAuthorityFrom, string jointOccupantsValue, string extendTime, string clearByPerson, string expectedFeedback,
                                                     bool updateBtn,	bool clearBtn, bool closeBtn, bool cancelBtn, string expNotificationsPopupHeader, string expNotificationsPopupText,
                                                     string notificationPopupValue, string expRNCPopupHeader, string expRNCPopupText, string releaserNotCopierPopupValue, bool issueAuthorityPTCVoice,
                                                     bool completeAcknowledge, bool closeForms)
        {
            int retries = 0;

            //Open Authority based on 'openAuthority' param value
            openAuthorityFrom = openAuthorityFrom.ToLower();
            switch(openAuthorityFrom){

                case "summarylist":
                    NS_OpenAuthority_AuthoritySummaryList(authoritySeed);
                    break;

                case "trackline":
                    NS_OpenAuthority_Trackline(authoritySeed);
                    break;

                case "dtad":
                    NS_OpenAuthority_DTAD(authoritySeed);
                    break;

            }

            var authorityObject = NS_Authorities.authorityDictionary[authoritySeed];

            //Waiting for the Authority form to open
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0) && retries < 5 )
            {
                Ranorex.Delay.Milliseconds(200);
                retries++;
            }

            if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("Failed to Open Authority");
                return;
            }

            //Select Yes/No in joint occupants dropdown
            if(jointOccupantsValue != "")
            {	SelectJointOccupantsValueInCommunicationExchangeForm(authoritySeed, jointOccupantsValue);}


            //Input Extend Untll time
            if(extendTime != "")
            {	SetExtendUntilFieldInComunicationExchangeForm(authoritySeed, extendTime);}

            //Fill ClearBy input field
            if(clearByPerson != "")
            {	SetClearByFieldInComunicationExchangeForm(authoritySeed, clearByPerson);}

            //Check feedback if it is exist
            if (!CheckFeedback(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback, expectedFeedback))
            {
                GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButtonInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                return;
            }

            if(!string.IsNullOrEmpty(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback.GetAttributeValue<string>("Text").ToString()))
            {
                GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButtonInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                return;
            }

            //Click on Update button if updateBtn = true
            if(updateBtn)
            {
                if(!WaitForButtonToEnableAndClick(Authoritiesrepo.Communications_Exchange_Ok_Authority.UpdateButtonInfo))
                {
                    Ranorex.Report.Failure("Failed to click on Update button in Communication Exchange Form");
                    GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo,
                                                                          Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButtonInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                    return;
                }
            }

            if (!CheckFeedback(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback, expectedFeedback))
            {
                GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButtonInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                return;
            }

            if(!string.IsNullOrEmpty(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback.GetAttributeValue<string>("Text").ToString()))
            {
                GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButtonInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                return;
            }
            //Click on Clear button if clearBtn = true
            if(clearBtn)
            {
                if(!WaitForButtonToEnableAndClick(Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButtonInfo))
                {
                    Ranorex.Report.Failure("Failed to click on Clear button in Communication Exchange Form");
                    GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo,
                                                                          Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButtonInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                    return;
                }
            }

            retries = 0;
            while(string.IsNullOrEmpty(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback.GetAttributeValue<string>("Text").ToString()) && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if (!CheckFeedback(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback, expectedFeedback))
            {
                GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButtonInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                return;
            }

            if(!string.IsNullOrEmpty(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback.GetAttributeValue<string>("Text").ToString()))
            {
                GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButtonInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                return;
            }
            //Click on Cancel button if cancelBtn = true
            if(cancelBtn)
            {
                if(!WaitForButtonToEnableAndClick(Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo))
                {
                    Ranorex.Report.Failure("Failed to click on Cancel button in Communication Exchange Form");
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                    return;
                }
            }

            //Validate If any feedback exist
            if (!CheckFeedback(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback, expectedFeedback))
            {
                GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButtonInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);

                return;
            }

            //Validate Text in 'Notifications' popup
            if(expNotificationsPopupText != "")
                ValidateTextInNotificationPopup(expNotificationsPopupHeader, expNotificationsPopupText);

            //Click on Yes/No/Close Button in 'Notification' popup
            if(notificationPopupValue != "")
            {	HandleNotificationPopupInCommunicationExchangeForm(notificationPopupValue);}

            //Validate Text in 'Releaser Not Copier' popup
            if(expRNCPopupText != "")
            {	ValidateTextInReleaserNotCopierPopup(expRNCPopupHeader, expRNCPopupText);}

            //Click on Yes/No/Close Button in 'Releaser Not Copier' popup
            if(releaserNotCopierPopupValue != "")
            {	HandleReleaserNotCopierPopupInCommunicationExchangeForm(releaserNotCopierPopupValue);}

            //If form is PTC, handle here
            IssueAuthorityPTCVoice(issueAuthorityPTCVoice);

            //Clicks on Close button if closBtn = true
            if(closeBtn)
            {
                if(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo.Exists(0))
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
            }

            //Complete acknowledge if completeAcknowledge = true
            if(completeAcknowledge)
            {
                //Wait for Acknowledge Button to exist and click it
                retries = 0;
                while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0) && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }

                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0))
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                    Report.Info("Acknowledging the Void Authority request");
                }
                else
                {
                    Ranorex.Report.Failure("Acknowledge Form did not appear for Voiding");
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                    return;
                }

                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0))
                {
                    Ranorex.Report.Failure("Communication Exchnage Form for Track Authority Void did not disappear");
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
                    return;
                }

                Report.Success("Successfully Voided Authority");
            }

            if(closeForms)
            {
                if (Authoritiesrepo.Track_Authority_Summary_List.SelfInfo.Exists(0))
                {
                    Authoritiesrepo.Track_Authority_Summary_List.WindowControls.Close.Click();
                }
            }

            return;
        }


        /// <summary>
        /// Select value(i.e. YES/NO) in JointOccupants dropdown as per user choice
        /// </summary>
        /// <param name="authoritySeed">Input:Seed of the Authority you want to extend</param>
        /// <param name="jointOccupantsValue">Input:Pass JointOccupants value(YES/NO), not case sensitive</param>
        [UserCodeMethod]
        public static void SelectJointOccupantsValueInCommunicationExchangeForm(string authoritySeed, string jointOccupantsValue)
        {
            var authorityObject = NS_Authorities.authorityDictionary[authoritySeed];

            if(authorityObject.trackAuthorityType == "RW")
            {
                int retries = 0;
                while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsTextInfo.Exists(0) && retries < 2)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }

                if(Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsTextInfo.Exists(0))
                {
                    if(Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.GetAttributeValue<bool>("Enabled"))
                    {
                        Ranorex.Report.Info("User is trying to select {" + jointOccupantsValue + "} as joint occupants value");
                        jointOccupantsValue = jointOccupantsValue.ToLower();
                        if(jointOccupantsValue == "yes")
                        {
                            Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.Click();
                            Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.Yes.Click();
                            Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.PressKeys("{TAB}");
                            Ranorex.Report.Info("Info","Successfully selected JointOccupants value as {" + jointOccupantsValue + "}");
                        }
                        else if(jointOccupantsValue == "no")
                        {
                            Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.Click();
                            Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.No.Click();
                            Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.PressKeys("{TAB}");
                            Ranorex.Report.Info("Info","Successfully selected JointOccupants value as {" + jointOccupantsValue + "}");
                        }
                        else
                        {
                            Ranorex.Report.Failure("Failure", "Invalid Joint Occupants Value");
                        }
                    }
                }
                else if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsTextInfo.Exists(0) && jointOccupantsValue != "")
                {
                    Ranorex.Report.Failure("Joint Occupants field did not appear for Voiding");
                }
            }
        }

        /// <summary>
        /// Fill 'ClearBy' information in 'Communication Exchange From' based on user's choice
        /// </summary>
        /// <param name="authoritySeed">Input:Seed of the Authority you want to extend</param>
        /// <param name="clearByValue">Input:Pass clearByValue as 'copiedBy', if user wants 'Releaser' same as 'Copier'
        ///														Pass other than 'copiedBy, if user does not want 'Releaser' same as 'Copier'
        ///														It is not case sensitive</param>
        [UserCodeMethod]
        public static void SetClearByFieldInComunicationExchangeForm(string authoritySeed, string clearByValue)
        {
            var authorityObject = NS_Authorities.authorityDictionary[authoritySeed];

            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByTextInfo.Exists(0))
            {
                if(clearByValue != "")
                {
                    clearByValue = clearByValue.ToLower();
                    if(clearByValue == "copiedby")
                    {
                        Report.Info("Trying to enter clearBy value as {" + authorityObject.copiedBy + "}");
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.Click();
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.PressKeys(authorityObject.copiedBy);
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.PressKeys("{TAB}");
                        Ranorex.Report.Info("Info","Successfully entered clearBy value as {" + authorityObject.copiedBy + "}");
                    }
                    else
                    {
                        Report.Info("Trying to enter clearBy value as {" + clearByValue + "}");
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.Click();
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.PressKeys(clearByValue);
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.PressKeys("{TAB}");
                        Ranorex.Report.Info("Info","Successfully entered clearBy value as {" + clearByValue + "}");
                    }
                }
            }
            else
            {
                Ranorex.Report.Failure("Failure","ClearBy input field did not appear");
            }
        }

        /// <summary>
        /// If form is PTC, click on PTC Voice button
        /// </summary>
        /// <param name="issueAuthorityPTCVoice"> Will click the Voice button if true, if false it will end at voice form if it exists, otherwise complete it</param>
        [UserCodeMethod]
        public static void IssueAuthorityPTCVoice(bool issueAuthorityPTCVoice)
        {
            //If form is PTC, handle here
            int retries = 0;
            while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0) && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0))
            {
                if (issueAuthorityPTCVoice)
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButton.Click();
                }
                else
                {
                    Report.Success("Successfully Voided Authority.");
                    return;
                }
            }
            else if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0) && issueAuthorityPTCVoice)
            {
                Report.Failure("Expected PTC Voice Form but none appeared");
            }
        }

        /// <summary>
        /// Clicks YES/NO in'Notifications' popup or Close it based on user's choice
        /// </summary>
        /// <param name="notificationPopupValue">Input:Pass notificationPopupValue as YES/NO/CLOSE (not case sensitive)</param>
        [UserCodeMethod]
        public static void HandleNotificationPopupInCommunicationExchangeForm(string notificationPopupValue = "no")
        {
            int retries = 0;
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            //Click on Yes/No Button if Notification is displayed
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0) && notificationPopupValue != "")
            {
                Report.Info("Trying to acknowledg the Notification Popup with value :- " + notificationPopupValue);

                notificationPopupValue = notificationPopupValue.ToLower();
                if(notificationPopupValue == "yes")
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.YesButton.Click();
                }
                else if(notificationPopupValue == "no" || notificationPopupValue == "close")
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.NoButton.Click();
                }
            }

            retries = 0;
            while(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0))
            {
                Ranorex.Report.Success("Success", "Successfully clicked on {" + notificationPopupValue + "} in Notification Popup");
            }
            else
            {
                Ranorex.Report.Failure("Failure","Failed to click on {" + notificationPopupValue + "} in Notification Popup");
            }
        }

        /// <summary>
        /// This Method will Extend Authority and it will add the extendTime to the current time and extend the TA by that much time.
        /// </summary>
        /// <param name="extendTime">by how much do you want to extend the authority from current time
        ///													1 - pass value as 'effectiveuntiltime', if user wants keep ExtendTime same as EffectiveUntilTime for negative scenarios
        ///													2 - either pass value in proper time format like '09:00 AM' or pass as integer like '120'</param>
        /// <param name="authoritySeed">Seed of the Authority you want to extend</param>
        [UserCodeMethod]
        public static void SetExtendUntilFieldInComunicationExchangeForm(string authoritySeed, string extendTime)
        {
            int retries = 0;
            int convertedIntegerValue;
            string effectiveTimeDifferenceFormatted = "";
            var authorityObject = NS_Authorities.authorityDictionary[authoritySeed];

            if (extendTime == "effectiveuntiltime")
            {
                effectiveTimeDifferenceFormatted = authorityObject.box5UntilInMinutes;
            }
            //If the value of extendTime is an integer, convert to time else, use that as the value to enter
            else if(int.TryParse(extendTime, out convertedIntegerValue))
            {
                System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(convertedIntegerValue);
                effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("hh:mm tt");
            }
            else
            {
                effectiveTimeDifferenceFormatted = extendTime;
            }

            //Waiting for the Authority form to open
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0) && retries < 3 )
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }


            if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("Failed to Open Authority");
                return;
            }

            //Input ExtendTime
            Report.Info("Extending the Authority up to {" + effectiveTimeDifferenceFormatted + "}");
            Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendUntilText.Element.SetAttributeValue("Text",effectiveTimeDifferenceFormatted);
            Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendUntilText.PressKeys("{TAB}");
            Ranorex.Report.Info("Info","Successfully updated Extend Until Time as {" + effectiveTimeDifferenceFormatted + "}");
        }

        /// <summary>
        /// Validates 'Releaser Not Copier' popup header and text inside it.
        /// </summary>
        /// <param name="expRNCPopupHeader">Input:Pass exact 'Releaser Not Copier' popup header</param>
        /// <param name="expRNCPopupText">Input:Pass text inside 'Releaser Not Copier' popup</param>
        [UserCodeMethod]
        public static bool ValidateTextInReleaserNotCopierPopup(string expRNCPopupHeader, string expRNCPopupText)
        {
            int retries = 0;
            bool validateTextInNotificationsPopup = false;
            Regex expectedPopupText = new Regex(expRNCPopupText.Trim());

            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.SelfInfo.Exists(0) && retries < 3 )
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.SelfInfo.Exists(0))
            {

                Ranorex.Report.Success("Success","ReleaserNotCopier Popup is present as expected");

                string actPopupHeader = Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.TitleBar.GetAttributeValue<string>("Text").Trim();

                if( expRNCPopupHeader.Trim().Equals(actPopupHeader))
                {
                    Ranorex.Report.Success("Success", "Expected popup header {" + expRNCPopupHeader + "} and found Popup header {" + actPopupHeader + "}");

                    string actPopupTextValue1 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.TextArea.Text1.GetAttributeValue<string>("Text").Trim();
                    string actPopupTextValue2 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.TextArea.Text2.GetAttributeValue<string>("Text").Trim();
                    string actPopupTextValue = actPopupTextValue1 + actPopupTextValue2;

                    if(expectedPopupText.ToString().Equals(actPopupTextValue))
                    {
                        validateTextInNotificationsPopup = true;
                        Ranorex.Report.Success("Success", "Expected popup text {" + expectedPopupText + "} and found Popup text : {" + actPopupTextValue + "}");

                    }
                    else
                    {
                        Ranorex.Report.Failure("Failure", "Expected popup text {" + expectedPopupText + "} but found Popup text {" + actPopupTextValue + "}");
                    }
                }
                else
                {
                    Ranorex.Report.Failure("Failure", "Expected popup header {" + expRNCPopupHeader + "} but found Popup header {" + actPopupHeader + "}");
                }

            }
            else
            {
                Ranorex.Report.Failure("Failure","ReleaserNotCopier Popup is not present for validating");
            }

            return validateTextInNotificationsPopup;
        }

        /// <summary>
        /// Validates 'Notifications' popup header and text inside it.
        /// </summary>
        /// <param name="expNotificationPopupHeader">Input:Pass exact 'Notifications' popup header</param>
        /// <param name="expNotificationPopupText">Input:Pass text inside 'Notifications' popup</param>
        [UserCodeMethod]
        public static bool ValidateTextInNotificationPopup(string expNotificationPopupHeader, string expNotificationPopupText)
        {
            int retries = 0;
            bool validateTextInPopup = false;
            Regex expectedNotificationPopupText = new Regex(expNotificationPopupText.Trim());
            Authoritiesrepo.NotificationText = expNotificationPopupText.Trim();

            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 3 )
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0))
            {
                Ranorex.Report.Success("Success","Notifications Popup is present as expected");

                string actPopupHeader = Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.TitleBar.GetAttributeValue<string>("Text").Trim();

                if(expNotificationPopupHeader.Trim().Equals(actPopupHeader))
                {
                    Ranorex.Report.Success("Success", "Expected popup header {" + expNotificationPopupHeader + "} and found Popup header {" + actPopupHeader + "}");

                    string actPopupTextValue = Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.NotificationTextByNotificationText.GetAttributeValue<string>("Text").Trim();

                    if(expectedNotificationPopupText.IsMatch(actPopupTextValue))
                    {
                        validateTextInPopup = true;
                        Ranorex.Report.Success("Success", "Expected popup text {" + expectedNotificationPopupText + "} and found Popup text {" + actPopupTextValue + "}");
                    }
                    else
                    {
                        Ranorex.Report.Failure("Failure", "Expected popup text {" + expectedNotificationPopupText + "} but found Popup text {" + actPopupTextValue + "}");
                    }
                }
                else
                {
                    Ranorex.Report.Failure("Failure", "Expected popup header {" + expNotificationPopupHeader + "} but found Popup header {" + actPopupHeader + "}");
                }
            }
            else
            {
                Ranorex.Report.Failure("Failure","Notification Popup is not present for validating");
            }

            return validateTextInPopup;
        }

        /// <summary>
        /// Clicks YES/NO in'Releaser Not Copier' popup or Close it based on user's choice
        /// </summary>
        /// <param name="releaserNotCopierPopupValue">Input:Pass releaserNotCopierPopupValue as YES/NO/CLOSE(not case sensitive)</param>
        [UserCodeMethod]
        public static void HandleReleaserNotCopierPopupInCommunicationExchangeForm(string releaserNotCopierPopupValue = "no")
        {
            int retries = 0;
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.SelfInfo.Exists(0) && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            //Click on Yes/No Button if Notification is displayed
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.SelfInfo.Exists(0) && releaserNotCopierPopupValue != "")
            {
                Report.Info("Trying to acknowledg the Releaser_Not_Copier Popup with value :-" + releaserNotCopierPopupValue);

                releaserNotCopierPopupValue = releaserNotCopierPopupValue.ToLower();

                if(releaserNotCopierPopupValue == "yes")
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.YesButton.Click();
                }
                else if(releaserNotCopierPopupValue == "no" || releaserNotCopierPopupValue == "close")
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.NoButton.Click();
                }
            }
            else
            {
                Ranorex.Report.Failure("Failure","Releaser_Not_Copier Popup did not appear to acknowledge");
            }

            retries = 0;
            while(Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.SelfInfo.Exists(0) && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.SelfInfo.Exists(0))
            {
                Ranorex.Report.Success("Success", "Successfully clicked on {" + releaserNotCopierPopupValue + "} in Releaser_Not_Copier Popup");
            }
            else
            {
                Ranorex.Report.Failure("Failure","Failed to click on {" + releaserNotCopierPopupValue + "} in Releaser_Not_Copier Popup");
            }
        }

        /// <summary>
        /// Wait for button to exist and enabled then click
        /// </summary>
        /// <param name="button">Input:Pass button object info user wants to click</param>
        [UserCodeMethod]
        public static bool WaitForButtonToEnableAndClick(Ranorex.Core.Repository.RepoItemInfo buttonInfo)
        {
            int retries = 0;
            bool btnEnabled = false;
            Ranorex.Adapter button = buttonInfo.CreateAdapter<Unknown>(true);

            while(!buttonInfo.Exists(0) && retries < 6)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if(buttonInfo.Exists(0))
            {
                while(!button.Enabled && retries < 6)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }

                if (button.Enabled)
                {
                    btnEnabled = true;
                    button.Click();
                    Ranorex.Report.Info("Info","Successfully clicked on " + button);
                }
            }

            return btnEnabled;
        }
        /// <summary>
        /// Select Zones under box 3
        /// </summary>
        /// <param name="zones"></param>
        /// <returns></returns>
        public static bool FillBox3_SelectZoneList(string zones, bool zonesSelect)
        {
            int retries=0;
            if (zones!="")
            {
                if(Authoritiesrepo.Create_Track_Authority.Box3.ZoneListButton.Enabled)
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Create_Track_Authority.Box3.ZoneListButtonInfo,
                                                                                  Authoritiesrepo.Create_Track_Authority.Specify_Zones.SelfInfo,
                                                                                  WinForms.MouseButtons.Left);
                    Report.Info(zones);
                    if(Authoritiesrepo.Create_Track_Authority.Specify_Zones.SelfInfo.Exists())
                    {
                        //zones = MAIN 1-MAIN 2|MAIN 1-MAIN 2 (expected format of the parameter)
                        string[] splitZone = zones.Split('|');
                        string[] splitZone1;
                        string[] splitZone2;
                        if(!splitZone[0].Equals(""))
                        {
                            if(splitZone[0].Contains("-"))
                            {
                                splitZone1 = splitZone[0].Split('-');
                                for(int i=0;i<=splitZone1.Length-1;i++)
                                {
                                    Authoritiesrepo.Zones=splitZone1[i].ToString();
                                    Authoritiesrepo.Create_Track_Authority.Specify_Zones.ZoneListTable1.ZonesToIncludeByZoneName.Click();
                                }
                            }
                            else
                            {
                                Authoritiesrepo.Zones=splitZone[0].ToString();
                                Authoritiesrepo.Create_Track_Authority.Specify_Zones.ZoneListTable1.ZonesToIncludeByZoneName.Click();
                            }
                        }
                        if(!splitZone[1].Equals(""))
                        {
                            if(splitZone[1].ToString().Contains("-"))
                            {
                                splitZone2 = splitZone[1].Split('-');
                                for(int i=0;i<=splitZone2.Length-1;i++)
                                {
                                    Authoritiesrepo.Zones=splitZone2[i].ToString();
                                    Authoritiesrepo.Create_Track_Authority.Specify_Zones.ZoneListTable2.ZonesToIncludeByZoneName.Click();
                                }
                            }
                            else
                            {
                                Authoritiesrepo.Zones=splitZone[1].ToString();
                                Authoritiesrepo.Create_Track_Authority.Specify_Zones.ZoneListTable2.ZonesToIncludeByZoneName.Click();
                            }
                        }
                        Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Specify_Zones.Self.Element);
                        if (Authoritiesrepo.Create_Track_Authority.Specify_Zones.ApplyButtonInfo.Exists(0))
                        {
                            Authoritiesrepo.Create_Track_Authority.Specify_Zones.ApplyButton.Click();
                        }

                        while(!Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 5)
                        {
                            Delay.Milliseconds(500);
                            retries ++;
                        }
                        if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0))
                        {
                            if(zonesSelect)
                            {
                                if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButton.Enabled)
                                {

                                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButtonInfo,
                                                                                      Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);
                                    Ranorex.Report.Info("Clicking YES button on Zone Select");
                                }
                                else
                                {
                                    Ranorex.Report.Failure("YES button Disabled on Zone Select");
                                }
                            }
                            else
                            {
                                if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.NoButton.Enabled)
                                {
                                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.NoButtonInfo,
                                                                                      Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);

                                    Ranorex.Report.Info("clicking NO button on Zone Select");
                                }
                                else
                                {

                                    Ranorex.Report.Failure("NO button Disabled on Zone Select");
                                }
                            }
                        }
                        if(Authoritiesrepo.Create_Track_Authority.Specify_Zones.CancelButtonInfo.Exists(0))
                        {
                            PDS_CORE.Code_Utils.GeneralUtilities.clickItemIfItExists(Authoritiesrepo.Create_Track_Authority.Specify_Zones.CancelButtonInfo);
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="SubdividedLimitsText"></param>
        /// <param name="betweenSide"></param>
        /// <param name="andSide"></param>
        /// <returns></returns>
        [UserCodeMethod]
        public static bool FillBox13_SelectSubdividedLimits(string authoritySeed, string SubdividedLimitsText, bool betweenSide, bool andSide)
        {
        	GeneralUtilities.LeftClickAndWaitForWithRetry(Authoritiesrepo.Create_Track_Authority.Box13.SubdivideLimitsCheckboxInfo, Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.SelfInfo);
//            if(!Authoritiesrepo.Create_Track_Authority.Box13.SubdivideLimitsCheckbox.Checked)
//            {
//                Authoritiesrepo.Create_Track_Authority.Box13.SubdivideLimitsCheckbox.PressKeys("{SPACE}");
//            }
            if(Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.SelfInfo.Exists())
            {
                if(betweenSide)
                {
                    Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.EnterLocationsToSubdivide.BetweenSideRadioButton.Click(WinForms.MouseButtons.Left);
                    if (Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.EnterLocationsToSubdivide.BetweenSideRadioButton.Checked)
                    {
                        Ranorex.Report.Success("Between Side selected");
                    }
                }
                if (SubdividedLimitsText!="")
                {
                    Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.EnterLocationsToSubdivide.SubdividedLocationText.Click();
                    Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.EnterLocationsToSubdivide.SubdividedLocationText.Element.SetAttributeValue("Text",SubdividedLimitsText);
                    Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.EnterLocationsToSubdivide.SubdividedLocationText.PressKeys("{TAB}");
                    if (Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.EnterLocationsToSubdivide.SubdividedLocationText.TextValue==SubdividedLimitsText)
                    {
                        Ranorex.Report.Success("Subdivided Location Text : "+ SubdividedLimitsText);
                    }
                    GeneralUtilities.CheckWaitState(10);
                }
                if(andSide)
                {
                    Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.EnterLocationsToSubdivide.AndSideRadioButton.Click(WinForms.MouseButtons.Left);
                    if (Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.EnterLocationsToSubdivide.AndSideRadioButton.Checked)
                    {
                        Ranorex.Report.Success("And Side selected");
                    }
                }

        		if (authorityDictionary.ContainsKey(authoritySeed))
        		{
        			authorityDictionary[authoritySeed] = new AuthorityObject();
        		} else {
        			authorityDictionary.Add(authoritySeed, new AuthorityObject());
        		}

        		AddAuthorityBox13_SubDivideLimits(authoritySeed);

        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.OKButtonInfo,
        		                                                 Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.SelfInfo);
        		if(Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.OKButtonInfo.Exists(0))
        		{
        			if(!Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.OKButton.Enabled)
        			{
        				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.CancelButtonInfo,
        				                                                 Authoritiesrepo.Create_Track_Authority.Specify_Subdivided_Limits.SelfInfo);
        			}
        		}
        		return true;
        	}
        	else
        	{
        		Ranorex.Report.Error("Subdivide Limits pop-up does not exist");
        		return false;
        	}
        }
        /// <summary>
        /// Validate Remote Track Authority Issue Request PopUp and click OpenAuthorityButton or AcknowledgeButton
        /// <param name="OpenAuthority"></param>
        /// </summary>
        [UserCodeMethod]
        public static void NS_AcknowledgeOrOpenRemoteTrackAuthorityRequestPopUp(bool OpenAuthority)
        {
            int retries = 0;

            while(!Authoritiesrepo.Remote_Track_Authority_Request.SelfInfo.Exists(0) && retries < 5)
            {
                Ranorex.Delay.Milliseconds(1000);
                retries++;
            }

            if(Authoritiesrepo.Remote_Track_Authority_Request.SelfInfo.Exists(0))
            {
                if(OpenAuthority)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Remote_Track_Authority_Request.OpenAuthorityButtonInfo,Authoritiesrepo.Remote_Track_Authority_Request.SelfInfo);
                    Ranorex.Report.Info("Succesfully verified the Open Authority button and performed click on it.");
                }
                else
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Remote_Track_Authority_Request.AcknowledgeButtonInfo,Authoritiesrepo.Remote_Track_Authority_Request.SelfInfo);
                    Ranorex.Report.Info("Succesfully verified the Acknowledge Button and performed click on it.");
                }
            }

            else
            {
                Ranorex.Report.Failure("Failure", Authoritiesrepo.Remote_Track_Authority_Request + " Failed to validate the Remote Track Authority popup , the popup does not exist.");
            }
        }

        /// <summary>
        /// validates Box3 in Creat track Authority
        /// <param name="box3_yn"></param>
        /// <param name="box3_loc1"></param>
        /// <param name="box3_loc1_cp"></param>
        /// <param name="box3_loc2"></param>
        /// <param name="box3_loc2_cp"></param>
        /// <param name="box3_track1"></param>
        /// <param name="box3_track2"></param>
        /// <param name="box3_track3"></param>
        /// <param name="box3_track4"></param>
        /// <param name="box3_track5"></param>
        /// </summary>
        [UserCodeMethod]
        public static bool NS_ValidateBox3_CreateTrackAuthority(string box3_yn, string box3_loc1, string box3_loc1_cp, string box3_loc2, string box3_loc2_cp, string box3_track1, string box3_track2, string box3_track3,
                                                                string box3_track4, string box3_track5)
        {
            bool success = true;
            bool CheckBox = false;
            StringBuilder msg=new StringBuilder();
            if(Authoritiesrepo.Create_Track_Authority.Box3.Box3Checkbox.Checked == !(box3_yn == "n" || box3_yn == ""))
            {
                msg.Append("{Box3 Checkbox checked status}{"+box3_yn+"}");
            }
            else
            {
                Ranorex.Report.Failure("Failed to verify the Box3 Checkbox checked status is [ "+box3_yn+" ].");
                success = false;
            }
            if(!string.IsNullOrEmpty(box3_loc1))
            {
                string workBetweenBetweenText = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenBetween.GetAttributeValue<string>("Text");

                if(workBetweenBetweenText.Equals(box3_loc1))
                {
                    msg.Append("{workBetweenBetween Text}{"+box3_loc1+"}");

                }
                else
                {
                    Ranorex.Report.Failure("Failed to verify the workBetweenBetween Text in Box 3.");
                    success = false;
                }
            }

            if(!string.IsNullOrEmpty(box3_loc1_cp))
            {
                if(box3_loc1_cp.ToLower().Equals("y"))
                {
                    CheckBox = true;
                }
                else
                {
                    CheckBox = false;

                }
                if(Authoritiesrepo.Create_Track_Authority.Box3.ControlPoint1Checkbox.Checked == CheckBox)

                {
                    msg.Append("{Box3 Location1 Control Point Checkbox checked status}{"+box3_loc1+"}");

                }
                else
                {
                    Ranorex.Report.Failure("Failed to verify the Box3 Location1 Control Point Checkbox checked status is [ "+box3_loc1_cp+" ].");
                    success = false;

                }
            }

            if(!string.IsNullOrEmpty(box3_loc2))
            {
                string WorkBetweenAnd = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenAnd.GetAttributeValue<string>("Text");

                if(WorkBetweenAnd.Equals(box3_loc2))
                {
                    msg.Append("{WorkBetweenAnd Text}{"+box3_loc2+"}");

                }
                else
                {
                    Ranorex.Report.Failure("Failed to verify the WorkBetweenAnd Text in Box 3.");
                    success = false;

                }
            }

            if(!string.IsNullOrEmpty(box3_loc2_cp))
            {
                if(box3_loc2_cp.ToLower().Equals("y"))
                {
                    CheckBox = true;
                }
                else
                {
                    CheckBox = false;

                }
                if(Authoritiesrepo.Create_Track_Authority.Box3.ControlPoint2Checkbox.Checked == CheckBox)

                {
                    msg.Append("{Box3 Location2 Control point Checkbox status is}{"+box3_loc2_cp+"}");

                }
                else
                {
                    Ranorex.Report.Failure("Failed to verify the Box3 Location2 Control point Checkbox status is [ "+box3_loc2_cp+" ]");
                    success = false;

                }
            }

            if(!string.IsNullOrEmpty(box3_track1))
            {
                string WorkBetweenTrack1 = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack1.GetAttributeValue<string>("Text");

                if(WorkBetweenTrack1.Equals(box3_track1))
                {
                    msg.Append("{WorkBetweenTrack1 Text}{"+box3_track1+"}");

                }
                else
                {
                    Ranorex.Report.Failure("Failed to verify the WorkBetweenTrack1 Text in Box 3.");
                    success = false;

                }
            }

            if(!string.IsNullOrEmpty(box3_track2))
            {
                string WorkBetweenTrack2 = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack2.GetAttributeValue<string>("Text");

                if(WorkBetweenTrack2.Equals(box3_track2))
                {
                    msg.Append("{WorkBetweenTrack2 Text}{"+box3_track2+"}");

                }
                else
                {
                    Ranorex.Report.Failure("Failed to verify the WorkBetweenTrack2 Text in Box 3.");
                    success = false;

                }
            }

            if(!string.IsNullOrEmpty(box3_track3))
            {
                string WorkBetweenTrack3 = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack3.GetAttributeValue<string>("Text");

                if(WorkBetweenTrack3.Equals(box3_track3))
                {
                    msg.Append("{WorkBetweenTrack3 Text}{"+box3_track3+"}");

                }
                else
                {
                    Ranorex.Report.Failure("Failed to verify the WorkBetweenTrack3 Text in Box 3.");
                    success = false;

                }
            }

            if(!string.IsNullOrEmpty(box3_track4))
            {
                string WorkBetweenTrack4 = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack4.GetAttributeValue<string>("Text");

                if(WorkBetweenTrack4.Equals(box3_track4))
                {
                    msg.Append("{WorkBetweenTrack4 Text}{"+box3_track4+"}");

                }
                else
                {
                    Ranorex.Report.Failure("Failed to verify the WorkBetweenTrack4 Text in Box 3.");
                    success = false;

                }
            }

            if(!string.IsNullOrEmpty(box3_track5))
            {
                string WorkBetweenTrack5 = Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenTrack5.GetAttributeValue<string>("Text");

                if(WorkBetweenTrack5.Equals(box3_track5))
                {
                    msg.Append("{WorkBetweenTrack5 Text}{"+box3_track5+"}");

                }
                else
                {
                    Ranorex.Report.Failure("Failed to verify the WorkBetweenTrack5 Text in Box 3.");
                    success = false;

                }
            }
            msg.Append("}");
            if (success)
            {
                Ranorex.Report.Success(msg.ToString());
            }
            return success;

        }
        /// <summary>
        /// Validates RU_Comments in Create track Authority
        /// <param name="RU_Comments"></param>
        /// </summary>
        [UserCodeMethod]
        public static bool NS_ValidateRU_CommentsText_CreateTrackAuthority(string RU_Comments)
        {
            bool boxStatus = false;
            if(Authoritiesrepo.Create_Track_Authority.RUCommentsTextInfo.Exists(0))
            {

                string ru_comments = Authoritiesrepo.Create_Track_Authority.RUCommentsText.GetAttributeValue<string>("Text");

                if(ru_comments.Equals(RU_Comments))
                {
                    Ranorex.Report.Success(" Remoute user comments" +RU_Comments+ " Exist");

                    char[] arrChar = ru_comments.ToCharArray();
                    foreach(char c in arrChar)
                    {
                        if(!char.IsLetterOrDigit(c))
                        {
                            boxStatus = true;
                            break;

                        }
                    }

                    if(boxStatus)
                    {
                        Report.Success("The special character are present in the RU Comments :[ "+ru_comments+" ] ");
                    }
                    else
                    {
                        Report.Success("The normal character are present in the RU Comments :[ "+ru_comments+" ] ");
                    }

                    boxStatus = true;
                }
                else
                {
                    Ranorex.Report.Failure("Failed to verify the RU Comments , Expected is [ "+RU_Comments+" ] and Actual is [ "+RU_Comments+" ].");
                    boxStatus = false;
                }
            }

            else
            {
                Ranorex.Report.Success("Remoute user comments box dose not exist");
                boxStatus = true;
            }
            return boxStatus;
        }


        /// <summary>
        /// Validates To Text in create track Authority
        /// <param name="To"></param>
        /// </summary>
        [UserCodeMethod]
        public static bool NS_ValidateTo_CreateTrackAuthority(string To)
        {
            bool Status = false;

            string ToText = Authoritiesrepo.Create_Track_Authority.To.NonEngineToText.GetAttributeValue<string>("Text");
            if(ToText.Equals(To))
            {

                Ranorex.Report.Success("Sucessfully matches the ToText value :[ "+To+" ]");
                Status = true;
            }
            else
            {
                Ranorex.Report.Failure("Failed to verify the ToText , Expected is [ "+To+" ] and Actual is [ "+ToText+" ].");
                Status = false;
            }
            return Status;
        }


        /// <summary>
        /// Validates At Text in Create track Authority
        /// <param name="At"></param>
        /// </summary>
        [UserCodeMethod]
        public static bool NS_ValidateAt_CreateTrackAuthority(string At)
        {
            bool Status = false;
            string AtText = Authoritiesrepo.Create_Track_Authority.At.AtText.GetAttributeValue<string>("Text");
            if(AtText.Equals(At))
            {
                Ranorex.Report.Success("Sucessfully matches the AtText value :[ "+At+" ]");
                Status = true;
            }

            else
            {
                Ranorex.Report.Failure("Failed to verify the AtText , Expected is [ "+At+" ] and Actual is [ "+AtText+" ].");
                Status = false;
            }
            return Status;
        }


        /// <summary>
        /// Validates Box5 in Create track Authority
        /// <param name="box5_time"></param>
        /// <param name="box5_yn"></param>
        /// </summary>
        [UserCodeMethod]
        public static bool ValidateBox5_CreateTrackAuthority(string box5_yn, string box5_time)
        {
            bool success = true;
            StringBuilder msg=new StringBuilder();
            //Validate	the status of Box5 Checkbox

            if(Authoritiesrepo.Create_Track_Authority.Box5.Box5Checkbox.Checked == !(box5_yn == "n" || box5_yn == ""))
            {

                msg.Append("{Box5 Checkbox checked status}{"+box5_yn+"}");
            }
            else
            {
                Ranorex.Report.Failure("Failed to verify the Box5Checkbox is in checked status.");
                success = false;
            }

            // Validate the box5 effective time

            if(Authoritiesrepo.Create_Track_Authority.Box5.EffectiveUntilTextInfo.Exists() &&	 !(string.IsNullOrEmpty(Authoritiesrepo.Create_Track_Authority.Box5.EffectiveUntilText.TextValue.ToString())))
            {

                msg.Append("{Box5 effective time until is "+Authoritiesrepo.Create_Track_Authority.Box5.EffectiveUntilText.TextValue.ToString()+"}");

            }
            else
            {
                Ranorex.Report.Failure("Failed to verify the Box5 Effective time untill exist,the value is blank or empty.");
                success = false;
            }
            msg.Append("}");
            if (success)
            {
                Ranorex.Report.Success(msg.ToString());
            }
            return success;
        }

        /// <summary>
        /// Validates Create track Authority Form for RW Authority
        /// <param name="To"></param>
        /// <param name="At"></param>
        /// <param name="box3_yn"></param>
        /// <param name="box3_loc1"></param>
        /// <param name="box3_loc1_cp"></param>
        /// <param name="box3_loc2"></param>
        /// <param name="box3_loc2_cp"></param>
        /// <param name="box3_track1"></param>
        /// <param name="box3_track2"></param>
        /// <param name="box3_track3"></param>
        /// <param name="box3_track4"></param>
        /// <param name="box3_track5"></param>
        /// <param name="box5_time"></param>
        /// <param name="box5_yn"></param>
        /// <param name="RU_Comments"></param>
        /// </summary>
        [UserCodeMethod]
        public static void NS_ValidateCreateTrackAuthority( bool radioButtonTE, bool radioButtonOT, bool radioButtonRW , string To , string At ,
                                                           string box3_yn, string box3_loc1, string box3_loc1_cp, string box3_loc2, string box3_loc2_cp,
                                                           string box3_track1, string box3_track2, string box3_track3, string box3_track4, string box3_track5,
                                                           string box5_yn, string box5_time, string RU_Comments )
        {

            bool success=false;
            ValidateAuthorityRadioButtonSelected(radioButtonTE,radioButtonOT,radioButtonRW);
            success = NS_ValidateTo_CreateTrackAuthority(To);
            DisplayMsg(success,"TO Text");
            success = NS_ValidateAt_CreateTrackAuthority(At);
            DisplayMsg(success,"AT Text");
            success = NS_ValidateBox3_CreateTrackAuthority(box3_yn,box3_loc1,box3_loc1_cp, box3_loc2, box3_loc2_cp,box3_track1,box3_track2,box3_track3,box3_track4,box3_track5);
            DisplayMsg(success,"Box3");
            success = ValidateBox5_CreateTrackAuthority(box5_yn,box5_time);
            DisplayMsg(success,"Box5");
            NS_ValidateRU_CommentsText_CreateTrackAuthority(RU_Comments);
            DisplayMsg(success,"RU_Comments");
        }

        /// <summary>
        /// Complete Granting or Denying a Authority recived via RUM
        /// </summary>
        /// <param name="grantAuthority">Input:True to grant the authority, false to deny it</param>
        /// <param name="closeForms">Input:Closes the Task List Form</param>
        /// <param name="closeAuthorityForm">Input:Closes the Authority Form</param>
        [UserCodeMethod]
        public static void NS_GrantOrDenyAuthority_CommunicationsExchange(bool grantAuthority, string commentsText, string optionalJointOccupancy, bool issueAuthorityPTCVoice, bool closeAuthorityForm, bool closeTaskListForm, string expectedFeedback)
        {
            int retries = 0;
            Authoritiesrepo.Communications_Exchange_Ok_Authority.Self.Activate();
            if (!CheckFeedbackExists(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback, expectedFeedback))
            {
                Ranorex.Report.Failure("Received Feedback message not mached as expected message.");
            }
            else
            {
                Ranorex.Report.Success("Received Feedback message: "+Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback.GetAttributeValue<string>("Text").ToString());
                Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                if(closeAuthorityForm)
                {
                	Ranorex.Report.Info("Denying Autority by closing the Form");
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
            }
            if (grantAuthority)
            {
                Ranorex.Report.Info("Granting Authority");
                optionalJointOccupancy = optionalJointOccupancy.ToLower();
                if(optionalJointOccupancy.Equals("yes"))
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsTextInfo,
                                                              Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.YesInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.SelfInfo);
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.PressKeys("{TAB}");
                }
                else if(optionalJointOccupancy.Equals("no"))
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsTextInfo,
                                                              Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.NoInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.SelfInfo);
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.PressKeys("{TAB}");
                }
                else
                {
                    Ranorex.Report.Info("Joint Occupant Value provided is either blank or invalid");
                }

                Authoritiesrepo.Communications_Exchange_Ok_Authority.AcceptButton.Click();

                if(!string.IsNullOrEmpty(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback.TextValue))
                {
                    if (!CheckFeedbackExists(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback, expectedFeedback))
                    {
                        Ranorex.Report.Failure("Received Feedback message not mached as expected message.");
                    }
                    else
                    {
                        Ranorex.Report.Success("Received Feedback message: "+Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback.GetAttributeValue<string>("Text").ToString());
                        Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.AddCommentsButton.Click();
                        string commentText = Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.CommentText.TextValue;
                        if (commentText != "")
                        {
                            Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.OkButton.Click();
                        }
                        else
                        {
                            Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.CommentText.Element.SetAttributeValue("Text", "Automation");
                            Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.OkButton.Click();
                        }
                        Ranorex.Report.Info("Denying Authority");
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.DenyButton.Click();
                        return;
                    }
                }

                retries = 0;
                while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 2)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }

                //Click on Yes Button if Notification is displayed
                if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0))
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.YesButton.Click();
                    Report.Info("Acknowledging the Notification Popup");
                }
                retries = 0;
                while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.SelfInfo.Exists(0) && retries < 2)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }

                //Click on Yes Button if ReleaserNotCopier is displayed
                if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.YesButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.SelfInfo);
                    Report.Info("Acknowledging the ReleaserNotCopier Popup");
                }
                else
                {
                    Ranorex.Report.Info("No ReleaserNotCopier Popup is found");
                }

                if(Authoritiesrepo.Communications_Exchange_Ok_Authority.AcceptButtonInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.AcceptButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.AcceptButtonInfo);
                }
                //If form is PTC, handle here
                while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0) && retries < 2)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }

                if (Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0))
                {
                    if (issueAuthorityPTCVoice)
                    {
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButton.Click();
                    } else {
                        Report.Success("Successfully Voided Authority.");
                        return;
                    }
                } else if (!Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0) && issueAuthorityPTCVoice)
                {
                    Report.Failure("Expected PTC Voice Form but none appeared");
                }
            } else {
                //Check if there is already a comment, due to one being required to deny	 if (commentsText != "")
                GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.AddCommentsButtonInfo,
                                                          Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.OkButtonInfo);
                string popupCommentText = Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.CommentText.TextValue;
                if (popupCommentText != "")
                {
                    //Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.OkButton.Click();
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.OkButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.SelfInfo);
                }
                else if (commentsText != "")
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.CommentText.Element.SetAttributeValue("Text", commentsText);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.OkButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.SelfInfo);
                }
                else
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.CommentText.Element.SetAttributeValue("Text", "Automation");
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.OkButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.SelfInfo);
                }
                string trackAuthorityNumber = Authoritiesrepo.Communications_Exchange_Ok_Authority.AuthorityNumberText.TextValue;
                string authoritySeed = GetAuthoritySeed(trackAuthorityNumber);
                Ranorex.Report.Info("Authority Number:"+trackAuthorityNumber+"Authority Seed:"+authoritySeed);
                AuthorityObject authorityObj = GetAuthorityObject(authoritySeed);
                if (!String.IsNullOrEmpty(authorityObj.extendUntilTime))
                {
                    authorityObj.extendUntilTime = "";
                }
                Ranorex.Report.Info("Denying Authority");
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.DenyButtonInfo,
                                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                //								if (Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
                //								{
                //										if(!string.IsNullOrEmpty(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback.TextValue))
                //										{
                //												if (!CheckFeedbackExists(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback, expectedFeedback))
                //												{
                //														Ranorex.Report.Failure("Received Feedback message not mached as expected message.");
                //												}
                //												else
                //												{
                //														Ranorex.Report.Success("Received Feedback message: "+Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback.GetAttributeValue<string>("Text").ToString());
                //														Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                //												}
                //										} else {
                //												GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.DenyButtonInfo,
                //																												Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                //										}
                //								}

            }

            if (closeTaskListForm)
            {
            	Ranorex.Report.Info("Closing Task List Form");
            	if(Miscellaneousrepo.Task_List.SelfInfo.Exists(0))
            	{
            		Miscellaneousrepo.Task_List.CloseButton.Click();
            	}
            }
            return;

        }


        /// <summary>
        /// Validates RU_Comments in CommunicationsExchange
        /// <param name="RU_Comments"></param>
        /// </summary>
        [UserCodeMethod]
        public static bool NS_ValidateRU_CommentsText_CommunicationsExchange(string RU_Comments)
        {
            Ranorex.Delay.Milliseconds(500);
            bool boxStatus = false;
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.RUCommentsTextInfo.Exists(0))
            {
                string ru_comments = Authoritiesrepo.Communications_Exchange_Ok_Authority.RUCommentsText.GetAttributeValue<string>("Text");
                if(ru_comments.Equals(RU_Comments))
                {
                    Ranorex.Report.Success(" Remoute user comments" +RU_Comments+ " Exist");

                    char[] arrChar = ru_comments.ToCharArray();
                    foreach(char c in arrChar)
                    {
                        if(!char.IsLetterOrDigit(c))
                        {
                            boxStatus = true;
                            break;
                        }
                    }

                    if(boxStatus)
                    {
                        Report.Success("The special character are present in the RU Comments :[ "+ru_comments+" ] ");
                    }
                    else
                    {
                        Report.Success("The normal character are present in the RU Comments :[ "+ru_comments+" ] ");
                    }

                    boxStatus = true;
                }
                else
                {
                    Ranorex.Report.Failure("Failed to verify the RU Comments , Expected is [ "+RU_Comments+" ] and Actual is [ "+RU_Comments+" ].");
                    boxStatus = false;
                }
            }

            else
            {
                Ranorex.Report.Success("Remoute user comments box dose not exist");
                boxStatus = true;
            }
            return boxStatus;
        }

        /// <summary>
        /// validate Authority Back flow in ADMS.ABF_FBA_M_AUTHORITY
        /// <param name="authoritySeed"></param>
        /// <param name="authorityState"></param>
        /// <param name="ruComment"></param>
        /// </summary>
        [UserCodeMethod]
        public static void NS_ValidateAuthorityBackflow(string authoritySeed, string authorityState, string ruComment)
        {
            string authorityNumber = NS_Authorities.GetAuthorityNumber(authoritySeed);
            Oracle.Code_Utils.ADMSEnvironment.ValidateAuthorityBackflow(authorityNumber, authorityState, ruComment);
        }

        public static void NS_ClosePrintFaxForm_CommuncationExchange()
        {
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.CancelButtonInfo,
                                                              Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.SelfInfo);

            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                              Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
        }

        public static void NS_CloseAdhocPrintFaxForm_CommuncationExchange()
        {
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.CancelButtonInfo,
                                                              Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.SelfInfo);

            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.CancelButtonInfo,
                                                              Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.SelfInfo);

            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                              Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
        }


        [UserCodeMethod]
        public static void ValidateToLimitWithTolerance (string mpList)
        {

            string toLimitText = Authoritiesrepo.Create_Track_Authority.Box2.Proceed1.Proceed1To1.Text;

            string[] splitMpList = mpList.Split('|');

            foreach (string mp in splitMpList)
            {
                if (mp.Equals(toLimitText))
                {
                    Ranorex.Report.Success("Location {"+mp+"} is present within the tolerance list and is present in the To Limit of the authority.");
                    return;
                }
            }

            Ranorex.Report.Failure("Location {"+toLimitText+"} is present in the To Limit of the authority but is not within the tolerance range of {"+mpList+"}. Please manually validate the correctness of the suggestion and add the value to the tolerance range if needed.");
        }

        /// <summary>
        /// Sending Print\Fax request to Print the Authority from CommunicationExchange form
        /// </summary>
        /// <param name="authoritySeed">authoritySeed to identify the authority</param>
        /// <param name="optionalDivision">Division name if selecting to open authority from SummaryList Choice</param>
        /// <param name="optionalLogicalPosition">LogicalPosition Name if selecting to open authority from SummaryList Choice</param>
        /// <param name="openAuthorityFrom">Open the authority from either "summarylist", "trackline" or "summarylistchoice"</param>
        /// <param name="optionalPrintType">Printer or Fax or DistributionList or Email</param>
        /// <param name="optionalName">To whom to sent the authority print\fax</param>
        /// <param name="optionalNumberOfCopies">Number of copies to print</param>
        /// <param name="okButton">True to click or False to not click</param>
        /// <param name="adhocButton">True to click and open Adhoc request form or False to not open</param>
        /// <param name="cancelButton">True to click or False to not click</param>
        /// <param name="optionalAdhocName">Name of Entity to whom print request is sent</param>
        /// <param name="optionalAdhocAddress">Address of the Entity to whom print request is sent</param>
        /// <param name="optionalAdhocQuantity">Numbr of copies sent to the adhoc entity</param>
        /// <param name="optionalAdhocType">Printer, Fax, Email or Pager option to be selected</param>
        /// <param name="adhocOkButton">True to click or False to not click</param>
        /// <param name="adhocInsertRowButton">True to Click or False to not click</param>
        /// <param name="adhocCancelButton">True to click or False to not click</param>
        /// <param name="expectedFeedback">Expected Feedback if want to validate incorrect inputs</param>
        [UserCodeMethod]
        public static void NS_Send_Authority_PrintFax(string authoritySeed, string optionalDivision, string optionalLogicalPosition, string openAuthorityFrom, string optionalPrintType, string optionalName, string optionalNumberOfCopies, bool okButton, bool adhocButton, bool cancelButton, string optionalAdhocName, string optionalAdhocAddress, string optionalAdhocQuantity, string optionalAdhocType, bool adhocOkButton, bool adhocInsertRowButton, bool adhocCancelButton, string expectedFeedback)
        {
            int retry = 0;
            switch(openAuthorityFrom.ToLower())
            {
                case "summarylist":
                    NS_OpenAuthority_AuthoritySummaryList(authoritySeed);
                    break;

                case "summarylistchoice":
                    NS_OpenAuthority_AuthoritySummaryListChoice(authoritySeed, optionalDivision, optionalLogicalPosition);
                    break;

                case "trackline":
                    NS_OpenAuthority_Trackline(authoritySeed);
                    break;

                default:
                    Ranorex.Report.Error("Invalid Open Authority From Option: "+openAuthorityFrom.ToLower());
                    return;
            }

            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.RibbonMenu.PrintInfo,
                                                          Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.SelfInfo);

                if(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.SelfInfo.Exists(0))
                {
                    if(!adhocButton)
                    {
                        if(!string.IsNullOrEmpty(optionalPrintType))
                        {
                            switch(optionalPrintType.ToLower())
                            {
                                case "printer":
                                    if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.PrinterRadioButton.GetAttributeValue<bool>("Checked"))
                                    {
                                        Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.PrinterRadioButton.Click();
                                    }
                                    break;

                                case "fax":
                                    if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.FaxRadioButton.GetAttributeValue<bool>("Checked"))
                                    {
                                        Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.FaxRadioButton.Click();
                                    }
                                    break;


                                case "distributionlist":
                                    if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.DistributionListRadioButton.GetAttributeValue<bool>("Checked"))
                                    {
                                        Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.DistributionListRadioButton.Click();
                                    }
                                    break;

                                case "email":
                                    if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.EmailRadioButton.GetAttributeValue<bool>("Checked"))
                                    {
                                        Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.EmailRadioButton.Click();
                                    }
                                    break;

                                default:
                                    Ranorex.Report.Failure("Invalid Print Type: "+optionalPrintType+", so cancelling the request");
                                    NS_ClosePrintFaxForm_CommuncationExchange();
                                    return;

                            }
                        }

                        if(!string.IsNullOrEmpty(optionalName))
                        {
                            Authoritiesrepo.Name = optionalName;
                            GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Name.NameTextInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Name.NameList.SelfInfo);

                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Name.NameList.NameListItemByNameInfo,
                                                                              Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Name.NameList.SelfInfo);

                        }

                        if(!string.IsNullOrEmpty(optionalNumberOfCopies))
                        {
                            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.NumberOfCopies.GetAttributeValue<bool>("Enabled"))
                            {
                                Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.NumberOfCopies.Element.SetAttributeValue("Text", optionalNumberOfCopies);
                            }
                            else
                            {
                                Ranorex.Report.Info("Number of Copies Field is disabled");
                            }
                        }

                        if(okButton)
                        {
                            Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.OkButton.Click();

                            while(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.SelfInfo.Exists(0) && retry < 3){
                                Ranorex.Delay.Milliseconds(1000);
                                retry++;
                            }
                        }

                        if(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.SelfInfo.Exists(0))
                        {
                            if(CheckFeedback(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Feedback, expectedFeedback))
                            {
                                Ranorex.Report.Failure("Received Feedback message: "+Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Feedback.GetAttributeValue<string>("Text").ToString());
                                Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Self);

                                NS_ClosePrintFaxForm_CommuncationExchange();
                                return;
                            }
                        } else
                        {
                            Ranorex.Report.Info("Successfully sent Print Fax request");
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                              Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);

                        }

                        if(cancelButton)
                        {
                            NS_ClosePrintFaxForm_CommuncationExchange();
                        }
                    }
                    else
                    {

                        GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.AdhocButtonInfo,
                                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.SelfInfo);

                        if(!string.IsNullOrEmpty(optionalAdhocName))
                        {
                            Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.AdhocRecipientTable.RecipientByRowIndex.NameText.Element.SetAttributeValue("Text", optionalAdhocName);

                            if(CheckFeedback(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.Feedback, expectedFeedback))
                            {
                                Ranorex.Report.Failure("Received Feedback message: "+Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.Feedback.GetAttributeValue<string>("Text").ToString());
                                Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.Self);

                                NS_CloseAdhocPrintFaxForm_CommuncationExchange();
                                return;
                            }
                        }

                        if(!string.IsNullOrEmpty(optionalAdhocAddress))
                        {
                            Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.AdhocRecipientTable.RecipientByRowIndex.NameText.Element.SetAttributeValue("Text", optionalAdhocAddress);

                            if(CheckFeedback(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.Feedback, expectedFeedback))
                            {
                                Ranorex.Report.Failure("Received Feedback message: "+Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.Feedback.GetAttributeValue<string>("Text").ToString());
                                Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.Self);

                                NS_CloseAdhocPrintFaxForm_CommuncationExchange();
                                return;
                            }
                        }

                        if(!string.IsNullOrEmpty(optionalAdhocQuantity))
                        {
                            Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.AdhocRecipientTable.RecipientByRowIndex.NameText.Element.SetAttributeValue("Text", optionalAdhocQuantity);

                            if(CheckFeedback(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.Feedback, expectedFeedback))
                            {
                                Ranorex.Report.Failure("Received Feedback message: "+Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.Feedback.GetAttributeValue<string>("Text").ToString());
                                Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.Self);

                                NS_CloseAdhocPrintFaxForm_CommuncationExchange();
                                return;
                            }
                        }

                        if(!string.IsNullOrEmpty(optionalAdhocType))
                        {
                            GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.AdhocRecipientTable.RecipientByRowIndex.Type.SelfInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.AdhocRecipientTable.RecipientByRowIndex.Type.RecipientTypeComboBox.SelfInfo);

                            switch(optionalAdhocType.ToLower())
                            {
                                case "printer":
                                    if(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.AdhocRecipientTable.RecipientByRowIndex.Type.RecipientTypeComboBox.Printer.Visible)
                                    {
                                        Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.AdhocRecipientTable.RecipientByRowIndex.Type.RecipientTypeComboBox.Printer.Click();
                                    }
                                    break;

                                case "fax":
                                    if(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.AdhocRecipientTable.RecipientByRowIndex.Type.RecipientTypeComboBox.Fax.Visible)
                                    {
                                        Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.AdhocRecipientTable.RecipientByRowIndex.Type.RecipientTypeComboBox.Fax.Click();
                                    }
                                    break;

                                case "email":
                                    if(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.AdhocRecipientTable.RecipientByRowIndex.Type.RecipientTypeComboBox.Email.Visible)
                                    {
                                        Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.AdhocRecipientTable.RecipientByRowIndex.Type.RecipientTypeComboBox.Email.Click();
                                    }
                                    break;

                                case "pager":
                                    if(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.AdhocRecipientTable.RecipientByRowIndex.Type.RecipientTypeComboBox.Pager.Visible)
                                    {
                                        Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.AdhocRecipientTable.RecipientByRowIndex.Type.RecipientTypeComboBox.Pager.Click();
                                    }
                                    break;
                            }


                        }

                        if(adhocOkButton)
                        {
                            Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.OkButton.Click();
                            retry = 0;

                            while(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.SelfInfo.Exists(0) && retry < 5)
                            {
                                Ranorex.Delay.Milliseconds(1000);
                                retry++;
                            }

                        }

                        if(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.SelfInfo.Exists(0))
                        {
                            if(CheckFeedback(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.Feedback, expectedFeedback))
                            {
                                Ranorex.Report.Failure("Received Feedback message: "+Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.Feedback.GetAttributeValue<string>("Text").ToString());
                                Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.PDS_Print_Fax_Authority_Dialog.Print_Fax_For_Authority_Adhoc_Recipients.Self);

                                NS_CloseAdhocPrintFaxForm_CommuncationExchange();
                                return;
                            }
                        }
                        else
                        {
                            Ranorex.Report.Info("Successfully sent Print Fax request");
                            NS_CloseAdhocPrintFaxForm_CommuncationExchange();


                        }

                        if(cancelButton)
                        {
                            NS_CloseAdhocPrintFaxForm_CommuncationExchange();
                        }
                    }
                }
                else
                {
                    Ranorex.Report.Failure("PDS Print Fax Dialog Box not found for the Track Authority");
                }
            }
            else
            {
                Ranorex.Report.Failure("Track Authority Communication Exchange Form not found");
            }
        }

        /// <summary>
        /// Validate the Joint Occupants Field of an Authority as either blank, yes or no.
        /// <param name="authoritySeed">Optional Parameter if the Authority is not already open</param>
        /// <param name="jointOccupancyState">State to be validated against</param>
        /// </summary>
        [UserCodeMethod]
        public static void NS_ValidateAuthorityJointOccupantsField(string authoritySeed, string jointOccupancyState, bool closeAuthority)
        {
            NS_OpenAuthority_AuthoritySummaryList(authoritySeed);
            if (jointOccupancyState == "N")
            {
                jointOccupancyState = "No";
            } else if (jointOccupancyState == "Y")
            {
                jointOccupancyState = "Yes";
            }

            string foundJointOccupancyText = Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.Text;
            if (foundJointOccupancyText != jointOccupancyState)
            {
                Ranorex.Report.Failure("Found Joint Occupancy text {"+foundJointOccupancyText+"} not equal to expected value of {"+jointOccupancyState+"}");
            } else {
                Ranorex.Report.Success("Found Joint Occupancy text {"+foundJointOccupancyText+"} is equal to expected value");
            }

            if (closeAuthority)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
            }

            return;
        }

        /// <summary>
        /// Validate the Joint Occupants Field of an Authority as either blank, yes or no.
        /// <param name="authoritySeed">Optional Parameter if the Authority is not already open</param>
        /// <param name="jointOccupancyState">State to be validated against</param>
        /// </summary>
        [UserCodeMethod]
        public static void WaitForRumTrackAuthorityRequestPopup_NS(int maxWaitSeconds)
        {
            int retries = 0;
            while(!Authoritiesrepo.Remote_Track_Authority_Request.SelfInfo.Exists(0) && retries < maxWaitSeconds)
            {
                Ranorex.Delay.Seconds(1);
                retries++;
            }

            if (!Authoritiesrepo.Remote_Track_Authority_Request.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("RUM Track Authority Popup did not appear within "+maxWaitSeconds.ToString()+" seconds.");
            } else {
                Ranorex.Report.Info("RUM Track Authority Popup appeared");
            }
            return;
        }

        [UserCodeMethod]
        public static void Validate_VoidAuthorityInfoUI_RUMRequest(string authoritySeed, string employeeFirstName, string employeeMiddleName, string employeeLastName, string joint_occupancy, string ru_comments)
        {
            string authorityNumber = GetAuthorityNumber(authoritySeed);
            bool validateVoidForm = true;
            int retries = 0;
            string employeeName = employeeFirstName;

            if(!string.IsNullOrEmpty(employeeMiddleName))
            {
                employeeName = employeeName + " " +employeeMiddleName;
            }

            if(!string.IsNullOrEmpty(employeeLastName))
            {
                employeeName = employeeName + " " +employeeLastName;
            }

            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(1000);
                retries++;
            }

            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                if(authorityNumber != Authoritiesrepo.Communications_Exchange_Ok_Authority.AuthorityNumberText.GetAttributeValue<string>("Text"))
                {
                    Ranorex.Report.Failure(string.Format("Authority Number sent from RUM message '{0}' does not match with UI '{1}'", authorityNumber, Authoritiesrepo.Communications_Exchange_Ok_Authority.AuthorityNumberText.GetAttributeValue<string>("Text")));
                    validateVoidForm = false;
                }

                if(ru_comments != Authoritiesrepo.Communications_Exchange_Ok_Authority.RUCommentsText.GetAttributeValue<string>("Text"))
                {
                    Ranorex.Report.Failure(string.Format("RU Comments sent from RUM message '{0}' does not match with UI '{1}'", ru_comments, Authoritiesrepo.Communications_Exchange_Ok_Authority.RUCommentsText.GetAttributeValue<string>("Text")));
                    validateVoidForm = false;
                }

                if(Authoritiesrepo.Communications_Exchange_Ok_Authority.RUCommentsText.GetAttributeValue<bool>("Editable") != false)
                {
                    Ranorex.Report.Failure("RU Comments Text field is editable");
                    validateVoidForm = false;
                }

                if(joint_occupancy.ToLower() == "y")
                {
                    joint_occupancy = "Yes";
                }
                else if(joint_occupancy.ToLower() == "n")
                {
                    joint_occupancy = "No";
                }
                else
                {
                    joint_occupancy = "";
                }

                if(joint_occupancy != Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.GetAttributeValue<string>("Text"))
                {
                    Ranorex.Report.Failure(string.Format("Joint Occupancy sent from RUM message '{0}' does not match with UI '{1}'", authorityNumber, Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.GetAttributeValue<string>("Text")));
                    validateVoidForm = false;
                }

                if(Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.GetAttributeValue<bool>("Enabled") != false)
                {
                    Ranorex.Report.Failure("Joint Occupants Text field is editable");
                    validateVoidForm = false;
                }

                if(employeeName != Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.GetAttributeValue<string>("Text"))
                {
                    Ranorex.Report.Failure(string.Format("Employee Clear by Name sent from RUM message '{0}' does not match with UI '{1}'", employeeName, Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.GetAttributeValue<string>("Text")));
                    validateVoidForm = false;
                }

                if(validateVoidForm)
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                    Ranorex.Report.Success("All fields are correctly popuplated and disabled");
                }
                else
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                    Ranorex.Report.Failure("All fields are not correctly popuplated and disabled");
                }
            }
            else
            {
                Ranorex.Report.Failure("Unable to find Communication Exchange form");
            }

        }

        /// <summary>
        /// Validating Authority messages backflow
        /// </summary>
        /// <param name="authoritySeed">Authority Seed</param>
        /// <param name="messageId">E.g. RD-RTIR, RD-CATA, DR-TAUT etc</param>
        /// <param name="district">District in which authority is issued</param>
        /// <param name="optionalAction">Action# e.g. 0,1 etc</param>
        /// <param name="optionalDispatcherResponse">Dispatcher Response added in the comments section, or response auto generated when rejecting the authority or closing Yellow Form</param>
        /// <param name="optionalWithInMinutes">Validate the messages backflowedSu within current-n minutes</param>
        [UserCodeMethod]
        public static void NS_Validate_ABF_OTC_MESSAGE_ADMS(string authoritySeed, string messageId, string district, string optionalAction, string optionalDispatcherResponse, string optionalWithInMinutes)
        {
            string authorityNumber = "";
            if(messageId != "RD-RTIR" && messageId != "DR-RTCD")
            {
                authorityNumber = GetAuthorityNumber(authoritySeed);
            }

            Oracle.Code_Utils.ADMSEnvironment.Validate_OTCMessage_Backflow(messageId, authorityNumber, district, optionalAction, optionalDispatcherResponse, optionalWithInMinutes);
        }

        /// <summary>
        /// Validate TrainID when issue TE authority
        /// </summary>
        /// <param name="invalidTrainId">Invalid Train ID InputnumberOfTrackAuthorities Ex:NS12 45</param>
        /// <param name="expectedFeedback">Specified trainID not found</param>
        /// <param name="closeForms">Input: True closes authority issue form</param>
        [UserCodeMethod]
        public static void NS_ValidateTrainIsAvailable_AuthorityForm(string invalidTrainId, string expectedFeedback, bool closeForms)
        {
            NS_OpenAuthorityForm_MainMenu("TE");
            Authoritiesrepo.Create_Track_Authority.TrainID.FindTrainButton.Click();
            Authoritiesrepo.Create_Track_Authority.TrainID.Find_Train.TrainIDText.Click();
            Authoritiesrepo.Create_Track_Authority.TrainID.Find_Train.TrainIDText.Element.SetAttributeValue("Text", invalidTrainId);
            Authoritiesrepo.Create_Track_Authority.TrainID.Find_Train.OkButton.Click();

            CheckFeedback(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback);

            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo, Authoritiesrepo.Create_Track_Authority.CancelButtonInfo);
            }
        }


        /// <summary>
        /// Helps to issue Pre-select 'OT', 'RW', 'TE', 'TE_PROCEEDFROM', 'TE_WORKWAY' and 'TE_AUTHORITY'
        /// </summary>
        /// <param name="authoritySeed"></param>
        /// <param name="trackAuthorityType">Pass 'OT' - If wants to issue Pre-select 'Track Equipment' Authority from specific Trackline window
        ///																	Pass 'RW' - If wants to issue Pre-select 'Roadway Worker' Authority from specific Trackline window
        ///																	Pass 'TE' - If wants to issue Pre-select 'Train or Engine' Authority from specific Trackline window
        ///																	Pass 'TE' - If wants to issue Pre-select 'Proceed From' Authority by right clicking on TrainId in opsta
        ///																	Pass 'TE' - If wants to issue Pre-select 'Workway' Authority from opsta by right clicking on TrainId in opsta
        ///																	Pass 'TE' - If wants to issue Pre-select 'TE' Authority by right clicking on TrainId in opsta</param>
        /// <param name="trainSeed"></param>
        /// <param name="engineSeed"></param>
        /// <param name="rWOrOtWorker"></param>
        /// <param name="at"></param>
        /// <param name="box1TrackAuthorityNumber"></param>
        /// <param name="box1Validate"></param>
        /// <param name="box2ProceedFrom"></param>
        /// <param name="box2Fsw"></param>
        /// <param name="box2To1"></param>
        /// <param name="box2Track1"></param>
        /// <param name="box2To1HoldClearMain"></param>
        /// <param name="box2To2"></param>
        /// <param name="box2Track2"></param>
        /// <param name="box2To2HoldClearMain"></param>
        /// <param name="box2To3"></param>
        /// <param name="box2Track3"></param>
        /// <param name="box2To3HoldClearMain"></param>
        /// <param name="box2Validate"></param>
        /// <param name="box3WorkBetweenFrom"></param>
        /// <param name="box3FromCP"></param>
        /// <param name="box3To"></param>
        /// <param name="box3ToCP"></param>
        /// <param name="box3Track1"></param>
        /// <param name="box3Track2"></param>
        /// <param name="box3Track3"></param>
        /// <param name="box3Track4"></param>
        /// <param name="box3Track5"></param>
        /// <param name="box3Validate"></param>
        /// <param name="box4ProceedFrom"></param>
        /// <param name="box4Fsw"></param>
        /// <param name="box4To1"></param>
        /// <param name="box4Track1"></param>
        /// <param name="box4To1HoldClearMain"></param>
        /// <param name="box4To2"></param>
        /// <param name="box4Track2"></param>
        /// <param name="box4To2HoldClearMain"></param>
        /// <param name="box4To3"></param>
        /// <param name="box4Track3"></param>
        /// <param name="box4To3HoldClearMain"></param>
        /// <param name="box4Validate"></param>
        /// <param name="box5UntilInMinutes"></param>
        /// <param name="box5Validate"></param>
        /// <param name="box6EngineSeed1"></param>
        /// <param name="box6Engine1Direction"></param>
        /// <param name="box6EngineSeed2"></param>
        /// <param name="box6Engine2Direction"></param>
        /// <param name="box6EngineSeed3"></param>
        /// <param name="box6Engine3Direction"></param>
        /// <param name="box6At"></param>
        /// <param name="box6Validate"></param>
        /// <param name="box7"></param>
        /// <param name="box7Validate"></param>
        /// <param name="box8EngineSeed1"></param>
        /// <param name="box8Engine1Direction"></param>
        /// <param name="box8EngineSeed2"></param>
        /// <param name="box8Engine2Direction"></param>
        /// <param name="box8EngineSeed3"></param>
        /// <param name="box8Engine3Direction"></param>
        /// <param name="box8Validate"></param>
        /// <param name="box9"></param>
        /// <param name="box9Validate"></param>
        /// <param name="box10Between1"></param>
        /// <param name="box10Between2"></param>
        /// <param name="box10Validate"></param>
        /// <param name="box11StopShort"></param>
        /// <param name="box11Track"></param>
        /// <param name="box11Validate"></param>
        /// <param name="box12RWIC1"></param>
        /// <param name="box12Between1"></param>
        /// <param name="box12And1"></param>
        /// <param name="box12Track1"></param>
        /// <param name="box12RWIC2"></param>
        /// <param name="box12Between2"></param>
        /// <param name="box12And2"></param>
        /// <param name="box12Track2"></param>
        /// <param name="box12RWIC3"></param>
        /// <param name="box12Between3"></param>
        /// <param name="box12And3"></param>
        /// <param name="box12Track3"></param>
        /// <param name="box12Validate"></param>
        /// <param name="box13SubdivideLimits"></param>
        /// <param name="box13AutomaticInstructions"></param>
        /// <param name="box13ManualInstructions"></param>
        /// <param name="box13Validate"></param>
        /// <param name="pressIssue"></param>
        /// <param name="completeAuthorityIssue"></param>
        /// <param name="issueAuthorityCopiedBy"></param>
        /// <param name="issueAuthorityRelayingEmployee"></param>
        /// <param name="issueAuthorityAt"></param>
        /// <param name="issueAuthorityPTCVoice"></param>
        /// <param name="expectedFeedback"></param>
        /// <param name="zones"></param>
        /// <param name="box13SubdividedLimitsText"></param>
        /// <param name="box13BetweenSide"></param>
        /// <param name="box13AndSide"></param>
        /// <param name="atLocMPType">Pass 'True', If wants to select Milepost as 'AT' location else 'False'</param>
        /// <param name="toLocMPType">Pass 'True', If wants to select Milepost as 'TO' location else 'False'</param>
        /// <param name="fromLocMPType">Pass 'True', If wants to select Milepost as 'FROM' location else 'False'</param>
        /// <param name="fromTrackSection">Pass the TrackSection Id, where wants to select 'FROM' Milepost(e.g 2079092)</param>
        /// <param name="toTrackSection">Pass the TrackSection Id, where wants to select 'TO' Milepost(e.g 2079092)</param>
        /// <param name="issueWithTrain">Pass 'True', If wants to issue Authority by right clicking on TrainId else pass 'False'</param>
        /// <param name="rwicUser"></param>
        /// <param name="trackLineWindowName">Pass the Trackline window name(e.g 'Savannah 2')</param>
        /// <param name="preselectAuthorityType">Pass 'OT' - If wants to issue Pre-select 'Track Equipment' Authority from specific Trackline window
        ///																	Pass 'RW' - If wants to issue Pre-select 'Roadway Worker' Authority from specific Trackline window
        ///																	Pass 'TE' - If wants to issue Pre-select 'Train or Engine' Authority from specific Trackline window
        ///																	Pass 'TEPROCEEDTRACKAUTHORITY' - If wants to issue Pre-select 'Proceed From' Authority by right clicking on TrainId in opsta
        ///																	Pass 'TEWORKTRACKAUTHORITY' - If wants to issue Pre-select 'Workway' Authority from opsta by right clicking on TrainId in opsta
        ///																	Pass 'TETRACKAUTHORITY' - If wants to issue Pre-select 'TE' Authority by right clicking on TrainId in opsta</param>
        /// <param name="issuewithTrainFromSummaryList">Pass 'True', If wants to issue authority Pre-select from right clicking on train in trains summary list</param>

        [UserCodeMethod]
        public static void IssuePreSelectAuthorityFunction(string authoritySeed, string trackAuthorityType, string trainSeed, string engineSeed,
                                                           string rWOrOtWorker, string at, string box1TrackAuthorityNumber,
                                                           bool box1Validate, string box2ProceedFrom, bool box2Fsw, string box2To1, string box2Track1,
                                                           string box2To1HoldClearMain, string box2To2, string box2Track2, string box2To2HoldClearMain,
                                                           string box2To3, string box2Track3, string box2To3HoldClearMain, bool box2Validate,
                                                           string box3WorkBetweenFrom, bool box3FromCP, string box3To, bool box3ToCP, string box3Track1,
                                                           string box3Track2, string box3Track3, string box3Track4, string box3Track5, bool box3Validate,
                                                           string box4ProceedFrom, bool box4Fsw, string box4To1, string box4Track1,
                                                           string box4To1HoldClearMain, string box4To2, string box4Track2, string box4To2HoldClearMain,
                                                           string box4To3, string box4Track3, string box4To3HoldClearMain, bool box4Validate,
                                                           string box5UntilInMinutes, bool box5Validate, string box6EngineSeed1, string box6Engine1Direction,string box6EngineSeed2, string box6Engine2Direction,
                                                           string box6EngineSeed3, string box6Engine3Direction, string box6At, bool box6Validate, bool box7, bool box7Validate, string box8EngineSeed1,
                                                           string box8Engine1Direction, string box8EngineSeed2, string box8Engine2Direction,
                                                           string box8EngineSeed3, string box8Engine3Direction, bool box8Validate, bool box9, bool box9Validate,
                                                           string box10Between1, string box10Between2, bool box10Validate, string box11StopShort,
                                                           string box11Track, bool box11Validate, string box12RWIC1, string box12Between1,
                                                           string box12And1, string box12Track1, string box12RWIC2, string box12Between2,
                                                           string box12And2, string box12Track2, string box12RWIC3, string box12Between3,
                                                           string box12And3, string box12Track3, bool box12Validate, bool box13SubdivideLimits,
                                                           string box13AutomaticInstructions, string box13ManualInstructions, bool box13Validate,
                                                           bool pressIssue, bool completeAuthorityIssue, string issueAuthorityCopiedBy, string issueAuthorityRelayingEmployee,
                                                           string issueAuthorityAt, bool issueAuthorityPTCVoice, string expectedFeedback,string zones,
                                                           string box13SubdividedLimitsText, bool box13BetweenSide, bool box13AndSide, bool atLocMPType,
                                                           bool toLocMPType, bool fromLocMPType, string fromTrackSection, string toTrackSection, bool issueWithTrain, string rwicUser, string trackLineWindowName, string preselectAuthorityType, bool issuewithTrainFromSummaryList, bool limitsDoNotAdjoin = true, bool zonesSelect = true)
        {

            // Get the Trackline window name where users wants to issue Pre-select Authoritystring 
            string fromLoc = "";
            string toLoc = "";
            if (!box2ProceedFrom.Equals(""))
            {
            	fromLoc = box2ProceedFrom;
            	toLoc = box2To1;
            }
            else
            {
            	fromLoc = box3WorkBetweenFrom;
            	toLoc =box3To;
            }
            NS_PreselectAuthorityFunction(trackLineWindowName, preselectAuthorityType, trainSeed, issuewithTrainFromSummaryList, trackAuthorityType, atLocMPType, at, fromLocMPType, fromLoc, fromTrackSection, toLocMPType, toLoc, toTrackSection, limitsDoNotAdjoin);

            //Calling NS_IssueAuthorityFunction here
            NS_IssueAuthorityFunction(authoritySeed, trackAuthorityType, trainSeed, engineSeed,
                                      rWOrOtWorker, at, box1TrackAuthorityNumber,
                                      box1Validate, box2ProceedFrom, box2Fsw, box2To1, box2Track1,
                                      box2To1HoldClearMain, box2To2, box2Track2, box2To2HoldClearMain,
                                      box2To3, box2Track3, box2To3HoldClearMain, box2Validate,
                                      box3WorkBetweenFrom, box3FromCP, box3To, box3ToCP, box3Track1,
                                      box3Track2, box3Track3, box3Track4, box3Track5, box3Validate,
                                      box4ProceedFrom, box4Fsw, box4To1, box4Track1,
                                      box4To1HoldClearMain, box4To2, box4Track2, box4To2HoldClearMain,
                                      box4To3, box4Track3, box4To3HoldClearMain, box4Validate,
                                      box5UntilInMinutes, box5Validate,	box6EngineSeed1,	box6Engine1Direction, box6EngineSeed2, box6Engine2Direction,
                                      box6EngineSeed3,	box6Engine3Direction, box6At, box6Validate, box7, box7Validate, box8EngineSeed1,
                                      box8Engine1Direction, box8EngineSeed2, box8Engine2Direction,
                                      box8EngineSeed3, box8Engine3Direction, box8Validate, box9, box9Validate,
                                      box10Between1, box10Between2,	box10Validate, box11StopShort,
                                      box11Track, box11Validate,	box12RWIC1, box12Between1,
                                      box12And1, box12Track1, box12RWIC2, box12Between2,
                                      box12And2, box12Track2, box12RWIC3, box12Between3,
                                      box12And3, box12Track3, box12Validate, box13SubdivideLimits,
                                      box13AutomaticInstructions,	box13ManualInstructions,	box13Validate,
                                      pressIssue, completeAuthorityIssue, issueAuthorityCopiedBy, issueAuthorityRelayingEmployee,
                                      issueAuthorityAt, issueAuthorityPTCVoice, expectedFeedback,zones,
                                      box13SubdividedLimitsText, box13BetweenSide, box13AndSide, rwicUser, limitsDoNotAdjoin, zonesSelect);
        }

        [UserCodeMethod]
        public static void NS_PreselectAuthorityFunction(string trackLineWindowName, string preselectTrackAuthorityType, string trainSeed, bool fromSummaryList, string authorityType,bool atIsMilePost, string atLocation, bool fromIsMilePost, string fromLocation,
                                                        string fromTrackSection, bool toIsMilePost, string toLocation, string toTrackSection, bool limitsDoNotAdjoin, string atTrackSection="")
        {
        	Tracklinerepo.TracklineWindow = trackLineWindowName;
            preselectTrackAuthorityType = preselectTrackAuthorityType.ToUpper();
            // Check whether user wants to issue Pre-select Authority by right clicking on TrainId or from the top Menulist
            if(trainSeed != "" && authorityType == "TE")
            {
                if(!fromSummaryList)
                {
                    string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
                    Tracklinerepo.TrainId = trainId;
                    if (trainId == null)
                    {
                        Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                        return;
                    }
                    if (!Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.Visible)
                   		NS_Trackline.MakeTrainVisibleOnTrackline(trainSeed);
                    int iter= 0;
                    while (!Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.SelfInfo.Exists(0) && iter< 5)
                    {
                    	Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.Click(System.Windows.Forms.MouseButtons.Right);

                    	Delay.Seconds(1);
                    	iter++;
                    }
                    
                    switch(preselectTrackAuthorityType.ToUpper())
                    {
                        case "TEPROCEEDTRACKAUTHORITY":
                            if(Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.IssueProceedTrackAuthorityInfo.Exists(0) && Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.IssueProceedTrackAuthority.Enabled)
                            {
                                Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.IssueProceedTrackAuthority.Click();
                            }
                            else
                            {
                                Ranorex.Report.Error("TE_PROCEEDTRACKAUTHORITY Authority pre-select button is not present as expected");
                                return;
                            }
                            break;

                        case "TEWORKTRACKAUTHORITY":
                            if(Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.IssueWorkTrackAuthorityInfo.Exists(0) && Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.IssueWorkTrackAuthority.Enabled)
                            {
                                Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.IssueWorkTrackAuthority.Click();
                            }
                            else
                            {
                                Ranorex.Report.Error("TE_WORKTRACKAUTHORITY Authority pre-select button is not present as expected");
                                return;
                            }
                            break;

                        case "TETRACKAUTHORITY":
                            if(Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.IssueTrackAuthorityInfo.Exists(0) && Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.IssueTrackAuthority.Enabled)
                            {
                            	Report.Warn("Not really a preselect. Beware.");
                                Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.IssueTrackAuthority.Click();
                                Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(5000);
                            }
                            else
                            {
                                Ranorex.Report.Error("TE_TRACKAUTHORITY Authority pre-select button is not present as expected");
                            }
                           return;
                        default:
                            Ranorex.Report.Error("PreSelect Authority Type is not given correctly");
                            break;

                    }
                }
                else
                {
                    NS_Trainsheet.NS_OpenTrainStatusSummary_MainMenu();
                    if(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo.Exists(0))
                    {
                        PDS_CORE.Code_Utils.GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo,
                                                                                           Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.SelfInfo);
                    }
                    switch(preselectTrackAuthorityType.ToUpper())
                    {
                        case "TEPROCEEDTRACKAUTHORITY":
                            if(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.IssueProceedTrackAuthorityPreSelectInfo.Exists(0) && Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.IssueProceedTrackAuthorityPreSelect.Enabled)
                            {
                                Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.IssueProceedTrackAuthorityPreSelect.Click();
                            }
                            else
                            {
                                Ranorex.Report.Error("TE_PROCEEDTRACKAUTHORITY Authority pre-select button is not present as expected");
                                return;
                            }
                            break;

                        case "TEWORKTRACKAUTHORITY":
                            if(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.IssueWorkTrackAuthorityPreSelectInfo.Exists(0) && Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.IssueWorkTrackAuthorityPreSelect.Enabled)
                            {
                                Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.IssueWorkTrackAuthorityPreSelect.Click();
                            }
                            else
                            {
                                Ranorex.Report.Error("TE_WORKTRACKAUTHORITY Authority pre-select button is not present as expected");
                                return;
                            }
                            break;

                        case "TETRACKAUTHORITY":
                            if(Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.IssueTrackAuthorityInfo.Exists(0) && Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.IssueTrackAuthority.Enabled)
                            {
                            	Report.Warn("Not really a preselect. Beware.");
                            	Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.IssueTrackAuthority.Click();
                            	Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(5000);
                            }
                            else
                            {
                                Ranorex.Report.Error("TE_TRACKAUTHORITY Authority pre-select button is not present as expected");
                            }
                            return;
                        default:
	                        if(Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.RibbonMenu.TrainOrEngineTrackAuthorityInfo.Exists(0) && Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.RibbonMenu.TrainOrEngineTrackAuthority.Enabled)
	                        {
	                        	GeneralUtilities.LeftClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.RibbonMenu.TrainOrEngineTrackAuthorityInfo, Authoritiesrepo.Create_Track_Authority.SelfInfo);
	                            return; //this will just open a manual authority form
	                        }
	                        else
	                        {
	                            Ranorex.Report.Error("TE Authority pre-select button is not present as expected");
	                            return;
	                        }
	                    }
                }
            }
            else
            {
                switch(authorityType)
                {

                    case "OT":
                        if(Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.RibbonMenu.TrackEquipmentAuthorityInfo.Exists(0) && Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.RibbonMenu.TrackEquipmentAuthority.Enabled)
                        {
                            Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.RibbonMenu.TrackEquipmentAuthority.Click();
                        }
                        else
                        {
                            Ranorex.Report.Error("OT Authority pre-select button is not present as expected");
                            return;
                        }
                        break;

                    case "RW":
                        if(Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.RibbonMenu.RoadwayWorkerAuthorityInfo.Exists(0) && Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.RibbonMenu.RoadwayWorkerAuthority.Enabled)
                        {
                            Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.RibbonMenu.RoadwayWorkerAuthority.Click();
                        }
                        else
                        {
                            Ranorex.Report.Error("RW Authority pre-select button is not present as expected");
                            return;
                        }
                        break;
                }

            }
            // Pre-select AT, ProceedFrom, ProceedTo, WorkBetweenFrom and WorkBetweenTo fileds based on the conditions
           //Select 'AT' location
          // Bitmap currentMouse = Mouse.GetCursorImage();
          	if(atIsMilePost)
	        {
	        	//original implementation has the next call using the friomTracksection instead of an "atTrackSection" for now , im keeping it same as original
	        	if(atTrackSection!= "")
	        		NS_Trackline.SelectMPfromTrackSection(atTrackSection, atLocation);
	        	else
	        		NS_Trackline.SelectMPfromTrackSection(fromTrackSection, atLocation);
	        }
	        else
	        {
	            Tracklinerepo.ControlPointName = atLocation;
	            if(Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.ControlPointObjectInfo.Exists(0) && Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.ControlPointObject.Enabled)
	            {
	                Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.ControlPointObject.Click(WinForms.MouseButtons.Middle);
	                Delay.Milliseconds(500);
	            }
	            else
	            {
	                Ranorex.Report.Failure("ControlPointObject for AT location is not present as expected");
	                return;
	            }
	        }
 
          	if(fromIsMilePost)
            {
                NS_Trackline.SelectMPfromTrackSection(fromTrackSection, fromLocation);
            }
            else
            {
                Tracklinerepo.ControlPointName = fromLocation;
                if(Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.ControlPointObjectInfo.Exists(0) && Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.ControlPointObject.Enabled)
                {
                    Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.ControlPointObject.Click(WinForms.MouseButtons.Middle);
                    Delay.Milliseconds(500);
                }
                else
                {
                    Ranorex.Report.Failure("ControlPointObject for Box2ProceedFrom is not present as expected");
                    return;
                }
            }

            //Select 'ProceedTo' location
       
	        if(toIsMilePost)
            {
                NS_Trackline.SelectMPfromTrackSection(toTrackSection, toLocation);
            }
            else
            {
                Tracklinerepo.ControlPointName = toLocation;
                if(Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.ControlPointObjectInfo.Exists(0) && Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.ControlPointObject.Enabled)
                {
                    Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.ControlPointObject.Click(WinForms.MouseButtons.Middle);
                    Delay.Milliseconds(500);
                }
                else
                {
                    Ranorex.Report.Failure("ControlPointObject for Box2To is not present as expected");
                    return;
                }
            }


            int retries = 0;
            while (!Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if (!Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Create Track Authority form did not open");
                return;
            }

            retries = 0;
            while(!Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 3)
            {
                Delay.Milliseconds(500);
                retries ++;
            }
            if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0))
            {
                if(limitsDoNotAdjoin)
                {
                    if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButton.Enabled)
                    {

                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButtonInfo,

                                                                          Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);
                        Ranorex.Report.Info("Clicking YES button");
                        if(Bulletinsrepo.Bulletins_Input_Relay.SelfInfo.Exists(0))
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.AddressLinesRowByIndex.TCNumberInfo,
                                                                              Bulletinsrepo.Bulletins_Input_Relay.Relay.AddressLines.AddressTable.AddressLinesRowByIndex.TCNumberInfo);
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.WindowControls.CloseInfo,
                                                                              Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
                        }
                    }
                }
                else
                {
                    if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.NoButton.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.NoButtonInfo,
                                                                  Authoritiesrepo.Create_Track_Authority.SelfInfo);

                        Ranorex.Report.Info("clicking NO button");
                    }
                }
            }
        }

        /// <summary>
        /// Verify the Track Authority was Extended or Not
        /// </summary>
        /// <param name="authoritySeed">Invalid Train ID Input Ex:NS12 45</param>
        /// <param name="Extended">Specified trainID not found</param>
        /// <param name="closeForms">Input: True closes authority issue form</param>
        [UserCodeMethod]
        public static void ValidateAuthorityExtend(string authoritySeed, bool extended, bool closeForms)
        {
            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                string extendUntilObjTime1 = authorityDictionary[authoritySeed].extendUntil1;
                string extendUntilObjTime2 = authorityDictionary[authoritySeed].extendUntil2;
                string extendUntilObjTime3 = authorityDictionary[authoritySeed].extendUntil3;

                string extendUntilTime1 = "";
                string extendUntilTime2 = "";
                string extendUntilTime3 = "";

                if(!string.IsNullOrEmpty(extendUntilObjTime1))
                {
                    extendUntilTime1 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box5.ExtendedUntilText1.TextValue;
                }
                if(!string.IsNullOrEmpty(extendUntilObjTime2))
                {
                    extendUntilTime2 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box5.ExtendedUntilText2.TextValue;
                }
                if(!string.IsNullOrEmpty(extendUntilObjTime3))
                {
                    extendUntilTime3 = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box5.ExtendedUntilText3.TextValue;
                }

                bool resultFound = true;


                if(extended)
                {
                    if(!string.IsNullOrEmpty(extendUntilObjTime1) && extendUntilObjTime1.Equals(extendUntilTime1))
                    {
                        Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                        Ranorex.Report.Success("First Extended Until Time matches expected value: {"+extendUntilObjTime1+"} actual value: {"+extendUntilTime1+"}.");
                    }
                    else
                    {
                        resultFound = false;
                    }
                    if(!string.IsNullOrEmpty(extendUntilObjTime2))
                    {
                        if(extendUntilObjTime2.Equals(extendUntilTime2))
                        {
                            Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                            Ranorex.Report.Success("Second Extended Until Time matches expected value: {"+extendUntilObjTime2+"} actual value: {"+extendUntilTime2+"}.");
                        }
                        else
                        {
                            resultFound = false;
                        }
                    }
                    if(!string.IsNullOrEmpty(extendUntilObjTime3))
                    {
                        if(extendUntilObjTime3.Equals(extendUntilTime3))
                        {
                            Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                            Ranorex.Report.Success("Third Extended Until Time matches expected value: {"+extendUntilObjTime3+"} actual value: {"+extendUntilTime3+"}.");
                        }
                        else
                        {
                            resultFound = false;
                        }
                    }
                    if(!resultFound)
                    {
                        Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                        Ranorex.Report.Failure("Track Authority was not Extended for Second or Third.");
                    }
                }
                else
                {
                    if(string.IsNullOrEmpty(extendUntilObjTime1) && string.IsNullOrEmpty(extendUntilTime1))
                    {
                        Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                        Ranorex.Report.Success("Track Authority was not Extended");
                    }
                    else
                    {
                        Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                        Ranorex.Report.Failure("Track Authority Extended With {"+extendUntilTime1+"} Time.");
                    }
                }
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                }

            }
        }


        /// <summary>
        /// Acknowledge the Notification by validating its text
        /// </summary>
        /// <param name="notificationText">Pass the notification text which needs to acknowledge</param>
        /// <param name="clickYesButton">True to click Yes button, else False</param>
        [UserCodeMethod]
        public static void AcknowledgeAuthorityNotification_CreateTrackAuthority(string notificationText, bool clickYesButton)
        {
            int retries = 0;

            while(!Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            Regex notificationTextRegex = new Regex(notificationText);
            if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0))
            {
                string actualNotificationTextValue = Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.TextWithAuthority.GetAttributeValue<string>("Text");

                if(actualNotificationTextValue.Contains(":"))
                {
                    string[] popupMessage = actualNotificationTextValue.Split(':');
                    actualNotificationTextValue = popupMessage[0].ToString();
                }

                if(notificationTextRegex.IsMatch(actualNotificationTextValue.Trim()))
                {
                    Ranorex.Report.Success("Notification pop-up exist with expected notfication text");

                    if(clickYesButton)
                    {
                        Ranorex.Report.Info("Clicking YES button to acknowledge Notification pop-up");
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButtonInfo,
                                                                          Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButtonInfo);
                    }
                    else
                    {
                        Ranorex.Report.Info("Clicking NO button to acknowledge Notification pop-up");
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.NoButtonInfo,
                                                                          Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.NoButtonInfo);
                    }
                }
                else
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Notifications_Form.Self.Element);
                    Ranorex.Report.Failure("Not the expected Notification popup, clicking No button");
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.NoButtonInfo,
                                                                      Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.NoButtonInfo);
                }
            }
            else
            {
                Ranorex.Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Self.Element);
                Ranorex.Report.Failure("Unable to find Notification Popup with text: "+notificationText);
            }
        }

        /// <summary>
        /// Accept the Issue Authority by clicking on Accept Button in Create Authority form
        /// </summary>
        [UserCodeMethod]
        public static void NS_ClickAcceptButton_IssueAuthority_RUM()
        {
            int retries = 0;
            while(!Authoritiesrepo.Create_Track_Authority.AcceptButtonInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if(Authoritiesrepo.Create_Track_Authority.AcceptButtonInfo.Exists(0))
            {
                Authoritiesrepo.Create_Track_Authority.AcceptButton.Click();
            }
            else
            {
                Ranorex.Report.Failure("Accept Button does not exist");
            }
        }


        /// <summary>
        /// Filling Box 3 toopst without tabingout
        /// </summary>
        /// <param name="box3To">To Opst in box 3</param>
        /// <param name="authoritySeed">authority seed</param>
        [UserCodeMethod]
        public static void NS_FillBox3ToOpst(string box3To)
        {
            if(!Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("There is no form exist to exit box3");
            }
            else
            {
                Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenAnd.Click();
                Authoritiesrepo.Create_Track_Authority.Box3.WorkBetweenAnd.Element.SetAttributeValue("Text", box3To);
            }
        }

        /// <summary>
        /// Validation of Box 13 in communication Exchange form
        /// </summary>
        /// <param name="closeForms">close The Communication Exchange Track Authority form</param>
        /// <param name="expectedValue">box 13 value</param>
        [UserCodeMethod]
        public static void NS_ValidateBox13_Communication_ExchangeAuthorityForm(bool closeForms, string expectedValue)
        {
            bool box13Value = false;
            if (Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
            	box13Value = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box13.SelfInfo.Exists();
                if (box13Value && expectedValue.ToLower() == "true")
                {
                    Ranorex.Report.Success("Box 13 value is present");
                    if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Box13.Self.Enabled)
                    	Report.Success(" and checked.");
                }
                else if (!box13Value && expectedValue.ToLower() == "false")
                {
                    Ranorex.Report.Success("Box 13 is not present.");
                }
                else
                {
                	Report.Failure("Expected box 13 present {"+expectedValue+"} but box 13 actual presence = "+box13Value+".");
                }
                if(closeForms)
                {
                	Ranorex.Report.Info("Denying Autority by closing the Form");
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
            }
            else
            {
                Ranorex.Report.Failure("Authority form Does not exit to validate");
            }
        }

        /// <summary>
        /// A bit meatier version of validate hold main that will also return true if it doesnt exist on the form.
        /// </summary>
        /// <param name="holdMain">Whether or not Hold Main will be selected.</param>
        [UserCodeMethod]
        public static void NS_ValidateAuthorityHoldMain (bool holdMain)
        {
            if (Authoritiesrepo.Create_Track_Authority.Box7.Box7CheckboxInfo.Exists(0) && holdMain)
            {
                if (Authoritiesrepo.Create_Track_Authority.Box7.Box7Checkbox.Checked)
                {
                    Ranorex.Report.Success("Current authority holds main as expected.");
                }
                else
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Box7.Box7Checkbox.Element);
                    Ranorex.Report.Failure("Expected authority to hold main. Hold main is unchecked.");
                }
            }
            else if (Authoritiesrepo.Create_Track_Authority.Box7.Box7CheckboxInfo.Exists(0) && !holdMain)
            {
                if (Authoritiesrepo.Create_Track_Authority.Box7.Box7Checkbox.Checked)
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Box7.Box7Checkbox.Element);
                    Ranorex.Report.Failure("Hold Main is in unexpected state True.");
                }
                else
                {
                    Ranorex.Report.Success("Hold main is unchecked as expected.");
                }
            }
            else //Hold main doesnt exist
            {
                if (holdMain)
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Self.Element);
                    Ranorex.Report.Failure("Hold Main is not present on the authority form.");
                }
                else
                {
                    Ranorex.Report.Success("Hold main is not present on authority form.");
                }
            }
        }

        /// <summary>
        /// A bit meatier version of validate clear main that will also return true if it doesnt exist on the form.
        /// </summary>
        /// <param name="clearMain">Whether or not Clear Main will be selected.</param>
        [UserCodeMethod]
        public static void NS_ValidateAuthorityClearMain (bool clearMain)
        {
            if (Authoritiesrepo.Create_Track_Authority.Box9.Box9CheckboxInfo.Exists(0) && clearMain)
            {
                if (Authoritiesrepo.Create_Track_Authority.Box9.Box9Checkbox.Checked)
                {
                    Ranorex.Report.Success("Current authority clears main as expected.");
                }
                else
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Box9.Box9Checkbox.Element);
                    Ranorex.Report.Failure("Expected authority to clear main. Clear main is unchecked.");
                }
            }
            else if (Authoritiesrepo.Create_Track_Authority.Box9.Box9CheckboxInfo.Exists(0) && !clearMain)
            {
                if (Authoritiesrepo.Create_Track_Authority.Box9.Box9Checkbox.Checked)
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Box9.Box9Checkbox.Element);
                    Ranorex.Report.Failure("Clear Main is in unexpected state True.");
                }
                else
                {
                    Ranorex.Report.Success("Clear main is unchecked as expected.");
                }
            }
            else //clear main doesnt exist
            {
                if (clearMain)
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Self.Element);
                    Ranorex.Report.Failure("Clear Main is not present on the authority form.");
                }
                else
                {
                    Ranorex.Report.Success("Clear main is not present on authority form.");
                }
            }
        }

        /// <summary>
        /// Issue and complete autority after form is filled out.
        /// </summary>
        /// <param name="authoritySeed">The string a user will be able to access the new authority with.</param>
        [UserCodeMethod]
        public static void NS_IssueAuthorityAfterFormisFilled(string authoritySeed, bool completeAuthorityIssue, string issueAuthorityCopiedBy, string issueAuthorityRelayingEmployee, string issueAuthorityAt, bool issueAuthorityPTCVoice, string expectedFeedback)
        {
            if (Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
            {
                if (authoritySeed !="")
                {
                    AddAuthorityObjectFromOpenAuthority(authoritySeed);
                }
                int retries = 0;
                while(!Authoritiesrepo.Create_Track_Authority.IssueButton.Enabled && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }
                if (!Authoritiesrepo.Create_Track_Authority.IssueButton.Enabled)
                {
                    Ranorex.Report.Info("Issue Button is not enabled when trying to issue");
                }
                Authoritiesrepo.Create_Track_Authority.IssueButton.Click();
                retries = 0;
                while (Authoritiesrepo.Create_Track_Authority.IssueButtonInfo.Exists(0) && retries < 4)
                {
                    if (retries == 2)
                    {
                        Authoritiesrepo.Create_Track_Authority.IssueButton.Click();
                    }
                    Ranorex.Delay.Seconds(1);
                    retries++;
                }
                Report.Info("Clicked Issue Button to Issue Authority.");

                if (Authoritiesrepo.Create_Track_Authority.IssueButtonInfo.Exists(0))
                {
                    if (!CheckFeedback(Authoritiesrepo.Create_Track_Authority.Feedback, expectedFeedback))
                    {
                        Authoritiesrepo.Create_Track_Authority.CancelButton.Click();
                        return;
                    } else {
                        Ranorex.Report.Failure("Track Authority Failed to Issue.");
                        Authoritiesrepo.Create_Track_Authority.CancelButton.Click();
                        return;
                    }
                }
                if (completeAuthorityIssue)
                {

                    CompleteAuthorityIssue(authoritySeed, issueAuthorityCopiedBy, issueAuthorityRelayingEmployee, issueAuthorityAt, issueAuthorityPTCVoice);

                    while(Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0) && retries < 3){
                        Ranorex.Delay.Milliseconds(200);
                        retries++;
                    }

                    if(Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0)){
                        Report.Failure("Unable to acknowledge the Authority");
                    }
                }

            }
            else
            {
                Ranorex.Report.Failure("Create Track Authority form does not exit");
            }
        }

        /// <summary>
        /// Will detect open authority forms, which will impede further operations and close or issue through them if
        /// unable to back out.
        /// </summary>
        [UserCodeMethod]
        public static void NS_CloseAuthorityForms()
        {
        	if (MainMenurepo.PDS_Main_Menu.Incomplete_Track_Authority.SelfInfo.Exists(0))
        	{
        		MainMenurepo.PDS_Main_Menu.Incomplete_Track_Authority.Self.EnsureVisible();
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.PDS_Main_Menu.Incomplete_Track_Authority.OkButtonInfo,  MainMenurepo.PDS_Main_Menu.Incomplete_Track_Authority.SelfInfo);
        	}
        	//Checks should cascade backwards in flow to avoid repeat code and checks
        	//TODO Feel free to put any checks i've forgotten in here, just make sure its done in the correct order
        	if (Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0))
        	{
        		Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.Self.EnsureVisible();
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.NoButtonInfo,  Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo);
        	}
        	//Check if TA is in ok state
        	if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0))
        	{
        		Authoritiesrepo.Communications_Exchange_Ok_Authority.Self.EnsureVisible();
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
        	}
        	//Check if train is in commex
        	if (Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo.Exists(0))
        	{
        		Authoritiesrepo.Communications_Exchange_Ok_Authority.Self.EnsureVisible();
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
        	}
        	//That should lead us back to the create state, or if we are currently in the create state
        	if (Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.SelfInfo.Exists(0))
        	{
        		Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.Self.EnsureVisible();
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.CancelButtonInfo, Authoritiesrepo.Create_Track_Authority.Hold_Clear_Main.SelfInfo);
        	}
        	if (Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0))
        	{
        		//TODO This is the only notification off the top of my head, 99% sure theres more, feel free to add more detailed checks andhandles in
        		Authoritiesrepo.Create_Track_Authority.Notifications_Form.Self.EnsureVisible();
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.NoButtonInfo, Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);
        	}

        	if (Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
        	{
        		Authoritiesrepo.Create_Track_Authority.Self.EnsureVisible();
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo, Authoritiesrepo.Create_Track_Authority.SelfInfo);
        		//cant have other authorities open at the same time, we're done here
    		}

        	//At PTC Voice or Ack, have to ack through to get rid of the window
        	//Do it in different user code so we dont necessarily have to do ALL the checks if we dont have to

        }

        /// <summary>
        /// Will detect open authorities in a state where they cannot be returned from and issue them since it might be blocking other tests
        /// </summary>
        [UserCodeMethod]
        public static void NS_CompleteHangingAuthorities()
        {
        	while (Authoritiesrepo.Confirm_Tracking_Request.SelfInfo.Exists(0))
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Confirm_Tracking_Request.CancelInfo, Authoritiesrepo.Confirm_Tracking_Request.SelfInfo);
        	}
        	//TODO put a wait in here if you want, currently not used in original recording being refactored
        	if (Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo.Exists(0))
        	{
        		GeneralUtilities.LeftClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo);
        	}

        	if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0))
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo, Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
        	}
        }

        [UserCodeMethod]
        public static void NS_CloseCommunicationExchangeForm(bool acceptConfirmPopUp)
        {
        	int retries = 0;
        	while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.WindowControls.CloseInfo.Exists(0) && retries < 3)
        	{
        		Ranorex.Delay.Milliseconds(500);
        		retries++;
        	}

        	if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.WindowControls.CloseInfo.Exists(0))
        	{
        		Ranorex.Report.Error("Could not find Cancel button for Communications Exchange Form");
        		return;
        	}

        	GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.WindowControls.CloseInfo,
        	                                          Authoritiesrepo.Please_Confirm_PopUp.SelfInfo);
        	if(acceptConfirmPopUp)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Please_Confirm_PopUp.YesButtonInfo,
        		                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
        		Ranorex.Report.Info("Denying Authority by closing the Form");
        	}
        	else
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Please_Confirm_PopUp.NoButtonInfo,
        		                                                              Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
        	}

        	return;
        }


        /// <summary>
        /// ValidateBox13 is Checked as expected.
        /// </summary>
        [UserCodeMethod]
        public static void NS_ValidateBox13IssueAuthority(string box13AutomaticInstructions)
        {
            NS_ValidateBox13(box13AutomaticInstructions);
        }

        /// <summary>
        /// To UnCheck Box2 if it is checked
        /// </summary>
        [UserCodeMethod]
        public static void NS_UncheckBox2()
        {
            int retries = 0;
            if (Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
            {
                while(Authoritiesrepo.Create_Track_Authority.Box2.Box2Checkbox.Checked && retries < 3)
                {
                    Authoritiesrepo.Create_Track_Authority.Box2.Box2Checkbox.Click();
                    retries ++;
                }
            }
            else
            {
                Ranorex.Report.Failure("Authority form does not exist");
            }
        }


        /// <summary>
        /// Validates 'Notifications' popup header and text inside it.
        /// </summary>
        /// <param name="expNotificationPopupHeader">Input:Pass exact 'Notifications' popup header</param>
        /// <param name="expNotificationPopupText">Input:Pass text inside 'Notifications' popup</param>
        /// <param name="isPopupExist">Input:True or False to validate popup Exist or Not Exist</param>
        [UserCodeMethod]
        public static void ValidateTextInCreateTrackAuthorityPopup(string expNotificationPopupHeader, string expNotificationPopupText, bool isPopupExist)
        {
            int retries = 0;
            Regex expectedNotificationPopupText = new Regex(expNotificationPopupText.Trim());
            Authoritiesrepo.NotificationText = expNotificationPopupText.Trim();

            if(isPopupExist)
            {
                while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 3 )
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }

                if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Success("Success","Notifications Popup is present as expected");

                    string actPopupHeader = Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.TitleBar.GetAttributeValue<string>("Text").Trim();

                    if(expNotificationPopupHeader.Trim().Equals(actPopupHeader))
                    {
                        Ranorex.Report.Success("Success", "Expected popup header {" + expNotificationPopupHeader + "} and found Popup header {" + actPopupHeader + "}");
                        string actPopupTextValue = Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.TextWithAuthority.GetAttributeValue<string>("Text");
                        if(expectedNotificationPopupText.IsMatch(actPopupTextValue.Trim()))
                        {
                            Ranorex.Report.Success("Success", "Expected popup text {" + expectedNotificationPopupText + "} and found Popup text {" + actPopupTextValue + "}");
                        }
                        else
                        {
                            Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.Self);
                            Ranorex.Report.Failure("Failure", "Expected popup text {" + expectedNotificationPopupText + "} but found Popup text {" + actPopupTextValue + "}");
                        }
                    }
                    else
                    {
                        Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.Self);
                        Ranorex.Report.Failure("Failure", "Expected popup header {" + expNotificationPopupHeader + "} but found Popup header {" + actPopupHeader + "}");
                    }
                }
                else
                {
                    Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                    Ranorex.Report.Failure("Failure","Notification Popup is not present for validating.");
                }
                retries = 0;
            }
            else
            {
                while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 3 )
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }

                if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Success("Success","Notifications Popup is NOT present as expected");
                }
                else
                {
                    Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                    Ranorex.Report.Failure("Failure","Notification Popup is Exist.");
                }
            }
        }

        /// <summary>
        /// Pre-condition : Communication_Exchange_Form' should be opened.
        /// Validates presence of Line12 in 'CommunicationsExchangeForm'.
        /// </summary>
        /// <param name="expLine12Exist">Input:Pass 'True' if user is expecting Line12 to be present or else 'False'</param>
        [UserCodeMethod]
        public static void ValidatePresenceOfLine12InCommunicationExchangeForm(bool expLine12Exist)
        {
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                bool actLine12Exist = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box12.SelfInfo.Exists(0);
                if(actLine12Exist == expLine12Exist)
                {
                    Ranorex.Report.Success("Expected presence of Line12 to be {"+expLine12Exist+"} and found to be {"+actLine12Exist+"}.");
                    return;
                }
                else
                {
                    Ranorex.Report.Failure("Expected presence of Line12 to be {"+expLine12Exist+"} but found to be {"+actLine12Exist+"}.");
                    return;
                }
            }
            else
            {
                Ranorex.Report.Error("Communication Exchange Form is not opened");
                return;
            }
        }

        /// <summary>
        /// Deny Authority Communication Exchange form
        /// </summary>
        /// <param name="commentsText">Input:commentsText</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        [UserCodeMethod]
        public static void NS_DenyAuthority_CommunicationsExchangeForm(string commentsText, string expectedFeedback)
        {
            int retries = 0;
            string trackAuthorityNumber = "";
            string authoritySeed = "";
            AuthorityObject authorityObj = null;
            while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0) && retries < 5)
            {
                Delay.Milliseconds(500);
                retries ++;
            }
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                if(!string.IsNullOrEmpty(commentsText))
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.AddCommentsButtonInfo,
                                                              Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.CommentTextInfo);
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.CommentText.Element.SetAttributeValue("Text", commentsText);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.OkButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.SelfInfo);
                }

                Ranorex.Report.Info("Denying Authority");

                trackAuthorityNumber = Authoritiesrepo.Communications_Exchange_Ok_Authority.AuthorityNumberText.TextValue;
                authoritySeed = GetAuthoritySeed(trackAuthorityNumber);
                Ranorex.Report.Info("Authority Number:"+trackAuthorityNumber+"Authority Seed:"+authoritySeed);
                authorityObj = GetAuthorityObject(authoritySeed);
                if (!String.IsNullOrEmpty(authorityObj.extendUntilTime))
                {
                    authorityObj.extendUntilTime = "";
                }
                Authoritiesrepo.Communications_Exchange_Ok_Authority.DenyButton.Click();

                if(!string.IsNullOrEmpty(expectedFeedback))
                {
                    if (!CheckFeedbackExists(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback, expectedFeedback))
                    {
                        Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                        Ranorex.Report.Failure("Received Feedback message of {" + Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback.GetAttributeValue<string>("Text") + "}, expected {" + expectedFeedback + "}.");
                    }
                    else
                    {
                        Ranorex.Report.Success("Received Feedback message: "+Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback.GetAttributeValue<string>("Text"));
                    }
                }
            }
            else
            {
                Ranorex.Report.Failure("Communication Exchange form doest not Exist");
                return;
            }

            retries = 0;
            while(Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0) && retries < 5)
            {
                Delay.Milliseconds(500);
                retries ++;
            }
            if(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                Ranorex.Report.Info("RUM Request is Denied and Communication Exchange form is closed Succesfully");
            }
            else{
                Ranorex.Report.Info("RUM Request is Denied and Communication Exchange form is still opened");
            }
            return;
        }


        [UserCodeMethod]
        public static void NS_Fill_RollupLocation_CheckFeedback_CommunicationExchangeForm(string authoritySeed, string rollupLocation, string expectedFeedback, bool closeForm=false)
        {
            NS_OpenAuthority_AuthoritySummaryList(authoritySeed);

            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                if(!String.IsNullOrEmpty(rollupLocation))
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.RollupInfoByText.Click();
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.RollupInfoByText.Element.SetAttributeValue("Text", rollupLocation);
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.RollupInfoByText.PressKeys("{TAB}");
                }
                else
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.RollupInfoByText.Click();
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.RollupInfoByText.PressKeys("{TAB}");
                }

                GeneralUtilities.CheckWaitState(3);

                if(!CheckFeedbackExists(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback,expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                    Ranorex.Report.Failure("Unexpected Feedback received");
                }
                else
                {
                    Ranorex.Report.Info("Feedback received matches the exected feedback");
                }
                if(closeForm)
                {
                    if(Authoritiesrepo.Track_Authority_Summary_List.SelfInfo.Exists(0))
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Track_Authority_Summary_List.WindowControls.CloseInfo,
                                                                          Authoritiesrepo.Track_Authority_Summary_List.SelfInfo);
                    }
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                }
            }
            else
            {
                Ranorex.Report.Failure("Authority Communication Form did not open for Authority Number:"+GetAuthorityNumber(authoritySeed));
                return;
            }
        }

        [UserCodeMethod]
        public static void NS_Fill_ClearByField_CommunicationExchangeForm(string authoritySeed, string copiedBy, string expectedFeedback,bool clickYes, bool closeForm=false)
        {
            NS_OpenAuthority_AuthoritySummaryList(authoritySeed);

            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                if(GetAuthorityType(authoritySeed).Equals("RW"))
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.Click();

                    GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsTextInfo,
                                                              Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.YesInfo);
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsList.Yes.Click();
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.JointOccupants.JointOccupantsText.PressKeys("{TAB}");

                }
                if(Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.GetAttributeValue<string>("Text").Equals(copiedBy))
                {
                    Ranorex.Report.Info("Clear By field already filled with expected value");
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.Click();
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.PressKeys("{TAB}");
                }
                else
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.Click();
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.Element.SetAttributeValue("Text", copiedBy);
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.LimitsReportedClearByText.PressKeys("{TAB}");
                }

                GeneralUtilities.CheckWaitState(3);

                if(!CheckFeedbackExists(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback,expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                    Ranorex.Report.Failure("Unexpected Feedback received");
                }
                else
                {
                    Ranorex.Report.Info("Feedback received matches the expected feedback");
                }

                if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.SelfInfo.Exists(0) && clickYes)
                {
                    Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.YesButton.Click();
                    Report.Info("Acknowledging the Releaser Not Copier Popup");
                }
                else
                {
                    if(Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.SelfInfo.Exists(0))
                    {
                        Authoritiesrepo.Communications_Exchange_Ok_Authority.Releaser_Not_Copier.NoButton.Click();
                        Report.Info("Not Acknowledging the Releaser Not Copier Popup");
                    }
                }

                if(!CheckFeedbackExists(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback,expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                    Ranorex.Report.Failure("Unexpected Feedback received");
                }
                else
                {
                    Ranorex.Report.Info("Feedback received matches the exected feedback");
                }

                if(closeForm)
                {
                    if(Authoritiesrepo.Track_Authority_Summary_List.SelfInfo.Exists(0))
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Track_Authority_Summary_List.WindowControls.CloseInfo,
                                                                          Authoritiesrepo.Track_Authority_Summary_List.SelfInfo);
                    }
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                    return;
                }
            }
            else
            {
                Ranorex.Report.Failure("Authority Communication Form did not open for Authority Number:"+GetAuthorityNumber(authoritySeed));
                return;
            }
        }

        [UserCodeMethod]
        public static void NS_ValidateCommunicationExchangeFormState(bool extendUntilEnabled,bool rollupLocationEnabled, bool recordedAtEnabled, bool closeForm=false)
        {
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {

                if(Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendUntilText.Enabled != extendUntilEnabled)
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                    Ranorex.Report.Failure("Extend By Field is not in correct state, current state enabled is:"+Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendUntilText.Enabled.ToString());
                }
                else if(Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendOSLocationText.Enabled != rollupLocationEnabled)
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                    Ranorex.Report.Failure("Rollup OS Location Field is not in correct state, current state enabled is:"+Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendOSLocationText.Enabled.ToString());
                }
                else if(Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendRecordedTimeText.Enabled != recordedAtEnabled)
                {
                    Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                    Ranorex.Report.Failure("Extend Time Field is not in correct state, current state enabled is:"+Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendRecordedTimeText.Enabled.ToString());
                }
                else
                {
                    Ranorex.Report.Success("All fields on Communication Exchange form are disabled after entering Clear By Value");
                }


                if(closeForm)
                {
                    if(Authoritiesrepo.Track_Authority_Summary_List.SelfInfo.Exists(0))
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Track_Authority_Summary_List.WindowControls.CloseInfo,
                                                                          Authoritiesrepo.Track_Authority_Summary_List.SelfInfo);
                    }
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                    return;
                }
            }
            else
            {
                Ranorex.Report.Failure("Authority Communication Form is not open to validate fields state");
                return;
            }

        }


        /// <summary>
        /// Click on 'Suspend/Pause' button in Create Authority form
        /// </summary>
        [UserCodeMethod]
        public static void ClickSuspendButton_CreateAuthorityform(bool closeForms)
        {
            int retries = 0;
            while(!Authoritiesrepo.Create_Track_Authority.RibbonMenu.Suspend.Enabled && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if(Authoritiesrepo.Create_Track_Authority.RibbonMenu.Suspend.Enabled)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.RibbonMenu.SuspendInfo,
                                                                  Authoritiesrepo.Create_Track_Authority.SelfInfo);
                if(!Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Success("Successfully clicked on SUSPEND/PAUSE button in Create_Authority form");
                }
                else
                {
                    Ranorex.Report.Failure("Create_Authority form should be disappeared after clicking on SUSPEND button but still exists");
                }
            }
            else
            {
                Ranorex.Report.Failure("SUSPEND/PAUSE Button is not enabled to click");
                Report.Screenshot(Authoritiesrepo.Create_Track_Authority.Self);
            }

            if(closeForms)
            {
                if(Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo,
                                                                      Authoritiesrepo.Create_Track_Authority.SelfInfo);
                }

            }
        }


        /// <summary>
        /// Close pending Autority Forms
        /// </summary>
        [UserCodeMethod]
        public static void NS_PendingAutorityFormsCloser_Rum()
        {
        	if (Authoritiesrepo.Open_Autority_Form_PopUp.SelfInfo.Exists(0))
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Open_Autority_Form_PopUp.CloseButtonInfo,
        		                                                  Authoritiesrepo.Open_Autority_Form_PopUp.SelfInfo);
        		Ranorex.Report.Info("POP up has appeared for previours action was not done right");
        	}
        	if (Authoritiesrepo.Please_Confirm_PopUp.SelfInfo.Exists(0))
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Please_Confirm_PopUp.YesButtonInfo,
        		                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
        	}
        	if (Authoritiesrepo.Create_Track_Authority.Enter_Comments.CommentTextInfo.Exists(0))
        	{
        		Authoritiesrepo.Create_Track_Authority.Enter_Comments.CommentText.Element.SetAttributeValue("Text", "Automation");
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Enter_Comments.OkButtonInfo,
        		                                                  Authoritiesrepo.Create_Track_Authority.Enter_Comments.SelfInfo);
        		Ranorex.Report.Info("Denying Authority");
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.DenyButtonInfo,
        		                                                  Authoritiesrepo.Create_Track_Authority.SelfInfo);
        	}
        	if (Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
        	{
        		Ranorex.Report.Info("Communication Form Exist hence closing it");
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
        	}
        	if(Authoritiesrepo.Remote_Track_Authority_Request.SelfInfo.Exists(0))
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Remote_Track_Authority_Request.AcknowledgeButtonInfo,Authoritiesrepo.Remote_Track_Authority_Request.SelfInfo);
        		Ranorex.Report.Info("Acknowledge Button and performed click on it.");
        	}
        	if(Miscellaneousrepo.Task_List.SelfInfo.Exists(0))
        	{
        		Miscellaneousrepo.Task_List.CloseButton.Click();
        		Ranorex.Report.Info("Task List Form exit closed it");
        	}
        	NS_RemovePendingAuthoritiesFromTaskList(true);
        }

        /// <summary>
        /// </summary>
        public static void NS_GetPendingAuthorityCountFromMainMenu()
        {
        	string authorityCount = MainMenurepo.PDS_Main_Menu.RibbonMenu.PendingTAsCount.GetAttributeValue<string>("Text");
        	pendingAuthorityCount = int.Parse(authorityCount);
        }

        /// <summary>
        /// Validate pending Authority count from Main Menu
        /// </summary>
        /// <param name="expectedAuthorityCount">input :expectedAuthorityCount</param>
        [UserCodeMethod]
        public static void NS_ValidatePendingAuthorityCount(int expauthorityCount)
        {
        	string authorityCount = MainMenurepo.PDS_Main_Menu.RibbonMenu.PendingTAsCount.GetAttributeValue<string>("Text");
        	int actualAuthorityCount = int.Parse(authorityCount);
        	int expectedAuthorityCount = pendingAuthorityCount + expauthorityCount;
        	if(actualAuthorityCount == expectedAuthorityCount)
        	{
        		Ranorex.Report.Success("Pendindg Authority count Actual{"+actualAuthorityCount+"} and Expected {"+expectedAuthorityCount+"}.");
        		return;
        	}
        	else
        	{

        		Ranorex.Report.Screenshot(MainMenurepo.PDS_Main_Menu.Self);
        		Ranorex.Report.Failure("Pendindg Authority count Actual{"+actualAuthorityCount+"} and Expected{"+expectedAuthorityCount+"}.");
        		return;
        	}

        }

        /// <summary>
        /// Remove pending authorities and pending bulletin Tasks from the Taks List
        /// </summary>
        /// <param name="closeForm">Input:closeForm </param>
        [UserCodeMethod]
        public static void NS_RemovePendingAuthoritiesFromTaskList(bool closeForm)
        {
        	int counter = 0;
        	NS_Miscellaneous.NS_OpenTaskListForm_MainMenu();
        	int taskRows = Miscellaneousrepo.Task_List.Tasks.TasksTable.Self.Rows.Count;
        	for(int i = 0; i < taskRows; i++)
        	{
        		Miscellaneousrepo.TaskIndex = counter.ToString();
        		string descriptionText = Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.TaskDescription.Text.ToLower();
        		string priorityText = Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.Priority.Text.ToLower();
        		if((descriptionText.Contains("o/t issue request received") || descriptionText.Contains("r/w issue request received") || descriptionText.Contains("t/e issue request received")))
        		{
        			GeneralUtilities.RightClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.MenuCellInfo,
        			                                               Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.SelfInfo);

        			GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.OpenInfo,
        			                                          Authoritiesrepo.Create_Track_Authority.SelfInfo);

        			GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Create_Track_Authority.AddCommentsButtonInfo,
        			                                          Authoritiesrepo.Create_Track_Authority.Enter_Comments.SelfInfo);

        			Authoritiesrepo.Create_Track_Authority.Enter_Comments.CommentText.Element.SetAttributeValue("Text", "Automation");
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Enter_Comments.OkButtonInfo,
        			                                                  Authoritiesrepo.Create_Track_Authority.Enter_Comments.SelfInfo);

        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.DenyButtonInfo,
        			                                                  Authoritiesrepo.Create_Track_Authority.SelfInfo);
        		}
        		else if(((descriptionText.Contains("o/t extend request received")) || (descriptionText.Contains("o/t void request received")) || (descriptionText.Contains("o/t rollup request received")) ||
        		         (descriptionText.Contains("r/w extend request received")) || (descriptionText.Contains("r/w void request received")) || (descriptionText.Contains("r/w rollup request received")) ||
        		         (descriptionText.Contains("t/e extend request received")) || (descriptionText.Contains("t/e void request received")) || (descriptionText.Contains("t/e rollup request received"))))

        		{

        			GeneralUtilities.RightClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.MenuCellInfo,
        			                                               Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.SelfInfo);
        			GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.OpenInfo,
        			                                          Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);

        			GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.AddCommentsButtonInfo,
        			                                          Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.SelfInfo);
        			Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.CommentText.Element.SetAttributeValue("Text", "Automation");
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.OkButtonInfo,
        			                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.Enter_Comments.SelfInfo);
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.DenyButtonInfo,
        			                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
        		}
        		else if(descriptionText.Contains("complete track authority suspended"))
        		{
        			GeneralUtilities.RightClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.MenuCellInfo,
        			                                               Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.SelfInfo);

        			GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.OpenInfo,
        			                                          Authoritiesrepo.Create_Track_Authority.SelfInfo);
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.CancelButtonInfo ,Authoritiesrepo.Create_Track_Authority.SelfInfo);
        		}
        		else
        		{
        			counter++;
        		}

        	}
        	if(closeForm)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Task_List.CloseButtonInfo,Miscellaneousrepo.Task_List.SelfInfo);
        	}
        }

        /// <summary>
        /// Validate Task List Options Enabled or Disabled using Description and Employee Name
        /// </summary>
        /// <param name="optTrainSeed">Required only for TE authority</param>
        /// <param name="optEngineSeed">Required only for TE authority</param>
        /// <param name="type">TE,OT,RW</param>
        /// <param name="requestType">Issue,Extend,Rollup,Void values can be provided</param>
        /// <param name="employee_name">employee_name</param>
        /// <param name="enabledTaskListMenuOption">Pass the options name which is expected to be Enabled(e.g. Open)</param>
        /// <param name="disabledTaskListMenuOption">Pass the options name which is expected to be disabled(e.g. Delete)</param>
        /// <param name="expectTask"></param>
        [UserCodeMethod]
        public static void NS_ValidateAuthorityTaskListMenuOptionsEnabledDisabled(string trainSeed, string engineSeed, string type, string requestType, string employeeName, string enabledTaskListMenuOption, string disabledTaskListMenuOption)
        {
            string description = "";
            requestType = requestType.ToLower();
            if (type.Equals("TE"))
            {
                if (string.IsNullOrEmpty(trainSeed) | string.IsNullOrEmpty(engineSeed))
                {
                    Ranorex.Report.Error("Train seed or engine seed not provided for TE Authority.");
                    return;
                }

                switch(requestType)
                {
                    case "issue":
                        description = "T/E issue request received from";
                        break;
                    case "extend":
                        description = "T/E extend request received from";
                        break;
                    case "void":
                        description = "T/E void request received from";
                        break;
                    case "rollup":
                        description = "T/E rollup request received from";
                        break;
                    default:
                        Ranorex.Report.Error("Invalid Request Type Received");
                        break;
                }

                string engineId = NS_TrainID.GetEngineInitial(trainSeed, engineSeed) + " " + NS_TrainID.GetEngineNumber(trainSeed, engineSeed);
                string employeeId = "";
                employeeId = NS_TrainID.GetTrainId(trainSeed) + " (" + engineId + ")";
                NS_Miscellaneous.NS_ValidateTaskListOptionsEnabledAndDisabled(description, employeeId, enabledTaskListMenuOption, disabledTaskListMenuOption);
            }
            if (type.Equals("OT"))
            {
                switch(requestType)
                {
                    case "issue":
                        description = "O/T issue request received from";
                        break;
                    case "extend":
                        description = "O/T extend request received from";
                        break;
                    case "void":
                        description = "O/T void request received from";
                        break;
                    default:
                        Ranorex.Report.Error("Invalid Request Type Received: "+requestType);
                        break;
                }
                NS_Miscellaneous.NS_ValidateTaskListOptionsEnabledAndDisabled(description, employeeName, enabledTaskListMenuOption, disabledTaskListMenuOption);
            }
            if (type.Equals("RW"))
            {
                switch(requestType)
                {
                    case "issue":
                        description = "R/W issue request received from";
                        break;
                    case "extend":
                        description = "R/W extend request received from";
                        break;
                    case "rollup":
                        description = "R/W rollup request received from";
                        break;
                    case "void":
                        description = "R/W void request received from";
                        break;
                    default:
                        Ranorex.Report.Error("Invalid Request Type Received: "+requestType);
                        break;
                }
                NS_Miscellaneous.NS_ValidateTaskListOptionsEnabledAndDisabled(description, employeeName, enabledTaskListMenuOption, disabledTaskListMenuOption);
            }

        }
        /// Validates presence of 'Notification' popup in 'Communication Exchange' form
        /// <param name="isExpPresenceOfNotificationPopup">Input:Pass - True, if user is expecting Notification popup to appear
        ///                                                Input:Pass - False, if user is not expecting Notification popup to appear</param>
        [UserCodeMethod]
        public static void ValidatePresenceOfNotificationPopup_CommunicationExchangeForm(bool isExpPresenceOfNotificationPopup)
        {
        	int retries = 0;

        	// Incase any lags
        	while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0) && retries < 3 )
        	{
        		Ranorex.Delay.Milliseconds(500);
        		retries++;
        	}

        	bool isActPresenceOfNotificationPopup = Authoritiesrepo.Communications_Exchange_Ok_Authority.Notifications_Form.SelfInfo.Exists(0);

        	if(isActPresenceOfNotificationPopup == isExpPresenceOfNotificationPopup)
        	{
        		Report.Success("Presence of Notification Popup expected to be {" +isExpPresenceOfNotificationPopup+"} and found {" +isActPresenceOfNotificationPopup+ "}.");
        	}
        	else
        	{
        		Report.Failure("Presence of Notification Popup expected to be {" +isExpPresenceOfNotificationPopup+"} but found {" +isActPresenceOfNotificationPopup+ "}.");
        	}
        }


        /// <summary>
        /// Fill the 'OS Location' in Communication_Exchange form and validate feedback if any
        /// </summary>
        /// <param name="authoritySeed">Input:authoritySeed</param>
        /// <param name="rollupLocation">Input:rollupLocation</param>
        /// <param name="expectedFeedback">Input:rollupLocation</param>
        /// <param name="closeForm">Input:rollupLocation</param>
        [UserCodeMethod]
        public static void Fill_OSLocation_CheckFeedback_CommunicationExchangeForm(string authoritySeed, string rollupLocation, string expectedFeedback, bool closeForm=false)
        {
        	NS_OpenAuthority_AuthoritySummaryList(authoritySeed);

        	if(Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
        	{
        		if(!String.IsNullOrEmpty(rollupLocation))
        		{
        			Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendOSLocationText.Click();
        			Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendOSLocationText.Element.SetAttributeValue("Text", rollupLocation);
        			Authoritiesrepo.Communications_Exchange_Ok_Authority.ExtendOSLocationText.PressKeys("{TAB}");
        			Report.Info("Entered OS Location " + rollupLocation);
        		}
        		else
        		{
        			Authoritiesrepo.Communications_Exchange_Ok_Authority.RollupInfoByText.Click();
        			Authoritiesrepo.Communications_Exchange_Ok_Authority.RollupInfoByText.PressKeys("{TAB}");
        		}

        		GeneralUtilities.CheckWaitState(3);

        		if(!CheckFeedbackExists(Authoritiesrepo.Communications_Exchange_Ok_Authority.Feedback, expectedFeedback))
        		{
        			Ranorex.Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
        			Ranorex.Report.Failure("Unexpected Feedback is received");
        		}
        		else
        		{
        			Ranorex.Report.Info("Feedback received matches the expected feedback");
        		}

        		if(closeForm)
        		{
        			if(Authoritiesrepo.Track_Authority_Summary_List.SelfInfo.Exists(0))
        			{
        				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Track_Authority_Summary_List.WindowControls.CloseInfo,
        				                                                  Authoritiesrepo.Track_Authority_Summary_List.SelfInfo);
        			}
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
        			                                                  Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
        		}
        	}
        	else
        	{
        		Ranorex.Report.Failure("Authority Communication Form did not open for Authority Number: "+GetAuthorityNumber(authoritySeed));
        		return;
        	}
        }

         /// <summary>
         /// Click on 'Update' button in 'Communication Exchange' form
         /// </summary>
         [UserCodeMethod]
         public static void ClickUpdateButton_CommunicationExchangeForm()
         {
         	//Click on Update button
         	int retries = 0;
         	while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.UpdateButton.Enabled && retries < 3) {
         		Ranorex.Delay.Milliseconds(500);
         		retries++;
         	}

         	if (Authoritiesrepo.Communications_Exchange_Ok_Authority.UpdateButton.Enabled)
         	{
         		Authoritiesrepo.Communications_Exchange_Ok_Authority.UpdateButton.Click();
         		Report.Info("Clicked Update Button to Extend Authority");
         	}
         	else
         	{
         		Ranorex.Report.Failure("Update Button was not enabled after multiple retries");
         		Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
         		Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
         		return;
         	}
         }

         /// <summary>
         /// Click on 'Acknowledge' button in 'Communication Exchange' form
         /// </summary>
         [UserCodeMethod]
         public static void ClickAcknowledgeButton_CommunicationExchangeForm()
         {
         	//Wait for Acknowledge Button to exist and click it
         	int retries = 0;
         	while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0) && retries < 3)
         	{
         		Ranorex.Delay.Milliseconds(500);
         		retries++;
         	}

         	if (Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo.Exists(0))
         	{
         		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.AcknowledgeButtonInfo,
         		                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
         		Report.Info("Acknowledging the Authority");
         	}
         	else
         	{
         		Ranorex.Report.Failure("Acknowledge Form did not appear");
         		Authoritiesrepo.Communications_Exchange_Ok_Authority.CancelButton.Click();
         		Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButton.Click();
         		return;
         	}
         }

         [UserCodeMethod]
         public static void NS_CloseCommunicationExchangeFormFromFileMenu(bool acceptConfirmPopUp)
         {
         	int retries = 0;
         	while (!Authoritiesrepo.Communications_Exchange_Ok_Authority.WindowControls.CloseInfo.Exists(0) && retries < 3)
        	{
        		Ranorex.Delay.Milliseconds(500);
        		retries++;
        	}
         	Authoritiesrepo.Communications_Exchange_Ok_Authority.MainMenuBar.FileButton.Click();
         	GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.FileMenu.CloseInfo,
         	                                          Authoritiesrepo.Please_Confirm_PopUp.SelfInfo);
         	if(acceptConfirmPopUp)
         	{
         		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Please_Confirm_PopUp.YesButtonInfo,
        		                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
        		Ranorex.Report.Info("Denying Autority by closing the Form");
         	}
         	else
         	{
         		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Please_Confirm_PopUp.NoButtonInfo,
        		                                                              Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
         	}
         	return;
         }



         [UserCodeMethod]
         public static void NS_ValidatePendingTrackAuthority_TrackLine(string authoritySeed)
         {
         	if (!authorityDictionary.ContainsKey(authoritySeed))
         	{
         		Ranorex.Report.Error("No authority for authority seed {"+authoritySeed+"}.");
                return;
         	}

         	AuthorityObject authority = authorityDictionary[authoritySeed];

         	Tracklinerepo.TrainId = authority.authorityNumber + " " + "PENDING";
         	if(Tracklinerepo.Trackline_Form.AuthorityObjectInfo.Exists(0))
            {

                    Ranorex.Report.Success("Track Authority with number {"+authority.authorityNumber+"} with text PENDING has found on trackline");
         	}
         	else
         	{
         		Ranorex.Report.Failure("Track Authority with number {"+authority.authorityNumber+"} with text PENDING not found on trackline");
         	}
         }
         public static string NS_ADMSGetAuthorityId(string authoritySeed)
         {
             string authorityNumber = NS_Authorities.GetAuthorityNumber(authoritySeed);
             if (authorityNumber == null)
        	 {
        		 authorityNumber = authoritySeed;
        	 }

             return Oracle.Code_Utils.ADMSEnvironment.GetAuthorityId_ADMS(authorityNumber);
         }

        /// <summary>
        /// Pre-condition : Communication_Exchange_Form' should be opened.
        /// Validates presence of Line8 in 'CommunicationsExchangeForm'.
        /// </summary>
        /// <param name="expLine8Exist">Input:Pass 'True' if user is expecting Line8 to be present or else 'False'</param>
        [UserCodeMethod]
        public static void ValidatePresenceOfLine8_CommunicationExchangeform(bool expLine8IsPresent)
        {
            if(Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
            {
                bool actLine8IsPresent = Authoritiesrepo.Communications_Exchange_Ok_Authority.Box8.SelfInfo.Exists(0);
                if(actLine8IsPresent == expLine8IsPresent)
                {
                    Ranorex.Report.Success("Expected presence of Line8 to be {"+expLine8IsPresent+"} and found to be {"+actLine8IsPresent+"}.");
                    return;
                }
                else
                {
                    Ranorex.Report.Failure("Expected presence of Line8 to be {"+expLine8IsPresent+"} but found to be {"+actLine8IsPresent+"}.");
                    Report.Screenshot(Authoritiesrepo.Communications_Exchange_Ok_Authority.Self);
                    return;
                }
            }
            else
            {
                Ranorex.Report.Error("Communication Exchange Form did not open");
                return;
            }
        }

        /// <summary>
        /// Remove Extend Until Time Object from authority dictionary
        /// </summary>
        /// <param name="authoritySeed">Input:authoritySeed</param>
        [UserCodeMethod]
        public static void NS_RemoveExtendUntilTimeFromAuthorityObject(string authoritySeed)
        {
        	AuthorityObject authorityObj = PDS_NS.UserCodeCollections.NS_Authorities.GetAuthorityObject(authoritySeed);
        	if (!string.IsNullOrEmpty(authorityObj.extendUntilTime))
        	{
        		authorityObj.extendUntilTime = "";
        		Ranorex.Report.Info("Remove extend until time object from authority dictionary.");
        	}
        }

        [UserCodeMethod]
        public static void NS_ValidateEngineId (string trainSeed, string engineSeed)
        {
        	string engineId = "";
        	if (trainSeed == "")
        		engineId = engineSeed;
        	else
        		engineId = NS_TrainID.GetEngineObjectFromTrain(trainSeed, engineSeed).EngineNumber;

        	if  (Authoritiesrepo.Create_Track_Authority.To.EngineToText.Text.Contains(engineId))
        		Report.Success("Engine {"+engineId+"} present as expected");
        	else
        		Report.Failure("Engine {"+engineId+"} not found. Actual engine found = {"+Authoritiesrepo.Create_Track_Authority.To.EngineToText.Text+"}");
        }

        [UserCodeMethod]
        public static void NS_HandleNotificationPopup_CreateTrackAuthority(bool clickOnYes = false)
        {
        	if(Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo.Exists(0))
        	{
        		Authoritiesrepo.Create_Track_Authority.Notifications_Form.Self.Activate();
        		if(clickOnYes)
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.YesButtonInfo,
        			                                                  Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);
        		}
        		else
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Create_Track_Authority.Notifications_Form.GenericNotification.NoButtonInfo,
        			                                                  Authoritiesrepo.Create_Track_Authority.Notifications_Form.SelfInfo);
        		}
        	}
        	else
        	{
        		Ranorex.Report.Error("Notification Popup does not exists");
        		return;
        	}
        }

        [UserCodeMethod]
        public static void NS_EnterAtLocation_CreateTrackAuthority(string atLocation)
        {
        	if(Authoritiesrepo.Create_Track_Authority.SelfInfo.Exists(0))
        	{
        		if(Authoritiesrepo.Create_Track_Authority.At.AtText.Enabled)
        		{
        			Authoritiesrepo.Create_Track_Authority.At.AtText.Element.SetAttributeValue("Text", atLocation);
        			Authoritiesrepo.Create_Track_Authority.At.AtText.PressKeys("{TAB}");
        		}
        		else
        		{
        			Ranorex.Report.Error("At textbox is in disabled state");
        			return;
        		}
        	}
        	else
        	{
        		Ranorex.Report.Error("Create Track Authority form doesn not exists");
        		return;
        	}
        }


        [UserCodeMethod]
		public static void NS_ValidateTrackAuthorityFormEnabled_TrackAuthorityMenu(string formName, bool expectedFormEnabled = true)
		{
			bool actualformEnabled = true;
			//open track authority menu
			GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrackAuthoritesButtonInfo,
			                                          MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.SummaryListInfo);

			switch(formName.ToLower())
			{
				case "totrainorengine":
					if(!MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.ToTrainOrEngine.Enabled)
					{
						actualformEnabled = false;
					}
					break;
				case "toroadwayworker":
					if(!MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.ToRoadwayWorker.Enabled)
					{
						actualformEnabled = false;
					}
					break;
				case "toontrackequipment":
					if(!MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.ToOnTrackEquipment.Enabled)
					{
						actualformEnabled = false;
					}
					break;

				default : Ranorex.Report.Error("Invalid Form Name. Valid form name are : totrainorengine, toroadwayworker and toontrackequipment.");
					break;
			}

			if(actualformEnabled == expectedFormEnabled)
			{
				Ranorex.Report.Success("Expected Track Authority form Enabled as :{"+expectedFormEnabled+"} and actual found as :{"+actualformEnabled+"}");
			}
			else{
				Ranorex.Report.Failure("Expected Track Authority form Enabled as :{"+expectedFormEnabled+"} and actual found as :{"+actualformEnabled+"}");
			}
			//close track authority menu
			GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrackAuthoritesButtonInfo,
			                                                  MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.SummaryListInfo);
		}

		[UserCodeMethod]
		public static void NS_ValidateNoOverlappingAuthority_Trackline(string authoritySeed)
		{
		    int actAuthoritiesCount = 0;
		    int retries = 0;
		    if (!authorityDictionary.ContainsKey(authoritySeed))
		    {
		        Ranorex.Report.Error("No authority for authority seed {"+authoritySeed+"}.");
		        return;
		    }

		    AuthorityObject authority = authorityDictionary[authoritySeed];
		    //Authorities are displayed like a train and use trainid
		    if (authority.trackAuthorityType == "TE") {
		        Ranorex.Report.Info("Engine Seed:"+authority.engineSeed);
		        Ranorex.Report.Info("Engine Initial:"+PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authority.trainSeed, authority.engineSeed).EngineInitial.ToString());
		        Ranorex.Report.Info("Engine Number:"+PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authority.trainSeed, authority.engineSeed).EngineNumber.ToString());
		        Tracklinerepo.TrainId = authority.authorityNumber + " " + PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(authority.trainSeed) + " ("+PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authority.trainSeed, authority.engineSeed).EngineInitial + " " + PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authority.trainSeed, authority.engineSeed).EngineNumber + ")";
		    } else {
		        Tracklinerepo.TrainId = authority.authorityNumber + " " + authority.rWOrOtWorker;
		    }
		    while(!Tracklinerepo.Trackline_Form.MenuAuthorityObjectInfo.Exists(0) && retries < 5)
		    {
		        Tracklinerepo.Trackline_Form.AuthorityObject.Click(WinForms.MouseButtons.Middle);
		        Delay.Milliseconds(500);
		        retries++;
		    }
		    if(Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.SelfInfo.Exists(0))
		    {
		        actAuthoritiesCount = (Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.Self.Rows.Count)-2;
		    }
		    else
		    {
		        Ranorex.Report.Error("Failed to find the Departure list table");
		    }
		    if(actAuthoritiesCount == 1)
		    {
		        Ranorex.Report.Success("Authorities Count present on trackline :{"+actAuthoritiesCount.ToString()+"} and no overlapping authority present on Track line.");
		    }
		    else
		    {
		        Ranorex.Report.Failure("Authorities Count present on trackline :{"+actAuthoritiesCount.ToString()+"} and overlapping authority present on Track line.");
		    }
		    if(Tracklinerepo.Trackline_Form.AuthorityObjectInfo.Exists(0))
		    {
		        Tracklinerepo.Trackline_Form.AuthorityObject.Click(WinForms.MouseButtons.Middle);
		    }
		    else
		    {
		        Ranorex.Report.Error("No authority Present on Track line");
		    }
		}
		
		/// <summary>
		/// Click Acknowledge on PTC Alert for Track Authority Roll-up Request 
		/// </summary>
		[UserCodeMethod]
		public static void NS_AcknowledgePTCAlertforTrackAuthorityRollUp()
		{
			int retries = 0;
			while(!Authoritiesrepo.PTC_Track_Authority_Roll_Up_Acknowledge_Popup.SelfInfo.Exists(0) && retries <3)
			{
				Ranorex.Delay.Milliseconds(300);
				retries++;
			}
			
			if(Authoritiesrepo.PTC_Track_Authority_Roll_Up_Acknowledge_Popup.SelfInfo.Exists(0))
			{
				Ranorex.Report.Info("TestStep", "clicking acknowledge button");
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.PTC_Track_Authority_Roll_Up_Acknowledge_Popup.AcknowlegdeButtonInfo,
				                                                  Authoritiesrepo.PTC_Track_Authority_Roll_Up_Acknowledge_Popup.SelfInfo);	
			}else{
				Ranorex.Report.Error("PTC Alert for Track Authority Roll-up request not found");
			}
		}
			
		/// <summary>
		/// Validate PTC Alert for Track Authority Roll-up Request 
		/// </summary>
		/// <param name="expectExists"></param>
		[UserCodeMethod]
		public static void NS_ValidatePTCAlertforTrackAuthorityRollUpExists(bool expectExists)
		{
			int retries = 0;
			while(!Authoritiesrepo.PTC_Track_Authority_Roll_Up_Acknowledge_Popup.SelfInfo.Exists(0) && retries <3)
			{
				Ranorex.Delay.Milliseconds(300);
				retries++;
			}
			
			bool actualExists = Authoritiesrepo.PTC_Track_Authority_Roll_Up_Acknowledge_Popup.SelfInfo.Exists(0);
			
			if(actualExists == expectExists)
			{
				Ranorex.Report.Success("Expected PTC Alert for Track Authority Roll up Request to exists as :{"+expectExists+"} and found as :{"+actualExists+"}.");
			}
			else{
				Ranorex.Report.Failure("Expected PTC Alert for Track Authority Roll up Request to exists as :{"+expectExists+"} and found as :{"+actualExists+"}.");
			}
		}
		
		/// <summary>
		/// Input release by and click clear button to void authority
		/// </summary>
		/// <param name="releaseBy"></param>
		[UserCodeMethod]
		public static void PTC_VoidActiveTrackAuthority_CommunicationExchange(string releaseBy)
		{
			int retries =0;
			while(!Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0) && retries < 3)
			{
				Ranorex.Delay.Milliseconds(300);
				retries++;
			}
			
			//check if Active authority form exists 
			if(Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo.Exists(0))
			{
				Authoritiesrepo.Communications_Exchange_Ok_Authority.Self.Activate();
				Authoritiesrepo.Communications_Exchange_Ok_Authority.ReleaseInfoByText.Click();
				Authoritiesrepo.Communications_Exchange_Ok_Authority.ReleaseInfoByText.Element.SetAttributeValue("Text",releaseBy);
				Keyboard.Press("{TAB}");
				
				//check if Clear button is enabled after inputting Released by information
				if (Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButton.Enabled)
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.ClearButtonInfo,
					                                          Authoritiesrepo.Communications_Exchange_Ok_Authority.VoiceButtonInfo);
                    Report.Info("Clicked Clear Button to Void Authority");
                } else {
                    Ranorex.Report.Failure("Clear Button was not enabled after inputting Limits Released By");
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Communications_Exchange_Ok_Authority.CloseButtonInfo,
                                                                      Authoritiesrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                    return;
                }	
			}
			else{
				Ranorex.Report.Failure("Active Track Authority form does not exists. ");
				return;
			}	
		}
		[UserCodeMethod]
		public static void NS_ValidateTrackAuthorityTextColor_PendingAndOtherStates_TrackLine(string authoritySeed, string color, string validateText)
		{
		    bool result = false;
		    if (!authorityDictionary.ContainsKey(authoritySeed))
		    {
		        Ranorex.Report.Error("No authority for authority seed {"+authoritySeed+"}.");
		        return;
		    }

		    AuthorityObject authority = authorityDictionary[authoritySeed];
		    Tracklinerepo.TrainId = authority.authorityNumber + " " + validateText;
		    
		    if (!Tracklinerepo.Trackline_Form.AuthorityObjectInfo.Exists(0))
		    {
		        Ranorex.Report.Error("No authority with name {"+Tracklinerepo.TrainId+"} found on Trackline");
		        return;
		    }
		    
		    result = PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form.AuthorityObject, color, true);
		    if(result)
		    {

		        Ranorex.Report.Success("Track Authority number {"+Tracklinerepo.TrainId.ToString()+"} found "+color+" color on trackline");
		    }
		    else
		    {
		        Ranorex.Report.Failure("Track Authority number {"+Tracklinerepo.TrainId.ToString()+"} not found "+color+" color on trackline");
		    }
		}
		
		/// <summary>
		/// validate overlapping authority present on TrackLine.
		/// </summary>
		/// <param name="authoritySeed1">Input:authoritySeed1</param>
		/// <param name="authoritySeed2">Input:authoritySeed2</param>
		[UserCodeMethod]
		public static void ValidateOverlappingAuthorityOnTrackline(string authoritySeed1, string authoritySeed2)
		{
		    int retries = 0;
		    string []  authorityDeatails = new string[2];
		    if (!authorityDictionary.ContainsKey(authoritySeed1) && !authorityDictionary.ContainsKey(authoritySeed2))
		    {
		        Ranorex.Report.Error("No authorities for authorityseed1 {"+authoritySeed1+"} and authorityseed2{"+authoritySeed2+".");
		        return;
		    }
		    AuthorityObject authority1 = authorityDictionary[authoritySeed1];
		    AuthorityObject authority2 = authorityDictionary[authoritySeed2];
		    if (authority1.trackAuthorityType == "TE")
		    {
		        Tracklinerepo.TrainId = authority1.authorityNumber + " " + PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(authority1.trainSeed) + " ("+PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authority1.trainSeed, authority1.engineSeed).EngineInitial + " " + PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authority1.trainSeed, authority1.engineSeed).EngineNumber + ")";
		        authorityDeatails[0]  = GetAuthorityNumber(authoritySeed1) + " " +PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(authority1.trainSeed) + " ("+PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authority1.trainSeed, authority1.engineSeed).EngineInitial + " " + PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authority1.trainSeed, authority1.engineSeed).EngineNumber + ")";
		        authorityDeatails[1]  = GetAuthorityNumber(authoritySeed2)+ " " + authority2.rWOrOtWorker;
		    }
		    else
		    {
		        Tracklinerepo.TrainId = authority1.authorityNumber + " " + authority1.rWOrOtWorker;
		        authorityDeatails[0]  = GetAuthorityNumber(authoritySeed1)+ " " + authority1.rWOrOtWorker;
		        authorityDeatails[1]  = GetAuthorityNumber(authoritySeed2) + " " +PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(authority2.trainSeed) + " ("+PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authority2.trainSeed, authority2.engineSeed).EngineInitial + " " + PDS_CORE.Code_Utils.NS_TrainID.GetEngineObjectFromTrain(authority2.trainSeed, authority2.engineSeed).EngineNumber + ")";
		    }
		    
		    while(!Tracklinerepo.Trackline_Form.MenuAuthorityObjectInfo.Exists(0) && retries < 5)
		    {
		        Tracklinerepo.Trackline_Form.AuthorityObject.Click(WinForms.MouseButtons.Middle);
		        Delay.Milliseconds(500);
		        retries++;
		    }
		    
		    if(Tracklinerepo.Trackline_Form.MenuAuthorityObjectInfo.Exists(0))
		    {
		        int rows = Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.Self.Rows.Count;
		        for(int i=1; i<rows-1; i++)
		        {
		            Tracklinerepo.TrainId = authorityDeatails[i-1];
		            string actAuthorityNumber = Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.TrainIDLabel.GetAttributeValue<string>("Text");
		            if(authorityDeatails[i-1].Contains(actAuthorityNumber))
		            {
		                Ranorex.Report.Success("The Actual TrackAuthority Number:{"+actAuthorityNumber+"} and expected TrackAuthority Number : {"+authorityDeatails[i-1]+"} found on trackline");
		            }
		            else
		            {
		                Ranorex.Report.Failure("The Actual TrackAuthority Number:{"+actAuthorityNumber+"} and expected TrackAuthority Number : {"+authorityDeatails[i-1]+"} not found on trackline");
		            }
		        }
		    }
		    else
		    {
		        Ranorex.Report.Failure("No authorities found on trackline to identify the authority numbers");
		    }
		    if(Tracklinerepo.Trackline_Form.AuthorityObjectInfo.Exists(0) || Tracklinerepo.Trackline_Form.MenuAuthorityObjectInfo.Exists(0))
		    {
		        Tracklinerepo.TrainId = authorityDeatails[0];
		        Tracklinerepo.Trackline_Form.AuthorityObject.Click(WinForms.MouseButtons.Middle);
		    }
		    return;
		}
    }
}
