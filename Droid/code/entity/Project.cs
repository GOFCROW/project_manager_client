using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProjectManager.Droid.code.entity
{
    [Serializable]
    public class Project : Java.Lang.Object, Java.IO.ISerializable
    {
        [XmlElement("id")]  
        private int id { get; set; }

        [XmlElement("name")]  
        private string name { get; set; }

        [XmlElement("description")]  
        private string description { get; set; }

        [XmlElement("estimated_hours")]  
        private int estimated_hours { get; set; }

        [XmlElement("enabled")]  
        private Boolean enabled { get; set; }

        [XmlArray("assignments")]
        [XmlArrayItem("assignments")]
        private Assignment[] assignment { get; set; }


    }
}
