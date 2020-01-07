﻿namespace TeisterMask.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Task")]
    public class ExportTasksProjectDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Label")]
        public string Label { get; set; }
    }
}
