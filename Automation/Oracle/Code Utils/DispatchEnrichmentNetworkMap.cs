/*
 * Created by Ranorex
 * User: 210058208
 * Date: 11/15/2018
 * Time: 9:31 AM
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
using System.Linq;
using System.Data; 

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace Oracle.Code_Utils
{
	
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class DispatchEnrichmentNetworkMap
    {
    	
    	internal class StationInfo {
        	public string StationId;
        	public string StationName;
		}
    	
    	/// <summary>
    	/// 
    	/// </summary>
    	/// <param name="subdiv"></param>
    	/// <param name="SqlConnection"></param>
    	[UserCodeMethod]
    	public static void populateFBANeighborTest(string subdiv, string SqlConnection) {
            /*
				 we're trying to turn this:
				
				            A             B           C
				              __ ______ ___
				             /             \
				    ----- -- --- ------ --- -- ----- ---
				
				into this:
				    { |A| ---siding--- |B| ,
				
				      |A| --- main --- |B| ,  |B| --- main --- |C| 
				      
				    }
				
				through depth first search and qualifying traversal based on section/station id
             */

            //just the basics first

            var network = loadTDMSMap(SqlConnection);

            //TODO hook up more subdivs in single run
            List<string> subdivs = new List<string>()
            {
                subdiv
            };

            //get our reduced network based on the subdivisions we are interested in working with
            var first = network
            	.Where(x => subdivs.Contains(x.DistrictName))
            	//make sure we dont hit a shelf on our first search
            	.Where(y => (y.HighNormalSectionID != String.Empty || y.HighReverseSectionID != String.Empty 
            	             || y.LowNormalSectionID != String.Empty || y.LowReverseSectionID != String.Empty ) )
            	.First();

            var result = NetworkSearch(network, first, SubdivisionComparator, FullAdjacency);

            
            
            //for every station identified as authority.. 
            var stations = network
                .Where(x => subdivs.Contains(x.DistrictName))
                .Where(y => y.StationName != string.Empty)
            	.Distinct()
            	.Select(y => new StationInfo { StationId = y.StationID, StationName = y.StationName }).ToList();

            List<Tuple<string, string, string>> StationMap = new List<Tuple<string, string, string>>();

            List<Tuple<FlatValueTopoEdge, FlatValueTopoEdge>> attempted = new List<Tuple<FlatValueTopoEdge, FlatValueTopoEdge>>();

            //bubble against every other stations as authority..
            //test network for path to that station using comparator that restricts movement to like named 'named tracks' and within subdiv
            
            /*
            //flatten some of this time complexity
            IEnumerable<Tuple<StationInfo, StationInfo>> testpairs = 
            	foreach(var station in stations)
            	foreach(var pair in stations) yield new Tuple(station,pair);
            */
           
            foreach(var station in stations)
            {
                foreach(var pair in stations)
                {
                    //exclude self
                    if (station.StationId != pair.StationId)
                    {
                        //find a section of each station
                        var candidateList1 = network
                            .Where(x => subdivs.Contains(x.DistrictName))
                            .Where(y => y.StationID == station.StationId);

                        var candidateList2 = network
                            .Where(x => subdivs.Contains(x.DistrictName))
                            .Where(y => y.StationID == pair.StationId);

                        /* expensive /cry /sad  #whatistimecomplexityanyways?? */
                        foreach(FlatValueTopoEdge edge1 in candidateList1)
                        {
                            foreach(FlatValueTopoEdge edge2 in candidateList2) {
                                if (!attempted.Contains(Tuple.Create(edge1, edge2)))
                                {
                                    var searchResult = NetworkSearch(network, edge1, SustainNamedTrackComparator, FullAdjacency, x => x.SectionID == edge2.SectionID);

                                    attempted.Add(Tuple.Create(edge1, edge2));

                                    //forgot to check if the network actually "found" what we were looking for
                                    if (searchResult.Count > 0 && searchResult.Contains(edge2))
                                    {
                                        StationMap.Add(Tuple.Create(station.StationName, pair.StationName, searchResult.First().NamedTrackName));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            //Format the results to match the data table needs
            
        	/*
				To		At				FirstLimit		SecondLimit		FirstLimitTakeCP	SecondLimitTakeCP	Track
				Tester	O HARE			O HARE			DES PLAINES		FALSE				FALSE				MAIN ONE
				Tester	O HARE			O HARE			DES PLAINES		FALSE				FALSE				MAIN TWO
				Tester	DES PLAINES		DES PLAINES		PROSPECT		FALSE				FALSE				MAIN
				Tester	PROSPECT		PROSPECT		SOUTH WHEELING	FALSE				FALSE				MAIN ONE
				Tester	PROSPECT		PROSPECT		SOUTH WHEELING	FALSE				FALSE				MAIN TWO
				Tester	SOUTH WHEELING	SOUTH WHEELING	NORTH WHEELING	FALSE				FALSE				MAIN ONE
				Tester	SOUTH WHEELING	SOUTH WHEELING	NORTH WHEELING	FALSE				FALSE				MAIN TWO
				Tester	NORTH WHEELING	NORTH WHEELING	BUFFALO GROVE	FALSE				FALSE				MAIN ONE
				Tester	NORTH WHEELING	NORTH WHEELING	BUFFALO GROVE	FALSE				FALSE				MAIN TWO
				Tester	NORTH WHEELING	NORTH WHEELING	BUFFALO GROVE	FALSE				FALSE				MAIN THREE
 
        	 */ 
        	
        	DataTable enriched = new DataTable("DataTest_FBA_Neighbor");
        	enriched.Columns.AddRange(new DataColumn[] {
                  	new DataColumn("To", System.Type.GetType("System.String")),
                  	new DataColumn("At", System.Type.GetType("System.String")),
                  	new DataColumn("FirstLimit", System.Type.GetType("System.String")),
                  	new DataColumn("SecondLimit", System.Type.GetType("System.String")),
                  	new DataColumn("FirstLimitTakeCP", System.Type.GetType("System.String")),
                  	new DataColumn("SecondLimitTakeCP", System.Type.GetType("System.String")),
                  	new DataColumn("Track", System.Type.GetType("System.String"))
				});
        	
        	StationMap.ForEach(pair =>  {
        		DataRow newRow = enriched.NewRow();
        		
        		newRow["To"] = "TESTER";
        		newRow["At"] = pair.Item1;
        		newRow["FirstLimit"] = pair.Item1;
        		newRow["SecondLimit"] = pair.Item2;
        		newRow["FirstLimitTakeCP"] = "FALSE";
        		newRow["SecondLimitTakeCP"] = "FALSE";
        		newRow["Track"] = pair.Item3;
        		
        		enriched.Rows.Add(newRow);
			});
        	
        	//assign the data table to file needed by test
        	string filename = TDMSDataGenerationUtility.getCsvFileNameForConnector("DataTest_FBA_Neighbor");
			TDMSDataGenerationUtility.DataTableToCSV(enriched, filename);
    	}
    	
    	/// <summary>
    	/// Delegate for comparison of things in network map flat file. Add or remove additional success conditions for termination conditions of network serach.
    	/// </summary>
    	public delegate bool ComparatorFunc(FlatValueTopoEdge a, FlatValueTopoEdge b);
    	
        public static bool SubdivisionComparator(FlatValueTopoEdge a, FlatValueTopoEdge b)
        {
            if (a != null && b != null && (a.DistrictName == b.DistrictName)) return true;
            else return false;
        }

        /// <summary>
        /// Only traverse to next nodes if they contain the same named track and district as starting node.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool SustainNamedTrackComparator(FlatValueTopoEdge a, FlatValueTopoEdge b)
        {
            if (a != null && b != null 
                && (a.DistrictName == b.DistrictName)
                && (a.NamedTrackName == b.NamedTrackName) ) return true;
            else return false;
        }
        
        
        /// <summary>
        /// Depth First Search of Network given a Track Section comparator and method of traversing the Network.
        /// </summary>
        /// <param name="network">List of FlatValueTopoEdge that constittues search network </param>
        /// <param name="v">Root node</param>
        /// <param name="Comparator">Termination condition for search</param>
        /// <param name="AdjacencyStyle">Traversal style for search</param>
        /// <returns></returns>
        public static List<FlatValueTopoEdge> NetworkSearch(
            List<FlatValueTopoEdge> network,
            FlatValueTopoEdge v,
            ComparatorFunc Comparator,
            AdjacencyFunction AdjacencyStyle)
        {
            var stack = new Stack<FlatValueTopoEdge>();
            var discovered = new List<FlatValueTopoEdge>();

            stack.Push(v);
            while (stack.Count > 0)
            {
                var visit = stack.Pop();
                if (!discovered.Any(x => x.SectionID == visit.SectionID))
                {
                    discovered.Add(visit);
                    AdjacencyStyle(visit, network)
                    	.ForEach(edge =>
                    {
                        if (Comparator(visit, edge)) stack.Push(edge);
                    });
                }
            }

            return discovered;
        }
        
        /// <summary>
        /// Depth First Search of Network given a Track Section comparator and method of traversing the Network.
        /// </summary>
        /// <param name="network">List of FlatValueTopoEdge that constittues search network </param>
        /// <param name="v">Root node</param>
        /// <param name="Comparator">Termination condition for search</param>
        /// <param name="AdjacencyStyle">Traversal style for search</param>
        /// <param name="SuccessCondition">Short circuit success condition</param>
        /// <returns>List of edges traversed</returns>
        public static List<FlatValueTopoEdge> NetworkSearch(
            List<FlatValueTopoEdge> network,
            FlatValueTopoEdge v,
            ComparatorFunc Comparator,
            AdjacencyFunction AdjacencyStyle,
            Func<FlatValueTopoEdge, bool> SuccessCondition)
        {
            var stack = new Stack<FlatValueTopoEdge>();
            var discovered = new List<FlatValueTopoEdge>();

            stack.Push(v);
            while (stack.Count > 0)
            {
                var visit = stack.Pop();

                //short circuit on success condition
                if (SuccessCondition(visit))  {
                    discovered.Add(visit);
                    return discovered;
                }

                if (!discovered.Any(x => x.SectionID == visit.SectionID))
                {
                    discovered.Add(visit);
                    AdjacencyStyle(visit, network).ForEach(edge =>
                    {
                        if (Comparator(visit, edge)) stack.Push(edge);
                    });
                }
            }

            return discovered;
        }

        
        /// <summary>
        /// Delegate for style of network traversal. Add or remove additional success conditions for what edges are allowed to be traversed. 
        /// </summary>
        public delegate List<FlatValueTopoEdge> AdjacencyFunction(FlatValueTopoEdge edge, List<FlatValueTopoEdge> graph);

        /// <summary>
        /// used if reverse legs are allowed in the adjacency of what we're searching
        /// </summary>
        /// <param name="edge"></param>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static List<FlatValueTopoEdge> FullAdjacency(FlatValueTopoEdge edge, List<FlatValueTopoEdge> graph)
        {
            return new List<FlatValueTopoEdge>()
            {
                graph.FirstOrDefault(x => x.SectionID == edge.LowNormalSectionID),
                graph.FirstOrDefault(x => x.SectionID == edge.LowReverseSectionID),
                graph.FirstOrDefault(x => x.SectionID == edge.HighNormalSectionID),
                graph.FirstOrDefault(x => x.SectionID == edge.HighReverseSectionID)
            };
        }
        
        
       	static List<FlatValueTopoEdge> loadTDMSMap(string SqlConnection) 
        {
       		//SECTION_ID,LOW_NORMAL_SECTION_ID,LOW_REVERSE_SECTION_ID,HIGH_NORMAL_SECTION_ID,HIGH_REVERSE_SECTION_ID,NAMED_TRACK_TYPE,AUTHORITY_TERRITORY_TYPE,MISC_AUTHORITY_TERRITORY_TYPE,DISTRICT_ID,DISTRICT_NAME,DIVISION_ID,DIVISION_NAME,DISPATCH_TERRITORY_ID,DISPATCH_TERRITORY_NAME,STATION_ID,STATION_NAME,STATION_IDENTIFIER
			var dt = TDMSDataGenerationUtility.populateFBABaseNetworkDataFromTDMS("", SqlConnection);
			return dt.AsEnumerable().Select(x => new FlatValueTopoEdge()
			{
             	SectionID = x[0].ToString(),
             	LowNormalSectionID = x[1].ToString(),
			    LowReverseSectionID = x[2].ToString(),
			    HighNormalSectionID = x[3].ToString(),
			    HighReverseSectionID = x[4].ToString(),
			
			    NamedTrackType = x[5].ToString(),
			    AuthorityTerritoryType = x[6].ToString(),
			    MiscAuthorityTerritoryType = x[7].ToString(),
			
			    DistrictID = x[8].ToString(),
			    DistrictName = x[9].ToString(),
			    DivisionID = x[10].ToString(),
			    DivisionName = x[11].ToString(),
			    DispatchTerritoryID = x[12].ToString(),
			    DispatchTerritoryName = x[13].ToString(),
			
			    StationID = x[14].ToString(),
			    StationName = x[15].ToString(),
			    StationOpsta = x[16].ToString(),
			    NamedTrackName = x[17].ToString()
            }).ToList();
        }
    }
    
    public class FlatValueTopoEdge
    {
        public string SectionID { get; set; }
        public string LowNormalSectionID { get; set; }
        public string LowReverseSectionID { get; set; }
        public string HighNormalSectionID { get; set; }
        public string HighReverseSectionID { get; set; }

        public string NamedTrackType { get; set; }
        public string AuthorityTerritoryType { get; set; }
        public string MiscAuthorityTerritoryType { get; set; }

        public string DistrictID { get; set; }
        public string DistrictName { get; set; }
        public string DivisionID { get; set; }
        public string DivisionName { get; set; }
        public string DispatchTerritoryID { get; set; }
        public string DispatchTerritoryName { get; set; }

        public string StationID { get; set; }
        public string StationName { get; set; }
        public string StationOpsta { get; set; }

        public string NamedTrackName { get; set; }
        
        public FlatValueTopoEdge()
        {
        }

    }
    
}
