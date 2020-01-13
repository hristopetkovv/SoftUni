namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Data;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;
    using System;
    using System.Linq;
    using System.IO;
    using System.Xml.Serialization;
    using AutoMapper.QueryableExtensions;
    using ProductShop.Dtos.Export;
    using System.Text;
    using System.Xml;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper
                .Initialize(cfg => cfg.AddProfile<ProductShopProfile>());

            using (var db = new ProductShopContext())
            {
                //var inputXml = File.ReadAllText("./../../../Datasets/categories-products.xml");

                //var result = ImportCategoryProducts(db, inputXml);

                Console.WriteLine(GetUsersWithProducts(db));
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportUsersDto[]),
                                new XmlRootAttribute("Users"));

            ImportUsersDto[] usersDtos;

            using (var reader = new StringReader(inputXml))
            {
                usersDtos = (ImportUsersDto[])xmlSerializer.Deserialize(reader);
            }

            var users = Mapper.Map<User[]>(usersDtos);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProductsDto[]),
                                new XmlRootAttribute("Products"));

            ImportProductsDto[] productsDtos;

            using (var reader = new StringReader(inputXml))
            {
                productsDtos = (ImportProductsDto[])xmlSerializer.Deserialize(reader);
            }

            var products = Mapper.Map<Product[]>(productsDtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoriesDto[]),
                                new XmlRootAttribute("Categories"));

            ImportCategoriesDto[] categoriesDtos;

            using (var reader = new StringReader(inputXml))
            {
                categoriesDtos = (ImportCategoriesDto[])xmlSerializer.Deserialize(reader);
            }

            var categories = Mapper.Map<Category[]>(categoriesDtos);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoriesAndProductsDto[]),
                                new XmlRootAttribute("CategoryProducts"));

            ImportCategoriesAndProductsDto[] dtos;

            using (var reader = new StringReader(inputXml))
            {
                dtos = (ImportCategoriesAndProductsDto[])xmlSerializer.Deserialize(reader);
            }

            var categoryProducts = Mapper.Map<CategoryProduct[]>(dtos);

            var categories = context.Categories.Select(c => c.Id);
            var products = context.Products.Select(p => p.Id);

            var validCategoryProduct = categoryProducts
                .Where(cp => categories.Contains(cp.CategoryId) && products.Contains(cp.ProductId));

            context.CategoryProducts.AddRange(validCategoryProduct);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ExportProductInRangeDto>()
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProductInRangeDto[]),
                                new XmlRootAttribute("Products"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ProjectTo<ExportSoldProductsDto>()
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportSoldProductsDto[]),
                new XmlRootAttribute("Users"));

            var stringBuilder = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(stringBuilder), users, namespaces);

            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .ProjectTo<ExportCategoriesByProductsCountDto>()
                .OrderByDescending(cp => cp.Count)
                .ThenBy(cp => cp.TotalRevenue)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCategoriesByProductsCountDto[]),
                new XmlRootAttribute("Categories"));

            var stringBuilder = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(stringBuilder), categories, namespaces);

            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.ProductsSold.Count)
                .Select(u => new ExportUsersAndProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsDto
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                        .OrderByDescending(ps => ps.Price)
                        .Select(ps => new ExportUserSoldProductsDto
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        })
                        .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            var result = new GetCountAndUsersWithProductsDto
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = users
            };

            var xmlSerializer = new XmlSerializer(typeof(GetCountAndUsersWithProductsDto),
                new XmlRootAttribute("Users"));

            var stringBuilder = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(stringBuilder), result, namespaces);

            return stringBuilder.ToString().TrimEnd();
        }
    }
}