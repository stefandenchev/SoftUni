using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using CarDealer.XmlHelp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //var suppliersXml = File.ReadAllText("./Datasets/suppliers.xml");
            //var partsXml = File.ReadAllText("./Datasets/parts.xml");
            var carsXml = File.ReadAllText("./Datasets/cars.xml");

            //ImportSuppliers(db, suppliersXml);
            //ImportParts(db, partsXml);
            var resultCars = ImportCars(db, carsXml);

            Console.WriteLine(resultCars);
        }


        //11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarsDTO[]), new XmlRootAttribute("Cars"));

            ImportCarsDTO[] carsDtos = (ImportCarsDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var cars = new List<Car>();
            var partCars = new List<PartCar>();

            foreach (var carDto in carsDtos)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                var parts = carDto
                    .Parts
                    .Where(pc => context.Parts.Any(p => p.Id == pc.Id))
                    .Select(p => p.Id)
                    .Distinct();

                foreach (var part in parts)
                {
                    PartCar partCar = new PartCar()
                    {
                        PartId = part,
                        Car = car
                    };

                    partCars.Add(partCar);
                }

                cars.Add(car);

            }

            context.PartCars.AddRange(partCars);

            context.Cars.AddRange(cars);

            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
            /* const string root = "Cars";

             var dto = XmlConverter.Deserialize<CarInputModel>(inputXml, root);

             var allParts = context.Parts.Select(x => x.Id).ToList();

             var cars = dto
                 .Select(x => new Car
                 {
                     Make = x.Make,
                     Model = x.Model,
                     TravelledDistance = x.TraveledDistance,
                     PartCars = x.CarPartsInputModel.Select(x => x.Id)
                         .Distinct()
                         .Intersect(allParts)
                         .Select(x => new PartCar
                         {
                             PartId = x
                         })
                     .ToList()
                 })
                 .ToList();


             context.Cars.AddRange(cars);
             context.SaveChanges();

             return $"Successfully imported {cars.Count}";*/
        }

        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string root = "Parts";

            var partsDto = XmlConverter.Deserialize<ImportPartsDTO>(inputXml, root);

            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var parts = partsDto
                .Where(s => supplierIds.Contains(s.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSupplierDTO[]), new XmlRootAttribute("Suppliers"));
            var textRead = new StringReader(inputXml);
            var suppliersDto = xmlSerializer.Deserialize(textRead) as ImportSupplierDTO[];

            var suppliers = suppliersDto.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter
            })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }



    }
}