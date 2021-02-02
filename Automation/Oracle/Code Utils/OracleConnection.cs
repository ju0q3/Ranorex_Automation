/*
 * Created by Ranorex
 * User: 210057585
 * Date: 10/10/2017
 * Time: 11:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Oracle.Code_Utils
{
	/// <summary>
	/// Description of OracleConnection.
	/// </summary>
	public class OracleConnectionContext
	{
		private static string _userName = null;
		private static string _password = null;
		//private static string _connectionString = null;		
		
		private static string _TNS = null;
		
		public OracleConnectionContext(string UserName, string Password, string TNS)
		{
			_userName = UserName;
			_password = Password;
			_TNS = TNS;
		}
		
		
      	//build connection string
        public string BuildConnectionString(Boolean pooling = false)
        {
            var conn = "";
            if (pooling)
            {
                conn = String.Format("Data Source={0};User Id={1};Password={2};" +
                    "Min Pool Size=10;Connection Lifetime=120;Connection Timeout=60;" +
                    "Incr Pool Size=5; Decr Pool Size=2",
                    _TNS,
                    _userName,
                    _password);
            }
            else
            {
                conn = String.Format("Data Source={0};User Id={1};Password={2};",
                    _TNS,
                    _userName,
                    _password);
            }

            return conn;
        }
	}
	
	
}
