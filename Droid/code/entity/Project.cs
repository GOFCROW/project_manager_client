using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProjectManager.Droid.code.entity
{
    [Serializable]
    public class Project : Java.Lang.Object, Java.IO.ISerializable
    {
        [XmlElement("id")]  
        public int id { get; set; }

        [XmlElement("name")]  
        public string name { get; set; }

        [XmlElement("description")]  
        public string description { get; set; }

        [XmlElement("estimated_hours")]  
        public int estimated_hours { get; set; }

        [XmlElement("enabled")]  
        public String enabled { get; set; }

        [XmlArray("assignments")]
        [XmlArrayItem("assignments")]
        public Assignment[] assignment { get; set; }


    }
}
