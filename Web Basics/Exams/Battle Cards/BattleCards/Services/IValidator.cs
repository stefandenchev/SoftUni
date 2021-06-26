namespace BattleCards.Services
{
    using System.Collections.Generic;
    using BattleCards.Models.Cards;
    using BattleCards.Models.Users;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);
        ICollection<string> ValidateCard(CreateCardFormModel model);
    }
}
