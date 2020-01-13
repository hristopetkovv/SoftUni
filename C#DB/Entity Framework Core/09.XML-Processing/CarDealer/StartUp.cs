namespace CarDealer
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Xml.Serialization;

    using CarDealer.Data;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;

    using AutoMapper;
    using System.Collections.Generic;
    using AutoMapper.QueryableExtensions;
    using CarDealer.Dtos.Export;
    using System.Text;
    using System.Xml;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper
                .Initialize(cfg => cfg.AddProfile<CarDealerProfile>());

            using (var db = new CarDealerContext())
            {
                //var inputXml = File.ReadAllText("./../../../Datasets/sales.xml");

                //var result = GetCarsWithDistance(db);

                Console.WriteLine(GetSalesWithAppliedDiscount(db));
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]),
                                new XmlRootAttribute("Suppliers"));

            ImportSupplierDto[] suppliersDtos;

            using (var reader = new StringReader(inputXml))
            {
                suppliersDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(reader);
            }

            var suppliers = Mapper.Map<Supplier[]>(suppliersDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]),
                                new XmlRootAttribute("Parts"));

            ImportPartDto[] partDtos;

            using (var reader = new StringReader(inputXml))
            {
                partDtos = ((ImportPartDto[])xmlSerializer
                    .Deserialize(reader))
                    .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                    .ToArray();
            }

            var parts = Mapper.Map<Part[]>(partDtos);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCarsDto[]),
                             new XmlRootAttribute("Cars"));

            var carDtos = (ImportCarsDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var cars = new List<Car>();

            foreach (var carDto in carDtos)
            {
                var car = Mapper.Map<Car>(carDto);

                foreach (var part in carDto.Parts)
                {
                    var partCarExists = car
                        .PartCars
                        .FirstOrDefault(p => p.PartId == part.PartId) != null;

                    if (!partCarExists && context.Parts.Any(p => p.Id == part.PartId))
                    {
                        var partCar = new PartCar
                        {
                            CarId = car.Id,
                            PartId = part.PartId
                        };

                        car.PartCars.Add(partCar);
                    }
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {context.Cars.ToList().Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]),
                                new XmlRootAttribute("Customers"));

            ImportCustomerDto[] customerDtos;

            using (var reader = new StringReader(inputXml))
            {
                customerDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(reader);
            }

            var customers = Mapper.Map<Customer[]>(customerDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSalesDto[]),
                                new XmlRootAttribute("Sales"));

            var salesDtos = (ImportSalesDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var carsId = context.Cars.Select(c => c.Id);

            var validSales = new List<ImportSalesDto>();

            foreach (var sale in salesDtos)
            {
                if (carsId.Contains(sale.CarId))
                {
                    validSales.Add(sale);
                }
            }

            var sales = Mapper.Map<Sale[]>(validSales);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarWithDistanceDto>()
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCarWithDistanceDto[]),
                                new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<ExportCarFromMakeBmwDto>()
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCarFromMakeBmwDto[]),
                                new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => !s.IsImporter)
                .ProjectTo<ExportLocalSupplierDto>()
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportLocalSupplierDto[]),
                                new XmlRootAttribute("suppliers"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new ExportCarsWithTheirListOfParts
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(pc => new ExportPartsOfCarsDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCarsWithTheirListOfParts[]),
                            new XmlRootAttribute("cars"));

            var stringBuilder = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(stringBuilder), cars, namespaces);

            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Any())
                .ProjectTo<ExportTotalSalesByCustomerDto>()
                .OrderByDescending(cdto => cdto.SpentMoney)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportTotalSalesByCustomerDto[]),
                            new XmlRootAttribute("customers"));

            var stringBuilder = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(stringBuilder), customers, namespaces);

            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .ProjectTo<ExportSalesWithAppliedDiscountDto>()
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportSalesWithAppliedDiscountDto[]),
                            new XmlRootAttribute("sales"));

            var stringBuilder = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(stringBuilder), sales, namespaces);

            return stringBuilder.ToString().TrimEnd();
        }
    }
}