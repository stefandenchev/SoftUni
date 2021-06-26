namespace SharedTrip.Services
{
    using System.Collections.Generic;

    using SharedTrip.Models.Trips;
    using SharedTrip.Models.Users;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidateTrip(AddTripFormModel model);
    }
}
