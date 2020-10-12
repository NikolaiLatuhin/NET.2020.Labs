using System.Xml.Serialization;

namespace Deserialization.CUI.Entities
{
    [XmlRoot("CONTACTS"), XmlType("CONTACTS")]
    public class Contacts
    {
        [XmlElement(ElementName = "SmsPhoneNumber")]
        public string SmsPhoneNumber { get; set; }

        [XmlElement(ElementName = "PhoneNeedActualize")]
        public bool PhoneNeedActualize { get; set; }
    }
}
