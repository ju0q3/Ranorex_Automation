/*
 * Created by Ranorex
 * User: 210058208
 * Date: 10/5/2018
 * Time: 10:22 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Collections.Specialized;
using WinForms = System.Windows.Forms;
using System.Xml;
using System.Runtime.Serialization;
using System.IO;
using System.Linq;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace Oracle.Code_Utils
{

    [DataContract(Namespace="")]
    public class DispatchRouteEnrichmentMap
    {
        // You can use the "Insert New User Code Method" functionality from the context menu,
        // to add a new method with the attribute [UserCodeMethod].
        [DataMember]
        public List<DispatchRoute> RouteMap { get; set; }

        //public Dictionary<String, Tuple<String, String>> RouteMap { get; private set; }

        public DispatchRouteEnrichmentMap()
        {
            RouteMap = new List<DispatchRoute>();
        }

        //reflective xml deserialize
        public static DispatchRouteEnrichmentMap GetFromFile(string filename)
        {
            DispatchRouteEnrichmentMap readout = null;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas()))
                {
                    DataContractSerializer ser = new DataContractSerializer(typeof(DispatchRouteEnrichmentMap));
                    readout = (DispatchRouteEnrichmentMap)ser.ReadObject(reader, true);
                }
            }

            return readout;
        }
    }

    [DataContract(Namespace="")]
    public class DispatchRoute
    {
        [DataMember]
        public string Territory { get; set; }
        [DataMember]
        public Route TerritoryRoute { get; set; }

    }

    [DataContract(Namespace="")]
    public class Route
    {
        [DataMember]
        public string StartOPTSA { get; set; }
        [DataMember]
        public string EndOPSTA { get; set; }

        public Route(string start, string end)
        {
            StartOPTSA = start; EndOPSTA = end;
        }
    }
    
}
