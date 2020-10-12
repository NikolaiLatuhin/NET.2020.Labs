using System.Xml.Serialization;

namespace Deserialization.CUI.Entities
{

    [XmlRoot("AGENT_INFO"), XmlType("AGENT_INFO")]
    public class AgentInfo
    {
        [XmlElement(ElementName = "ISN")]
        public string ISN { get; set; }

        [XmlElement(ElementName = "ShortName")]
        public string ShortName { get; set; }

        [XmlElement(ElementName = "FullName")]
        public string FullName { get; set; }

        [XmlElement(ElementName = "IsBank")]
        public bool IsBank { get; set; }

        [XmlElement(ElementName = "ClassISN")]
        public string ClassISN { get; set; }
    }
}
