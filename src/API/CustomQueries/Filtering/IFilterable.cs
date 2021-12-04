using System.Collections.Generic;

namespace Amir.Apparel.Demo.Api.Dotnet.API.CustomQueries
{
    public interface IFilterable<T> where T : class
    {
        public Dictionary<string, string[]> GetFilters();
    }
}
