namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("Users")]
    public class GetCountAndUsersWithProductsDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExportUsersAndProductsDto[] Users { get; set; }
    }
}
