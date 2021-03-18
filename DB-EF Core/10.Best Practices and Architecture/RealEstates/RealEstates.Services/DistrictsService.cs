﻿using RealEstates.Data;
using RealEstates.Services.Models;
using System.Collections.Generic;

namespace RealEstates.Services
{
    public class DistrictsService : IDistrictsService
    {
        private readonly ApplicationDbContext dbContext;

        public DistrictsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count)
        {
            return new List<DistrictInfoDto>();
        }
    }
}
