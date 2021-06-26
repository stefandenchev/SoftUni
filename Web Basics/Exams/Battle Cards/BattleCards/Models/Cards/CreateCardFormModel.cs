namespace BattleCards.Models.Cards
{

    using System;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;
    public class CreateCardFormModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(CardMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

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
    }
}
