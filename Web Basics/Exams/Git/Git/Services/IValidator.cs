namespace Git.Services
{
    using Git.ViewModels.Repositories;
    using Git.ViewModels.User;
    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterViewModel model);

        ICollection<string> ValidateRepository(CreateRepositoryInputModel model);
    }
}
