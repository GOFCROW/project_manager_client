using System;
using System.Xml.Serialization;

namespace ProjectManager.Droid.code.entity
{
    [Serializable]
    public class Assignment
    {
        [XmlElement("fk_dev")]  
        private int fk_dev { get; set; }

        [XmlElement( "fk_proj")]  
        private int fk_proj { get; set; }

        [XmlElement( "fk_role")]  
        private int fk_role { get; set; }

        [XmlElement("hours_worked")]  
        private int hours_worked { get; set; }


        [XmlElement("Project")]  
        private Project project { get; set; }

        [XmlElement("RoleDev")]  
        private RoleDev role{ get; set; }

        public Assignment()
        {

        }
    }
}
