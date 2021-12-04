using System;
using System.Collections;
using System.Linq;

namespace Amir.Apparel.Demo.Api.Dotnet.Utilities
{
    public static class BaseExtensions
    {
        public static string Random(this string[] list)
        {
            var rand = new Random();
            var randomIndex = rand.Next(0, list.Length);
            return list[randomIndex];
        }

        public static DateTime Random(this DateTime datetime)
        {
            return datetime;
        }

        public static string Capitalize(this string value)
        {
            return value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
        }

        public static string[] ToStringArray(this object obj)
        {
            return ((IEnumerable)obj).Cast<object>()
                .Where(x => x != null)
                .Select(x => x.ToString())
                .ToArray();
        }
    }
}
