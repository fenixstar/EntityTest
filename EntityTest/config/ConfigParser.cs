using System.Xml;

namespace EntityTest.config
{
    public enum Parameters
    {
        host,
        port,
        database,
        username,
        password
    }
    public class ConfigParser
    {
        private string path;

        public ConfigParser(string _path) 
        { 
            path = _path;   
        }
    
        private string GetValue(Parameters _param) 
        {
            string result = "";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement? xRoot = xDoc.DocumentElement;

            if (xRoot != null)
            {
                XmlElement xnode = xRoot;
                XmlNode? attr = xnode.Attributes.GetNamedItem(_param.ToString());
                result = attr?.Value;
            }
            return result; 
        }
        public string GetHost() 
        { 
            return GetValue(Parameters.host); 
        }
        public string GetPort() 
        { 
            return GetValue(Parameters.port); 
        }
        public string GetDataBase() 
        { 
            return GetValue(Parameters.database); 
        }
        public string GetUserName() 
        {
            return GetValue(Parameters.username);
        }
        public string GetPassword() 
        { 
            return GetValue(Parameters.password); 
        }
        public Dictionary<string, Parameters> GetAllValue()
        {
            Dictionary<string, Parameters> result = new Dictionary<string, Parameters>();
            result.Add(GetValue(Parameters.host), Parameters.host);
            result.Add(GetValue(Parameters.port), Parameters.port);
            result.Add(GetValue(Parameters.database), Parameters.database);
            result.Add(GetValue(Parameters.username), Parameters.username);
            result.Add(GetValue(Parameters.password), Parameters.password);
            return result; 
        }
    }

}
