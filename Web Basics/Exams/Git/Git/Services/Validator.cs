namespace Git.Services
{
    using Git.ViewModels.Repositories;
    using Git.ViewModels.User;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterViewModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UserMinUsername || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UserMinUsername} and {DefaultMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < UserMinPassword || model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPassword} and {DefaultMaxLength} characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            return errors;
        }

        public ICollection<string> ValidateRepository(CreateRepositoryInputModel model)
        {
            var errors = new List<string>();

            if (model.Name.Length < 3 || model.Name.Length > 10)
            {
                errors.Add($"Name '{model.Name}' is not valid. It must be between 3 and 10 characters long.");
            }

            return errors;
        }
    }
}
