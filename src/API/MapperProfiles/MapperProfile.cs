using Amir.Apparel.Demo.Api.Dotnet.API.DTOs;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using AutoMapper;

namespace Amir.Apparel.Demo.Api.Dotnet.API.MapperProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Purchase, PurchaseResponseDTO>().ReverseMap();
        }
    }
}
