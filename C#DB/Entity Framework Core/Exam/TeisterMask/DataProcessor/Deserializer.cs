namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using System.Text;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ProjectsImportDto[]), new XmlRootAttribute("Projects"));
            var objects = (ProjectsImportDto[])serializer.Deserialize(new StringReader(xmlString));
            var projects = new HashSet<Project>();

            var sb = new StringBuilder();

            foreach (var dto in objects)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var project = new Project
                {
                    Name = dto.Name,
                    OpenDate = DateTime.ParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DueDate = string.IsNullOrEmpty(dto.DueDate)
                            ? (DateTime?)null
                            : DateTime.ParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                };

                foreach (var taskDto in dto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var taskOpenDate = DateTime.ParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var taskDueDate = DateTime.ParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (taskOpenDate < project.OpenDate || taskDueDate > project.DueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)Enum.Parse(typeof(ExecutionType), taskDto.ExecutionType),
                        LabelType = (LabelType)Enum.Parse(typeof(LabelType), taskDto.LabelType)
                    };

                    project.Tasks.Add(task);
                }

                projects.Add(project);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var objects = JsonConvert.DeserializeObject<EmployeesImportDto[]>(jsonString);
            var employees = new HashSet<Employee>();
            var sb = new StringBuilder();

            foreach (var dto in objects)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = dto.Username,
                    Email = dto.Email,
                    Phone = dto.Phone
                };

                var uniqueTasks = dto.Tasks.Distinct();

                foreach (var taskId in uniqueTasks)
                {
                    var databaseContainsTasks = context.Tasks.Any(t => t.Id == taskId);

                    if(!databaseContainsTasks)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var employeeTask = new EmployeeTask { TaskId = taskId };
                    employee.EmployeesTasks.Add(employeeTask);
                }

                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}