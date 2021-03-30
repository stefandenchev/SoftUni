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
    using ProductShop.XmlHelp;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            GameInputModel[] games = JsonConvert.DeserializeObject<GameInputModel[]>(jsonString);

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

                sb.AppendLine($"Added {currGame.Name} ({currGame.Genre}) with {currGame.Tags.Count()} tags");

            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            UserInputModel[] users = JsonConvert.DeserializeObject<UserInputModel[]>(jsonString);

            foreach (var currUser in users)
            {
                if (!IsValid(currUser)
                    || !currUser.Cards.All(IsValid)) // All(x => IsValid(x))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                User user = new User
                {
                    FullName = currUser.FullName,
                    Username = currUser.Username,
                    Email = currUser.Email,
                    Age = currUser.Age,
                    Cards = currUser.Cards.Select(x => new Card
                    {
                        Number = x.Number,
                        Cvc = x.CVC,
                        Type = x.Type.Value
                    })
                    .ToList()
                };

                /*                foreach (var card in currUser.Cards)
                                {
                                    user.Cards.Add(new Card
                                    {
                                        Number = card.Number,
                                        Cvc = card.CVC,
                                        Type = card.Type.Value
                                    });
                                }*/

                context.Users.Add(user);
                context.SaveChanges();

                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count()} cards");

            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var root = "Purchases";
            StringBuilder sb = new StringBuilder();

            PurchaseInputModel[] purchases = XmlConverter.Deserialize<PurchaseInputModel>(xmlString, root);

            foreach (var currPurchase in purchases)
            {
                if (!IsValid(currPurchase))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool parsedDate = DateTime.TryParseExact(
                    currPurchase.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var date);

                if (!parsedDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Purchase purchase = new Purchase
                {
                    Date = date,
                    Type = currPurchase.Type.Value,
                    ProductKey = currPurchase.Key,
                    Card = context.Cards.FirstOrDefault(x => x.Number == currPurchase.Card),
                    Game = context.Games.FirstOrDefault(x => x.Name == currPurchase.Title)
                };

                context.Purchases.Add(purchase);
                context.SaveChanges();

                var username = context.Users.Where(x => x.Id == purchase.Card.UserId)
                    .Select(x => x.Username).FirstOrDefault();

                sb.AppendLine($"Imported {currPurchase.Title} for {username}");

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