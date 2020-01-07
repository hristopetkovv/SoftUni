namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projectDtos = context
                .Projects
                .Where(p => p.Tasks.Any())
                .OrderByDescending(p => p.Tasks.Count)
                .ThenBy(p => p.Name)
                .Select(p => new ExportProjectDto
                {
                    TasksCount = p.Tasks.Count,
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    Tasks = p.Tasks
                    .OrderBy(t => t.Name)
                    .Select(t => new ExportTasksProjectDto
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .ToArray()
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProjectDto[]),
                                new XmlRootAttribute("Projects"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), projectDtos, namespaces);

            return sb.ToString().TrimEnd();

        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employeeDtos = context
                .Employees
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .Select(e => new ExportEmployeesDto
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                    .Where(et => et.Task.OpenDate >= date)
                    .OrderByDescending(et => et.Task.DueDate)
                    .ThenBy(et => et.Task.Name)
                    .Select(et => new ExportTaskEmployeeDto
                    {
                        TaskName = et.Task.Name,
                        OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = et.Task.LabelType.ToString(),
                        ExecutionType = et.Task.ExecutionType.ToString()
                    })
                    .ToArray()
                })
                .ToArray()
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            var jsonResult = JsonConvert.SerializeObject(employeeDtos, Formatting.Indented);

            return jsonResult;
        }
    }
}