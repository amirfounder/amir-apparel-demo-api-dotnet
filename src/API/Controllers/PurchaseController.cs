using Amir.Apparel.Demo.Api.Dotnet.API.CustomQueries;
using Amir.Apparel.Demo.Api.Dotnet.API.DTOs;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using Amir.Apparel.Demo.Api.Dotnet.Providers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.API.Controllers
{
    [Route("products")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseProvider _provider;
        private readonly IMapper _mapper;

        public int FromQuery { get; private set; }

        public PurchaseController(IPurchaseProvider provider, IMapper mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Page<PurchaseResponseDTO>>> GetPurchasesByEmailAsync(
            [FromQuery] PaginationOptions paginationOptions,
            [FromQuery] string email
        )
        {
            var page = await _provider.GetPurchasesByEmailAsync(paginationOptions, email);
            return Ok(page);
        }
    }
}
