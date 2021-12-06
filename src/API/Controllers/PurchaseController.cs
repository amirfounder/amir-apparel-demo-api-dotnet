using Amir.Apparel.Demo.Api.Dotnet.API.DTOs;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using Amir.Apparel.Demo.Api.Dotnet.Providers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.API.Controllers
{
    [Route("purchases")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseProvider _provider;
        private readonly IMapper _mapper;

        public PurchaseController(IPurchaseProvider provider, IMapper mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<PurchaseResponseDTO>> CreatePurchaseAsync(
            [FromBody] PurchaseRequestDTO purchaseRequestDTO
        )
        {
            var purchaseToSave = _mapper.Map<Purchase>(purchaseRequestDTO);
            var savedPurchase = await _provider.CreatePurchaseAsync(purchaseToSave);
            var purchaseResponseDto = _mapper.Map<PurchaseResponseDTO>(savedPurchase);

            return Created($"/purchases", purchaseResponseDto);
        }
    }
}
