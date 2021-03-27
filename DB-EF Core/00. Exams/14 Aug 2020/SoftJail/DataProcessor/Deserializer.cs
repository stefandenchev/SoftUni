namespace SoftJail.DataProcessor
{
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using ProductShop.XmlHelp;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Department> departments = new List<Department>();

            ImDepartmentCellsDto[] departmentDtos = JsonConvert.DeserializeObject<ImDepartmentCellsDto[]>(jsonString);

            foreach (var departmentDto in departmentDtos)
            {
                if (!IsValid(departmentDto)
                    || !departmentDto.Cells.All(IsValid)
                    || !departmentDto.Cells.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Department department = new Department()
                {
                    Name = departmentDto.Name,
                    Cells = departmentDto.Cells.Select(x => new Cell
                    {
                        CellNumber = x.CellNumber,
                        HasWindow = x.HasWindow
                    })
                    .ToList()
                };

                departments.Add(department);

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");

            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().Trim();
        }


        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Prisoner> prisoners = new List<Prisoner>();

            ImPrisonerMailDto[] prisonerMails = JsonConvert.DeserializeObject<ImPrisonerMailDto[]>(jsonString);

            foreach (var currentPrisoner in prisonerMails)
            {
                if (!IsValid(currentPrisoner)
                    || !currentPrisoner.Mails.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidReleaseDate = DateTime.TryParseExact(
                    currentPrisoner.ReleaseDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime releaseDate);

                var incarcerationDate = DateTime.ParseExact(
                    currentPrisoner.IncarcerationDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);

                Prisoner prisoner = new Prisoner
                {
                    FullName = currentPrisoner.FullName,
                    Nickname = currentPrisoner.Nickname,
                    Age = currentPrisoner.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = isValidReleaseDate ? (DateTime?)releaseDate : null,
                    Bail = currentPrisoner.Bail,
                    CellId = currentPrisoner.CellId,
                    Mails = currentPrisoner.Mails.Select(x => new Mail
                    {
                        Description = x.Description,
                        Sender = x.Sender,
                        Address = x.Address,
                    })
                    .ToList()
                };

                prisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var officerPrisoners = XmlConverter.Deserialize<ImOfficerPrisonerDto>(xmlString, "Officers");

            List<Officer> officers = new List<Officer>();

            foreach (var officerPrisoner in officerPrisoners)
            {
                if (!IsValid(officerPrisoner))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Position position;
                bool isValidPosition = Enum.TryParse(officerPrisoner.Position, out position);
                if (!isValidPosition)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Weapon weapon;
                bool isValidWeapon = Enum.TryParse(officerPrisoner.Weapon, out weapon);
                if (!isValidWeapon)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Officer officer = new Officer()
                {
                    FullName = officerPrisoner.FullName,
                    Salary = officerPrisoner.Salary,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officerPrisoner.DepartmentId,
                    OfficerPrisoners = officerPrisoner.Prisoners.Select(x => new OfficerPrisoner
                    {
                        PrisonerId = x.Id
                    })
                    .ToList()
                };

                officers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");

            }

            context.Officers.AddRange(officers);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }

    }
}