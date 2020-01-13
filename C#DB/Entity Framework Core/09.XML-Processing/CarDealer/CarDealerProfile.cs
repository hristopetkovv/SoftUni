namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Dtos.Export;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;
    using System.Linq;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();

            this.CreateMap<ImportPartDto, Part>();

            this.CreateMap<ImportCarsDto, Car>();

            this.CreateMap<ImportCustomerDto, Customer>();

            this.CreateMap<ImportSalesDto, Sale>();

            this.CreateMap<Customer, ExportTotalSalesByCustomerDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.NumberOfBoughtCars, opt => opt.MapFrom(src => src.Sales.Count))
                .ForMember(dest => dest.SpentMoney, opt => opt.MapFrom(src => src.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))));


            this.CreateMap<Sale, ExportSalesWithAppliedDiscountDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Car.PartCars.Sum(pc => pc.Part.Price)))
                .ForMember(dest => dest.PriceWithDiscount,
                                    opt => opt.MapFrom(src => src.Car.PartCars.Sum(pc => pc.Part.Price) 
                                    - (src.Car.PartCars.Sum(pc => pc.Part.Price) * src.Discount / 100)));
                

        }
    }
}
