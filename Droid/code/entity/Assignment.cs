using System;
using System.Xml.Serialization;

namespace ProjectManager.Droid.code.entity
{
    [Serializable]
    public class Assignment : Java.Lang.Object, Java.IO.ISerializable
    {
        [XmlElement("fk_dev")]  
        public int fk_dev { get; set; }

        [XmlElement( "fk_proj")]  
        public int fk_proj { get; set; }

        [XmlElement( "fk_role")]  
        public int fk_role { get; set; }

        [XmlElement("hours_worked")]  
        public int hours_worked { get; set; }


        [XmlElement("Project")]  
        public Project project { get; set; }

        [XmlElement("RoleDev")]  
        public RoleDev role{ get; set; }

        public Assignment()
        {

        }
    }
}
