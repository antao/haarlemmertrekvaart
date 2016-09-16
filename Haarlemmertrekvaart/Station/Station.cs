using System.Collections.Generic;
using System.Xml.Serialization;

namespace Haarlemmertrekvaart.Station
{
    public class Station
    {
        public string Code { get; set; }

        public string Type { get; set; }

        public Namen Namen { get; set; }

        public string Land { get; set; }

        [XmlElement("UICCode")]
        public string UicCode { get; set; }

        [XmlElement("Lat")]
        public double Latitude { get; set; }

        [XmlElement("Lon")]
        public double Longitude { get; set; }

        public List<string> Synoniemen { get; set; }
    }
}
