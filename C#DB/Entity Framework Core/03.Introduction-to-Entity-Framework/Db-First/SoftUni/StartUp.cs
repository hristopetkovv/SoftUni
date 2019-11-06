using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            string result = IncreaseSalaries(context);

            Console.WriteLine(result);
        }

        //Problem 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Select(e => new
                {
                    Id = e.EmployeeId,
                    Name = String.Join(" ", e.FirstName, e.LastName, e.MiddleName),
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.Id);

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.Name} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName);

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .Where(e => e.DepartmentName == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName);

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} " +
                    $"from {e.DepartmentName} - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee nakov = context
                .Employees
                .First(e => e.LastName == "Nakov");

            nakov.Address = address;

            context.SaveChanges();

            var addressTexts = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => new
                {
                    e.Address.AddressText
                })
                .Take(10)
                .ToList();

            foreach (var at in addressTexts)
            {
                sb.AppendLine(at.AddressText);
            }
            return sb.ToString().TrimEnd();
        }

        //Problem 07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects
                        .Any(p => p.Project.StartDate.Year >= 2001
                        && p.Project.StartDate.Year <= 2003))
                 .Take(10)
                 .Select(e => new
                 {
                     FullName = e.FirstName + " " + e.LastName,
                     ManagerFullName = e.Manager.FirstName + " " + e.Manager.LastName,
                     Projects = e.EmployeesProjects
                     .Select(p => new
                     {
                         p.Project.Name,
                         p.Project.StartDate,
                         p.Project.EndDate
                     })
                 });

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FullName} - Manager: {e.ManagerFullName}");

                foreach (var project in e.Projects)
                {
                    string format = "M/d/yyyy h:mm:ss tt";
                    string startDate = project.StartDate
                        .ToString(format, CultureInfo.InvariantCulture);

                    string endDate = project.EndDate != null
                        ? project.EndDate.Value.ToString(format, CultureInfo.InvariantCulture)
                        : "not finished";

                    sb.AppendLine($"--{project.Name} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //problem 08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context
                .Addresses
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                })
                .OrderByDescending(e => e.EmployeesCount)
                .ThenBy(e => e.TownName)
                .ThenBy(e => e.AddressText)
                .Take(10)
                .ToList();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 09
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee = context
                .Employees
                .Where(x => x.EmployeeId == 147)
                .Select(e => new
                {
                    FullName = e.FirstName + " " + e.LastName,
                    e.JobTitle,
                    ProjectsNames = e.EmployeesProjects
                        .Select(p => p.Project.Name)
                        .OrderBy(p => p)
                })
                .FirstOrDefault();

            sb.AppendLine($"{employee.FullName} - {employee.JobTitle}");

            foreach (var projectName in employee.ProjectsNames)
            {
                sb.AppendLine(projectName);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    d.Name,
                    ManagerFullName = d.Manager.FirstName + " " + d.Manager.LastName,
                    Employees = d.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Select(e => new
                    {
                        FullName = e.FirstName + " " + e.LastName,
                        e.JobTitle
                    })
                });

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.ManagerFullName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.FullName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context
                .Projects
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name);

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);

                string format = "M/d/yyyy h:mm:ss tt";
                string startDate = project.StartDate
                    .ToString(format, CultureInfo.InvariantCulture);

                sb.AppendLine(startDate);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e =>
                        e.Department.Name == "Engineering" ||
                        e.Department.Name == "Tool Design" ||
                        e.Department.Name == "Marketing" ||
                        e.Department.Name == "Information Services");

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employeesToPrint = employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            foreach (var e in employeesToPrint)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //Project 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            int projectId = 2;

            var employeesProjects = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == projectId);

            foreach (var employeeProject in employeesProjects)
            {
                context.EmployeesProjects.Remove(employeeProject);
            }

            var project = context
                .Projects
                .Find(projectId);

            context.Projects.Remove(project);
            context.SaveChanges();

            var projectsNames = context
                .Projects
                .Take(10)
                .Select(p => p.Name);

            foreach (var projectName in projectsNames)
            {
                sb.AppendLine(projectName);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 15
        public static string RemoveTown(SoftUniContext context)
        {
            var seattle = context
                .Towns
                .First(t => t.Name == "Seattle");

            var addressesInTown = context
                .Addresses
                .Where(a => a.Town == seattle);

            var employeesToRemoveAddress = context
                .Employees
                .Where(e => addressesInTown.Contains(e.Address));

            foreach (var e in employeesToRemoveAddress)
            {
                e.AddressId = null;
            }

            foreach (var a in addressesInTown)
            {
                context
                    .Addresses
                    .Remove(a);
            }

            int addressesCount = addressesInTown.Count();

            context
                .Towns
                .Remove(seattle);

            context.SaveChanges();

            return $"{addressesCount} addresses in Seattle were deleted";
        }
    }
}
