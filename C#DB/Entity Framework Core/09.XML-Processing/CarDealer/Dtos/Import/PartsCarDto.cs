namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("partId")]
    public class PartsCarDto
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}
