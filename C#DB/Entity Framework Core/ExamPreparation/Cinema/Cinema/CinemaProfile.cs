namespace Cinema
{
    using AutoMapper;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ExportDto;
    using System;
    using System.Linq;

    public class CinemaProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public CinemaProfile()
        {
            this.CreateMap<Customer, ExportCustomersWithSpentMoneyDto>()
                .ForMember(dest => dest.SpentMoney, opt => opt.MapFrom(src => src.Tickets.Sum(t => t.Price).ToString("F2")))
                .ForMember(dest => dest.SpentTime, opt => opt.MapFrom(src => TimeSpan.FromMilliseconds(
                    src.Tickets.Sum(t => t.Projection.Movie.Duration.TotalMilliseconds)).ToString(@"hh\:mm\:ss")));
        }
    }
}
