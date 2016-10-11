using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Haarlemmertrekvaart.TravelPlanner
{
    public class ReisMogelijkheid
    {
        public int AantalOverstappen { get; set; }

        public string GeplandeReisTijd { get; set; }

        public string ActueleReisTijd { get; set; }

        public string AankomstVertraging { get; set; }

        public bool Optimaal { get; set; }

        [XmlIgnore()]
        public DateTime GeplandeVertrekTijd { get; set; }

        [XmlElement(ElementName = "GeplandeVertrekTijd")]
        public string XmlGeplandeVertrekTijd
        {
            get { return XmlConvert.ToString(GeplandeVertrekTijd, XmlDateTimeSerializationMode.Utc); }
            set { GeplandeVertrekTijd = DateTimeOffset.Parse(value).DateTime; }
        }

        //public DateTime ActueleVertrekTijd { get; set; }

        //public DateTime GeplandeAankomstTijd { get; set; }

        //public DateTime ActueleAankomstTijd { get; set; }

        public string Status { get; set; }

        [XmlElement("ReisDeel", typeof(ReisDeel))]
        public List<ReisDeel> ReisDeel { get; set; }
    }
}
