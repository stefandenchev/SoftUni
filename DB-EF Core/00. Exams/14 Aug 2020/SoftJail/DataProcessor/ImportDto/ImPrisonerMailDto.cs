﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImPrisonerMailDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"The [A-Z][a-z]+")]
        public string Nickname { get; set; }

        [Range(18, 65)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        public decimal? Bail { get; set; }

        public int? CellId { get; set; }
        public ICollection<ImMailDto> Mails { get; set; }
    }
}