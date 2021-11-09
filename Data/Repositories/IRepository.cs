﻿using amir_apparel_demo_api_dotnet_5.API.CustomRequestQueries;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<Page<T>> GetAll(IPaginationOptions paginationOptions);
        Task<Page<T>> GetAll(IPaginationOptions paginationOptions, IFilterable<T> filterable);
        Task<IEnumerable> GetDistinct(string property);
    }
}
