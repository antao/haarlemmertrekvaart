using System.Collections.Generic;
using System.Xml.Serialization;

namespace Haarlemmertrekvaart.Station
{
    [XmlRoot("Stations")]
    public class Stations : List<Station>
    {
    }
}
