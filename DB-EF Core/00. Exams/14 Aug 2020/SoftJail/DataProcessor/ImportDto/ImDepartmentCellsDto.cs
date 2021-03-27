using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImDepartmentCellsDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        //[StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public ImCellsDto[] Cells { get; set; }
    }
}