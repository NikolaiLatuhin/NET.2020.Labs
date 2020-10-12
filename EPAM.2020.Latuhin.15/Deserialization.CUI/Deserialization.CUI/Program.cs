using System;
using System.IO;
using System.Xml.Serialization;
using Deserialization.CUI.Entities;

namespace Deserialization.CUI
{
    class Program
    {
        static void Main()
        {
            var xmlDeserialized = Load<PortalUserInfo>("PORTAL_USER_INFO.xml");
            PrintSomeDeserializedElements(xmlDeserialized);
        }

        private static void PrintSomeDeserializedElements(PortalUserInfo xmlDeserialized)
        {
            Console.WriteLine($"Company {xmlDeserialized.Company}");
            Console.WriteLine($"Short name {xmlDeserialized.AgentInfo.ShortName}");
            Console.WriteLine($"SmsPhoneNumber {xmlDeserialized.Contacts.SmsPhoneNumber}");
            Console.WriteLine($"FilialISN {xmlDeserialized.FilialISN}");
        }

        private static T Load<T>(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T) serializer.Deserialize(fileStream);
            }
        }
    }
}
