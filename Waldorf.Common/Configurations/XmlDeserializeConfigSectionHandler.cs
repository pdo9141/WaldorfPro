using System;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;

namespace Waldorf.Common.Configurations
{
    public abstract class XmlDeserializeConfigSectionHandler : IConfigurationSectionHandler
    {
        public XmlDeserializeConfigSectionHandler()
            : base()
        {
        }

        public object Create(object parent, object configContext, XmlNode section)
        {
            Type t = this.GetType();
            XmlSerializer ser = new XmlSerializer(t);
            XmlNodeReader xNodeReader = new XmlNodeReader(section);
            return ser.Deserialize(xNodeReader);
        }
    }
}
