/*
 * Created by Ranorex
 * User: 502589202
 * Date: 8/14/2018
 * Time: 8:35 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using Env.Code_Utils;

namespace PDS_CORE.Code_Utils.Territory
{
	/// <summary>
	/// Description of TerritoryNameIdMap.
	/// </summary>
	public class TerritoryNameIdMap
	{
		private static TerritoryNameIdMap instance = null;
		public Dictionary<string,string> territoryMap = new Dictionary<string, string>();
		public Dictionary<string,string> territoryLoidMap = new Dictionary<string, string>();
		
        public static TerritoryNameIdMap Instance()
        {
            if (instance == null)
            {
                instance = new TerritoryNameIdMap();
            }
            return instance;
        }
        
        private TerritoryNameIdMap()
        {
            loadTerritoryNameIds();
        }
        
        //loadTerritoryNameIds will load the territory names and corresponding IDs into a dictionary
        private int loadTerritoryNameIds()
        {
        	string line;
            string[] variables = null;
        	VMEnvironment vm = VMEnvironment.Instance();
        	
        	string territoryMapFile = vm.baseCoreDir+"Data/Territory/TerritoryNameIdMap.csv";
        	
            System.IO.StreamReader territoryList = new System.IO.StreamReader(@territoryMapFile);
            while((line = territoryList.ReadLine()) != null)
            {
            	char[] delimiters = new Char[] { ',' };
                variables = line.Split(delimiters);
                if (!variables[0].Equals("territory_name") && ! territoryMap.ContainsKey(variables[0].ToLower()))
                {
                	territoryMap.Add(variables[0].ToLower(), variables[1]);
                	territoryLoidMap.Add(variables[0].ToLower(), variables[2]);
                }
            }
        	
            if (variables == null)
            {
                return 1;
            }
                        
        	return 0;
        	
	    }
        
        //lookupTerritoryId will trim whitespace before and after a variable as well as call ToLower to assist with looking up territory IDs
        public string lookupTerritoryId(string territoryName)
        {
        	string id = "-1";
        	string name = territoryName.TrimStart().TrimEnd().ToLower();
        	
        	id = territoryMap[name];
        	
        	return id;
        }
        
        //lookupTerritoryId will trim whitespace before and after a variable as well as call ToLower to assist with looking up territory IDs
        public string lookupTerritoryLoidId(string territoryName)
        {
        	string id = "-1";
        	string name = territoryName.TrimStart().TrimEnd().ToLower();
        	
        	id = territoryLoidMap[name];
        	
        	return id;
        } 
	}
}
