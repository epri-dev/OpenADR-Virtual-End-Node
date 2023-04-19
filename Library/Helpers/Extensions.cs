using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Oadr.Library.Helpers
{
    public static class Extensions
    {
        public static XmlDocument ToXmlDocument<T>(this T input)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                serializer.Serialize(stream, input);
                stream.Position = 0;

                var settings = new XmlReaderSettings
                {
                    IgnoreWhitespace = true
                };
                using (var reader = XmlReader.Create(stream, settings))
                {
                    var document = new XmlDocument();
                    document.Load(reader);
                    return document;
                }
            }
        }
    }
}
