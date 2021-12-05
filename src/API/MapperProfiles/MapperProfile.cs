using Amir.Apparel.Demo.Api.Dotnet.API.DTOs;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using AutoMapper;

namespace Amir.Apparel.Demo.Api.Dotnet.API.MapperProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductResponseDTO>().ReverseMap();

            CreateMap<Purchase, PurchaseResponseDTO>()
                .ForMember(dest => dest.BillingAddress, opt => opt.MapFrom(src => src.BuildBillingAddress()))
                .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.BuildShippingAddress()))
                .ReverseMap();
            CreateMap<Purchase, PurchaseRequestDTO>()
                .ForMember(dest => dest.BillingAddress, opt => opt.MapFrom(src => src.BuildBillingAddress()))
                .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.BuildShippingAddress()))
                .ReverseMap();

            CreateMap<Address, AddressResponseDTO>().ReverseMap();
            CreateMap<Address, AddressRequestDTO>().ReverseMap();

            CreateMap<LineItem, LineItemResponseDTO>().ReverseMap();
            CreateMap<LineItem, LineItemRequestDTO>().ReverseMap();
        }
    }
}
