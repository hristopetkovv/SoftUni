﻿namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("Product")]
    public class ExportUserSoldProductsDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
