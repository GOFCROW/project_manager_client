using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ProjectManager.Droid.code.entity
{
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public class Project : Java.Lang.Object
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
        public string enabled { get; set; }

        [XmlArray("assignments")]
        [XmlArrayItem("Assignment")]
        public List<Assignment> assignment { get; set; }


        public Project()
        {
            
        }

        //public Project(int id, string name, string description, string estimated_hours, String enabled, List<Assignment> assignment )
        //{
        //    this.id = id;
        //    this.name = name;
        //    this.description = description;
        //    this.estimated_hours = estimated_hours;
        //    this.enabled = enabled;
        //    this.assignment = assignment;
        //}

    }
}
