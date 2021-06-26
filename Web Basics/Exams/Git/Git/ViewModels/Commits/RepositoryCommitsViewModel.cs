namespace Git.ViewModels.Commits
{
    using System;

    public class RepositoryCommitsViewModel
    {
        public string Id { get; init; }

        public string RepName { get; init; }

        public string Description { get; init; }

        public DateTime CreatedOn { get; init; }
    }
}
