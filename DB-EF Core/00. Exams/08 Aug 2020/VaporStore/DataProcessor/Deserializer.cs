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
            StringBuilder sb = new StringBuilder();

            GameImportModel[] games = JsonConvert.DeserializeObject<GameImportModel[]>(jsonString);

            foreach (var currGame in games)
            {
                if (!IsValid(currGame)
                    || !currGame.Tags.Any()) // Tags.Count() == 0
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //Either find it in the DB or create it if missing.
                var genre = context.Genres.FirstOrDefault(x => x.Name == currGame.Genre)
                    ?? new Genre { Name = currGame.Genre }; 
                var developer = context.Developers.FirstOrDefault(x => x.Name == currGame.Developer)
                    ?? new Developer { Name = currGame.Developer };


                Game game = new Game
                {
                    Name = currGame.Name,
                    Price = currGame.Price,
                    ReleaseDate = currGame.ReleaseDate.Value,
                    Developer = developer,
                    Genre = genre
                };

                foreach (var tag in currGame.Tags)
                {
                    var gameTag = context.Tags.FirstOrDefault(x => x.Name == tag)
                        ?? new Tag { Name = tag };
                    game.GameTags.Add(new GameTag { Tag = gameTag });
                }

                context.Games.Add(game);
                context.SaveChanges();

                sb.AppendLine($"Added {currGame.Name} ({currGame.Genre}) with {currGame.Tags.Count()} tags!");

            } 

            return sb.ToString().TrimEnd();
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