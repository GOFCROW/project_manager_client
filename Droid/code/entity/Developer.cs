using System;
using System.Xml.Serialization;

namespace ProjectManager.Droid.code.entity
{
    [Serializable]
    public class Developer : Java.Lang.Object, Java.IO.ISerializable
    {
        [XmlElement("id")]  
        public int id { get; set; }

        [XmlElement("first_name")]  
        public string first_name { get; set; }

        [XmlElement("last_name")]  
        public string last_name { get; set; }

        [XmlElement("phone_number")]  
        public string phone_number { get; set; }

        [XmlElement("experience")]  
        public string experience { get; set; }

        [XmlElement("skills")]  
        public string skills { get; set; }

        [XmlElement("email")]  
        public string email { get; set; }
       
        [XmlElement("enabled")]  
        public String enabled { get; set; }

        [XmlArray("assignments")]
        [XmlArrayItem("assignments")]
        public Assignment[] asignments { get; set; }

        public Developer()
        {
        }
    }
}
