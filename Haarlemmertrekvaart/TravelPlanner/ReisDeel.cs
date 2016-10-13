using System.Collections.Generic;
using System.Xml.Serialization;

namespace Haarlemmertrekvaart.TravelPlanner
{
    public class ReisDeel
    {
        // Travel Section

        public string Vervoerder { get; set; }

        public string VervoerType { get; set; }

        public string RitNummer { get; set; }

        public string Status { get; set; }

        [XmlElement("Reisdetails")]
        public List<string> Reisdetail { get; set; }

        [XmlElement(ElementName = "ReisStop")]
        public List<ReisStop> ReisStop { get; set; }
    }
}
