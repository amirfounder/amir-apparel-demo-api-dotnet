using Amir.Apparel.Demo.Api.Dotnet.API.CustomQueries;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Repositories
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
