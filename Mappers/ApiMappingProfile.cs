using AutoMapper;
using SanriJP.API.Models;
using System;

namespace SanriJP.API.Mappers
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            #region ModelRequests to Entities

            CreateMap<CreateClientRequest, Client>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(p => DateTime.UtcNow))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(p => p.Login.ToUpper()));

            CreateMap<CreateEmployeeRequest, Employee>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(p => DateTime.UtcNow))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(p => p.Login.ToUpper()));
            
            CreateMap<CreateCarOrderRequest, CarOrder>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(p => DateTime.UtcNow))
                .ForMember(dest => dest.Price10Percent, opt => opt.MapFrom(p => p.Price / 10));
            
            CreateMap<CreateCarSaleRequest, CarSale>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(p => DateTime.UtcNow))
                .ForMember(dest => dest.Price10Percent, opt => opt.MapFrom(p => p.Price / 10));

            CreateMap<CreateCarResaleRequest, CarResale>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(p => DateTime.UtcNow));

            #endregion
        }
    }
}
