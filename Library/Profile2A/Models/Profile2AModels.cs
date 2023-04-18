﻿namespace Oadr.Library.Profile2A.Models
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://openadr.org/oadr-2.0a/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://openadr.org/oadr-2.0a/2012/07", IsNullable=false)]
    public partial class oadrResponse {
        
        private eiResponse eiResponseField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
        public eiResponse eiResponse {
            get {
                return this.eiResponseField;
            }
            set {
                this.eiResponseField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
    public partial class eiResponse {
        
        private string responseCodeField;
        
        private string responseDescriptionField;
        
        private string requestIDField;
        
        /// <remarks/>
        public string responseCode {
            get {
                return this.responseCodeField;
            }
            set {
                this.responseCodeField = value;
            }
        }
        
        /// <remarks/>
        public string responseDescription {
            get {
                return this.responseDescriptionField;
            }
            set {
                this.responseDescriptionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public string requestID {
            get {
                return this.requestIDField;
            }
            set {
                this.requestIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:ietf:params:xml:ns:icalendar-2.0:stream")]
    public abstract partial class StreamBaseType {
        
        private dtstart dtstartField;
        
        private DurationPropType durationField;
        
        private IntervalType[] intervalsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="urn:ietf:params:xml:ns:icalendar-2.0")]
        public dtstart dtstart {
            get {
                return this.dtstartField;
            }
            set {
                this.dtstartField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="urn:ietf:params:xml:ns:icalendar-2.0")]
        public DurationPropType duration {
            get {
                return this.durationField;
            }
            set {
                this.durationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("interval", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
        public IntervalType[] intervals {
            get {
                return this.intervalsField;
            }
            set {
                this.intervalsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:ietf:params:xml:ns:icalendar-2.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="urn:ietf:params:xml:ns:icalendar-2.0", IsNullable=false)]
    public partial class dtstart {
        
        private System.DateTime datetimeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("date-time")]
        public System.DateTime datetime {
            get {
                return this.datetimeField;
            }
            set {
                this.datetimeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:ietf:params:xml:ns:icalendar-2.0")]
    [System.Xml.Serialization.XmlRootAttribute("x-eiNotification", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
    public partial class DurationPropType {
        
        private string durationField;
        
        /// <remarks/>
        public string duration {
            get {
                return this.durationField;
            }
            set {
                this.durationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("interval", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
    public partial class IntervalType {
        
        private DurationPropType durationField;
        
        private uid uidField;
        
        // private StreamPayloadBaseType streamPayloadBaseField;
        private currentValueType currentValueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="urn:ietf:params:xml:ns:icalendar-2.0")]
        public DurationPropType duration {
            get {
                return this.durationField;
            }
            set {
                this.durationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="urn:ietf:params:xml:ns:icalendar-2.0")]
        public uid uid {
            get {
                return this.uidField;
            }
            set {
                this.uidField = value;
            }
        }

        /// <remarks/>
        // [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:ietf:params:xml:ns:icalendar-2.0")]
        public currentValueType signalPayload
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

        /// <remarks/>
        /*[System.Xml.Serialization.XmlElementAttribute(Namespace="urn:ietf:params:xml:ns:icalendar-2.0:stream")]
        public StreamPayloadBaseType streamPayloadBase {
            get {
                return this.streamPayloadBaseField;
            }
            set {
                this.streamPayloadBaseField = value;
            }
        }*/
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:ietf:params:xml:ns:icalendar-2.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="urn:ietf:params:xml:ns:icalendar-2.0", IsNullable=false)]
    public partial class uid {
        
        private string textField;
        
        /// <remarks/>
        public string text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(signalPayloadType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:ietf:params:xml:ns:icalendar-2.0:stream")]
    public abstract partial class StreamPayloadBaseType {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("signalPayload", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
    public partial class signalPayloadType : StreamPayloadBaseType {
        
        private payloadFloat payloadFloatField;
        
        /// <remarks/>
        public payloadFloat payloadFloat {
            get {
                return this.payloadFloatField;
            }
            set {
                this.payloadFloatField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
    public partial class payloadFloat {
        
        private float valueField;
        
        /// <remarks/>
        public float value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("eiTarget", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
    public partial class eiTargetType {
        
        private string[] groupIDField;
        
        private string[] resourceIDField;
        
        private string[] venIDField;
        
        private string[] partyIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("groupID")]
        public string[] groupID {
            get {
                return this.groupIDField;
            }
            set {
                this.groupIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("resourceID")]
        public string[] resourceID {
            get {
                return this.resourceIDField;
            }
            set {
                this.resourceIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("venID")]
        public string[] venID {
            get {
                return this.venIDField;
            }
            set {
                this.venIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("partyID")]
        public string[] partyID {
            get {
                return this.partyIDField;
            }
            set {
                this.partyIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("eiEventSignal", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
    public partial class eiEventSignalType {
        
        private IntervalType[] intervalsField;
        
        private string signalNameField;
        
        private SignalTypeEnumeratedType signalTypeField;
        
        private string signalIDField;
        
        private currentValueType currentValueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace="urn:ietf:params:xml:ns:icalendar-2.0:stream")]
        [System.Xml.Serialization.XmlArrayItemAttribute("interval", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
        public IntervalType[] intervals {
            get {
                return this.intervalsField;
            }
            set {
                this.intervalsField = value;
            }
        }
        
        /// <remarks/>
        public string signalName {
            get {
                return this.signalNameField;
            }
            set {
                this.signalNameField = value;
            }
        }
        
        /// <remarks/>
        public SignalTypeEnumeratedType signalType {
            get {
                return this.signalTypeField;
            }
            set {
                this.signalTypeField = value;
            }
        }
        
        /// <remarks/>
        public string signalID {
            get {
                return this.signalIDField;
            }
            set {
                this.signalIDField = value;
            }
        }
        
        /// <remarks/>
        public currentValueType currentValue {
            get {
                return this.currentValueField;
            }
            set {
                this.currentValueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("signalType", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
    public enum SignalTypeEnumeratedType {
        
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
        product,
        
        /// <remarks/>
        setpoint,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("currentValue", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
    public partial class currentValueType {
        
        private payloadFloat itemField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("payloadFloat")]
        public payloadFloat Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("qualifiedEventID", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
    public partial class QualifiedEventIDType {
        
        private string eventIDField;
        
        private uint modificationNumberField;
        
        /// <remarks/>
        public string eventID {
            get {
                return this.eventIDField;
            }
            set {
                this.eventIDField = value;
            }
        }
        
        /// <remarks/>
        public uint modificationNumber {
            get {
                return this.modificationNumberField;
            }
            set {
                this.modificationNumberField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("eiActivePeriod", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
    public partial class eiActivePeriodType {
        
        private properties propertiesField;
        
        private object componentsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="urn:ietf:params:xml:ns:icalendar-2.0")]
        public properties properties {
            get {
                return this.propertiesField;
            }
            set {
                this.propertiesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="urn:ietf:params:xml:ns:icalendar-2.0", IsNullable=true)]
        public object components {
            get {
                return this.componentsField;
            }
            set {
                this.componentsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:ietf:params:xml:ns:icalendar-2.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="urn:ietf:params:xml:ns:icalendar-2.0", IsNullable=false)]
    public partial class properties {
        
        private dtstart dtstartField;
        
        private DurationPropType durationField;
        
        private propertiesTolerance toleranceField;
        
        private DurationPropType xeiNotificationField;
        
        private DurationPropType xeiRampUpField;
        
        private DurationPropType xeiRecoveryField;
        
        /// <remarks/>
        public dtstart dtstart {
            get {
                return this.dtstartField;
            }
            set {
                this.dtstartField = value;
            }
        }
        
        /// <remarks/>
        public DurationPropType duration {
            get {
                return this.durationField;
            }
            set {
                this.durationField = value;
            }
        }
        
        /// <remarks/>
        public propertiesTolerance tolerance {
            get {
                return this.toleranceField;
            }
            set {
                this.toleranceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("x-eiNotification", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
        public DurationPropType xeiNotification {
            get {
                return this.xeiNotificationField;
            }
            set {
                this.xeiNotificationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("x-eiRampUp", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
        public DurationPropType xeiRampUp {
            get {
                return this.xeiRampUpField;
            }
            set {
                this.xeiRampUpField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("x-eiRecovery", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
        public DurationPropType xeiRecovery {
            get {
                return this.xeiRecoveryField;
            }
            set {
                this.xeiRecoveryField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:ietf:params:xml:ns:icalendar-2.0")]
    public partial class propertiesTolerance {
        
        private propertiesToleranceTolerate tolerateField;
        
        /// <remarks/>
        public propertiesToleranceTolerate tolerate {
            get {
                return this.tolerateField;
            }
            set {
                this.tolerateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:ietf:params:xml:ns:icalendar-2.0")]
    public partial class propertiesToleranceTolerate {
        
        private string startafterField;
        
        /// <remarks/>
        public string startafter {
            get {
                return this.startafterField;
            }
            set {
                this.startafterField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("eventDescriptor", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
    public partial class eventDescriptorType {
        
        private string eventIDField;
        
        private uint modificationNumberField;
        
        private uint priorityField;
        
        private bool priorityFieldSpecified;
        
        private eventDescriptorTypeEiMarketContext eiMarketContextField;
        
        private System.DateTime createdDateTimeField;
        
        private EventStatusEnumeratedType eventStatusField;
        
        private string testEventField;
        
        private string vtnCommentField;
        
        /// <remarks/>
        public string eventID {
            get {
                return this.eventIDField;
            }
            set {
                this.eventIDField = value;
            }
        }
        
        /// <remarks/>
        public uint modificationNumber {
            get {
                return this.modificationNumberField;
            }
            set {
                this.modificationNumberField = value;
            }
        }
        
        /// <remarks/>
        public uint priority {
            get {
                return this.priorityField;
            }
            set {
                this.priorityField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool prioritySpecified {
            get {
                return this.priorityFieldSpecified;
            }
            set {
                this.priorityFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public eventDescriptorTypeEiMarketContext eiMarketContext {
            get {
                return this.eiMarketContextField;
            }
            set {
                this.eiMarketContextField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime createdDateTime {
            get {
                return this.createdDateTimeField;
            }
            set {
                this.createdDateTimeField = value;
            }
        }
        
        /// <remarks/>
        public EventStatusEnumeratedType eventStatus {
            get {
                return this.eventStatusField;
            }
            set {
                this.eventStatusField = value;
            }
        }
        
        /// <remarks/>
        public string testEvent {
            get {
                return this.testEventField;
            }
            set {
                this.testEventField = value;
            }
        }
        
        /// <remarks/>
        public string vtnComment {
            get {
                return this.vtnCommentField;
            }
            set {
                this.vtnCommentField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    public partial class eventDescriptorTypeEiMarketContext {
        
        private string marketContextField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://docs.oasis-open.org/ns/emix/2011/06", DataType="anyURI")]
        public string marketContext {
            get {
                return this.marketContextField;
            }
            set {
                this.marketContextField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("eventStatus", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
    public enum EventStatusEnumeratedType {
        
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("eiEvent", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
    public partial class eiEventType {
        
        private eventDescriptorType eventDescriptorField;
        
        private eiActivePeriodType eiActivePeriodField;
        
        private eiEventSignalType[] eiEventSignalsField;
        
        private eiTargetType eiTargetField;
        
        /// <remarks/>
        public eventDescriptorType eventDescriptor {
            get {
                return this.eventDescriptorField;
            }
            set {
                this.eventDescriptorField = value;
            }
        }
        
        /// <remarks/>
        public eiActivePeriodType eiActivePeriod {
            get {
                return this.eiActivePeriodField;
            }
            set {
                this.eiActivePeriodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("eiEventSignal", IsNullable=false)]
        public eiEventSignalType[] eiEventSignals {
            get {
                return this.eiEventSignalsField;
            }
            set {
                this.eiEventSignalsField = value;
            }
        }
        
        /// <remarks/>
        public eiTargetType eiTarget {
            get {
                return this.eiTargetField;
            }
            set {
                this.eiTargetField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://openadr.org/oadr-2.0a/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://openadr.org/oadr-2.0a/2012/07", IsNullable=false)]
    public partial class oadrDistributeEvent {
        
        private eiResponse eiResponseField;
        
        private string requestIDField;
        
        private string vtnIDField;
        
        private oadrDistributeEventOadrEvent[] oadrEventField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
        public eiResponse eiResponse {
            get {
                return this.eiResponseField;
            }
            set {
                this.eiResponseField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public string requestID {
            get {
                return this.requestIDField;
            }
            set {
                this.requestIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string vtnID {
            get {
                return this.vtnIDField;
            }
            set {
                this.vtnIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("oadrEvent")]
        public oadrDistributeEventOadrEvent[] oadrEvent {
            get {
                return this.oadrEventField;
            }
            set {
                this.oadrEventField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://openadr.org/oadr-2.0a/2012/07")]
    public partial class oadrDistributeEventOadrEvent {
        
        private eiEventType eiEventField;
        
        private ResponseRequiredType oadrResponseRequiredField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
        public eiEventType eiEvent {
            get {
                return this.eiEventField;
            }
            set {
                this.eiEventField = value;
            }
        }
        
        /// <remarks/>
        public ResponseRequiredType oadrResponseRequired {
            get {
                return this.oadrResponseRequiredField;
            }
            set {
                this.oadrResponseRequiredField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://openadr.org/oadr-2.0a/2012/07")]
    public enum ResponseRequiredType {
        
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://openadr.org/oadr-2.0a/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://openadr.org/oadr-2.0a/2012/07", IsNullable=false)]
    public partial class oadrCreatedEvent {
        
        private eiCreatedEvent eiCreatedEventField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public eiCreatedEvent eiCreatedEvent {
            get {
                return this.eiCreatedEventField;
            }
            set {
                this.eiCreatedEventField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110/payloads", IsNullable=false)]
    public partial class eiCreatedEvent {
        
        private eiResponse eiResponseField;
        
        private eventResponsesEventResponse[] eventResponsesField;
        
        private string venIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
        public eiResponse eiResponse {
            get {
                return this.eiResponseField;
            }
            set {
                this.eiResponseField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
        [System.Xml.Serialization.XmlArrayItemAttribute("eventResponse", IsNullable=false)]
        public eventResponsesEventResponse[] eventResponses {
            get {
                return this.eventResponsesField;
            }
            set {
                this.eventResponsesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID {
            get {
                return this.venIDField;
            }
            set {
                this.venIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    public partial class eventResponsesEventResponse {
        
        private string responseCodeField;
        
        private string responseDescriptionField;
        
        private string requestIDField;
        
        private QualifiedEventIDType qualifiedEventIDField;
        
        private OptTypeType optTypeField;
        
        /// <remarks/>
        public string responseCode {
            get {
                return this.responseCodeField;
            }
            set {
                this.responseCodeField = value;
            }
        }
        
        /// <remarks/>
        public string responseDescription {
            get {
                return this.responseDescriptionField;
            }
            set {
                this.responseDescriptionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public string requestID {
            get {
                return this.requestIDField;
            }
            set {
                this.requestIDField = value;
            }
        }
        
        /// <remarks/>
        public QualifiedEventIDType qualifiedEventID {
            get {
                return this.qualifiedEventIDField;
            }
            set {
                this.qualifiedEventIDField = value;
            }
        }
        
        /// <remarks/>
        public OptTypeType optType {
            get {
                return this.optTypeField;
            }
            set {
                this.optTypeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("optType", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
    public enum OptTypeType {
        
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://openadr.org/oadr-2.0a/2012/07")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://openadr.org/oadr-2.0a/2012/07", IsNullable=false)]
    public partial class oadrRequestEvent {
        
        private eiRequestEvent eiRequestEventField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
        public eiRequestEvent eiRequestEvent {
            get {
                return this.eiRequestEventField;
            }
            set {
                this.eiRequestEventField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110/payloads", IsNullable=false)]
    public partial class eiRequestEvent {
        
        private string requestIDField;
        
        private string venIDField;
        
        private uint replyLimitField;
        
        private bool replyLimitFieldSpecified;
        
        /// <remarks/>
        public string requestID {
            get {
                return this.requestIDField;
            }
            set {
                this.requestIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
        public string venID {
            get {
                return this.venIDField;
            }
            set {
                this.venIDField = value;
            }
        }
        
        /// <remarks/>
        public uint replyLimit {
            get {
                return this.replyLimitField;
            }
            set {
                this.replyLimitField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool replyLimitSpecified {
            get {
                return this.replyLimitFieldSpecified;
            }
            set {
                this.replyLimitFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
    public partial class eventResponses {
        
        private eventResponsesEventResponse[] eventResponseField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("eventResponse")]
        public eventResponsesEventResponse[] eventResponse {
            get {
                return this.eventResponseField;
            }
            set {
                this.eventResponseField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
    [System.Xml.Serialization.XmlRootAttribute("eiEventSignals", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110", IsNullable=false)]
    public partial class eiEventSignalsType {
        
        private eiEventSignalType[] eiEventSignalField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("eiEventSignal")]
        public eiEventSignalType[] eiEventSignal {
            get {
                return this.eiEventSignalField;
            }
            set {
                this.eiEventSignalField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/ns/energyinterop/201110/payloads")]
    [System.Xml.Serialization.XmlRootAttribute("eventFilter", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110/payloads", IsNullable=false)]
    public enum EventFilterType {
        
        /// <remarks/>
        all,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:ietf:params:xml:ns:icalendar-2.0:stream")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="urn:ietf:params:xml:ns:icalendar-2.0:stream", IsNullable=false)]
    public partial class intervals {
        
        private IntervalType[] intervalField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("interval", Namespace="http://docs.oasis-open.org/ns/energyinterop/201110")]
        public IntervalType[] interval {
            get {
                return this.intervalField;
            }
            set {
                this.intervalField = value;
            }
        }
    }
}
