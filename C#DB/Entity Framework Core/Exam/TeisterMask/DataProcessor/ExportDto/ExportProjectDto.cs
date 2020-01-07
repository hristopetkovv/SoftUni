namespace TeisterMask.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Project")]
    public class ExportProjectDto
    {
        [XmlAttribute]
        public int TasksCount { get; set; }

        [XmlElement("ProjectName")]
        public string ProjectName { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray]
        public ExportTasksProjectDto[] Tasks { get; set; }
    }
}
