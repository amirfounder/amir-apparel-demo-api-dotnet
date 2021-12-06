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
        Task<IPage<T>> GetAll(IPaginationOptions paginationOptions);
        Task<IPage<T>> GetAll(IPaginationOptions paginationOptions, IFilterable<T> filterable);
        Task<T> GetByProperty(string property, string value);
        Task<IEnumerable> GetDistinct(string property);
        Task<bool> ExistsById(int id);
        Task<T> Save(T entity);

    }
}
