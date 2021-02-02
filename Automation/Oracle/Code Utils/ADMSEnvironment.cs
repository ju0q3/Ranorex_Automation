/*
 * Created by Ranorex
 * User: 503073759
 * Date: 1/7/2019
 * Time: 11:03 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Data;
using System.Data.Odbc;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;


using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using Env.Code_Utils;

namespace Oracle.Code_Utils
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class ADMSEnvironment
    {
        //private static Oracle.Code_Utils.DataLoader ADMSDataLoader;
        public static bool loadedADMSEnv = false;
        public static DataLoader ADMSDataLoader;
        public static void InitializeADMSEnvironment()
        {
            if (!loadedADMSEnv)
            {
                VMEnvironment vm = VMEnvironment.Instance();
                if(!string.IsNullOrEmpty(vm.dbUser))
                {
                    ADMSDataLoader = new Oracle.Code_Utils.DataLoader(new Oracle.Code_Utils.OracleConnectionContext(vm.dbUser, vm.dbPw, vm.user));
                }
                else
                {
                    ADMSDataLoader = new Oracle.Code_Utils.DataLoader(new Oracle.Code_Utils.OracleConnectionContext("ADMS", vm.dbPw, vm.user));
                }
                loadedADMSEnv = true;
            }
        }
        
        [UserCodeMethod]
        public static string GetEmployeeId_ADMS(string trainSymbol, string originDate, string firstInitial, string middleInitial, string lastName)
        {
            InitializeADMSEnvironment();
            string trainKey = GetTrainKey(trainSymbol, originDate);
            Report.Info("The train key = " + trainKey);

            string qry = string.Format(
                "SELECT EMPLOYEE_ID FROM ADMS.ABF_TEC_CREW WHERE TRAIN_KEY = {0} AND FIRST_NAME LIKE '{1}%' AND MIDDLE_INITIAL = '{2}' AND LAST_NAME = '{3}' ORDER BY BF_TIMESTAMP DESC",
                trainKey, firstInitial, middleInitial, lastName
               );

            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(qry);
            
            string result = null;
            if (output.Rows.Count == 0)
            {
                Ranorex.Report.Error(string.Format("There is no record for a crew member given by the following query: {0}", qry));
            } else {
                result = output.Rows[0][0].ToString();
                Report.Info(string.Format("This method returned employee Id '{0}'", result));
            }
            return result;
        }

        [UserCodeMethod]
        public static DataTable GetRowCount(string tableName)
        {
            InitializeADMSEnvironment();
            string qry = string.Format("SELECT COUNT(*) AS ROW_COUNT FROM (SELECT * FROM ADMS.{0})", tableName.ToUpper());

            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(qry);

			return output;
        }

        public static bool TableExists(string tableName)
        {
            InitializeADMSEnvironment();

            string qry = string.Format("SELECT * FROM ALL_TAB_COLUMNS WHERE OWNER = 'ADMS' AND TABLE_NAME = '{0}'", tableName.ToUpper());

            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(qry);

            bool tableExists = false;
            if (output.Rows.Count > 0)
            {
                tableExists = true;
            }

            return tableExists;
        }
        
        [UserCodeMethod]
        public static string QueryBulletinNumber_ADMS(string bulletinType, string optionalFromLocation, string optionalToLocation,
                                                      string optionalDistrict, string optionalBulletinState = "ACTIVE")
        {
            InitializeADMSEnvironment();
            string fullQuery;
            
            string selectSubQuery = "select BULLETIN_NUMBER from ADMS.ABF_RST_BULLETIN ";
            string filterSubQuery = "where BULLETIN_TYPE = '" + bulletinType + "'";
            string arrangeSubQuery = "order by BF_TIMESTAMP desc";
            
            if (!String.IsNullOrEmpty(optionalBulletinState))
            {
                filterSubQuery += " and BULLETIN_STATE = '" + optionalBulletinState + "' ";
            }
            
            if (!String.IsNullOrEmpty(optionalFromLocation))
            {
                filterSubQuery += " and FROM_LOCATION = '" + optionalFromLocation + "' ";
            }
            
            if (!String.IsNullOrEmpty(optionalToLocation))
            {
                filterSubQuery += " and TO_LOCATION = '" + optionalToLocation + "' ";
            }
            
            if (!String.IsNullOrEmpty(optionalDistrict))
            {
                filterSubQuery += " and DISTRICT = '" + optionalDistrict + "' ";
            }
            
            fullQuery = selectSubQuery + filterSubQuery + arrangeSubQuery;
            
            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(fullQuery);
            
            if (output.Rows.Count == 0)
            {
                Ranorex.Report.Failure("There is no bulletin for the input combination of from/to location and/or bulletin type/state");
                return null;
            } else {
                string result = output.Rows[0][0].ToString();
                return result;
            }
        }
        
        [UserCodeMethod]
        public static void ValidateARCodingInADMS(string trainSymbol, string arCode)
        {
            InitializeADMSEnvironment();
            string admsARCode = NS_GetARCode(trainSymbol);
            if (admsARCode.Equals(arCode))
            {
                Ranorex.Report.Success("Expected AR code {"+arCode+"} matches most recent AR ADMS code for train {"+trainSymbol+"}.");
            }
            else
            {
                Ranorex.Report.Failure("Expected AR code {"+arCode+"} does not match most recent AR ADMS code entry for train {"+trainSymbol+"}. Actual code = {"+admsARCode+"}.");
            }
        }
        
        [UserCodeMethod]
        public static string GetTrainClearanceNumber(string trainId)
        {
            InitializeADMSEnvironment();
            //Query pulls the last associated clearance number. If the train no longer has a train id, the last one will be populated. If the train never had a clearance, no results will be populated
        	string qry = "Select TRAIN_CLEARANCE_NUMBER from ADMS.ABF_RST_TRAIN_CLEARANCE_EVENT where EVENT_SUBTYPE = 'CURRENT' and SHORT_TRAINID = '"+trainId+"' and EVENT_TIMESTAMP = (Select max(EVENT_TIMESTAMP) from ADMS.ABF_RST_TRAIN_CLEARANCE_EVENT where EVENT_SUBTYPE = 'CURRENT' and SHORT_TRAINID = '"+trainId+"')";
        	DataTable trainClearances = new DataTable();
        	trainClearances = ADMSDataLoader.ReadOracleDataToTable(qry);
        	if (!(trainClearances.Rows.Count == 0)) {
        		return trainClearances.Rows[0][0].ToString();
        	}
        	int retry = 0;
        	while (trainClearances.Rows.Count == 0 && retry < 10) {
        		Delay.Seconds(1);
        		trainClearances = ADMSDataLoader.ReadOracleDataToTable(qry);
        		retry++;
        	}
        	if (!(trainClearances.Rows.Count == 0)) {
        		return trainClearances.Rows[0][0].ToString();
        	} else {
        		Ranorex.Report.Failure("Train Clearance Number not found for train with trainId "+trainId+" in ADMS Database");
        		return "";
        	}
        }

        [UserCodeMethod]
        public static void Validate_PTCMessageLogged_ADMS(string ptcMessageId)
        {
            InitializeADMSEnvironment();
            Ranorex.Report.Info("TestStep", string.Format("Validating that PTC message '{0}' has been logged in ADMS", ptcMessageId));

            string with_query = "WITH TIME_FILTER AS (SELECT (SYSTIMESTAMP AT TIME ZONE 'GMT' -NUMTODSINTERVAL(1, 'MINUTE')) AS FILTER FROM DUAL) ";
            string select_query = string.Format("SELECT MESSAGE_ID FROM ADMS.ABF_OTC_MESSAGE A, TIME_FILTER F WHERE A.BF_TIMESTAMP >= F.FILTER AND A.MESSAGE_ID = '{0}'", ptcMessageId);
            string full_query = with_query + select_query;
            
            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(full_query);
            
            int retries = 0;
            //Takes up to 10 seconds to begin backflow
            while (output.Rows.Count == 0 && retries < 12)
            {
                retries++;
                Ranorex.Delay.Seconds(2);
                output = ADMSDataLoader.ReadOracleDataToTable(full_query);
            }
            
            if (output.Rows.Count == 0)
            {
                Ranorex.Report.Failure(string.Format("Failed to find '{0}' message logged in ADMS over the past minute.", ptcMessageId));
            }
            else
            {
                Ranorex.Report.Success(string.Format("PTC Message '{0}' successfully logged in ADMS within the past minute.", ptcMessageId));
            }
        }
        
        [UserCodeMethod]
        public static void Validate_BulletinItemConfig_ADMS(string bulletinName, string operable, string ptcTransfer, string toTransfer)
        {
            InitializeADMSEnvironment();
            string qry = "Select BULLETIN_TYPE, PTC_TRANSFER, OPERABLE, TO_TRANSFER from ADMS.ABF_RST_BULLETIN_ITEM_CONFIG where BULLETIN_TYPE like '%"+bulletinName+"%' Order by BF_TIMESTAMP DESC FETCH NEXT 1 ROWS ONLY";
            DataTable BuliTypeConfig = new DataTable();
            BuliTypeConfig = ADMSDataLoader.ReadOracleDataToTable(qry);
            
            if (BuliTypeConfig.Rows.Count > 0)
            {
                if(!BuliTypeConfig.Rows[0][1].ToString().Equals(ptcTransfer) && ptcTransfer != "")
                {
                    Ranorex.Report.Info("PTC Transfer Value Present in ADMS table: "+BuliTypeConfig.Rows[0][1].ToString());
                    Ranorex.Report.Failure("PTC Transfer Field Does not match");
                    return;
                }
                
                if(!BuliTypeConfig.Rows[0][2].ToString().Equals(operable) && operable != "")
                {
                    Ranorex.Report.Info("Operable Value Present in ADMS table: "+BuliTypeConfig.Rows[0][2].ToString());
                    Ranorex.Report.Failure("Operable Field Does not match");
                    return;
                }
                
                if(!BuliTypeConfig.Rows[0][3].ToString().Equals(toTransfer) && toTransfer != "")
                {
                    Ranorex.Report.Info("To Transfer Value Present in ADMS table: "+BuliTypeConfig.Rows[0][3].ToString());
                    Ranorex.Report.Failure("To Transfer Field Does not match");
                    return;
                }
                
            }
            
            
            if (BuliTypeConfig.Rows.Count == 0)
            {
                Ranorex.Report.Failure("No Entry found in ABF_RST_BULLETIN_ITEM_CONFIG for bulletin like "+bulletinName);
                return;
            }
            
            Ranorex.Report.Success("Data Matched in ABF_RST_BULLETIN_ITEM_CONFIG table");
            return;
            
        }

        public static void ValidateEngine_ADMS(string scac, string trainSymbol, string trainSection, string engineInitial, string engineNumber, string reportingLocation, string reportingPassCount, string reportingSource, string engineStatus, string consistStatus, string enginePosition,
        	                       string engineLock, string groupNumber, string model, string compensatedHP, string ptsEquipped, string ptcEquipped, string lslEquipped, string csEquipped, string notes, string originLocation, string originPassCount, string destinationLocation,
        	                       string destinationPassCount, string eventSubtype)
        {
            InitializeADMSEnvironment();
            StringBuilder fullQuery = new StringBuilder("");
            fullQuery.Append("select TRAINID_SYMBOL from ADMS.ABF_TEC_ENGINE ");
            fullQuery.AppendFormat("where TRAINID_SYMBOL = '{0}' and ENGINE_NUMBER = {1}", trainSymbol, engineNumber);
            string arrangeSubQuery = "order by BF_TIMESTAMP desc";
            
            if (!String.IsNullOrEmpty(scac))
            {
            	fullQuery.AppendFormat(" and TRAINID_SCAC = '{0}' ", scac);
            }
            
            if (!String.IsNullOrEmpty(trainSection))
            {
            	fullQuery.AppendFormat(" and TRAINID_SECTION = '{0}' ", trainSection);
            }
            
            if (!String.IsNullOrEmpty(engineInitial))
            {
            	fullQuery.AppendFormat(" and ENGINE_INITIAL = '{0}' ", engineInitial);
            }
            
            if (!String.IsNullOrEmpty(reportingLocation))
            {
            	fullQuery.AppendFormat(" and REPORTING_LOCATION = '{0}' ", reportingLocation);
            }
            
            if (!String.IsNullOrEmpty(reportingPassCount))
            {
            	fullQuery.AppendFormat(" and REPORTING_PASSCOUNT = {0} ", reportingPassCount);
            }
            
            if (!String.IsNullOrEmpty(reportingSource))
            {
            	if (reportingSource == "C")
            		reportingSource = "OTC CREW LOGON";
            	fullQuery.AppendFormat(" and REPORTING_SOURCE = '{0}' ", reportingSource);
            }
            
            if (!String.IsNullOrEmpty(engineStatus))
            {
            	fullQuery.AppendFormat(" and ENGINE_STATUS = '{0}' ", engineStatus);
            }
            
            if (!String.IsNullOrEmpty(consistStatus))
            {
            	fullQuery.AppendFormat(" and CONSIST_STATUS = '{0}' ", consistStatus);
            }
            
            if (!String.IsNullOrEmpty(groupNumber))
            {
            	fullQuery.AppendFormat(" and ENGINE_GROUP = '{0}' ", groupNumber);
            }
            
            if (!String.IsNullOrEmpty(engineLock))
            {
            	engineLock = engineLock.ToUpper();
            	if (engineLock.Equals("Y"))
            	    engineLock = "1";
            	else
            		engineLock = "0";
            	fullQuery.AppendFormat(" and ENGINE_LOCK = {0} ", engineLock);
            }
            
            if (!String.IsNullOrEmpty(model))
            {
            	fullQuery.AppendFormat(" and ENGINE_MODEL = '{0}' ", model);
            }
            
            if (!String.IsNullOrEmpty(compensatedHP))
            {
            	fullQuery.AppendFormat(" and COMPENSATED_HP = {0} ", compensatedHP);
            }
            
            if (!String.IsNullOrEmpty(ptsEquipped))
            {
            	ptsEquipped = ptsEquipped.ToUpper();
            	if (ptsEquipped.Equals("Y"))
            	    ptsEquipped = "1";
            	else
            		ptsEquipped = "0";
            	fullQuery.AppendFormat(" and PTS_EQUIPPED = {0} ", ptsEquipped);
            }
            
            if (!String.IsNullOrEmpty(ptcEquipped))
            {
            	ptcEquipped = ptcEquipped.ToUpper();
            	if (ptcEquipped.Equals("Y"))
            	    ptcEquipped = "1";
            	else
            		ptcEquipped = "0";
            	fullQuery.AppendFormat(" and PTC_EQUIPPED = {0} ", ptcEquipped);
            }
            
            if (!String.IsNullOrEmpty(lslEquipped))
            {
            	lslEquipped = lslEquipped.ToUpper();
            	if (lslEquipped.Equals("Y"))
            	    lslEquipped = "1";
            	else
            		lslEquipped ="0";
            	fullQuery.AppendFormat(" and LSL_EQUIPPED = {0} ", lslEquipped);
            }
            
            if (!String.IsNullOrEmpty(csEquipped))
            {
            	csEquipped = csEquipped.ToUpper();
            	if (csEquipped.Equals("Y"))
            	    csEquipped = "1";
            	else
            		csEquipped ="0";
            	fullQuery.AppendFormat(" and CAB_SIGNAL_EQUIPPED = {0} ", csEquipped);
            }
            
            if (!String.IsNullOrEmpty(notes))
            {
            	fullQuery.AppendFormat(" and ENGINE_NOTE = '{0}' ", notes);
            }
            
            if (!String.IsNullOrEmpty(originLocation))
            {
            	fullQuery.AppendFormat(" and ORIGIN_STATION_OPSTA = '{0}' ", originLocation);
            }
            
            if (!String.IsNullOrEmpty(originPassCount))
            {
            	fullQuery.AppendFormat(" and ORIGIN_STATION_PASSCOUNT = {0} ", originPassCount);
            }
            
            //add, modify
            if (!String.IsNullOrEmpty(eventSubtype))
            {
            	fullQuery.AppendFormat(" and EVENT_SUBTYPE = '{0}' ", eventSubtype);
            }
            
            //fullQuery = selectSubQuery + filterSubQuery + arrangeSubQuery;
            
            Report.Info("Query being sent: " + fullQuery);
            
            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(fullQuery.Append(arrangeSubQuery).ToString());
            
            if (output.Rows.Count == 0)
            {
                Ranorex.Report.Failure("Engine with specified attributes was not found in ADMS.");
            } else {
            	Ranorex.Report.Success("Engine with specified attributes was found in ADMS.");
            }
        }
        
        /// <summary>
        /// Will validate the reporting source exists for a particular train int his table, BE CAREFUL, if you modify through the same method more than once you may get duplicate results
        /// </summary>
        /// <param name="trainSymbol"></param>
        /// <param name="source"></param>
        /// <param name="reportingSource"></param>
        /// <param name="eventSubtype"></param>
        public static void ValidateTCSMReportingSource (string trainSymbol, string source, string reportingSource, string eventSubtype, string timeFrameInSeconds)
        {
        	int seconds = 0;
        	Int32.TryParse(timeFrameInSeconds, out seconds);
        	InitializeADMSEnvironment();
            StringBuilder fullQuery = new StringBuilder("");
            //for debugging purposes ive added a bit more to the result than necessary
            fullQuery.Append("select TRAINID_SYMBOL, SUMMARY_TIMESTAMP, TCSM_REPORTING_SOURCE from ADMS.ABF_TRC_CONSIST_SUMMARY "); 
            fullQuery.AppendFormat("where TRAINID_SYMBOL = '{0}' and SOURCE = '{1}' and EVENT_SUBTYPE = '{2}' and TCSM_REPORTING_SOURCE = '{3}'", trainSymbol, source, eventSubtype.ToUpper(), reportingSource);
            
            Report.Info("Query being sent: " + fullQuery);
            
            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(fullQuery.ToString());
            int retries = 0;
            while (output.Rows.Count == 0 && retries < 3)
            {
            	Delay.Seconds(10);
            	retries++;
            	output = ADMSDataLoader.ReadOracleDataToTable(fullQuery.ToString());
            }
            System.DateTime now = System.DateTime.Now;
            now.AddSeconds(0-seconds);
            if (output.Rows.Count == 0)
            {
                Ranorex.Report.Failure("Did not find any results for "+fullQuery);
            } else {
            	string[] monthDayThenRest = output.Rows[0][1].ToString().Split('/');
            	//Check if month or day needs leading 0s
//            	if (monthDayThenRest[0].Length == 1)
//            		monthDayThenRest[0] = "0" + monthDayThenRest[0];
//            	if (monthDayThenRest[1].Length == 1)
//            		monthDayThenRest[1] = "0" +monthDayThenRest[1];
            	string resultTime = string.Join("/", monthDayThenRest);
            	string format = "M/d/yyyy h:mm:ss tt"; //TODO RUn this on a day that doesnt have the same day and month identifier
            	System.DateTime timeStamp = System.DateTime.ParseExact(resultTime, format, System.Globalization.CultureInfo.InvariantCulture);
            	timeStamp.AddHours(-5);
            	int compareTime = System.DateTime.Compare(now, timeStamp);
            	if (compareTime < 0)
            		Ranorex.Report.Success("Found entry in expected timeframe");
            	else
            		Ranorex.Report.Failure("Entry was not found within expected timeframe. Old entry? " + resultTime);
            }
        }
        
        public static void ValidateAuthorityBackflow(string authorityNumber,  string authorityState, string ruComment)
        {
            InitializeADMSEnvironment();
            string result = "";
            string qry = string.Format("Select count(*) from (Select max(BF_TIMESTAMP) from ADMS.ABF_FBA_M_AUTHORITY where " +
                                       "AUTHORITY_NUMBER = '{0}' and AUTHORITY_STATE = '{1}' and RU_COMMENTS = '{2}')",authorityNumber,authorityState,ruComment);
            DataTable AuthorityBackFlowTable = new DataTable();
            AuthorityBackFlowTable = ADMSDataLoader.ReadOracleDataToTable(qry);
            
            int retries = 0;
            while (AuthorityBackFlowTable.Rows.Count == 0 && retries < 2)
            {
                retries++;
                Ranorex.Delay.Seconds(2);
                AuthorityBackFlowTable = ADMSDataLoader.ReadOracleDataToTable(qry);
            }
            
            if (AuthorityBackFlowTable.Rows.Count != 0)
            {
                result = AuthorityBackFlowTable.Rows[0][0].ToString();
                Ranorex.Report.Info("RUM message back flow validation"+result);
                int resultRetry = 0;
                while (result == "0" && resultRetry < 2)
                {
                    resultRetry++;
                    Ranorex.Delay.Seconds(3);
                    AuthorityBackFlowTable = ADMSDataLoader.ReadOracleDataToTable(qry);
                }
                if (AuthorityBackFlowTable.Rows.Count != 0)
                {
                    result = AuthorityBackFlowTable.Rows[0][0].ToString();
                    if (result == "0")
                    {
                        Ranorex.Report.Failure("Failed to find message logged in ADMS");
                        return;
                    }
                    else
                    {
                        Ranorex.Report.Success("RUM Message successfully logged in ADMS");
                        return;
                    }
                }
                else
                {
                    Ranorex.Report.Failure("Failure to fetch from Authority backflow table");
                }
            }
            else
            {
                Ranorex.Report.Failure("Failure to fetch from Authority backflow table");
            }
        }

        
        /// <summary>
        /// Validates ETA record is available in database or not
        /// </summary>
        /// <param name="trainSeed">Input trainSeed</param>
        /// <param name="opstaLocation">Input opstaLocation</param>
        /// <param name="originDate">Input originDate</param>
        /// <param name="isPresent">Input If its true ETA record is present, if false ETA record is not present</param>
        [UserCodeMethod]
        public static void Validate_ETARecord_ADMS(string trainSymbol, string opstaLocation, string originDate, bool IsPresent)
        {
            InitializeADMSEnvironment();
            //string qry = "select * from ADMS.ABF_TOS_TRAIN_ETA where TRAINID_SYMBOL = '"+trainSeed+"' and LOCATION_STATION_OPSTA = '"+opstaLocation+"' Order by BF_TIMESTAMP DESC FETCH NEXT 1 ROWS ONLY";
            string qry= string.Format("select * from ADMS.ABF_TOS_TRAIN_MOVEMENT where TRAINID_SYMBOL='{0}' and LOCATION_STATION_OPSTA='{1}'" +
                                      "and TO_CHAR(TRAINID_DATE, 'MMDDYYYY') = '{2}'" +
                                      "Order by BF_TIMESTAMP DESC FETCH NEXT 1 ROWS ONLY", trainSymbol, opstaLocation, originDate);
            DataTable ETARecordConfig = new DataTable();
            ETARecordConfig = ADMSDataLoader.ReadOracleDataToTable(qry);
            
            int retries = 0;
            while (ETARecordConfig.Rows.Count == 0 && retries < 3)
            {
                retries++;
                Ranorex.Delay.Seconds(2);
                ETARecordConfig = ADMSDataLoader.ReadOracleDataToTable(qry);
            }
            if(IsPresent)
            {
                if (ETARecordConfig.Rows.Count > 0)
                {
                    Ranorex.Report.Success("Train Symbol [ "+trainSymbol+" ]  and opstaLocation  [ "+opstaLocation+" ] ETA data record exist in database" );
                }
                else
                {
                    Ranorex.Report.Failure("Train Symbol [ "+trainSymbol+" ]  and opstaLocation  [ "+opstaLocation+" ] ETA data record does not exist in database" );
                }
            }
            else
            {
                if (ETARecordConfig.Rows.Count == 0)
                {
                    Ranorex.Report.Success("Train Symbol [ "+trainSymbol+" ]  and opstaLocation  [ "+opstaLocation+" ] ETA data record does not exist in database" );
                }
                else
                {
                    Ranorex.Report.Failure("Train Symbol [ "+trainSymbol+" ]  and opstaLocation  [ "+opstaLocation+" ] ETA data record exist in database" );
                }
            }
        }

        public static DataTable ValidateConsistSummaryBackflow_ADMS(string trainKey, string eventType, string eventSubType)
        {
            InitializeADMSEnvironment();
            DataTable messageBackFlow = new DataTable();

            string query = string.Format(
                "WITH ALL_ROWS AS " +
                "(" +
                "SELECT TCSM_REPORTING_LOCATION, LOADS, EMPTIES, TRAILING_TONNAGE, LENGTH, AXLES, OPERATIVE_BRAKES, TOTAL_BRAKING_FORCE, TCSM_REPORTING_SOURCE, MAX_PLATE_SIZE, SPEED_CLASS " +
                "FROM ADMS.ABF_TRC_CONSIST_SUMMARY " +
                "WHERE TRAIN_KEY = '{0}' AND EVENT_TYPE = '{1}' AND EVENT_SUBTYPE = '{2}' ORDER BY BF_TIMESTAMP DESC" +
                ") " +
                "SELECT * FROM ALL_ROWS WHERE ROWNUM = 1",
                trainKey, eventType, eventSubType
               );

            int retries = 0;
            while (messageBackFlow.Rows.Count == 0 && retries < 3)
            {
                retries++;
                Ranorex.Delay.Seconds(2);
                messageBackFlow = ADMSDataLoader.ReadOracleDataToTable(query);
            }

            return messageBackFlow;
            
        }
        
        /// <summary>
        /// Validates MovementInformation record is available in database or not
        /// </summary>
        /// <param name="trainSeed">Input trainSeed</param>
        /// <param name="opstaLocation">Input opstaLocation</param>
        /// <param name="originDate">Input originDate</param>
        /// <param name="isPresent">Input If its true MovementInformation record is present, if false MovementInformation record is not present</param>
        public static DataTable validate_MovementInformation_ADMS(string trainSymbol,string opstaLocation, string originDate)
        {
            InitializeADMSEnvironment();
            string qry= string.Format("select * from ADMS.ABF_TOS_TRAIN_MOVEMENT where TRAINID_SYMBOL='{0}' and LOCATION_STATION_OPSTA='{1}'" +
                                      "and TO_CHAR(TRAINID_DATE, 'MMDDYYYY') = '{2}'" +
                                      "Order by BF_TIMESTAMP DESC FETCH NEXT 1 ROWS ONLY", trainSymbol, opstaLocation, originDate);
            
            DataTable MovementTypeConfig = new DataTable();
            MovementTypeConfig = ADMSDataLoader.ReadOracleDataToTable(qry);
            
            int retries = 0;
            while (MovementTypeConfig.Rows.Count == 0 && retries < 3)
            {
                retries++;
                Ranorex.Delay.Seconds(2);
                MovementTypeConfig = ADMSDataLoader.ReadOracleDataToTable(qry);
            }
            
            return MovementTypeConfig;
        }
        
        
        [UserCodeMethod]
        public static void Validate_TrainKeyLogged_ADMS(string DeviceID, string TransactionType, string trainKey)
        {
            InitializeADMSEnvironment();
            Report.Info("The train key = " + trainKey);
            string qry = string.Format(
                "SELECT COUNT(*)FROM ADMS.ABF_CTC_OPERATION WHERE TRANSACTION_TYPE = '{1}' AND DEVICE_ID = '{2}' AND EVENT_SUBTYPE LIKE '%{0}%'",
                trainKey, TransactionType, DeviceID
               );
            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(qry);
            int retries = 0;
            while (output.Rows.Count == 0 && retries <2)
            {
                retries++;
                Ranorex.Delay.Seconds(2);
                output = ADMSDataLoader.ReadOracleDataToTable(qry);
            }
            if (output.Rows.Count == 0)
            {
                Ranorex.Report.Failure("There is no record for a train key for given Device ID the following query: {0}", qry);
            }
            else
            {
                Ranorex.Report.Success("Train Key has been logged for device ID");
                return;
            }
        }

        [UserCodeMethod]
        public static void ValidateCTCOperationBackflow_ADMS(string transactionType, string eventSubtype, string cpStation, string deviceId, string withinMinutes)
        {
            InitializeADMSEnvironment();
            string qry = string.Format(
                "  WITH TIME_FILTER AS (" +
                "SELECT (SYSTIMESTAMP AT TIME ZONE 'GMT' -NUMTODSINTERVAL("+withinMinutes+", 'MINUTE')) AS FILTER FROM DUAL) " +
                "SELECT * " +
                "  FROM ADMS.ABF_CTC_OPERATION, TIME_FILTER T " +
                " WHERE TRANSACTION_TYPE = '{0}' " +
                "   AND EVENT_TYPE = 'CTC Operation' " +
                "   AND EVENT_SUBTYPE = '{1}' " +
                "   AND CP_STATION = '{2}' " +
                "   AND DEVICE_ID = {3} " +
                "   AND BF_TIMESTAMP > T.FILTER",
                transactionType, eventSubtype, cpStation, deviceId
               );

            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(qry);
            int retries = 0;
            while (output.Rows.Count == 0 && retries < 3)
            {
                retries++;
                Ranorex.Delay.Seconds(5);
                output = ADMSDataLoader.ReadOracleDataToTable(qry);
            }

            if (output.Rows.Count == 0)
            {
                Report.Failure("Validation", string.Format("No backflow entry found for CTC operation {0} at device Id {1}", transactionType, deviceId));
            } else {
                Report.Success("Validation", string.Format("Backflow entry successfully found for CTC operation {0} at device Id {1}", transactionType, deviceId));
            }
        }
        
        public static void Validate_OTCMessage_Backflow(string messageId, string authorityNumber, string district, string action, string dispatcherResponse, string withInMinutes="2")
        {
            InitializeADMSEnvironment();
            DataTable output = new DataTable();
            
            string qry = "";
            
            district = district.ToUpper();
            
            string with_query = "WITH TIME_FILTER AS (SELECT (SYSTIMESTAMP AT TIME ZONE 'GMT' -NUMTODSINTERVAL("+withInMinutes+", 'MINUTE')) AS FILTER FROM DUAL) ";
            string select_qry="";
            switch(messageId)
            {
                case "RD-RTIR":
                    select_qry = string.Format(
                        "SELECT MESSAGE_XML FROM ADMS.ABF_OTC_MESSAGE A, TIME_FILTER F WHERE DISTRICT = '{0}' AND SOURCE_SYSTEM = 'RU' AND MESSAGE_ID = 'RD-RTIR' AND BF_TIMESTAMP > F.FILTER ORDER BY BF_TIMESTAMP DESC FETCH NEXT 1 ROW ONLY", district);
                    qry = with_query+select_qry;
                    break;
                    
                case "DR-RTCD":
                    if(!string.IsNullOrEmpty(dispatcherResponse)){
                        select_qry = string.Format(
                            "SELECT MESSAGE_XML FROM ADMS.ABF_OTC_MESSAGE WHERE DISTRICT = '{0}' AND SOURCE_SYSTEM = 'CAD' AND MESSAGE_ID = 'DR-RTCD' AND MESSAGE_XML LIKE '%DISPATCHER_RESPONSE>{1}%' ORDER BY BF_TIMESTAMP DESC FETCH NEXT 1 ROW ONLY", district, dispatcherResponse);
                        qry=with_query+select_qry;
                    } else{
                        select_qry = string.Format(
                            "SELECT MESSAGE_XML FROM ADMS.ABF_OTC_MESSAGE WHERE DISTRICT = '{0}' AND SOURCE_SYSTEM = 'CAD' AND MESSAGE_ID = 'DR-RTCD' AND MESSAGE_XML LIKE '%DISPATCHER_RESPONSE>{1}%' ORDER BY BF_TIMESTAMP DESC FETCH NEXT 1 ROW ONLY", district, dispatcherResponse);
                        qry=with_query+select_qry;
                    }
                    break;
                    
                case "RD-RTVR":
                    qry = string.Format(
                        "SELECT MESSAGE_XML FROM ADMS.ABF_OTC_MESSAGE WHERE DISTRICT = '{0}' AND SOURCE_SYSTEM = 'RU' AND MESSAGE_ID = 'RD-RTVR' AND MESSAGE_XML LIKE '%TRACK_AUTHORITY_NUMBER>{1}%' ORDER BY BF_TIMESTAMP DESC FETCH NEXT 1 ROW ONLY", district, authorityNumber);
                    break;
                    
                case "DR-TAUT":
                    qry = string.Format(
                        "SELECT MESSAGE_XML FROM ADMS.ABF_OTC_MESSAGE WHERE DISTRICT = '{0}' AND SOURCE_SYSTEM = 'CAD' AND MESSAGE_ID = 'DR-TAUT' AND MESSAGE_XML LIKE '%TRACK_AUTHORITY_NUMBER>{1}%' ORDER BY BF_TIMESTAMP DESC FETCH NEXT 1 ROW ONLY", district, authorityNumber);
                    break;
                    
                case "RD-CATA":
                    qry = string.Format(
                        "SELECT MESSAGE_XML FROM ADMS.ABF_OTC_MESSAGE WHERE DISTRICT= '{0}' AND SOURCE_SYSTEM = 'RU' AND MESSAGE_ID = 'RD-CATA' AND MESSAGE_XML LIKE '%TRACK_AUTHORITY_NUMBER>{1}%' ORDER BY BF_TIMESTAMP DESC FETCH NEXT 1 ROW ONLY", district, authorityNumber);
                    break;
                    
                case "DG-TAUT":
                    qry = string.Format(
                        "SELECT MESSAGE_XML FROM ADMS.ABF_OTC_MESSAGE WHERE DISTRICT= '{0}' AND SOURCE_SYSTEM = 'CAD' AND MESSAGE_ID = 'DG-TAUT' AND MESSAGE_XML LIKE '%TRACK_AUTHORITY_NUMBER>{1}%' ORDER BY BF_TIMESTAMP DESC FETCH NEXT 1 ROW ONLY", district, authorityNumber);
                    break;
                    
                default:
                    Ranorex.Report.Error("Invalid Message Id"+messageId);
                    break;
                    
            }
            
            output = ADMSDataLoader.ReadOracleDataToTable(qry);
            
            int retries = 0;
            while (output.Rows.Count == 0 && retries < 5)
            {
                retries++;
                Ranorex.Delay.Seconds(2);
                output = ADMSDataLoader.ReadOracleDataToTable(qry);
            }
            
            if (output.Rows.Count == 1)
            {
                string result = output.Rows[0][0].ToString();
                
                if(messageId == "RD-RTIR" )
                {
                    Ranorex.Report.Success("Valid Entry present for Message Id: "+messageId);
                }
                else if(messageId == "DR-RTCD")
                {
                    
                    Ranorex.Report.Success("Valid Entry present for Message Id: "+messageId);
                }
                else
                {
                    if (result.Contains("TRACK_AUTHORITY_NUMBER>"+authorityNumber))
                    {
                        if(!string.IsNullOrEmpty(action) && result.Contains("<ACTION>"+action))
                        {
                            Ranorex.Report.Success("Valid Entry present for Message Id: "+messageId);
                        }
                        else
                        {
                            Ranorex.Report.Success("Valid Entry present for Message Id: "+messageId);
                        }
                        
                    }
                    else
                    {
                        Ranorex.Report.Failure("Valid Entry not present for Message Id: "+messageId + " in ----> "+output.Rows[0][0].ToString());
                    }
                }
            }
            else
            {
                Ranorex.Report.Info("Found "+output.Rows.Count.ToString() +" enteries for the search criteria");
                Ranorex.Report.Failure("Valid Entry not present for Message Id: "+messageId);
            }
        }
        public static DataTable NS_ABF_FBA_TAG_AUTHORITY_ADMS(string tagName, string tagType, string eventSubType, string withInMinutes)
        {
            InitializeADMSEnvironment();
            DataTable output = new DataTable();
            bool executeQuery = false;
            eventSubType = eventSubType.ToUpper();
            string finalQuery = "";
            string qry = "";
            string filter_qry =string.Format("WITH TIME_FILTER AS (SELECT (SYSTIMESTAMP AT TIME ZONE 'GMT' -NUMTODSINTERVAL("+withInMinutes+", 'MINUTE')) AS FILTER FROM DUAL)");
            switch(tagType.ToLower())
            {
                case("signal"):
                    qry = string.Format("SELECT TAG_ID,EVENT_SUBTYPE FROM ADMS.ABF_FBA_TAG_AUTHORITY A, TIME_FILTER F WHERE TAG_NAME = '{0}' AND TAG_TYPE='Signal' AND EVENT_SUBTYPE = '{1}' AND A.BF_TIMESTAMP>F.FILTER ORDER BY BF_TIMESTAMP DESC FETCH NEXT 1 ROW ONLY ",tagName,eventSubType);
                    finalQuery=filter_qry+qry;
                    executeQuery = true;
                    break;
                case("switch"):
                    qry = string.Format("SELECT TAG_ID,EVENT_SUBTYPE FROM ADMS.ABF_FBA_TAG_AUTHORITY A, TIME_FILTER F WHERE TAG_NAME = '{0}' AND TAG_TYPE='Switch' AND EVENT_SUBTYPE = '{1}' AND A.BF_TIMESTAMP>F.FILTER ORDER BY BF_TIMESTAMP DESC FETCH NEXT 1 ROW ONLY ",tagName,eventSubType);
                    finalQuery=filter_qry+qry;
                    executeQuery = true;
                    break;
                case("track"):
                    qry = string.Format("SELECT TAG_ID,EVENT_SUBTYPE FROM ADMS.ABF_FBA_TAG_AUTHORITY A, TIME_FILTER F WHERE TAG_NAME = '{0}' AND TAG_TYPE='Track' AND EVENT_SUBTYPE = '{1}' AND A.BF_TIMESTAMP>F.FILTER ORDER BY BF_TIMESTAMP DESC FETCH NEXT 1 ROW ONLY ",tagName,eventSubType);
                    finalQuery=filter_qry+qry;
                    executeQuery = true;
                    break;
                default:
                    Ranorex.Report.Failure("Invalid Tag Type: "+tagType);
                    break;
            }
            
            if(executeQuery)
            {
                output = ADMSDataLoader.ReadOracleDataToTable(finalQuery);
                int retries = 0;
                while (output.Rows.Count == 0 && retries < 3)
                {
                    retries++;
                    Ranorex.Delay.Seconds(5);
                    output = ADMSDataLoader.ReadOracleDataToTable(finalQuery);
                }
            }
            
            return output;
        }
        
        public static DataTable Validate_ABF_FBA_NOTIFICATION_ADMS(string dispatcherResponse,string authorityType,string notificationMessage,string withInMinutes)
        {
            InitializeADMSEnvironment();
            DataTable output = new DataTable();
            dispatcherResponse=dispatcherResponse.ToUpper();
            bool executeQuery = false;
            
            string finalQuery = "";
            string qry = "";
            string with_query =string.Format("SELECT * FROM ADMS.ABF_FBA_NOTIFICATION WHERE DISPATCHER_RESPONSE IN('{0}') AND NOTIFICATION_MESSAGE LIKE '%{1}%'  AND AUTHORITY_ID =  " , dispatcherResponse ,notificationMessage);
            switch(authorityType.ToUpper())
            {
                case("TE"):
                    qry = string.Format("(WITH TIME_FILTER AS (SELECT (SYSTIMESTAMP AT TIME ZONE 'GMT' -NUMTODSINTERVAL("+withInMinutes+", 'MINUTE')) AS FILTER FROM DUAL) SELECT AUTHORITY_ID FROM ADMS.ABF_FBA_M_AUTHORITY A ,TIME_FILTER F WHERE ADDRESSEE_TYPE = 'T/E' AND PROCEED1_SUB1_BEGIN_PT = 'None' AND PROCEED1_SUB1_END_PT = 'None' AND A.BF_TIMESTAMP>F.FILTER ORDER BY BF_TIMESTAMP DESC FETCH NEXT 1 ROW ONLY )");
                    finalQuery=with_query+qry;
                    executeQuery = true;
                    break;
                case("RW"):
                    qry = string.Format("(WITH TIME_FILTER AS (SELECT (SYSTIMESTAMP AT TIME ZONE 'GMT' -NUMTODSINTERVAL("+withInMinutes+", 'MINUTE')) AS FILTER FROM DUAL) SELECT AUTHORITY_ID FROM ADMS.ABF_FBA_M_AUTHORITY A,TIME_FILTER F WHERE ADDRESSEE_TYPE = 'R/W' AND WORK_SUB1_BEGIN_PT = 'None' AND WORK_SUB1_END_PT = 'None' AND A.BF_TIMESTAMP>F.FILTER ORDER BY BF_TIMESTAMP DESC FETCH NEXT 1 ROW ONLY)");
                    finalQuery=with_query+qry;
                    executeQuery = true;
                    break;
                case("OT"):
                    qry = string.Format("(WITH TIME_FILTER AS (SELECT (SYSTIMESTAMP AT TIME ZONE 'GMT' -NUMTODSINTERVAL("+withInMinutes+", 'MINUTE')) AS FILTER FROM DUAL) SELECT AUTHORITY_ID FROM ADMS.ABF_FBA_M_AUTHORITY A,TIME_FILTER F WHERE ADDRESSEE_TYPE = 'O/T' AND WORK_SUB1_BEGIN_PT = 'None' AND WORK_SUB1_END_PT = 'None' AND A.BF_TIMESTAMP>F.FILTER ORDER BY BF_TIMESTAMP DESC FETCH NEXT 1 ROW ONLY)");
                    finalQuery=with_query+qry;
                    executeQuery = true;
                    break;
                default:
                    Ranorex.Report.Failure("Invalid Authority Type: "+authorityType);
                    break;
            }
            
            if(executeQuery)
            {
                output = ADMSDataLoader.ReadOracleDataToTable(finalQuery);
                int retries = 0;
                while (output.Rows.Count == 0 && retries < 3)
                {
                    retries++;
                    Ranorex.Delay.Seconds(5);
                    output = ADMSDataLoader.ReadOracleDataToTable(finalQuery);
                }
                if (output.Rows.Count == 0)
                {
                    Ranorex.Report.Failure("Data is not available :",finalQuery);
                }
            }
            else
            {
                Ranorex.Report.Failure("Passed Authortiy Type : "+authorityType+ " is not a valid Authority Type");
            }
            
            return output;
        }
        
        public static DataTable NS_ABF_FBA_M_AUTHORITY_ADMS(string authorityNumber, string authorityState, string authorityType,string eventSubType)
        {
            InitializeADMSEnvironment();
            DataTable output = new DataTable();
            string qry = "";
            string finalQry="";
            string eventSubTypeFilter="";
            string authorityTypeValue="";
            authorityState = authorityState.ToUpper();
            //	authorityTypeValue=authorityType.Insert(1,"/");
            if (!authorityType.Contains("/"))
            {
                authorityTypeValue=authorityType.Insert(1,"/");
            }
            else
            {
                authorityTypeValue=authorityType;
            }
            
            switch(authorityTypeValue.ToUpper())
            {
                case("T/E"):
                case("O/T"):
                case("R/W"):
                    qry = string.Format("SELECT EVENT_SUBTYPE,AUTHORITY_STATE FROM ADMS.ABF_FBA_M_AUTHORITY WHERE ADDRESSEE_TYPE = '{0}' AND AUTHORITY_NUMBER = '{1}' AND AUTHORITY_STATE = '{2}' ", authorityTypeValue, authorityNumber, authorityState);
                    break;
                default:
                    Ranorex.Report.Failure("Invalid Authority Type: "+authorityType);
                    break;
            }
            if(eventSubType!="")
            {
                eventSubTypeFilter ="AND EVENT_SUBTYPE='"+eventSubType+"' ORDER BY BF_TIMESTAMP FETCH NEXT 1 ROW ONLY";
            }
            else
            {
                eventSubTypeFilter="ORDER BY BF_TIMESTAMP FETCH NEXT 1 ROW ONLY";
                
            }
            finalQry=qry+eventSubTypeFilter;
            output = ADMSDataLoader.ReadOracleDataToTable(finalQry);
            int retries = 0;
            while (output.Rows.Count == 0 && retries < 3)
            {
                retries++;
                Ranorex.Delay.Seconds(5);
                output = ADMSDataLoader.ReadOracleDataToTable(finalQry);
            }
            return output;
        }
        
        public static string GetAuthorityId_ADMS(string authorityNumber)
        {
            InitializeADMSEnvironment();
            string qry = string.Format("SELECT AUTHORITY_ID FROM ADMS.ABF_FBA_M_AUTHORITY WHERE AUTHORITY_NUMBER = '{0}'  ORDER BY BF_TIMESTAMP DESC FETCH NEXT 1 ROWS ONLY", authorityNumber);
            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(qry);
            int retries = 0;
            while (output.Rows.Count == 0 && retries < 3)
            {
                Ranorex.Delay.Seconds(5);
                output = ADMSDataLoader.ReadOracleDataToTable(qry);
                retries++;
            }
            if (output.Rows.Count == 0)
            {
                Ranorex.Report.Info(string.Format("There is no record for authority id given by the following query: {0}", qry));
                return null;
            }
            return output.Rows[0][0].ToString();
        }
        
        public static void ValidateCrewTimeZone_ADMS(string trainKey, string originDate, string firstName, string middleName, string lastName)
        {
            InitializeADMSEnvironment();
            string qry = string.Format("select ON_DUTY_TIMEZONE, HOS_TIMEZONE, ON_TRAIN_TIMEZONE, OFF_DUTY_TIMEZONE, OFF_TRAIN_TIMEZONE  from ADMS.ABF_TEC_CREW where TRAIN_KEY= {0} and TO_CHAR(TRAINID_DATE, 'MMDDYYYY')='{1}' and EVENT_SUBTYPE = 'Add' and FIRST_NAME = '{2}' and MIDDLE_INITIAL = '{3}' and LAST_NAME = '{4}' Order by BF_TIMESTAMP DESC FETCH NEXT 1 ROWS ONLY", trainKey, originDate, firstName, middleName, lastName);
            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(qry);
            
            if (output.Rows.Count == 0)
            {
                Ranorex.Report.Failure(string.Format("There is no record for  crew time zone given by the following query: {0}", qry));
            }
            else
            {
                string result_onDuty = output.Rows[0][0].ToString();
                Ranorex.Report.Info("On Duty:"+result_onDuty);
                string result_hos = output.Rows[0][1].ToString();
                Ranorex.Report.Info("Hos :"+result_hos);
                string result_onTrain = output.Rows[0][2].ToString();
                Ranorex.Report.Info("On Train Duty:"+result_onTrain);
                string result_offDuty = output.Rows[0][3].ToString();
                Ranorex.Report.Info("Off Duty:"+result_offDuty);
                string result_offTrain = output.Rows[0][4].ToString();
                Ranorex.Report.Info("Off Train Duty:"+result_offTrain);
                
                if((result_onDuty == "EDT" || result_onDuty == "CDT" || result_onDuty == "CST" || result_onDuty == "EST") && (result_hos == "EDT" || result_hos == "CDT" || result_hos == "EST" || result_hos == "CST") &&
                   (result_onTrain == "EDT" || result_onTrain == "CDT" || result_onTrain == "EST" || result_onTrain == "CST") && (result_offDuty == "EDT" || result_offDuty == "CDT" || result_offDuty == "EST" || result_offDuty == "CST") &&
                   (result_offTrain == "EDT" || result_offTrain == "CDT" || result_offTrain == "EST" || result_offTrain == "CST") )
                    
                {
                    Ranorex.Report.Success("Time zone records logged in ADMS as Expected for On Duty: '"+result_onDuty+"'  HOS Expiration: '"+result_hos+"' " +
                                           "On Train: '"+result_onTrain+"' Off Duty: '"+result_offDuty+"' Off Train: '"+result_offTrain+"' ");
                }
                else
                {
                    Ranorex.Report.Failure("Expected entry not found in curent result.");
                }
                
                
            }
        }
        /// <summary>
        /// validating time zone for delay in ADMS.ABF_TDL_TRAIN_DELAY
        /// <param name="trainSeed">Input trainKey</param>
        /// <param name="trainSeed">Input originDate</param>
        /// <summary>
        public static void ValidateTimeZone_Delay_ADMS(string trainKey, string originDate, string delayCode, string fromOpsta, string toOpsta, string fromTimeZone, string toTimeZone)
        {
            InitializeADMSEnvironment();
            string qry = string.Format("select * FROM ADMS.ABF_TDL_TRAIN_DELAY where TRAIN_KEY = {0} and TO_CHAR(TRAINID_DATE, 'MMDDYYYY')='{1}' and DELAY_FROM_TIMEZONE = '{2}' and DELAY_TO_TIMEZONE = '{3}' and DELAY_CODE = '{4}' and DELAY_FROM_STATION = '{5}' and DELAY_TO_STATION = '{6}' Order by BF_TIMESTAMP DESC FETCH NEXT 1 ROWS ONLY", trainKey, originDate, fromTimeZone, toTimeZone, delayCode, fromOpsta, toOpsta);
            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(qry);
            
            int retries = 0;
            while (output.Rows.Count == 0 && retries < 2)
            {
                retries++;
                Ranorex.Delay.Seconds(2);
                output = ADMSDataLoader.ReadOracleDataToTable(qry);
            }
            if (output.Rows.Count == 0)
            {
                Ranorex.Report.Failure(string.Format("There is no record for  delay time zone given by the following query: {0}", qry));
            } else {
                
                Ranorex.Report.Success("Delay time zone for DELAY_FROM_TIMEZONE: '"+fromTimeZone+"'  DELAY_TO_TIMEZONE: '"+toTimeZone+"' " );
            }
        }
        
        
        public static DataTable GetAssignedWorkBackflow_ADMS(string trainKey)
        {
            // TODO: Make the query more versatile by including optional parameters for crew member type?
            InitializeADMSEnvironment();
            string qry = string.Format("select * from ADMS.ABF_TRC_ASSIGNED_WORK where TRAIN_KEY = {0} Order by BF_TIMESTAMP DESC FETCH NEXT 1 ROWS ONLY", trainKey);
            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(qry);
            return output;
        }
        
        /// <summary>
        /// validate error log entires in ADMS ABF_ELOG table
        /// <summary>
        [UserCodeMethod]
        public static void validateErrorLogEntries_ADMS()
        {
            InitializeADMSEnvironment();
            string qry = "select * from ADMS.ABF_ELOG";
            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(qry);
            if(output.Rows.Count == 0)
            {
                Ranorex.Report.Success("No entries found in ABF_ELOG table");
            }
            else
            {
                Ranorex.Report.Failure("Error Log entries found in ABG_ELOG table. Please refer ABF_ELOG table for error log entries before cleaning PDS");
            }
        }
        
        
        public static string GetTrainClearanceDetails_ADMS(string trainClearanceNumber)
        {
            InitializeADMSEnvironment();
            //select SUBSTR(TRAIN_CLEARANCE_DETAILS,INSTR(TRAIN_CLEARANCE_DETAILS,'Issued'),27) from abf_rst_train_clearance where TRAIN_CLEARANCE_NUMBER={0}
            string qry = string.Format("SELECT TRAIN_CLEARANCE_DETAILS FROM abf_rst_train_clearance WHERE TRAIN_CLEARANCE_NUMBER={0}", trainClearanceNumber);
            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(qry);
            return output.Rows[0][0].ToString();
        }
        //SELECT EFFECTIVE_DATE_TIME,EXPIRATION_DATE_TIME FROM ABF_RST_BULLETIN WHERE  BULLETIN_TYPE='Speed - Area Restriction' AND BULLETIN_NUMBER=1 AND BULLETIN_STATE='PENDING_ACTIVE';
        public static DataTable GetBulletinDatetime_ADMS(string bulletinNumber,string bulletinType,string bulletinState)
        {
            InitializeADMSEnvironment();
            //select SUBSTR(TRAIN_CLEARANCE_DETAILS,INSTR(TRAIN_CLEARANCE_DETAILS,'Issued'),27) from abf_rst_train_clearance where TRAIN_CLEARANCE_NUMBER={0}
            string qry = string.Format("SELECT EFFECTIVE_DATE_TIME,EXPIRATION_DATE_TIME FROM ABF_RST_BULLETIN WHERE BULLETIN_NUMBER='{0}' AND BULLETIN_TYPE='{1}' AND BULLETIN_STATE='{2}'", bulletinNumber,bulletinType,bulletinState);
            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(qry);
            return output;
        }
        public static DataTable Validate_EMT_ABF_FBA_NOTIFICATION(string dispatcherResponse,string notificationMessage)
        {
            InitializeADMSEnvironment();
            DataTable output = new DataTable();
            dispatcherResponse=dispatcherResponse.ToUpper();
            
            string qry = string.Format("SELECT * FROM ADMS.ABF_FBA_NOTIFICATION WHERE DISPATCHER_RESPONSE= '{0}' AND NOTIFICATION_MESSAGE LIKE '%{1}%' Order by BF_TIMESTAMP DESC FETCH NEXT 1 ROWS ONLY" , dispatcherResponse ,notificationMessage);
            output = ADMSDataLoader.ReadOracleDataToTable(qry);
            int retries = 0;
            while (output.Rows.Count == 0 && retries < 3)
            {
                retries++;
                Ranorex.Delay.Seconds(5);
                output = ADMSDataLoader.ReadOracleDataToTable(qry);
            }
            if (output.Rows.Count == 0)
            {
                Ranorex.Report.Failure("Data is not available :",qry);
            }
            
            return output;
        }
        
        public static string GetBulletinLatestNumber_ADMS()
        {
            InitializeADMSEnvironment();
            string selectSubQuery = "select MAX(BULLETIN_NUMBER) from ADMS.ABF_RST_BULLETIN  order by BF_TIMESTAMP desc";
            Report.Info(selectSubQuery.ToString());
            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(selectSubQuery);
            
            if (output.Rows.Count == 0)
            {
                
                return "0";
            }
            else
            {
                string result = output.Rows[0][0].ToString();
                return result;
            }
        }
        
        public static string GetBulletinId_ADMS(string bulletinNumber)
        {
            InitializeADMSEnvironment();
        	string qry = string.Format("SELECT BULLETIN_ID FROM ADMS.ABF_RST_BULLETIN WHERE BULLETIN_NUMBER = '{0}'  ORDER BY BF_TIMESTAMP DESC FETCH NEXT 1 ROWS ONLY", bulletinNumber);
        	DataTable output = new DataTable();
        	output = ADMSDataLoader.ReadOracleDataToTable(qry);
        	int retries = 0;
        	while (output.Rows.Count == 0 && retries < 5)
        	{
        		Ranorex.Delay.Seconds(5);
        		output = ADMSDataLoader.ReadOracleDataToTable(qry);
        		retries++;
        	}
        	if (output.Rows.Count == 0)
        	{
        		Ranorex.Report.Info(string.Format("There is no record for bulletin id given by the following query: {0}", qry));
        		return null;
        	}
        	return output.Rows[0][0].ToString();
        }
        
        public static string GetIssuedTwoMilepostBulletinDetails_ADMS(string bulletinType, string milePost1, string milePost2, string bulletinState)
        {
            InitializeADMSEnvironment();
            string qry = string.Format("SELECT unique bulletin_number FROM ADMS.ABF_RST_BULLETIN WHERE bulletin_type = '"+bulletinType+"' AND from_location like '"+milePost1+"%' AND to_location like '"+milePost2+"%' AND bulletin_state = '"+bulletinState+"' Order by BF_TIMESTAMP DESC FETCH NEXT 1 ROWS ONLY");
            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(qry);
            return output.Rows[0][0].ToString();
        }
        
        public static int GetMaxCrewEmployeeId()
        {
            InitializeADMSEnvironment();
        	string withQuery = "with NUMERIC_CREW as (select distinct to_number(EMPLOYEE_ID) EMPLOYEE_NUMBER from ADMS.ABF_TEC_CREW) ";
        	string selectQuery = "select max(EMPLOYEE_NUMBER) from NUMERIC_CREW";
        	
        	string qry = withQuery + selectQuery;
        	int defaultNumber = 0;
        	int outputNumber;
        	
        	DataTable crewId = new DataTable();
        	crewId = ADMSDataLoader.ReadOracleDataToTable(qry);
        	if (!(crewId.Rows.Count == 0))
        	{
        		string result = crewId.Rows[0][0].ToString();
        		
        		// Account for corner case where the result is null, as employee_id is a nullable field.
        		bool isNumeric = Int32.TryParse(result, out outputNumber);
        		if (isNumeric)
        		{
        			return outputNumber;
        		} else {
        			return defaultNumber;
        		}
        	} else {
        		return defaultNumber;
        	}
        }
        
        public static string IncrementEmployeeId()
        {
        	int maxEmployee = GetMaxCrewEmployeeId();
        	return (maxEmployee + 1).ToString();
        }
        
        public static string GetLastAuthorityFromAddressee(string addressee, string authorityType) 
        {
            InitializeADMSEnvironment();
        	string qry = "Select AUTHORITY_NUMBER from ADMS.ABF_FBA_M_AUTHORITY where ADDRESSEE01 = '" + addressee + "' and ADDRESSEE_TYPE = '" + authorityType + "' and AUTHORITY_STATE = 'ACTIVE' ORDER BY BF_TIMESTAMP DESC";
        	DataTable lastAuthority = ADMSDataLoader.ReadOracleDataToTable(qry);
        	return lastAuthority.Rows[0][0].ToString();
        }
        
		/// <summary>
		/// Returns TrainKey for a train symbol, originDate, section, and SCAC
		/// </summary>
		/// <param name="trainSymbol"></param>
		/// <param name="originDate"></param>
		/// <param name="section"></param>
		/// <param name="scac"></param>
		/// <returns></returns>
        public static string GetTrainKey(string trainSymbol, string originDate, string section = "", string scac = "NS")
        {
            InitializeADMSEnvironment();
        	// ADMS stores "blank" section IDs as a single, white space character
			string inputSection = " ";
			if (!string.IsNullOrEmpty(section))
			{
				inputSection = section;
			}
			
			//Query pulls the Train Key from a combination of trainSymbol and trainSection
        	string qry = "WITH FILTERED_RESULTS AS (SELECT DISTINCT LAST_VALUE(TRAIN_KEY) OVER (PARTITION BY SCAC, SYMBOL, SECTION, ORIGIN_DATE ORDER BY BF_TIMESTAMP) " +
        		"AS TRAIN_KEY, SYMBOL, TO_CHAR(ORIGIN_DATE, 'MMDDYYYY') AS CHARACTER_DATE, SECTION, SCAC FROM ADMS.ABF_MPS_TRAIN_ID) " +
        		"SELECT TRAIN_KEY FROM FILTERED_RESULTS WHERE SYMBOL = '"+ trainSymbol +"' AND CHARACTER_DATE = '"+ originDate +"'" +
				" and SECTION = '"+ inputSection +"' and SCAC = '"+ scac +"'";
        	
        	DataTable trainKey = new DataTable();
        	trainKey = ADMSDataLoader.ReadOracleDataToTable(qry);
        	if (trainKey.Rows.Count == 1) 
        	{
				return trainKey.Rows[0][0].ToString();
        	}
        	int retry = 0;
        	while (trainKey.Rows.Count == 0 && retry < 10) 
        	{
        		Delay.Seconds(1);
        		trainKey = ADMSDataLoader.ReadOracleDataToTable(qry);
        		retry++;
        	}
        	if (trainKey.Rows.Count == 1) 
        	{
        		Report.Info(string.Format("The train key returns in the format: '{0}'", trainKey.Rows[0][0].ToString()));
        		return trainKey.Rows[0][0].ToString();
        	} else 
        	{
        		Ranorex.Report.Failure("Train Key not found for train with train symbol "+trainSymbol+" in ADMS Database");
        		return "";
        	}
        }
        
        public static string GetDRAPopUpDisplayedLogAction(string trainKey, string fromOpsta, string toOpsta)
        {
            InitializeADMSEnvironment();
        	//Retrieve the ACTION column for the train key and popup type DRA POPUP
        	string qry = "Select ACTION from ADMS.ABF_TKG_DRA_POPUP_LOG where TRAIN_KEY = "+trainKey+" and FROM_OPSTA = '"+fromOpsta+"' and TO_OPSTA = '"+toOpsta+"' and COMMENTS is null";
        	DataTable DRAPopupLogTable = new DataTable();
        	DRAPopupLogTable = ADMSDataLoader.ReadOracleDataToTable(qry);
        	
        	if (DRAPopupLogTable.Rows.Count == 1) 
        	{
        		return DRAPopupLogTable.Rows[0][0].ToString();
        	}
        	int retry = 0;
        	while (DRAPopupLogTable.Rows.Count == 0 && retry < 10) 
        	{
        		Delay.Seconds(1);
        		DRAPopupLogTable = ADMSDataLoader.ReadOracleDataToTable(qry);
        		retry++;
        	}
        	if (DRAPopupLogTable.Rows.Count == 1) 
        	{
        		return DRAPopupLogTable.Rows[0][0].ToString();
        	} else 
        	{
        		Ranorex.Report.Warn("DRA Popup entry not found for train with train key "+trainKey+" in ADMS Database");
        		return "";
        	}
        }
        
        
        public static string GetDRAPopUpAcknowledgedLogAction(string trainKey, string fromOpsta, string toOpsta)
        {
            InitializeADMSEnvironment();
        	//Retrieve the Action column from ABF_TKG_DRA_POPUP_LOG and it should not be 'POP_UP_DISPLAYED_TO_USER'
        	string qry = "Select ACTION from ADMS.ABF_TKG_DRA_POPUP_LOG where TRAIN_KEY = "+trainKey+" and FROM_OPSTA = '"+fromOpsta+"' and TO_OPSTA = '"+toOpsta+"'  and ACTION != 'POP_UP_DISPLAYED_TO_USER'";
        	DataTable DRAPopupLogTable = new DataTable();
        	DRAPopupLogTable = ADMSDataLoader.ReadOracleDataToTable(qry);
        	
        	if (DRAPopupLogTable.Rows.Count == 1) 
        	{
        		Report.Info("DRA Acknowledge Popup Action: " +DRAPopupLogTable.Rows[0][0].ToString());
        		return DRAPopupLogTable.Rows[0][0].ToString();
        	}
        	
        	int retry = 0;
        	while (DRAPopupLogTable.Rows.Count == 0 && retry < 10) 
        	{
        		Delay.Seconds(1);
        		DRAPopupLogTable = ADMSDataLoader.ReadOracleDataToTable(qry);
        		retry++;
        	}
        	
        	if (DRAPopupLogTable.Rows.Count == 1) 
        	{
        		Report.Info("DRA Acknowledge Popup Action: " +DRAPopupLogTable.Rows[0][0].ToString());
        		return DRAPopupLogTable.Rows[0][0].ToString();
        	} else 
        	{
        		Ranorex.Report.Failure("DRA Popup entry not found for train with train key "+trainKey+" in ADMS Database");
        		return "";
        	}
        }
        
        /// <summary>
        /// Retrieves the most recent AR Code for a given train smybol
        /// </summary>
        /// <param name="trainSymbol">Train whose AR coding is desired</param>
        /// <returns></returns>
        public static string NS_GetARCode(string trainSymbol)
        {
            InitializeADMSEnvironment();
        	string qry = "SELECT reason_code FROM ADMS.abf_tri_train_planning_state WHERE trainid_symbol = '"+trainSymbol+"' ORDER BY bf_timestamp";
    		DataTable ARCodeTable = new DataTable();
    		ARCodeTable = ADMSDataLoader.ReadOracleDataToTable(qry);
    		if (ARCodeTable.Rows.Count > 0) //At least one returnable entry
    		{
    			return ARCodeTable.Rows[0][0].ToString();
    		}
    		else
    		{
    			Ranorex.Report.Failure("No entries found in ADMS.abf_tri_train_planning_state for train {"+trainSymbol+"}.");
    			return "";
    		}
        }
        
    	public static string GetDRAHistoryTableEnteredTime(string trainKey, string fromOpsta, string toOpsta)
    	{
    	    InitializeADMSEnvironment();
    		//Retrieve the Entered time for a TIH train and send it, else throw failure and return ""
    		string qry = "Select ENTERED from ADMS.ABF_TKG_DRA_HISTORY where TRAIN_KEY = '"+trainKey+"' and FROM_OPSTA= '"+fromOpsta+"' and TO_OPSTA= '"+toOpsta+"'";
    		DataTable DRAHistoryTable = new DataTable();
    		DRAHistoryTable = ADMSDataLoader.ReadOracleDataToTable(qry);
    		if (DRAHistoryTable.Rows.Count == 1) 
    		{
    			return DRAHistoryTable.Rows[0][0].ToString();
    		}
    		
    		int retry = 0;
        	while (DRAHistoryTable.Rows.Count == 0 && retry < 10) 
        	{
        		Delay.Seconds(1);
        		DRAHistoryTable = ADMSDataLoader.ReadOracleDataToTable(qry);
        		retry++;
        	}
        	if (DRAHistoryTable.Rows.Count == 1) 
        	{
        		return DRAHistoryTable.Rows[0][0].ToString();
        	} else if (DRAHistoryTable.Rows.Count == 0)
        	{
        		return "";
        	} else 
        	{
        		Ranorex.Report.Failure("Multiple DRA Entries found in History table");
        		return "";
        	}
    		
    	}
    	
    	/// <summary>
        /// Retrieves the most recent AR Code for a given train smybol
        /// </summary>
        /// <param name="messageId">Message Id you want to check within timeFrame</param>
        /// <param name="trainClearanceNumber">Train Clearance Number of associated ptc train for the PTC message</param>
        /// <param name="engineId">Engine Id of the PTC Train</param>
        /// <param name="startTimeMinutesFromNow">Start of the timeframe in reference to now to start looking for the PTC Messages</param>
        /// <param name="endTimeMinutesFromNow">End of the timeframe in reference to now to stop looking for the PTC Messages</param>
        /// <returns>DataTable of results</returns>
        [UserCodeMethod]
    	public static DataTable GetNumberOfPTCMessagesWithinTimeframeForEngine(string messageId, string trainClearanceNumber, string engineId, string startTimeMinutesFromNow, string endTimeMinutesFromNow)
    	{
    	    InitializeADMSEnvironment();
    	    System.DateTime currentTime = System.DateTime.UtcNow;
    	    TimeZoneInfo gmtZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
    	    System.DateTime currentGMTTime = TimeZoneInfo.ConvertTimeFromUtc(currentTime, gmtZone);
    	    string startTimeFormatted = currentGMTTime.AddMinutes(int.Parse(startTimeMinutesFromNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    string endTimeFormatted = currentGMTTime.AddMinutes(int.Parse(endTimeMinutesFromNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID, otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%" + messageId + "%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND    otc.BF_TIMESTAMP <= '" + endTimeFormatted + "' AND   otc.MESSAGE_XML LIKE '%" + trainClearanceNumber + "%" + engineId + "%'";
    		DataTable PTCMessageTable = new DataTable();
    		PTCMessageTable = ADMSDataLoader.ReadOracleDataToTable(qry);
    		return PTCMessageTable;
    	}
    	
    	/// <summary>
        /// Runs an ADMS Query
        /// </summary>
        [UserCodeMethod]
    	public static DataTable RunQuery(string qry)
    	{
    	    InitializeADMSEnvironment();
    	    
    		DataTable returnedDataTable = new DataTable();
    		returnedDataTable = ADMSDataLoader.ReadOracleDataToTable(qry);
    		return returnedDataTable;
    	}
    	
    	/// <summary>
        /// Checks if Train Schedule was created in ADMS
        /// </summary>
        /// <param name="scac">Scac of train, i.e. NS</param>
        /// <param name="trainId">TrainId including section if appropriate, i.e. R11111 17-1</param>
        /// <returns>DataTable of results</returns>
//        [UserCodeMethod]
//    	public static DataTable GetTrainScheduleTableForTrain(string scac, string trainId, string creationDay)
//    	{
//    	    InitializeADMSEnvironment();
//    	    //First get the MPS_TRAIN_SCHEDULE_ID to use to get the stations the trainSchedule has
//    	    string qry = "SELECT abf.MPS_TRAIN_SCHEDULE_ID FROM ADMS.ABF_MPS_TRAIN_SCHEDULE abf WHERE abf.SCAC = '" + scac + "' AND abf.SHORT_TRAINID = '" + trainId + "' AND ORDER BY abf.BF_TIMESTAMP DESC";
//    		DataTable trainScheduleIdsTable = new DataTable();
//    		trainScheduleIdsTable = ADMSDataLoader.ReadOracleDataToTable(qry);
//    		return trainScheduleIdsTable;
//    	}

		/// <summary>
		/// Get Previous Train Clearance Number 
		/// </summary>
		/// <param name="trainId"></param>
		/// <returns></returns>
		[UserCodeMethod]
		public static string GetPreviousTrainClearanceNumber(string trainId)
		{
			InitializeADMSEnvironment();
			//Query pulls the last associated clearance number. If the train no longer has a train id, the last one will be populated. If the train never had a clearance, no results will be populated
			string qry = "Select TRAIN_CLEARANCE_NUMBER from ADMS.ABF_RST_TRAIN_CLEARANCE_EVENT where EVENT_SUBTYPE = 'NONCURRENT' and SHORT_TRAINID = '"+trainId+"' and EVENT_TIMESTAMP = (Select max(EVENT_TIMESTAMP) from ADMS.ABF_RST_TRAIN_CLEARANCE_EVENT where EVENT_SUBTYPE = 'NONCURRENT' and SHORT_TRAINID = '"+trainId+"')";
			DataTable trainClearances = new DataTable();
			trainClearances = ADMSDataLoader.ReadOracleDataToTable(qry);
			if (!(trainClearances.Rows.Count == 0)) {
				return trainClearances.Rows[0][0].ToString();
			}
			int retry = 0;
			while (trainClearances.Rows.Count == 0 && retry < 10) {
				Delay.Seconds(1);
				trainClearances = ADMSDataLoader.ReadOracleDataToTable(qry);
				retry++;
			}
			if (!(trainClearances.Rows.Count == 0)) {
				return trainClearances.Rows[0][0].ToString();
			} else {
				Ranorex.Report.Failure("Train Clearance Number not found for train with trainId "+trainId+" in ADMS Database");
				return "";
			}
		}
		
		[UserCodeMethod]
		public static string GetEffectiveTimeOfBulletin(string bulletinNumber)
		{
			InitializeADMSEnvironment();
            string qry = string.Format("SELECT EFFECTIVE_DATE_TIME FROM ABF_RST_BULLETIN WHERE BULLETIN_NUMBER = '"+bulletinNumber+"' Order by BF_TIMESTAMP DESC FETCH NEXT 1 ROWS ONLY");
            DataTable output = new DataTable();
            output = ADMSDataLoader.ReadOracleDataToTable(qry);
            return output.Rows[0][0].ToString();
		}
    }
}
