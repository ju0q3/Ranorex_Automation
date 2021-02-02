/*
 * Created by Ranorex
 * User: r07000021
 * Date: 10/13/2017
 * Time: 10:42 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess;
using System.Collections.Generic;

namespace Oracle.Code_Utils
{
	/// <summary>
	/// Description of DataLoader.
	/// </summary>
	public class DataLoader
	{
		private Boolean isPersistant;
		private OracleConnection Oracle;
		private OracleConnectionContext UserContext;
	
		
		public DataLoader(OracleConnectionContext ctx)
		{
			UserContext = ctx;
			isPersistant = false;
			Oracle = new OracleConnection(ctx.BuildConnectionString(false));
		}
		
		public DataLoader(string manualConnection)
		{
			UserContext = null;
			isPersistant = false;
			Oracle = new OracleConnection(manualConnection);
		}
		
		public List<OracleParameter> ParamaterizeQuery(string query) {
			return new List<OracleParameter>();
		}
		
		
        public DataTable ReadOracleDataToTable(string query, List<OracleParameter> param=null)
        {
        	List<OracleParameter> parameters;
        	
        	if(param == null)
            	parameters = ParamaterizeQuery(query);
        	else parameters = param;
        	
            DataTable t = new DataTable();
            try
            {
                if (!PersistantCon && Oracle.State != ConnectionState.Open)
                {
                	string tns_admin = Environment.GetEnvironmentVariable("TNS_ADMIN");
                	
                    Oracle.Open();
                }

                var command = new OracleCommand
                {
                	CommandText = query,
                    Connection = Oracle,
                };

                //difference in old vs new ODP. Multiple uses of bind variables will fail without it
                command.BindByName = true; 

                parameters.ForEach(p => command.Parameters.Add(p) );

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        t.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
            	Ranorex.Report.Error(ex.Message + "\r\n" + ex.StackTrace + "\r\n" + query);
            	//throw;
            }
            finally
            {
                if(!PersistantCon && Oracle.State == ConnectionState.Open)
                    Oracle.Close();
            }

            return t;
        }
        
        public int ExecuteUpdateQueryToTable(string query, List<OracleParameter> param=null)
        {
        	List<OracleParameter> parameters;
        	
        	if(param == null)
            	parameters = ParamaterizeQuery(query);
        	else parameters = param;
        	Ranorex.Report.Info("Params: "+parameters.ToString());

        	int i = 0;
        	try
            {
                if (!PersistantCon && Oracle.State != ConnectionState.Open)
                {
                	string tns_admin = Environment.GetEnvironmentVariable("TNS_ADMIN");
                	
                    Oracle.Open();
                }

                var command = new OracleCommand
                {
                	CommandText = query,
                    Connection = Oracle,
                };

                //difference in old vs new ODP. Multiple uses of bind variables will fail without it
                command.BindByName = true; 

                parameters.ForEach(p => command.Parameters.Add(p) );

                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.UpdateCommand = Oracle.CreateCommand();
                adapter.UpdateCommand.CommandText = query;
                i = adapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            	Ranorex.Report.Error(ex.Message + "\r\n" + ex.StackTrace + "\r\n" + query);
            }
            finally
            {
                if(!PersistantCon && Oracle.State == ConnectionState.Open)
                    Oracle.Close();
            }

            return i;
        }
        
        /// <summary>
        /// Creates Oracle Connection with one time open/close and connection pooling in ODP
        /// </summary>
        public void EstablishPersistantConnection()
        {
            try
            {
                if (Oracle.State != ConnectionState.Open)
                {
                    //put connection pulling string into connection
                    Oracle.ConnectionString = UserContext.BuildConnectionString(true);

                    //attempt to open and flag Loader as persisitant
                    Oracle.Open();
                    isPersistant = true;
                }
            }
            catch (OracleException ex)
            {
            	Ranorex.Report.Error(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        public Boolean PersistantCon
        {
            get { return Oracle.State == ConnectionState.Open && isPersistant; }
        }

        public void ClosePersistantConnection(OracleConnectionContext ctx)
        {
            try
            {
                if (Oracle.State == ConnectionState.Open)
                    Oracle.Close();
                isPersistant = false;
                Oracle.ConnectionString = UserContext.BuildConnectionString(false);
            }
            catch (OracleException ex)
            {
                Ranorex.Report.Error(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        
	}
}
