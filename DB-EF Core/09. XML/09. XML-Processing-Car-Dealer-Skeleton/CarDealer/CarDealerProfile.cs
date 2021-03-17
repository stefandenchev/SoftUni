using AutoMapper;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportCustomerDTO, Customer>()
                .ForMember(x => x.BirthDate, y => y.MapFrom(s => DateTime.Parse(s.BirthDate)));
        }
    }
}
