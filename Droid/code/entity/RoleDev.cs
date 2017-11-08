using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ProjectManager.Droid.code.entity
{
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public class RoleDev : Java.Lang.Object
    {
        [XmlElement("id")] 
        public int id { get; set; }

        [XmlElement("name")] 
        public string name { get; set; }


        public RoleDev()
        {
            
        }

        public RoleDev(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
