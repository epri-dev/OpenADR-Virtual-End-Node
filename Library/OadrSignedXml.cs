using System;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace Oadr.Library
{
    public class OadrSignedXml : SignedXml
    {
        public OadrSignedXml(XmlDocument xml) : base(xml)
        {
        }

        public OadrSignedXml(XmlDocument document, string signatureId) : base(document)
        {
            if (string.IsNullOrEmpty(signatureId))
            {
                throw new ArgumentNullException(nameof(signatureId), "Signature identifier can't be empty");
            }

            Signature.Id = signatureId;
        }

        public override XmlElement GetIdElement(XmlDocument document, string id)
        {
            // Check if it is a standard ID reference.
            var element = base.GetIdElement(document, id);
            if (element != null)
            {
                return element;
            }
            var namespaceManager = new XmlNamespaceManager(document.NameTable);
            namespaceManager.AddNamespace("oadr", "http://openadr.org/oadr-2.0b/2012/07");
            element = document.SelectSingleNode("//*[@oadr:Id=\"" + id + "\"]", namespaceManager) as XmlElement;
            return element;
        }
    }
}
