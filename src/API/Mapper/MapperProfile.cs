using Amir.Apparel.Demo.Api.Dotnet.API.DTOs;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using AutoMapper;

namespace Amir.Apparel.Demo.Api.Dotnet.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductResponseDTO>().ReverseMap();

            CreateMap<Purchase, PurchaseResponseDTO>()
                .ForMember(dest => dest.BillingAddress, opt => opt.MapFrom(src => src.BuildBillingAddress()))
                .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.BuildShippingAddress()))
                .ForMember(dest => dest.CreditCard, opt => opt.MapFrom(src => src.BuildCreditCard()))
                .ReverseMap();
            CreateMap<Purchase, PurchaseRequestDTO>()
                .ForMember(dest => dest.BillingAddress, opt => opt.MapFrom(src => src.BuildBillingAddress()))
                .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.BuildShippingAddress()))
                .ForMember(dest => dest.CreditCard, opt => opt.MapFrom(src => src.BuildCreditCard()))
                .ReverseMap();

            CreateMap<Address, AddressResponseDTO>().ReverseMap();
            CreateMap<Address, AddressRequestDTO>().ReverseMap();

            CreateMap<LineItem, LineItemResponseDTO>().ReverseMap();
            CreateMap<LineItem, LineItemRequestDTO>().ReverseMap();

            CreateMap<CreditCard, CreditCardResponseDTO>().ReverseMap();
            CreateMap<CreditCard, CreditCardRequestDTO>().ReverseMap();
            
            CreateMap<ApplicationUser, ApplicationUserResponseDTO>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserRequestDTO>().ReverseMap();
        }
    }
}
