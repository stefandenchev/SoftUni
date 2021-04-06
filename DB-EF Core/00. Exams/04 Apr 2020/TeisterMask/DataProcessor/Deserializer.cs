namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using ProductShop.XmlHelp;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            string root = "Projects";
            StringBuilder sb = new StringBuilder();

            ProjectInputXmlModel[] projects = XmlConverter.Deserialize<ProjectInputXmlModel>(xmlString, root);

            foreach (var currProject in projects)
            {
                if (!IsValid(currProject))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime openDate;
                bool parseOpenDate = DateTime.TryParseExact(currProject.OpenDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out openDate);

                if (!parseOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate;
                if (!String.IsNullOrEmpty(currProject.DueDate))
                {
                    DateTime projDueDate;
                    bool parseDueDate = DateTime
                        .TryParseExact(currProject.DueDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out projDueDate);

                    if (!parseDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = projDueDate;
                }
                else
                {
                    dueDate = null;
                }

                Project project = new Project()
                {
                    Name = currProject.Name,
                    OpenDate = openDate,
                    DueDate = dueDate
                };

                foreach (var currTask in currProject.Tasks)
                {

                    if (!IsValid(currTask))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    bool parseTaskOpenDate = DateTime.TryParseExact(currTask.OpenDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out taskOpenDate);

                    if (!parseTaskOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < project.OpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskDueDate;
                    bool parseTaskDueDate = DateTime.TryParseExact(currTask.DueDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out taskDueDate);

                    if (!parseTaskDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (project.DueDate.HasValue)
                    {
                        if (taskDueDate > project.DueDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }

                    Task task = new Task()
                    {
                        Name = currTask.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)currTask.ExecutionType,
                        LabelType = (LabelType)currTask.LabelType,

                    };
                    project.Tasks.Add(task);
                }

                context.Projects.Add(project);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported project - {project.Name} with {project.Tasks.Count()} tasks.");
                //sb.AppendLine(String.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            EmployeeInputJsonModel[] employees = JsonConvert.DeserializeObject<EmployeeInputJsonModel[]>(jsonString);

            foreach (var currEmployee in employees)
            {
                if (!IsValid(currEmployee))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee
                {
                    Username = currEmployee.Username,
                    Email = currEmployee.Email,
                    Phone = currEmployee.Phone
                };

                foreach (var currTask in currEmployee.Tasks.Distinct())
                {
                    Task task = context.Tasks
                        .FirstOrDefault(x => x.Id == currTask);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask()
                    {
                        Employee = employee,
                        Task = task
                    });
                }

                context.Employees.Add(employee);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported employee - {employee.Username} with {employee.EmployeesTasks.Count()} tasks.");

            }

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