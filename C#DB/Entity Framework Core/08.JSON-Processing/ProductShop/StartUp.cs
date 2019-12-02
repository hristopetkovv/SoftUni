using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new ProductShopContext())
            {
                var inputJson = File.ReadAllText("./../../../Datasets/products.json");

                var result = ImportProducts(db, inputJson);

                Console.WriteLine(result);
            }
        }

        //P01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }


        //P02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //P03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson);
            var validCategories = categories
                .Where(x => x.Name != null
                        && x.Name.Length >= 3 && x.Name.Length <= 13)
                 .ToArray();

            context.Categories.AddRange(validCategories);

            context.SaveChanges();

            return $"Successfully imported {validCategories.Length}";
        }

        //P04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoriesProducts);

            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }

        //P05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        //P06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSales = context
                .Users
                .Where(u => u.ProductsSold.Count > 0
                        && u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Include(u => u.ProductsSold)
                .ToList();

            var jsonExport = Mapper.Map<IEnumerable<User>, IEnumerable<UserWithSalesDto>>(usersWithSales);

            DefaultContractResolver contractResolver = new DefaultContractResolver();
            {
                var namingStrategy = new CamelCaseNamingStrategy();
            }

            var jsonResult = JsonConvert.SerializeObject(jsonExport, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            return jsonResult;
        }

        //P07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AveragePrice = $"{c.CategoryProducts.Average(cp => cp.Product.Price):f2}",
                    TotalRevenue = $"{c.CategoryProducts.Sum(cp => cp.Product.Price):f2}"
                });

            DefaultContractResolver contractResolver = new DefaultContractResolver();
            {
                var namingStrategy = new CamelCaseNamingStrategy();
            }

            var jsonResult = JsonConvert.SerializeObject(categories, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            return jsonResult;
        }

        //P08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(p => p.Buyer != null),
                        products = u.ProductsSold
                                .Where(p => p.Buyer != null)
                                .Select(ps => new
                                {
                                    name = ps.Name,
                                    price = ps.Price
                                })
                    }
                })
                .ToList();

            var userOutput = new
            {
                usersCount = users.Count,
                users = users
            };

            var json = JsonConvert.SerializeObject(userOutput, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }
    }
}