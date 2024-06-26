using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CoPick.Setting;

namespace AbPlcEmulator.Models
{
    [Serializable]
    public class ServerInfo : ICustomTypeDescriptor
    {
        [ReadOnly(true)]
        [Description("IP Addresss For Server")]
        [Category("ServerInfo")]
        [TypeConverter(typeof(IPAddress))]
        public string IP { get; }

        [ReadOnly(true)]
        [Description("Using Port For Server")]
        [Category("ServerInfo")]
        public string Port { get; }

        public ServerInfo(string ip, string port)
        {
            IP = ip;
            Port = port;

            UpdatePropertyDescriptors();
        }

        [NonSerialized]
        private PropertyDescriptorCollection _pdColl;

        public void UpdatePropertyDescriptors()
        {
            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(this);
            PropertyDescriptor[] propertyDescriptorArray = typeof(ServerInfo).GetProperties()
                .Select(m => new AbPlcEmulatorPropertyDescriptor(pdc[m.Name], m.GetCustomAttributes(false).Cast<Attribute>().ToArray()))
                .ToArray();
            _pdColl = new PropertyDescriptorCollection(propertyDescriptorArray);
        }

        public AttributeCollection GetAttributes() => TypeDescriptor.GetAttributes(this, true);
        public string GetClassName() => TypeDescriptor.GetClassName(this, true);
        public string GetComponentName() => TypeDescriptor.GetComponentName(this, true);
        public TypeConverter GetConverter() => TypeDescriptor.GetConverter(this, true);
        public EventDescriptor GetDefaultEvent() => TypeDescriptor.GetDefaultEvent(this, true);
        public PropertyDescriptor GetDefaultProperty() => TypeDescriptor.GetDefaultProperty(this, true);
        public object GetEditor(Type editorBaseType) => TypeDescriptor.GetEditor(this, editorBaseType, true);
        public EventDescriptorCollection GetEvents() => TypeDescriptor.GetEvents(this, true);
        public EventDescriptorCollection GetEvents(Attribute[] attributes) => TypeDescriptor.GetEvents(this, attributes, true);
        public PropertyDescriptorCollection GetProperties() => _pdColl;
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes) => _pdColl;
        public object GetPropertyOwner(PropertyDescriptor pd) => this;
    }

    public class AbPlcEmulatorPropertyDescriptor : PropertyDescriptor
    {
        private PropertyDescriptor _originalPd;

        public AbPlcEmulatorPropertyDescriptor(PropertyDescriptor pd, Attribute[] attrs)
            : base(pd, attrs) 
        {
            _originalPd = pd;
        }

        public override Type ComponentType
        {
            get => _originalPd.ComponentType;
        }

        public override bool IsReadOnly
        {
            get => _originalPd.IsReadOnly;
        }

        public override Type PropertyType
        {
            get => _originalPd.PropertyType;
        }

        public override bool CanResetValue(object component) => _originalPd.CanResetValue(component);
        public override object GetValue(object component) => _originalPd.GetValue(component);
        public override void ResetValue(object component) => _originalPd.ResetValue(component);
        public override void SetValue(object component, object value) => _originalPd.SetValue(component, value);
        public override bool ShouldSerializeValue(object component) => _originalPd.ShouldSerializeValue(component);
    }
}
