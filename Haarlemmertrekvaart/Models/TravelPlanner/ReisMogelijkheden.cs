using System.Collections.Generic;
using System.Xml.Serialization;

namespace Haarlemmertrekvaart.Models.TravelPlanner
{
    [XmlRoot("ReisMogelijkheden")]
    public class ReisMogelijkheden : List<ReisMogelijkheid>
    {
        // Language domain should be kept in Dutch
    }
}
