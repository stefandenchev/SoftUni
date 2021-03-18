using RealEstates.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Services
{
    public interface IPropertiesService
    {
        void Add(string district, int price, byte floor,
            byte maxFloor, int size, int yardSize, int year,
            string propertyType, string buildingType);

        IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice,
            int minSize, int maxSize);
    }
}
