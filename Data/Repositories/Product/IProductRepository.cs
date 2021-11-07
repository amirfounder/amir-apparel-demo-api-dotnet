using amir_apparel_demo_api_dotnet_5.Data.Models;

namespace amir_apparel_demo_api_dotnet_5.Data.Repositories
{
    public interface IProductRepository<T> : IRepository<T>
        where T : class, IEntity
    {

    }
}
