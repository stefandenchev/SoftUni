using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using CarDealer.XmlHelp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            /*db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var suppliersXml = File.ReadAllText("./Datasets/suppliers.xml");
            var partsXml = File.ReadAllText("./Datasets/parts.xml");
            var carsXml = File.ReadAllText("./Datasets/cars.xml");
            var customersXml = File.ReadAllText("./Datasets/customers.xml");
            var salesXml = File.ReadAllText("./Datasets/sales.xml");

            ImportSuppliers(db, suppliersXml);
            ImportParts(db, partsXml);
            var resultCars = ImportCars(db, carsXml);
            var resultCustomers = ImportCustomers(db, customersXml);
            var resultSales = ImportSales(db, salesXml);
            Console.WriteLine(resultSales);*/

            Console.WriteLine(GetSalesWithAppliedDiscount(db));
        }
        //19. Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new ExportSaleDTO
                {
                   Car = new ExportCarSaleDTO
                   {
                       Make = x.Car.Make,
                       Model = x.Car.Model,
                       TravelledDistance = x.Car.TravelledDistance
                   },
                   Discount = x.Discount,
                   CustomerName = x.Customer.Name,
                   Price = x.Car.PartCars.Sum(p => p.Part.Price),
                   PriceWithDiscount = (x.Car.PartCars.Sum(p => p.Part.Price))
                   - (x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100)
                })
                .ToArray();

            var root = new XmlRootAttribute("sales");
            var serializer = new XmlSerializer(typeof(ExportSaleDTO[]), root);

            var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, sales, ns);

            var result = writer.ToString();
            return result;
        }
        //18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var cars = context.Customers          
                .Where(x => x.Sales.Any())
                .Select(x => new ExportCustomerTotalSalesDTO
                {
                    Name = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Select(x => x.Car).SelectMany(x => x.PartCars).Sum(p => p.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            var root = new XmlRootAttribute("customers");
            var serializer = new XmlSerializer(typeof(ExportCustomerTotalSalesDTO[]), root);

            var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, cars, ns);

            var result = writer.ToString();
            return result;
        }
        //17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new ExportCarWithPartsDTO
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(p => new ExportPartCarsDTO
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            var root = new XmlRootAttribute("cars");
            var serializer = new XmlSerializer(typeof(ExportCarWithPartsDTO[]), root);

            var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, cars, ns);

            var result = writer.ToString();
            return result;
        }
        //16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new ExportLocalSuppliersDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToArray();

            var root = new XmlRootAttribute("suppliers");
            var serializer = new XmlSerializer(typeof(ExportLocalSuppliersDTO[]), root);

            var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, suppliers, ns);

            var result = writer.ToString();
            return result;
        }
        //15. Export Cars From Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new ExportCarsBMWDTO
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportCarsBMWDTO[]), new XmlRootAttribute("cars"));

            var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, cars, ns);

            var result = writer.ToString();
            return result;
        }
        //14. Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2_000_000)
                .Select(x => new ExportCarSaleDTO
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportCarSaleDTO[]), new XmlRootAttribute("cars"));

            var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, cars, ns);

            var result = writer.ToString();
            return result;
        }
        //13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string root = "Sales";

            var salesDto = XmlConverter.Deserialize<ImportSaleDTO>(inputXml, root);

            var carIds = context.Cars
                .Select(x => x.Id)
                .ToList();

            var sales = salesDto
                .Where(s => carIds.Contains(s.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }
        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string root = "Customers";
            InitializeAutoMapper();

            var customersDto = XmlConverter.Deserialize<ImportCustomerDTO>(inputXml, root);
            var customers = mapper.Map<Customer[]>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
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