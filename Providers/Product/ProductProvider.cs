﻿using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.Data.Repositories;
using amir_apparel_demo_api_dotnet_5.Exceptions;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace amir_apparel_demo_api_dotnet_5.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly IProductRepository _repository;

        public ProductProvider(IProductRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _repository.GetProductsAsync();
        }

        public async Task<Product> getProductByIdAsync(int id)
        {
            Product product;

            try
            {
                product = await _repository.GetProductByIdAsync(id);
            }
            catch
            {
                HttpResponseMessage response = new();
                response.ReasonPhrase = "Internal server error";
                response.StatusCode = HttpStatusCode.InternalServerError;
                throw new System.Web.Http.HttpResponseException(response);
            }

            if (product == null)
            {
                throw new NotFoundException("Could not find error");
            }

            return product;
        }
    }
}
