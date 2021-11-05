using amir_apparel_demo_api_dotnet_5.API.QueryParams;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.DTOs;
using amir_apparel_demo_api_dotnet_5.Providers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductProvider _provider;
        private readonly IMapper _mapper;

        public int FromQuery { get; private set; }

        public ProductController(IProductProvider provider)
        {
            _provider = provider;
            _mapper = InitializeMapper();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync(
            [FromQuery] PaginationQueryParams productParameters
        )
        {
            var products = await _provider.GetProductsAsync(productParameters);
            return Ok(_mapper.Map<List<ProductDTO>>(products.ToList()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int id)
        {
            var product = await _provider.getProductByIdAsync(id);
            return Ok(_mapper.Map<ProductDTO>(product));
        }

        private IMapper InitializeMapper()
        {
            var config = new MapperConfiguration(config =>
                config.CreateMap<Product, ProductDTO>().ReverseMap());

            return config.CreateMapper();
        }
    }
}
