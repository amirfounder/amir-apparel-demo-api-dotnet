using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using amir_apparel_demo_api_dotnet_5.Data.Models;

namespace amir_apparel_demo_api_dotnet_5.Data
{
    public static class RepositoryHelperExtensions
    {
        public static Dictionary<string, string> Clean(this string[] sortables, Type model)
        {
            Dictionary<string, string> map = new();
            List<string> properties = model
                .GetProperties()
                .Select(x => x.Name.ToUpper())
                .ToList();

            foreach (string sortable in sortables)
            {
                string[] fieldValuePair = sortable.Split(",");
                if (fieldValuePair.Length != 2 || !properties.Contains(fieldValuePair[0].ToUpper()))
                {
                    continue;
                }
                map[fieldValuePair[0]] = fieldValuePair[1];
            }

            return map;
        }
    }
}
