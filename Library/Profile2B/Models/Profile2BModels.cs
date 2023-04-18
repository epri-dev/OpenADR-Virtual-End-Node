﻿namespace Oadr.Library.Profile2B.Models
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrPayload
    {

        private SignatureType signatureField;

        private oadrSignedObject oadrSignedObjectField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature
        {
            get
            {
                return this.signatureField;
            }
            set
            {
                this.signatureField = value;
            }
        }

        /// <remarks/>
        public oadrSignedObject oadrSignedObject
        {
            get
            {
                return this.oadrSignedObjectField;
            }
            set
            {
                this.oadrSignedObjectField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class SignatureType
    {

        private SignedInfoType signedInfoField;

        private SignatureValueType signatureValueField;

        private KeyInfoType keyInfoField;

        private ObjectType[] objectField;

        private string idField;

        /// <remarks/>
        public SignedInfoType SignedInfo
        {
            get
            {
                return this.signedInfoField;
            }
            set
            {
                this.signedInfoField = value;
            }
        }

        /// <remarks/>
        public SignatureValueType SignatureValue
        {
            get
            {
                return this.signatureValueField;
            }
            set
            {
                this.signatureValueField = value;
            }
        }

        /// <remarks/>
        public KeyInfoType KeyInfo
        {
            get
            {
                return this.keyInfoField;
            }
            set
            {
                this.keyInfoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Object")]
        public ObjectType[] Object
        {
            get
            {
                return this.objectField;
            }
            set
            {
                this.objectField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("SignedInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class SignedInfoType
    {

        private CanonicalizationMethodType canonicalizationMethodField;

        private SignatureMethodType signatureMethodField;

        private ReferenceType[] referenceField;

        private string idField;

        /// <remarks/>
        public CanonicalizationMethodType CanonicalizationMethod
        {
            get
            {
                return this.canonicalizationMethodField;
            }
            set
            {
                this.canonicalizationMethodField = value;
            }
        }

        /// <remarks/>
        public SignatureMethodType SignatureMethod
        {
            get
            {
                return this.signatureMethodField;
            }
            set
            {
                this.signatureMethodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Reference")]
        public ReferenceType[] Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("CanonicalizationMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class CanonicalizationMethodType
    {

        private System.Xml.XmlNode[] anyField;

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlNode[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07/xmldsig-properties")]
    public partial class NonceValueType
    {

        private string encodingTypeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string EncodingType
        {
            get
            {
                return this.encodingTypeField;
            }
            set
            {
                this.encodingTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07/xmldsig-properties")]
    [System.Xml.Serialization.XmlRootAttribute("ReplayProtect", Namespace = "http://openadr.org/oadr-2.0b/2012/07/xmldsig-properties", IsNullable = false)]
    public partial class ReplayProtectType
    {

        private System.DateTime timestampField;

        private NonceValueType nonceField;

        /// <remarks/>
        public System.DateTime timestamp
        {
            get
            {
                return this.timestampField;
            }
            set
            {
                this.timestampField = value;
            }
        }

        /// <remarks/>
        public NonceValueType nonce
        {
            get
            {
                return this.nonceField;
            }
            set
            {
                this.nonceField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    [System.Xml.Serialization.XmlRootAttribute("KeyInfoReference", Namespace = "http://www.w3.org/2009/xmldsig11#", IsNullable = false)]
    public partial class KeyInfoReferenceType
    {

        private string uRIField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string URI
        {
            get
            {
                return this.uRIField;
            }
            set
            {
                this.uRIField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    public partial class NamedCurveType
    {

        private string uRIField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string URI
        {
            get
            {
                return this.uRIField;
            }
            set
            {
                this.uRIField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    public partial class ECValidationDataType
    {

        private byte[] seedField;

        private string hashAlgorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] seed
        {
            get
            {
                return this.seedField;
            }
            set
            {
                this.seedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string hashAlgorithm
        {
            get
            {
                return this.hashAlgorithmField;
            }
            set
            {
                this.hashAlgorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    public partial class CurveType
    {

        private byte[] aField;

        private byte[] bField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] A
        {
            get
            {
                return this.aField;
            }
            set
            {
                this.aField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] B
        {
            get
            {
                return this.bField;
            }
            set
            {
                this.bField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PnBFieldParamsType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TnBFieldParamsType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    [System.Xml.Serialization.XmlRootAttribute("GnB", Namespace = "http://www.w3.org/2009/xmldsig11#", IsNullable = false)]
    public partial class CharTwoFieldParamsType
    {

        private string mField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger")]
        public string M
        {
            get
            {
                return this.mField;
            }
            set
            {
                this.mField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    [System.Xml.Serialization.XmlRootAttribute("PnB", Namespace = "http://www.w3.org/2009/xmldsig11#", IsNullable = false)]
    public partial class PnBFieldParamsType : CharTwoFieldParamsType
    {

        private string k1Field;

        private string k2Field;

        private string k3Field;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger")]
        public string K1
        {
            get
            {
                return this.k1Field;
            }
            set
            {
                this.k1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger")]
        public string K2
        {
            get
            {
                return this.k2Field;
            }
            set
            {
                this.k2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger")]
        public string K3
        {
            get
            {
                return this.k3Field;
            }
            set
            {
                this.k3Field = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    [System.Xml.Serialization.XmlRootAttribute("TnB", Namespace = "http://www.w3.org/2009/xmldsig11#", IsNullable = false)]
    public partial class TnBFieldParamsType : CharTwoFieldParamsType
    {

        private string kField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger")]
        public string K
        {
            get
            {
                return this.kField;
            }
            set
            {
                this.kField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    [System.Xml.Serialization.XmlRootAttribute("Prime", Namespace = "http://www.w3.org/2009/xmldsig11#", IsNullable = false)]
    public partial class PrimeFieldParamsType
    {

        private byte[] pField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] P
        {
            get
            {
                return this.pField;
            }
            set
            {
                this.pField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    public partial class FieldIDType
    {

        private object itemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("GnB", typeof(CharTwoFieldParamsType))]
        [System.Xml.Serialization.XmlElementAttribute("PnB", typeof(PnBFieldParamsType))]
        [System.Xml.Serialization.XmlElementAttribute("Prime", typeof(PrimeFieldParamsType))]
        [System.Xml.Serialization.XmlElementAttribute("TnB", typeof(TnBFieldParamsType))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    public partial class ECParametersType
    {

        private FieldIDType fieldIDField;

        private CurveType curveField;

        private byte[] baseField;

        private byte[] orderField;

        private string coFactorField;

        private ECValidationDataType validationDataField;

        /// <remarks/>
        public FieldIDType FieldID
        {
            get
            {
                return this.fieldIDField;
            }
            set
            {
                this.fieldIDField = value;
            }
        }

        /// <remarks/>
        public CurveType Curve
        {
            get
            {
                return this.curveField;
            }
            set
            {
                this.curveField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] Base
        {
            get
            {
                return this.baseField;
            }
            set
            {
                this.baseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] Order
        {
            get
            {
                return this.orderField;
            }
            set
            {
                this.orderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string CoFactor
        {
            get
            {
                return this.coFactorField;
            }
            set
            {
                this.coFactorField = value;
            }
        }

        /// <remarks/>
        public ECValidationDataType ValidationData
        {
            get
            {
                return this.validationDataField;
            }
            set
            {
                this.validationDataField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    [System.Xml.Serialization.XmlRootAttribute("ECKeyValue", Namespace = "http://www.w3.org/2009/xmldsig11#", IsNullable = false)]
    public partial class ECKeyValueType
    {

        private object itemField;

        private byte[] publicKeyField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ECParameters", typeof(ECParametersType))]
        [System.Xml.Serialization.XmlElementAttribute("NamedCurve", typeof(NamedCurveType))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] PublicKey
        {
            get
            {
                return this.publicKeyField;
            }
            set
            {
                this.publicKeyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("SignatureProperty", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class SignaturePropertyType
    {

        private System.Xml.XmlElement[] itemsField;

        private string[] textField;

        private string targetField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Target
        {
            get
            {
                return this.targetField;
            }
            set
            {
                this.targetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("SignatureProperties", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class SignaturePropertiesType
    {

        private SignaturePropertyType[] signaturePropertyField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SignatureProperty")]
        public SignaturePropertyType[] SignatureProperty
        {
            get
            {
                return this.signaturePropertyField;
            }
            set
            {
                this.signaturePropertyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("Manifest", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class ManifestType
    {

        private ReferenceType[] referenceField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Reference")]
        public ReferenceType[] Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("Reference", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class ReferenceType
    {

        private TransformType[] transformsField;

        private DigestMethodType digestMethodField;

        private byte[] digestValueField;

        private string idField;

        private string uRIField;

        private string typeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Transform", IsNullable = false)]
        public TransformType[] Transforms
        {
            get
            {
                return this.transformsField;
            }
            set
            {
                this.transformsField = value;
            }
        }

        /// <remarks/>
        public DigestMethodType DigestMethod
        {
            get
            {
                return this.digestMethodField;
            }
            set
            {
                this.digestMethodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] DigestValue
        {
            get
            {
                return this.digestValueField;
            }
            set
            {
                this.digestValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string URI
        {
            get
            {
                return this.uRIField;
            }
            set
            {
                this.uRIField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("Transform", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class TransformType
    {

        private object[] itemsField;

        private string[] textField;

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("XPath", typeof(string))]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class DigestMethodType
    {

        private System.Xml.XmlNode[] anyField;

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlNode[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    public partial class LineItem
    {

        private long amountField;

        private long roundingField;

        private bool roundingFieldSpecified;

        private long dateTimeField;

        private string noteField;

        /// <remarks/>
        public long amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }

        /// <remarks/>
        public long rounding
        {
            get
            {
                return this.roundingField;
            }
            set
            {
                this.roundingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool roundingSpecified
        {
            get
            {
                return this.roundingFieldSpecified;
            }
            set
            {
                this.roundingFieldSpecified = value;
            }
        }

        /// <remarks/>
        public long dateTime
        {
            get
            {
                return this.dateTimeField;
            }
            set
            {
                this.dateTimeField = value;
            }
        }

        /// <remarks/>
        public string note
        {
            get
            {
                return this.noteField;
            }
            set
            {
                this.noteField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    public partial class RationalNumber
    {

        private string numeratorField;

        private object denominatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string numerator
        {
            get
            {
                return this.numeratorField;
            }
            set
            {
                this.numeratorField = value;
            }
        }

        /// <remarks/>
        public object denominator
        {
            get
            {
                return this.denominatorField;
            }
            set
            {
                this.denominatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    public partial class ReadingInterharmonic
    {

        private string numeratorField;

        private object denominatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string numerator
        {
            get
            {
                return this.numeratorField;
            }
            set
            {
                this.numeratorField = value;
            }
        }

        /// <remarks/>
        public object denominator
        {
            get
            {
                return this.denominatorField;
            }
            set
            {
                this.denominatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ServiceStatus))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(IdentifiedObject))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TimeConfiguration))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ElectricPowerUsageSummary))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ElectricPowerQualitySummary))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UsagePoint))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ReadingType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MeterReading))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(IntervalBlock))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ServiceDeliveryPoint))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BatchItemInfo))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SummaryMeasurement))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ServiceCategory))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DateTimeInterval))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ReadingQuality))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(IntervalReading))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://naesb.org/espi", IsNullable = false)]
    public partial class Object
    {

        private object[] extensionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("extension")]
        public object[] extension
        {
            get
            {
                return this.extensionField;
            }
            set
            {
                this.extensionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://naesb.org/espi", IsNullable = false)]
    public partial class ServiceStatus : Object
    {

        private string currentStatusField;

        /// <remarks/>
        public string currentStatus
        {
            get
            {
                return this.currentStatusField;
            }
            set
            {
                this.currentStatusField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TimeConfiguration))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ElectricPowerUsageSummary))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ElectricPowerQualitySummary))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UsagePoint))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ReadingType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MeterReading))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(IntervalBlock))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://naesb.org/espi", IsNullable = false)]
    public partial class IdentifiedObject : Object
    {

        private BatchItemInfo batchItemInfoField;

        /// <remarks/>
        public BatchItemInfo batchItemInfo
        {
            get
            {
                return this.batchItemInfoField;
            }
            set
            {
                this.batchItemInfoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://naesb.org/espi", IsNullable = false)]
    public partial class BatchItemInfo : Object
    {

        private byte[] nameField;

        private string operationField;

        private string statusCodeField;

        private string statusReasonField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "hexBinary")]
        public byte[] name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string operation
        {
            get
            {
                return this.operationField;
            }
            set
            {
                this.operationField = value;
            }
        }

        /// <remarks/>
        public string statusCode
        {
            get
            {
                return this.statusCodeField;
            }
            set
            {
                this.statusCodeField = value;
            }
        }

        /// <remarks/>
        public string statusReason
        {
            get
            {
                return this.statusReasonField;
            }
            set
            {
                this.statusReasonField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    [System.Xml.Serialization.XmlRootAttribute("LocalTimeParameters", Namespace = "http://naesb.org/espi", IsNullable = false)]
    public partial class TimeConfiguration : IdentifiedObject
    {

        private byte[] dstEndRuleField;

        private long dstOffsetField;

        private byte[] dstStartRuleField;

        private long tzOffsetField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "hexBinary")]
        public byte[] dstEndRule
        {
            get
            {
                return this.dstEndRuleField;
            }
            set
            {
                this.dstEndRuleField = value;
            }
        }

        /// <remarks/>
        public long dstOffset
        {
            get
            {
                return this.dstOffsetField;
            }
            set
            {
                this.dstOffsetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "hexBinary")]
        public byte[] dstStartRule
        {
            get
            {
                return this.dstStartRuleField;
            }
            set
            {
                this.dstStartRuleField = value;
            }
        }

        /// <remarks/>
        public long tzOffset
        {
            get
            {
                return this.tzOffsetField;
            }
            set
            {
                this.tzOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://naesb.org/espi", IsNullable = false)]
    public partial class ElectricPowerUsageSummary : IdentifiedObject
    {

        private DateTimeInterval billingPeriodField;

        private long billLastPeriodField;

        private bool billLastPeriodFieldSpecified;

        private long billToDateField;

        private bool billToDateFieldSpecified;

        private long costAdditionalLastPeriodField;

        private bool costAdditionalLastPeriodFieldSpecified;

        private LineItem[] costAdditionalDetailLastPeriodField;

        private string currencyField;

        private SummaryMeasurement overallConsumptionLastPeriodField;

        private SummaryMeasurement currentBillingPeriodOverAllConsumptionField;

        private SummaryMeasurement currentDayLastYearNetConsumptionField;

        private SummaryMeasurement currentDayNetConsumptionField;

        private SummaryMeasurement currentDayOverallConsumptionField;

        private SummaryMeasurement peakDemandField;

        private SummaryMeasurement previousDayLastYearOverallConsumptionField;

        private SummaryMeasurement previousDayNetConsumptionField;

        private SummaryMeasurement previousDayOverallConsumptionField;

        private string qualityOfReadingField;

        private SummaryMeasurement ratchetDemandField;

        private DateTimeInterval ratchetDemandPeriodField;

        private long statusTimeStampField;

        /// <remarks/>
        public DateTimeInterval billingPeriod
        {
            get
            {
                return this.billingPeriodField;
            }
            set
            {
                this.billingPeriodField = value;
            }
        }

        /// <remarks/>
        public long billLastPeriod
        {
            get
            {
                return this.billLastPeriodField;
            }
            set
            {
                this.billLastPeriodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool billLastPeriodSpecified
        {
            get
            {
                return this.billLastPeriodFieldSpecified;
            }
            set
            {
                this.billLastPeriodFieldSpecified = value;
            }
        }

        /// <remarks/>
        public long billToDate
        {
            get
            {
                return this.billToDateField;
            }
            set
            {
                this.billToDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool billToDateSpecified
        {
            get
            {
                return this.billToDateFieldSpecified;
            }
            set
            {
                this.billToDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        public long costAdditionalLastPeriod
        {
            get
            {
                return this.costAdditionalLastPeriodField;
            }
            set
            {
                this.costAdditionalLastPeriodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool costAdditionalLastPeriodSpecified
        {
            get
            {
                return this.costAdditionalLastPeriodFieldSpecified;
            }
            set
            {
                this.costAdditionalLastPeriodFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("costAdditionalDetailLastPeriod")]
        public LineItem[] costAdditionalDetailLastPeriod
        {
            get
            {
                return this.costAdditionalDetailLastPeriodField;
            }
            set
            {
                this.costAdditionalDetailLastPeriodField = value;
            }
        }

        /// <remarks/>
        public string currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        /// <remarks/>
        public SummaryMeasurement overallConsumptionLastPeriod
        {
            get
            {
                return this.overallConsumptionLastPeriodField;
            }
            set
            {
                this.overallConsumptionLastPeriodField = value;
            }
        }

        /// <remarks/>
        public SummaryMeasurement currentBillingPeriodOverAllConsumption
        {
            get
            {
                return this.currentBillingPeriodOverAllConsumptionField;
            }
            set
            {
                this.currentBillingPeriodOverAllConsumptionField = value;
            }
        }

        /// <remarks/>
        public SummaryMeasurement currentDayLastYearNetConsumption
        {
            get
            {
                return this.currentDayLastYearNetConsumptionField;
            }
            set
            {
                this.currentDayLastYearNetConsumptionField = value;
            }
        }

        /// <remarks/>
        public SummaryMeasurement currentDayNetConsumption
        {
            get
            {
                return this.currentDayNetConsumptionField;
            }
            set
            {
                this.currentDayNetConsumptionField = value;
            }
        }

        /// <remarks/>
        public SummaryMeasurement currentDayOverallConsumption
        {
            get
            {
                return this.currentDayOverallConsumptionField;
            }
            set
            {
                this.currentDayOverallConsumptionField = value;
            }
        }

        /// <remarks/>
        public SummaryMeasurement peakDemand
        {
            get
            {
                return this.peakDemandField;
            }
            set
            {
                this.peakDemandField = value;
            }
        }

        /// <remarks/>
        public SummaryMeasurement previousDayLastYearOverallConsumption
        {
            get
            {
                return this.previousDayLastYearOverallConsumptionField;
            }
            set
            {
                this.previousDayLastYearOverallConsumptionField = value;
            }
        }

        /// <remarks/>
        public SummaryMeasurement previousDayNetConsumption
        {
            get
            {
                return this.previousDayNetConsumptionField;
            }
            set
            {
                this.previousDayNetConsumptionField = value;
            }
        }

        /// <remarks/>
        public SummaryMeasurement previousDayOverallConsumption
        {
            get
            {
                return this.previousDayOverallConsumptionField;
            }
            set
            {
                this.previousDayOverallConsumptionField = value;
            }
        }

        /// <remarks/>
        public string qualityOfReading
        {
            get
            {
                return this.qualityOfReadingField;
            }
            set
            {
                this.qualityOfReadingField = value;
            }
        }

        /// <remarks/>
        public SummaryMeasurement ratchetDemand
        {
            get
            {
                return this.ratchetDemandField;
            }
            set
            {
                this.ratchetDemandField = value;
            }
        }

        /// <remarks/>
        public DateTimeInterval ratchetDemandPeriod
        {
            get
            {
                return this.ratchetDemandPeriodField;
            }
            set
            {
                this.ratchetDemandPeriodField = value;
            }
        }

        /// <remarks/>
        public long statusTimeStamp
        {
            get
            {
                return this.statusTimeStampField;
            }
            set
            {
                this.statusTimeStampField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://naesb.org/espi", IsNullable = false)]
    public partial class DateTimeInterval : Object
    {

        private uint durationField;

        private bool durationFieldSpecified;

        private long startField;

        private bool startFieldSpecified;

        /// <remarks/>
        public uint duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool durationSpecified
        {
            get
            {
                return this.durationFieldSpecified;
            }
            set
            {
                this.durationFieldSpecified = value;
            }
        }

        /// <remarks/>
        public long start
        {
            get
            {
                return this.startField;
            }
            set
            {
                this.startField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool startSpecified
        {
            get
            {
                return this.startFieldSpecified;
            }
            set
            {
                this.startFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://naesb.org/espi", IsNullable = false)]
    public partial class SummaryMeasurement : Object
    {

        private string powerOfTenMultiplierField;

        private long timeStampField;

        private bool timeStampFieldSpecified;

        private string uomField;

        private long valueField;

        private bool valueFieldSpecified;

        /// <remarks/>
        public string powerOfTenMultiplier
        {
            get
            {
                return this.powerOfTenMultiplierField;
            }
            set
            {
                this.powerOfTenMultiplierField = value;
            }
        }

        /// <remarks/>
        public long timeStamp
        {
            get
            {
                return this.timeStampField;
            }
            set
            {
                this.timeStampField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool timeStampSpecified
        {
            get
            {
                return this.timeStampFieldSpecified;
            }
            set
            {
                this.timeStampFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string uom
        {
            get
            {
                return this.uomField;
            }
            set
            {
                this.uomField = value;
            }
        }

        /// <remarks/>
        public long value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool valueSpecified
        {
            get
            {
                return this.valueFieldSpecified;
            }
            set
            {
                this.valueFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://naesb.org/espi", IsNullable = false)]
    public partial class ElectricPowerQualitySummary : IdentifiedObject
    {

        private long flickerPltField;

        private bool flickerPltFieldSpecified;

        private long flickerPstField;

        private bool flickerPstFieldSpecified;

        private long harmonicVoltageField;

        private bool harmonicVoltageFieldSpecified;

        private long longInterruptionsField;

        private bool longInterruptionsFieldSpecified;

        private long mainsVoltageField;

        private bool mainsVoltageFieldSpecified;

        private byte measurementProtocolField;

        private bool measurementProtocolFieldSpecified;

        private long powerFrequencyField;

        private bool powerFrequencyFieldSpecified;

        private long rapidVoltageChangesField;

        private bool rapidVoltageChangesFieldSpecified;

        private long shortInterruptionsField;

        private bool shortInterruptionsFieldSpecified;

        private DateTimeInterval summaryIntervalField;

        private long supplyVoltageDipsField;

        private bool supplyVoltageDipsFieldSpecified;

        private long supplyVoltageImbalanceField;

        private bool supplyVoltageImbalanceFieldSpecified;

        private long supplyVoltageVariationsField;

        private bool supplyVoltageVariationsFieldSpecified;

        private long tempOvervoltageField;

        private bool tempOvervoltageFieldSpecified;

        /// <remarks/>
        public long flickerPlt
        {
            get
            {
                return this.flickerPltField;
            }
            set
            {
                this.flickerPltField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool flickerPltSpecified
        {
            get
            {
                return this.flickerPltFieldSpecified;
            }
            set
            {
                this.flickerPltFieldSpecified = value;
            }
        }

        /// <remarks/>
        public long flickerPst
        {
            get
            {
                return this.flickerPstField;
            }
            set
            {
                this.flickerPstField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool flickerPstSpecified
        {
            get
            {
                return this.flickerPstFieldSpecified;
            }
            set
            {
                this.flickerPstFieldSpecified = value;
            }
        }

        /// <remarks/>
        public long harmonicVoltage
        {
            get
            {
                return this.harmonicVoltageField;
            }
            set
            {
                this.harmonicVoltageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool harmonicVoltageSpecified
        {
            get
            {
                return this.harmonicVoltageFieldSpecified;
            }
            set
            {
                this.harmonicVoltageFieldSpecified = value;
            }
        }

        /// <remarks/>
        public long longInterruptions
        {
            get
            {
                return this.longInterruptionsField;
            }
            set
            {
                this.longInterruptionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool longInterruptionsSpecified
        {
            get
            {
                return this.longInterruptionsFieldSpecified;
            }
            set
            {
                this.longInterruptionsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public long mainsVoltage
        {
            get
            {
                return this.mainsVoltageField;
            }
            set
            {
                this.mainsVoltageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool mainsVoltageSpecified
        {
            get
            {
                return this.mainsVoltageFieldSpecified;
            }
            set
            {
                this.mainsVoltageFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte measurementProtocol
        {
            get
            {
                return this.measurementProtocolField;
            }
            set
            {
                this.measurementProtocolField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool measurementProtocolSpecified
        {
            get
            {
                return this.measurementProtocolFieldSpecified;
            }
            set
            {
                this.measurementProtocolFieldSpecified = value;
            }
        }

        /// <remarks/>
        public long powerFrequency
        {
            get
            {
                return this.powerFrequencyField;
            }
            set
            {
                this.powerFrequencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool powerFrequencySpecified
        {
            get
            {
                return this.powerFrequencyFieldSpecified;
            }
            set
            {
                this.powerFrequencyFieldSpecified = value;
            }
        }

        /// <remarks/>
        public long rapidVoltageChanges
        {
            get
            {
                return this.rapidVoltageChangesField;
            }
            set
            {
                this.rapidVoltageChangesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool rapidVoltageChangesSpecified
        {
            get
            {
                return this.rapidVoltageChangesFieldSpecified;
            }
            set
            {
                this.rapidVoltageChangesFieldSpecified = value;
            }
        }

        /// <remarks/>
        public long shortInterruptions
        {
            get
            {
                return this.shortInterruptionsField;
            }
            set
            {
                this.shortInterruptionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool shortInterruptionsSpecified
        {
            get
            {
                return this.shortInterruptionsFieldSpecified;
            }
            set
            {
                this.shortInterruptionsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public DateTimeInterval summaryInterval
        {
            get
            {
                return this.summaryIntervalField;
            }
            set
            {
                this.summaryIntervalField = value;
            }
        }

        /// <remarks/>
        public long supplyVoltageDips
        {
            get
            {
                return this.supplyVoltageDipsField;
            }
            set
            {
                this.supplyVoltageDipsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool supplyVoltageDipsSpecified
        {
            get
            {
                return this.supplyVoltageDipsFieldSpecified;
            }
            set
            {
                this.supplyVoltageDipsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public long supplyVoltageImbalance
        {
            get
            {
                return this.supplyVoltageImbalanceField;
            }
            set
            {
                this.supplyVoltageImbalanceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool supplyVoltageImbalanceSpecified
        {
            get
            {
                return this.supplyVoltageImbalanceFieldSpecified;
            }
            set
            {
                this.supplyVoltageImbalanceFieldSpecified = value;
            }
        }

        /// <remarks/>
        public long supplyVoltageVariations
        {
            get
            {
                return this.supplyVoltageVariationsField;
            }
            set
            {
                this.supplyVoltageVariationsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool supplyVoltageVariationsSpecified
        {
            get
            {
                return this.supplyVoltageVariationsFieldSpecified;
            }
            set
            {
                this.supplyVoltageVariationsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public long tempOvervoltage
        {
            get
            {
                return this.tempOvervoltageField;
            }
            set
            {
                this.tempOvervoltageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool tempOvervoltageSpecified
        {
            get
            {
                return this.tempOvervoltageFieldSpecified;
            }
            set
            {
                this.tempOvervoltageFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://naesb.org/espi", IsNullable = false)]
    public partial class UsagePoint : IdentifiedObject
    {

        private byte[] roleFlagsField;

        private ServiceCategory serviceCategoryField;

        private byte statusField;

        private bool statusFieldSpecified;

        private ServiceDeliveryPoint serviceDeliveryPointField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "hexBinary")]
        public byte[] roleFlags
        {
            get
            {
                return this.roleFlagsField;
            }
            set
            {
                this.roleFlagsField = value;
            }
        }

        /// <remarks/>
        public ServiceCategory ServiceCategory
        {
            get
            {
                return this.serviceCategoryField;
            }
            set
            {
                this.serviceCategoryField = value;
            }
        }

        /// <remarks/>
        public byte status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool statusSpecified
        {
            get
            {
                return this.statusFieldSpecified;
            }
            set
            {
                this.statusFieldSpecified = value;
            }
        }

        /// <remarks/>
        public ServiceDeliveryPoint ServiceDeliveryPoint
        {
            get
            {
                return this.serviceDeliveryPointField;
            }
            set
            {
                this.serviceDeliveryPointField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    public partial class ServiceCategory : Object
    {

        private string kindField;

        /// <remarks/>
        public string kind
        {
            get
            {
                return this.kindField;
            }
            set
            {
                this.kindField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    public partial class ServiceDeliveryPoint : Object
    {

        private string nameField;

        private string tariffProfileField;

        private string customerAgreementField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string tariffProfile
        {
            get
            {
                return this.tariffProfileField;
            }
            set
            {
                this.tariffProfileField = value;
            }
        }

        /// <remarks/>
        public string customerAgreement
        {
            get
            {
                return this.customerAgreementField;
            }
            set
            {
                this.customerAgreementField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://naesb.org/espi", IsNullable = false)]
    public partial class ReadingType : IdentifiedObject
    {

        private string accumulationBehaviourField;

        private string commodityField;

        private short consumptionTierField;

        private bool consumptionTierFieldSpecified;

        private string currencyField;

        private string dataQualifierField;

        private string defaultQualityField;

        private string flowDirectionField;

        private uint intervalLengthField;

        private bool intervalLengthFieldSpecified;

        private string kindField;

        private string phaseField;

        private string powerOfTenMultiplierField;

        private string timeAttributeField;

        private short touField;

        private bool touFieldSpecified;

        private string uomField;

        private short cppField;

        private bool cppFieldSpecified;

        private ReadingInterharmonic interharmonicField;

        private string measuringPeriodField;

        private RationalNumber argumentField;

        /// <remarks/>
        public string accumulationBehaviour
        {
            get
            {
                return this.accumulationBehaviourField;
            }
            set
            {
                this.accumulationBehaviourField = value;
            }
        }

        /// <remarks/>
        public string commodity
        {
            get
            {
                return this.commodityField;
            }
            set
            {
                this.commodityField = value;
            }
        }

        /// <remarks/>
        public short consumptionTier
        {
            get
            {
                return this.consumptionTierField;
            }
            set
            {
                this.consumptionTierField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool consumptionTierSpecified
        {
            get
            {
                return this.consumptionTierFieldSpecified;
            }
            set
            {
                this.consumptionTierFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        /// <remarks/>
        public string dataQualifier
        {
            get
            {
                return this.dataQualifierField;
            }
            set
            {
                this.dataQualifierField = value;
            }
        }

        /// <remarks/>
        public string defaultQuality
        {
            get
            {
                return this.defaultQualityField;
            }
            set
            {
                this.defaultQualityField = value;
            }
        }

        /// <remarks/>
        public string flowDirection
        {
            get
            {
                return this.flowDirectionField;
            }
            set
            {
                this.flowDirectionField = value;
            }
        }

        /// <remarks/>
        public uint intervalLength
        {
            get
            {
                return this.intervalLengthField;
            }
            set
            {
                this.intervalLengthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool intervalLengthSpecified
        {
            get
            {
                return this.intervalLengthFieldSpecified;
            }
            set
            {
                this.intervalLengthFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string kind
        {
            get
            {
                return this.kindField;
            }
            set
            {
                this.kindField = value;
            }
        }

        /// <remarks/>
        public string phase
        {
            get
            {
                return this.phaseField;
            }
            set
            {
                this.phaseField = value;
            }
        }

        /// <remarks/>
        public string powerOfTenMultiplier
        {
            get
            {
                return this.powerOfTenMultiplierField;
            }
            set
            {
                this.powerOfTenMultiplierField = value;
            }
        }

        /// <remarks/>
        public string timeAttribute
        {
            get
            {
                return this.timeAttributeField;
            }
            set
            {
                this.timeAttributeField = value;
            }
        }

        /// <remarks/>
        public short tou
        {
            get
            {
                return this.touField;
            }
            set
            {
                this.touField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool touSpecified
        {
            get
            {
                return this.touFieldSpecified;
            }
            set
            {
                this.touFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string uom
        {
            get
            {
                return this.uomField;
            }
            set
            {
                this.uomField = value;
            }
        }

        /// <remarks/>
        public short cpp
        {
            get
            {
                return this.cppField;
            }
            set
            {
                this.cppField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool cppSpecified
        {
            get
            {
                return this.cppFieldSpecified;
            }
            set
            {
                this.cppFieldSpecified = value;
            }
        }

        /// <remarks/>
        public ReadingInterharmonic interharmonic
        {
            get
            {
                return this.interharmonicField;
            }
            set
            {
                this.interharmonicField = value;
            }
        }

        /// <remarks/>
        public string measuringPeriod
        {
            get
            {
                return this.measuringPeriodField;
            }
            set
            {
                this.measuringPeriodField = value;
            }
        }

        /// <remarks/>
        public RationalNumber argument
        {
            get
            {
                return this.argumentField;
            }
            set
            {
                this.argumentField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://naesb.org/espi", IsNullable = false)]
    public partial class MeterReading : IdentifiedObject
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://naesb.org/espi", IsNullable = false)]
    public partial class IntervalBlock : IdentifiedObject
    {

        private DateTimeInterval intervalField;

        private IntervalReading[] intervalReadingField;

        /// <remarks/>
        public DateTimeInterval interval
        {
            get
            {
                return this.intervalField;
            }
            set
            {
                this.intervalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IntervalReading")]
        public IntervalReading[] IntervalReading
        {
            get
            {
                return this.intervalReadingField;
            }
            set
            {
                this.intervalReadingField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://naesb.org/espi", IsNullable = false)]
    public partial class IntervalReading : Object
    {

        private long costField;

        private bool costFieldSpecified;

        private ReadingQuality[] readingQualityField;

        private DateTimeInterval timePeriodField;

        private long valueField;

        private bool valueFieldSpecified;

        /// <remarks/>
        public long cost
        {
            get
            {
                return this.costField;
            }
            set
            {
                this.costField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool costSpecified
        {
            get
            {
                return this.costFieldSpecified;
            }
            set
            {
                this.costFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReadingQuality")]
        public ReadingQuality[] ReadingQuality
        {
            get
            {
                return this.readingQualityField;
            }
            set
            {
                this.readingQualityField = value;
            }
        }

        /// <remarks/>
        public DateTimeInterval timePeriod
        {
            get
            {
                return this.timePeriodField;
            }
            set
            {
                this.timePeriodField = value;
            }
        }

        /// <remarks/>
        public long value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool valueSpecified
        {
            get
            {
                return this.valueFieldSpecified;
            }
            set
            {
                this.valueFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://naesb.org/espi")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://naesb.org/espi", IsNullable = false)]
    public partial class ReadingQuality : Object
    {

        private string qualityField;

        /// <remarks/>
        public string quality
        {
            get
            {
                return this.qualityField;
            }
            set
            {
                this.qualityField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
    [System.Xml.Serialization.XmlRootAttribute("available", Namespace = "urn:ietf:params:xml:ns:icalendar-2.0", IsNullable = false)]
    public partial class AvailableType
    {

        private properties propertiesField;

        /// <remarks/>
        public properties properties
        {
            get
            {
                return this.propertiesField;
            }
            set
            {
                this.propertiesField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0", IsNullable = false)]
    public partial class properties
    {

        private dtstart dtstartField;

        private DurationPropType durationField;

        private propertiesTolerance toleranceField;

        private DurationPropType xeiNotificationField;

        private DurationPropType xeiRampUpField;

        private DurationPropType xeiRecoveryField;

        /// <remarks/>
        public dtstart dtstart
        {
            get
            {
                return this.dtstartField;
            }
            set
            {
                this.dtstartField = value;
            }
        }

        /// <remarks/>
        public DurationPropType duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }

        /// <remarks/>
        public propertiesTolerance tolerance
        {
            get
            {
                return this.toleranceField;
            }
            set
            {
                this.toleranceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("x-eiNotification", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public DurationPropType xeiNotification
        {
            get
            {
                return this.xeiNotificationField;
            }
            set
            {
                this.xeiNotificationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("x-eiRampUp", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public DurationPropType xeiRampUp
        {
            get
            {
                return this.xeiRampUpField;
            }
            set
            {
                this.xeiRampUpField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("x-eiRecovery", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public DurationPropType xeiRecovery
        {
            get
            {
                return this.xeiRecoveryField;
            }
            set
            {
                this.xeiRecoveryField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0", IsNullable = false)]
    public partial class dtstart
    {

        private System.DateTime datetimeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("date-time")]
        public System.DateTime datetime
        {
            get
            {
                return this.datetimeField;
            }
            set
            {
                this.datetimeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
    [System.Xml.Serialization.XmlRootAttribute("oadrRequestedOadrPollFreq", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class DurationPropType
    {

        private string durationField;

        /// <remarks/>
        public string duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
    public partial class propertiesTolerance
    {

        private propertiesToleranceTolerate tolerateField;

        /// <remarks/>
        public propertiesToleranceTolerate tolerate
        {
            get
            {
                return this.tolerateField;
            }
            set
            {
                this.tolerateField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
    public partial class propertiesToleranceTolerate
    {

        private string startafterField;

        /// <remarks/>
        public string startafter
        {
            get
            {
                return this.startafterField;
            }
            set
            {
                this.startafterField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
    [System.Xml.Serialization.XmlRootAttribute("vavailability", Namespace = "urn:ietf:params:xml:ns:icalendar-2.0", IsNullable = false)]
    public partial class VavailabilityType
    {

        private AvailableType[] componentsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("available", IsNullable = false)]
        public AvailableType[] components
        {
            get
            {
                return this.componentsField;
            }
            set
            {
                this.componentsField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(oadrCreateOptType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    public partial class EiOptType
    {

        private string optIDField;

        private OptTypeType optTypeField;

        private string optReasonField;

        private string marketContextField;

        private string venIDField;

        private VavailabilityType vavailabilityField;

        private System.DateTime createdDateTimeField;

        private string schemaVersionField;

        /// <remarks/>
        public string optID
        {
            get
            {
                return this.optIDField;
            }
            set
            {
                this.optIDField = value;
            }
        }

        /// <remarks/>
        public OptTypeType optType
        {
            get
            {
                return this.optTypeField;
            }
            set
            {
                this.optTypeField = value;
            }
        }

        /// <remarks/>
        public string optReason
        {
            get
            {
                return this.optReasonField;
            }
            set
            {
                this.optReasonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06", DataType = "anyURI")]
        public string marketContext
        {
            get
            {
                return this.marketContextField;
            }
            set
            {
                this.marketContextField = value;
            }
        }

        /// <remarks/>
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
        public VavailabilityType vavailability
        {
            get
            {
                return this.vavailabilityField;
            }
            set
            {
                this.vavailabilityField = value;
            }
        }

        /// <remarks/>
        public System.DateTime createdDateTime
        {
            get
            {
                return this.createdDateTimeField;
            }
            set
            {
                this.createdDateTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("optType", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public enum OptTypeType
    {

        /// <remarks/>
        optIn,

        /// <remarks/>
        optOut,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("eiEventBaseline", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public partial class eiEventBaselineType
    {

        private dtstart dtstartField;

        private DurationPropType durationField;

        private IntervalType[] intervalsField;

        private string baselineIDField;

        private string[] resourceIDField;

        private string baselineNameField;

        private ItemBaseType itemBaseField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
        public dtstart dtstart
        {
            get
            {
                return this.dtstartField;
            }
            set
            {
                this.dtstartField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
        public DurationPropType duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0:stream")]
        [System.Xml.Serialization.XmlArrayItemAttribute("interval", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
        public IntervalType[] intervals
        {
            get
            {
                return this.intervalsField;
            }
            set
            {
                this.intervalsField = value;
            }
        }

        /// <remarks/>
        public string baselineID
        {
            get
            {
                return this.baselineIDField;
            }
            set
            {
                this.baselineIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("resourceID")]
        public string[] resourceID
        {
            get
            {
                return this.resourceIDField;
            }
            set
            {
                this.resourceIDField = value;
            }
        }

        /// <remarks/>
        public string baselineName
        {
            get
            {
                return this.baselineNameField;
            }
            set
            {
                this.baselineNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06")]
        public ItemBaseType itemBase
        {
            get
            {
                return this.itemBaseField;
            }
            set
            {
                this.itemBaseField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("interval", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public partial class IntervalType
    {

        private dtstart dtstartField;

        private DurationPropType durationField;

        private object itemField;

        private StreamPayloadBaseType[] streamPayloadBaseField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
        public dtstart dtstart
        {
            get
            {
                return this.dtstartField;
            }
            set
            {
                this.dtstartField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
        public DurationPropType duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("refID", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("uid", typeof(IntervalTypeUidUid), Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("streamPayloadBase", Namespace = "urn:ietf:params:xml:ns:icalendar-2.0:stream")]
        [System.Xml.Serialization.XmlElementAttribute("oadrReportPayload", typeof(oadrReportPayloadType), Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
        [System.Xml.Serialization.XmlElementAttribute("signalPayload", typeof(signalPayloadType), Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        [System.Xml.Serialization.XmlElementAttribute("oadrGBPayload", typeof(oadrGBStreamPayloadBase), Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
        public StreamPayloadBaseType[] streamPayloadBase
        {
            get
            {
                return this.streamPayloadBaseField;
            }
            set
            {
                this.streamPayloadBaseField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
    [System.Xml.Serialization.XmlRootAttribute("uid", Namespace = "urn:ietf:params:xml:ns:icalendar-2.0", IsNullable = false)]
    public partial class IntervalTypeUidUid
    {

        private string textField;

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ReportPayloadType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(oadrReportPayloadType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(signalPayloadType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(oadrGBStreamPayloadBase))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0:stream")]
    public abstract partial class StreamPayloadBaseType
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(oadrReportPayloadType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    public partial class ReportPayloadType : StreamPayloadBaseType
    {

        private string rIDField;

        private uint confidenceField;

        private bool confidenceFieldSpecified;

        private float accuracyField;

        private bool accuracyFieldSpecified;

        // private PayloadFloatType itemField;
        private PayloadBaseType itemField;

        /// <remarks/>
        public string rID
        {
            get
            {
                return this.rIDField;
            }
            set
            {
                this.rIDField = value;
            }
        }

        /// <remarks/>
        public uint confidence
        {
            get
            {
                return this.confidenceField;
            }
            set
            {
                this.confidenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool confidenceSpecified
        {
            get
            {
                return this.confidenceFieldSpecified;
            }
            set
            {
                this.confidenceFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float accuracy
        {
            get
            {
                return this.accuracyField;
            }
            set
            {
                this.accuracyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool accuracySpecified
        {
            get
            {
                return this.accuracyFieldSpecified;
            }
            set
            {
                this.accuracyFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("payloadFloat", typeof(PayloadFloatType), Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        [System.Xml.Serialization.XmlElementAttribute("oadrPayloadResourceStatus", typeof(oadrPayloadResourceStatusType), Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
        public PayloadBaseType Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("payloadFloat", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public partial class PayloadFloatType : PayloadBaseType
    {

        private float valueField;

        /// <remarks/>
        public float value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PayloadFloatType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(oadrPayloadResourceStatusType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    public abstract partial class PayloadBaseType
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("signalPayload", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public partial class signalPayloadType : StreamPayloadBaseType
    {

        private PayloadBaseType itemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("payloadBase", typeof(PayloadBaseType))]
        [System.Xml.Serialization.XmlElementAttribute("payloadFloat", typeof(PayloadFloatType))]
        public PayloadBaseType Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PowerItemType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PowerRealType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PowerReactiveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PowerApparentType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EnergyItemType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EnergyRealType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EnergyReactiveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EnergyApparentType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(VoltageType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(oadrGBItemBase))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(pulseCountType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(temperatureType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ThermType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FrequencyType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(currencyType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(currencyPerKWhType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(currencyPerKWType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CurrentType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BaseUnitType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06")]
    public abstract partial class ItemBaseType
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PowerRealType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PowerReactiveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PowerApparentType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
    [System.Xml.Serialization.XmlRootAttribute("powerItem", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power", IsNullable = false)]
    public abstract partial class PowerItemType : ItemBaseType
    {

        private string itemDescriptionField;

        private string itemUnitsField;

        private SiScaleCodeType siScaleCodeField;

        private PowerAttributesType powerAttributesField;

        /// <remarks/>
        public string itemDescription
        {
            get
            {
                return this.itemDescriptionField;
            }
            set
            {
                this.itemDescriptionField = value;
            }
        }

        /// <remarks/>
        public string itemUnits
        {
            get
            {
                return this.itemUnitsField;
            }
            set
            {
                this.itemUnitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/siscale")]
        public SiScaleCodeType siScaleCode
        {
            get
            {
                return this.siScaleCodeField;
            }
            set
            {
                this.siScaleCodeField = value;
            }
        }

        /// <remarks/>
        public PowerAttributesType powerAttributes
        {
            get
            {
                return this.powerAttributesField;
            }
            set
            {
                this.powerAttributesField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/siscale")]
    [System.Xml.Serialization.XmlRootAttribute("siScaleCode", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/siscale", IsNullable = false)]
    public enum SiScaleCodeType
    {

        /// <remarks/>
        p,

        /// <remarks/>
        n,

        /// <remarks/>
        micro,

        /// <remarks/>
        m,

        /// <remarks/>
        c,

        /// <remarks/>
        d,

        /// <remarks/>
        k,

        /// <remarks/>
        M,

        /// <remarks/>
        G,

        /// <remarks/>
        T,

        /// <remarks/>
        none,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
    [System.Xml.Serialization.XmlRootAttribute("powerAttributes", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power", IsNullable = false)]
    public partial class PowerAttributesType
    {

        private decimal hertzField;

        private decimal voltageField;

        private bool acField;

        /// <remarks/>
        public decimal hertz
        {
            get
            {
                return this.hertzField;
            }
            set
            {
                this.hertzField = value;
            }
        }

        /// <remarks/>
        public decimal voltage
        {
            get
            {
                return this.voltageField;
            }
            set
            {
                this.voltageField = value;
            }
        }

        /// <remarks/>
        public bool ac
        {
            get
            {
                return this.acField;
            }
            set
            {
                this.acField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
    [System.Xml.Serialization.XmlRootAttribute("powerReal", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power", IsNullable = false)]
    public partial class PowerRealType : PowerItemType
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
    [System.Xml.Serialization.XmlRootAttribute("powerReactive", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power", IsNullable = false)]
    public partial class PowerReactiveType : PowerItemType
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
    [System.Xml.Serialization.XmlRootAttribute("powerApparent", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power", IsNullable = false)]
    public partial class PowerApparentType : PowerItemType
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EnergyRealType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EnergyReactiveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EnergyApparentType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
    [System.Xml.Serialization.XmlRootAttribute("energyItem", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power", IsNullable = false)]
    public abstract partial class EnergyItemType : ItemBaseType
    {

        private string itemDescriptionField;

        private string itemUnitsField;

        private SiScaleCodeType siScaleCodeField;

        /// <remarks/>
        public string itemDescription
        {
            get
            {
                return this.itemDescriptionField;
            }
            set
            {
                this.itemDescriptionField = value;
            }
        }

        /// <remarks/>
        public string itemUnits
        {
            get
            {
                return this.itemUnitsField;
            }
            set
            {
                this.itemUnitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/siscale")]
        public SiScaleCodeType siScaleCode
        {
            get
            {
                return this.siScaleCodeField;
            }
            set
            {
                this.siScaleCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
    [System.Xml.Serialization.XmlRootAttribute("energyReal", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power", IsNullable = false)]
    public partial class EnergyRealType : EnergyItemType
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
    [System.Xml.Serialization.XmlRootAttribute("energyReactive", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power", IsNullable = false)]
    public partial class EnergyReactiveType : EnergyItemType
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
    [System.Xml.Serialization.XmlRootAttribute("energyApparent", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power", IsNullable = false)]
    public partial class EnergyApparentType : EnergyItemType
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
    [System.Xml.Serialization.XmlRootAttribute("voltage", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power", IsNullable = false)]
    public partial class VoltageType : ItemBaseType
    {

        private string itemDescriptionField;

        private string itemUnitsField;

        private SiScaleCodeType siScaleCodeField;

        public VoltageType()
        {
            this.itemDescriptionField = "Voltage";
            this.itemUnitsField = "V";
        }

        /// <remarks/>
        public string itemDescription
        {
            get
            {
                return this.itemDescriptionField;
            }
            set
            {
                this.itemDescriptionField = value;
            }
        }

        /// <remarks/>
        public string itemUnits
        {
            get
            {
                return this.itemUnitsField;
            }
            set
            {
                this.itemUnitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/siscale")]
        public SiScaleCodeType siScaleCode
        {
            get
            {
                return this.siScaleCodeField;
            }
            set
            {
                this.siScaleCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("eiEventSignals", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public partial class eiEventSignalsType
    {

        private eiEventSignalType[] eiEventSignalField;

        private eiEventBaselineType eiEventBaselineField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("eiEventSignal")]
        public eiEventSignalType[] eiEventSignal
        {
            get
            {
                return this.eiEventSignalField;
            }
            set
            {
                this.eiEventSignalField = value;
            }
        }

        /// <remarks/>
        public eiEventBaselineType eiEventBaseline
        {
            get
            {
                return this.eiEventBaselineField;
            }
            set
            {
                this.eiEventBaselineField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("eiEventSignal", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public partial class eiEventSignalType
    {

        private IntervalType[] intervalsField;

        private EiTargetType eiTargetField;

        private string signalNameField;

        private SignalTypeEnumeratedType signalTypeField;

        private string signalIDField;

        private ItemBaseType itemBaseField;

        private currentValueType currentValueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0:stream")]
        [System.Xml.Serialization.XmlArrayItemAttribute("interval", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
        public IntervalType[] intervals
        {
            get
            {
                return this.intervalsField;
            }
            set
            {
                this.intervalsField = value;
            }
        }

        /// <remarks/>
        public EiTargetType eiTarget
        {
            get
            {
                return this.eiTargetField;
            }
            set
            {
                this.eiTargetField = value;
            }
        }

        /// <remarks/>
        public string signalName
        {
            get
            {
                return this.signalNameField;
            }
            set
            {
                this.signalNameField = value;
            }
        }

        /// <remarks/>
        public SignalTypeEnumeratedType signalType
        {
            get
            {
                return this.signalTypeField;
            }
            set
            {
                this.signalTypeField = value;
            }
        }

        /// <remarks/>
        public string signalID
        {
            get
            {
                return this.signalIDField;
            }
            set
            {
                this.signalIDField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("energyApparent", typeof(EnergyApparentType), Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
        [System.Xml.Serialization.XmlElementAttribute("energyReactive", typeof(EnergyReactiveType), Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
        [System.Xml.Serialization.XmlElementAttribute("energyReal", typeof(EnergyRealType), Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
        [System.Xml.Serialization.XmlElementAttribute("powerApparent", typeof(PowerApparentType), Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
        [System.Xml.Serialization.XmlElementAttribute("powerReactive", typeof(PowerReactiveType), Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
        [System.Xml.Serialization.XmlElementAttribute("powerReal", typeof(PowerRealType), Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]        
        [System.Xml.Serialization.XmlElementAttribute("currency", typeof(currencyType), Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
        [System.Xml.Serialization.XmlElementAttribute("currencyPerKWh", typeof(currencyPerKWhType), Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
        [System.Xml.Serialization.XmlElementAttribute("currencyPerKW", typeof(currencyPerKWType), Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
        public ItemBaseType itemBase
        {
            get
            {
                return this.itemBaseField;
            }
            set
            {
                this.itemBaseField = value;
            }
        }

        /// <remarks/>
        public currentValueType currentValue
        {
            get
            {
                return this.currentValueField;
            }
            set
            {
                this.currentValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("oadrDeviceClass", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class EiTargetType
    {

        private AggregatedPnodeType[] aggregatedPnodeField;

        private EndDeviceAssetType[] endDeviceAssetField;

        private MeterAssetType[] meterAssetField;

        private PnodeType[] pnodeField;

        private ServiceAreaType[] serviceAreaField;

        private ServiceDeliveryPointType[] serviceDeliveryPointField;

        private ServiceLocationType[] serviceLocationField;

        private TransportInterfaceType[] transportInterfaceField;

        private string[] groupIDField;

        private string[] groupNameField;

        private string[] resourceIDField;

        private string[] venIDField;

        private string[] partyIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("aggregatedPnode", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
        public AggregatedPnodeType[] aggregatedPnode
        {
            get
            {
                return this.aggregatedPnodeField;
            }
            set
            {
                this.aggregatedPnodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("endDeviceAsset", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
        public EndDeviceAssetType[] endDeviceAsset
        {
            get
            {
                return this.endDeviceAssetField;
            }
            set
            {
                this.endDeviceAssetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("meterAsset", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
        public MeterAssetType[] meterAsset
        {
            get
            {
                return this.meterAssetField;
            }
            set
            {
                this.meterAssetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("pnode", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
        public PnodeType[] pnode
        {
            get
            {
                return this.pnodeField;
            }
            set
            {
                this.pnodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("serviceArea", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06")]
        public ServiceAreaType[] serviceArea
        {
            get
            {
                return this.serviceAreaField;
            }
            set
            {
                this.serviceAreaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("serviceDeliveryPoint", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
        public ServiceDeliveryPointType[] serviceDeliveryPoint
        {
            get
            {
                return this.serviceDeliveryPointField;
            }
            set
            {
                this.serviceDeliveryPointField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("serviceLocation", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
        public ServiceLocationType[] serviceLocation
        {
            get
            {
                return this.serviceLocationField;
            }
            set
            {
                this.serviceLocationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("transportInterface", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
        public TransportInterfaceType[] transportInterface
        {
            get
            {
                return this.transportInterfaceField;
            }
            set
            {
                this.transportInterfaceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("groupID")]
        public string[] groupID
        {
            get
            {
                return this.groupIDField;
            }
            set
            {
                this.groupIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("groupName")]
        public string[] groupName
        {
            get
            {
                return this.groupNameField;
            }
            set
            {
                this.groupNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("resourceID")]
        public string[] resourceID
        {
            get
            {
                return this.resourceIDField;
            }
            set
            {
                this.resourceIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("venID")]
        public string[] venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("partyID")]
        public string[] partyID
        {
            get
            {
                return this.partyIDField;
            }
            set
            {
                this.partyIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
    [System.Xml.Serialization.XmlRootAttribute("aggregatedPnode", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power", IsNullable = false)]
    public partial class AggregatedPnodeType
    {

        private string nodeField;

        /// <remarks/>
        public string node
        {
            get
            {
                return this.nodeField;
            }
            set
            {
                this.nodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
    [System.Xml.Serialization.XmlRootAttribute("endDeviceAsset", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power", IsNullable = false)]
    public partial class EndDeviceAssetType
    {

        private string mridField;

        /// <remarks/>
        public string mrid
        {
            get
            {
                return this.mridField;
            }
            set
            {
                this.mridField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
    [System.Xml.Serialization.XmlRootAttribute("meterAsset", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power", IsNullable = false)]
    public partial class MeterAssetType
    {

        private string mridField;

        /// <remarks/>
        public string mrid
        {
            get
            {
                return this.mridField;
            }
            set
            {
                this.mridField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
    [System.Xml.Serialization.XmlRootAttribute("pnode", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power", IsNullable = false)]
    public partial class PnodeType
    {

        private string nodeField;

        /// <remarks/>
        public string node
        {
            get
            {
                return this.nodeField;
            }
            set
            {
                this.nodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06")]
    [System.Xml.Serialization.XmlRootAttribute("serviceArea", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06", IsNullable = false)]
    public partial class ServiceAreaType
    {

        private FeatureCollection featureCollectionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.opengis.net/gml/3.2")]
        public FeatureCollection FeatureCollection
        {
            get
            {
                return this.featureCollectionField;
            }
            set
            {
                this.featureCollectionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opengis.net/gml/3.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.opengis.net/gml/3.2", IsNullable = false)]
    public partial class FeatureCollection
    {

        private FeatureCollectionLocation locationField;

        private string idField;

        /// <remarks/>
        public FeatureCollectionLocation location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, DataType = "ID")]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opengis.net/gml/3.2")]
    public partial class FeatureCollectionLocation
    {

        private FeatureCollectionLocationPolygon polygonField;

        /// <remarks/>
        public FeatureCollectionLocationPolygon Polygon
        {
            get
            {
                return this.polygonField;
            }
            set
            {
                this.polygonField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opengis.net/gml/3.2")]
    public partial class FeatureCollectionLocationPolygon
    {

        private FeatureCollectionLocationPolygonExterior exteriorField;

        private string idField;

        /// <remarks/>
        public FeatureCollectionLocationPolygonExterior exterior
        {
            get
            {
                return this.exteriorField;
            }
            set
            {
                this.exteriorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, DataType = "ID")]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opengis.net/gml/3.2")]
    public partial class FeatureCollectionLocationPolygonExterior
    {

        private FeatureCollectionLocationPolygonExteriorLinearRing linearRingField;

        /// <remarks/>
        public FeatureCollectionLocationPolygonExteriorLinearRing LinearRing
        {
            get
            {
                return this.linearRingField;
            }
            set
            {
                this.linearRingField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opengis.net/gml/3.2")]
    public partial class FeatureCollectionLocationPolygonExteriorLinearRing
    {

        private string posListField;

        /// <remarks/>
        public string posList
        {
            get
            {
                return this.posListField;
            }
            set
            {
                this.posListField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
    [System.Xml.Serialization.XmlRootAttribute("serviceDeliveryPoint", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power", IsNullable = false)]
    public partial class ServiceDeliveryPointType
    {

        private string nodeField;

        /// <remarks/>
        public string node
        {
            get
            {
                return this.nodeField;
            }
            set
            {
                this.nodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
    [System.Xml.Serialization.XmlRootAttribute("serviceLocation", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power", IsNullable = false)]
    public partial class ServiceLocationType
    {

        private FeatureCollection featureCollectionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.opengis.net/gml/3.2")]
        public FeatureCollection FeatureCollection
        {
            get
            {
                return this.featureCollectionField;
            }
            set
            {
                this.featureCollectionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
    [System.Xml.Serialization.XmlRootAttribute("transportInterface", Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power", IsNullable = false)]
    public partial class TransportInterfaceType
    {

        private string pointOfReceiptField;

        private string pointOfDeliveryField;

        /// <remarks/>
        public string pointOfReceipt
        {
            get
            {
                return this.pointOfReceiptField;
            }
            set
            {
                this.pointOfReceiptField = value;
            }
        }

        /// <remarks/>
        public string pointOfDelivery
        {
            get
            {
                return this.pointOfDeliveryField;
            }
            set
            {
                this.pointOfDeliveryField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("signalType", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public enum SignalTypeEnumeratedType
    {

        /// <remarks/>
        delta,

        /// <remarks/>
        level,

        /// <remarks/>
        multiplier,

        /// <remarks/>
        price,

        /// <remarks/>
        priceMultiplier,

        /// <remarks/>
        priceRelative,

        /// <remarks/>
        setpoint,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("x-loadControlCapacity")]
        xloadControlCapacity,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("x-loadControlLevelOffset")]
        xloadControlLevelOffset,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("x-loadControlPercentOffset")]
        xloadControlPercentOffset,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("x-loadControlSetpoint")]
        xloadControlSetpoint,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("currentValue", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public partial class currentValueType
    {

        private PayloadFloatType itemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("payloadFloat")]
        public PayloadFloatType Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom")]
    public partial class sourceType
    {

        private object[] itemsField;

        private ItemsChoiceType6[] itemsElementNameField;

        private string baseField;

        private string langField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("author", typeof(personType))]
        [System.Xml.Serialization.XmlElementAttribute("category", typeof(categoryType))]
        [System.Xml.Serialization.XmlElementAttribute("contributor", typeof(personType))]
        [System.Xml.Serialization.XmlElementAttribute("generator", typeof(generatorType))]
        [System.Xml.Serialization.XmlElementAttribute("icon", typeof(iconType))]
        [System.Xml.Serialization.XmlElementAttribute("id", typeof(idType))]
        [System.Xml.Serialization.XmlElementAttribute("link", typeof(linkType))]
        [System.Xml.Serialization.XmlElementAttribute("logo", typeof(logoType))]
        [System.Xml.Serialization.XmlElementAttribute("rights", typeof(textType))]
        [System.Xml.Serialization.XmlElementAttribute("subtitle", typeof(textType))]
        [System.Xml.Serialization.XmlElementAttribute("title", typeof(textType))]
        [System.Xml.Serialization.XmlElementAttribute("updated", typeof(dateTimeType))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType6[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string @base
        {
            get
            {
                return this.baseField;
            }
            set
            {
                this.baseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom")]
    public partial class personType
    {

        private object[] itemsField;

        private ItemsChoiceType3[] itemsElementNameField;

        private string baseField;

        private string langField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("email", typeof(string), DataType = "normalizedString")]
        [System.Xml.Serialization.XmlElementAttribute("name", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("uri", typeof(uriType))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType3[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string @base
        {
            get
            {
                return this.baseField;
            }
            set
            {
                this.baseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom")]
    public partial class uriType
    {

        private string baseField;

        private string langField;

        private System.Xml.XmlAttribute[] anyAttrField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string @base
        {
            get
            {
                return this.baseField;
            }
            set
            {
                this.baseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "anyURI")]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom", IncludeInSchema = false)]
    public enum ItemsChoiceType3
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("##any:")]
        Item,

        /// <remarks/>
        email,

        /// <remarks/>
        name,

        /// <remarks/>
        uri,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom")]
    public partial class categoryType
    {

        private string termField;

        private string schemeField;

        private string labelField;

        private string baseField;

        private string langField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string term
        {
            get
            {
                return this.termField;
            }
            set
            {
                this.termField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string scheme
        {
            get
            {
                return this.schemeField;
            }
            set
            {
                this.schemeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string @base
        {
            get
            {
                return this.baseField;
            }
            set
            {
                this.baseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom")]
    public partial class generatorType
    {

        private string uriField;

        private string versionField;

        private string baseField;

        private string langField;

        private System.Xml.XmlAttribute[] anyAttrField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string uri
        {
            get
            {
                return this.uriField;
            }
            set
            {
                this.uriField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string @base
        {
            get
            {
                return this.baseField;
            }
            set
            {
                this.baseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom")]
    public partial class iconType
    {

        private string baseField;

        private string langField;

        private System.Xml.XmlAttribute[] anyAttrField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string @base
        {
            get
            {
                return this.baseField;
            }
            set
            {
                this.baseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "anyURI")]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom")]
    public partial class idType
    {

        private string baseField;

        private string langField;

        private System.Xml.XmlAttribute[] anyAttrField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string @base
        {
            get
            {
                return this.baseField;
            }
            set
            {
                this.baseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "anyURI")]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom")]
    public partial class linkType
    {

        private string hrefField;

        private string relField;

        private string typeField;

        private string hreflangField;

        private string titleField;

        private string lengthField;

        private string baseField;

        private string langField;

        private System.Xml.XmlAttribute[] anyAttrField;

        private string[] textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string href
        {
            get
            {
                return this.hrefField;
            }
            set
            {
                this.hrefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string rel
        {
            get
            {
                return this.relField;
            }
            set
            {
                this.relField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string hreflang
        {
            get
            {
                return this.hreflangField;
            }
            set
            {
                this.hreflangField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        public string length
        {
            get
            {
                return this.lengthField;
            }
            set
            {
                this.lengthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string @base
        {
            get
            {
                return this.baseField;
            }
            set
            {
                this.baseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom")]
    public partial class logoType
    {

        private string baseField;

        private string langField;

        private System.Xml.XmlAttribute[] anyAttrField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string @base
        {
            get
            {
                return this.baseField;
            }
            set
            {
                this.baseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "anyURI")]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom")]
    public partial class textType
    {

        private System.Xml.XmlNode[] anyField;

        private textTypeType typeField;

        private bool typeFieldSpecified;

        private string baseField;

        private string langField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlNode[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public textTypeType type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool typeSpecified
        {
            get
            {
                return this.typeFieldSpecified;
            }
            set
            {
                this.typeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string @base
        {
            get
            {
                return this.baseField;
            }
            set
            {
                this.baseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
    public enum textTypeType
    {

        /// <remarks/>
        text,

        /// <remarks/>
        html,

        /// <remarks/>
        xhtml,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom")]
    public partial class dateTimeType
    {

        private string baseField;

        private string langField;

        private System.Xml.XmlAttribute[] anyAttrField;

        private System.DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string @base
        {
            get
            {
                return this.baseField;
            }
            set
            {
                this.baseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public System.DateTime Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom", IncludeInSchema = false)]
    public enum ItemsChoiceType6
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("##any:")]
        Item,

        /// <remarks/>
        author,

        /// <remarks/>
        category,

        /// <remarks/>
        contributor,

        /// <remarks/>
        generator,

        /// <remarks/>
        icon,

        /// <remarks/>
        id,

        /// <remarks/>
        link,

        /// <remarks/>
        logo,

        /// <remarks/>
        rights,

        /// <remarks/>
        subtitle,

        /// <remarks/>
        title,

        /// <remarks/>
        updated,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    public partial class oadrLoadControlStateTypeType
    {

        private float oadrMinField;

        private bool oadrMinFieldSpecified;

        private float oadrMaxField;

        private bool oadrMaxFieldSpecified;

        private float oadrCurrentField;

        private float oadrNormalField;

        private bool oadrNormalFieldSpecified;

        /// <remarks/>
        public float oadrMin
        {
            get
            {
                return this.oadrMinField;
            }
            set
            {
                this.oadrMinField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool oadrMinSpecified
        {
            get
            {
                return this.oadrMinFieldSpecified;
            }
            set
            {
                this.oadrMinFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float oadrMax
        {
            get
            {
                return this.oadrMaxField;
            }
            set
            {
                this.oadrMaxField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool oadrMaxSpecified
        {
            get
            {
                return this.oadrMaxFieldSpecified;
            }
            set
            {
                this.oadrMaxFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float oadrCurrent
        {
            get
            {
                return this.oadrCurrentField;
            }
            set
            {
                this.oadrCurrentField = value;
            }
        }

        /// <remarks/>
        public float oadrNormal
        {
            get
            {
                return this.oadrNormalField;
            }
            set
            {
                this.oadrNormalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool oadrNormalSpecified
        {
            get
            {
                return this.oadrNormalFieldSpecified;
            }
            set
            {
                this.oadrNormalFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(oadrReportType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0:stream")]
    public abstract partial class StreamBaseType
    {

        private dtstart dtstartField;

        private DurationPropType durationField;

        private IntervalType[] intervalsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
        public dtstart dtstart
        {
            get
            {
                return this.dtstartField;
            }
            set
            {
                this.dtstartField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
        public DurationPropType duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("interval", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
        public IntervalType[] intervals
        {
            get
            {
                return this.intervalsField;
            }
            set
            {
                this.intervalsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom")]
    public partial class contentType
    {

        private System.Xml.XmlNode[] anyField;

        private string typeField;

        private string srcField;

        private string baseField;

        private string langField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlNode[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string src
        {
            get
            {
                return this.srcField;
            }
            set
            {
                this.srcField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string @base
        {
            get
            {
                return this.baseField;
            }
            set
            {
                this.baseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom")]
    [System.Xml.Serialization.XmlRootAttribute("entry", Namespace = "http://www.w3.org/2005/Atom", IsNullable = false)]
    public partial class entryType
    {

        private object[] itemsField;

        private ItemsChoiceType4[] itemsElementNameField;

        private string baseField;

        private string langField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("author", typeof(personType))]
        [System.Xml.Serialization.XmlElementAttribute("category", typeof(categoryType))]
        [System.Xml.Serialization.XmlElementAttribute("content", typeof(contentType))]
        [System.Xml.Serialization.XmlElementAttribute("contributor", typeof(personType))]
        [System.Xml.Serialization.XmlElementAttribute("id", typeof(idType))]
        [System.Xml.Serialization.XmlElementAttribute("link", typeof(linkType))]
        [System.Xml.Serialization.XmlElementAttribute("published", typeof(dateTimeType))]
        [System.Xml.Serialization.XmlElementAttribute("rights", typeof(textType))]
        [System.Xml.Serialization.XmlElementAttribute("source", typeof(textType))]
        [System.Xml.Serialization.XmlElementAttribute("summary", typeof(textType))]
        [System.Xml.Serialization.XmlElementAttribute("title", typeof(textType))]
        [System.Xml.Serialization.XmlElementAttribute("updated", typeof(dateTimeType))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType4[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string @base
        {
            get
            {
                return this.baseField;
            }
            set
            {
                this.baseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom", IncludeInSchema = false)]
    public enum ItemsChoiceType4
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("##any:")]
        Item,

        /// <remarks/>
        author,

        /// <remarks/>
        category,

        /// <remarks/>
        content,

        /// <remarks/>
        contributor,

        /// <remarks/>
        id,

        /// <remarks/>
        link,

        /// <remarks/>
        published,

        /// <remarks/>
        rights,

        /// <remarks/>
        source,

        /// <remarks/>
        summary,

        /// <remarks/>
        title,

        /// <remarks/>
        updated,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom")]
    [System.Xml.Serialization.XmlRootAttribute("feed", Namespace = "http://www.w3.org/2005/Atom", IsNullable = false)]
    public partial class feedType
    {

        private object[] itemsField;

        private ItemsChoiceType5[] itemsElementNameField;

        private string baseField;

        private string langField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("author", typeof(personType))]
        [System.Xml.Serialization.XmlElementAttribute("category", typeof(categoryType))]
        [System.Xml.Serialization.XmlElementAttribute("contributor", typeof(personType))]
        [System.Xml.Serialization.XmlElementAttribute("entry", typeof(entryType))]
        [System.Xml.Serialization.XmlElementAttribute("generator", typeof(generatorType))]
        [System.Xml.Serialization.XmlElementAttribute("icon", typeof(iconType))]
        [System.Xml.Serialization.XmlElementAttribute("id", typeof(idType))]
        [System.Xml.Serialization.XmlElementAttribute("link", typeof(linkType))]
        [System.Xml.Serialization.XmlElementAttribute("logo", typeof(logoType))]
        [System.Xml.Serialization.XmlElementAttribute("rights", typeof(textType))]
        [System.Xml.Serialization.XmlElementAttribute("subtitle", typeof(textType))]
        [System.Xml.Serialization.XmlElementAttribute("title", typeof(textType))]
        [System.Xml.Serialization.XmlElementAttribute("updated", typeof(dateTimeType))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType5[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string @base
        {
            get
            {
                return this.baseField;
            }
            set
            {
                this.baseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/Atom", IncludeInSchema = false)]
    public enum ItemsChoiceType5
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("##any:")]
        Item,

        /// <remarks/>
        author,

        /// <remarks/>
        category,

        /// <remarks/>
        contributor,

        /// <remarks/>
        entry,

        /// <remarks/>
        generator,

        /// <remarks/>
        icon,

        /// <remarks/>
        id,

        /// <remarks/>
        link,

        /// <remarks/>
        logo,

        /// <remarks/>
        rights,

        /// <remarks/>
        subtitle,

        /// <remarks/>
        title,

        /// <remarks/>
        updated,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("specifierPayload", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public partial class SpecifierPayloadType
    {

        private string rIDField;

        private ItemBaseType itemBaseField;

        private string readingTypeField;

        /// <remarks/>
        public string rID
        {
            get
            {
                return this.rIDField;
            }
            set
            {
                this.rIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06")]
        public ItemBaseType itemBase
        {
            get
            {
                return this.itemBaseField;
            }
            set
            {
                this.itemBaseField = value;
            }
        }

        /// <remarks/>
        public string readingType
        {
            get
            {
                return this.readingTypeField;
            }
            set
            {
                this.readingTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
    [System.Xml.Serialization.XmlRootAttribute("interval", Namespace = "urn:ietf:params:xml:ns:icalendar-2.0", IsNullable = false)]
    public partial class WsCalendarIntervalType
    {

        private properties propertiesField;

        /// <remarks/>
        public properties properties
        {
            get
            {
                return this.propertiesField;
            }
            set
            {
                this.propertiesField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("reportSpecifier", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public partial class ReportSpecifierType
    {

        private string reportSpecifierIDField;

        private DurationPropType granularityField;

        private DurationPropType reportBackDurationField;

        private WsCalendarIntervalType reportIntervalField;

        private SpecifierPayloadType[] specifierPayloadField;

        /// <remarks/>
        public string reportSpecifierID
        {
            get
            {
                return this.reportSpecifierIDField;
            }
            set
            {
                this.reportSpecifierIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
        public DurationPropType granularity
        {
            get
            {
                return this.granularityField;
            }
            set
            {
                this.granularityField = value;
            }
        }

        /// <remarks/>
        public DurationPropType reportBackDuration
        {
            get
            {
                return this.reportBackDurationField;
            }
            set
            {
                this.reportBackDurationField = value;
            }
        }

        /// <remarks/>
        public WsCalendarIntervalType reportInterval
        {
            get
            {
                return this.reportIntervalField;
            }
            set
            {
                this.reportIntervalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("specifierPayload")]
        public SpecifierPayloadType[] specifierPayload
        {
            get
            {
                return this.specifierPayloadField;
            }
            set
            {
                this.specifierPayloadField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("qualifiedEventID", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public partial class QualifiedEventIDType
    {

        private string eventIDField;

        private uint modificationNumberField;

        /// <remarks/>
        public string eventID
        {
            get
            {
                return this.eventIDField;
            }
            set
            {
                this.eventIDField = value;
            }
        }

        /// <remarks/>
        public uint modificationNumber
        {
            get
            {
                return this.modificationNumberField;
            }
            set
            {
                this.modificationNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("eiActivePeriod", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public partial class eiActivePeriodType
    {

        private properties propertiesField;

        private object componentsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
        public properties properties
        {
            get
            {
                return this.propertiesField;
            }
            set
            {
                this.propertiesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0", IsNullable = true)]
        public object components
        {
            get
            {
                return this.componentsField;
            }
            set
            {
                this.componentsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("eventDescriptor", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public partial class eventDescriptorType
    {

        private string eventIDField;

        private uint modificationNumberField;

        private System.DateTime modificationDateTimeField;

        private bool modificationDateTimeFieldSpecified;

        private string modificationReasonField;

        private uint priorityField;

        private bool priorityFieldSpecified;

        private eventDescriptorTypeEiMarketContext eiMarketContextField;

        private System.DateTime createdDateTimeField;

        private EventStatusEnumeratedType eventStatusField;

        private string testEventField;

        private string vtnCommentField;

        /// <remarks/>
        public string eventID
        {
            get
            {
                return this.eventIDField;
            }
            set
            {
                this.eventIDField = value;
            }
        }

        /// <remarks/>
        public uint modificationNumber
        {
            get
            {
                return this.modificationNumberField;
            }
            set
            {
                this.modificationNumberField = value;
            }
        }

        /// <remarks/>
        public System.DateTime modificationDateTime
        {
            get
            {
                return this.modificationDateTimeField;
            }
            set
            {
                this.modificationDateTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool modificationDateTimeSpecified
        {
            get
            {
                return this.modificationDateTimeFieldSpecified;
            }
            set
            {
                this.modificationDateTimeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string modificationReason
        {
            get
            {
                return this.modificationReasonField;
            }
            set
            {
                this.modificationReasonField = value;
            }
        }

        /// <remarks/>
        public uint priority
        {
            get
            {
                return this.priorityField;
            }
            set
            {
                this.priorityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool prioritySpecified
        {
            get
            {
                return this.priorityFieldSpecified;
            }
            set
            {
                this.priorityFieldSpecified = value;
            }
        }

        /// <remarks/>
        public eventDescriptorTypeEiMarketContext eiMarketContext
        {
            get
            {
                return this.eiMarketContextField;
            }
            set
            {
                this.eiMarketContextField = value;
            }
        }

        /// <remarks/>
        public System.DateTime createdDateTime
        {
            get
            {
                return this.createdDateTimeField;
            }
            set
            {
                this.createdDateTimeField = value;
            }
        }

        /// <remarks/>
        public EventStatusEnumeratedType eventStatus
        {
            get
            {
                return this.eventStatusField;
            }
            set
            {
                this.eventStatusField = value;
            }
        }

        /// <remarks/>
        public string testEvent
        {
            get
            {
                return this.testEventField;
            }
            set
            {
                this.testEventField = value;
            }
        }

        /// <remarks/>
        public string vtnComment
        {
            get
            {
                return this.vtnCommentField;
            }
            set
            {
                this.vtnCommentField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    public partial class eventDescriptorTypeEiMarketContext
    {

        private string marketContextField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06", DataType = "anyURI")]
        public string marketContext
        {
            get
            {
                return this.marketContextField;
            }
            set
            {
                this.marketContextField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("eventStatus", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public enum EventStatusEnumeratedType
    {

        /// <remarks/>
        none,

        /// <remarks/>
        far,

        /// <remarks/>
        near,

        /// <remarks/>
        active,

        /// <remarks/>
        completed,

        /// <remarks/>
        cancelled,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("eiEvent", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public partial class eiEventType
    {

        private eventDescriptorType eventDescriptorField;

        private eiActivePeriodType eiActivePeriodField;

        private eiEventSignalsType eiEventSignalsField;

        private EiTargetType eiTargetField;

        /// <remarks/>
        public eventDescriptorType eventDescriptor
        {
            get
            {
                return this.eventDescriptorField;
            }
            set
            {
                this.eventDescriptorField = value;
            }
        }

        /// <remarks/>
        public eiActivePeriodType eiActivePeriod
        {
            get
            {
                return this.eiActivePeriodField;
            }
            set
            {
                this.eiActivePeriodField = value;
            }
        }

        /// <remarks/>
        public eiEventSignalsType eiEventSignals
        {
            get
            {
                return this.eiEventSignalsField;
            }
            set
            {
                this.eiEventSignalsField = value;
            }
        }

        /// <remarks/>
        public EiTargetType eiTarget
        {
            get
            {
                return this.eiTargetField;
            }
            set
            {
                this.eiTargetField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("eiResponse", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public partial class EiResponseType
    {

        private string responseCodeField;

        private string responseDescriptionField;

        private string requestIDField;

        /// <remarks/>
        public string responseCode
        {
            get
            {
                return this.responseCodeField;
            }
            set
            {
                this.responseCodeField = value;
            }
        }

        /// <remarks/>
        public string responseDescription
        {
            get
            {
                return this.responseDescriptionField;
            }
            set
            {
                this.responseDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public string requestID
        {
            get
            {
                return this.requestIDField;
            }
            set
            {
                this.requestIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("Object", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class ObjectType
    {

        private System.Xml.XmlNode[] anyField;

        private string idField;

        private string mimeTypeField;

        private string encodingField;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlNode[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MimeType
        {
            get
            {
                return this.mimeTypeField;
            }
            set
            {
                this.mimeTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Encoding
        {
            get
            {
                return this.encodingField;
            }
            set
            {
                this.encodingField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("SPKIData", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class SPKIDataType
    {

        private byte[][] sPKISexpField;

        private System.Xml.XmlElement anyField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SPKISexp", DataType = "base64Binary")]
        public byte[][] SPKISexp
        {
            get
            {
                return this.sPKISexpField;
            }
            set
            {
                this.sPKISexpField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("PGPData", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class PGPDataType
    {

        private object[] itemsField;

        private ItemsChoiceType1[] itemsElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("PGPKeyID", typeof(byte[]), DataType = "base64Binary")]
        [System.Xml.Serialization.XmlElementAttribute("PGPKeyPacket", typeof(byte[]), DataType = "base64Binary")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType1[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("##any:")]
        Item,

        /// <remarks/>
        PGPKeyID,

        /// <remarks/>
        PGPKeyPacket,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class X509IssuerSerialType
    {

        private string x509IssuerNameField;

        private string x509SerialNumberField;

        /// <remarks/>
        public string X509IssuerName
        {
            get
            {
                return this.x509IssuerNameField;
            }
            set
            {
                this.x509IssuerNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string X509SerialNumber
        {
            get
            {
                return this.x509SerialNumberField;
            }
            set
            {
                this.x509SerialNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("X509Data", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class X509DataType
    {

        private object[] itemsField;

        private ItemsChoiceType[] itemsElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("X509CRL", typeof(byte[]), DataType = "base64Binary")]
        [System.Xml.Serialization.XmlElementAttribute("X509Certificate", typeof(byte[]), DataType = "base64Binary")]
        [System.Xml.Serialization.XmlElementAttribute("X509IssuerSerial", typeof(X509IssuerSerialType))]
        [System.Xml.Serialization.XmlElementAttribute("X509SKI", typeof(byte[]), DataType = "base64Binary")]
        [System.Xml.Serialization.XmlElementAttribute("X509SubjectName", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("##any:")]
        Item,

        /// <remarks/>
        X509CRL,

        /// <remarks/>
        X509Certificate,

        /// <remarks/>
        X509IssuerSerial,

        /// <remarks/>
        X509SKI,

        /// <remarks/>
        X509SubjectName,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("RetrievalMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class RetrievalMethodType
    {

        private TransformType[] transformsField;

        private string uRIField;

        private string typeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Transform", IsNullable = false)]
        public TransformType[] Transforms
        {
            get
            {
                return this.transformsField;
            }
            set
            {
                this.transformsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string URI
        {
            get
            {
                return this.uRIField;
            }
            set
            {
                this.uRIField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("RSAKeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class RSAKeyValueType
    {

        private byte[] modulusField;

        private byte[] exponentField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] Modulus
        {
            get
            {
                return this.modulusField;
            }
            set
            {
                this.modulusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] Exponent
        {
            get
            {
                return this.exponentField;
            }
            set
            {
                this.exponentField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("DSAKeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class DSAKeyValueType
    {

        private byte[] pField;

        private byte[] qField;

        private byte[] gField;

        private byte[] yField;

        private byte[] jField;

        private byte[] seedField;

        private byte[] pgenCounterField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] P
        {
            get
            {
                return this.pField;
            }
            set
            {
                this.pField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] Q
        {
            get
            {
                return this.qField;
            }
            set
            {
                this.qField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] G
        {
            get
            {
                return this.gField;
            }
            set
            {
                this.gField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] Y
        {
            get
            {
                return this.yField;
            }
            set
            {
                this.yField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] J
        {
            get
            {
                return this.jField;
            }
            set
            {
                this.jField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] Seed
        {
            get
            {
                return this.seedField;
            }
            set
            {
                this.seedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] PgenCounter
        {
            get
            {
                return this.pgenCounterField;
            }
            set
            {
                this.pgenCounterField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("KeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class KeyValueType
    {

        private object itemField;

        private string[] textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("DSAKeyValue", typeof(DSAKeyValueType))]
        [System.Xml.Serialization.XmlElementAttribute("RSAKeyValue", typeof(RSAKeyValueType))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("KeyInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class KeyInfoType
    {

        private object[] itemsField;

        private ItemsChoiceType2[] itemsElementNameField;

        private string[] textField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("KeyName", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("KeyValue", typeof(KeyValueType))]
        [System.Xml.Serialization.XmlElementAttribute("MgmtData", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("PGPData", typeof(PGPDataType))]
        [System.Xml.Serialization.XmlElementAttribute("RetrievalMethod", typeof(RetrievalMethodType))]
        [System.Xml.Serialization.XmlElementAttribute("SPKIData", typeof(SPKIDataType))]
        [System.Xml.Serialization.XmlElementAttribute("X509Data", typeof(X509DataType))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType2[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
    public enum ItemsChoiceType2
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("##any:")]
        Item,

        /// <remarks/>
        KeyName,

        /// <remarks/>
        KeyValue,

        /// <remarks/>
        MgmtData,

        /// <remarks/>
        PGPData,

        /// <remarks/>
        RetrievalMethod,

        /// <remarks/>
        SPKIData,

        /// <remarks/>
        X509Data,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("SignatureValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class SignatureValueType
    {

        private string idField;

        private byte[] valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "base64Binary")]
        public byte[] Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("SignatureMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class SignatureMethodType
    {

        private string hMACOutputLengthField;

        private System.Xml.XmlNode[] anyField;

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string HMACOutputLength
        {
            get
            {
                return this.hMACOutputLengthField;
            }
            set
            {
                this.hMACOutputLengthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlNode[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrSignedObject
    {

        private object itemField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("oadrCancelOpt", typeof(oadrCancelOptType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrCancelPartyRegistration", typeof(oadrCancelPartyRegistrationType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrCancelReport", typeof(oadrCancelReportType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrCanceledOpt", typeof(oadrCanceledOptType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrCanceledPartyRegistration", typeof(oadrCanceledPartyRegistrationType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrCanceledReport", typeof(oadrCanceledReportType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrCreateOpt", typeof(oadrCreateOptType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrCreatePartyRegistration", typeof(oadrCreatePartyRegistrationType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrCreateReport", typeof(oadrCreateReportType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrCreatedEvent", typeof(oadrCreatedEventType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrCreatedOpt", typeof(oadrCreatedOptType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrCreatedPartyRegistration", typeof(oadrCreatedPartyRegistrationType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrCreatedReport", typeof(oadrCreatedReportType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrDistributeEvent", typeof(oadrDistributeEventType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrPoll", typeof(oadrPollType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrQueryRegistration", typeof(oadrQueryRegistrationType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrRegisterReport", typeof(oadrRegisterReportType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrRegisteredReport", typeof(oadrRegisteredReportType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrRequestEvent", typeof(oadrRequestEventType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrRequestReregistration", typeof(oadrRequestReregistrationType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrResponse", typeof(oadrResponseType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrUpdateReport", typeof(oadrUpdateReportType))]
        [System.Xml.Serialization.XmlElementAttribute("oadrUpdatedReport", typeof(oadrUpdatedReportType))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrCancelOpt", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrCancelOptType
    {

        private string requestIDField;

        private string optIDField;

        private string venIDField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public string requestID
        {
            get
            {
                return this.requestIDField;
            }
            set
            {
                this.requestIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string optID
        {
            get
            {
                return this.optIDField;
            }
            set
            {
                this.optIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrCancelPartyRegistration", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrCancelPartyRegistrationType
    {

        private string requestIDField;

        private string registrationIDField;

        private string venIDField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public string requestID
        {
            get
            {
                return this.requestIDField;
            }
            set
            {
                this.requestIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string registrationID
        {
            get
            {
                return this.registrationIDField;
            }
            set
            {
                this.registrationIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrCancelReport", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrCancelReportType
    {

        private string requestIDField;

        private string[] reportRequestIDField;

        private bool reportToFollowField;

        private string venIDField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public string requestID
        {
            get
            {
                return this.requestIDField;
            }
            set
            {
                this.requestIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("reportRequestID", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string[] reportRequestID
        {
            get
            {
                return this.reportRequestIDField;
            }
            set
            {
                this.reportRequestIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public bool reportToFollow
        {
            get
            {
                return this.reportToFollowField;
            }
            set
            {
                this.reportToFollowField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrCanceledOpt", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrCanceledOptType
    {

        private EiResponseType eiResponseField;

        private string optIDField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public EiResponseType eiResponse
        {
            get
            {
                return this.eiResponseField;
            }
            set
            {
                this.eiResponseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string optID
        {
            get
            {
                return this.optIDField;
            }
            set
            {
                this.optIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrCanceledPartyRegistration", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrCanceledPartyRegistrationType
    {

        private EiResponseType eiResponseField;

        private string registrationIDField;

        private string venIDField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public EiResponseType eiResponse
        {
            get
            {
                return this.eiResponseField;
            }
            set
            {
                this.eiResponseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string registrationID
        {
            get
            {
                return this.registrationIDField;
            }
            set
            {
                this.registrationIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrCanceledReport", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrCanceledReportType
    {

        private EiResponseType eiResponseField;

        private string[] oadrPendingReportsField;

        private string venIDField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public EiResponseType eiResponse
        {
            get
            {
                return this.eiResponseField;
            }
            set
            {
                this.eiResponseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("reportRequestID", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
        public string[] oadrPendingReports
        {
            get
            {
                return this.oadrPendingReportsField;
            }
            set
            {
                this.oadrPendingReportsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrCreateOpt", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrCreateOptType : EiOptType
    {

        private string requestIDField;

        private QualifiedEventIDType qualifiedEventIDField;

        private EiTargetType eiTargetField;

        private EiTargetType oadrDeviceClassField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public string requestID
        {
            get
            {
                return this.requestIDField;
            }
            set
            {
                this.requestIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public QualifiedEventIDType qualifiedEventID
        {
            get
            {
                return this.qualifiedEventIDField;
            }
            set
            {
                this.qualifiedEventIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public EiTargetType eiTarget
        {
            get
            {
                return this.eiTargetField;
            }
            set
            {
                this.eiTargetField = value;
            }
        }

        /// <remarks/>
        public EiTargetType oadrDeviceClass
        {
            get
            {
                return this.oadrDeviceClassField;
            }
            set
            {
                this.oadrDeviceClassField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrCreatePartyRegistration", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrCreatePartyRegistrationType
    {

        private string requestIDField;

        private string registrationIDField;

        private string venIDField;

        private oadrProfileType oadrProfileNameField;

        private oadrTransportType oadrTransportNameField;

        private string oadrTransportAddressField;

        private bool oadrReportOnlyField;

        private bool oadrXmlSignatureField;

        private string oadrVenNameField;

        private bool oadrHttpPullModelField;

        private bool oadrHttpPullModelFieldSpecified;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public string requestID
        {
            get
            {
                return this.requestIDField;
            }
            set
            {
                this.requestIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string registrationID
        {
            get
            {
                return this.registrationIDField;
            }
            set
            {
                this.registrationIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        public oadrProfileType oadrProfileName
        {
            get
            {
                return this.oadrProfileNameField;
            }
            set
            {
                this.oadrProfileNameField = value;
            }
        }

        /// <remarks/>
        public oadrTransportType oadrTransportName
        {
            get
            {
                return this.oadrTransportNameField;
            }
            set
            {
                this.oadrTransportNameField = value;
            }
        }

        /// <remarks/>
        public string oadrTransportAddress
        {
            get
            {
                return this.oadrTransportAddressField;
            }
            set
            {
                this.oadrTransportAddressField = value;
            }
        }

        /// <remarks/>
        public bool oadrReportOnly
        {
            get
            {
                return this.oadrReportOnlyField;
            }
            set
            {
                this.oadrReportOnlyField = value;
            }
        }

        /// <remarks/>
        public bool oadrXmlSignature
        {
            get
            {
                return this.oadrXmlSignatureField;
            }
            set
            {
                this.oadrXmlSignatureField = value;
            }
        }

        /// <remarks/>
        public string oadrVenName
        {
            get
            {
                return this.oadrVenNameField;
            }
            set
            {
                this.oadrVenNameField = value;
            }
        }

        /// <remarks/>
        public bool oadrHttpPullModel
        {
            get
            {
                return this.oadrHttpPullModelField;
            }
            set
            {
                this.oadrHttpPullModelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool oadrHttpPullModelSpecified
        {
            get
            {
                return this.oadrHttpPullModelFieldSpecified;
            }
            set
            {
                this.oadrHttpPullModelFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrProfileName", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public enum oadrProfileType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2.0a")]
        Item20a,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2.0b")]
        Item20b,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrTransportName", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public enum oadrTransportType
    {

        /// <remarks/>
        simpleHttp,

        /// <remarks/>
        xmpp,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrCreateReport", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrCreateReportType
    {

        private string requestIDField;

        private oadrReportRequestType[] oadrReportRequestField;

        private string venIDField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public string requestID
        {
            get
            {
                return this.requestIDField;
            }
            set
            {
                this.requestIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("oadrReportRequest")]
        public oadrReportRequestType[] oadrReportRequest
        {
            get
            {
                return this.oadrReportRequestField;
            }
            set
            {
                this.oadrReportRequestField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrReportRequest", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrReportRequestType
    {

        private string reportRequestIDField;

        private ReportSpecifierType reportSpecifierField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string reportRequestID
        {
            get
            {
                return this.reportRequestIDField;
            }
            set
            {
                this.reportRequestIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public ReportSpecifierType reportSpecifier
        {
            get
            {
                return this.reportSpecifierField;
            }
            set
            {
                this.reportSpecifierField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrCreatedEvent", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrCreatedEventType
    {

        private eiCreatedEvent eiCreatedEventField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public eiCreatedEvent eiCreatedEvent
        {
            get
            {
                return this.eiCreatedEventField;
            }
            set
            {
                this.eiCreatedEventField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads", IsNullable = false)]
    public partial class eiCreatedEvent
    {

        private EiResponseType eiResponseField;

        private eventResponsesEventResponse[] eventResponsesField;

        private string venIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public EiResponseType eiResponse
        {
            get
            {
                return this.eiResponseField;
            }
            set
            {
                this.eiResponseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        [System.Xml.Serialization.XmlArrayItemAttribute("eventResponse", IsNullable = false)]
        public eventResponsesEventResponse[] eventResponses
        {
            get
            {
                return this.eventResponsesField;
            }
            set
            {
                this.eventResponsesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    public partial class eventResponsesEventResponse
    {

        private string responseCodeField;

        private string responseDescriptionField;

        private string requestIDField;

        private QualifiedEventIDType qualifiedEventIDField;

        private OptTypeType optTypeField;

        /// <remarks/>
        public string responseCode
        {
            get
            {
                return this.responseCodeField;
            }
            set
            {
                this.responseCodeField = value;
            }
        }

        /// <remarks/>
        public string responseDescription
        {
            get
            {
                return this.responseDescriptionField;
            }
            set
            {
                this.responseDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public string requestID
        {
            get
            {
                return this.requestIDField;
            }
            set
            {
                this.requestIDField = value;
            }
        }

        /// <remarks/>
        public QualifiedEventIDType qualifiedEventID
        {
            get
            {
                return this.qualifiedEventIDField;
            }
            set
            {
                this.qualifiedEventIDField = value;
            }
        }

        /// <remarks/>
        public OptTypeType optType
        {
            get
            {
                return this.optTypeField;
            }
            set
            {
                this.optTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrCreatedOpt", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrCreatedOptType
    {

        private EiResponseType eiResponseField;

        private string optIDField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public EiResponseType eiResponse
        {
            get
            {
                return this.eiResponseField;
            }
            set
            {
                this.eiResponseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string optID
        {
            get
            {
                return this.optIDField;
            }
            set
            {
                this.optIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrCreatedPartyRegistration", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrCreatedPartyRegistrationType
    {

        private EiResponseType eiResponseField;

        private string registrationIDField;

        private string venIDField;

        private string vtnIDField;

        private oadrProfilesOadrProfile[] oadrProfilesField;

        private DurationPropType oadrRequestedOadrPollFreqField;

        private oadrServiceSpecificInfoOadrService[] oadrServiceSpecificInfoField;

        private oadrCreatedPartyRegistrationTypeOadrExtension[] oadrExtensionsField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public EiResponseType eiResponse
        {
            get
            {
                return this.eiResponseField;
            }
            set
            {
                this.eiResponseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string registrationID
        {
            get
            {
                return this.registrationIDField;
            }
            set
            {
                this.registrationIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string vtnID
        {
            get
            {
                return this.vtnIDField;
            }
            set
            {
                this.vtnIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("oadrProfile", IsNullable = false)]
        public oadrProfilesOadrProfile[] oadrProfiles
        {
            get
            {
                return this.oadrProfilesField;
            }
            set
            {
                this.oadrProfilesField = value;
            }
        }

        /// <remarks/>
        public DurationPropType oadrRequestedOadrPollFreq
        {
            get
            {
                return this.oadrRequestedOadrPollFreqField;
            }
            set
            {
                this.oadrRequestedOadrPollFreqField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("oadrService", IsNullable = false)]
        public oadrServiceSpecificInfoOadrService[] oadrServiceSpecificInfo
        {
            get
            {
                return this.oadrServiceSpecificInfoField;
            }
            set
            {
                this.oadrServiceSpecificInfoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("oadrExtension", IsNullable = false)]
        public oadrCreatedPartyRegistrationTypeOadrExtension[] oadrExtensions
        {
            get
            {
                return this.oadrExtensionsField;
            }
            set
            {
                this.oadrExtensionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    public partial class oadrProfilesOadrProfile
    {

        private oadrProfileType oadrProfileNameField;

        private oadrTransportsOadrTransport[] oadrTransportsField;

        /// <remarks/>
        public oadrProfileType oadrProfileName
        {
            get
            {
                return this.oadrProfileNameField;
            }
            set
            {
                this.oadrProfileNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("oadrTransport", IsNullable = false)]
        public oadrTransportsOadrTransport[] oadrTransports
        {
            get
            {
                return this.oadrTransportsField;
            }
            set
            {
                this.oadrTransportsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    public partial class oadrTransportsOadrTransport
    {

        private oadrTransportType oadrTransportNameField;

        /// <remarks/>
        public oadrTransportType oadrTransportName
        {
            get
            {
                return this.oadrTransportNameField;
            }
            set
            {
                this.oadrTransportNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    public partial class oadrServiceSpecificInfoOadrService
    {

        private oadrServiceNameType oadrServiceNameField;

        private oadrInfo[] oadrInfoField;

        /// <remarks/>
        public oadrServiceNameType oadrServiceName
        {
            get
            {
                return this.oadrServiceNameField;
            }
            set
            {
                this.oadrServiceNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("oadrInfo")]
        public oadrInfo[] oadrInfo
        {
            get
            {
                return this.oadrInfoField;
            }
            set
            {
                this.oadrInfoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrServiceName", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public enum oadrServiceNameType
    {

        /// <remarks/>
        EiEvent,

        /// <remarks/>
        EiOpt,

        /// <remarks/>
        EiReport,

        /// <remarks/>
        EiRegisterParty,

        /// <remarks/>
        OadrPoll,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrInfo
    {

        private string oadrKeyField;

        private string oadrValueField;

        /// <remarks/>
        public string oadrKey
        {
            get
            {
                return this.oadrKeyField;
            }
            set
            {
                this.oadrKeyField = value;
            }
        }

        /// <remarks/>
        public string oadrValue
        {
            get
            {
                return this.oadrValueField;
            }
            set
            {
                this.oadrValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    public partial class oadrCreatedPartyRegistrationTypeOadrExtension
    {

        private string oadrExtensionNameField;

        private oadrInfo[] oadrInfoField;

        /// <remarks/>
        public string oadrExtensionName
        {
            get
            {
                return this.oadrExtensionNameField;
            }
            set
            {
                this.oadrExtensionNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("oadrInfo")]
        public oadrInfo[] oadrInfo
        {
            get
            {
                return this.oadrInfoField;
            }
            set
            {
                this.oadrInfoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrCreatedReport", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrCreatedReportType
    {

        private EiResponseType eiResponseField;

        private string[] oadrPendingReportsField;

        private string venIDField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public EiResponseType eiResponse
        {
            get
            {
                return this.eiResponseField;
            }
            set
            {
                this.eiResponseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("reportRequestID", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
        public string[] oadrPendingReports
        {
            get
            {
                return this.oadrPendingReportsField;
            }
            set
            {
                this.oadrPendingReportsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrDistributeEvent", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrDistributeEventType
    {

        private EiResponseType eiResponseField;

        private string requestIDField;

        private string vtnIDField;

        private oadrDistributeEventTypeOadrEvent[] oadrEventField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public EiResponseType eiResponse
        {
            get
            {
                return this.eiResponseField;
            }
            set
            {
                this.eiResponseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public string requestID
        {
            get
            {
                return this.requestIDField;
            }
            set
            {
                this.requestIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string vtnID
        {
            get
            {
                return this.vtnIDField;
            }
            set
            {
                this.vtnIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("oadrEvent")]
        public oadrDistributeEventTypeOadrEvent[] oadrEvent
        {
            get
            {
                return this.oadrEventField;
            }
            set
            {
                this.oadrEventField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    public partial class oadrDistributeEventTypeOadrEvent
    {

        private eiEventType eiEventField;

        private ResponseRequiredType oadrResponseRequiredField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public eiEventType eiEvent
        {
            get
            {
                return this.eiEventField;
            }
            set
            {
                this.eiEventField = value;
            }
        }

        /// <remarks/>
        public ResponseRequiredType oadrResponseRequired
        {
            get
            {
                return this.oadrResponseRequiredField;
            }
            set
            {
                this.oadrResponseRequiredField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrResponseRequired", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public enum ResponseRequiredType
    {

        /// <remarks/>
        always,

        /// <remarks/>
        never,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrPoll", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrPollType
    {

        private string venIDField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrQueryRegistration", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrQueryRegistrationType
    {

        private string requestIDField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public string requestID
        {
            get
            {
                return this.requestIDField;
            }
            set
            {
                this.requestIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrRegisterReport", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrRegisterReportType
    {

        private string requestIDField;

        private oadrReportType[] oadrReportField;

        private string venIDField;

        private string reportRequestIDField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public string requestID
        {
            get
            {
                return this.requestIDField;
            }
            set
            {
                this.requestIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("oadrReport")]
        public oadrReportType[] oadrReport
        {
            get
            {
                return this.oadrReportField;
            }
            set
            {
                this.oadrReportField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string reportRequestID
        {
            get
            {
                return this.reportRequestIDField;
            }
            set
            {
                this.reportRequestIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrReport", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrReportType : StreamBaseType
    {

        private string eiReportIDField;

        private oadrReportDescriptionType[] oadrReportDescriptionField;

        private string reportRequestIDField;

        private string reportSpecifierIDField;

        private string reportNameField;

        private System.DateTime createdDateTimeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string eiReportID
        {
            get
            {
                return this.eiReportIDField;
            }
            set
            {
                this.eiReportIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("oadrReportDescription")]
        public oadrReportDescriptionType[] oadrReportDescription
        {
            get
            {
                return this.oadrReportDescriptionField;
            }
            set
            {
                this.oadrReportDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string reportRequestID
        {
            get
            {
                return this.reportRequestIDField;
            }
            set
            {
                this.reportRequestIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string reportSpecifierID
        {
            get
            {
                return this.reportSpecifierIDField;
            }
            set
            {
                this.reportSpecifierIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string reportName
        {
            get
            {
                return this.reportNameField;
            }
            set
            {
                this.reportNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public System.DateTime createdDateTime
        {
            get
            {
                return this.createdDateTimeField;
            }
            set
            {
                this.createdDateTimeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrReportDescription", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrReportDescriptionType
    {

        private string rIDField;

        private EiTargetType reportSubjectField;

        private EiTargetType reportDataSourceField;

        private ReportEnumeratedType reportTypeField;

        private ItemBaseType itemBaseField;

        private ReadingTypeEnumeratedType readingTypeField;

        private string marketContextField;

        private oadrSamplingRateType oadrSamplingRateField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string rID
        {
            get
            {
                return this.rIDField;
            }
            set
            {
                this.rIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public EiTargetType reportSubject
        {
            get
            {
                return this.reportSubjectField;
            }
            set
            {
                this.reportSubjectField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public EiTargetType reportDataSource
        {
            get
            {
                return this.reportDataSourceField;
            }
            set
            {
                this.reportDataSourceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public ReportEnumeratedType reportType
        {
            get
            {
                return this.reportTypeField;
            }
            set
            {
                this.reportTypeField = value;
            }
        }

        /// <remarks/>
        // [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06")]        
        [System.Xml.Serialization.XmlElementAttribute("energyApparent", typeof(EnergyApparentType), Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
        [System.Xml.Serialization.XmlElementAttribute("energyReactive", typeof(EnergyReactiveType), Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
        [System.Xml.Serialization.XmlElementAttribute("energyReal", typeof(EnergyRealType), Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
        [System.Xml.Serialization.XmlElementAttribute("powerApparent", typeof(PowerApparentType), Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]
        [System.Xml.Serialization.XmlElementAttribute("powerReactive", typeof(PowerReactiveType), Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]        
        [System.Xml.Serialization.XmlElementAttribute("powerReal", typeof(PowerRealType), Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/power")]        
        public ItemBaseType itemBase
        {
            get
            {
                return this.itemBaseField;
            }
            set
            {
                this.itemBaseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public ReadingTypeEnumeratedType readingType
        {
            get
            {
                return this.readingTypeField;
            }
            set
            {
                this.readingTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06", DataType = "anyURI")]
        public string marketContext
        {
            get
            {
                return this.marketContextField;
            }
            set
            {
                this.marketContextField = value;
            }
        }

        /// <remarks/>
        public oadrSamplingRateType oadrSamplingRate
        {
            get
            {
                return this.oadrSamplingRateField;
            }
            set
            {
                this.oadrSamplingRateField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrSamplingRate", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrSamplingRateType
    {

        private string oadrMinPeriodField;

        private string oadrMaxPeriodField;

        private bool oadrOnChangeField;

        /// <remarks/>
        public string oadrMinPeriod
        {
            get
            {
                return this.oadrMinPeriodField;
            }
            set
            {
                this.oadrMinPeriodField = value;
            }
        }

        /// <remarks/>
        public string oadrMaxPeriod
        {
            get
            {
                return this.oadrMaxPeriodField;
            }
            set
            {
                this.oadrMaxPeriodField = value;
            }
        }

        /// <remarks/>
        public bool oadrOnChange
        {
            get
            {
                return this.oadrOnChangeField;
            }
            set
            {
                this.oadrOnChangeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrRegisteredReport", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrRegisteredReportType
    {

        private EiResponseType eiResponseField;

        private oadrReportRequestType[] oadrReportRequestField;

        private string venIDField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public EiResponseType eiResponse
        {
            get
            {
                return this.eiResponseField;
            }
            set
            {
                this.eiResponseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("oadrReportRequest")]
        public oadrReportRequestType[] oadrReportRequest
        {
            get
            {
                return this.oadrReportRequestField;
            }
            set
            {
                this.oadrReportRequestField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrRequestEvent", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrRequestEventType
    {

        private eiRequestEvent eiRequestEventField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public eiRequestEvent eiRequestEvent
        {
            get
            {
                return this.eiRequestEventField;
            }
            set
            {
                this.eiRequestEventField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads", IsNullable = false)]
    public partial class eiRequestEvent
    {

        private string requestIDField;

        private string venIDField;

        private uint replyLimitField;

        private bool replyLimitFieldSpecified;

        /// <remarks/>
        public string requestID
        {
            get
            {
                return this.requestIDField;
            }
            set
            {
                this.requestIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        public uint replyLimit
        {
            get
            {
                return this.replyLimitField;
            }
            set
            {
                this.replyLimitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool replyLimitSpecified
        {
            get
            {
                return this.replyLimitFieldSpecified;
            }
            set
            {
                this.replyLimitFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrRequestReregistration", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrRequestReregistrationType
    {

        private string venIDField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrResponse", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrResponseType
    {

        private EiResponseType eiResponseField;

        private string venIDField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public EiResponseType eiResponse
        {
            get
            {
                return this.eiResponseField;
            }
            set
            {
                this.eiResponseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrUpdateReport", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrUpdateReportType
    {

        private string requestIDField;

        private oadrReportType[] oadrReportField;

        private string venIDField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public string requestID
        {
            get
            {
                return this.requestIDField;
            }
            set
            {
                this.requestIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("oadrReport")]
        public oadrReportType[] oadrReport
        {
            get
            {
                return this.oadrReportField;
            }
            set
            {
                this.oadrReportField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrUpdatedReport", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrUpdatedReportType
    {

        private EiResponseType eiResponseField;

        private oadrCancelReportType oadrCancelReportField;

        private string venIDField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public EiResponseType eiResponse
        {
            get
            {
                return this.eiResponseField;
            }
            set
            {
                this.eiResponseField = value;
            }
        }

        /// <remarks/>
        public oadrCancelReportType oadrCancelReport
        {
            get
            {
                return this.oadrCancelReportField;
            }
            set
            {
                this.oadrCancelReportField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID
        {
            get
            {
                return this.venIDField;
            }
            set
            {
                this.venIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrProfiles
    {

        private oadrProfilesOadrProfile[] oadrProfileField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("oadrProfile")]
        public oadrProfilesOadrProfile[] oadrProfile
        {
            get
            {
                return this.oadrProfileField;
            }
            set
            {
                this.oadrProfileField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrTransports
    {

        private oadrTransportsOadrTransport[] oadrTransportField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("oadrTransport")]
        public oadrTransportsOadrTransport[] oadrTransport
        {
            get
            {
                return this.oadrTransportField;
            }
            set
            {
                this.oadrTransportField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrServiceSpecificInfo
    {

        private oadrServiceSpecificInfoOadrService[] oadrServiceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("oadrService")]
        public oadrServiceSpecificInfoOadrService[] oadrService
        {
            get
            {
                return this.oadrServiceField;
            }
            set
            {
                this.oadrServiceField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrPendingReports", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrPendingReportsType
    {

        private string[] reportRequestIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("reportRequestID", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string[] reportRequestID
        {
            get
            {
                return this.reportRequestIDField;
            }
            set
            {
                this.reportRequestIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("customUnit", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class BaseUnitType : ItemBaseType
    {

        private string itemDescriptionField;

        private string itemUnitsField;

        private SiScaleCodeType siScaleCodeField;

        /// <remarks/>
        public string itemDescription
        {
            get
            {
                return this.itemDescriptionField;
            }
            set
            {
                this.itemDescriptionField = value;
            }
        }

        /// <remarks/>
        public string itemUnits
        {
            get
            {
                return this.itemUnitsField;
            }
            set
            {
                this.itemUnitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/siscale")]
        public SiScaleCodeType siScaleCode
        {
            get
            {
                return this.siScaleCodeField;
            }
            set
            {
                this.siScaleCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("current", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class CurrentType : ItemBaseType
    {

        private string itemDescriptionField;

        private string itemUnitsField;

        private SiScaleCodeType siScaleCodeField;

        public CurrentType()
        {
            this.itemDescriptionField = "Current";
            this.itemUnitsField = "A";
        }

        /// <remarks/>
        public string itemDescription
        {
            get
            {
                return this.itemDescriptionField;
            }
            set
            {
                this.itemDescriptionField = value;
            }
        }

        /// <remarks/>
        public string itemUnits
        {
            get
            {
                return this.itemUnitsField;
            }
            set
            {
                this.itemUnitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/siscale")]
        public SiScaleCodeType siScaleCode
        {
            get
            {
                return this.siScaleCodeField;
            }
            set
            {
                this.siScaleCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("currency", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class currencyType : ItemBaseType
    {

        private currencyItemDescriptionType itemDescriptionField;

        private ISO3AlphaCurrencyCodeContentType itemUnitsField;

        private SiScaleCodeType siScaleCodeField;

        /// <remarks/>
        public currencyItemDescriptionType itemDescription
        {
            get
            {
                return this.itemDescriptionField;
            }
            set
            {
                this.itemDescriptionField = value;
            }
        }

        /// <remarks/>
        public ISO3AlphaCurrencyCodeContentType itemUnits
        {
            get
            {
                return this.itemUnitsField;
            }
            set
            {
                this.itemUnitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/siscale")]
        public SiScaleCodeType siScaleCode
        {
            get
            {
                return this.siScaleCodeField;
            }
            set
            {
                this.siScaleCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("currencyPerKWh", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class currencyPerKWhType : currencyType
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("currencyPerKW", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class currencyPerKWType : currencyType
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    public enum currencyItemDescriptionType
    {

        /// <remarks/>
        currency,

        /// <remarks/>
        currencyPerKW,

        /// <remarks/>
        currencyPerKWh,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:un:unece:uncefact:codelist:standard:5:ISO42173A:2010-04-07")]
    [System.Xml.Serialization.XmlRootAttribute("ISO3AlphaCurrencyCode", Namespace = "urn:un:unece:uncefact:codelist:standard:5:ISO42173A:2010-04-07", IsNullable = false)]
    public enum ISO3AlphaCurrencyCodeContentType
    {

        /// <remarks/>
        AED,

        /// <remarks/>
        AFN,

        /// <remarks/>
        ALL,

        /// <remarks/>
        AMD,

        /// <remarks/>
        ANG,

        /// <remarks/>
        AOA,

        /// <remarks/>
        ARS,

        /// <remarks/>
        AUD,

        /// <remarks/>
        AWG,

        /// <remarks/>
        AZN,

        /// <remarks/>
        BAM,

        /// <remarks/>
        BBD,

        /// <remarks/>
        BDT,

        /// <remarks/>
        BGN,

        /// <remarks/>
        BHD,

        /// <remarks/>
        BIF,

        /// <remarks/>
        BMD,

        /// <remarks/>
        BND,

        /// <remarks/>
        BOB,

        /// <remarks/>
        BOV,

        /// <remarks/>
        BRL,

        /// <remarks/>
        BSD,

        /// <remarks/>
        BTN,

        /// <remarks/>
        BWP,

        /// <remarks/>
        BYR,

        /// <remarks/>
        BZD,

        /// <remarks/>
        CAD,

        /// <remarks/>
        CDF,

        /// <remarks/>
        CHE,

        /// <remarks/>
        CHF,

        /// <remarks/>
        CHW,

        /// <remarks/>
        CLF,

        /// <remarks/>
        CLP,

        /// <remarks/>
        CNY,

        /// <remarks/>
        COP,

        /// <remarks/>
        COU,

        /// <remarks/>
        CRC,

        /// <remarks/>
        CUC,

        /// <remarks/>
        CUP,

        /// <remarks/>
        CVE,

        /// <remarks/>
        CZK,

        /// <remarks/>
        DJF,

        /// <remarks/>
        DKK,

        /// <remarks/>
        DOP,

        /// <remarks/>
        DZD,

        /// <remarks/>
        EEK,

        /// <remarks/>
        EGP,

        /// <remarks/>
        ERN,

        /// <remarks/>
        ETB,

        /// <remarks/>
        EUR,

        /// <remarks/>
        FJD,

        /// <remarks/>
        FKP,

        /// <remarks/>
        GBP,

        /// <remarks/>
        GEL,

        /// <remarks/>
        GHS,

        /// <remarks/>
        GIP,

        /// <remarks/>
        GMD,

        /// <remarks/>
        GNF,

        /// <remarks/>
        GTQ,

        /// <remarks/>
        GWP,

        /// <remarks/>
        GYD,

        /// <remarks/>
        HKD,

        /// <remarks/>
        HNL,

        /// <remarks/>
        HRK,

        /// <remarks/>
        HTG,

        /// <remarks/>
        HUF,

        /// <remarks/>
        IDR,

        /// <remarks/>
        ILS,

        /// <remarks/>
        INR,

        /// <remarks/>
        IQD,

        /// <remarks/>
        IRR,

        /// <remarks/>
        ISK,

        /// <remarks/>
        JMD,

        /// <remarks/>
        JOD,

        /// <remarks/>
        JPY,

        /// <remarks/>
        KES,

        /// <remarks/>
        KGS,

        /// <remarks/>
        KHR,

        /// <remarks/>
        KMF,

        /// <remarks/>
        KPW,

        /// <remarks/>
        KRW,

        /// <remarks/>
        KWD,

        /// <remarks/>
        KYD,

        /// <remarks/>
        KZT,

        /// <remarks/>
        LAK,

        /// <remarks/>
        LBP,

        /// <remarks/>
        LKR,

        /// <remarks/>
        LRD,

        /// <remarks/>
        LSL,

        /// <remarks/>
        LTL,

        /// <remarks/>
        LVL,

        /// <remarks/>
        LYD,

        /// <remarks/>
        MAD,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("MAD")]
        MAD1,

        /// <remarks/>
        MDL,

        /// <remarks/>
        MGA,

        /// <remarks/>
        MKD,

        /// <remarks/>
        MMK,

        /// <remarks/>
        MNT,

        /// <remarks/>
        MOP,

        /// <remarks/>
        MRO,

        /// <remarks/>
        MUR,

        /// <remarks/>
        MVR,

        /// <remarks/>
        MWK,

        /// <remarks/>
        MXN,

        /// <remarks/>
        MXV,

        /// <remarks/>
        MYR,

        /// <remarks/>
        MZN,

        /// <remarks/>
        NAD,

        /// <remarks/>
        NGN,

        /// <remarks/>
        NIO,

        /// <remarks/>
        NOK,

        /// <remarks/>
        NPR,

        /// <remarks/>
        NZD,

        /// <remarks/>
        OMR,

        /// <remarks/>
        PAB,

        /// <remarks/>
        PEN,

        /// <remarks/>
        PGK,

        /// <remarks/>
        PHP,

        /// <remarks/>
        PKR,

        /// <remarks/>
        PLN,

        /// <remarks/>
        PYG,

        /// <remarks/>
        QAR,

        /// <remarks/>
        RON,

        /// <remarks/>
        RSD,

        /// <remarks/>
        RUB,

        /// <remarks/>
        RWF,

        /// <remarks/>
        SAR,

        /// <remarks/>
        SBD,

        /// <remarks/>
        SCR,

        /// <remarks/>
        SDG,

        /// <remarks/>
        SEK,

        /// <remarks/>
        SGD,

        /// <remarks/>
        SHP,

        /// <remarks/>
        SLL,

        /// <remarks/>
        SOS,

        /// <remarks/>
        SRD,

        /// <remarks/>
        STD,

        /// <remarks/>
        SVC,

        /// <remarks/>
        SYP,

        /// <remarks/>
        SZL,

        /// <remarks/>
        THB,

        /// <remarks/>
        TJS,

        /// <remarks/>
        TMT,

        /// <remarks/>
        TND,

        /// <remarks/>
        TOP,

        /// <remarks/>
        TRY,

        /// <remarks/>
        TTD,

        /// <remarks/>
        TWD,

        /// <remarks/>
        TZS,

        /// <remarks/>
        UAH,

        /// <remarks/>
        UGX,

        /// <remarks/>
        USD,

        /// <remarks/>
        USN,

        /// <remarks/>
        USS,

        /// <remarks/>
        UYI,

        /// <remarks/>
        UYU,

        /// <remarks/>
        UZS,

        /// <remarks/>
        VEF,

        /// <remarks/>
        VND,

        /// <remarks/>
        VUV,

        /// <remarks/>
        WST,

        /// <remarks/>
        XAF,

        /// <remarks/>
        XAG,

        /// <remarks/>
        XAU,

        /// <remarks/>
        XBA,

        /// <remarks/>
        XBB,

        /// <remarks/>
        XBC,

        /// <remarks/>
        XBD,

        /// <remarks/>
        XCD,

        /// <remarks/>
        XDR,

        /// <remarks/>
        XFU,

        /// <remarks/>
        XOF,

        /// <remarks/>
        XPD,

        /// <remarks/>
        XPF,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("XPF")]
        XPF1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("XPF")]
        XPF2,

        /// <remarks/>
        XPT,

        /// <remarks/>
        XTS,

        /// <remarks/>
        XXX,

        /// <remarks/>
        YER,

        /// <remarks/>
        ZAR,

        /// <remarks/>
        ZMK,

        /// <remarks/>
        ZWL,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("frequency", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class FrequencyType : ItemBaseType
    {

        private string itemDescriptionField;

        private string itemUnitsField;

        private SiScaleCodeType siScaleCodeField;

        public FrequencyType()
        {
            this.itemDescriptionField = "Frequency";
            this.itemUnitsField = "Hz";
        }

        /// <remarks/>
        public string itemDescription
        {
            get
            {
                return this.itemDescriptionField;
            }
            set
            {
                this.itemDescriptionField = value;
            }
        }

        /// <remarks/>
        public string itemUnits
        {
            get
            {
                return this.itemUnitsField;
            }
            set
            {
                this.itemUnitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/siscale")]
        public SiScaleCodeType siScaleCode
        {
            get
            {
                return this.siScaleCodeField;
            }
            set
            {
                this.siScaleCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("Therm", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class ThermType : ItemBaseType
    {

        private string itemDescriptionField;

        private string itemUnitsField;

        private SiScaleCodeType siScaleCodeField;

        public ThermType()
        {
            this.itemDescriptionField = "Therm";
            this.itemUnitsField = "thm";
        }

        /// <remarks/>
        public string itemDescription
        {
            get
            {
                return this.itemDescriptionField;
            }
            set
            {
                this.itemDescriptionField = value;
            }
        }

        /// <remarks/>
        public string itemUnits
        {
            get
            {
                return this.itemUnitsField;
            }
            set
            {
                this.itemUnitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/siscale")]
        public SiScaleCodeType siScaleCode
        {
            get
            {
                return this.siScaleCodeField;
            }
            set
            {
                this.siScaleCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("temperature", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class temperatureType : ItemBaseType
    {

        private string itemDescriptionField;

        private temperatureUnitType itemUnitsField;

        private SiScaleCodeType siScaleCodeField;

        public temperatureType()
        {
            this.itemDescriptionField = "temperature";
        }

        /// <remarks/>
        public string itemDescription
        {
            get
            {
                return this.itemDescriptionField;
            }
            set
            {
                this.itemDescriptionField = value;
            }
        }

        /// <remarks/>
        public temperatureUnitType itemUnits
        {
            get
            {
                return this.itemUnitsField;
            }
            set
            {
                this.itemUnitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/ns/emix/2011/06/siscale")]
        public SiScaleCodeType siScaleCode
        {
            get
            {
                return this.siScaleCodeField;
            }
            set
            {
                this.siScaleCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    public enum temperatureUnitType
    {

        /// <remarks/>
        celsius,

        /// <remarks/>
        fahrenheit,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("pulseCount", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class pulseCountType : ItemBaseType
    {

        private string itemDescriptionField;

        private string itemUnitsField;

        private float pulseFactorField;

        public pulseCountType()
        {
            this.itemDescriptionField = "pulse count";
            this.itemUnitsField = "count";
        }

        /// <remarks/>
        public string itemDescription
        {
            get
            {
                return this.itemDescriptionField;
            }
            set
            {
                this.itemDescriptionField = value;
            }
        }

        /// <remarks/>
        public string itemUnits
        {
            get
            {
                return this.itemUnitsField;
            }
            set
            {
                this.itemUnitsField = value;
            }
        }

        /// <remarks/>
        public float pulseFactor
        {
            get
            {
                return this.pulseFactorField;
            }
            set
            {
                this.pulseFactorField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrPayloadResourceStatus", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrPayloadResourceStatusType : PayloadBaseType
    {

        private bool oadrOnlineField;

        private bool oadrManualOverrideField;

        private oadrLoadControlStateType oadrLoadControlStateField;

        /// <remarks/>
        public bool oadrOnline
        {
            get
            {
                return this.oadrOnlineField;
            }
            set
            {
                this.oadrOnlineField = value;
            }
        }

        /// <remarks/>
        public bool oadrManualOverride
        {
            get
            {
                return this.oadrManualOverrideField;
            }
            set
            {
                this.oadrManualOverrideField = value;
            }
        }

        /// <remarks/>
        public oadrLoadControlStateType oadrLoadControlState
        {
            get
            {
                return this.oadrLoadControlStateField;
            }
            set
            {
                this.oadrLoadControlStateField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrLoadControlState", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrLoadControlStateType
    {

        private oadrLoadControlStateTypeType oadrCapacityField;

        private oadrLoadControlStateTypeType oadrLevelOffsetField;

        private oadrLoadControlStateTypeType oadrPercentOffsetField;

        private oadrLoadControlStateTypeType oadrSetPointField;

        /// <remarks/>
        public oadrLoadControlStateTypeType oadrCapacity
        {
            get
            {
                return this.oadrCapacityField;
            }
            set
            {
                this.oadrCapacityField = value;
            }
        }

        /// <remarks/>
        public oadrLoadControlStateTypeType oadrLevelOffset
        {
            get
            {
                return this.oadrLevelOffsetField;
            }
            set
            {
                this.oadrLevelOffsetField = value;
            }
        }

        /// <remarks/>
        public oadrLoadControlStateTypeType oadrPercentOffset
        {
            get
            {
                return this.oadrPercentOffsetField;
            }
            set
            {
                this.oadrPercentOffsetField = value;
            }
        }

        /// <remarks/>
        public oadrLoadControlStateTypeType oadrSetPoint
        {
            get
            {
                return this.oadrSetPointField;
            }
            set
            {
                this.oadrSetPointField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrGBPayload", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrGBStreamPayloadBase : StreamPayloadBaseType
    {

        private feedType feedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2005/Atom")]
        public feedType feed
        {
            get
            {
                return this.feedField;
            }
            set
            {
                this.feedField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrGBDataDescription", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrGBItemBase : ItemBaseType
    {

        private feedType feedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2005/Atom")]
        public feedType feed
        {
            get
            {
                return this.feedField;
            }
            set
            {
                this.feedField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://openadr.org/oadr-2.0b/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute("oadrReportPayload", Namespace = "http://openadr.org/oadr-2.0b/2012/07", IsNullable = false)]
    public partial class oadrReportPayloadType : ReportPayloadType
    {

        private string oadrDataQualityField;

        /// <remarks/>
        public string oadrDataQuality
        {
            get
            {
                return this.oadrDataQualityField;
            }
            set
            {
                this.oadrDataQualityField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public partial class eventResponses
    {

        private eventResponsesEventResponse[] eventResponseField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("eventResponse")]
        public eventResponsesEventResponse[] eventResponse
        {
            get
            {
                return this.eventResponseField;
            }
            set
            {
                this.eventResponseField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("responses", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public partial class ArrayofResponses
    {

        private EiResponseType[] responseField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("response")]
        public EiResponseType[] response
        {
            get
            {
                return this.responseField;
            }
            set
            {
                this.responseField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("SignalNameEnumerated", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public enum SignalNameEnumeratedType
    {

        /// <remarks/>
        SIMPLE,

        /// <remarks/>
        simple,

        /// <remarks/>
        ELECTRICITY_PRICE,

        /// <remarks/>
        ENERGY_PRICE,

        /// <remarks/>
        DEMAND_CHARGE,

        /// <remarks/>
        BID_PRICE,

        /// <remarks/>
        BID_LOAD,

        /// <remarks/>
        BID_ENERGY,

        /// <remarks/>
        CHARGE_STATE,

        /// <remarks/>
        LOAD_DISPATCH,

        /// <remarks/>
        LOAD_CONTROL,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("optReasonEnumerated", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public enum OptReasonEnumeratedType
    {

        /// <remarks/>
        economic,

        /// <remarks/>
        emergency,

        /// <remarks/>
        mustRun,

        /// <remarks/>
        notParticipating,

        /// <remarks/>
        outageRunStatus,

        /// <remarks/>
        overrideStatus,

        /// <remarks/>
        participating,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("x-schedule")]
        xschedule,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("reportEnumerated", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public enum ReportEnumeratedType
    {

        /// <remarks/>
        reading,

        /// <remarks/>
        usage,

        /// <remarks/>
        demand,

        /// <remarks/>
        setPoint,

        /// <remarks/>
        deltaUsage,

        /// <remarks/>
        deltaSetPoint,

        /// <remarks/>
        deltaDemand,

        /// <remarks/>
        baseline,

        /// <remarks/>
        deviation,

        /// <remarks/>
        avgUsage,

        /// <remarks/>
        avgDemand,

        /// <remarks/>
        operatingState,

        /// <remarks/>
        upRegulationCapacityAvailable,

        /// <remarks/>
        downRegulationCapacityAvailable,

        /// <remarks/>
        regulationSetpoint,

        /// <remarks/>
        storedEnergy,

        /// <remarks/>
        targetEnergyStorage,

        /// <remarks/>
        availableEnergyStorage,

        /// <remarks/>
        price,

        /// <remarks/>
        level,

        /// <remarks/>
        powerFactor,

        /// <remarks/>
        percentUsage,

        /// <remarks/>
        percentDemand,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("x-resourceStatus")]
        xresourceStatus,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("readingTypeEnumerated", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable = false)]
    public enum ReadingTypeEnumeratedType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Direct Read")]
        DirectRead,

        /// <remarks/>
        Net,

        /// <remarks/>
        Allocated,

        /// <remarks/>
        Estimated,

        /// <remarks/>
        Summed,

        /// <remarks/>
        Derived,

        /// <remarks/>
        Mean,

        /// <remarks/>
        Peak,

        /// <remarks/>
        Hybrid,

        /// <remarks/>
        Contract,

        /// <remarks/>
        Projected,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("x-RMS")]
        xRMS,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("x-notApplicable")]
        xnotApplicable,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:icalendar-2.0:stream")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0:stream", IsNullable = false)]
    public partial class intervals
    {

        private IntervalType[] intervalField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("interval", Namespace = "http://docs.oasis-open.org/ns/energyinterop/201110")]
        public IntervalType[] interval
        {
            get
            {
                return this.intervalField;
            }
            set
            {
                this.intervalField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0", IsNullable = false)]
    public partial class dtend
    {

        private System.DateTime datetimeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("date-time")]
        public System.DateTime datetime
        {
            get
            {
                return this.datetimeField;
            }
            set
            {
                this.datetimeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("Transforms", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class TransformsType
    {

        private TransformType[] transformField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Transform")]
        public TransformType[] Transform
        {
            get
            {
                return this.transformField;
            }
            set
            {
                this.transformField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    [System.Xml.Serialization.XmlRootAttribute("DEREncodedKeyValue", Namespace = "http://www.w3.org/2009/xmldsig11#", IsNullable = false)]
    public partial class DEREncodedKeyValueType
    {

        private string idField;

        private byte[] valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "base64Binary")]
        public byte[] Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    [System.Xml.Serialization.XmlRootAttribute("X509Digest", Namespace = "http://www.w3.org/2009/xmldsig11#", IsNullable = false)]
    public partial class X509DigestType
    {

        private string algorithmField;

        private byte[] valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "base64Binary")]
        public byte[] Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
}