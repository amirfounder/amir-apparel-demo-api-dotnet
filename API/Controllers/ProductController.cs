using amir_apparel_demo_api_dotnet_5.API;
using amir_apparel_demo_api_dotnet_5.API.QueryParams;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.Providers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public ProductController(IProductProvider provider, IMapper mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Page<ProductDTO>>> GetProductsAsync(
            [FromQuery] PaginationOptions paginationOptions
        )
        {
            var page = await _provider.GetProductsAsync(paginationOptions);
            return Ok(page);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int id)
        {
            var product = await _provider.getProductByIdAsync(id);
            return Ok(_mapper.Map<ProductDTO>(product));
        }
    }
}
