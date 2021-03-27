namespace SoftJail.DataProcessor
{

    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using ProductShop.XmlHelp;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Linq;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                 .Prisoners
                 .ToList()
                 .Where(p => ids.Any(i => i == p.Id))
                 .Select(p => new
                 {
                     Id = p.Id,
                     Name = p.FullName,
                     CellNumber = p.Cell.CellNumber,
                     Officers = p.PrisonerOfficers
                     .ToList()
                     .Select(x => new
                     {
                         OfficerName = x.Officer.FullName,
                         Department = x.Officer.Department.Name
                     })
                     .OrderBy(x => x.OfficerName)
                     .ToList(),
                     OfficerSalaries = p.PrisonerOfficers.Sum(x => x.Officer.Salary)
                 })
                 .OrderBy(p => p.Name)
                 .ThenBy(p => p.Id)
                 .ToList();

            var jsonResult = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return jsonResult;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisoners = context.Prisoners
                .Where(p => prisonersNames.Contains(p.FullName))
                .Select(x => new ExPrisonerMailDto
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd"),
                    Messages = x.Mails.Select(x => new ExMessageDto
                    {
                        Description = ReverseString(x.Description)
                    })
                    .ToArray()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            var root = "Prisoners";
            var result = XmlConverter.Serialize(prisoners, root);

            return result;
        }

        private static string ReverseString(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}