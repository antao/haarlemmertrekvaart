using System.Xml.Serialization;

namespace Haarlemmertrekvaart.Models.Disruption
{
    public class Storing
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        public string Traject { get; set; }

        public string Periode { get; set; }

        public string Bericht { get; set; }
    }
}
