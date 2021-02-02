/*
 * Created by Ranorex
 * User: 503073759
 * Date: 6/7/2019
 * Time: 5:46 AM
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

namespace PDS_CORE.Code_Utils
{
    public class MsgFilter
	{

		private List<string> _filters = null;

		public MsgFilter()
		{
			_filters = new List<string>();
		}
		
		public MsgFilter(string filter)
		{
			_filters = new List<string>();
			this._filters.Add(filter);
		}

		public MsgFilter(List<string> filters)
		{
			this._filters = filters;
		}

		public void AddFilter(string xmlVal, string xmlAttr)
		{
			// Since the default, unbound value will be an empty string, only add the filter if the variable is bound
			if (!string.IsNullOrEmpty(xmlVal) && !string.IsNullOrEmpty(xmlAttr))
			{
				if (xmlVal == "Blank")
				{
					xmlVal = "";
				}
				string xmlFilter = "<" + xmlAttr + ">" + xmlVal + "</" + xmlAttr + ">";
				_filters.Add(xmlFilter);
			}
		}
		
		/// <summary>
		/// Pass the complete tag with value
		/// e.g. <S5_SEQUENCE>1</S5_SEQUENCE>
		/// </summary>
		/// <param name="xmlTag"></param>
		public void AddFilter(string xmlTag)
		{
			// Since the default, unbound value will be an empty string, only add the filter if the variable is bound
			if (!string.IsNullOrEmpty(xmlTag) )
			{
				_filters.Add(xmlTag);
			}
		}
		public void AddFilter_NotExistTag(string xmlAttr)
		{
			if (!string.IsNullOrEmpty(xmlAttr))
			{
				string xmlFilter = @"^(?(?!"+xmlAttr+@").)*\S$";
				_filters.Add(xmlFilter);
			}
		}

		public string FormatFilters()
		{
			string filters = string.Join("|", GetFiltersAsArray());
			return filters;
		}

		public string[] GetFiltersAsArray()
		{
			return _filters.ToArray();
		}

		// for later
		private void addMultiple(string[] xmlVals, string[] xmlAttrs, List<string> msgFilters = null)
		{
			if (xmlVals.Length != xmlAttrs.Length)
			{
				Report.Warn(string.Format("The number of values given ({0}) is different than the number of xml attributes given ({1}).", xmlVals.Length.ToString(), xmlAttrs.Length.ToString()));
				throw new IndexOutOfRangeException();
			}

			for (int i = 0; i < xmlVals.Length; i++)
			{
				AddFilter(xmlVals[i], xmlAttrs[i]);
			}
		}
	}
}
