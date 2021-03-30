namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using ProductShop.XmlHelp;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context
                .Genres
                .ToArray()
                .Where(x => genreNames.Contains(x.Name))
                .Select(genre => new
                {
                    Id = genre.Id,
                    Genre = genre.Name,
                    Games = genre.Games.Where(game => game.Purchases.Any()).Select(game => new
                    {
                        Id = game.Id,
                        Title = game.Name,
                        Developer = game.Developer.Name,
                        Tags = string.Join(", ", game.GameTags.Select(gt => gt.Tag.Name).ToArray()),
                        Players = game.Purchases.Count
                    })
                    .OrderByDescending(game => game.Players)
                    .ThenBy(game => game.Id)
                    .ToArray(),
                    TotalPlayers = genre.Games.Sum(ga => ga.Purchases.Count)
                })
                .OrderByDescending(genre => genre.TotalPlayers)
                .ThenBy(genre => genre.Id)
                .ToArray();


            var jsonResult = JsonConvert.SerializeObject(genres, Formatting.Indented);

            return jsonResult;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var users = context
                .Users
                .ToList()
                .Where(x => x.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
                .Select(x => new UserPurchaseOutputModel
                {
                    Username = x.Username,

                    TotalSpent = x.Cards.Sum(
                        c => c.Purchases
                        .Where(p => p.Type.ToString() == storeType)
                        .Sum(x => x.Game.Price)),

                    Purchases = x.Cards.SelectMany(c => c.Purchases)
                    .Where(p => p.Type.ToString() == storeType)
                    .Select(p => new PurchaseOutputModel
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new GameOutputModel
                        {
                            Title = p.Game.Name,
                            Price = p.Game.Price,
                            Genre = p.Game.Genre.Name
                        }
                    })
                    .OrderBy(x => x.Date)
                    .ToArray()
                })
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.Username)
                .ToArray();

            string root = "Users";
            string xmlResult = XmlConverter.Serialize(users, root);

            return xmlResult;
        }
    }
}