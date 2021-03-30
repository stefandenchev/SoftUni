using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UserCardInputModel
    {
        [Required]
        [RegularExpression("[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}")] // ([0-9]{4} ){3}[0-9]{4}
        public string Number { get; set; }

        [RegularExpression("[0-9]{3}")]
        public string CVC { get; set; }

        [Required]
        public CardType? Type { get; set; }
    }
}