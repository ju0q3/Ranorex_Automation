/*
 * Created by Ranorex
 * User: r07000021
 * Date: 2/12/2019
 * Time: 8:38 AM
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

namespace STE.Code_Utils.messages
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class CacheRefresh
    {
    	
    	/// <summary>
    	/// Validates that certain filters are not found when querying the cache refresh
    	/// Gets the contents of the cache refresh from the server, removes new lines, and compares against filters
    	/// </summary>
    	/// <param name="labelName">Name of Server label being run</param>
    	/// <param name="district">District for the cache refresh information</param>
    	/// <param name="division">division for the district. i.e. Georgia = div1</param>
    	/// <param name="messageType">DG, DC, etc..</param>
    	/// <param name="filters">Pipe delimited string for checking contents of cache refresh output</param>
    	[UserCodeMethod]
    	public static void ValidateMessageInCacheRefreshFunction_NS(string labelName, string district, string division, string messageType, string filters)
    	{
    		bool filterFail = false;
    		Env.Code_Utils.VMEnvironment vm = Env.Code_Utils.VMEnvironment.Instance();
    		string cacheRefreshOutput = Env.Code_Utils.LinuxUtils.getCacheRefreshInformation(vm, labelName, district, division, messageType).Replace("\n", " ");
    		foreach (string filter in filters.Split('|'))
            {
    			Ranorex.Report.Info("Checking Filter {"+@filter+"}");
            	Regex filterRegex = new Regex(@".*"+@filter+@".*");
            	if (!filterRegex.IsMatch(@cacheRefreshOutput))
                {
            		Ranorex.Report.Failure("Filter {"+@filter+"} not found in cacheRefreshOutput");
            		filterFail = true;
                }
            }
    		if (filterFail)
    		{
    			Ranorex.Report.Info("Cache Refresh Message Information Contents : {"+cacheRefreshOutput+"}");
    			return;
    		}
    		
    		
    		Ranorex.Report.Success("All Message Filters found in cache Refresh");
    		return;
    	}
    	
    	
    	/// <summary>
    	/// Validates that certain filters are not found when querying the cache refresh
    	/// Gets the contents of the cache refresh from the server, removes new lines, and compares against filters
    	/// </summary>
    	/// <param name="labelName">Name of Server label being run</param>
    	/// <param name="district">District for the cache refresh information</param>
    	/// <param name="division">division for the district. i.e. Georgia = div1</param>
    	/// <param name="messageType">DG, DC, etc..</param>
    	/// <param name="filters">Pipe delimited string for checking contents of cache refresh output</param>
    	[UserCodeMethod]
    	public static void ValidateMessageNotInCacheRefreshFunction_NS(string labelName, string district, string division, string messageType, string filters)
    	{
    		bool filterFail = false;
    		Env.Code_Utils.VMEnvironment vm = Env.Code_Utils.VMEnvironment.Instance();
    		string cacheRefreshOutput = Env.Code_Utils.LinuxUtils.getCacheRefreshInformation(vm, labelName, district, division, messageType).Replace("\n", " ");
    		foreach (string filter in filters.Split('|'))
            {
    			Ranorex.Report.Info("Checking Filter {"+@filter+"}");
            	Regex filterRegex = new Regex(@".*"+@filter+@".*");
            	if (!filterRegex.IsMatch(@cacheRefreshOutput))
                {
            		filterFail = true;
                }
            }
    		if (filterFail)
    		{
    			Ranorex.Report.Info("Cache Refresh Message Information Contents : {"+cacheRefreshOutput+"}");
    			Ranorex.Report.Success("One or more of the filters was not found in the cache refresh");
    			return;
    		}
    		
    		
    		Ranorex.Report.Failure("All Message Filters found in cache Refresh");
    		return;
    	}
    }
}
