﻿using amir_apparel_demo_api_dotnet_5.API.CustomQueries;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.Data.Repositories;
using amir_apparel_demo_api_dotnet_5.HttpStatusExceptions;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly IProductRepository<Product> _repository;

        public ProductProvider(IProductRepository<Product> repository)
        {
            _repository = repository;
        }


        public async Task<Page<Product>> GetProductsAsync(IPaginationOptions paginationOptions)
        {
            return await _repository.GetAll(paginationOptions);
        }

        public async Task<Product> getProductByIdAsync(int id)
        {
            Product product;

            product = await _repository.Get(id);

            if (product == null)
            {
                throw new NotFoundException("Could not find product with id: " + id);
            }

            return product;
        }
    }
}
