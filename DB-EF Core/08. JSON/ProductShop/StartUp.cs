using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTO;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        //private static string ResultsDirectoryPath = "../../../Datasets/Tasks";
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            /*db.Database.EnsureDeleted();
            db.Database.EnsureCreated();*/

            /*string usersJson = File.ReadAllText("../../../Datasets/users.json");
            string productsJson = File.ReadAllText("../../../Datasets/products.json");
            string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            string categoriesProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");*/

            string json = GetUsersWithProducts(db);
            //File.WriteAllText(ResultsDirectoryPath + "/products-in-range.json.json", json);   <-- if you want a file
            Console.WriteLine(json);

            /*ImportUsers(db, usersJson);
            ImportProducts(db, productsJson);
            ImportCategories(db, categoriesJson);
            ImportCategoryProducts(db, categoriesProductsJson);*/
        }

        //08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Where(y => y.BuyerId != null).Count(),
                        products = x.ProductsSold.Where(y => y.BuyerId != null).Select(pr => new
                        {
                            name = pr.Name,
                            price = pr.Price
                        })
                    }
                })
                .OrderByDescending(x => x.soldProducts.count)
                .ToList();

            var result = new
            {
                usersCount = users.Count(),
                users = users
            };

            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var jsonResult = JsonConvert.SerializeObject(result, jsonSettings);
            return jsonResult;
        }

        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count(),
                    averagePrice = x.CategoryProducts.Average(p => p.Product.Price).ToString("F2"),
                    totalRevenue = x.CategoryProducts.Sum(p => p.Product.Price).ToString("F2")
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var jsonResult = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return jsonResult;
        }

        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Select(y => new
                    {
                        name = y.Name,
                        price = y.Price,
                        buyerFirstName = y.Buyer.FirstName,
                        buyerLastName = y.Buyer.LastName,
                    })
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var jsonResult = JsonConvert.SerializeObject(users, Formatting.Indented);

            return jsonResult;
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .OrderBy(x => x.price)
                .ToList();

            var jsonResult = JsonConvert.SerializeObject(products, Formatting.Indented);

            return jsonResult;
        }

        //04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoCategoryProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJson);

            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoryProducts);

            context.CategoryProducts.AddRange(categoryProducts);
            int count = categoryProducts.Count();
            context.SaveChanges();

            return $"Successfully imported {count}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoCategories = JsonConvert.DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson)
                .Where(x => x.Name != null)
                .ToList();

            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);
            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);
            int count = products.Count();
            context.SaveChanges();

            return $"Successfully imported {count}";
        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);
            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}