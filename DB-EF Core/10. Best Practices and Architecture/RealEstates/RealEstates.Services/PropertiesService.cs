﻿using AutoMapper.QueryableExtensions;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstates.Services
{
    public class PropertiesService : BaseService, IPropertiesService
    {
        private readonly ApplicationDbContext dbContext;
        public PropertiesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(string district, int price, byte floor, byte maxFloor,
            int size, int yardSize, int year, string propertyType, string buildingType)
        {
            var property = new Property
            {
                Size = size,
                Price = price <= 0 ? null : price,
                Floor = floor <= 0 || floor > 255 ? null : floor,
                TotalFloors = maxFloor <= 0 || maxFloor > 255 ? null : maxFloor,
                YardSize = yardSize <= 0 ? null : yardSize,
                Year = year <= 1800 ? null : year
            };

            var dbDistrict = dbContext.Districts.FirstOrDefault(x => x.Name == district);
            if (dbDistrict == null)
            {
                dbDistrict = new District { Name = district };
            }
            property.District = dbDistrict;

            var dbPropertyType = dbContext.PropertyTypes.FirstOrDefault(x => x.Name == propertyType);
            if (dbPropertyType == null)
            {
                dbPropertyType = new PropertyType { Name = propertyType };
            }
            property.Type = dbPropertyType;

            var dbBuildingType = dbContext.Buildings.FirstOrDefault(x => x.Name == buildingType);
            if (dbBuildingType == null)
            {
                dbBuildingType = new BuildingType { Name = buildingType };
            }
            property.BuildingType = dbBuildingType;

            dbContext.Properties.Add(property);
            dbContext.SaveChanges();
        }

        public decimal AveragePricePerSquareMeter()
        {
            return dbContext.Properties.Where(x => x.Price.HasValue)
                .Average(x => x.Price / (decimal)x.Size) ?? 0;
        }

        public decimal AveragePricePerSquareMeter(int districtId)
        {
            return dbContext.Properties.Where(x => x.Price.HasValue && x.DistrictId == districtId)
                .Average(x => x.Price / (decimal)x.Size) ?? 0;
        }

        public double AverageSize(int districtId)
        {
            return dbContext.Properties.Where(x => x.DistrictId == districtId)
                .Average(x => x.Size);
        }

        public IEnumerable<PropertyInfoFullData> GetFullData(int count)
        {
            var properties = dbContext.Properties
                .Where(x => x.Floor.HasValue && x.Floor.Value > 1
                && x.Year.HasValue && x.Year > 2010)
                .ProjectTo<PropertyInfoFullData>(this.Mapper.ConfigurationProvider)
                .OrderByDescending(x => x.Price)
                .ThenBy(x => x.Size)
                .ThenBy(x => x.Year)
                .Take(count)
                .ToList();

            return properties;
        }

        public IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice,
            int minSize, int maxSize)
        {
            var properties = dbContext.Properties.Where(x => x.Price >= minPrice && x.Price <= maxPrice &&
            x.Size >= minSize && x.Size <= maxSize)
                .ProjectTo<PropertyInfoDto>(this.Mapper.ConfigurationProvider)
                .ToList();
            return properties;
        }
    }
}
