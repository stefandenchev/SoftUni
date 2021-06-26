namespace BattleCards.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Card
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(CardMaxLength)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Keyword { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Attack { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Health { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public IEnumerable<UserCard> Cards { get; init; } = new List<UserCard>();
    }
}