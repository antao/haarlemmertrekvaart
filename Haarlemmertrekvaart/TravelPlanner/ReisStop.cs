using System;
using System.Xml;
using System.Xml.Serialization;

namespace Haarlemmertrekvaart.TravelPlanner
{
    public class ReisStop
    {
        public string Naam { get; set; }

        [XmlIgnore()]
        public DateTime Tijd { get; set; }

        [XmlElement(ElementName = "Tijd")]
        public string XmTijd
        {
            get { return XmlConvert.ToString(Tijd, XmlDateTimeSerializationMode.Utc); }
            set { Tijd = DateTimeOffset.Parse(value).DateTime; }
        }

        public string Spoor { get; set; }
    }
}
