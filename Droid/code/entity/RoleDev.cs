using System;
using System.Xml.Serialization;

namespace ProjectManager.Droid.code.entity
{
    [Serializable]
    public class RoleDev : Java.Lang.Object, Java.IO.ISerializable
    {
        [XmlElement("id")] 
        private int id { get; set; }

        [XmlElement("name")] 
        private string name { get; set; }

        public RoleDev()
        {
        }
    }
}
