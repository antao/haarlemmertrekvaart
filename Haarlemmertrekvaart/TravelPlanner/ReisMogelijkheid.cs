using System;
using System.Collections.Generic;

namespace Haarlemmertrekvaart.TravelPlanner
{
    public class ReisMogelijkheid
    {
        // Language domain should be kept in Dutch

        public int AantalOverstappen { get; set; }

        public string GeplandeReisTijd { get; set; }

        public string ActueleReisTijd { get; set; }

        public string AankomstVertraging { get; set; }

        public bool Optimaal { get; set; }

        //public DateTime GeplandeVertrekTijd { get; set; }

        //public DateTime ActueleVertrekTijd { get; set; }

        //public DateTime GeplandeAankomstTijd { get; set; }

        //public DateTime ActueleAankomstTijd { get; set; }

        public string Status { get; set; }

        //public List<ReisDeel> ReisDeel { get; set; }
    }
}
