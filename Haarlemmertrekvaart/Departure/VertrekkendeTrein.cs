using System;
using System.Xml;
using System.Xml.Serialization;

namespace Haarlemmertrekvaart.Departure
{
    public class VertrekkendeTrein
    {
        public string RitNummer { get; set; }

        [XmlIgnore()]
        public DateTime VertrekTijd { get; set; }

        [XmlElement(ElementName = "VertrekTijd")]
        public string XmlVertrekTijd
        {
            get { return XmlConvert.ToString(VertrekTijd, XmlDateTimeSerializationMode.Utc); }
            set { VertrekTijd = DateTimeOffset.Parse(value).DateTime; }
        }

        public string VertrekVertraging { get; set; }

        public string VertrekVertragingTekst { get; set; }

        public string EindBestemming { get; set; }

        public string TreinSoort { get; set; }

        public string RouteTekst { get; set; }

        public string Vervoerder { get; set; }

        public string VertrekSpoor { get; set; }

        public string ReisTip { get; set; }

        public string Comments { get; set; }
    }
}