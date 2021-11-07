using amir_apparel_demo_api_dotnet_5.API;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using AutoMapper;

namespace amir_apparel_demo_api_dotnet_5.DTOs.MapperProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
