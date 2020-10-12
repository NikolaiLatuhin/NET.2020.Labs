using System.Xml.Serialization;

namespace Deserialization.CUI.Entities
{
    [XmlRoot("POST_ERRORS"), XmlType("POST_ERRORS")]
    public class PostErrors
    {
        [XmlElement(ElementName = "All")]
        public string All { get; set; }

        [XmlElement(ElementName = "Critical")]
        public string Critical { get; set; }
    }
}
