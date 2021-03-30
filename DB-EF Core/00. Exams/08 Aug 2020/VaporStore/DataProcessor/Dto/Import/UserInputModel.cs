﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UserInputModel
    {
        [Required]
        [RegularExpression("[A-Z][a-z]+ [A-Z][a-z]+")] //{2,}
        public string FullName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        public List<UserCardInputModel> Cards { get; set; }
    }
}
