using System;
using System.IO;
using System.Xml.Serialization;

namespace ProjectManager.Droid.code.utils
{
    public class Serializer
    {
        private XmlRootAttribute xRoot;

        public Serializer(string xmlElementName)
        {
            this.xRoot = new XmlRootAttribute();
            this.xRoot.ElementName = xmlElementName;
            this.xRoot.IsNullable = true;
        }

        public T Deserialize<T>(string input) where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T),this.xRoot);

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        public string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                return textWriter.ToString();
            }
        }
    }
}
