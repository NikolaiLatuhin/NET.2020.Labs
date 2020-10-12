using System.Xml.Serialization;

namespace Deserialization.CUI.Entities
{
    [XmlRoot("PORTAL_USER_INFO"), XmlType("PORTAL_USER_INFO")]
    public class PortalUserInfo
    {
        [XmlElement(ElementName = "AGENT_INFO")]
        public AgentInfo AgentInfo { get; set; }

        [XmlElement(ElementName = "CONTACTS")]
        public Contacts Contacts { get; set; }

        [XmlElement(ElementName = "POST_ERRORS")]
        public PostErrors PostErrors { get; set; }

        [XmlElement(ElementName = "IsEmployee")]
        public string IsEmployee { get; set; }

        [XmlElement(ElementName = "Company")]
        public string Company { get; set; }

        [XmlElement(ElementName = "FilialISN")]
        public string FilialISN { get; set; }

    }

}
