using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            //Console.WriteLine(GetEmployeesFullInformation(db));
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(db));
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(db));
            //Console.WriteLine(AddNewAddressToEmployee(db));
            Console.WriteLine(GetEmployeesInPeriod(db));

            /*var address = db.Addresses.FirstOrDefault(x => x.AddressText == "Vitoshka 15");
            db.Addresses.Remove(address);
            db.SaveChanges();*/


        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees.ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.Append(String.Join(" ", e.FirstName, e.LastName, e.MiddleName, e.JobTitle));
                sb.AppendLine($" {e.Salary:f2}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Salary > 50000)
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb
                  .Append(e.FirstName)
                  .AppendLine($" - {e.Salary:f2}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    DepartmentName = x.Department.Name,
                    x.Salary
                })
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
            }

            return sb.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var person = context.Employees.Where(x => x.LastName == "Nakov").FirstOrDefault();
            person.Address = address;

            context.SaveChanges();

            var employees = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    AddressText = x.Address.AddressText,
                    x.AddressId,
                    x.Salary
                })
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.AddressText}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001
                                                       && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                    .Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        ProjectStart = p.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                        ProjectEnd = p.Project.EndDate.HasValue ?
                        p.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished"
                    }).ToList()
                }).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName}" +
                    $" - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.ProjectStart} - {p.ProjectEnd}");
                }

            }

            return sb.ToString();
        }
    }
}