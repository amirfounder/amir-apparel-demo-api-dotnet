﻿using Amir.Apparel.Demo.Api.Dotnet.API.CustomQueries;
using Amir.Apparel.Demo.Api.Dotnet.API.DTOs;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using Amir.Apparel.Demo.Api.Dotnet.Providers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Controllers
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

        [HttpGet("filter")]
        public async Task<ActionResult<Page<ProductDTO>>> GetProductsWithFilterAsync(
            [FromQuery] PaginationOptions paginationOptions,
            [FromQuery] ProductFilter productFilter
        )
        {
            var page = await _provider.GetProductsWithFilterAsync(paginationOptions, productFilter);
            return Ok(page);
        }

        [HttpGet("attributes/{property}")]
        public async Task<ActionResult<IEnumerable>> GetDistinctAsync(string property)
        {
            var distinct = await _provider.GetDistinctAsync(property);
            return Ok(distinct);
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
            var product = await _provider.GetProductByIdAsync(id);
            return Ok(_mapper.Map<ProductDTO>(product));
        }
    }
}
