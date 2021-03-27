using System;
using System.Collections.Generic;
using System.Text;

namespace SoftJail.DataProcessor.ExportDto
{
    public class ExPrisonerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CellNumber { get; set; }
        public ICollection<ExOfficerDto> Officers { get; set; }
        public decimal OfficerSalaries { get; set; }
    }
}
