namespace Git.Controllers
{
    using System;
    using System.Linq;
    using Git.Data;
    using Git.Data.Models;
    using Git.Services;
    using Git.ViewModels.Repositories;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class RepositoriesController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IValidator validator;

        public RepositoriesController(
            ApplicationDbContext db,
            IValidator validator)
        {
            this.db = db;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateRepositoryInputModel model)
        {
            var modelErrors = this.validator.ValidateRepository(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var repository = new Repository
            {
                Name = model.Name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = model.RepositoryType == "Public",
                OwnerId = this.User.Id
            };

            this.db.Repositories.Add(repository);

            this.db.SaveChanges();

            return Redirect("/Repositories/All");
        }

        public HttpResponse All()
        {
            var repsQuery = this.db.Repositories.Where(x => x.IsPublic || x.OwnerId == User.Id).AsQueryable();

            var repositories = repsQuery
                .Select(x => new RepositoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Owner = x.Owner.Username,
                    CreatedOn = x.CreatedOn,
                    CommitsCount = x.Commits.Count(),
                })
                .ToList();

            return View(repositories);
        }
    }
}
