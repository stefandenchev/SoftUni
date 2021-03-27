namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		private const string ErrorMessage = "Invalid Data";
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            throw new NotImplementedException();

/*            StringBuilder sb = new StringBuilder();
            List<Game> gamesToAdd = new List<Game>();

            GameImportModel[] games = JsonConvert.DeserializeObject<GameImportModel[]>(jsonString);

            foreach (var currGame in games)
            {
                if (!IsValid(currGame)
                    || !currGame.Tags.All(IsValid)
                    || !currGame.Tags.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var releaseDate = DateTime.ParseExact(
                    currGame.ReleaseDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);

                Game game = new Game
                {
                    Name = currGame.Name,
                    Price = currGame.Price,
                    ReleaseDate = releaseDate,
                    Developer = currGame.Developer.Name,
                    Genre = currGame.Genre.Name,
                    Tags = currGame.Tags.Select(x => new Tag
                    {
                        CellNumber = x.CellNumber,
                        HasWindow = x.HasWindow
                    })
                    .ToList()
                };

                gamesToAdd.Add(games);

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");

            }

            context.Games.AddRange(gamesToAdd);
            context.SaveChanges();

            return sb.ToString().Trim();*/
        }

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			throw new NotImplementedException();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			throw new NotImplementedException();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}