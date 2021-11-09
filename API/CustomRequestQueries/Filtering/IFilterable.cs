using System.Collections.Generic;

namespace amir_apparel_demo_api_dotnet_5.API.CustomRequestQueries
{
    public interface IFilterable<T> where T : class
    {
        public Dictionary<string, string[]> GetFilters();
    }
}
