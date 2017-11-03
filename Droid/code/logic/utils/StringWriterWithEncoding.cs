using System;
using System.IO;
using System.Text;

namespace ProjectManager.Droid.code.logic.utils
{
    public sealed class StringWriterWithEncoding : StringWriter
    {
        public override Encoding Encoding { get; }

        public StringWriterWithEncoding (Encoding encoding)
        {
            Encoding = encoding;
        }  
    }
}
