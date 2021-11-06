using System;
using System.Reflection;

namespace amir_apparel_demo_api_dotnet_5.Data.Models.Extensions
{
    public static class IEntityExtensions
    {
        public static PropertyInfo GetProperty(this IEntity item, string name)
        {
            var properties = item.GetPublicAndInstanceProperties();
            return properties.FindPropertyByName(name);
        }

        public static object GetValue(this IEntity item, string name)
        {
            var properties = item.GetPublicAndInstanceProperties();
            return properties.FindPropertyByName(name).GetValue(item, null);
        }

        private static PropertyInfo[] GetPublicAndInstanceProperties(this object item)
        {
            return item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        private static PropertyInfo FindPropertyByName(this PropertyInfo[] properties, string name)
        {
            foreach (var property in properties)
            {
                if (name.ToUpper() == property.Name.ToUpper() && property.CanRead)
                {
                    return property;
                }
            }
            throw new ArgumentException("Could not find property with name: " + name);
        }
    }
}
