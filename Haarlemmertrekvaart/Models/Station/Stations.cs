using System.Collections.Generic;
using System.Xml.Serialization;

namespace Haarlemmertrekvaart.Models.Station
{
    [XmlRoot("Stations")]
    public class Stations : List<Models.Station.Station>
    {
    }
}
