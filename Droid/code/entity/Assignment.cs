using System;
using System.Xml.Serialization;
using Android.OS;
using Android.Runtime;
using GoogleGson;
using Newtonsoft.Json;

namespace ProjectManager.Droid.code.entity
{
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public class Assignment : Java.Lang.Object
    {
        [XmlElement("fk_dev")]  
        public int fk_dev { get; set; }

        //[XmlElement("fk_proj")]  
        //public int fk_proj { get; set; }

        //[XmlElement( "fk_role")]  
        //public int fk_role { get; set; }

        [XmlElement("hours_worked")]  
        public int hours_worked { get; set; }


        //[XmlElement("Developer")]  
        //public Developer developer { get; set; }

        //[XmlElement("RoleDev")]  
        //public RoleDev role{ get; set; }

        public Assignment()
        {
            
        }

        //public Assignment(int fk_dev, int fk_proj, int fk_role, int hours_worked,Developer developer,RoleDev role)
        //{
        //    this.fk_dev = fk_dev;
        //    this.fk_proj = fk_proj;
        //    this.fk_role = fk_role;
        //    this.hours_worked = hours_worked;
        //    this.developer = developer;
        //    this.role = role;
        //}

    }
}
