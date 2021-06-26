namespace BattleCards.Controllers
{
    using BattleCards.Data;
    using BattleCards.Data.Models;
    using BattleCards.Models.Cards;
    using BattleCards.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class CardsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IValidator validator;

        public CardsController(ApplicationDbContext db, IValidator validator)
        {
            this.db = db;
            this.validator = validator;
        }
        public HttpResponse All()
        {
            var cards = this.db.Cards
                .Select(r => new CardListingViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Attack = r.Attack,
                    Health = r.Health,
                    ImageUrl = r.ImageUrl,
                    Description = r.Description,
                    Keyword = r.Keyword
                })
                .ToList();

            return View(cards);
        }

        [Authorize]
        public HttpResponse Add() => View();

        [HttpPost]
        [Authorize]
        public HttpResponse Add(CreateCardFormModel model)
        {
            var modelErrors = this.validator.ValidateCard(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var repository = new Card
            {
                Name = model.Name,
                Description = model.Description,
                Attack = model.Attack,
                Health = model.Health,
                ImageUrl = model.Image,
                Keyword = model.Keyword,
            };

            this.db.Cards.Add(repository);

            this.db.SaveChanges();

            return Redirect("/Cards/All");
        }
    }
}
