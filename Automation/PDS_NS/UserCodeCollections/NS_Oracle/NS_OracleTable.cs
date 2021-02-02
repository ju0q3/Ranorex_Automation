/*
 * Created by Ranorex
 * User: 503073759
 * Date: 5/20/2019
 * Time: 6:30 AM
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
    public class NS_OracleTable
    {
    	    
        private string[] _colnames = new string[] {};
        private DataTable _dt = new DataTable();
        private int _rowcount = 0;

        public NS_OracleTable(DataTable dt)
        {
            this._dt = dt;
            setColumnNames();
            setRowCount();
        }

        private void setRowCount()
        {
            this._rowcount = this._dt.Rows.Count;
        }

        private void setColumnNames()
		{
			string[] colNames = new string[] {};
			colNames = this._dt.Columns.Cast<DataColumn>()
                                       .Select(name => name.ColumnName)
                                       .ToArray();
			this._colnames = colNames;
		}

        private bool columnExists(string columnName)
		{
			bool colExists = false;

            int indexPosition = Array.IndexOf(this._colnames, columnName);
			if (indexPosition > -1)
			{
				colExists = true;
			} else {
                Report.Error(string.Format("The column name '{0}' does not exist in the Oracle results. Please check your query.", columnName));
            }
			return colExists;
		}

        private bool rowExists(int rowIndex)
        {
            bool doesRowExist = false;
            if (rowIndex < this._rowcount)
            {
                doesRowExist = true;
            } else {
                Report.Error(string.Format(
                    "Row number '{0}' does not exist in the Oracle results. The Oracle table includes '{1}' rows.", 
                    (rowIndex+1).ToString(), this._rowcount.ToString()
                ));
            }
            return doesRowExist;
        }
        
        public void ValidateCell(string expectedValue, string columnName, int rowIndex = 0)
        {
            string actualValue = GetCellValue(columnName, rowIndex);
            Regex expectedRegex = new Regex(expectedValue);

            string feedbackMessage = string.Format("Oracle entry for '{0}' has actual value: '{1}' and expected value: '{2}'", columnName, actualValue, expectedValue);
            if (expectedRegex.IsMatch(actualValue))
			{
				Ranorex.Report.Success("Validation", feedbackMessage);
			} else {
				Ranorex.Report.Failure("Validation", feedbackMessage);
			}

        }

        public string GetCellValue(string columnName, int rowIndex = 0)
        {
            string outValue = null;
            
            if (columnExists(columnName) && rowExists(rowIndex))
            {
                DataColumn column = this._dt.Columns[columnName];
                outValue = this._dt.Rows[rowIndex][column].ToString();
            }
            return outValue;
        }

        public bool CellEquals(string expectedValue, string columnName, int rowIndex)
        {
            string actualValue = GetCellValue(columnName, rowIndex);
            return actualValue.Equals(expectedValue, StringComparison.InvariantCultureIgnoreCase);
        }
        
        public int GetRowCount()
        {
            return this._rowcount;
        }
		
    }
}
