namespace Git.Controllers
{
    using System;
    using System.Linq;
    using Git.Data;
    using Git.Data.Models;
    using Git.ViewModels.Commits;
    using Git.ViewModels.Repositories;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class CommitsController : Controller
    {
        private readonly ApplicationDbContext db;

        public CommitsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Authorize]
        public HttpResponse All(string repId)
        {
            var commits = this.db
                .Commits
                .Where(c => c.CreatorId == User.Id)
                .Select(c => new RepositoryCommitsViewModel
                {
                    Id = c.Id,
                    RepName = c.Repository.Name,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn
                })
                .ToList();

            if (commits == null)
            {
                return Error($"Repository with ID '{repId}' does not exist.");
            }

            return View(commits);
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var repository = this.db
                .Repositories
                .Where(x => x.Id == id)
                .Select(x => new RepositoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .FirstOrDefault();

            return this.View(repository);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateCommitInputModel model)
        {
            var commit = new Commit
            {
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = this.User.Id,
                RepositoryId = model.Id
            };

            this.db.Commits.Add(commit);

            this.db.SaveChanges();

            return Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var commit = this.db.Commits
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (commit == null || commit.CreatorId != User.Id)
            {
                return BadRequest();
            }

            this.db.Commits.Remove(commit);
            this.db.SaveChanges();

            return Redirect("/Commits/All");
        }
    }
}
