using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Amir.Apparel.Demo.Api.Dotnet.API.CustomQueries
{
    public abstract class Filterable<T> : IFilterable<T> where T : class
    {
        public Dictionary<string, string[]> GetFilters()
        {
            var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var filters = new Dictionary<string, string[]>();

            foreach (var property in properties)
            {
                var name = property.Name;
                var value = (string)property.GetValue(this, null);

                if (value == null)
                {
                    continue;
                }

                var values = value
                    .Split(",")
                    .Where(x => x.Trim() != "")
                    .ToArray();

                filters[name] = values;
            }

            return filters;
        }
    }
}
