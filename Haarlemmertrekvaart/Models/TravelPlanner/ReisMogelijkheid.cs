﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Haarlemmertrekvaart.Models.TravelPlanner
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

        [XmlIgnore()]
        public DateTime ActueleVertrekTijd { get; set; }

        [XmlElement(ElementName = "ActueleVertrekTijd")]
        public string XmlActueleVertrekTijd
        {
            get { return XmlConvert.ToString(ActueleVertrekTijd, XmlDateTimeSerializationMode.Utc); }
            set { ActueleVertrekTijd = DateTimeOffset.Parse(value).DateTime; }
        }

        [XmlIgnore()]
        public DateTime GeplandeAankomstTijd { get; set; }

        [XmlElement(ElementName = "GeplandeAankomstTijd")]
        public string XmlGeplandeAankomstTijd
        {
            get { return XmlConvert.ToString(GeplandeAankomstTijd, XmlDateTimeSerializationMode.Utc); }
            set { GeplandeAankomstTijd = DateTimeOffset.Parse(value).DateTime; }
        }

        [XmlIgnore()]
        public DateTime ActueleAankomstTijd { get; set; }

        [XmlElement(ElementName = "ActueleAankomstTijd")]
        public string XmlActueleAankomstTijd
        {
            get { return XmlConvert.ToString(ActueleAankomstTijd, XmlDateTimeSerializationMode.Utc); }
            set { ActueleAankomstTijd = DateTimeOffset.Parse(value).DateTime; }
        }


        public string Status { get; set; }

        [XmlElement(ElementName = "ReisDeel")]
        public List<ReisDeel> ReisDeel { get; set; }

        public Melding Melding { get; set; }
    }
}
