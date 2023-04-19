using Oadr.Library.Helpers;
using Oadr.Library.Profile2B.Models;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace Oadr.Library
{
    public static class XmlSigning
    {
        public static string Sign(string xml, X509Certificate2 certificate)
        {
            if (certificate == null)
            {
                throw new ArgumentNullException(nameof(certificate));
            }
            if (!certificate.HasPrivateKey)
            {
                throw new Exception("The provided certificate is missing its private key.");
            }

            var document = new XmlDocument { PreserveWhitespace = true };
            document.LoadXml(xml);

            var privateKey = certificate.PrivateKey;
            var publicKey = certificate.PublicKey;

            const string signatureId = "payloadSignature";
            // Create a SignedXml object.
            var signedXml = new OadrSignedXml(document, signatureId)
            {
                SigningKey = privateKey
            };

            #region KeyInfo

            var keyInfo = new KeyInfo();
            keyInfo.AddClause(new KeyInfoName(certificate.SubjectName.Name));
            switch (publicKey.Key.SignatureAlgorithm)
            {
                case "RSA":
                    keyInfo.AddClause(new RSAKeyValue((RSA)publicKey.Key));
                    break;
                case "ECDsa":
                    keyInfo.AddClause(new KeyInfoX509Data(certificate, X509IncludeOption.None));
                    break;
            }
            signedXml.KeyInfo = keyInfo;

            #endregion // KeyInfo

            #region References and Object

            // Create and add the reference to the SignedXml object.
            var reference = new Reference
            {
                Uri = "#signedObject"
            };
            signedXml.AddReference(reference);
            
            var dataObject = new DataObject("prop", string.Empty, string.Empty, GetReplayProtectSignatureProperty(signatureId).ToXmlDocument().DocumentElement);
            signedXml.AddObject(dataObject);
            reference = new Reference
            {
                Uri = "#prop"
            };
            signedXml.AddReference(reference);

            #endregion // References and Object

            #region Message signing

            // Compute the signature.
            signedXml.ComputeSignature();
            
            // Get the XML representation of the signature.
            var signature = signedXml.GetXml();

            #endregion // Message signing

            // Append the element to the XML document.
            document.DocumentElement?.InsertBefore(document.ImportNode(signature, true), document.DocumentElement.FirstChild);
            return document.OuterXml;
        }

        private static SignaturePropertiesType GetReplayProtectSignatureProperty(string target)
        {
            var replayProtect = new ReplayProtectType
            {
                timestamp = DateTime.UtcNow,
                nonce = new NonceValueType
                {
                    Value = RandomHex.Instance().GenerateRandomHex(16)
                }
            }.ToXmlDocument();
            return new SignaturePropertiesType
            {
                SignatureProperty = new[]
                {
                    new SignaturePropertyType
                    {
                        Target = target,
                        Items = new[] { replayProtect.DocumentElement }
                    }
                }
            };
        }
    }
}
