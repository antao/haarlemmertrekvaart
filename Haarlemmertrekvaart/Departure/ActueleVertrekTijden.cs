using System.Collections.Generic;
using System.Xml.Serialization;

namespace Haarlemmertrekvaart.Departure
{
    [XmlRoot("ActueleVertrekTijden")]
    public class ActueleVertrekTijden : List<VertrekkendeTrein>
    {
    }
}
