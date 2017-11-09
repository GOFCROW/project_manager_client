using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ProjectManager.Droid.code.entity
{
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public class Developer : Java.Lang.Object
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


        public Developer(int id,string first_name,string last_name,string phone_number,
                         string experience,string skills, string email,String enabled,Assignment[] asignments )
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.phone_number = phone_number;
            this.experience = experience;
            this.skills = skills;
            this.email = email;
            this.enabled = enabled;
            this.asignments = asignments;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;

            Developer developer = (Developer)obj;
            return id.Equals(developer.id);
        }
    }
}
