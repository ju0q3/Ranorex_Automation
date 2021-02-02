/*
 * Created by Ranorex
 * User: 503073759
 * Date: 5/20/2019
 * Time: 6:32 AM
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
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using PDS_CORE.Code_Utils;
using Oracle.Code_Utils;

namespace PDS_NS.UserCodeCollections.NS_Oracle
{
    /// <summary>
    /// This class handles NS customer-specific components of Oracle queries. 
    /// Examples include queries that are dependent on NS_TrainObject classes, or where NS_TrainObject validations are necessary from query output. 
    /// This may be better served as a namespace (folder + several files) as opposed to a single class for longer-term buildout planning purposes. 
    /// </summary>
    [UserCodeCollection]
    public class NS_OracleValidation
    {
    	[UserCodeMethod]
    	public static void NS_ValidateTags_Backflow(string tagName, string tagType, string eventSubType, string withInMinutes)
    	{
    		eventSubType = eventSubType.ToUpper();
    		DataTable tagBackflow = ADMSEnvironment.NS_ABF_FBA_TAG_AUTHORITY_ADMS(tagName,tagType,eventSubType,withInMinutes);
    		NS_OracleTable tbl = new NS_OracleTable(tagBackflow);
    		
    		if (tbl.GetRowCount() > 0)
    		{
    			Ranorex.Report.Info(string.Format("Notification found for Tag Id: '{0}'", tbl.GetCellValue("TAG_ID")));
    			Ranorex.Report.Success("Valid Entry for Event SubType: "+eventSubType+" and Tag Name: "+tagName);
    		}
    		else
    		{
    			Ranorex.Report.Failure("No Valid Entry for Event SubType: "+eventSubType+" and Tag Name: "+tagName);
    		}
    	}
        [UserCodeMethod]
        public static void NS_ValidateAthorityNotification_Backflow(string dispatcherResponse, string authorityType, string notificationMessage,string withInMinutes)
        {
            dispatcherResponse = dispatcherResponse.ToUpper();
            DataTable messageBackFlow = ADMSEnvironment.Validate_ABF_FBA_NOTIFICATION_ADMS(dispatcherResponse, authorityType, notificationMessage,withInMinutes);

            NS_OracleTable tbl = new NS_OracleTable(messageBackFlow);

            if (tbl.GetRowCount() > 0)
        	{
        		Ranorex.Report.Info(string.Format("Notification found for Authority Id: '{0}'", tbl.GetCellValue("AUTHORITY_ID"))); // -DK
        		Ranorex.Report.Success("Valid Entry for Dispather Response: "+dispatcherResponse+"and Notification Message: "+notificationMessage);
        	}
        	else
        	{
        		Ranorex.Report.Failure("No Entry found for Dispather Response: "+dispatcherResponse+"and Notification Message: "+notificationMessage);
        	}
        }
        
        /// <summary>
		/// Validates MovementInformation record is available in database or not
		/// </summary>
		/// <param name="trainSeed">Input trainSeed</param>
		/// <param name="opstaLocation">Input opstaLocation</param>
		/// <param name="optAverageSpeed">Optional Input Average Speed</param>
		/// <param name="optTrainLength">Optional Input Train Length</param>
		/// <param name="isPresent">Input If its true MovementInformation record is present, if false MovementInformation record is not present</param>
		[UserCodeMethod]
		public static void NS_validate_MovementInformation_BackFlow(string trainSeed,string opstaLocation, string optAverageSpeed, string optTrainLength, bool IsPresent)
		{
			string trainSymbol= NS_TrainID.GetTrainSymbol(trainSeed);
			string originDate = PDS_CORE.Code_Utils.NS_TrainID.getOriginDate(trainSeed);
			if(trainSymbol!= null)
			{
				DataTable movementInfoBackflow = Oracle.Code_Utils.ADMSEnvironment.validate_MovementInformation_ADMS(trainSymbol, opstaLocation, originDate);
				NS_OracleTable tbl = new NS_OracleTable(movementInfoBackflow);
				
				if(IsPresent)
				{
					
					if (movementInfoBackflow.Rows.Count > 0)
					{
						if(!string.IsNullOrEmpty(optAverageSpeed))
						{
							tbl.ValidateCell(optAverageSpeed, "AVERAGE_SPEED");
						}
						
						if(!string.IsNullOrEmpty(optTrainLength))
						{
							tbl.ValidateCell(optTrainLength, "TRAIN_LENGTH");
						}
						
						Ranorex.Report.Success("Train Symbol [ "+trainSymbol+" ]  and opstaLocation  [ "+opstaLocation+" ] Matched in ABF_TOS_TRAIN_MOVEMENT table with the column" );
					}
					else
					{
						Ranorex.Report.Failure("Train Symbol [ "+trainSymbol+" ]  and opstaLocation  [ "+opstaLocation+" ] did not Matched in ABF_TOS_TRAIN_MOVEMENT table with the column" );
					}
					
				}
				else
				{
					if(movementInfoBackflow.Rows.Count == 0)
					{
						
						Ranorex.Report.Success("Train Symbol [ "+trainSymbol+" ]  and opstaLocation  [ "+opstaLocation+" ] Matched in ABF_TOS_TRAIN_MOVEMENT table with the column" );
					}
					
					else
					{
						Ranorex.Report.Failure("Train Symbol [ "+trainSymbol+" ]  and opstaLocation  [ "+opstaLocation+" ] did not Matched in ABF_TOS_TRAIN_MOVEMENT table with the column");
					}
				}
			}
			else
			{
				Ranorex.Report.Error("Train Symbol is not Valid");
			}

		}
        [UserCodeMethod]
        public static void NS_Validate_ABF_FBA_M_AUTHORITY_ADMS(string authoritySeed, string authorityState, string eventSubType)
        {
        	eventSubType = eventSubType.ToUpper();
        	string authorityNumber = NS_Authorities.GetAuthorityNumber(authoritySeed);
        	string authorityType = "";
        	AuthorityObject authorityObj = NS_Authorities.GetAuthorityObject(authoritySeed);
        	authorityType = authorityObj.trackAuthorityType.ToString();
        	DataTable authorityFlow=ADMSEnvironment.NS_ABF_FBA_M_AUTHORITY_ADMS(authorityNumber, authorityState, authorityType, eventSubType);
        	NS_OracleTable tbl = new NS_OracleTable(authorityFlow);
        	if(tbl.GetRowCount() > 0)
        	{
        		Ranorex.Report.Success("Valid Entry Authority State:"+authorityState+" Found for Authority Number:"+authorityNumber+"and Event Subtype:"+eventSubType);
       
        	}
        	else
        	{
        		Ranorex.Report.Failure("No Entry found for Authority State:"+authorityState+ " as part of Authority Number: "+authorityNumber+"and Event Subtype:"+eventSubType);
        	}
        
    }

        [UserCodeMethod]
        public static void NS_ValidateBIVoiceAckByDistrict_PTCConfiguration(string districtName, bool isBIVoiceAckEnabled)
        {
            DataTable ptcConfig = CDMSEnvironment.GetPTCConfigurationByDistrict_CDMS(districtName);
            NS_OracleTable tbl = new NS_OracleTable(ptcConfig);

            if (tbl.GetRowCount() == 0)
            {
                Report.Failure(string.Format("The district name '{0}' does not exist in CDMS.COMMUNICATION_CFG_VW", districtName));
                return;
            }

            // If checked, then the value should be 0 for the district, if unchecked then 1
            string expectedValue = isBIVoiceAckEnabled ? "0" : "1";
            tbl.ValidateCell(expectedValue, "BI_VOICE_ACK_REQ");

        }

		[UserCodeMethod]
		public static void NS_ValidateOracleTableHasRecords(string schemaName, string tableName, bool validateHasRecords)
		{
			if (!schemaName.ToUpper().Equals("ADMS") && !schemaName.ToUpper().Equals("CDMS"))
			{
				Report.Error(string.Format("The schema '{0}' is an invalid entry. Please choose between ADMS or CDMS, and try again.", schemaName.ToUpper()));
				return;
			}

			DataTable rowCount = new DataTable();

			if (schemaName.ToUpper().Equals("ADMS"))
			{
				if (ADMSEnvironment.TableExists(tableName))
				{
					rowCount = ADMSEnvironment.GetRowCount(tableName);
				} else {
					Report.Error(string.Format("The table '{0}' does not exist in ADMS. Please try again.", tableName.ToUpper()));
					return;
				}
			}

			if (schemaName.ToUpper().Equals("CDMS"))
			{
				if (CDMSEnvironment.TableExists(tableName))
				{
					rowCount = CDMSEnvironment.GetRowCount(tableName);
				} else {
					Report.Error(string.Format("The table '{0}' does not exist in CDMS. Please try again.", tableName.ToUpper()));
					return;
				}
			}

			NS_OracleTable tbl = new NS_OracleTable(rowCount);

			string count = tbl.GetCellValue("ROW_COUNT");
			bool hasRecords = Int32.Parse(count) > 0;
			
			string feedbackMessage = string.Format(
				"Row count for {0}.{1} is '{2}'. The table contains records: '{3}'; the table was expected to contain records: '{4}'",
				schemaName.ToUpper(), tableName.ToUpper(), count, hasRecords, validateHasRecords
			);

			if (hasRecords == validateHasRecords)
			{
				Report.Success(feedbackMessage);
			} else {
				Report.Failure(feedbackMessage);
			}
		}
        
        [UserCodeMethod]
        public static void NS_ValidateTrainConsistSummary_Backflow(string trainSeed, string consistSeed, string eventType, string eventSubType)
        {
            bool includeSource = true;
            if (eventSubType.Equals("NEW_ENGINE") | eventSubType.Equals("TRAIN_CONSIST_SUMMARY"))
            {
                includeSource = false;
            }
            
            bool includeConsist = true;
            if (eventSubType.Equals("ACTIVITY_STATE_CHANGE"))
            {
            	includeConsist = false;
            }
               
        	string trainKey = NS_TrainMiscellaneous.GetTrainKeyFromADMS(trainSeed);
            if (trainKey == null)
            {
                Ranorex.Report.Error(string.Format("Train key could not be found for train seed: '{0}'", trainSeed));
                return;
            }
			
			DataTable messageBackFlow = ADMSEnvironment.ValidateConsistSummaryBackflow_ADMS(trainKey, eventType, eventSubType);

            NS_OracleTable tbl = new NS_OracleTable(messageBackFlow);

            if (includeConsist)
            {
                NS_ConsistObject trainConsist = NS_TrainID.GetConsistObjectFromTrain(trainSeed, consistSeed);
            	
            	tbl.ValidateCell(trainConsist.NumberLoads, "LOADS");
                tbl.ValidateCell(trainConsist.NumberEmpties, "EMPTIES");
                tbl.ValidateCell(trainConsist.TrailingTonnage, "TRAILING_TONNAGE");
                tbl.ValidateCell(trainConsist.TrainLength, "LENGTH");
                tbl.ValidateCell(trainConsist.AxleCount, "AXLES");
                tbl.ValidateCell(trainConsist.OperativeBrakes, "OPERATIVE_BRAKES");
                tbl.ValidateCell(trainConsist.TotalBrakingForce, "TOTAL_BRAKING_FORCE");
                tbl.ValidateCell(trainConsist.SpeedClass, "SPEED_CLASS");
                tbl.ValidateCell(trainConsist.MaxPlateSize, "MAX_PLATE_SIZE");
                if (includeSource)
                {
                	tbl.ValidateCell(trainConsist.ReportingLocation, "TCSM_REPORTING_LOCATION");
                	tbl.ValidateCell(trainConsist.ReportingSource, "TCSM_REPORTING_SOURCE");
                } 
            } 
            else
            {
                tbl.ValidateCell("0", "LOADS");
                tbl.ValidateCell("0", "EMPTIES");
                tbl.ValidateCell("0", "TRAILING_TONNAGE");
                tbl.ValidateCell("0", "LENGTH");
                tbl.ValidateCell("-1", "AXLES");
                tbl.ValidateCell("-1", "OPERATIVE_BRAKES");
                tbl.ValidateCell("-1", "TOTAL_BRAKING_FORCE");
            }
        }
        
        [UserCodeMethod]
        public static void NS_ValidateEMTNotification_Backflow(string dispatcherResponse, string notificationMessage)
        {
            dispatcherResponse = dispatcherResponse.ToUpper();
            DataTable messageBackFlow = ADMSEnvironment.Validate_EMT_ABF_FBA_NOTIFICATION(dispatcherResponse, notificationMessage);

            NS_OracleTable tbl = new NS_OracleTable(messageBackFlow);

            if (tbl.GetRowCount() > 0)
        	{
        		//Ranorex.Report.Info(string.Format("Notification found for Authority Id: '{0}'", tbl.GetCellValue("AUTHORITY_ID"))); // -DK
        		Ranorex.Report.Success("Valid Entry for Dispather Response: "+dispatcherResponse+" and Notification Message: "+notificationMessage);
        	}
        	else
        	{
        		Ranorex.Report.Failure("No Entry found for Dispather Response: "+dispatcherResponse+" and Notification Message: "+notificationMessage);
        	}
        }
        
        [UserCodeMethod]
        public static void NS_ValidateTwoMilepostBulletinDetailsInADMS(string bulletinSeed, string bulletinState)
        {
        	string bulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
        	string bulletinType = NS_Bulletin.GetBulletinType(bulletinSeed);
        	string milePost1 = NS_Bulletin.GetBulletinMilepost1(bulletinSeed);
        	string milePost2 = NS_Bulletin.GetBulletinMilepost2(bulletinSeed);
        	
        	string bulletinNumberFromDB = ADMSEnvironment.GetIssuedTwoMilepostBulletinDetails_ADMS(bulletinType, milePost1, milePost2, bulletinState);
        	
        	Ranorex.Report.Info("UI: {"+bulletinNumber+"} DB: {"+bulletinNumberFromDB+"}");
        	if(bulletinNumber.Equals(bulletinNumberFromDB))
        	{
        		Ranorex.Report.Success("Bulletin details are present in the database as expected"); 
        	}
        	else
        	{
        		Ranorex.Report.Failure("Bulletin details are Not present in the database as expected");
        	}
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="trainSeed">trainSeed for engine and train clearance information</param>
		/// <param name="engineSeed">Engine Seed for PTC engine information</param>
		/// <param name="messageId">message type to validate i.e. DC-TCON</param>
		/// <param name="startTimeMinutesFromNow">Minutes from now for the ADMS validation window</param>
		/// <param name="endTimeMinutesFromNow">Minutes from now for the end of the ADMS validation window</param>
		/// <param name="numberOfMessagesExpected">How many messages are expected</param>
        [UserCodeMethod]
        public static void NS_ValidateNumberOfPTCMessagesWithinTimeframeForEngine_ADMS(string trainSeed, string engineSeed, string messageId, string startTimeMinutesFromNow, string endTimeMinutesFromNow, int numberOfMessagesExpected)
        {
            string trainClearanceNumber = NS_TrainID.GetTrainClearanceNumber(trainSeed);
            string engineId = NS_TrainID.GetEngineInitial(trainSeed, engineSeed) + " " + NS_TrainID.GetEngineNumber(trainSeed, engineSeed);
            DataTable resultsTable = ADMSEnvironment.GetNumberOfPTCMessagesWithinTimeframeForEngine(messageId, trainClearanceNumber, engineId, startTimeMinutesFromNow, endTimeMinutesFromNow);
            int numberOfRows = resultsTable.Rows.Count;
            if (numberOfRows == numberOfMessagesExpected)
            {
                Ranorex.Report.Success("Expected and received {" + numberOfMessagesExpected.ToString() + "} number of {" + messageId + "} messages within timeframe");
            } else {
                Ranorex.Report.Failure("Expected {" + numberOfMessagesExpected.ToString() + "} and received {" + numberOfRows.ToString() + "} number of {" + messageId + "} messages within timeframe");
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="trainClearanceNumberTrainSeed">trainseed storing the train clearance, or the train clearance number itself</param>
		/// <param name="engineNumberTrainSeed">trainseed storing the ptc engine</param>
		/// <param name="engineNumberEngineSeed">engineseed storing the ptc engine or the ptc engine id itself</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateCD_RTID_ABF_OTC_MESSAGE_ADMS(string trainClearanceNumberTrainSeed, string engineNumberTrainSeed, string engineNumberEngineSeed, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            string trainClearanceNumber = PDS_CORE.Code_Utils.NS_TrainID.GetTrainClearanceNumber(trainClearanceNumberTrainSeed);
            if (trainClearanceNumber == null)
            {
                trainClearanceNumber = trainClearanceNumberTrainSeed;
            }
            
            string engineId = "";
            string engineInitial = PDS_CORE.Code_Utils.NS_TrainID.GetEngineInitial(engineNumberTrainSeed, engineNumberEngineSeed);
            if (engineInitial == null)
            {
                engineId = engineNumberEngineSeed;
            } else {
                engineId = engineInitial + "%" + PDS_CORE.Code_Utils.NS_TrainID.GetEngineNumber(engineNumberTrainSeed, engineNumberEngineSeed);
            }
            
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%CD-RTID%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + trainClearanceNumber + "%" + engineId + "%'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for CD-RTID within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for CD-RTID within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for CD-RTID within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for CD-RTID within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for CD-RTID within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for CD-RTID within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="messageBeingAcknowledged">message ID being acknowledged by the DC-AK01</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateDC_AK01_ABF_OTC_MESSAGE_ADMS(string messageBeingAcknowledged, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%DC-AK01%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + messageBeingAcknowledged + "%'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for DC-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for DC-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for DC-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for DC-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for DC-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for DC-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="trainClearanceNumberTrainSeed">trainseed storing the train clearance, or the train clearance number itself</param>
		/// <param name="engineNumberTrainSeed">trainseed storing the ptc engine</param>
		/// <param name="engineNumberEngineSeed">engineseed storing the ptc engine or the ptc engine id itself</param>
		/// <param name="originDateTrainSeed">trainseed storing the origin date of the ptc train</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateDC_TLST_ABF_OTC_MESSAGE_ADMS(string trainClearanceNumberTrainSeed, string engineNumberTrainSeed, string engineNumberEngineSeed, string originDateTrainSeed, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            string trainClearanceNumber = PDS_CORE.Code_Utils.NS_TrainID.GetTrainClearanceNumber(trainClearanceNumberTrainSeed);
            if (trainClearanceNumber == null)
            {
                trainClearanceNumber = trainClearanceNumberTrainSeed;
            }
            
            string engineId = "";
            string engineInitial = PDS_CORE.Code_Utils.NS_TrainID.GetEngineInitial(engineNumberTrainSeed, engineNumberEngineSeed);
            if (engineInitial == null)
            {
                engineId = engineNumberEngineSeed;
            } else {
                engineId = engineInitial + "%" + PDS_CORE.Code_Utils.NS_TrainID.GetEngineNumber(engineNumberTrainSeed, engineNumberEngineSeed);
            }
            
            string originDate = PDS_CORE.Code_Utils.NS_TrainID.getOriginDate(originDateTrainSeed);
            if (originDate == null)
            {
                originDate = originDateTrainSeed;
            }
            
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%DC-TLST%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + trainClearanceNumber + "%" + engineId + "%" + originDate + "%'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for DC-TLST within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for DC-TLST within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for DC-TLST within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for DC-TLST within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for DC-TLST within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for DC-TLST within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="messageBeingAcknowledged">message ID being acknowledged by the DC-AK01</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateCD_AK01_ABF_OTC_MESSAGE_ADMS(string messageBeingAcknowledged, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%CD-AK01%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + messageBeingAcknowledged + "%'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for CD-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for CD-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for CD-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for CD-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for CD-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for CD-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="trainSymbolTrainSeed">trainseed storing the train symbol</param>
		/// <param name="engineNumberTrainSeed">trainseed storing the ptc engine</param>
		/// <param name="engineNumberEngineSeed">engineseed storing the ptc engine or the ptc engine id itself</param>
		/// <param name="crewSeed">crewSeed storing the crew information</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateCD_CSGN_ABF_OTC_MESSAGE_ADMS(string trainSymbolTrainSeed, string engineNumberTrainSeed, string engineNumberEngineSeed, string employeeIdCrewSeed, string crewFirstInitialCrewSeed, string crewLastNameCrewSeed, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSymbolTrainSeed);
            if (trainSymbol == null)
            {
                trainSymbol = trainSymbolTrainSeed;
            }
            
            string engineId = "";
            string engineInitial = PDS_CORE.Code_Utils.NS_TrainID.GetEngineInitial(engineNumberTrainSeed, engineNumberEngineSeed);
            if (engineInitial == null)
            {
                engineId = engineNumberEngineSeed;
            } else {
                engineId = engineInitial + "%" + PDS_CORE.Code_Utils.NS_TrainID.GetEngineNumber(engineNumberTrainSeed, engineNumberEngineSeed);
            }
            
            string employeeId = PDS_CORE.Code_Utils.NS_CrewClass.GetCrewMemberEmployeeId(employeeIdCrewSeed);
            if (employeeId == null)
            {
                employeeId = employeeIdCrewSeed;
            }
            
            string crewFirstInitial = PDS_CORE.Code_Utils.NS_CrewClass.GetCrewMemberFirstInitial(crewFirstInitialCrewSeed);
            if (crewFirstInitial == null)
            {
                crewFirstInitial = crewFirstInitialCrewSeed;
            }
            
            string crewLastName = PDS_CORE.Code_Utils.NS_CrewClass.GetCrewMemberLastName(crewLastNameCrewSeed);
            if (crewLastName == null)
            {
                crewLastName = crewLastNameCrewSeed;
            }
            
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%CD-CSGN%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + trainSymbol + "%" + engineId + "%" + employeeId + "%" + crewFirstInitial + "%" + crewLastName + "%'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for CD-CSGN within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for CD-CSGN within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for CD-CSGN within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for CD-CSGN within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for CD-CSGN within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for CD-CSGN within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="trainSymbolTrainSeed">trainseed storing the train symbol</param>
		/// <param name="engineNumberTrainSeed">trainseed storing the ptc engine</param>
		/// <param name="engineNumberEngineSeed">engineseed storing the ptc engine or the ptc engine id itself</param>
		/// <param name="crewSeed">crewSeed storing the crew information</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateCD_RABI_ABF_OTC_MESSAGE_ADMS(string trainSymbolTrainSeed, string trainClearanceNumberTrainSeed, string engineNumberTrainSeed, string engineNumberEngineSeed, string requestType, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSymbolTrainSeed);
            if (trainSymbol == null)
            {
                trainSymbol = trainSymbolTrainSeed;
            }
            
            string trainClearanceNumber = PDS_CORE.Code_Utils.NS_TrainID.GetTrainClearanceNumber(trainClearanceNumberTrainSeed);
            if (trainClearanceNumber == null)
            {
                trainClearanceNumber = trainClearanceNumberTrainSeed;
            }
            
            string engineId = "";
            string engineInitial = PDS_CORE.Code_Utils.NS_TrainID.GetEngineInitial(engineNumberTrainSeed, engineNumberEngineSeed);
            if (engineInitial == null)
            {
                engineId = engineNumberEngineSeed;
            } else {
                engineId = engineInitial + "%" + PDS_CORE.Code_Utils.NS_TrainID.GetEngineNumber(engineNumberTrainSeed, engineNumberEngineSeed);
            }
            
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%CD-RABI%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + trainSymbol + "%" + trainClearanceNumber + "%" + engineId + "%" + requestType.ToUpper() + "%'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for CD-RABI within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for CD-RABI within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for CD-RABI within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for CD-RABI within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for CD-RABI within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for CD-RABI within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="trainSymbolTrainSeed">trainseed storing the train symbol</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateDC_DIBS_ABF_OTC_MESSAGE_ADMS(string trainSymbolTrainSeed, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSymbolTrainSeed);
            if (trainSymbol == null)
            {
                trainSymbol = trainSymbolTrainSeed;
            }
            
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%DC-DIBS%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + trainSymbol + "%'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for DC-DIBS within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for DC-DIBS within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for DC-DIBS within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for DC-DIBS within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for DC-DIBS within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for DC-DIBS within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="trainSymbolTrainSeed">trainseed storing the train symbol</param>
		/// <param name="originDateTrainSeed">trainseed storing the origin date of the ptc train</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateCD_RCON_ABF_OTC_MESSAGE_ADMS(string trainSymbolTrainSeed, string originDateTrainSeed, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSymbolTrainSeed);
            if (trainSymbol == null)
            {
                trainSymbol = trainSymbolTrainSeed;
            }
            
            string originDate = PDS_CORE.Code_Utils.NS_TrainID.getOriginDate(originDateTrainSeed);
            if (originDate == null)
            {
                originDate = originDateTrainSeed;
            }
            
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%CD-RCON%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + trainSymbol + "%" + originDate + "%'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for CD-RCON within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for CD-RCON within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for CD-RCON within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for CD-RCON within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for CD-RCON within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for CD-RCON within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="trainSymbolTrainSeed">trainseed storing the Train Symbol</param>
		/// <param name="originDateTrainSeed">trainseed storing the origin date of the ptc train</param>
		/// <param name="engineNumberTrainSeed">trainseed storing the ptc engine</param>
		/// <param name="engineNumberEngineSeed">engineseed storing the ptc engine or the ptc engine id itself</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateCD_TCON_ABF_OTC_MESSAGE_ADMS(string trainSymbolTrainSeed, string engineNumberTrainSeed, string engineNumberEngineSeed, string engineCount, string speedClass, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            string trainId = "";
            string trainScac = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSCAC(trainSymbolTrainSeed);
            if (trainScac == null)
            {
                trainId = trainSymbolTrainSeed;
            } else {
                trainId = trainScac + "%" + PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSymbolTrainSeed);
            }
            
            string engineId = "";
            string engineInitial = PDS_CORE.Code_Utils.NS_TrainID.GetEngineInitial(engineNumberTrainSeed, engineNumberEngineSeed);
            if (engineInitial == null)
            {
                engineId = engineNumberEngineSeed;
            } else {
                engineId = engineInitial + "%" + PDS_CORE.Code_Utils.NS_TrainID.GetEngineNumber(engineNumberTrainSeed, engineNumberEngineSeed);
            }
            
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%CD-TCON%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + trainId + "%" + (engineCount != "" ? "ENGINE_COUNT%" + engineCount + "%ENGINE_COUNT%":"") + (speedClass != "" ? "SPEED_CLASS%" + speedClass + "%SPEED_CLASS%":"") + (engineId != "" ? engineId + "%":"") + "'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for CD-TCON within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for CD-TCON within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for CD-TCON within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for CD-TCON within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for CD-TCON within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for CD-TCON within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="trainSymbolTrainSeed">trainseed storing the Train Symbol</param>
		/// <param name="originDateTrainSeed">trainseed storing the origin date of the ptc train</param>
		/// <param name="engineNumberTrainSeed">trainseed storing the ptc engine</param>
		/// <param name="engineNumberEngineSeed">engineseed storing the ptc engine or the ptc engine id itself</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateDC_TCON_ABF_OTC_MESSAGE_ADMS(string trainSymbolTrainSeed, string originDateTrainSeed, string engineNumberTrainSeed, string engineNumberEngineSeed, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSymbolTrainSeed);
            if (trainSymbol == null)
            {
                trainSymbol = trainSymbolTrainSeed;
            }
            
            string originDate = PDS_CORE.Code_Utils.NS_TrainID.getOriginDate(originDateTrainSeed);
            if (originDate == null)
            {
                originDate = originDateTrainSeed;
            }
            
            string engineId = "";
            string engineInitial = PDS_CORE.Code_Utils.NS_TrainID.GetEngineInitial(engineNumberTrainSeed, engineNumberEngineSeed);
            if (engineInitial == null)
            {
                engineId = engineNumberEngineSeed;
            } else {
                engineId = engineInitial + "%" + PDS_CORE.Code_Utils.NS_TrainID.GetEngineNumber(engineNumberTrainSeed, engineNumberEngineSeed);
            }
            
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%DC-TCON%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + trainSymbol + "%" + originDate + "%" + engineId + "%'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for DC-TCON within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for DC-TCON within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for DC-TCON within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for DC-TCON within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for DC-TCON within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for DC-TCON within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="trainSymbolTrainSeed">trainseed storing the train symbol</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateCD_RTDL_ABF_OTC_MESSAGE_ADMS(string trainSymbolTrainSeed, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSymbolTrainSeed);
            if (trainSymbol == null)
            {
                trainSymbol = trainSymbolTrainSeed;
            }
            
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%CD-RTDL%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + trainSymbol + "%'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for CD-RTDL within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for CD-RTDL within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for CD-RTDL within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for CD-RTDL within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for CD-RTDL within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for CD-RTDL within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="trainSymbolTrainSeed">trainseed storing the Train Symbol</param>
		/// <param name="originDateTrainSeed">trainseed storing the origin date of the ptc train</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateDC_TRDL_ABF_OTC_MESSAGE_ADMS(string trainSymbolTrainSeed, string originDateTrainSeed, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSymbolTrainSeed);
            if (trainSymbol == null)
            {
                trainSymbol = trainSymbolTrainSeed;
            }
            
            string originDate = PDS_CORE.Code_Utils.NS_TrainID.getOriginDate(originDateTrainSeed);
            if (originDate == null)
            {
                originDate = originDateTrainSeed;
            }
            
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%DC-TRDL%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + trainSymbol + "%" + originDate + "%'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for DC-TRDL within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for DC-TRDL within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for DC-TRDL within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for DC-TRDL within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for DC-TRDL within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for DC-TRDL within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="messageBeingAcknowledged">message ID being acknowledged by the DC-AK01</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateGD_AK01_ABF_OTC_MESSAGE_ADMS(string messageBeingAcknowledged, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%GD-AK01%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + messageBeingAcknowledged + "%'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for GD-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for GD-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for GD-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for GD-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for GD-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for GD-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="trainSymbolTrainSeed">trainseed storing the Train Symbol</param>
		/// <param name="originDateTrainSeed">trainseed storing the origin date of the ptc train</param>
		/// <param name="engineNumberTrainSeed">trainseed storing the ptc engine</param>
		/// <param name="engineNumberEngineSeed">engineseed storing the ptc engine or the ptc engine id itself</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateGD_VICR_ABF_OTC_MESSAGE_ADMS(string engineNumberTrainSeed, string engineNumberEngineSeed, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            string engineId = "";
            string engineInitial = PDS_CORE.Code_Utils.NS_TrainID.GetEngineInitial(engineNumberTrainSeed, engineNumberEngineSeed);
            if (engineInitial == null)
            {
                engineId = engineNumberEngineSeed;
            } else {
                engineId = engineInitial + "%" + PDS_CORE.Code_Utils.NS_TrainID.GetEngineNumber(engineNumberTrainSeed, engineNumberEngineSeed);
            }
            
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%GD-VICR%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + engineId + "%'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for GD-VICR within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for GD-VICR within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for GD-VICR within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for GD-VICR within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for GD-VICR within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for GD-VICR within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="userId">User Id for CATA</param></param>
		/// <param name="minutesBeforeNow">Minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateGD_CATA_ABF_OTC_MESSAGE_ADMS(string userId, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%GD-CATA%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + userId + "%'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for GD-CATA within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for GD-CATA within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for GD-CATA within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for GD-CATA within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for GD-CATA within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for GD-CATA within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="trainSymbolTrainSeed">trainseed storing the Train Symbol</param>
		/// <param name="originDateTrainSeed">trainseed storing the origin date of the ptc train</param>
		/// <param name="engineNumberTrainSeed">trainseed storing the ptc engine</param>
		/// <param name="engineNumberEngineSeed">engineseed storing the ptc engine or the ptc engine id itself</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateGD_ADSR_ABF_OTC_MESSAGE_ADMS(string engineNumberTrainSeed, string engineNumberEngineSeed, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            string engineId = "";
            string engineInitial = PDS_CORE.Code_Utils.NS_TrainID.GetEngineInitial(engineNumberTrainSeed, engineNumberEngineSeed);
            if (engineInitial == null)
            {
                engineId = engineNumberEngineSeed;
            } else {
                engineId = engineInitial + "%" + PDS_CORE.Code_Utils.NS_TrainID.GetEngineNumber(engineNumberTrainSeed, engineNumberEngineSeed);
            }
            
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%GD-ADSR%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + engineId + "%'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for GD-ADSR within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for GD-ADSR within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for GD-ADSR within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for GD-ADSR within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for GD-ADSR within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for GD-ADSR within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="messageBeingAcknowledged">message ID being acknowledged by the DG-AK01</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateDG_AK01_ABF_OTC_MESSAGE_ADMS(string messageBeingAcknowledged, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%DG-AK01%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + messageBeingAcknowledged + "%'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for DG-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for DG-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for DG-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for DG-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for DG-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for DG-AK01 (" + messageBeingAcknowledged + ") within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="trainSymbolTrainSeed">trainseed storing the Train Symbol</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateDG_TAUT_ABF_OTC_MESSAGE_ADMS(string trainSymbolTrainSeed, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSymbolTrainSeed);
            if (trainSymbol == null)
            {
                trainSymbol = trainSymbolTrainSeed;
            }
            
            System.DateTime currentTime = System.DateTime.UtcNow;
    	    string startTimeFormatted = currentTime.AddMinutes(-1 * int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
    	    
    	    string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%DG-TAUT%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + trainSymbol + "%'";
    	    Ranorex.Report.Info("Query ran is : " + qry);
    	    DataTable output = new DataTable();
            output = ADMSEnvironment.RunQuery(qry);
            
            int foundRows = output.Rows.Count;
            
            //20 seconds of checking
            System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
            
            if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for DG-TAUT within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for DG-TAUT within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for DG-TAUT within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for DG-TAUT within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for DG-TAUT within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for DG-TAUT within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        [UserCodeMethod]
        public static void NS_ValidateChangedEffectiveTimeReplacedBulletin(string bulletinSeed, string newBulletinSeed, int expTimeDifferenceInMinutes)
        {
        	string bulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
        	string newBulletinNumber = NS_Bulletin.GetBulletinNumber(newBulletinSeed);
        	
        	string oldBulletinEffectiveTime = ADMSEnvironment.GetEffectiveTimeOfBulletin(bulletinNumber);
        	Ranorex.Report.Info("Effective for Bulletin with bulletin Number: {"+bulletinNumber+"} is {"+oldBulletinEffectiveTime+"}");
        	string newBulletinEffectiveTime = ADMSEnvironment.GetEffectiveTimeOfBulletin(newBulletinNumber);
        	Ranorex.Report.Info("Effective for Bulletin with bulletin Number: {"+newBulletinNumber+"} is {"+newBulletinEffectiveTime+"}");
        	
        	TimeSpan timeDifference = System.DateTime.Parse(newBulletinEffectiveTime) - System.DateTime.Parse(oldBulletinEffectiveTime);
        	int timeDifferenceInMinutes = Convert.ToInt32(timeDifference.TotalMinutes);
        	if(timeDifferenceInMinutes == expTimeDifferenceInMinutes)
        	{
        		Ranorex.Report.Success("The difference between two effective time difference of bulletins is expected to be {"+expTimeDifferenceInMinutes+"} minutes and found {"+timeDifferenceInMinutes+"} minutes");
        	}
        	else
        	{
        		Ranorex.Report.Failure("The difference between two effective time difference of bulletins is expected to be {"+expTimeDifferenceInMinutes+"} minutes and found {"+timeDifferenceInMinutes+"} minutes");
        	}
        }
        
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="bulletinSeed">Bulletin Seed to fetch milepost details</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateDG_BULI_ABF_OTC_MESSAGE_ADMS(string bulletinSeed, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
        	string milePost1 = NS_Bulletin.GetBulletinMilepost1(bulletinSeed);
        	string milePost2 = NS_Bulletin.GetBulletinMilepost2(bulletinSeed);
        	
        	System.DateTime currentTime = System.DateTime.UtcNow;
        	string startTimeFormatted = currentTime.AddMinutes(-1*int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
        	
        	string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%DG-BULI%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + milePost1 + "%" + milePost2 + "%'";
        	DataTable output = new DataTable();
        	output = ADMSEnvironment.RunQuery(qry);
        	
        	int foundRows = output.Rows.Count;
        	
        	//Checking for 20 seconds if no rows found
        	System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
        	
        	 if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for DG-BULI within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for DG-BULI within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for DG-BULI within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for DG-BULI within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for DG-BULI within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for DG-BULI within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
        [UserCodeMethod]
        public static void NS_ValidateGD_BOSR_ABF_OTC_MESSAGE_ADMS(string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            
        }
        
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
		[UserCodeMethod]
        public static void NS_ValidateDC_ASBI_ABF_OTC_MESSAGE_ADMS(string minutesBeforeNow, string trainSeed, string bulletinSeed, string expectedCount, bool validateExists)
        {
        	System.DateTime currentTime = System.DateTime.UtcNow;
        	//TimeZoneInfo gmtZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
        	//System.DateTime currentGMTTime = TimeZoneInfo.ConvertTimeFromUtc(currentTime, gmtZone);
        	Report.Info("Current UTC Time: "+currentTime.ToString());
        	string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
        	string trainOriginDate = PDS_CORE.Code_Utils.NS_TrainID.getOriginDate(trainSeed);
        	string bulletinNumber = PDS_NS.UserCodeCollections.NS_Bulletin.GetBulletinNumber(bulletinSeed);
        	string startTimeFormatted = currentTime.AddMinutes(-1*int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
        	
        	string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%DC-ASBI%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%"+trainSymbol+"%"+trainOriginDate+"%' AND otc.MESSAGE_XML LIKE '%"+bulletinNumber+"%'";
        	Ranorex.Report.Info("Query: "+qry);
        	DataTable output = new DataTable();
        	output = ADMSEnvironment.RunQuery(qry);
        	
        	int foundRows = output.Rows.Count;
        	
        	//Checking for 20 seconds if no rows found
        	System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
        	
        	 if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for DC-ASBI within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for DC-ASBI within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for DC-ASBI within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for DC-ASBI within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for DG-ASBI within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for DC-ASBI within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
		[UserCodeMethod]
        public static void NS_ValidateCD_CABI_ABF_OTC_MESSAGE_ADMS(string minutesBeforeNow, string bulletinSeed, string trainSeed, string expectedCount, bool validateExists)
        {
        	System.DateTime currentTime = System.DateTime.UtcNow;
        	//TimeZoneInfo gmtZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
        	//System.DateTime currentGMTTime = TimeZoneInfo.ConvertTimeFromUtc(currentTime, gmtZone);
        	string startTimeFormatted = currentTime.AddMinutes(-1*int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
        	string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
        	string trainOriginDate = PDS_CORE.Code_Utils.NS_TrainID.getOriginDate(trainSeed);
        	Report.Info(currentTime.ToString());
        	string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%CD-CABI%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%"+trainSymbol+"%"+trainOriginDate+"%'";
        	Report.Info("CABI: "+qry);
        	DataTable output = new DataTable();
        	output = ADMSEnvironment.RunQuery(qry);
        	
        	int foundRows = output.Rows.Count;
        	
        	System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
        	
        	 if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for CD-CABI within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for CD-CABI within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for DG-CABI within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for CD-CABI within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for DG-ASBI within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for CD-CABI within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="trainSymbolTrainSeed">trainseed storing the train symbol</param>
		/// <param name="originDateTrainSeed">trainseed storing the origin date of the ptc train</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
		[UserCodeMethod]
        public static void NS_ValidateDC_MESS_ABF_OTC_MESSAGE_ADMS(string trainSymbolTrainSeed, string originDateTrainSeed, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSymbolTrainSeed);
            if (trainSymbol == null)
            {
                trainSymbol = trainSymbolTrainSeed;
            }
            
            string originDate = PDS_CORE.Code_Utils.NS_TrainID.getOriginDate(originDateTrainSeed);
            if (originDate == null)
            {
                originDate = originDateTrainSeed;
            }
            
        	System.DateTime currentTime = System.DateTime.UtcNow;
        	string startTimeFormatted = currentTime.AddMinutes(-1*int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
        	
        	string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%DC-MESS%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + trainSymbol + "%" + originDate + "%'";
        	DataTable output = new DataTable();
        	output = ADMSEnvironment.RunQuery(qry);
        	
        	int foundRows = output.Rows.Count;
        	
        	//Checking for 20 seconds if no rows found
        	System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
        	
        	 if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for DC-MESS within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for DC-MESS within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for DC-MESS within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for DC-MESS within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for DG-ASBI within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for DC-MESS within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
        
        /// <summary>
		/// Validates Number of PTC messages received within a timeframe
		/// </summary>
		/// <param name="trainSymbolTrainSeed">trainseed storing the train symbol</param>
		/// <param name="originDateTrainSeed">trainseed storing the origin date of the ptc train</param>
		/// <param name="minutesBeforeNow">minutes before now to check for the ADMS entry</param>
		/// <param name="expectedCount">Expected number of messages, blank for no particular expectation</param>
		/// <param name="validateExists">Validate Exists or not</param>
		[UserCodeMethod]
        public static void NS_ValidateDC_ENED_ABF_OTC_MESSAGE_ADMS(string trainSymbolTrainSeed, string originDateTrainSeed, string minutesBeforeNow, string expectedCount, bool validateExists)
        {
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSymbolTrainSeed);
            if (trainSymbol == null)
            {
                trainSymbol = trainSymbolTrainSeed;
            }
            
            string originDate = PDS_CORE.Code_Utils.NS_TrainID.getOriginDate(originDateTrainSeed);
            if (originDate == null)
            {
                originDate = originDateTrainSeed;
            }
            
        	System.DateTime currentTime = System.DateTime.UtcNow;
        	string startTimeFormatted = currentTime.AddMinutes(-1*int.Parse(minutesBeforeNow)).ToString("dd-MMM-yy hh.mm.ss.fffffff00 tt").ToUpper();
        	
        	string qry = "SELECT otc.MESSAGE_ID,otc.BF_TIMESTAMP FROM ADMS.ABF_OTC_MESSAGE otc WHERE otc.MESSAGE_ID LIKE '%DC-ENED%' AND otc.BF_TIMESTAMP > '" + startTimeFormatted + "' AND otc.MESSAGE_XML LIKE '%" + trainSymbol + "%" + originDate + "%'";
        	DataTable output = new DataTable();
        	output = ADMSEnvironment.RunQuery(qry);
        	
        	int foundRows = output.Rows.Count;
        	
        	//Checking for 20 seconds if no rows found
        	System.DateTime checkTime = System.DateTime.Now.AddSeconds(20);
            while (foundRows == 0 && validateExists && System.DateTime.Now < checkTime)
            {
            	Ranorex.Delay.Seconds(1);
            	output = ADMSEnvironment.RunQuery(qry);
            	foundRows = output.Rows.Count;
            }
        	
        	 if (validateExists)
            {
                if (expectedCount != "")
                {
                    int expectedCountInt;
                    if (int.TryParse(expectedCount, out expectedCountInt))
                    {
                        if (expectedCountInt == foundRows)
                        {
                            Ranorex.Report.Success("Expected and found " + expectedCountInt.ToString() + " records in ADMS for DC-ENED within {" + minutesBeforeNow + "} minutes");
                        } else {
                            Ranorex.Report.Failure("Expected " + expectedCountInt.ToString() + " and found " + foundRows.ToString() + " records in ADMS for DC-ENED within {" + minutesBeforeNow + "} minutes");
                        }
                    } else {
                        Ranorex.Report.Error("Expected count of " + expectedCount + " could not be converted to an integer");
                    }
                } else {
                    if (foundRows > 0)
                    {
                        Ranorex.Report.Success("Found " + foundRows.ToString() + " records in ADMS for DC-ENED within {" + minutesBeforeNow + "} minutes");
                    } else {
                        Ranorex.Report.Failure("Found 0 records in ADMS for DC-ENED within {" + minutesBeforeNow + "} minutes");
                    }
                }
            } else {
                if (foundRows > 0)
                {
                    Ranorex.Report.Failure("Found " + foundRows.ToString() + " records in ADMS for DC-ENED within {" + minutesBeforeNow + "} minutes");
                } else {
                    Ranorex.Report.Success("Found 0 records in ADMS for DC-ENED within {" + minutesBeforeNow + "} minutes");
                }
            }
        }
    }
}
