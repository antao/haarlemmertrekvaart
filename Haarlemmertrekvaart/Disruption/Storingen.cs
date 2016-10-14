using System.Xml.Serialization;

namespace Haarlemmertrekvaart.Disruption
{
    [XmlRoot("Storingen")]
    public class Storingen
    {
        public Ongepland Ongepland { get; set; }

        public Gepland Gepland { get; set; }
    }
}
