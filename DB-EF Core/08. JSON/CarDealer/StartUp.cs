using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //string suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //string partsJson = File.ReadAllText("../../../Datasets/parts.json");
            string carsJson = File.ReadAllText("../../../Datasets/cars.json");

            //ImportSuppliers(db, suppliersJson);
            //ImportParts(db, partsJson);
            Console.WriteLine(ImportCars(db, carsJson)); 
        }

        //11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoCars = JsonConvert.DeserializeObject<IEnumerable<CarInputModel>>(inputJson);
            var cars = mapper.Map<IEnumerable<Car>>(dtoCars);

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }
        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var dtoParts = JsonConvert.DeserializeObject<IEnumerable<PartInputModel>>(inputJson)
                .Where(x => supplierIds.Contains(x.SupplierId))
                .ToList();
            var parts = mapper.Map<IEnumerable<Part>>(dtoParts);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoSuppliers = JsonConvert.DeserializeObject<IEnumerable<SupplierInputModel>>(inputJson);
            var suppliers = mapper.Map<IEnumerable<Supplier>>(dtoSuppliers);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }
        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}