namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;
    using System.Linq;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUsersDto, User>();

            this.CreateMap<ImportProductsDto, Product>();

            this.CreateMap<ImportCategoriesDto, Category>();

            this.CreateMap<ImportCategoriesAndProductsDto, CategoryProduct>();

            this.CreateMap<Product, ExportProductInRangeDto>()
                .ForMember(dest => dest.Buyer, opt => opt.MapFrom(src => $"{src.Buyer.FirstName} {src.Buyer.LastName}"));

            this.CreateMap<User, ExportSoldProductsDto>();

            this.CreateMap<Category, ExportCategoriesByProductsCountDto>()
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.CategoryProducts.Count))
                .ForMember(dest => dest.AveragePrice, opt => opt.MapFrom(src => src.CategoryProducts.Average(cp => cp.Product.Price)))
                .ForMember(dest => dest.TotalRevenue, opt => opt.MapFrom(src => src.CategoryProducts.Sum(cp => cp.Product.Price)));

        }
    }
}
