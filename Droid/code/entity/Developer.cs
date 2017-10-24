using System;
using System.Xml.Serialization;

namespace ProjectManager.Droid.code.entity
{
    [Serializable]
    public class Developer : Java.Lang.Object, Java.IO.ISerializable
    {
        [XmlElement("id")]  
        private int id { get; set; }

        [XmlElement("first_name")]  
        private string first_name { get; set; }

        [XmlElement("last_name")]  
        private string last_name { get; set; }

        [XmlElement("phone_number")]  
        private string phone_number { get; set; }

        [XmlElement("experience")]  
        private string experience { get; set; }

        [XmlElement("skills")]  
        private string skills { get; set; }

        [XmlElement("email")]  
        private string email { get; set; }

        [XmlElement("enabled")]  
        private Boolean enabled { get; set; }

        [XmlArray("assignments")]
        [XmlArrayItem("assignments")]
        private Assignment[] asignments { get; set; }

        public Developer()
        {
        }
    }
}
