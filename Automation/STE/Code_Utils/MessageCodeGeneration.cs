/*
 * Created by Ranorex
 * User: r07000021
 * Date: 6/18/2019
 * Time: 10:44 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.IO;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace STE.Code_Utils
{
	public static class Tabber
    {
        private static string tabs = "\t";
        public static void SetTabs(int startingTabs)
        {
            tabs = "";
            Increment(startingTabs);
        }

        public static string Get()
        {
            return tabs;
        }

        public static string Increment(int numberToIncrease = 1)
        {
            for (int i = 0; i < numberToIncrease; i++)
            {
                tabs = tabs + "\t";
            }
            return tabs;
        }

        public static string Decrement(int numberToDecrease = 1)
        {
            for (int i = 0; i < numberToDecrease; i++)
            {
                tabs = tabs.Substring(0, (tabs.Length - numberToDecrease));
            }
            return tabs;
        }
    }
	
	
	
	public class MessageObject
    {
	    public class MessageLineObject : MessageObject
        {
            public string fieldName;
            public string parentField;
            public string fieldUnits;
            public string minFieldSize;
            public string maxFieldSize;
            public string fieldRange;
            public string mandatory;
            public string numberOfFields;
            public string optionalDescription;
            public new Dictionary<string, MessageLineObject> subObjects = new Dictionary<string, MessageLineObject>();
            
            public new bool addValueToDictionary(MessageLineObject objectToAdd)
            {
                if (fieldName == objectToAdd.parentField)
                {
                    string dictKey = objectToAdd.fieldName;
                    if (char.IsDigit(dictKey[0]))
                    {
                        dictKey = "N" + dictKey;
                    }
                    objectToAdd.myKey = dictKey;
                    subObjects.Add(dictKey, objectToAdd);
                    return true;
                }
    
                foreach (string key in subObjects.Keys)
                {
                    if (subObjects[key].addValueToDictionary(objectToAdd))
                    {
                        return true;
                    }
                }
    
                return false;
            }
        }
	    
	    public string myKey;
        public string messageNamePrefix;
        public string messageNameRoot;
        public string messageName;
        public string version;
        public string messageType;
        public string customer = "";
        public string direction;
        public string steName;
        public string stringTypeMessageVersion;
        public string stringTypeMessage;
        public string stringMessageVersion;
        public string stringPrefixMessageName;
        public int isFromPDS = 0;
        public Dictionary<string, MessageLineObject> subObjects = new Dictionary<string, MessageLineObject>();

        public bool createNewObject(string fieldName, string parentField, string fieldUnits, string minFieldSize, string maxFieldSize, string fieldRange, string mandatory, string numberOfFields, string optionalDescription)
        {
            MessageLineObject newObject = new MessageLineObject();
            newObject.fieldName = fieldName;
            newObject.parentField = parentField;
            newObject.fieldUnits = fieldUnits;
            newObject.minFieldSize = minFieldSize;
            newObject.maxFieldSize = maxFieldSize;
            newObject.fieldRange = fieldRange;
            newObject.mandatory = mandatory;
            newObject.numberOfFields = numberOfFields;
            newObject.optionalDescription = optionalDescription;
            
            newObject.messageNamePrefix = messageNamePrefix;
            newObject.messageNameRoot = messageNameRoot;
            newObject.messageName = messageName;
            newObject.version = version;
            newObject.messageType = messageType;
            newObject.customer = customer;
            newObject.direction = direction;
            newObject.steName = steName;
            newObject.stringTypeMessageVersion = stringTypeMessageVersion;
            newObject.stringTypeMessage = stringTypeMessage;
            newObject.stringMessageVersion = stringMessageVersion;
            newObject.stringPrefixMessageName = stringPrefixMessageName;
            newObject.isFromPDS = isFromPDS;
            return addValueToDictionary(newObject);
        }
        
        public bool addValueToDictionary(MessageLineObject objectToAdd)
        {
            if (messageName == objectToAdd.parentField)
            {
                string dictKey = objectToAdd.fieldName;
                if (char.IsDigit(dictKey[0]))
                {
                    dictKey = "N" + dictKey;
                }
                objectToAdd.myKey = dictKey;
                subObjects.Add(dictKey, objectToAdd);
                return true;
            }

            foreach (string key in subObjects.Keys)
            {
                if (subObjects[key].addValueToDictionary(objectToAdd))
                {
                    return true;
                }
            }

            return false;
        }
    }
	
	
    /// <summary>
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class MessageCodeGeneration
    {
        //Vars for messageTypes for how to build the file
        public static List<string> fromPDS = new List<string> { "DC", "DG", "DR", "MQ", "WLIS" };
        public static List<string> toPDS = new List<string> { "CD", "GD", "RD" };
    
        public static Dictionary<string, MessageObject> messages = new Dictionary<string, MessageObject>();

        static void ProcessDirectory(string targetDirectory)
        {
        	// Process the list of files found in the directory.
        	string [] fileEntries = Directory.GetFiles(targetDirectory);
        	foreach(string fileName in fileEntries)
        	{
        		Ranorex.Report.Info("Filename: " + fileName + "\n");
        		if (fileName.EndsWith(".csv")) {
            		ProcessFile(fileName);
        		}
       		}

        	// Recurse into subdirectories of this directory.
        	string [] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        	foreach(string subdirectory in subdirectoryEntries)
        	{
        		Ranorex.Report.Info("Subdirectory: " + subdirectory + "\n");
            	ProcessDirectory(subdirectory);
        	}
        }
        
        public static void ProcessFile(string path) 
	    {
	        using (var reader = new StreamReader(path))
	        {
	         	reader.ReadLine();
	            while (!reader.EndOfStream)
	            {
	            	var line = reader.ReadLine();
	                var values = line.Split(',');
	
	                string primaryKey = values[0] + values[1];
	                if (values[12] != "")
	                {
	                	primaryKey = values[12] + "_" + primaryKey;
	                }
	                if (!messages.ContainsKey(primaryKey))
	                {
	                	MessageObject newMessage = new MessageObject();
	                    newMessage.messageName = values[0];
	                    newMessage.version = values[1];
	                    newMessage.messageType = values[11];
	                    newMessage.customer = values[12];
	                    newMessage.direction = values[13];
	                    newMessage.steName = values[14];
	                    if (newMessage.messageType == "PTC" || newMessage.messageType == "RUM" || newMessage.messageType == "GPS")
	                    {
	                        if (newMessage.messageType != "GPS")
	                        {
    	                        newMessage.messageNamePrefix = newMessage.messageName.Substring(0, 2); 
                		        newMessage.messageNameRoot = newMessage.messageName.Substring(3);
	                            newMessage.stringPrefixMessageName = newMessage.messageNamePrefix + "_" + newMessage.messageNameRoot;
	                        } else {
	                            newMessage.stringPrefixMessageName = newMessage.messageName;
	                        }
	                        newMessage.stringTypeMessage = newMessage.messageType + "_" + newMessage.stringPrefixMessageName;
	                        newMessage.stringMessageVersion = (newMessage.customer == "" ? "" : newMessage.customer + "_") + newMessage.stringPrefixMessageName + "_" + newMessage.version;
	                        newMessage.stringTypeMessageVersion = newMessage.messageType + "_" + newMessage.stringMessageVersion;
	                        if (fromPDS.Contains(newMessage.messageNamePrefix))
        	                {
        	                    newMessage.isFromPDS = 1;
        	                }
	                    } else {
	                        newMessage.messageNamePrefix = newMessage.customer;
	                        newMessage.messageNameRoot = newMessage.messageName;
	                        newMessage.stringPrefixMessageName = newMessage.customer + "_" + newMessage.messageName;
	                        newMessage.stringTypeMessage = newMessage.messageType + "_" + newMessage.stringPrefixMessageName;
	                        newMessage.stringMessageVersion = newMessage.stringPrefixMessageName + "_" + newMessage.version;
	                        newMessage.stringTypeMessageVersion = newMessage.messageType + "_" + newMessage.stringMessageVersion;
	                        if (newMessage.direction == "From")
                        	{
                        		newMessage.isFromPDS = 1;
                        	} else if (newMessage.direction == "Both")
                        	{
                        		newMessage.isFromPDS = 2;
                        	}
	                    }
	                    messages.Add(primaryKey, newMessage);
	                }
	                messages[primaryKey].createNewObject(values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9], values[10]);
	            }
	        }

			return;	        
	    }
        
        [UserCodeMethod]
        public static void GenerateMessagesFromCSV()
        {
        	if (File.Exists(@"..\..\..\STE\data\message_templates\MessageDefinitions.txt"))
            {
                File.Delete(@"..\..\..\STE\data\message_templates\MessageDefinitions.txt");
            }
        	
            //Put all csv values from csv into a recursive object dictionary
            ProcessDirectory(@"..\..\..\STE\data\message_templates");
	            
            //Build the individual message files
            foreach (string key in messages.Keys)
            {
                MessageObject messageObject = messages[key]; 
                
                using (var writer = new StreamWriter(@"..\..\..\STE\data\message_templates\" + messageObject.stringTypeMessageVersion + ".cs"))
	            {
                	if (messageObject.isFromPDS == 0)
                	{
                		writer.Write(ToPDSCodeIncludesString());
                		writer.Write("namespace STE.Code_Utils.messages."+(messageObject.messageType == "GPS" ? "PTC" : messageObject.messageType)+(messageObject.customer != "" ? "."+messageObject.customer : "")+"\n{\n");
		
		                writer.Write(MainMessageClassString(messageObject, messageObject.isFromPDS));
		
		                foreach (string rootMessagekey in messageObject.subObjects.Keys)
		                {
		                    writer.Write(BuildBaseVariableClassesString(messageObject.subObjects[rootMessagekey]));
		                }
		
		                writer.Write(BuildMainSerializationClassesString(messageObject));
		
		                foreach (string rootMessagekey in messageObject.subObjects.Keys)
		                {
		                    writer.Write(BuildSubSerializationClassesString(messageObject.subObjects[rootMessagekey]));
		                }
		
		                writer.Write("}");
                	} else if (messageObject.isFromPDS == 1)
                	{
                		writer.Write(FromPDSCodeIncludesString());
		                writer.Write("namespace STE.Code_Utils.messages."+(messageObject.messageType == "GPS" ? "PTC" : messageObject.messageType)+(messageObject.customer != "" ? "."+messageObject.customer : "")+"\n{\n");
		
		                writer.Write(MainMessageClassString(messageObject, messageObject.isFromPDS));
		
		                foreach (string rootMessagekey in messageObject.subObjects.Keys)
		                {
		                    writer.Write(BuildBaseVariableClassesString(messageObject.subObjects[rootMessagekey]));
		                }
		
		                writer.Write(BuildMainSerializationClassesString(messageObject));
		
		                foreach (string rootMessagekey in messageObject.subObjects.Keys)
		                {
		                    writer.Write(BuildSubSerializationClassesString(messageObject.subObjects[rootMessagekey]));
		                }
		
		                writer.Write("}");
                	} else {
                		writer.Write(ToFromPDSCodeIncludesString());
		                writer.Write("namespace STE.Code_Utils.messages."+(messageObject.messageType == "GPS" ? "PTC" : messageObject.messageType)+(messageObject.customer != "" ? "."+messageObject.customer : "")+"\n{\n");
		
		                writer.Write(MainMessageClassString(messageObject, messageObject.isFromPDS));
		
		                foreach (string rootMessagekey in messageObject.subObjects.Keys)
		                {
		                    writer.Write(BuildBaseVariableClassesString(messageObject.subObjects[rootMessagekey]));
		                }
		
		                writer.Write(BuildMainSerializationClassesString(messageObject));
		
		                foreach (string rootMessagekey in messageObject.subObjects.Keys)
		                {
		                    writer.Write(BuildSubSerializationClassesString(messageObject.subObjects[rootMessagekey]));
		                }
		
		                writer.Write("}");
                	}
	            }
                
            }
        }

        private static string MainMessageClassString(MessageObject messageObject, int isFromPDS)
        {
            string stringBuilder = "";
            stringBuilder = Tabber.Get() + "public partial class " + messageObject.stringTypeMessageVersion + " {\n";

            Tabber.Increment();
            
            foreach (string key in messageObject.subObjects.Keys)
            {
                stringBuilder = stringBuilder + Tabber.Get() + "public " + messageObject.stringTypeMessage + key + "_" + messageObject.version + " " + key + ";\n";
            }
            if (isFromPDS == 1)
            {
                stringBuilder = stringBuilder + "\n" + Tabber.Get() + "public static " + messageObject.stringTypeMessageVersion + " fromSerializableObject(" + messageObject.stringMessageVersion + " message) {\n" +
                    Tabber.Increment() + messageObject.stringTypeMessageVersion + " " + messageObject.stringMessageVersion.ToLower() + " = new " + messageObject.stringTypeMessageVersion + "();\n";

                foreach (string key in messageObject.subObjects.Keys)
                {
                    stringBuilder = stringBuilder + Tabber.Get() + messageObject.stringPrefixMessageName + key + "_" + messageObject.version + " " + key.ToLower() + " = null;\n";
                }

                int i = 0;
                foreach (string key in messageObject.subObjects.Keys)
                {
                    stringBuilder = stringBuilder + Tabber.Get() + key.ToLower() + " = (" + messageObject.stringPrefixMessageName + key + "_" + messageObject.version + ") message.Items[" + i.ToString() + "];\n";
                    i++;
                }


                foreach (string key in messageObject.subObjects.Keys)
                {
                    stringBuilder = stringBuilder + "\n" + Tabber.Get() + "if (" + key.ToLower() + " != null) {\n" +
                        Tabber.Increment() + messageObject.stringTypeMessage + key + "_" + messageObject.version + " message" + key.ToLower() + " = new " + messageObject.stringTypeMessage + key + "_" + messageObject.version + "();\n";
                    stringBuilder = stringBuilder + BuildMessageValidations(messageObject.subObjects[key], key, "message" + messageObject.subObjects[key].parentField.ToLower()) + "\n" + 
                        Tabber.Get() + (messageObject.stringMessageVersion).ToLower() + "." + key + " = " + "message" + key.ToLower() + ";\n\n" + 
                        Tabber.Decrement() + "} else {\n" +
                        Tabber.Increment() + "Ranorex.Report.Failure(\"Field " + key + " is a Mandatory field but was found to be missing from the message\");\n" +
                        Tabber.Decrement() + "}\n";
                }

                stringBuilder = stringBuilder + Tabber.Get() + "return " + (messageObject.stringMessageVersion).ToLower() + ";\n" +
                    Tabber.Decrement() + "}\n\n" +
                    Tabber.Get() + "public static bool IsDigitsOnly(string messageField){\n" +
                    Tabber.Increment() + "int output;\n" +
                    Tabber.Get() + "return int.TryParse(messageField, out output);\n" +
                    Tabber.Decrement() + "}\n\n" +
                    Tabber.Get() + "public static bool ContainsDigits(string messageField) {\n" +
                    Tabber.Increment() + "foreach (char c in messageField) {\n" +
                    Tabber.Increment() + "if (char.IsDigit(c)) {\n" +
                    Tabber.Increment() + "return true;\n" +
                    Tabber.Decrement() + "}\n" +
                    Tabber.Decrement() + "}\n" +
                    Tabber.Get() + "return false;\n" +
                    Tabber.Decrement() + "}\n";

            } else if (isFromPDS == 0)
            {

                stringBuilder = stringBuilder + "\n" + Tabber.Get() + "public static void create" + messageObject.stringMessageVersion + "(";
                string createMessageString = "STE.Code_Utils.messages." + messageObject.messageType + "." + messageObject.stringTypeMessageVersion + ".create" + messageObject.stringMessageVersion + "(";
                Tabber.Increment();
                foreach (string key in messageObject.subObjects.Keys)
                {
                    foreach (string subkey in messageObject.subObjects[key].subObjects.Keys)
                    {
                    	if (subkey == "MESSAGE_ID")
                    	{
                    		continue;
                    	}
                        stringBuilder = stringBuilder + "\n" + Tabber.Get() + "string " + key.ToLower() + "_" + subkey.ToLower() + ",";
                        createMessageString = createMessageString + key.ToLower() + "_" + subkey.ToLower() + ", ";
                    }
                }

                createMessageString = createMessageString + "hostname);\n\n";
                File.AppendAllText(@"..\..\..\STE\data\message_templates\MessageDefinitions.txt", createMessageString);

                stringBuilder = stringBuilder + "\n" + Tabber.Get() + "string hostname\n" +
                    Tabber.Decrement() + ") {\n" +
                    Tabber.Increment() + "string temp = System.Environment.GetEnvironmentVariable(\"TEMP\");\n" +
                    Tabber.Get() + "XmlSerializer serializer;\n" +
                    Tabber.Get() + "FileStream fs;\n\n" +
                    Tabber.Get() + messageObject.stringTypeMessageVersion + " " + messageObject.stringTypeMessage.ToLower() + " = build" + messageObject.stringTypeMessageVersion + "(";

                List<string> stringListToJoin = new List<string>();
                foreach (string key in messageObject.subObjects.Keys)
                {
                    foreach (string subkey in messageObject.subObjects[key].subObjects.Keys)
                    {
                    	if (subkey == "MESSAGE_ID")
                    	{
                    		continue;
                    	}
                        stringListToJoin.Add(key.ToLower() + "_" + subkey.ToLower());
                    }
                }
                stringBuilder = stringBuilder + string.Join(", ", stringListToJoin) + ");\n\n" +
                    Tabber.Get() + messageObject.stringMessageVersion + " " + messageObject.stringPrefixMessageName.ToLower() + " = " + messageObject.stringTypeMessage.ToLower() + ".toSerializableObject();\n" +
                    Tabber.Get() + "fs = File.Create(temp+\"/temp.request\");\n" +
                    Tabber.Get() + "serializer = new XmlSerializer(typeof(" + messageObject.stringMessageVersion + "));\n" +
                    Tabber.Get() + "var writer = new SteXmlTextWriter(fs);\n" +
                    Tabber.Get() + "serializer.Serialize(writer, " + messageObject.stringPrefixMessageName.ToLower() + ");\n" +
                    Tabber.Get() + "fs.Close();\n\n" +
                    Tabber.Get() + "if (hostname == \"\" || hostname == \"Local\") {\n" +
                    Tabber.Increment() + "string request = File.ReadAllText(temp+\"/temp.request\");\n" +
                    Tabber.Get() + "request = " + messageObject.stringTypeMessage.ToLower() + ".toSteMessageHeader(request, false);\n" +
                    Tabber.Get() + "System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);\n" +
                    Tabber.Decrement() + "} else {\n" +
                    Tabber.Increment() + "string request = File.ReadAllText(temp+\"/temp.request\");\n" +
                    Tabber.Get() + "request = " + messageObject.stringTypeMessage.ToLower() + ".toSteMessageHeader(request, true);\n" +
                    Tabber.Get() + "int receiver_port = 2500;\n" +
                    Tabber.Get() + "using(TcpClient tcp = new TcpClient(hostname, receiver_port)) {\n" +
                    Tabber.Increment() + "NetworkStream nw = tcp.GetStream();\n" +
                    Tabber.Get() + "nw.ReadTimeout = 5000; //5 second timeout for read response\n" +
                    Tabber.Get() + "Ranorex.Report.Info(String.Format(\"Encoding Message {0} for STE {1}:2500\", request, hostname));\n" +
                    Tabber.Get() + "Byte[] data = System.Text.Encoding.ASCII.GetBytes(request);\n" +
                    Tabber.Get() + "//log to record we are sending exec\n" +
                    Tabber.Get() + "nw.Write(data, 0, data.Length);\n" +
                    Tabber.Get() + "Thread.Sleep(5);\n" +
                    Tabber.Get() + "nw.Close();\n" +
                    Tabber.Decrement() + "}\n" +
                    Tabber.Decrement() + "}\n" +
                    Tabber.Decrement() + "}\n";

                stringBuilder = stringBuilder + "\n" + Tabber.Get() + "public static " + messageObject.stringTypeMessageVersion + " build" + messageObject.stringTypeMessageVersion + "(\n";
                Tabber.Increment();
                stringListToJoin = new List<string>();
                foreach (string key in messageObject.subObjects.Keys)
                {
                    foreach (string subkey in messageObject.subObjects[key].subObjects.Keys)
                    {
                    	if (subkey == "MESSAGE_ID")
                    	{
                    		continue;
                    	}
                        stringListToJoin.Add(Tabber.Get() + "string " + key.ToLower() + "_" + subkey.ToLower());
                    }
                }
                stringBuilder = stringBuilder + string.Join(",\n", stringListToJoin) + "\n" +
                    Tabber.Decrement() + ") {\n\n" +
                    Tabber.Increment() + messageObject.stringTypeMessageVersion + " " + messageObject.stringTypeMessage.ToLower() + " = new " + messageObject.stringTypeMessageVersion + "();\n\n";

                foreach (string key in messageObject.subObjects.Keys)
                {
                    stringBuilder = stringBuilder + Tabber.Get() + messageObject.stringTypeMessage + key + "_" + messageObject.version + " " + key.ToLower() + " = new " + messageObject.stringTypeMessage + key + "_" + messageObject.version + "();\n" +
                        BuildMessageBuilder(messageObject.subObjects[key], key) + "\n";
                }

                foreach (string key in messageObject.subObjects.Keys)
                {
                    stringBuilder = stringBuilder + Tabber.Get() + messageObject.stringTypeMessage.ToLower() + "." + key + " = " + key.ToLower() + ";\n";
                }

                stringBuilder = stringBuilder + Tabber.Get() + "return " + messageObject.stringTypeMessage.ToLower() + ";\n" +
                    Tabber.Decrement() + "}\n\n" +
                    Tabber.Get() + "public " + messageObject.stringMessageVersion + " toSerializableObject() {\n" +
                    Tabber.Increment() + messageObject.stringMessageVersion + " " + messageObject.stringPrefixMessageName.ToLower() + "_" + messageObject.version.ToLower() + " = new " + messageObject.stringMessageVersion + "();\n" +
                    Tabber.Get() + messageObject.stringPrefixMessageName.ToLower() + "_" + messageObject.version.ToLower() + ".Items = new object[" + messageObject.subObjects.Keys.Count.ToString() + "];\n\n";

                foreach (string key in messageObject.subObjects.Keys)
                {
                    stringBuilder = stringBuilder + Tabber.Get() + messageObject.stringPrefixMessageName + key + "_" + messageObject.version + " " + key.ToLower() + " = new " + messageObject.stringPrefixMessageName + key + "_" + messageObject.version + "();\n" +
                        Tabber.Get() + "if (this." + key + " != null) {\n";
                    Tabber.Increment();
                    stringBuilder = stringBuilder + ToSerializableBuilder(messageObject.subObjects[key], key) +
                        Tabber.Decrement() + "}\n\n";

                }

                int i = 0;
                foreach (string key in messageObject.subObjects.Keys)
                {
                    stringBuilder = stringBuilder + Tabber.Get() + messageObject.stringPrefixMessageName.ToLower() + "_" + messageObject.version.ToLower() + ".Items[" + i.ToString() + "] = " + key.ToLower() + ";\n";
                    i++;
                }

                stringBuilder = stringBuilder + Tabber.Get() + "return " + messageObject.stringPrefixMessageName.ToLower() + "_" + messageObject.version.ToLower() + ";\n" +
                    Tabber.Decrement() + "}\n\n" +
                    Tabber.Get() + "public string toSteMessageHeader(string serializedXml, bool remote = false) {\n";
                Tabber.Increment();
                foreach (string key in messageObject.subObjects.Keys)
                {
                    bool misHeader = false;
                    if (key == "HEADER" && messageObject.messageType == "MIS")
                    {
                        misHeader = true;
                    }
                        
                    stringBuilder = stringBuilder + Tabber.Get() + (misHeader ? "//":"") + "int " + key.ToLower() + "From = serializedXml.IndexOf(\"<" + key + ">\") + \"<" + key + ">\".Length;\n" +
                        Tabber.Get() + (misHeader ? "//":"") + "int " + key.ToLower() + "To = serializedXml.LastIndexOf(\"</" + key + ">\");\n";
                }
                
                string prescriptDivider = (messageObject.messageType == "PTC" || messageObject.messageType == "GPS" || messageObject.messageType == "RUM" ? "|":",");

                stringBuilder = stringBuilder + "\n" + Tabber.Get() + "string preScript = \"\";\n" +
                    Tabber.Get() + "if (!remote) {\n" +
                	Tabber.Increment() + "preScript = \"PASSTHRU" + (messageObject.messageType == "PTC" || messageObject.messageType == "GPS" || messageObject.messageType == "RUM" ? "OTC":"") + prescriptDivider + (messageObject.steName == "" ? messageObject.messageName : messageObject.steName) + prescriptDivider + "\";\n" +
                    Tabber.Decrement() + "} else {\n" +
                    Tabber.Increment() + "preScript = \"RanorexAgent:PASSTHRU" + (messageObject.messageType == "PTC" || messageObject.messageType == "GPS" || messageObject.messageType == "RUM" ? "OTC":"") + prescriptDivider + (messageObject.steName == "" ? messageObject.messageName : messageObject.steName) + prescriptDivider + "\";\n" +
                    Tabber.Decrement() + "}\n\n" +
                    Tabber.Get() + "string result = preScript + ";

                stringListToJoin = new List<string>();
                foreach (string key in messageObject.subObjects.Keys)
                {
                    stringListToJoin.Add("serializedXml.Substring(" + key.ToLower() + "From, " + key.ToLower() + "To-" + key.ToLower() + "From)");
                }
                
                for (int j = 0; j < stringListToJoin.Count; j++)
                {
                    bool misHeader = false;
                    if (stringListToJoin[j].Contains("header") && messageObject.messageType == "MIS")
                    {
                        misHeader = true;
                    }
                    if (j == stringListToJoin.Count - 1)
                    {
                        stringBuilder = stringBuilder + stringListToJoin[j] + ";\n";
                    } else {
                        stringBuilder = stringBuilder + (misHeader ? "/*": "") + stringListToJoin[j] + " + " + (misHeader ? "*/": "");
                    }
                }
                stringBuilder = stringBuilder + Tabber.Get() + "return result;\n" +
                Tabber.Decrement() + "}\n";
            } else if (isFromPDS == 2)
            {
            	stringBuilder = stringBuilder + "\n" + Tabber.Get() + "public static " + messageObject.stringTypeMessageVersion + " fromSerializableObject(" + messageObject.stringMessageVersion + " message) {\n" +
                    Tabber.Increment() + messageObject.stringTypeMessageVersion + " " + (messageObject.stringMessageVersion).ToLower() + " = new " + messageObject.stringTypeMessageVersion + "();\n";

                foreach (string key in messageObject.subObjects.Keys)
                {
                    stringBuilder = stringBuilder + Tabber.Get() + messageObject.stringPrefixMessageName + key + "_" + messageObject.version + " " + key.ToLower() + " = null;\n";
                }

                int i = 0;
                foreach (string key in messageObject.subObjects.Keys)
                {
                    stringBuilder = stringBuilder + Tabber.Get() + key.ToLower() + " = (" + messageObject.stringPrefixMessageName + key + "_" + messageObject.version + ") message.Items[" + i.ToString() + "];\n";
                    i++;
                }


                foreach (string key in messageObject.subObjects.Keys)
                {
                    stringBuilder = stringBuilder + "\n" + Tabber.Get() + "if (" + key.ToLower() + " != null) {\n" +
                        Tabber.Increment() + messageObject.stringTypeMessage + key + "_" + messageObject.version + " message" + key.ToLower() + " = new " + messageObject.stringTypeMessage + key + "_" + messageObject.version + "();\n";
                    stringBuilder = stringBuilder + BuildMessageValidations(messageObject.subObjects[key], key, "message" + messageObject.subObjects[key].fieldName.ToLower()) + "\n" + 
                        Tabber.Get() + (messageObject.stringMessageVersion).ToLower() + "." + key + " = " + "message" + key.ToLower() + ";\n\n" + 
                        Tabber.Decrement() + "} else {\n" +
                        Tabber.Increment() + "Ranorex.Report.Failure(\"Field " + key + " is a Mandatory field but was found to be missing from the message\");\n" +
                        Tabber.Decrement() + "}\n";
                }

                stringBuilder = stringBuilder + Tabber.Get() + "return " + (messageObject.stringMessageVersion).ToLower() + ";\n" +
                    Tabber.Decrement() + "}\n\n" +
                    Tabber.Get() + "public static bool IsDigitsOnly(string messageField){\n" +
                    Tabber.Increment() + "int output;\n" +
                    Tabber.Get() + "return int.TryParse(messageField, out output);\n" +
                    Tabber.Decrement() + "}\n\n" +
                    Tabber.Get() + "public static bool ContainsDigits(string messageField) {\n" +
                    Tabber.Increment() + "foreach (char c in messageField) {\n" +
                    Tabber.Increment() + "if (char.IsDigit(c)) {\n" +
                    Tabber.Increment() + "return true;\n" +
                    Tabber.Decrement() + "}\n" +
                    Tabber.Decrement() + "}\n" +
                    Tabber.Get() + "return false;\n" +
                    Tabber.Decrement() + "}\n";
            	
            	stringBuilder = stringBuilder + "\n" + Tabber.Get() + "public static void create" + messageObject.stringMessageVersion + "(";
                string createMessageString = "STE.Code_Utils.messages." + messageObject.messageType + "." + messageObject.stringTypeMessageVersion + ".create" + messageObject.stringMessageVersion + "(";
                Tabber.Increment();
                foreach (string key in messageObject.subObjects.Keys)
                {
                    foreach (string subkey in messageObject.subObjects[key].subObjects.Keys)
                    {
                    	if (subkey == "MESSAGE_ID")
                    	{
                    		continue;
                    	}
                        stringBuilder = stringBuilder + "\n" + Tabber.Get() + "string " + key.ToLower() + "_" + subkey.ToLower() + ",";
                        createMessageString = createMessageString + key.ToLower() + "_" + subkey.ToLower() + ", ";
                    }
                }

                createMessageString = createMessageString + "hostname);\n\n";
                File.AppendAllText(@"..\..\..\STE\data\message_templates\MessageDefinitions.txt", createMessageString);

                stringBuilder = stringBuilder + "\n" + Tabber.Get() + "string hostname\n" +
                    Tabber.Decrement() + ") {\n" +
                    Tabber.Increment() + "string temp = System.Environment.GetEnvironmentVariable(\"TEMP\");\n" +
                    Tabber.Get() + "XmlSerializer serializer;\n" +
                    Tabber.Get() + "FileStream fs;\n\n" +
                    Tabber.Get() + messageObject.stringTypeMessageVersion + " " + messageObject.stringTypeMessage.ToLower() + " = build" + messageObject.stringTypeMessageVersion + "(";

                List<string> stringListToJoin = new List<string>();
                foreach (string key in messageObject.subObjects.Keys)
                {
                    foreach (string subkey in messageObject.subObjects[key].subObjects.Keys)
                    {
                    	if (subkey == "MESSAGE_ID")
                    	{
                    		continue;
                    	}
                        stringListToJoin.Add(key.ToLower() + "_" + subkey.ToLower());
                    }
                }
                stringBuilder = stringBuilder + string.Join(", ", stringListToJoin) + ");\n\n" +
                    Tabber.Get() + messageObject.stringMessageVersion + " " + messageObject.stringPrefixMessageName.ToLower() + " = " + messageObject.stringTypeMessage.ToLower() + ".toSerializableObject();\n" +
                    Tabber.Get() + "fs = File.Create(temp+\"/temp.request\");\n" +
                    Tabber.Get() + "serializer = new XmlSerializer(typeof(" + messageObject.stringMessageVersion + "));\n" +
                    Tabber.Get() + "var writer = new SteXmlTextWriter(fs);\n" +
                    Tabber.Get() + "serializer.Serialize(writer, " + messageObject.stringPrefixMessageName.ToLower() + ");\n" +
                    Tabber.Get() + "fs.Close();\n\n" +
                    Tabber.Get() + "if (hostname == \"\" || hostname == \"Local\") {\n" +
                    Tabber.Increment() + "string request = File.ReadAllText(temp+\"/temp.request\");\n" +
                    Tabber.Get() + "request = " + messageObject.stringTypeMessage.ToLower() + ".toSteMessageHeader(request, false);\n" +
                    Tabber.Get() + "System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);\n" +
                    Tabber.Decrement() + "} else {\n" +
                    Tabber.Increment() + "string request = File.ReadAllText(temp+\"/temp.request\");\n" +
                    Tabber.Get() + "request = " + messageObject.stringTypeMessage.ToLower() + ".toSteMessageHeader(request, true);\n" +
                    Tabber.Get() + "int receiver_port = 2500;\n" +
                    Tabber.Get() + "using(TcpClient tcp = new TcpClient(hostname, receiver_port)) {\n" +
                    Tabber.Increment() + "NetworkStream nw = tcp.GetStream();\n" +
                    Tabber.Get() + "nw.ReadTimeout = 5000; //5 second timeout for read response\n" +
                    Tabber.Get() + "Ranorex.Report.Info(String.Format(\"Encoding Message {0} for STE {1}:2500\", request, hostname));\n" +
                    Tabber.Get() + "Byte[] data = System.Text.Encoding.ASCII.GetBytes(request);\n" +
                    Tabber.Get() + "//log to record we are sending exec\n" +
                    Tabber.Get() + "nw.Write(data, 0, data.Length);\n" +
                    Tabber.Get() + "Thread.Sleep(5);\n" +
                    Tabber.Get() + "nw.Close();\n" +
                    Tabber.Decrement() + "}\n" +
                    Tabber.Decrement() + "}\n" +
                    Tabber.Decrement() + "}\n";

                stringBuilder = stringBuilder + "\n" + Tabber.Get() + "public static " + messageObject.stringTypeMessageVersion + " build" + messageObject.stringTypeMessageVersion + "(\n";
                Tabber.Increment();
                stringListToJoin = new List<string>();
                foreach (string key in messageObject.subObjects.Keys)
                {
                    foreach (string subkey in messageObject.subObjects[key].subObjects.Keys)
                    {
                    	if (subkey == "MESSAGE_ID")
                    	{
                    		continue;
                    	}
                        stringListToJoin.Add(Tabber.Get() + "string " + key.ToLower() + "_" + subkey.ToLower());
                    }
                }
                stringBuilder = stringBuilder + string.Join(",\n", stringListToJoin) + "\n" +
                    Tabber.Decrement() + ") {\n\n" +
                    Tabber.Increment() + messageObject.stringTypeMessageVersion + " " + messageObject.stringTypeMessage.ToLower() + " = new " + messageObject.stringTypeMessageVersion + "();\n\n";

                foreach (string key in messageObject.subObjects.Keys)
                {
                    stringBuilder = stringBuilder + Tabber.Get() + messageObject.stringTypeMessage + key + "_" + messageObject.version + " " + key.ToLower() + " = new " + messageObject.stringTypeMessage + key + "_" + messageObject.version + "();\n" +
                        BuildMessageBuilder(messageObject.subObjects[key], key) + "\n";
                }

                foreach (string key in messageObject.subObjects.Keys)
                {
                    stringBuilder = stringBuilder + Tabber.Get() + messageObject.stringTypeMessage.ToLower() + "." + key + " = " + key.ToLower() + ";\n";
                }

                stringBuilder = stringBuilder + Tabber.Get() + "return " + messageObject.stringTypeMessage.ToLower() + ";\n" +
                    Tabber.Decrement() + "}\n\n" +
                    Tabber.Get() + "public " + messageObject.stringMessageVersion + " toSerializableObject() {\n" +
                    Tabber.Increment() + messageObject.stringMessageVersion + " " + messageObject.stringPrefixMessageName.ToLower() + "_" + messageObject.version.ToLower() + " = new " + messageObject.stringMessageVersion + "();\n" +
                    Tabber.Get() + messageObject.stringPrefixMessageName.ToLower() + "_" + messageObject.version.ToLower() + ".Items = new object[" + messageObject.subObjects.Keys.Count.ToString() + "];\n\n";

                foreach (string key in messageObject.subObjects.Keys)
                {
                    stringBuilder = stringBuilder + Tabber.Get() + messageObject.stringPrefixMessageName + key + "_" + messageObject.version + " " + key.ToLower() + " = new " + messageObject.stringPrefixMessageName + key + "_" + messageObject.version + "();\n" +
                        Tabber.Get() + "if (this." + key + " != null) {\n";
                    Tabber.Increment();
                    stringBuilder = stringBuilder + ToSerializableBuilder(messageObject.subObjects[key], key) +
                        Tabber.Decrement() + "}\n\n";

                }

                i = 0;
                foreach (string key in messageObject.subObjects.Keys)
                {
                    stringBuilder = stringBuilder + Tabber.Get() + messageObject.stringPrefixMessageName.ToLower() + "_" + messageObject.version.ToLower() + ".Items[" + i.ToString() + "] = " + key.ToLower() + ";\n";
                    i++;
                }

                stringBuilder = stringBuilder + Tabber.Get() + "return " + messageObject.stringPrefixMessageName.ToLower() + "_" + messageObject.version.ToLower() + ";\n" +
                    Tabber.Decrement() + "}\n\n" +
                    Tabber.Get() + "public string toSteMessageHeader(string serializedXml, bool remote = false) {\n";
                Tabber.Increment();
                foreach (string key in messageObject.subObjects.Keys)
                {
                    bool misHeader = false;
                    if (key == "HEADER" && messageObject.messageType == "MIS")
                    {
                        misHeader = true;
                    }
                        
                    stringBuilder = stringBuilder + Tabber.Get() + (misHeader ? "//":"") + "int " + key.ToLower() + "From = serializedXml.IndexOf(\"<" + key + ">\") + \"<" + key + ">\".Length;\n" +
                        Tabber.Get() + (misHeader ? "//":"") + "int " + key.ToLower() + "To = serializedXml.LastIndexOf(\"</" + key + ">\");\n";
                }
                
                string prescriptDivider = (messageObject.messageType == "PTC" || messageObject.messageType == "GPS" || messageObject.messageType == "RUM" ? "|":",");

                stringBuilder = stringBuilder + "\n" + Tabber.Get() + "string preScript = \"\";\n" +
                    Tabber.Get() + "if (!remote) {\n" +
                    Tabber.Increment() + "preScript = \"PASSTHRU" + (messageObject.messageType == "PTC" || messageObject.messageType == "GPS" || messageObject.messageType == "RUM" ? "OTC":"") + prescriptDivider + (messageObject.steName == "" ? messageObject.messageName : messageObject.steName) + prescriptDivider + "\";\n" +
                    Tabber.Decrement() + "} else {\n" +
                    Tabber.Increment() + "preScript = \"RanorexAgent:PASSTHRU" + (messageObject.messageType == "PTC" || messageObject.messageType == "GPS" || messageObject.messageType == "RUM" ? "OTC":"") + prescriptDivider + (messageObject.steName == "" ? messageObject.messageName : messageObject.steName) + prescriptDivider + "\";\n" +
                    Tabber.Decrement() + "}\n\n" +
                    Tabber.Get() + "string result = preScript + ";

                stringListToJoin = new List<string>();
                
                foreach (string key in messageObject.subObjects.Keys)
                {
                    stringListToJoin.Add("serializedXml.Substring(" + key.ToLower() + "From, " + key.ToLower() + "To-" + key.ToLower() + "From)");
                }
                
                for (int j = 0; j < stringListToJoin.Count; j++)
                {
                    bool misHeader = false;
                    if (stringListToJoin[j].Contains("header") && messageObject.messageType == "MIS")
                    {
                        misHeader = true;
                    }
                    if (j == stringListToJoin.Count - 1)
                    {
                        stringBuilder = stringBuilder + stringListToJoin[j] + ";\n";
                    } else {
                        stringBuilder = stringBuilder + (misHeader ? "/*": "") + stringListToJoin[j] + " + " + (misHeader ? "*/": "");
                    }
                }
                stringBuilder = stringBuilder + Tabber.Get() + "return result;\n" +
                Tabber.Decrement() + "}\n";
            }
            stringBuilder = stringBuilder + Tabber.Decrement() + "}\n";
            return stringBuilder;
        }

        private static string ToSerializableBuilder(MessageObject.MessageLineObject messageObject, string baseTag, int iteration = 0)
        {
            string stringBuilder = "";

            foreach (string key in messageObject.subObjects.Keys)
            {
                if (messageObject.subObjects[key].mandatory == "Y")
                {
                	if (messageObject.subObjects[key].numberOfFields != "")
                    {
                        stringBuilder = stringBuilder + Tabber.Get() + "if (" + baseTag + "." + key + ".Count != 0) {\n";
                	} else {
                    	stringBuilder = stringBuilder + Tabber.Get() + "if (" + baseTag + "." + key + " != \"Null\") {\n";
                	}
                } else
                {
                    if (messageObject.subObjects[key].numberOfFields != "")
                    {
                        stringBuilder = stringBuilder + Tabber.Get() + "if (" + baseTag + "." + key + ".Count != 0) {\n";
                    }
                    else
                    {
                        stringBuilder = stringBuilder + Tabber.Get() + "if (" + baseTag + "." + key + " != null && " + baseTag + "." + key + " != \"\") {\n";
                    }
                    
                }

                if (messageObject.subObjects[key].numberOfFields == "")
                {
                    stringBuilder = stringBuilder + Tabber.Increment() + baseTag.ToLower() + "." + key + " = new " + messageObject.stringPrefixMessageName + baseTag + "_" + key + "_" + messageObject.version + "[1];\n" +
                        Tabber.Get() + baseTag.ToLower() + "." + key + "[0] = new " + messageObject.stringPrefixMessageName + baseTag + "_" + key + "_" + messageObject.version + "();\n";
                    if (messageObject.subObjects[key].mandatory == "Y")
                    {
                        stringBuilder = stringBuilder + Tabber.Get() + baseTag.ToLower() + "." + key + "[0].Value = " + baseTag + "." + key + ";\n";
                    } else
                    {
                        stringBuilder = stringBuilder + Tabber.Get() + "if (" + baseTag + "." + key + " == \"Empty\") {\n" +
                            Tabber.Increment() + baseTag.ToLower() + "." + key + "[0].Value = \"\";\n" +
                            Tabber.Decrement() + "} else {\n" +
                            Tabber.Increment() + baseTag.ToLower() + "." + key + "[0].Value = " + baseTag + "." + key + ";\n" +
                            Tabber.Decrement() + "}\n";
                    }
                } else
                {
                    stringBuilder = stringBuilder + Tabber.Increment() + "int " + key.ToLower() + "Index" + " = 0;\n" +
                        Tabber.Get() + baseTag.ToLower() + "." + key + " = new " + messageObject.stringPrefixMessageName + baseTag + "_" + key + "_" + messageObject.version + "[" + baseTag + "." + key + ".Count];\n" +
                        Tabber.Get() + "foreach (" + messageObject.stringTypeMessage + key + "_" + messageObject.version + " " + key + " in " + baseTag + "." + key + ") {\n" +
                        Tabber.Increment() + messageObject.stringPrefixMessageName + baseTag + "_" + key + "_" + messageObject.version + " " + key.ToLower() + " = new " + messageObject.stringPrefixMessageName + baseTag + "_" + key + "_" + messageObject.version + "();\n" +
                        ToSerializableBuilder(messageObject.subObjects[key], key, iteration + 1) +
                        Tabber.Get() + baseTag.ToLower() + "." + key + "[" + key.ToLower() + "Index] = " + key.ToLower() + ";\n" +
                        Tabber.Get() + key.ToLower() + "Index++;\n" +
                        Tabber.Decrement() + "}\n";

                }
                stringBuilder = stringBuilder + Tabber.Decrement() + "}\n\n";
            }
            return stringBuilder;
        }

        private static string ToSerializableAdvancedBuilder(MessageObject.MessageLineObject messageObject, string baseTag, int iteration = 0)
        {
            string stringBuilder = "";


            return stringBuilder;
        }

        private static string BuildMessageBuilder(MessageObject.MessageLineObject messageObject, string baseTag, int iteration = 0)
        {
            char forLoopCharacter = 'i';
            for (int i = 0; i < iteration - 1; i++)
            {
                forLoopCharacter++;
            }

            string stringBuilder = "";
            foreach(string key in messageObject.subObjects.Keys)
            {
                if (messageObject.subObjects[key].numberOfFields == "")
                {
                	if (key == "MESSAGE_ID")
                	{
                		stringBuilder = stringBuilder + Tabber.Get() + baseTag.ToLower() + "." + key + " = \"" + messageObject.messageName + "\";\n";
                	} else {
                    	stringBuilder = stringBuilder + Tabber.Get() + baseTag.ToLower() + "." + key + " = " + messageObject.fieldName.ToLower() + "_" + key.ToLower() + ";\n";
                	}
                } else
                {
                    stringBuilder = stringBuilder + Tabber.Get() + "if (" + baseTag.ToLower() + "_" + key.ToLower() + " != \"\") {\n" +
                        Tabber.Increment() + "string[] " + key.ToLower() + "List = " + baseTag.ToLower() + "_" + key.ToLower() + ".Split('|');\n" +
                        Tabber.Get() + "for (int " + forLoopCharacter + " = 0; " + forLoopCharacter + " < " + key.ToLower() + "List.Length;) {\n" +
                        Tabber.Increment() + messageObject.stringTypeMessage + key + "_" + messageObject.version + " " + key.ToLower() + "s = new " + messageObject.stringTypeMessage + key + "_" + messageObject.version + "();\n";

                    foreach (string subKey in messageObject.subObjects[key].subObjects.Keys)
                    {
                        if (messageObject.subObjects[key].subObjects[subKey].numberOfFields != "")
                        {
                            stringBuilder = stringBuilder + BuildMessageBuilder(messageObject.subObjects[key], key.ToLower() + "s", iteration + 1);
                        } else
                        {
                            stringBuilder = stringBuilder + Tabber.Get() + key.ToLower() + "s." + subKey + " = " + key.ToLower() + "List[" + forLoopCharacter + "];" + forLoopCharacter + "++;\n";
                        }
                    }

                    stringBuilder = stringBuilder + Tabber.Get() + baseTag.ToLower() + ".add" + key + "(" + key.ToLower() + "s);\n" +
                        Tabber.Decrement() + "}\n" +
                        Tabber.Decrement() + "}\n";
                }
            }

            return stringBuilder;
        }

        private static string BuildMessageValidations(MessageObject.MessageLineObject messageObject, string baseTag, string interumParentField, int iteration = 0)
        {
            string stringBuilder = "";

            char forLoopCharacter = 'i';
            for (int i = 0; i < iteration - 1; i++)
            {
                forLoopCharacter++;
            }

            string forLoopIntegerString = forLoopCharacter.ToString();

            if (messageObject.numberOfFields != "")
            {
                stringBuilder = stringBuilder + Tabber.Get() + "if (" + messageObject.parentField.ToLower() + "." + messageObject.fieldName + " != null) {\n" +
                    Tabber.Increment() + "for (int " + forLoopIntegerString + " = 0; " + forLoopIntegerString + " < " + messageObject.parentField.ToLower() + "." + messageObject.fieldName + ".Length; " + forLoopIntegerString + "++) {\n" +
                    Tabber.Increment() + messageObject.stringTypeMessage + messageObject.fieldName + "_" + messageObject.version + " " + messageObject.fieldName.ToLower() + " = new " + messageObject.stringTypeMessage + messageObject.fieldName + "_" + messageObject.version + "();\n";
            }

            foreach (string key in messageObject.subObjects.Keys)
            {
                string readMessageField = messageObject.fieldName.ToLower() + "." + key;
                string copiedMessageField = "message" + messageObject.fieldName.ToLower() + "." + key;
                if (messageObject.numberOfFields != "")
                {
                    readMessageField = messageObject.parentField.ToLower() + "." + messageObject.fieldName + "[" + forLoopIntegerString + "]." + key;
                    copiedMessageField = messageObject.fieldName.ToLower() + "." + key;
                }

                if (messageObject.subObjects[key].numberOfFields == "")
                {
                    stringBuilder = stringBuilder + "\n" +
                        Tabber.Get() + "if (" + readMessageField + " != null) {\n" +
                        Tabber.Increment() + copiedMessageField + " = " + readMessageField + "[0].Value;\n";
                    if (messageObject.subObjects[key].minFieldSize != "")
                    {
                        stringBuilder = stringBuilder + Tabber.Get() + "if (" + copiedMessageField + " != null) {\n";
                        Tabber.Increment();
                    }
                }
                if (messageObject.subObjects[key].fieldUnits.ToLower() == "numeric" && messageObject.subObjects[key].minFieldSize != "")
                {
                    if (messageObject.subObjects[key].minFieldSize == messageObject.subObjects[key].maxFieldSize)
                    {
                        stringBuilder = stringBuilder + Tabber.Get() + "if (" + copiedMessageField + ".Length != " + messageObject.subObjects[key].minFieldSize + ") {\n" +
                            Tabber.Increment() + "Ranorex.Report.Failure(\"Field " + key + " expected to be length of " + messageObject.subObjects[key].minFieldSize + ", has length of {\" + " + copiedMessageField + ".Length.ToString() + \"}.\");\n" +
                            Tabber.Decrement() + "}\n";
                    } else
                    {
                        stringBuilder = stringBuilder + Tabber.Get() + "if (" + copiedMessageField + ".Length < " + messageObject.subObjects[key].minFieldSize + " || " + copiedMessageField + ".Length > " + messageObject.subObjects[key].maxFieldSize + ") {\n" +
                            Tabber.Increment() + "Ranorex.Report.Failure(\"Field " + key + " expected to be length between or equal to " + messageObject.subObjects[key].minFieldSize + " and " + messageObject.subObjects[key].maxFieldSize + ", has length of {\" + " + copiedMessageField + ".Length.ToString() + \"}.\");\n" +
                            Tabber.Decrement() + "}\n";
                    }

                    stringBuilder = stringBuilder + Tabber.Get() + "if (!IsDigitsOnly(" + copiedMessageField + ")) {\n" +
                        Tabber.Increment() + "Ranorex.Report.Failure(\"Field " + key + " expected to be Numeric, has value of {\" + " + copiedMessageField + " + \"}.\");\n" +
                        Tabber.Decrement() + "}";
                    if (messageObject.subObjects[key].fieldRange != "")
                    {
                        stringBuilder = stringBuilder + " else {\n";
                        string[] fieldRanges = messageObject.subObjects[key].fieldRange.Split('|');
                        if (fieldRanges.Length == 2)
                        {
                            if (Convert.ToInt64(fieldRanges[1]) > 4294967295)
                            {
                                stringBuilder = stringBuilder + Tabber.Increment() + "long intConvertedValue = Convert.ToInt64(" + copiedMessageField + ");\n";
                            } else {
                                stringBuilder = stringBuilder + Tabber.Increment() + "int intConvertedValue = Convert.ToInt32(" + copiedMessageField + ");\n";
                            }
                            
                            stringBuilder = stringBuilder + Tabber.Get() + "if (intConvertedValue < " + fieldRanges[0] + " || intConvertedValue > " + fieldRanges[1] + ") {\n" +
                                Tabber.Increment() + "Ranorex.Report.Failure(\"Field " + key + " expected to have value between " + fieldRanges[0] + " and " + fieldRanges[1] + ", but was found to have a value of \" + " + copiedMessageField + " + \".\");\n" +
                                Tabber.Decrement() + "}\n";
                        } else {
                            stringBuilder = stringBuilder + Tabber.Increment() + "if (";
                            string subString = "";
                            for (int i = 0; i < fieldRanges.Length; i++)
                            {
                                
                                stringBuilder = stringBuilder + copiedMessageField + " != \"" + fieldRanges[i] + "\"";
                                if (i != fieldRanges.Length - 1)
                                {
                                    subString = subString + fieldRanges[i] + ", ";
                                    stringBuilder = stringBuilder + " && ";
                                } else
                                {
                                    subString = subString + fieldRanges[i];
                                    stringBuilder = stringBuilder + ") {\n";
                                }
                            }

                            stringBuilder = stringBuilder + Tabber.Increment() + "Ranorex.Report.Failure(\"Field " + key + " expected to be one of the following values {" + subString + "}, but was found to be {\" + " + copiedMessageField + " + \"}.\";\n" +
                                Tabber.Decrement() + "}\n";
                        }
                        stringBuilder = stringBuilder + Tabber.Decrement() + "}";
                    }

                    stringBuilder = stringBuilder + "\n";

                } else if (messageObject.subObjects[key].fieldUnits.ToLower() == "alphabetic" && messageObject.subObjects[key].minFieldSize != "") {

                    if (messageObject.subObjects[key].minFieldSize == messageObject.subObjects[key].maxFieldSize)
                    {
                        stringBuilder = stringBuilder + Tabber.Get() + "if (" + copiedMessageField + ".Length != " + messageObject.subObjects[key].minFieldSize + ") {\n" +
                            Tabber.Increment() + "Ranorex.Report.Failure(\"Field " + key + " expected to be length of " + messageObject.subObjects[key].minFieldSize + ", has length of {\" + " + copiedMessageField + ".Length.ToString() + \"}.\");\n" +
                            Tabber.Decrement() + "}\n";
                    }
                    else
                    {
                        stringBuilder = stringBuilder + Tabber.Get() + "if (" + copiedMessageField + ".Length < " + messageObject.subObjects[key].minFieldSize + " || " + copiedMessageField + ".Length > " + messageObject.subObjects[key].maxFieldSize + ") {\n" +
                            Tabber.Increment() + "Ranorex.Report.Failure(\"Field " + key + " expected to be length between or equal to " + messageObject.subObjects[key].minFieldSize + " and " + messageObject.subObjects[key].maxFieldSize + ", has length of {\" + " + copiedMessageField + ".Length.ToString() + \"}.\");\n" +
                            Tabber.Decrement() + "}\n";
                    }

                    stringBuilder = stringBuilder + Tabber.Get() + "if (ContainsDigits(" + copiedMessageField + ")) {\n" +
                        Tabber.Increment() + "Ranorex.Report.Failure(\"Field " + key + " expected to be Alphabetic, has value of {\" + " + copiedMessageField + " + \"}.\");\n" +
                        Tabber.Decrement() + "}\n";
                    if (messageObject.subObjects[key].fieldRange != "")
                    {
                        string[] fieldRanges = messageObject.subObjects[key].fieldRange.Split('|');
                        stringBuilder = stringBuilder + Tabber.Get() + "if (";
                        string subString = "";
                        for (int i = 0; i < fieldRanges.Length; i++)
                        {

                            stringBuilder = stringBuilder + copiedMessageField + " != \"" + fieldRanges[i] + "\"";
                            if (i != fieldRanges.Length - 1)
                            {
                                subString = subString + fieldRanges[i] + ", ";
                                stringBuilder = stringBuilder + " && ";
                            }
                            else
                            {
                                subString = subString + fieldRanges[i];
                                stringBuilder = stringBuilder + ") {\n";
                            }
                        }

                        stringBuilder = stringBuilder + Tabber.Increment() + "Ranorex.Report.Failure(\"Field " + key + " expected to be one of the following values {" + subString + "}, but was found to be {\" + " + copiedMessageField + " + \"}.\");\n" +
                            Tabber.Decrement() + "}\n";
                    }
                } else if (messageObject.subObjects[key].fieldUnits.ToLower() == "alphanumeric" && messageObject.subObjects[key].minFieldSize != "")
                {
                    if (messageObject.subObjects[key].minFieldSize == messageObject.subObjects[key].maxFieldSize)
                    {
                        stringBuilder = stringBuilder + Tabber.Get() + "if (" + copiedMessageField + ".Length != " + messageObject.subObjects[key].minFieldSize + ") {\n" +
                            Tabber.Increment() + "Ranorex.Report.Failure(\"Field " + key + " expected to be length of " + messageObject.subObjects[key].minFieldSize + ", has length of {\" + " + copiedMessageField + ".Length.ToString() + \"}.\");\n" +
                            Tabber.Decrement() + "}\n";
                    }
                    else
                    {
                        stringBuilder = stringBuilder + Tabber.Get() + "if (" + copiedMessageField + ".Length < " + messageObject.subObjects[key].minFieldSize + " || " + copiedMessageField + ".Length > " + messageObject.subObjects[key].maxFieldSize + ") {\n" +
                            Tabber.Increment() + "Ranorex.Report.Failure(\"Field " + key + " expected to be length between or equal to " + messageObject.subObjects[key].minFieldSize + " and " + messageObject.subObjects[key].maxFieldSize + ", has length of {\" + " + copiedMessageField + ".Length.ToString() + \"}.\");\n" +
                            Tabber.Decrement() + "}\n";
                    }

                    if (messageObject.subObjects[key].fieldRange != "")
                    {
                        string[] fieldRanges = messageObject.subObjects[key].fieldRange.Split('|');
                        stringBuilder = stringBuilder + Tabber.Get() + "if (";
                        string subString = "";
                        for (int i = 0; i < fieldRanges.Length; i++)
                        {

                            stringBuilder = stringBuilder + copiedMessageField + " != \"" + fieldRanges[i] + "\"";
                            if (i != fieldRanges.Length - 1)
                            {
                                subString = subString + fieldRanges[i] + ", ";
                                stringBuilder = stringBuilder + " && ";
                            }
                            else
                            {
                                subString = subString + fieldRanges[i];
                                stringBuilder = stringBuilder + ") {\n";
                            }
                        }

                        stringBuilder = stringBuilder + Tabber.Increment() + "Ranorex.Report.Failure(\"Field " + key + " expected to be one of the following values {" + subString + "}, but was found to be {\" + " + copiedMessageField + " + \"}.\");\n" +
                            Tabber.Decrement() + "}\n";
                    }
                } else if (messageObject.subObjects[key].numberOfFields != "")
                {
                    stringBuilder = stringBuilder + BuildMessageValidations(messageObject.subObjects[key], baseTag, copiedMessageField, iteration + 1);
                }

                if (messageObject.subObjects[key].numberOfFields != "")
                {
                    stringBuilder = stringBuilder + "\n" + Tabber.Get() + "message" + messageObject.fieldName.ToLower() + ".add" + key + "(" + key.ToLower() + ");\n";
                }
                
                if (!(messageObject.subObjects[key].minFieldSize == "" && messageObject.subObjects[key].numberOfFields == ""))
                {
                        stringBuilder = stringBuilder + Tabber.Decrement() + "}\n";
                }
                stringBuilder = stringBuilder + Tabber.Decrement() + "}";

                if (messageObject.subObjects[key].mandatory == "Y")
                {
                    stringBuilder = stringBuilder + " else {\n" +
                        Tabber.Increment() + "Ranorex.Report.Failure(\"Field " + key + " is a Mandatory field but was found to be missing from the message\");\n" +
                        Tabber.Decrement() + "}";
                }

                stringBuilder = stringBuilder + "\n";
            }
            return stringBuilder;
        }

        

        private static string FromPDSCodeIncludesString()
        {
           return "using System;\n" +
                    "using System.IO;\n" +
                    "using System.Xml;\n" +
                    "using System.Xml.Serialization;\n" +
                    "using System.Collections;\n" +
                    "using STE.Code_Utils.messages;\n\n";
        }
        
        private static string ToPDSCodeIncludesString()
        {
        	return "using System;\n" +
                    "using System.IO;\n" +
                    "using System.Text;\n" +
        			"using System.Threading;\n" +
                    "using System.Net.Sockets;\n" +
                    "using System.Net;\n" +
                    "using System.Xml;\n" +
                    "using System.Xml.Serialization;\n" +
                    "using System.Collections;\n" +
                    "using STE.Code_Utils.MessageQueues;\n\n";
        }

        private static string ToFromPDSCodeIncludesString()
        {
            return "using System;\n" +
                    "using System.IO;\n" +
                    "using System.Text;\n" +
            		"using System.Threading;\n" +
                    "using System.Net.Sockets;\n" +
                    "using System.Net;\n" +
                    "using System.Xml;\n" +
                    "using System.Xml.Serialization;\n" +
                    "using System.Collections;\n" +
            		"using STE.Code_Utils.messages;\n" +
                    "using STE.Code_Utils.MessageQueues;\n\n";
        }

        //private 

        private static string BuildBaseVariableClassesString(MessageObject.MessageLineObject messageObject)
        {
            string stringBuilder = "";

            List<MessageObject.MessageLineObject> complexObjectList = new List<MessageObject.MessageLineObject>();

            if (messageObject.subObjects.Keys.Count > 0)
            {
                stringBuilder = stringBuilder + "\tpublic partial class " + messageObject.stringTypeMessage + messageObject.fieldName + "_" + messageObject.version + " {\n";
                foreach (string key in messageObject.subObjects.Keys)
                {
                    if (messageObject.subObjects[key].numberOfFields == "")
                    {
                        stringBuilder = stringBuilder + "\t\tpublic string " + key + " = \"\";\n";
                    }
                    else
                    {
                        stringBuilder = stringBuilder + "\t\tpublic ArrayList " + key + " = new ArrayList();\n";
                        complexObjectList.Add(messageObject.subObjects[key]);
                    }
                }

                foreach (MessageObject.MessageLineObject complexObject in complexObjectList)
                {
                    stringBuilder = stringBuilder + "\n\t\tpublic void add" + complexObject.fieldName + "(" + messageObject.stringTypeMessage + complexObject.fieldName + "_" + messageObject.version + " " + complexObject.fieldName.ToLower() + ") {\n" +
                        "\t\t\tthis." + complexObject.fieldName + ".Add(" + complexObject.fieldName.ToLower() + ");\n" +
                        "\t\t}\n";
                }

                stringBuilder = stringBuilder + "\t}\n\n";

                foreach (MessageObject.MessageLineObject complexObject in complexObjectList)
                {
                    stringBuilder = stringBuilder + BuildBaseVariableClassesString(complexObject);
                }
            }

            return stringBuilder;
        }

        private static string BuildMainSerializationClassesString(MessageObject messageObject)
        {
            string stringBuilder = "\t[System.CodeDom.Compiler.GeneratedCodeAttribute(\"xsd\", \"4.7.2556.0\")]\n" +
                "\t[System.SerializableAttribute()]\n" +
                "\t[System.Diagnostics.DebuggerStepThroughAttribute()]\n" +
                "\t[System.ComponentModel.DesignerCategoryAttribute(\"code\")]\n" +
                "\t[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]\n" +
                "\t[System.Xml.Serialization.XmlRootAttribute(Namespace = \"\", ElementName = \"" + messageObject.messageName + "\", IsNullable = false)]\n" +
                "\tpublic partial class " + messageObject.stringMessageVersion + " {\n";

            foreach (string key in messageObject.subObjects.Keys)
            {
                stringBuilder = stringBuilder + "\t\t[System.Xml.Serialization.XmlElementAttribute(\"" + messageObject.subObjects[key].fieldName + "\", typeof(" + messageObject.stringPrefixMessageName + key + "_" + messageObject.version + "), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]\n\n";
            }

            stringBuilder = stringBuilder +
                "\t\tpublic object[] Items;\n\n" +
                "\t}\n\n";

            return stringBuilder;
        }

        private static string BuildSubSerializationClassesString(MessageObject.MessageLineObject messageObject)
        {
            string stringBuilder = "";

            List<MessageObject.MessageLineObject> complexObjectList = new List<MessageObject.MessageLineObject>();

            if (messageObject.subObjects.Keys.Count > 0 && messageObject.numberOfFields == "")
            {
                stringBuilder = stringBuilder + "\t[System.CodeDom.Compiler.GeneratedCodeAttribute(\"xsd\", \"4.7.2556.0\")]\n" +
                    "\t[System.SerializableAttribute()]\n" +
                    "\t[System.Diagnostics.DebuggerStepThroughAttribute()]\n" +
                    "\t[System.ComponentModel.DesignerCategoryAttribute(\"code\")]\n" +
                    "\t[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]\n" +
                    "\tpublic partial class " + messageObject.stringPrefixMessageName  + messageObject.myKey + "_" + messageObject.version + " {\n";

            	foreach (string key in messageObject.subObjects.Keys)
                {
                    stringBuilder = stringBuilder + "\t\t[System.Xml.Serialization.XmlElementAttribute(\"" + ((messageObject.fieldName == "HEADER" && messageObject.messageType != "MIS") ? "HEADER_" : "") + messageObject.subObjects[key].fieldName + "\", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]\n" +
                        "\t\tpublic " + messageObject.stringPrefixMessageName + messageObject.fieldName + "_" + key + "_" + messageObject.version + "[] " + key + ";\n\n";
                    complexObjectList.Add(messageObject.subObjects[key]);
                }

                stringBuilder = stringBuilder + "\t}\n\n";

                foreach (MessageObject.MessageLineObject complexObject in complexObjectList)
                {
                    stringBuilder = stringBuilder + BuildSubSerializationClassesString(complexObject);
                }
            } else if (messageObject.subObjects.Keys.Count > 0)
            {
                stringBuilder = stringBuilder + "\t[System.CodeDom.Compiler.GeneratedCodeAttribute(\"xsd\", \"4.7.2556.0\")]\n" +
                    "\t[System.SerializableAttribute()]\n" +
                    "\t[System.Diagnostics.DebuggerStepThroughAttribute()]\n" +
                    "\t[System.ComponentModel.DesignerCategoryAttribute(\"code\")]\n" +
                    "\t[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]\n" +
                    "\tpublic partial class " + messageObject.stringPrefixMessageName + messageObject.parentField + "_" + messageObject.myKey + "_" + messageObject.version + " {\n";

                foreach (string key in messageObject.subObjects.Keys)
                {
                    stringBuilder = stringBuilder + "\t\t[System.Xml.Serialization.XmlElementAttribute(\"" + messageObject.subObjects[key].fieldName + "\", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]\n" +
                        "\t\tpublic " + messageObject.stringPrefixMessageName + messageObject.fieldName + "_" + key + "_" + messageObject.version + "[] " + key + ";\n\n";
                    complexObjectList.Add(messageObject.subObjects[key]);
                }

                stringBuilder = stringBuilder + "\t}\n\n";

                foreach (MessageObject.MessageLineObject complexObject in complexObjectList)
                {
                    stringBuilder = stringBuilder + BuildSubSerializationClassesString(complexObject);
                }
            } else  {
                stringBuilder = stringBuilder + "\t[System.CodeDom.Compiler.GeneratedCodeAttribute(\"xsd\", \"4.7.2556.0\")]\n" +
                    "\t[System.SerializableAttribute()]\n" +
                    "\t[System.Diagnostics.DebuggerStepThroughAttribute()]\n" +
                    "\t[System.ComponentModel.DesignerCategoryAttribute(\"code\")]\n" +
                    "\t[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]\n" +
                    "\tpublic partial class " + messageObject.stringPrefixMessageName + messageObject.parentField + "_" + messageObject.myKey + "_" + messageObject.version + " {\n" +
                    "\t\t[System.Xml.Serialization.XmlTextAttribute()]\n" +
                    "\t\tpublic string Value;\n" +
                    "\t}\n\n";
            }

            return stringBuilder;
        }
    }
}
