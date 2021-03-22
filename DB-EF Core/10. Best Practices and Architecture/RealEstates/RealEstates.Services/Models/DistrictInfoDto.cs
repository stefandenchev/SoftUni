using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Services.Models
{
    public class DistrictInfoDto
    {
        public string Name { get; set; }
        public decimal AveragePricePerSquareMeter { get; set; }
        public int PropertiesCount { get; set; }
    }
}
