using System.IO;
using System.Text;

namespace Oadr.Library
{
    // Original implementation from: http://stackoverflow.com/questions/1564718/using-stringwriter-for-xml-serialization
    public sealed class StringWriterWithEncoding : StringWriter
    {
        public StringWriterWithEncoding(Encoding encoding)
        {
            Encoding = encoding;
        }

        public override Encoding Encoding { get; }
    }
}
